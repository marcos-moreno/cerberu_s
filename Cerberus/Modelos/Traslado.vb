Imports System.Data.SqlClient
Imports Cerberus

Public Class Traslado
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idTraslado As Integer
    Public idVisita As Integer
    Public salida As DateTime
    Public llegada As DateTime
    Public tiempoTraslado As Decimal
    Public tipoTraslado As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idCuenta As Integer

    Public cta As Cuenta

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function generaCxP(idEmpleado As Integer,
                              fechaCuenta As Date,
                              idSucursal As Integer,
                              nombreSuc As String,
                              CHET As Decimal,
                              idConcepto As Integer,
                              tipoPago As String,
                              valorPago As Decimal) As Boolean
        Dim CxP As New Cuenta(Ambiente)

        CxP.estado = "CO"
        CxP.descripccion = "Pago de Traslado " & If(tipoTraslado = 1, "LOCAL - Sucursal Foranea", "Sucursal Foranea - LOCAL") & " " & FormatNumber(tiempoTraslado) & " Hrs."
        CxP.esCuentaManual = False
        CxP.fechaCuenta = fechaCuenta
        CxP.idEmpleado = idEmpleado
        CxP.idEmpresa = Ambiente.empr.idEmpresa
        CxP.idSucursal = idSucursal
        CxP.monto = If(tipoPago = "F", valorPago, (tiempoTraslado * CHET) * (valorPago / 100))
        CxP.sistemaOrigen = "Traslado.GeneraCxP"
        CxP.tipoCuenta = "CxP"

        If CxP.guardar Then
            Dim CxPD As New CuentaDetalle(Ambiente)
            CxPD.descripccion = "Pago de Traslado " & If(tipoTraslado = 1, "LOCAL - Sucursal Foranea", "Sucursal Foranea - LOCAL") &
                " " & FormatNumber(tiempoTraslado) & " Hrs." & vbCrLf &
                "REGLA: (" & tipoPago & ") " & " VALOR: " & FormatNumber(valorPago) & " CHET: " & FormatCurrency(CHET)

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTraslado = rdr("idTraslado")
        idVisita = rdr("idVisita")
        salida = rdr("salida")
        llegada = rdr("llegada")
        tiempoTraslado = rdr("tiempoTraslado")
        tipoTraslado = rdr("tipoTraslado")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idCuenta = If(IsDBNull(rdr("idCuenta")), Nothing, rdr("idCuenta"))
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
            conex.tabla = "Traslado"
            conex.accion = accion

            conex.agregaCampo("idVisita", idVisita, False, False)
            conex.agregaCampo("salida", salida, False, False)
            conex.agregaCampo("llegada", llegada, False, False)
            conex.agregaCampo("tiempoTraslado", tiempoTraslado, False, False)
            conex.agregaCampo("tipoTraslado", tipoTraslado, False, False)
            conex.agregaCampo("idCuenta", idCuenta, True, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idTraslado = " & idTraslado

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "Traslado.armaQry" & vbCrLf & conex.descripError
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
                idTraslado = conex.reader("ID")
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
        Return armaQry("DELETE", True)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "Traslado"

        conex.condicion = "WHERE idTraslado=" & idTraslado

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function buscarPVisita() As Boolean
        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "Traslado"

        conex.condicion = "WHERE idVisita=" & idVisita & " AND tipoTraslado=" & tipoTraslado

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se encontraron resultados..."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function getCuenta() As Cuenta
        If cta Is Nothing Then
            cta = New Cuenta(Ambiente)
            cta.idCuenta = idCuenta
            cta.buscarPID()
        End If

        Return cta
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        creadoPor = Ambiente.usuario.idEmpleado
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
