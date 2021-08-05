Imports Cerberus

Public Class frmEntregas
    Implements InterfaceVentanas
    Private objDGEntrega As New List(Of Entregas)
    Private objEntrega As Entregas
    Public Ambiente As AmbienteCls
    Private objDetalleEntrega As DetalleEntregas
    Private objDGDetaleEntrega As New List(Of DetalleEntregas)
    Private controlBotones As Integer
    Private idUbicacion As Integer
    Private nuevoReg As Boolean
    Private nuevoReg3 As Boolean
    Private existDisp As Decimal
    Private cantidadTemporal As Decimal
    Private eventoListener As Byte

    Private Sub frmEntregas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        existDisp = 100000000000
        objEntrega = New Entregas(Ambiente)
        objEntrega.cargaGridCom(dgvEntrega, objDGEntrega, 0, DateAdd(DateInterval.Year, 1, Now))
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            objEntrega = New Entregas(Ambiente)
            objEntrega.idEmpresa = Ambiente.empr.idEmpresa
            DTPEntrega.ResetText()
            txtNombreEntrega.Text = ""
            txtDescripcionEntrega.Text = ""
        Else
            DTPEntrega.Value = objEntrega.fecha
            txtNombreEntrega.Text = objEntrega.nombre
            txtDescripcionEntrega.Text = objEntrega.descripcion
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        If IsDate(DTPEntrega.Value) Then
            objEntrega.fecha = DTPEntrega.Value
        Else
            objEntrega.fecha = Nothing
        End If
        If txtNombreEntrega.Text Is Nothing Then
            objEntrega.nombre = Nothing
        Else
            objEntrega.nombre = txtNombreEntrega.Text
        End If
        If txtDescripcionEntrega.Text Is Nothing Then
            objEntrega.descripcion = Nothing
        Else
            objEntrega.descripcion = txtDescripcionEntrega.Text
        End If
    End Sub

    Public Sub obtenerDatosDetalleEntrega()
        objDetalleEntrega.idEntrega = objEntrega.idEntrega

        If IsNumeric(txtIDEmpleado.Text) Then
            objDetalleEntrega.idEmpleado = txtIDEmpleado.Text
        Else
            objDetalleEntrega.idEmpleado = Nothing
        End If

        If IsNumeric(txtIDProducto.Text) Then
            objDetalleEntrega.idProductoCompuesto = txtIDProducto.Text
        Else
            objDetalleEntrega.idProductoCompuesto = Nothing
        End If

        If IsNumeric(txtCantidad.Text) Then
            objDetalleEntrega.cantidad = txtCantidad.Text
        Else
            objDetalleEntrega.cantidad = Nothing
        End If

        If IsNumeric(txtDescuento.Text) Then
            objDetalleEntrega.descuento = txtDescuento.Text
        Else
            objDetalleEntrega.descuento = Nothing
        End If

        If IsNumeric(txtPrecio.Text) Then
            objDetalleEntrega.precio = txtPrecio.Text
        Else
            objDetalleEntrega.precio = Nothing
        End If

        If IsNumeric(txtTotal.Text) Then
            objDetalleEntrega.total = txtTotal.Text
        Else
            objDetalleEntrega.total = Nothing
        End If

        If IsNumeric(txtIDUbicacion.Text) Then
            objDetalleEntrega.idUbicacion = txtIDUbicacion.Text
        Else
            objDetalleEntrega.total = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        objDetalleEntrega = New DetalleEntregas(Ambiente)
        If indice <> -1 Then
            nuevoReg = False
            objEntrega = objDGEntrega.Item(indice)
            asignaDatos()
            objDetalleEntrega.cargaGridCom(dgvEmpleados, objEntrega.idEntrega)
        End If
    End Sub

    Public Sub clicDatos2(idEmpleado As Integer)
        objDetalleEntrega = New DetalleEntregas(Ambiente)
        If idEmpleado <> -1 And idEmpleado <> 0 Then
            nuevoReg3 = False
            objDetalleEntrega.cargaGrdDetallesEntrega(dgvDetalles, objEntrega.idEntrega, idEmpleado, objDGDetaleEntrega)
        End If
    End Sub

    Public Sub clicDatos3(indice As Integer)
        objDetalleEntrega = New DetalleEntregas(Ambiente)
        If indice <> -1 Then
            nuevoReg3 = False
            objDetalleEntrega = objDGDetaleEntrega.Item(indice)
            asignaDatos3()
        End If
    End Sub

    Public Sub asignaDatos2()
        If nuevoReg3 Then
            objEntrega = New Entregas(Ambiente)
            objEntrega.idEmpresa = Ambiente.empr.idEmpresa
            DTPEntrega.ResetText()
            txtNombreEntrega.Text = ""
            txtDescripcionEntrega.Text = ""
        Else
            DTPEntrega.Value = objEntrega.fecha
            txtNombreEntrega.Text = objEntrega.nombre
            txtDescripcionEntrega.Text = objEntrega.descripcion
        End If
    End Sub

    Public Sub asignaDatos3()
        If nuevoReg3 Then
            If objDetalleEntrega.idEmpleado = Nothing Then
                txtIDEmpleado.Text = Nothing
                txtNombreEmpleado.Text = Nothing
            Else
                txtIDEmpleado.Text = objDetalleEntrega.idEmpleado
                txtNombreEmpleado.Text = objDetalleEntrega.nombreEmpleado
            End If
            objDetalleEntrega = New DetalleEntregas(Ambiente)
            txtIDProducto.Text = ""
            txtNombreProd.Text = ""
            txtCantidad.Text = ""
            txtDescuento.Text = ""
            txtPrecio.Text = ""
            txtTotal.Text = ""
            txtNombreUbic.Text = ""
            txtIDUbicacion.Text = ""
            txtNombreUbic.Text = ""
        Else
            txtNombreUbic.Text = objDetalleEntrega.nombreUbicacion
            txtIDUbicacion.Text = objDetalleEntrega.idUbicacion
            txtIDProducto.Text = objDetalleEntrega.idProductoCompuesto
            txtNombreProd.Text = objDetalleEntrega.nombreProd
            txtIDEmpleado.Text = objDetalleEntrega.idEmpleado
            txtNombreEmpleado.Text = objDetalleEntrega.nombreEmpleado
            txtCantidad.Text = objDetalleEntrega.cantidad
            txtDescuento.Text = objDetalleEntrega.descuento
            txtPrecio.Text = objDetalleEntrega.precio
            txtTotal.Text = objDetalleEntrega.total
            Existencias = New ExistenciaProducto(Ambiente)
            obtenerDatosExitencia()
            If Existencias.buscarPID() Then
                existDisp = Existencias.cantidadTemporal
            End If
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        ' Throw New NotImplementedException()
    End Sub
    'Celdas de tabla Entregas
    Private Sub dgvEntrega_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEntrega.SelectionChanged
        If dgvEntrega.SelectedRows.Count > 0 Then
            clicDatos(dgvEntrega.SelectedRows.Item(0).Index)
            habilitarBotones()
            dgvDetalles.Columns.Clear()
        End If
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntrega.CellDoubleClick
        clicDatos(e.RowIndex)
        dgvDetalles.Columns.Clear()
        habilitarBotones()
        TbGeneral.SelectTab(1)
    End Sub

    Private Sub dgvEmpleados_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmpleados.SelectionChanged
        Dim valor As Integer
        If dgvEmpleados.SelectedRows.Count > 0 Then
            valor = Me.dgvEmpleados.Item(0, dgvEmpleados.SelectedRows.Item(0).Index).Value
            clicDatos2(valor)
        End If
    End Sub

    Private Sub dgvEmpleados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellDoubleClick
        Dim Valor As Integer
        Valor = Me.dgvEmpleados.Item(0, e.RowIndex).Value
        clicDatos2(Valor)
        TbGeneral.SelectTab(3)
        tbDetalleE.SelectTab(0)
    End Sub

    Private Sub dgvDetalleE_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalles.SelectionChanged
        eventoListener = False
        If dgvDetalles.SelectedRows.Count > 0 Then
            clicDatos3(dgvDetalles.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub dgvDetalles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellDoubleClick
        eventoListener = False
        clicDatos3(e.RowIndex)
        tbDetalleE.SelectTab(1)
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        txtCantidad.Text = ""
        frmBuscarProductoCompuesto.Ambiente = Ambiente
        frmBuscarProductoCompuesto.wExistence = True
        If frmBuscarProductoCompuesto.ShowDialog() = DialogResult.OK Then
            If frmBuscarProductoCompuesto.productoRetorno.cantidad = 0 Then
                If nuevoReg3 = False Then
                    eliminarExistencia()
                End If
                MsgBox("No hay Existencias de este producto")
                txtIDProducto.Text = ""
                txtNombreProd.Text = ""
                txtPrecio.Text = ""
                txtNombreUbic.Text = ""
                txtNombreUbic.Text = ""
                txtDescuento.Text = 0.0
                txtIDUbicacion.Text = ""

            Else
                If nuevoReg3 = False Then
                    eliminarExistencia()
                End If
                txtNombreUbic.Text = frmBuscarProductoCompuesto.productoRetorno.nombreUbicacion
                txtIDUbicacion.Text = frmBuscarProductoCompuesto.productoRetorno.idUbicacion
                existDisp = frmBuscarProductoCompuesto.productoRetorno.cantidad
                txtIDProducto.Text = frmBuscarProductoCompuesto.productoRetorno.idProductoCompuesto
                txtNombreProd.Text = frmBuscarProductoCompuesto.productoRetorno.producto & " " & frmBuscarProductoCompuesto.productoRetorno.modelo & " " & frmBuscarProductoCompuesto.productoRetorno.talla
                txtPrecio.Text = frmBuscarProductoCompuesto.productoRetorno.precio
                If frmBuscarProductoCompuesto.productoRetorno.discount Then
                    txtDescuento.Text = frmBuscarProductoCompuesto.productoRetorno.porcentaje
                Else
                    txtDescuento.Text = 0.0
                End If

            End If
        End If
    End Sub

    Private Sub eliminarExistencia()
        If obtenerDatosExitencia() Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If Existencias.buscarPID() Then
                Existencias.cantidad += Existencias.cantidadTemporal + objDetalleEntrega.cantidad
                If Existencias.actualizar() Then
                    objDetalleEntrega.cantidad = 0
                    If Not objDetalleEntrega.actualizar() Then
                        Mensaje.Mensaje = objDetalleEntrega.descripError
                    Else
                        Mensaje.Mensaje = "Se Devolvió el producto al almacen correctamente..."
                        Existencias.cantidadTemporal = 0
                        objDetalleEntrega.cantidad = 0
                        Existencias.cantidad = 0
                    End If
                    Mensaje.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = False
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TbGeneral.SelectedIndexChanged
        If Me.TbGeneral.SelectedIndex = 0 Then '1ª pagina selccionada
            controlBotones = 0
        ElseIf Me.TbGeneral.SelectedIndex = 1 Then '2ª pagina selccionada
            controlBotones = 1
        ElseIf Me.TbGeneral.SelectedIndex = 2 Then '3ª pagina selccionada
            controlBotones = 2
        ElseIf Me.TbGeneral.SelectedIndex = 3 Then '4ª pagina selccionada
            controlBotones = 3
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        Select Case controlBotones
            Case 0
            Case 1
                obtenerDatos()
                If nuevoReg Then
                    If objEntrega.guardar() Then
                        Mensaje.Mensaje = "El registro se guardó exitosamente..."
                    Else
                        Mensaje.Mensaje = "Existe un error: " & objEntrega.descripError
                    End If
                Else
                    If objEntrega.actualizar() Then
                        Mensaje.Mensaje = "El registro se actualizó exitosamente..."
                    Else
                        Mensaje.Mensaje = "Existe un error: " & objEntrega.descripError
                    End If
                End If
                objEntrega.cargaGridCom(dgvEntrega, objDGEntrega, 0, Now)
                TbGeneral.SelectTab(0)
                Mensaje.ShowDialog()
            Case 2
                'guardar()
            Case 3
                guardar()
            Case Else
        End Select
    End Sub

    Private Sub guardar()
        Dim Bole As Byte
        Bole = False

        If IsNumeric(txtCantidad.Text) = False Or txtCantidad.Text = "" Then
            txtCantidad.Text = "0"
        End If

        If txtCantidad.Text <= existDisp Then
            Bole = True
        End If
        If objDetalleEntrega.cantidad > 0 Then
            If txtCantidad.Text <= (objDetalleEntrega.cantidad + existDisp) Then
                Bole = True
            End If
        End If

        If Bole Then
            cantidadTemporal = objDetalleEntrega.cantidad
            obtenerDatosDetalleEntrega()
            If nuevoReg3 Then
                If objDetalleEntrega.guardar() Then
                    If gExistencias() Then
                        Mensaje.Mensaje = "Se guardó correctamente la Compra y su Existencia"
                    End If
                Else
                    Mensaje.Mensaje = "Existe un error: " & objDetalleEntrega.descripError
                End If
            Else
                If objDetalleEntrega.actualizar() Then
                    If gExistencias() Then
                        Mensaje.Mensaje = "El registro se actualizó exitosamente..."
                    End If
                Else
                    Mensaje.Mensaje = "Existe un error: " & objDetalleEntrega.descripError
                End If
            End If
            objDetalleEntrega.cargaGrdDetallesEntrega(dgvDetalles, objEntrega.idEntrega, objDetalleEntrega.idEmpleado, objDGDetaleEntrega)
            objDetalleEntrega.cargaGridCom(dgvEmpleados, objEntrega.idEntrega)
            tbDetalleE.SelectTab(0)
            TbGeneral.SelectTab(2)
            Mensaje.ShowDialog()
        Else
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "No Hay suficientes Existencias, cuentas con: " & existDisp & " en Stock para la entrega, intenta con otra ubicación u otro producto"
            txtCantidad.Text = ""
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Existencias As ExistenciaProducto

    Private Function obtenerDatosExitencia() As Byte
        Try
            Existencias.idUbicacion = txtIDUbicacion.Text
            Existencias.idEmpresa = Ambiente.empr.idEmpresa
            Existencias.idProductoCompuesto = objDetalleEntrega.idProductoCompuesto
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function gExistencias() As Byte
        If cantidadTemporal <> objDetalleEntrega.cantidad Then
            Dim inserCount As Decimal
            inserCount = cantidadTemporal - objDetalleEntrega.cantidad
            Existencias = New ExistenciaProducto(Ambiente)
            If obtenerDatosExitencia() Then
                If Existencias.buscarPID() Then
                    Existencias.cantidad += Existencias.cantidadTemporal + inserCount
                    If Not Existencias.actualizar() Then
                        Return True
                    End If
                End If
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Select Case controlBotones
            Case 0
                nuevoReg = True
                asignaDatos()
                TbGeneral.SelectTab(1)
            Case 1
                nuevoReg = True
                asignaDatos()
            Case 2
                TbGeneral.SelectTab(3)
                nuevoReg3 = True
                asignaDatos3()
                tbDetalleE.SelectTab(1)
            Case 3
                nuevoReg3 = True
                asignaDatos3()
                tbDetalleE.SelectTab(1)
            Case Else
        End Select
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        Select Case controlBotones
            Case 0
                If objEntrega.eliminar() Then
                    Mensaje.Mensaje = "El registro se Elimino exitosamente..."
                Else
                    Mensaje.Mensaje = "Existe un error: " & objDetalleEntrega.descripError
                End If
                nuevoReg = True
                nuevoReg3 = True
                asignaDatos3()
                asignaDatos2()
                asignaDatos()
                objEntrega.cargaGridCom(dgvEntrega, objDGEntrega, 0, Now)
                TbGeneral.SelectTab(0)
                Mensaje.ShowDialog()
            Case 1
                If objEntrega.eliminar() Then
                    Mensaje.Mensaje = "El registro se Elimino exitosamente..."
                Else
                    Mensaje.Mensaje = "Existe un error: " & objDetalleEntrega.descripError
                End If
                nuevoReg = True
                nuevoReg3 = True
                asignaDatos3()
                asignaDatos2()
                asignaDatos()
                objEntrega.cargaGridCom(dgvEntrega, objDGEntrega, 0, Now)
                TbGeneral.SelectTab(0)
                Mensaje.ShowDialog()
            Case 2
                eliminarDetalleExistencia()
            Case 3
                eliminarDetalleExistencia()
            Case Else
        End Select
    End Sub





    Private Sub eliminarDetalleExistencia()
        obtenerDatosExitencia()
        If Existencias.buscarPID() Then
            Existencias.cantidad += Existencias.cantidadTemporal + objDetalleEntrega.cantidad
            If Existencias.actualizar() Then
                If objDetalleEntrega.eliminar() Then
                    Mensaje.Mensaje = "El registro se Elimino exitosamente..."
                    objDetalleEntrega.cargaGridCom(dgvEmpleados, objEntrega.idEntrega)
                    TbGeneral.SelectTab(2)
                    nuevoReg3 = True
                    objDetalleEntrega.cargaGrdDetallesEntrega(dgvDetalles, objEntrega.idEntrega, objDetalleEntrega.idEmpleado, objDGDetaleEntrega)
                    asignaDatos3()
                Else
                    Mensaje.Mensaje = "Existe un error: " & objDetalleEntrega.descripError
                End If
            End If
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub txtCantidad_Change(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        If IsNumeric(txtCantidad.Text) Then
            calcular()
        End If
    End Sub
    Private Sub txtDescuento_Change(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        calcular()
    End Sub
    Private Sub txtPrecio_Change(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        calcular()
    End Sub

    Private Sub calcular()
        Dim descuento As Decimal
        Dim precio As Decimal
        Dim cantidad As Decimal
        Dim idEmpleado As Integer
        If IsNumeric(txtDescuento.Text) Then
            descuento = txtDescuento.Text
        Else
            descuento = Nothing
        End If
        If IsNumeric(txtPrecio.Text) Then
            precio = txtPrecio.Text
        Else
            precio = Nothing
        End If
        If IsNumeric(txtCantidad.Text) Then
            cantidad = txtCantidad.Text
        Else
            cantidad = Nothing
        End If
        If IsNumeric(txtIDEmpleado.Text) Then
            idEmpleado = txtIDEmpleado.Text
        Else
            idEmpleado = Nothing
        End If
        txtTotal.Text = objDetalleEntrega.calcular(descuento, precio, cantidad, idEmpleado, objEntrega.fecha)
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click

    End Sub

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem1.Click
        objEntrega.RPT_ImprimirRptcXc()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        objEntrega.RPT_ModificarRptcXc()
    End Sub

End Class

