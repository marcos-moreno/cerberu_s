Imports System.Data.SqlClient
Imports Cerberus

Public Class VariableFormula
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idVariableFormula As Integer
    Public tipo As String
    Public elemento As String
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public nombreVariable As String
    Public proceso As String

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Departamento Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of VariableFormula))
        Dim filtro As String
        filtro = " WHERE idEmpresa = " & Ambiente.empr.idEmpresa & " AND tipo='FOR'"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of VariableFormula), filtro As String)
        Dim plantilla As VariableFormula
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM VariableFormula " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New VariableFormula(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add("(" & plantilla.elemento & ") - " & plantilla.nombreVariable)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "VariableFormula.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idVariableFormula = rdr("idVariableFormula")
        tipo = rdr("tipo")
        elemento = rdr("elemento")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        nombreVariable = rdr("nombreVariable")
        proceso = rdr("proceso")
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
        conex.numCon = 0
        conex.tabla = "VariableFormula"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idVaribleFormula=" & idVariableFormula

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
