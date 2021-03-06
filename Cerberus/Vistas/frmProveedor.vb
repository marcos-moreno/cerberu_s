Public Class frmProveedor
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private ObjProveedor As ProveedorProductos

    Private objDgvProveedor As New List(Of ProveedorProductos)

    Private nuevoRegistro As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoRegistro Then
            ObjProveedor = New ProveedorProductos(Ambiente)
        End If

        txtNombre.Text = ObjProveedor.nombreProveedor
        txtRfc.Text = ObjProveedor.rfc
        txtTelefono.Text = ObjProveedor.telefono
        txtCorreo.Text = ObjProveedor.correo
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        ObjProveedor.nombreProveedor = txtNombre.Text
        ObjProveedor.rfc = txtRfc.Text
        ObjProveedor.telefono = txtTelefono.Text
        ObjProveedor.correo = txtCorreo.Text

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        nuevoRegistro = False
        If dgvProveedor.SelectedRows.Count > 0 Then
            ObjProveedor = objDgvProveedor(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoRegistro Then

        End If
    End Sub



    Private Sub dgvProducto_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProveedor.SelectionChanged
        If dgvProveedor.SelectedRows.Count > 0 Then
            clicDatos(dgvProveedor.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        TabControl1.SelectTab(1)
        nuevoRegistro = True
        asignaDatos()
    End Sub

    Private Sub dgvProducto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvProveedor.MouseDoubleClick
        If dgvProveedor.SelectedRows.Count > 0 Then
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        obtenerDatos()

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoRegistro Then
            If ObjProveedor.guardar() Then
                Mensaje.Mensaje = "El registro se guardó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & ObjProveedor.descripError
            End If
        Else
            If ObjProveedor.actualizar() Then
                Mensaje.Mensaje = "El registro se actualizó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & ObjProveedor.descripError
            End If
        End If

        TabControl1.SelectTab(0)
        ObjProveedor.cargaGrid(dgvProveedor, objDgvProveedor, "")

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If ObjProveedor.eliminar() Then
            Mensaje.Mensaje = "El registro se guardo exitosamente..."
        Else
            Mensaje.Mensaje = "Existe un error: " & ObjProveedor.descripError
        End If
        TabControl1.SelectTab(0)
        ObjProveedor.cargaGrid(dgvProveedor, objDgvProveedor, "")
        Mensaje.ShowDialog()
    End Sub

    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObjProveedor = New ProveedorProductos(Ambiente)
        ObjProveedor.cargaGrid(dgvProveedor, objDgvProveedor, "")
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        ObjProveedor.cargaGrid(dgvProveedor, objDgvProveedor, "")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If frmBuscar.ShowDialog() = DialogResult.OK Then
            TabControl1.SelectTab(0)
            ObjProveedor.cargaGrid(dgvProveedor, objDgvProveedor, frmBuscar.valorBuscado)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvProveedor.SelectedRows.Item(0).Index <> 0 Then
            dgvProveedor.Rows(dgvProveedor.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvProveedor.SelectedRows.Item(0).Index <> dgvProveedor.Rows.Count - 1 Then
            dgvProveedor.Rows(dgvProveedor.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.Ambiente = Ambiente
        frmComentario.tabla = "ProveedorProductos"
        frmComentario.idTabla = ObjProveedor.idProveedor
        frmComentario.ShowDialog()
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntosToolStripMenuItem.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.tabla = "ProveedorProductos"
        frmArchivo.idTabla = ObjProveedor.idProveedor
        frmArchivo.ShowDialog()
    End Sub


End Class