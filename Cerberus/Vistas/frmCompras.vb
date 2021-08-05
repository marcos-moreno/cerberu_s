Imports Cerberus

Public Class frmCompras
    Implements InterfaceVentanas

    Private nuevoReg As Boolean
    Private nuevoReg2 As Boolean

    Private objCbEmpr As New List(Of Empresa)
    Private montoTotal As Decimal
    Public elemento As String
    Private compra As Compras

    Public Ambiente As AmbienteCls
    Public proveedor As ProveedorProductos
    Public almacen As Almacen

    Public objCompra As Compras
    Public objCompD As CompraDetalle
    Public indexCompra As Integer

    Private edoDocs As EstadoDocumentos
    Private objDGCompraD As New List(Of CompraDetalle)
    Private existencias As ExistenciaProducto

    Private objCompraD As CompraDetalle
    Private objCbSuc As New List(Of Sucursal)
    Private objCbAlmacen As New List(Of Almacen)
    Private objCbProveedor As New List(Of ProveedorProductos)
    Private objDGCompra As New List(Of Compras)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then

            objCompra = New Compras(Ambiente)
            objCompra.idEmpresa = Ambiente.empr.idEmpresa
            objCompra.estado = "BO"
            txtMontoTotal.Text = "0.0"
            txtIDProveedor.Text = ""
            txtNombreProveedor.Text = ""
            txtNumDocumento.Text = ""
            rtbDescripCuenta.Text = ""
            txtNumDocumento.Text = ""
            txtMontoTotal.Text = "0.0"
            txtEstado.Text = ""
            dtpFechaMov.Value = Now
            TabControl2.Enabled = False
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
            btnGuardar2.Enabled = False
        Else
            dtpFechaMov.Value = objCompra.fecha
            TabControl2.Enabled = True
            If objCompra.estado = "BO" Then
                btnNuevo2.Enabled = True
                btnEliminar2.Enabled = True
                btnGuardar2.Enabled = True
            End If

            objCompD = New CompraDetalle(Ambiente)
            objCompD.idCompra = objCompra.idCompra
            nuevoReg2 = False
            asignaDatos2()
            objCompD.cargaGridCom(dgvDetalleCompra, objDGCompraD)
            For i As Integer = 0 To cbSucursal.Items.Count - 1
                If objCbSuc.Item(i).idSucursal = objCompra.idSucursal Then
                    cbSucursal.SelectedIndex = i
                    Exit For
                End If
            Next

            For i As Integer = 0 To cbAlmacen.Items.Count - 1
                If objCbAlmacen.Item(i).idAlmacen = objCompra.idAlmacen Then
                    cbAlmacen.SelectedIndex = i
                    Exit For
                End If
            Next
            txtMontoTotal.Text = objCompra.montoTotal
            txtEstado.Text = edoDocs.getNombreEstado(objCompra.estado)
            txtNumDocumento.Text = objCompra.noFactura
            txtIDProveedor.Text = objCompra.idProveedor
            txtNombreProveedor.Text = objCompra.nombreProveedor
            rtbDescripCuenta.Text = objCompra.observacion
        End If

    End Sub


    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        edoDocs = New EstadoDocumentos
        objCompra = New Compras(Ambiente)
        objCompra.idEmpresa = Ambiente.empr.idEmpresa
        objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, Now, "", "")
        If Ambiente.usuario.desarrollador Then
            btnModificar.Visible = True
        Else
            btnModificar.Visible = False
        End If
        edoDocs = New EstadoDocumentos
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)
        lblStatus.Text = ""
        If Ambiente.usuario.desarrollador Then
            btnModificar.Visible = True
        Else
            btnModificar.Visible = False
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            objCompra = objDGCompra.Item(indice)
            asignaDatos()
            Controles()
        End If
    End Sub
    Public Sub clicDatos2(indice As Integer)
        If indice <> -1 Then
            nuevoReg2 = False
            objCompraD = objDGCompraD.Item(indice)
            asignaDatos2()
            Controles()
        End If
    End Sub

    Public Sub asignaDatos2()
        If nuevoReg2 Then
            objCompraD = New CompraDetalle(Ambiente)
            objCompraD.idCompra = objCompra.idCompra
            txtIDProducto.Text = ""
            txtNombreProd.Text = ""
            txtMonto.Text = ""
        End If
        Try
            txtCantidad.Text = objCompraD.cantidad
            txtIdUbic.Text = objCompraD.idUbicacion
            txtUbicacion.Text = objCompraD.ubicacion
            txtMonto.Text = objCompraD.precio
            txtNombreProd.Text = objCompraD.nombreProducto
            txtIDProducto.Text = objCompraD.idProductoCompuesto
        Catch ex As Exception

        End Try


    End Sub


    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
            txtNumDocumento.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
    End Sub

    Private Sub cbSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSucursal.SelectedIndexChanged
        almacen = New Almacen(Ambiente)
        Dim s As Sucursal
        s = objCbSuc.Item(cbSucursal.SelectedIndex)
        almacen.getComboAlmacen(cbAlmacen, objCbAlmacen, s.idSucursal)
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        frmBuscaProveedor.Ambiente = Ambiente
        If frmBuscaProveedor.ShowDialog() = DialogResult.OK Then
            txtIDProveedor.Text = frmBuscaProveedor.proveedorRetorno.idProveedor
            txtNombreProveedor.Text = frmBuscaProveedor.proveedorRetorno.nombreProveedor
        End If
    End Sub

    Private Sub Controles()
        If objCompra.estado = "BO" Then
            dtpFechaMov.Enabled = True
            txtNumDocumento.ReadOnly = False
            cbSucursal.Enabled = True
            cbAlmacen.Enabled = True
            txtMonto.ReadOnly = False
            btnProveedor.Enabled = True
            rtbDescripCuenta.ReadOnly = False
            If nuevoReg Then
                btnNuevo2.Enabled = False
                btnGuardar2.Enabled = False
                btnEliminar2.Enabled = False
            Else
                If objCompra.estado = "BO" Then
                    btnNuevo2.Enabled = True
                    btnGuardar2.Enabled = True
                    btnEliminar2.Enabled = True
                End If
            End If
        Else
            rtbDescripCuenta.ReadOnly = True
            btnProveedor.Enabled = False
            dtpFechaMov.Enabled = False
            txtNumDocumento.ReadOnly = True
            cbSucursal.Enabled = False
            cbAlmacen.Enabled = False
            btnNuevo2.Enabled = False
            btnGuardar2.Enabled = False
            btnEliminar2.Enabled = False
            txtMonto.ReadOnly = True
            rtbDescripCuenta.ReadOnly = True
        End If
    End Sub

    Private Sub dgvCuentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompras.CellClick
        indexCompra = e.RowIndex
        clicDatos(e.RowIndex)
        nuevoReg2 = True
        asignaDatos2()
        habilitarBotones()
    End Sub

    Private Sub dgvDetalleCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCompra.CellClick
        clicDatos2(e.RowIndex)
        If objCompra.estado = "BO" Then
            habilitarBotones2()
        End If
    End Sub

    Private Sub dgvDetalleCompra_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalleCompra.SelectionChanged
        If dgvDetalleCompra.SelectedRows.Count > 0 Then
            clicDatos2(dgvDetalleCompra.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub dgvCompras_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCompras.SelectionChanged
        If dgvCompras.SelectedRows.Count > 0 Then
            clicDatos(dgvCompras.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompras.CellDoubleClick
        indexCompra = e.RowIndex
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvDetalleCompras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCompra.CellDoubleClick
        clicDatos2(e.RowIndex)
        If objCompra.estado = "BO" Then
            habilitarBotones2()
        End If
        TabControl2.SelectTab(1)
    End Sub

    Public Sub habilitarBotones2()
        If nuevoReg2 Then
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
            txtMonto.Select()
        Else
            btnNuevo2.Enabled = True
            btnEliminar2.Enabled = True
        End If
    End Sub

    Private Sub btnConcepto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        frmBuscarProductoCompuesto.Ambiente = Ambiente
        frmBuscarProductoCompuesto.wExistence = False
        If frmBuscarProductoCompuesto.ShowDialog() = DialogResult.OK Then
            txtIDProducto.Text = frmBuscarProductoCompuesto.productoRetorno.idProductoCompuesto
            txtNombreProd.Text = frmBuscarProductoCompuesto.productoRetorno.producto & " " & frmBuscarProductoCompuesto.productoRetorno.modelo & " " & frmBuscarProductoCompuesto.productoRetorno.talla
            txtMonto.Text = frmBuscarProductoCompuesto.productoRetorno.precio
        End If
    End Sub

    Public Sub obtenerDatos2()
        If objCompra.idCompra <> Nothing Then
            objCompraD.idCompra = objCompra.idCompra
        End If
        If txtIDProducto.Text <> Nothing Then
            objCompraD.idProductoCompuesto = txtIDProducto.Text
        Else
            objCompraD.idProductoCompuesto = Nothing
        End If
        If IsNumeric(txtCantidad.Text) Then
            objCompraD.cantidad = txtCantidad.Text
        Else
            objCompraD.cantidad = 0
        End If
        If IsNumeric(txtMonto.Text) And IsNumeric(txtCantidad.Text) Then
            objCompraD.precio = txtMonto.Text * txtCantidad.Text
        Else
            objCompraD.precio = 0
        End If
        objCompD.actualizadoPor = Ambiente.usuario.idEmpleado
        objCompD.creadoPor = Ambiente.usuario.idEmpleado
        objCompraD.idUbicacion = txtIdUbic.Text
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objCompra.noFactura = txtNumDocumento.Text
        objCompra.fecha = dtpFechaMov.Value
        If txtMontoTotal.Text = 0 Or txtMontoTotal.Text = "" Or txtMontoTotal.Text = "0" Then
            objCompra.montoTotal = 0
        Else
            objCompra.montoTotal = txtMontoTotal.Text
        End If
        If IsNumeric(txtIDProveedor.Text) Then
            objCompra.idProveedor = txtIDProveedor.Text
        Else
            objCompra.idProveedor = Nothing
        End If
        objCompra.observacion = rtbDescripCuenta.Text
        If cbSucursal.SelectedIndex <> -1 Then
            objCompra.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            objCompra.idSucursal = Nothing
        End If
        If cbAlmacen.SelectedIndex <> -1 Then
            objCompra.idAlmacen = objCbAlmacen.Item(cbAlmacen.SelectedIndex).idAlmacen
        Else
            objCompra.idSucursal = Nothing
        End If
    End Sub

    Private Sub btnNuevo2_Click(sender As Object, e As EventArgs) Handles btnNuevo2.Click
        clicBtnNuevo()
    End Sub

    Private Sub clicBtnNuevo()
        nuevoReg2 = True
        asignaDatos2()
        habilitarBotones2()
        TabControl2.SelectTab(1)
    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        obtenerDatos2()
        If guardar2() Then
            asignaDatos2()
            TabControl2.SelectTab(0)
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Function guardar2() As Boolean
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg2 Then
            If Not objCompraD.guardar() Then
                Mensaje.Mensaje = objCompraD.descripError
                'TabControl2.AccessibleDescription

                Return False
            Else
                Mensaje.Mensaje = "Se guardó correctamente la compra"
                objCompraD.cargaGridCom(dgvDetalleCompra, objDGCompraD)
                montoTotal = 0
                For i As Integer = 0 To objDGCompraD.Count - 1
                    montoTotal += objDGCompraD.Item(i).precio
                Next
                objCompra.montoTotal = montoTotal
                If objCompra.actualizar() Then
                    Mensaje.Mensaje = "Se guardó correctamente el movimiento"
                    nuevoReg = False
                Else
                    Mensaje.Mensaje = objCompra.descripError
                    Return False
                End If
            End If
            txtMontoTotal.Text = FormatCurrency(montoTotal)
            nuevoReg2 = False
            habilitarBotones2()
        Else
            If Not objCompraD.actualizar() Then
                Mensaje.Mensaje = objCompraD.descripError
                Return False
            Else
                objCompraD.cargaGridCom(dgvDetalleCompra, objDGCompraD)
                montoTotal = 0
                For i As Integer = 0 To objDGCompraD.Count - 1
                    montoTotal += objDGCompraD.Item(i).precio
                Next
                Mensaje.Mensaje = "Se actualizó correctamente el movimiento"
                txtMontoTotal.Text = montoTotal
                objCompra.montoTotal = montoTotal
                If objCompra.actualizar() Then
                    nuevoReg = False
                Else
                    Mensaje.Mensaje = objCompra.descripError
                    Return False
                End If
                txtMontoTotal.Text = FormatCurrency(montoTotal)
                nuevoReg2 = False
                habilitarBotones2()
            End If
        End If
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscarUbicacion.Ambiente = Ambiente
        frmBuscarUbicacion.idSucursal = objCompra.idSucursal
        If frmBuscarUbicacion.ShowDialog() = DialogResult.OK Then
            txtIdUbic.Text = frmBuscarUbicacion.UbicacionRetorno.idUbicacion
            txtUbicacion.Text = frmBuscarUbicacion.UbicacionRetorno.codigo
        End If
    End Sub

    Private Sub btnEliminar2_Click(sender As Object, e As EventArgs) Handles btnEliminar2.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If objCompraD.eliminar() Then
            Mensaje.Mensaje = "El registro se Elimino exitosamente..."
            objCompraD.cargaGridCom(dgvDetalleCompra, objDGCompraD)
            TabControl2.SelectTab(0)
            objCompra.montoTotal = montoTotal
            montoTotal = 0
            For i As Integer = 0 To objDGCompraD.Count - 1
                montoTotal += objDGCompraD.Item(i).precio
            Next
            objCompra.montoTotal = montoTotal

            If objCompra.actualizar() Then
                nuevoReg = False
            Else
                Mensaje.Mensaje = objCompra.descripError
            End If
            txtMontoTotal.Text = FormatCurrency(montoTotal)
            asignaDatos2()
        Else
            Mensaje.Mensaje = "Existe un error: " & objCompD.descripError
        End If
    End Sub


    Private Sub BORRADORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BORRADORToolStripMenuItem.Click
        If objCompra.estado = "BO" Then
            guardar("BO")
        Else
            Mensaje.Mensaje = "No se puede cambiar a estado ""BORRADOR"" cuando ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub COMPLETARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COMPLETARToolStripMenuItem.Click
        Dim estado As String

        If nuevoReg Then
            estado = "BO"
        Else
            estado = "CO"
        End If

        If objCompra.estado = "BO" Or objCompra.estado = "PA" Then
            guardar(estado)
        Else
            Mensaje.Mensaje = "No se puede cambiar el estado, cuando con anterioridad ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub


    Private Sub obtenerDatosExitencia()
        existencias.cantidad = objCompraD.cantidad
        existencias.idUbicacion = objCompraD.idUbicacion
        existencias.idAlmacen = objCompra.idAlmacen
        existencias.idEmpresa = Ambiente.empr.idEmpresa
        existencias.idProductoCompuesto = objCompraD.idProductoCompuesto
        existencias.idSucursal = objCompra.idSucursal
    End Sub

    Private Function insertExistencias(estadoAct As String) As Byte
        If estadoAct = "CO" Then
            Dim validar As Byte
            validar = False
            existencias = New ExistenciaProducto(Ambiente)
            For i As Integer = 0 To objDGCompraD.Count - 1
                objCompraD = objDGCompraD.Item(i)
                obtenerDatosExitencia()
                If existencias.buscarPID() Then
                    existencias.cantidad += existencias.cantidadTemporal
                    If Not existencias.actualizar() Then
                        validar = True
                    End If
                Else

                    If Not existencias.guardar() Then
                        validar = True
                    End If
                End If
            Next
            If validar Then
                Mensaje.Mensaje = objCompraD.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la Compra y sus existencias"
                nuevoReg = False
                objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, Now, "", "")
                clicBtnNuevo()
                TabControl1.SelectTab(0)
            End If
            Return True
            Exit Function
        End If
        Return False
    End Function

    Private Sub guardar(estadoAct As String)
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If estadoAct = "CO" And FormatCurrency(txtMontoTotal.Text) <= 0 Then
            Mensaje.Mensaje = "La Compra no puede ser COMPLETADA cuando el valor de la cuenta es CERO"
            Mensaje.ShowDialog()
            Exit Sub
        End If

        obtenerDatos()
        objCompra.estado = estadoAct
        If nuevoReg Then
            If Not objCompra.guardar() Then
                Mensaje.Mensaje = objCompra.descripError
            Else
                If insertExistencias(estadoAct) = False Then
                    Mensaje.Mensaje = "Se guardó correctamente la Compra"
                    nuevoReg = False
                    objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, Now, "", "")
                    clicBtnNuevo()
                    TabControl1.SelectTab(0)
                End If
            End If
        Else
            If Not objCompra.actualizar() Then
                Mensaje.Mensaje = objCompra.descripError
            Else
                If insertExistencias(estadoAct) = False Then
                    Mensaje.Mensaje = "Se actualizó correctamente la Compra"
                    objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, Now, "", "")
                    TabControl1.SelectTab(0)
                    clicDatos(dgvCompras.SelectedRows.Item(0).Index)
                    habilitarBotones()
                End If
            End If
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        nuevoReg2 = True
        asignaDatos2()
        Controles()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la Compra: " & objCompra.noFactura & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If objCompra.eliminar() Then
                objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, "", "", "")
                TabControl1.SelectTab(0)
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "El registro se Elimino exitosamente..."
                nuevoReg = True
                asignaDatos()
                nuevoReg2 = True
                asignaDatos2()
            Else
                Mensaje.Mensaje = objCompra.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ImportacionEXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportacionEXCELToolStripMenuItem.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "Compras"
        frmImportar.ShowDialog()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvCompras.SelectedRows.Item(0).Index <> dgvCompras.Rows.Count - 1 Then
            dgvCompras.Rows(dgvCompras.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvCompras.SelectedRows.Item(0).Index <> 0 Then
            dgvCompras.Rows(dgvCompras.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objCompra.cargaGridCom(dgvCompras, objDGCompra, 0, Now, Now, elemento)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "Compras"
        frmArchivo.idTabla = objCompra.idCompra
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Compras"
        frmComentario.idTabla = objCompra.idCompra
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        frmBuscarCompras.Ambiente = Ambiente
        If frmBuscarCompras.ShowDialog = DialogResult.OK Then
            objCompra.cargaGridCom(dgvCompras, objDGCompra, frmBuscarCompras.idSucursal, frmBuscarCompras.fechaFinal, frmBuscarCompras.documentos, frmBuscarCompras.estadoDocumentos)
            TabControl1.SelectTab(0)
        End If
    End Sub

End Class