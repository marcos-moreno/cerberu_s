Imports Cerberus

Public Class frmDireccionEmpleado
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public idEmpleado As Integer

    Private objDireccionEmpleado As DireccionEmpleado
    Private objDGDireccionEmpleado As New List(Of DireccionEmpleado)
    Private objCombosCP As New List(Of CodigoPostal)
    Private objCP As CodigoPostal

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtCalle.Text = objDireccionEmpleado.calle
        txtNoExterior.Text = objDireccionEmpleado.noExterior
        txtNoInterior.Text = objDireccionEmpleado.noInterior
        txtReferencia.Text = objDireccionEmpleado.referencia
        esActivo.Checked = objDireccionEmpleado.esActivo

        objCP.idCodigoPostal = objDireccionEmpleado.idCodigoPostal

        If Not objCP.buscarPID() Then
            objCP = New CodigoPostal(Ambiente)
        End If

        txtCP.Text = objCP.codigoPostal
        objDireccionEmpleado.getComboEstado(cbEstado, txtCP.Text)
        limpiarCombos("estado")

        cbEstado.SelectedItem = objCP.estado
        cbMunicipio.SelectedItem = objCP.municipio
        cbCiudad.SelectedItem = objCP.ciudad
        cbTipoAsentamiento.SelectedItem = objCP.tipoAsentamiento
        cbAsentamiento.SelectedItem = objCP.asentamiento
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objDireccionEmpleado.idEmpleado = idEmpleado
        objDireccionEmpleado.calle = txtCalle.Text
        objDireccionEmpleado.noExterior = txtNoExterior.Text
        objDireccionEmpleado.noInterior = txtNoInterior.Text
        objDireccionEmpleado.referencia = txtReferencia.Text
        If cbAsentamiento.SelectedIndex <> -1 Then
            objDireccionEmpleado.idCodigoPostal = objCombosCP(cbAsentamiento.SelectedIndex).idCodigoPostal
        Else
            objDireccionEmpleado.idCodigoPostal = Nothing
        End If
        objDireccionEmpleado.esActivo = esActivo.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            objDireccionEmpleado = objDGDireccionEmpleado.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim acc As Boolean
        If dgvDireccionEmpleado.Rows.Count > 0 Or nuevoReg Then
            acc = True
        Else
            acc = False
        End If

        btnGuardar.Enabled = acc
        btnEliminar.Enabled = acc
        esActivo.Enabled = acc
        txtCalle.Enabled = acc
        txtCP.Enabled = acc
        txtNoExterior.Enabled = acc
        txtNoInterior.Enabled = acc
        txtReferencia.Enabled = acc

        cbAsentamiento.Enabled = acc
        cbCiudad.Enabled = acc
        cbEstado.Enabled = acc
        cbMunicipio.Enabled = acc
        cbTipoAsentamiento.Enabled = acc
    End Sub

    Private Sub frmDireccionEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recargar
    End Sub

    Private Sub txtCP_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCP.KeyUp
        If e.KeyCode = Keys.Enter Then
            objDireccionEmpleado.getComboEstado(cbEstado, txtCP.Text)
        End If

        limpiarCombos("cp")
    End Sub

    Private Sub cbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEstado.SelectedIndexChanged
        If cbEstado.SelectedIndex <> -1 Then
            objDireccionEmpleado.getComboMunicipio(cbMunicipio, txtCP.Text, cbEstado.SelectedItem)
        End If

        limpiarCombos("estado")
    End Sub

    Private Sub cbMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMunicipio.SelectedIndexChanged
        If cbMunicipio.SelectedIndex <> -1 Then
            objDireccionEmpleado.getComboCiudad(cbCiudad, txtCP.Text, cbEstado.SelectedItem, cbMunicipio.SelectedItem)
        End If

        limpiarCombos("municipio")
    End Sub

    Private Sub cbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCiudad.SelectedIndexChanged
        If cbCiudad.SelectedIndex <> -1 Then
            objDireccionEmpleado.getComboTipoAsentamiento(cbTipoAsentamiento, txtCP.Text, cbEstado.SelectedItem, cbMunicipio.SelectedItem, cbCiudad.SelectedItem)
        End If

        limpiarCombos("ciudad")
    End Sub

    Private Sub limpiarCombos(combo As String)
        Select Case combo
            Case "cp"
                cbEstado.SelectedIndex = -1
                cbAsentamiento.SelectedIndex = -1
                cbTipoAsentamiento.SelectedIndex = -1
                cbCiudad.SelectedIndex = -1
                cbMunicipio.SelectedIndex = -1
            Case "estado"
                cbAsentamiento.SelectedIndex = -1
                cbTipoAsentamiento.SelectedIndex = -1
                cbCiudad.SelectedIndex = -1
                cbMunicipio.SelectedIndex = -1
            Case "municipio"
                cbAsentamiento.SelectedIndex = -1
                cbTipoAsentamiento.SelectedIndex = -1
                cbCiudad.SelectedIndex = -1
            Case "ciudad"
                cbAsentamiento.SelectedIndex = -1
                cbTipoAsentamiento.SelectedIndex = -1
            Case "tipoAsentamiento"
                cbAsentamiento.SelectedIndex = -1
        End Select
    End Sub

    Private Sub cbTipoAsentamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoAsentamiento.SelectedIndexChanged
        limpiarCombos("tipoAsentamiento")

        If cbTipoAsentamiento.SelectedIndex <> -1 Then
            objDireccionEmpleado.getComboAsentamiento(cbAsentamiento, objCombosCP, txtCP.Text, cbEstado.SelectedItem, cbMunicipio.SelectedItem, cbCiudad.SelectedItem, cbTipoAsentamiento.SelectedItem)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        objDireccionEmpleado = New DireccionEmpleado(Ambiente)
        objDireccionEmpleado.idEmpleado = idEmpleado

        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim operacion As Boolean = True
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If nuevoReg Then
            If Not objDireccionEmpleado.guardar() Then
                Mensaje.Mensaje = objDireccionEmpleado.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la Dirección"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not objDireccionEmpleado.actualizar() Then
                Mensaje.Mensaje = objDireccionEmpleado.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la Dirección"
                operacion = False
            End If
        End If

        Mensaje.ShowDialog()
        If Not operacion Then
            objDireccionEmpleado.cargaGrid(dgvDireccionEmpleado, objDGDireccionEmpleado)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub dgvDireccionEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDireccionEmpleado.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvDireccionEmpleado_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDireccionEmpleado.SelectionChanged
        Dim indice As Integer

        If dgvDireccionEmpleado.SelectedRows.Count > 0 Then
            indice = dgvDireccionEmpleado.SelectedRows.Item(0).Index
        Else
            indice = -1
        End If

        clicDatos(indice)
        habilitarBotones()
        'TabControl1.SelectTab(1)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas ELIMINAR la dirección: " & objDireccionEmpleado.idDireccionEmpleado & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            objDireccionEmpleado.eliminar()
            objDireccionEmpleado.cargaGrid(dgvDireccionEmpleado, objDGDireccionEmpleado)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        recargar
    End Sub

    Private Sub recargar()
        objDireccionEmpleado = New DireccionEmpleado(Ambiente)
        objDireccionEmpleado.idEmpleado = idEmpleado
        objCP = New CodigoPostal(Ambiente)

        objDireccionEmpleado.cargaGrid(dgvDireccionEmpleado, objDGDireccionEmpleado)
        habilitarBotones()
        asignaDatos()

        lblStatus.Text = "ID Empleado Actual: (" & idEmpleado & ")"
    End Sub
End Class