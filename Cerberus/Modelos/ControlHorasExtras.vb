Imports System.Data.SqlClient
Imports Cerberus

Public Class ControlHorasExtras
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Public idEmpleado As Integer
    Public idPeriodo As Integer
    Public tienenHorasExtrasAut As Boolean
    Public forzarLimiteHorasExtras As Boolean
    Public cantidadHoras As Decimal
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public creado As DateTime
    Public creadoPor As Integer

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEmpleado = rdr("idEmpleado")
        idPeriodo = rdr("idPeriodo")
        tienenHorasExtrasAut = rdr("tienenHorasExtrasAut")
        forzarLimiteHorasExtras = rdr("forzarLimiteHorasExtras")
        cantidadHoras = rdr("cantidadHoras")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
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
            conex.tabla = "ControlHorasExtras"
            conex.accion = accion

            conex.agregaCampo("tienenHorasExtrasAut", tienenHorasExtrasAut, False, False)
            conex.agregaCampo("forzarLimiteHorasExtras", forzarLimiteHorasExtras, False, False)
            conex.agregaCampo("cantidadHoras", cantidadHoras, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEmpleado=" & idEmpleado & " AND idPeriodo=" & idPeriodo

            conex.armarQry()

            If conex.ejecutaQry Then
                Return True
            Else
                idError = conex.idError
                descripError = "ControlHorasExtras.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function creaHoras() As Boolean
        conex.numCon = 0
        conex.Qry = "EXEC spCreaControHoras " & idPeriodo & "," & Ambiente.usuario.idEmpleado

        If conex.ejecutaQry() Then
            Return True
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
        conex.numCon = 0

        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.tabla = "ControlHorasExtras"

        conex.condicion = "WHERE idEmpleado=" & idEmpleado & " AND idPeriodo=" & idPeriodo

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro nigún Registro en el periodo indicado..."
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
