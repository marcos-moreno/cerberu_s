Imports System.Data.SqlClient
Imports Cerberus

Public Class DestajoPago
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idDestajoPago As Integer
    Public idDestajo As Integer
    Public idCuenta As Integer
    Public idCuentaDetalle As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public idDestajoFactorBurbuja As Integer
    Public porcentajeFactor As Decimal
    Public idDestajoClasificacionPuntos As Integer
    Public montoPagoClasificacion As Decimal

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function pagarDestajos(obj As List(Of Destajo), fechaCuenta As Date, idConceptoAbono As Integer, ByRef numCuenta As String, ByRef totalCuenta As Decimal) As Boolean
        Dim plantilla As New Cuenta(Ambiente)
        Dim plantillaDetalle As New CuentaDetalle(Ambiente)
        Dim plantillaPago As DestajoPago
        Dim objEmpl As Empleado

        Dim idSucursalAct As Integer
        Dim idEmpleadoAct As Integer
        Dim idEmpleadoAnt As Integer
        Dim descrip As String
        Dim monto As Decimal
        Dim montoCta As Decimal
        Dim descuento As Decimal
        Dim destajoPagado As Boolean
        Dim veces As Integer

        idError = Nothing
        descripError = ""

        If obj.Count = 0 Then
            Return True
        End If

        For i As Integer = 0 To obj.Count - 1
            idEmpleadoAct = obj(i).idEmpleado
            monto = obj(i).montoDestajo
            destajoPagado = obj(i).esPagado

            If Not destajoPagado Then
                veces += 1

                If idEmpleadoAct <> idEmpleadoAnt Then
                    objEmpl = New Empleado(Ambiente)
                    objEmpl.idEmpleado = idEmpleadoAct
                    objEmpl.buscarPID()

                    idSucursalAct = objEmpl.idSucursal

                    descuento = 0

                    If i > 0 Then
                        If objEmpl.idDestajoClasificacionEmpeado <> Nothing Then
                            descuento = montoCta - (montoCta * (objEmpl.getDestajoClasificacion.porcentajePago / 100))
                        End If

                        If descuento > 0 Then
                            plantillaDetalle = New CuentaDetalle(Ambiente)
                            plantillaDetalle.idCuenta = plantilla.idCuenta
                            plantillaDetalle.idConceptoCuenta = idConceptoAbono
                            plantillaDetalle.monto = descuento * -1
                            plantillaDetalle.descripccion = "DESCUENTO X PERFIL DESTAJO: (" & objEmpl.getDestajoClasificacion.nombreClasificacion & ")"

                            If Not plantillaDetalle.guardar() Then
                                idError = conex.idError
                                descripError &= "Cuenta.Detalle: " & plantillaDetalle.descripError & vbCrLf
                            End If
                        End If

                        plantilla.monto = montoCta - descuento
                        plantilla.descripccion = "PAGO DESTAJO REF: " & descrip

                        If Not plantilla.actualizar() Then
                            idError = plantilla.idError
                            descripError &= "Cuenta ACT: " & plantilla.descripError & vbCrLf
                        End If
                    End If

                    plantilla = New Cuenta(Ambiente)
                    plantilla.tipoCuenta = "CxP"
                    plantilla.idEmpresa = idEmpresa
                    plantilla.idSucursal = idSucursalAct
                    plantilla.idEmpleado = idEmpleadoAct
                    plantilla.fechaCuenta = fechaCuenta
                    plantilla.estado = "CO"
                    plantilla.esCuentaManual = True
                    plantilla.sistemaOrigen = "Destajo.Pago"
                    plantilla.descripccion = "PAGO DESTAJO REF: "

                    montoCta = monto
                    descrip = obj(i).referenciaExterna & ","

                    If Not plantilla.guardar() Then
                        idError = plantilla.idError
                        descripError &= "Cuenta: " & plantilla.descripError & vbCrLf
                    End If
                Else
                    montoCta += monto
                    descrip = descrip.Replace(obj(i).referenciaExterna & ",", "")
                    descrip &= obj(i).referenciaExterna & ","
                End If

                plantillaDetalle = New CuentaDetalle(Ambiente)
                plantillaDetalle.idCuenta = plantilla.idCuenta
                plantillaDetalle.idConceptoCuenta = idConceptoAbono
                plantillaDetalle.monto = monto
                plantillaDetalle.descripccion = "PAGO DESTAJO (" & obj(i).referenciaExterna & ") - " & obj(i).etiqueta & " (" & obj(i).getEtapa.nombreEtapa & ") - " & Format(obj(i).fechaDestajo, "dd/MM/yyyy") & ""

                If Not plantillaDetalle.guardar() Then
                    idError = conex.idError
                    descripError &= "Cuenta.Detalle: " & plantillaDetalle.descripError & vbCrLf
                Else
                    plantillaPago = New DestajoPago(Ambiente)
                    plantillaPago.idDestajo = obj(i).idDestajo
                    plantillaPago.idCuenta = plantilla.idCuenta
                    plantillaPago.idCuentaDetalle = plantillaDetalle.idCuentaDetalle
                    plantillaPago.idEmpresa = idEmpresa
                    plantillaPago.idSucursal = idSucursalAct
                    plantillaPago.idDestajoFactorBurbuja = Nothing
                    plantillaPago.porcentajeFactor = Nothing
                    plantillaPago.idDestajoClasificacionPuntos = Nothing
                    plantillaPago.montoPagoClasificacion = Nothing

                    If Not plantillaPago.guardar() Then
                        idError = conex.idError
                        descripError &= "DestajoPago.Guardar: " & plantillaPago.descripError & vbCrLf
                    Else
                        obj(i).esPagado = True
                        If Not obj(i).actualizar() Then
                            idError = conex.idError
                            descripError &= "Destajo.Actualizar: " & obj(i).descripError & vbCrLf
                        End If
                    End If
                End If
            End If

            idEmpleadoAnt = idEmpleadoAct
        Next

        '***************
        If veces > 0 Then
            objEmpl = New Empleado(Ambiente)
            objEmpl.idEmpleado = idEmpleadoAct
            objEmpl.buscarPID()

            descuento = 0

            If objEmpl.idDestajoClasificacionEmpeado <> Nothing Then
                descuento = montoCta - (montoCta * (objEmpl.getDestajoClasificacion.porcentajePago / 100))
            End If

            If descuento > 0 Then
                plantillaDetalle = New CuentaDetalle(Ambiente)
                plantillaDetalle.idCuenta = plantilla.idCuenta
                plantillaDetalle.idConceptoCuenta = idConceptoAbono
                plantillaDetalle.monto = descuento * -1
                plantillaDetalle.descripccion = "DESCUENTO DEL (" & (100 - objEmpl.getDestajoClasificacion.porcentajePago) & " %) X PERFIL DESTAJO COLABORADOR >> " & objEmpl.getDestajoClasificacion.nombreClasificacion & " (" & objEmpl.getDestajoClasificacion.porcentajePago & " %)"

                If Not plantillaDetalle.guardar() Then
                    idError = conex.idError
                    descripError &= "Cuenta.Detalle: " & plantillaDetalle.descripError & vbCrLf
                End If
            End If

            plantilla.monto = montoCta - descuento
            plantilla.descripccion = "PAGO DESTAJO REF: " & descrip

            If Not plantilla.actualizar() Then
                idError = plantilla.idError
                descripError &= "Cuenta ACT: " & plantilla.descripError & vbCrLf
            End If
        End If
        '********************

        If idError = Nothing Then
            numCuenta = plantilla.noDocumento
            totalCuenta = plantilla.monto
            Return True
        Else
            numCuenta = Nothing
            totalCuenta = Nothing
            Return False
        End If

    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDestajoPago = rdr("idDestajoPago")
        idDestajo = rdr("idDestajo")
        idCuenta = rdr("idCuenta")
        idCuentaDetalle = rdr("idCuentaDetalle")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        idDestajoFactorBurbuja = If(IsDBNull(rdr("idDestajoFactorBurbuja")), Nothing, rdr("idDestajoFactorBurbuja"))
        porcentajeFactor = If(IsDBNull(rdr("porcentajeFactor")), Nothing, rdr("porcentajeFactor"))
        idDestajoClasificacionPuntos = If(IsDBNull(rdr("idDestajoClasificacionPuntos")), Nothing, rdr("idDestajoClasificacionPuntos"))
        montoPagoClasificacion = If(IsDBNull(rdr("montoPagoClasificacion")), Nothing, rdr("montoPagoClasificacion"))
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "DestajoPago"
            conex.accion = accion

            conex.agregaCampo("idDestajo", idDestajo, False, False)
            conex.agregaCampo("idCuenta", idCuenta, False, False)
            conex.agregaCampo("idCuentaDetalle", idCuentaDetalle, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)

            conex.agregaCampo("idDestajoFactorBurbuja", idDestajoFactorBurbuja, True, False)
            conex.agregaCampo("porcentajeFactor", porcentajeFactor, True, False)
            conex.agregaCampo("idDestajoClasificacionPuntos", idDestajoClasificacionPuntos, True, False)
            conex.agregaCampo("montoPagoClasificacion", montoPagoClasificacion, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idDestajoPago = " & idDestajoPago

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idDestajoPago = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo Obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado
        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function
End Class
