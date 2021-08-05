Imports System.Data.SqlClient
Imports Cerberus
Public Class Ruta

    Implements InterfaceTablas

    'Variables de tabla

    Public idRuta As Integer
    Public nombre As String
    Public origen As Integer
    Public destino As Integer
    Public kmRecorrido As Decimal
    Public coordenadasOrigen As String
    Public coordenadasDestino As String
    Public idEmpleado As Integer
    Public fechaSalida As DateTime
    Public fechaRegreso As DateTime
    Public estadoDocumento As String
    Public idCuenta As Integer
    Public creadoPor As String
    Public creado As DateTime
    Public actualizadoPor As Integer
    Public idSucursal As Integer
    Public idEmpresa As Integer
    Public comentario As String

    'Variables y objetos
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private edoDocs As EstadoDocumentos
    Public idError As Integer
    Public descripError As String
    Private objCuenta As Cuenta
    Private objActualizadoPor As Empleado

    Private metPago As MetodoPagoRuta


    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        edoDocs = New EstadoDocumentos
    End Sub


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idRuta = rdr("idRuta")
        nombre = rdr("nombre")
        origen = rdr("origen")
        destino = rdr("destino")
        kmRecorrido = rdr("kmRecorrido")
        coordenadasOrigen = If(IsDBNull(rdr("coordenadasOrigen")), Nothing, rdr("coordenadasOrigen"))
        coordenadasDestino = If(IsDBNull(rdr("coordenadasDestino")), Nothing, rdr("coordenadasDestino"))
        idEmpleado = rdr("idEmpleado")
        fechaSalida = rdr("fechaSalida")
        fechaRegreso = rdr("fechaRegreso")
        estadoDocumento = rdr("estadoDocumento")
        idCuenta = If(IsDBNull(rdr("idCuenta")), Nothing, rdr("idCuenta"))
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        idSucursal = rdr("idSucursal")
        idEmpresa = rdr("idEmpresa")
        comentario = rdr("comentario")
    End Sub

    Public Sub cargaGridCom(obj As List(Of Ruta), dgv As DataGridView)
        cargarGridGen(dgv, "", obj)
    End Sub

    Private Sub cargarGridGen(dgv As DataGridView, vvv As String, obj As List(Of Ruta))

        Dim plantilla As Ruta
        Dim dtb As New DataTable("Ruta")
        Dim row As DataRow

        dtb.Columns.Add("Nombre", Type.GetType("System.String"))
        dtb.Columns.Add("Origen", Type.GetType("System.String"))
        dtb.Columns.Add("Destino", Type.GetType("System.String"))
        dtb.Columns.Add("Kilómetros Recorridos", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Salida", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Regreso", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))

        obj.Clear()
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.agregaCampo("Ruta.*")
        conex.agregaCampo("Empleado.nombreEmpleado")
        conex.agregaCampo("Cuenta.noDocumento")
        conex.agregaCampo("O.nombreSucursal as SucOri")
        conex.agregaCampo("D.nombreSucursal as SucDest")
        conex.agregaCampo("Empleado.apPatEmpleado")
        conex.agregaCampo("Empleado.apMatEmpleado")
        conex.tabla = "Ruta LEFT JOIN cuenta ON cuenta.idCuenta = ruta.idCuenta "
        conex.tabla &= "inner join Empleado on Empleado.idEmpleado=Ruta.idEmpleado "
        conex.tabla &= "INNER JOIN Sucursal as O on Origen = O.idSucursal "
        conex.tabla &= "INNER JOIN Sucursal as D on Destino = D.idSucursal "
        conex.condicion = "WHERE Ruta.idEmpresa = " & idEmpresa

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Ruta(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow

                row("Nombre") = plantilla.nombre
                row("Origen") = conex.reader("SucOri")
                row("Destino") = conex.reader("SucDest")
                row("Kilómetros Recorridos") = plantilla.kmRecorrido
                row("Empleado") = conex.reader("NombreEmpleado") & " " & conex.reader("apPatEmpleado") & " " & conex.reader("apMatEmpleado")
                row("Fecha Salida") = Format(plantilla.fechaSalida, "dd/MM/yyyy")
                row("Fecha Regreso") = Format(plantilla.fechaRegreso, "dd/MM/yyyy")
                row("Estado") = plantilla.getNombreEstado

                dtb.Rows.Add(row)
            End While
            conex.reader.Close()

            dgv.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Ruta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry


        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Ruta"
            conex.accion = accion


            conex.agregaCampo("nombre", nombre, False, False)
            conex.agregaCampo("origen", origen, False, False)
            conex.agregaCampo("destino", destino, False, False)
            conex.agregaCampo("kmRecorrido", kmRecorrido, False, False)
            conex.agregaCampo("coordenadasOrigen", coordenadasOrigen, True, False)
            conex.agregaCampo("coordenadasDestino", coordenadasDestino, True, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("fechaSalida", fechaSalida, False, False)
            conex.agregaCampo("fechaRegreso", fechaRegreso, False, False)
            conex.agregaCampo("estadoDocumento", estadoDocumento, False, False)
            conex.agregaCampo("idCuenta", idCuenta, True, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("comentario", comentario, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idRuta = " & idRuta

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                MsgBox("Error")
                idError = conex.idError
                descripError = "Ruta.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Public Sub CancelarCuenta(idCuenta As Integer)
        MsgBox(idCuenta)
    End Sub

    Private Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idRuta = conex.reader("ID")
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

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If estadoDocumento = "BO" Then
            Return armaQry("DELETE", False)
        ElseIf estadoDocumento = "CO" Then
            Dim objCuenta As New Cuenta(Ambiente)
            objCuenta.idCuenta = idCuenta
            objCuenta.buscarPID()
            objCuenta.eliminar()

            actualizarEstadoRuta(idRuta)

            Return True
        Else
            idError = 1
            descripError = "No se pudo eliminar la ruta..."
            Return False
        End If
    End Function

    Private Function actualizarEstadoRuta(idRuta As Integer) As Boolean

        Dim acc As String = "UPDATE"
        conex.numCon = 0
        conex.tabla = "Ruta"
        conex.accion = acc

        conex.agregaCampo("estadoDocumento", "CA", False, False)
        conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
        conex.agregaCampo("actualizadoPor", Ambiente.usuario.idEmpleado, False, False)

        'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
        conex.condicion = "WHERE idRuta = " & idRuta

        conex.armarQry()

        Console.WriteLine(conex.Qry)
        If conex.ejecutaQry Then
            If acc = "INSERT" Then
                Return obtenerID()
            Else
                Return True
            End If
        Else
            MsgBox("Error")
            idError = conex.idError
            descripError = "Ruta.armaQry" & vbCrLf & conex.descripError
            Return False
        End If
        Return False
    End Function

    Public Function getColorEstado() As Color
        Return edoDocs.getColor(estadoDocumento)
    End Function
    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.tabla = "Ruta"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idRuta=" & idRuta
        conex.armarQry()

        If conex.ejecutaConsulta() Then
            seteaDatos(conex.reader)

            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(esNuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos

        If nombre = Nothing Then
            idError = 1
            descripError = "El campo nombre es obligatorio"
            Return False
        End If
        If origen = Nothing Then
            idError = 1
            descripError = "Seleccione una ruta de Origen"
            Return False
        End If
        If destino = Nothing Then
            idError = 1
            descripError = "Seleccione una ruta de destino"
            Return False
        End If
        If kmRecorrido = Nothing Then
            idError = 1
            descripError = "Ingrese los KM recorridos"
            Return False
        End If

        If idEmpleado = Nothing Then
            idError = 1
            descripError = "Seleccione a un empleado para continuar"
            Return False
        End If
        Dim objEmpleado As New Empleado(Ambiente)
        objEmpleado.idEmpleado = idEmpleado
        objEmpleado.buscarPID()
        If esNuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        actualizadoPor = Ambiente.usuario.idEmpleado
        idEmpresa = Ambiente.empr.idEmpresa
        idSucursal = objEmpleado.idSucursal
        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Return Nothing
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        If objActualizadoPor Is Nothing Then
            objActualizadoPor = New Empleado(Ambiente)
            objActualizadoPor.idEmpleado = actualizadoPor
            objActualizadoPor.buscarPID()
        End If

        Return objActualizadoPor
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        'Obtiene el valor del id de la tabla Empresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function

    Public Function getSucForanea(idSucursal As Integer) As Sucursal
        Dim objSucursal As New Sucursal(Ambiente)
        objSucursal.idSucursal = idSucursal
        objSucursal.buscarPID()

        Return objSucursal
    End Function

    Public Function getCuenta() As Cuenta
        If objCuenta Is Nothing Then
            objCuenta = New Cuenta(Ambiente)
            objCuenta.idCuenta = idCuenta
            If Not objCuenta.buscarPID() Then
                MsgBox(objCuenta.descripError)
            End If
        End If

        Return objCuenta
    End Function

    Public Function moverEstadoDocumento(nuevoEstado As String, accion As Integer) As Boolean
        'accion = 1 GUARDAR     accion = 2 ACTUALIZAR
        Dim estadoAnt As String
        Dim acc As String
        Dim accBool As Boolean
        Dim descrip As String

        Dim cuenta As New Cuenta(Ambiente)
        Dim cuentaDetalle As New CuentaDetalle(Ambiente)
        estadoAnt = estadoDocumento
        estadoDocumento = nuevoEstado

        If accion = 1 Then
            acc = "INSERT"
            accBool = True
        Else
            acc = "UPDATE"
            accBool = False
        End If

        If armaQry(acc, accBool) Then
            If estadoDocumento = "CO" Then
                'Si el estado de documento es completo, disparará la CxP

                Dim empl As New Empleado(Ambiente)
                empl.idEmpleado = idEmpleado
                empl.buscarPID()

                metPago = New MetodoPagoRuta(Ambiente)

                If Not metPago.buscarPKM(kmRecorrido) Then
                    idError = metPago.idError
                    descripError = metPago.descripError
                    Return False
                End If

                descrip = ""
                descrip &= "Origen: " & getSucForanea(origen).nombreSucursal
                descrip &= "  Destino: " & getSucForanea(destino).nombreSucursal
                descrip &= " """ & comentario & """"

                generaCxP(empl.idEmpleado,
                          empl.idEmpresa,
                           fechaRegreso,
                           empl.idSucursal,
                           metPago.idConceptoCuenta,
                           metPago.valorMetodo,
                          descrip)
                Return True
            End If
        Else
            Return False
        End If
        Return True
    End Function


    Public Function generaCxP(idEmpleado As Integer,
                              idEmpresa As Integer,
                              fechaCuenta As Date,
                               idSucursal As Integer,
                               idConcepto As Integer,
                               valorPago As Decimal,
                              descripCuenta As String) As Boolean

        Dim CxP As New Cuenta(Ambiente)

        CxP.estado = "CO"
        CxP.esCuentaManual = False
        CxP.fechaCuenta = fechaCuenta
        CxP.idEmpleado = idEmpleado
        CxP.idEmpresa = idEmpresa
        CxP.idSucursal = idSucursal
        CxP.monto = valorPago
        CxP.sistemaOrigen = "Ruta.GeneraCxP"
        CxP.descripccion = "Pago de Ruta FORANEA: " & descripCuenta
        CxP.tipoCuenta = "CxP"

        If CxP.guardar Then
            Dim CxPD As New CuentaDetalle(Ambiente)
            CxPD.descripccion = "Pago de Ruta FORANEA: " & descripCuenta

            CxPD.idConceptoCuenta = idConcepto
            CxPD.idCuenta = CxP.idCuenta
            CxPD.monto = CxP.monto
            If Not CxPD.guardar Then
                idError = CxPD.idError
                descripError = CxPD.descripError
                Return False
            Else
                idCuenta = CxP.idCuenta
                If Not actualizar() Then
                    Return False
                End If
            End If
        Else
            idError = CxP.idError
            descripError = CxP.descripError
            Return False
        End If
        Return True
    End Function

    Public Function getNombreEstado() As String
        Return edoDocs.getNombreEstado(estadoDocumento)
    End Function
End Class
