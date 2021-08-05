Imports System.Data.SqlClient
Imports Cerberus

Public Class nom10010
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idmovtodyh As Integer
    Public idperiodo As Integer
    Public idempleado As Integer
    Public idtipoincidencia As Integer
    Public idtarjetaincapacidad As Integer
    Public idtcontrolvacaciones As Integer
    Public fecha As DateTime
    Public valor As Decimal
    Public timestamp As DateTime

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idmovtodyh = rdr("idmovtodyh")
        idperiodo = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        idempleado = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        idtipoincidencia = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        idtarjetaincapacidad = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        idtcontrolvacaciones = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        fecha = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        valor = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
        timestamp = If(IsDBNull(rdr("idperiodo")), 0, rdr("idperiodo"))
    End Sub

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
