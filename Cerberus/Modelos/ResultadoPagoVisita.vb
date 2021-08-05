Imports System.Data.SqlClient
Imports Cerberus

Public Class ResultadoPagoVisita
    Implements InterfaceTablas

    Public idResultadoPagoVisita As Integer
    Public idVisita As Integer
    Public idResultadoPeriodoES As Integer
    Public idSucursal As Integer
    Public totalHoras As Decimal
    Public observaciones As String
    Public idCuenta As Integer
    Public idConceptoCuenta As Integer
    Public CHET As Decimal
    Public limiteHoras As Decimal

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function getPagoVisitas(objPagos As List(Of ResultadoPagoVisita)) As Boolean
        Dim objRPV As ResultadoPagoVisita
        objPagos.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "ResultadoPagoVisita"

        conex.condicion = "WHERE idResultadoPeriodoES = " & idResultadoPeriodoES

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                objRPV = New ResultadoPagoVisita(Ambiente)
                objRPV.seteaDatos(conex.reader)

                objPagos.Add(objRPV)
            End While
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idResultadoPagoVisita = rdr("idResultadoPagoVisita")
        idVisita = rdr("idVisita")
        idResultadoPeriodoES = rdr("idResultadoPeriodoES")
        idSucursal = rdr("idSucursal")
        totalHoras = rdr("totalHoras")
        observaciones = If(IsDBNull(rdr("observaciones")), Nothing, rdr("observaciones"))
        idCuenta = If(IsDBNull(rdr("idCuenta")), Nothing, rdr("idCuenta"))
        idConceptoCuenta = rdr("idConceptoCuenta")
        CHET = rdr("CHET")
        limiteHoras = rdr("limiteHoras")
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
            conex.tabla = "ResultadoPagoVisita"
            conex.accion = accion

            conex.agregaCampo("idVisita", idVisita, False, False)
            conex.agregaCampo("idResultadoPeriodoES", idResultadoPeriodoES, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("totalHoras", totalHoras, False, False)
            conex.agregaCampo("observaciones", observaciones, True, False)
            conex.agregaCampo("idCuenta", idCuenta, True, False)
            conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)
            conex.agregaCampo("CHET", CHET, False, False)
            conex.agregaCampo("limiteHoras", limiteHoras, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idResultadoPagoVisita = " & idResultadoPagoVisita

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "ResultadoPagoVisita.armaQry" & vbCrLf & conex.descripError
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
                idResultadoPagoVisita = conex.reader("ID")
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
