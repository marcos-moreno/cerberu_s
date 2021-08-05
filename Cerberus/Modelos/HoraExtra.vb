Imports System.Data.SqlClient
Imports Cerberus

Public Class HoraExtra
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idHoraExtra As Integer
    Public idEmpleado As Integer
    Public idEmpresa As Integer
    Public fecha As Date
    Public idRegistro As Integer
    Public idHorario As Integer
    Public horaSalida As DateTime
    Public tiempoGenerado As DateTime
    Public esAutorizado As Boolean
    Public autorizadoPor As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idHoraExtra = rdr("idHoraExtra")
        idEmpleado = rdr("idEmpleado")
        idEmpresa = rdr("idEmpresa")
        fecha = rdr("fecha")
        idRegistro = rdr("idRegistro")
        idHorario = rdr("idHorario")
        horaSalida = rdr("horaSalida")
        tiempoGenerado = rdr("tiempoGenerado")
        esAutorizado = rdr("esAutorizado")
        autorizadoPor = rdr("autorizadoPor")
    End Sub

    Public Function buscarXPeriodo(fechaInicio As Date, fechaFin As Date, objHorasExtra As List(Of HoraExtra)) As Boolean
        Dim plantilla As HoraExtra

        conex.numCon = 0
        conex.tabla = "HoraExtra"
        conex.accion = "SELECT"
        conex.agregaCampo("*")

        conex.condicion = "WHERE fecha BETWEEN idEmpleado = " & idEmpleado & "  idEmpresa = " & idEmpresa & " AND convert(date,'" & Format(fechaInicio, "yyyy-MM-dd") & "') AND convert(date,'" & Format(fechaFin, "yyyy-MM-dd") & "')"

        objHorasExtra.Clear()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New HoraExtra(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objHorasExtra.Add(plantilla)
            End While
            conex.reader.Close()

            Return True
        Else
            idError = 1
            descripError = "No se encontro nigún Registro en el periodo indicado..."
            Return False
        End If
    End Function

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Throw New NotImplementedException()
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Throw New NotImplementedException()
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
        Throw New NotImplementedException()
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        Throw New NotImplementedException()
    End Function
End Class
