Imports System.Data.SqlClient
Imports Cerberus

Public Class Consecutivo
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idConsecutivo As Integer
    Public tabla As String
    Public dato As String
    Public consecutivo As Integer
    Public prefijo As String
    Public idEmpresa As Integer

    Public siguienteConsecutivo As String

    Private Function armaConsec() As String
        Return (prefijo & consecutivo)
    End Function

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function generaSiguienteConsec() As Boolean
        If buscaXDato() Then
            consecutivo += 1
            siguienteConsecutivo = armaConsec()

            If actualizar() Then
                Return True
            Else
                Return False
            End If
        Else
            consecutivo += 1
            siguienteConsecutivo = armaConsec()

            If guardar() Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function buscaXDato() As Boolean
        conex.numCon = 0
        conex.tabla = "Consecutivo"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE dato = '" & dato & "' AND idEmpresa=" & idEmpresa
        conex.armarQry()

        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

        Return True
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idConsecutivo = rdr("idConsecutivo")
        tabla = rdr("tabla")
        dato = rdr("dato")
        consecutivo = rdr("consecutivo")
        prefijo = rdr("prefijo")
        idEmpresa = rdr("idEmpresa")
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Consecutivo"
            conex.accion = accion

            conex.agregaCampo("tabla", tabla, False, False)
            conex.agregaCampo("dato", dato, False, False)
            conex.agregaCampo("consecutivo", consecutivo, False, False)
            conex.agregaCampo("prefijo", prefijo, True, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idConsecutivo = " & idConsecutivo

            conex.armarQry()

            If conex.ejecutaQry Then
                Return True
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function actualizar() As Boolean Implements InterfaceTablas.actualizar
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
