Imports System.Data.SqlClient
Imports Cerberus

Public Class TiempoXTiempo
    Implements InterfaceTablas

    Public idTiempoxTiempo As Integer
    Public idEmpleado As Integer
    Public idResultadoPeriodoES As Integer
    Public idIncidencia As Integer
    Public idEmpresa As Integer
    Public tipoMov As String
    Public valor As Decimal

    Public idError As Integer
    Public descripError As String

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idTiempoxTiempo = rdr("idTiempoxTiempo")
        idEmpleado = rdr("idEmpleado")
        idResultadoPeriodoES = If(IsDBNull(rdr("idResultadoPeriodoES")), Nothing, rdr("idResultadoPeriodoES"))
        idIncidencia = If(IsDBNull(rdr("idIncidencia")), Nothing, rdr("idIncidencia"))
        idEmpresa = rdr("idEmpresa")
        tipoMov = rdr("tipoMov")
        valor = rdr("valor")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
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
        idEmpresa = Ambiente.empr.idEmpresa
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "TiempoXTiempo"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idResultadoPeriodoES", idResultadoPeriodoES, False, False)
            conex.agregaCampo("idIncidencia", idIncidencia, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("tipoMov", tipoMov, False, False)
            conex.agregaCampo("valor", valor, False, False)

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    ObtenerID()
                End If
                Return True
            Else
                idError = conex.idError
                descripError = "TiempoXTiempo.ArmaQry: " & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function ObtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idTiempoxTiempo = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function minutosDisponibles() As Decimal
        Dim tiempo As Decimal

        idError = 0

        conex.numCon = 0
        conex.Qry = "SELECT ISNULL(sum(iif(tipoMov = 'S', valor*-1,valor)),0) as tiempoDisponible FROM TiempoXTiempo where idEmpleado = " & idEmpleado

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                tiempo = conex.reader("tiempoDisponible")
            End If
            conex.reader.Close()
        Else
            idError = conex.idError
            descripError = conex.descripError
        End If

        Return tiempo
    End Function
End Class
