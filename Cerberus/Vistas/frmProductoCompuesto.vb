Imports Cerberus

Public Class frmProductoCompuesto
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public elemento As String
    Private nuevoRegistro As Boolean

    Public objProdCopsto As ProductoCompuesto
    Private objProdCompuesto As New List(Of ProductoCompuesto)


    Private Sub frmProductoCompuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProdCopsto = New ProductoCompuesto(Ambiente)
        objProdCopsto.cargaGrid(dgvProductoCompuesto, objProdCompuesto, "", False)
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoRegistro Then
            objProdCopsto = New ProductoCompuesto(Ambiente)
        End If

        txtPrecio.Text = objProdCopsto.precio
        txtIDProducto.Text = objProdCopsto.idProduct
        txtIdTalla.Text = objProdCopsto.idTalla
        txtIdModelo.Text = objProdCopsto.idModelo
        txtIdColor.Text = objProdCopsto.idColor
        txtPorcentaje.Text = objProdCopsto.porcentaje

        If objProdCopsto.porcentaje > 0 Then
            Label7.Visible = True
            txtPorcentaje.Visible = True
            Label8.Visible = True
            cbDiscount.SelectedIndex = 0
        Else
            Label7.Visible = False
            txtPorcentaje.Visible = False
            Label8.Visible = False
            cbDiscount.SelectedIndex = 1
        End If


        txtDescProducto.Text = objProdCopsto.producto
        txtTalla.Text = objProdCopsto.talla
        txtModelo.Text = objProdCopsto.modelo
        txtColor.Text = objProdCopsto.color

        txtCodigoCompuesto.Text = objProdCopsto.codigoCompuesto


    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objProdCopsto.idProduct = txtIDProducto.Text
        objProdCopsto.idTalla = txtIdTalla.Text
        objProdCopsto.idModelo = txtIdModelo.Text
        objProdCopsto.idColor = txtIdColor.Text
        objProdCopsto.producto = txtDescProducto.Text
        objProdCopsto.porcentaje = txtPorcentaje.Text
        objProdCopsto.precio = txtPrecio.Text

        If objProdCopsto.porcentaje > 0 Then
            objProdCopsto.discount = True
        Else
            objProdCopsto.discount = False
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        nuevoRegistro = False

        If dgvProductoCompuesto.SelectedRows.Count > 0 Then
            objProdCopsto = objProdCompuesto(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        TabControl1.SelectTab(1)
        nuevoRegistro = True
        asignaDatos()
    End Sub

    Private Sub cbDiscount_SelectionChanged(sender As Object, e As EventArgs) Handles cbDiscount.SelectedIndexChanged
        If cbDiscount.Text = "SI" Then
            Label7.Visible = True
            txtPorcentaje.Visible = True
            Label8.Visible = True
        Else
            Label7.Visible = False
            txtPorcentaje.Visible = False
            txtPorcentaje.Text = 0
            Label8.Visible = False
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        obtenerDatos()

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoRegistro Then
            If objProdCopsto.guardar() Then
                Mensaje.Mensaje = "El registro se guardó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & objProdCopsto.descripError
            End If
        Else
            If objProdCopsto.actualizar() Then
                Mensaje.Mensaje = "El registro se actualizó exitosamente..."
            Else
                Mensaje.Mensaje = "Existe un error: " & objProdCopsto.descripError
            End If
        End If

        TabControl1.SelectTab(0)
        objProdCopsto.cargaGrid(dgvProductoCompuesto, objProdCompuesto, "", False)

        Mensaje.ShowDialog()
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If objProdCopsto.eliminar() Then
            Mensaje.Mensaje = "El registro se guardo exitosamente..."
        Else
            Mensaje.Mensaje = "Existe un error: " & objProdCopsto.descripError
        End If
        TabControl1.SelectTab(0)
        objProdCopsto.cargaGrid(dgvProductoCompuesto, objProdCompuesto, "", False)
        Mensaje.ShowDialog()
    End Sub


    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objProdCopsto.cargaGrid(dgvProductoCompuesto, objProdCompuesto, "", False)
    End Sub

    Private Sub dgvProducto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvProductoCompuesto.MouseDoubleClick
        If dgvProductoCompuesto.SelectedRows.Count > 0 Then
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If frmBuscar.ShowDialog() = DialogResult.OK Then
            TabControl1.SelectTab(0)
            objProdCopsto.cargaGrid(dgvProductoCompuesto, objProdCompuesto, frmBuscar.valorBuscado, False)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvProductoCompuesto.SelectedRows.Item(0).Index <> 0 Then
            dgvProductoCompuesto.Rows(dgvProductoCompuesto.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvProductoCompuesto.SelectedRows.Item(0).Index <> dgvProductoCompuesto.Rows.Count - 1 Then
            dgvProductoCompuesto.Rows(dgvProductoCompuesto.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub


    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.Ambiente = Ambiente
        frmComentario.tabla = "ProductoCompuesto"
        frmComentario.idTabla = objProdCopsto.idProductoCompuesto
        frmComentario.ShowDialog()
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntosToolStripMenuItem.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.tabla = "ProductoCompuesto"
        frmArchivo.idTabla = objProdCopsto.idProductoCompuesto
        frmArchivo.ShowDialog()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoRegistro Then

        End If
    End Sub

    Private Sub dgvProducto_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductoCompuesto.SelectionChanged
        If dgvProductoCompuesto.SelectedRows.Count > 0 Then
            clicDatos(dgvProductoCompuesto.SelectedRows(0).Index)
        End If
    End Sub


    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        frmBuscaProducto.Ambiente = Ambiente
        If frmBuscaProducto.ShowDialog() = DialogResult.OK Then
            txtIDProducto.Text = frmBuscaProducto.productoRetorno.idProducto
            txtDescProducto.Text = frmBuscaProducto.productoRetorno.descripcion
        End If
    End Sub

    Private Sub bteColor_Click(sender As Object, e As EventArgs) Handles bteColor.Click
        frmBuscarCaracteristicaProducto.Ambiente = Ambiente
        frmBuscarCaracteristicaProducto.filtro1 = "color"
        If frmBuscarCaracteristicaProducto.ShowDialog() = DialogResult.OK Then
            txtIdColor.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.idCaracteristica
            txtColor.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.nombre
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscarCaracteristicaProducto.Ambiente = Ambiente
        frmBuscarCaracteristicaProducto.filtro1 = "talla"
        If frmBuscarCaracteristicaProducto.ShowDialog() = DialogResult.OK Then
            txtIdTalla.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.idCaracteristica
            txtTalla.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.nombre
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmBuscarCaracteristicaProducto.Ambiente = Ambiente
        frmBuscarCaracteristicaProducto.filtro1 = "modelo"
        If frmBuscarCaracteristicaProducto.ShowDialog() = DialogResult.OK Then
            txtIdModelo.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.idCaracteristica
            txtModelo.Text = frmBuscarCaracteristicaProducto.CarProdRetorno.nombre
        End If
    End Sub


End Class