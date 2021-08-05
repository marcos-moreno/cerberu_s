Imports System.Data.SqlClient
Imports Cerberus

Public Class HorarioDetalle
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idHorario As Integer
    Public numDia As Integer
    Public horaInicial As DateTime
    Public horaFinal As DateTime
    Public minLaborar As DateTime
    Public tiempoComida As DateTime

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Private Function almacenaHorarioDetalle() As Boolean
        Dim objParam(6, 2) As Object

        objParam(0, 0) = "@idHorario"
        objParam(0, 1) = idHorario

        objParam(1, 0) = "@horaInicial"
        objParam(1, 1) = horaInicial

        objParam(2, 0) = "@horaFinal"
        objParam(2, 1) = horaFinal

        objParam(3, 0) = "@minLaborar"
        objParam(3, 1) = minLaborar

        objParam(4, 0) = "@numDia"
        objParam(4, 1) = numDia

        objParam(5, 0) = "@tiempoComida"
        objParam(5, 1) = tiempoComida

        conex.numCon = 0
        conex.Qry = "spAlmacenaHorarioDetalle"

        If conex.ejecutaSP(objParam) Then
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "HorarioDetalle"
            conex.accion = accion

            conex.agregaCampo("idHorario", idHorario, False, False)
            conex.agregaCampo("horaInicial", horaInicial, False, False)
            conex.agregaCampo("horaFinal", horaFinal, False, False)
            conex.agregaCampo("minLaborar", minLaborar, False, False)
            conex.agregaCampo("tiempoComida", tiempoComida, False, False)
            conex.agregaCampo("numDia", numDia, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idHorario = " & idHorario & " AND numDia = " & numDia

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

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idHorario = rdr("idHorario")
        numDia = rdr("numDia")
        horaInicial = DateTime.Parse(rdr("horaInicial").ToString)
        horaFinal = DateTime.Parse(rdr("horaFinal").ToString)
        minLaborar = DateTime.Parse(rdr("minLaborar").ToString)
        tiempoComida = DateTime.Parse(rdr("tiempoComida").ToString)
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return almacenaHorarioDetalle()
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Throw New NotImplementedException()
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        idError = 0
        descripError = ""

        conex.numCon = 0
        conex.tabla = "HorarioDetalle"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idHorario=" & idHorario & " AND numDia=" & numDia

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No Existe Registro..."
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
