Imports System.Data.SqlClient
Imports Cerberus

Public Class FormatoImportacion
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idErrro As Integer
    Public descripErrro As String

    Public idFormatoImportacion As Integer
    Public tabla As String
    Public idEmpresa As Integer
    Public nombre As String
    Public tipoArchivo As String
    Public esActivo As Boolean

    Public Sub New(Ambiente As AmbienteCls)
        Me.conex = Ambiente.conex
        Me.Ambiente = Ambiente
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idFormatoImportacion = rdr("idFormatoImportacion")
        tabla = rdr("tabla")
        idEmpresa = rdr("idEmpresa")
        nombre = rdr("nombre")
        tipoArchivo = rdr("tipoArchivo")
        esActivo = rdr("esActivo")
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
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of FormatoImportacion))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 and idEmpresa = " & idEmpresa & " and tabla='" & tabla & "'"

        getCombo(combo, idCombos, filtro)
    End Sub

    Public Sub getComboCuentas(combo As ComboBox, lista As List(Of FormatoImportacion))
        Dim filtro As String
        filtro = "WHERE esActivo = 1  and tabla LIKE '%Cuenta%' "
        getCombo(combo, lista, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of FormatoImportacion), filtro As String)
        Dim plantilla As FormatoImportacion
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM FormatoImportacion " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New FormatoImportacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombre & " (" & plantilla.tipoArchivo & ")")
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "FormatoImportacion.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
