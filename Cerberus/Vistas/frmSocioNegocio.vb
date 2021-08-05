Imports Cerberus

Public Class frmSocioNegocio
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls

    Private nuevoReg As Boolean

    Private objSocio As SocioNegocio
    Private dgvSocio As New List(Of SocioNegocio)
    Private cbObjSuc As New List(Of Sucursal)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtCodigo.Text = objSocio.codigoSocio
        txtNombreCorto.Text = objSocio.nombreCorto
        txtNombreSocio.Text = objSocio.nombreSocio
        txtRFC.Text = objSocio.rfc

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbObjSuc.Count - 1
            If cbObjSuc(i).idSucursal = objSocio.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        accesoNivelEmpresa.Checked = objSocio.accesoNivelEmpresa
        esActivo.Checked = objSocio.esActivo
        esCliente.Checked = objSocio.esCliente
        esProveedor.Checked = objSocio.esProveedor
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objSocio.codigoSocio = txtCodigo.Text
        objSocio.nombreCorto = txtNombreCorto.Text
        objSocio.nombreSocio = txtNombreSocio.Text
        objSocio.rfc = txtRFC.Text
        objSocio.idSucursal = cbObjSuc(cbSucursal.SelectedIndex).idSucursal
        objSocio.accesoNivelEmpresa = accesoNivelEmpresa.Checked
        objSocio.esActivo = esActivo.Checked
        objSocio.esCliente = esCliente.Checked
        objSocio.esProveedor = esProveedor.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            objSocio = dgvSocio.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones

    End Sub

    Private Sub frmSocioNegocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim suc As New Sucursal(Ambiente)
        suc.idEmpresa = Ambiente.empr.idEmpresa
        suc.getComboActivo(cbSucursal, cbObjSuc)

        objSocio = New SocioNegocio(Ambiente)
        objSocio.idEmpresa = Ambiente.empr.idEmpresa
        objSocio.cargaGrid(DataGridView1, dgvSocio)

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click

        Dim operacion As Boolean = True
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not objSocio.guardar() Then
                Mensaje.Mensaje = objSocio.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el Socio"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not objSocio.actualizar() Then
                Mensaje.Mensaje = objSocio.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el Socio"
                operacion = False
            End If
        End If

        Mensaje.ShowDialog()
        If Not operacion Then
            objSocio.cargaGrid(DataGridView1, dgvSocio)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objSocio.cargaGrid(DataGridView1, dgvSocio)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "SocioNegocio"
        frmLogTransaccion.idTabla = objSocio.idSocioNegocio
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Socio: " & objSocio.idSocioNegocio & " - " & objSocio.nombreSocio & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            objSocio.eliminar()
            objSocio.cargaGrid(DataGridView1, dgvSocio)
            TabControl1.SelectTab(0)
        End If
    End Sub
End Class