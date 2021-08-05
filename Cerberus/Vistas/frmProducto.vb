Imports Cerberus

Public Class frmProducto
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objProducto As Producto
    Private objDgvProdcuto As New List(Of Producto)

    Private nuevoRegistro As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoRegistro Then
            objProducto = New Producto(Ambiente)
        End If

        txtCodigo.Text = objProducto.codigo
        txtDescripcion.Text = objProducto.descripcion

        lblStatus.Text = "ID: " & objProducto.idProducto
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objProducto.codigo = txtCodigo.Text
        objProducto.descripcion = txtDescripcion.Text
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        nuevoRegistro = False

        If dgvProducto.SelectedRows.Count > 0 Then
            objProducto = objDgvProdcuto(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoRegistro Then

        End If
    End Sub

    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProducto = New Producto(Ambiente)
        objProducto.cargaGrid(dgvProducto, objDgvProdcuto, "")
    End Sub




    Private Sub dgvProducto_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducto.SelectionChanged
        If dgvProducto.SelectedRows.Count > 0 Then
            clicDatos(dgvProducto.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        TabControl1.SelectTab(1)
        nuevoRegistro = True
        asignaDatos()
    End Sub

    Private Sub dgvProducto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvProducto.MouseDoubleClick
        If dgvProducto.SelectedRows.Count > 0 Then
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        obtenerDatos()

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoRegistro Then
            If objProducto.guardar() Then
                Mensaje.Mensaje = "El registro se guardó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & objProducto.descripError
            End If
        Else
            If objProducto.actualizar() Then
                Mensaje.Mensaje = "El registro se actualizó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & objProducto.descripError
            End If
        End If

        TabControl1.SelectTab(0)
        objProducto.cargaGrid(dgvProducto, objDgvProdcuto, "")

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If objProducto.eliminar() Then
            Mensaje.Mensaje = "El registro se guardo exitosamente..."
        Else
            Mensaje.Mensaje = "Existe un error: " & objProducto.descripError
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objProducto.cargaGrid(dgvProducto, objDgvProdcuto, "")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If frmBuscar.ShowDialog() = DialogResult.OK Then
            TabControl1.SelectTab(0)
            objProducto.cargaGrid(dgvProducto, objDgvProdcuto, frmBuscar.valorBuscado)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvProducto.SelectedRows.Item(0).Index <> 0 Then
            dgvProducto.Rows(dgvProducto.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvProducto.SelectedRows.Item(0).Index <> dgvProducto.Rows.Count - 1 Then
            dgvProducto.Rows(dgvProducto.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.Ambiente = Ambiente
        frmComentario.tabla = "Producto"
        frmComentario.idTabla = objProducto.idProducto
        frmComentario.ShowDialog()
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntosToolStripMenuItem.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.tabla = "Producto"
        frmArchivo.idTabla = objProducto.idProducto
        frmArchivo.ShowDialog()
    End Sub
End Class