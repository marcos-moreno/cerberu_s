Imports System.Data.SqlClient
Imports Cerberus

Public Class UbicacionFisica
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Public idUbicacionFisica As Integer

    Public nombreUbicacionFisica As String
    Public geolocalizacion As String
    Public idEmpresa As Integer
    Public idSucusal As Integer
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizadoPor As Integer
    Public actualizado As DateTime

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    'Clase especifica de Dispositivo Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of UbicacionFisica))
        Dim filtro As String
        filtro = "WHERE esActivo = 1 AND idEmpresa=" & idEmpresa

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of UbicacionFisica), filtro As String)
        Dim plantilla As UbicacionFisica
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM UbicacionFisica " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New UbicacionFisica(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreUbicacionFisica)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "UbicacionFisica.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idUbicacionFisica = rdr("idUbicacionFisica")
        nombreUbicacionFisica = rdr("nombreUbicacionFisica")
        geolocalizacion = rdr("geolocalizacion")
        idEmpresa = rdr("idEmpresa")
        idSucusal = rdr("idSucusal")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizadoPor = rdr("actualizadoPor")
        actualizado = rdr("actualizado")
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
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = " UbicacionFisica "

        conex.condicion = "WHERE idUbicacionFisica=" & idUbicacionFisica

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


    Public Sub cargaGridCom(dgv As DataGridView, filter As String, obj As List(Of UbicacionFisica))
        If filter.Length > 0 Then
            filter = " WHERE nombreUbicacionFisica LIKE '%" & nombreUbicacionFisica & "%'"
        End If
        cargarGrid(dgv, filter, obj)
    End Sub

    Private Sub cargarGrid(grid As DataGridView, filter As String, objEmp As List(Of UbicacionFisica))
        Dim plantilla As UbicacionFisica
        Dim dtb As New DataTable("UbicacionFisica")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Ubicación", Type.GetType("System.String"))

        objEmp.Clear()
        conex.Qry = "SELECT * FROM UbicacionFisica " & filter
        conex.numCon = 0
        If conex.ejecutaConsulta() Then

            While conex.reader.Read
                plantilla = New UbicacionFisica(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("ID") = plantilla.idUbicacionFisica
                row("Nombre Ubicación") = plantilla.nombreUbicacionFisica
                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()
            grid.DataSource = dtb
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Ubicación.cargarGridUbicacion"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class
