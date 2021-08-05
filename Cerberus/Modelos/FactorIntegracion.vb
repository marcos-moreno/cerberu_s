Imports System.Data.SqlClient
Imports Cerberus

Public Class FactorIntegracion
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Public idFactorIntegracion As Integer
    Public inicio As Integer
    Public fin As Integer
    Public factor As Decimal
    Public idEmpresa As Integer

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idFactorIntegracion = rdr("idFactorIntegracion")
        inicio = rdr("inicio")
        fin = rdr("fin")
        factor = rdr("factor")
        idEmpresa = rdr("idEmpresa")
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

    'Clase especifica de Sucursal Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of FactorIntegracion))
        Dim filtro As String
        filtro = "WHERE idEmpresa = " & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of FactorIntegracion), filtro As String)
        Dim plantilla As FactorIntegracion
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM FactorIntegracion " & filtro & " ORDER BY inicio"
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New FactorIntegracion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.fin / 12 & " Año(s) " & plantilla.factor)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "FactorIntegracion.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
