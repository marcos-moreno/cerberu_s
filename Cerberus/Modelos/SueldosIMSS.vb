Imports System.Data.SqlClient
Imports Cerberus

Public Class SueldosIMSS
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As String
    Public descripError As String

    Public idSueldoIMSS As Integer
    Public sueldoDiario As Decimal
    Public sueldoSemanal As Decimal
    Public ImpuestoTrabajador As Decimal
    Public impuestroPatron As Decimal
    Public netoAPagar As Decimal
    Public esActivo As Boolean
    Public aplicable As Date
    Public idEmpresa As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idSueldoIMSS = rdr("idSueldoIMSS")
        sueldoDiario = rdr("sueldoDiario")
        sueldoSemanal = rdr("sueldoSemanal")
        ImpuestoTrabajador = rdr("ImpuestoTrabajador")
        impuestroPatron = rdr("impuestroPatron")
        netoAPagar = rdr("netoAPagar")
        esActivo = rdr("esActivo")
        aplicable = rdr("aplicable")
        idEmpresa = rdr("idEmpresa")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "SueldosIMSS"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idSueldoIMSS = " & idSueldoIMSS
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "SueldosIMSS.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarPSuledoSemanal() As Boolean
        conex.numCon = 0
        conex.tabla = "SueldosIMSS"
        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.condicion = "WHERE sueldoSemanal = " & sueldoSemanal
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "SueldosIMSS.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "SueldosIMSS"
            conex.accion = accion
            conex.agregaCampo("sueldoDiario", sueldoDiario, False, False)
            conex.agregaCampo("sueldoSemanal", sueldoSemanal, False, False)
            conex.agregaCampo("ImpuestoTrabajador", ImpuestoTrabajador, True, False)
            conex.agregaCampo("impuestroPatron", impuestroPatron, False, False)
            conex.agregaCampo("netoAPagar", netoAPagar, False, False)
            conex.agregaCampo("esActivo", esActivo, True, False)
            conex.agregaCampo("aplicable", aplicable, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, True, False)
            conex.condicion = "WHERE idSueldoIMSS = " & idSueldoIMSS
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
                idSueldoIMSS = conex.reader("ID")
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

    Public Function sueldoFinalImms(sueldoInicial As Decimal, sueldoFinal As Decimal, idCombos As List(Of SueldosIMSS), combo As ComboBox, todos As Boolean) As Boolean
        Dim filtro As String
        If todos Then
            filtro = "WHERE  idEmpresa = " & idEmpresa & " AND sueldoSemanal>=" & sueldoInicial
        Else
            filtro = "WHERE  idEmpresa = " & idEmpresa & " AND sueldoSemanal BETWEEN  " & sueldoInicial & " AND " & sueldoFinal
        End If

        Return getCombo(combo, idCombos, filtro, sueldoFinal, todos)
    End Function

    Private Function getCombo(combo As ComboBox, idCombos As List(Of SueldosIMSS), filtro As String, sueldoFinal As Decimal, todos As Boolean) As Boolean
        Dim plantilla As SueldosIMSS
        combo.Items.Clear()
        idCombos.Clear()

        If todos Then
            conex.Qry = "SELECT 0 as porcentaje,* FROM SueldosIMSS " & filtro
        Else
            conex.Qry = "SELECT sueldoSemanal/" & If(sueldoFinal = 0, 1, sueldoFinal) & " * 100 as porcentaje,* FROM SueldosIMSS " & filtro & " ORDER BY sueldoSemanal"
        End If


        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New SueldosIMSS(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add("Sueldo (" & FormatCurrency(plantilla.sueldoSemanal, 2) & ") " & FormatNumber(conex.reader("porcentaje"), 2) & " % ")
            End While
            conex.reader.Close()
            Return True
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Sucursal.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function sueldoActualImms(combo As ComboBox, idCombos As List(Of SueldosIMSS)) As Boolean
        Dim filtro As String
        If sueldoSemanal <> 0 Then
            filtro = "WHERE  idEmpresa = " & idEmpresa & " AND sueldoSemanal=" & sueldoSemanal
            Return getCombo(combo, idCombos, filtro, sueldoSemanal, False)
        Else
            filtro = "WHERE  idEmpresa = " & idEmpresa & " AND sueldoSemanal BETWEEN  0  AND " & sueldoSemanal
            Return getCombo(combo, idCombos, filtro, sueldoSemanal, False)
        End If
    End Function




End Class
