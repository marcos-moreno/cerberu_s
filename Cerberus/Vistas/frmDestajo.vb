Imports Cerberus

Public Class frmDestajo
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private empl As Empleado

    Private des As Destajo
    Private objDgvDes As New List(Of Destajo)

    Private ori As Origen
    Private objCbOri As New List(Of Origen)

    Private eta As Etapa
    Private objCbEta As New List(Of Etapa)

    Private objCbSuc As New List(Of Sucursal)
    Private objCbEmpr As New List(Of Empresa)

    Private nuevoReg As Boolean
    Private filtro As String
    Private idFiltro As String
    Private granTotal As Decimal
    Private estadoAnt As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            des = New Destajo(Ambiente)
            des.idEmpresa = Ambiente.empr.idEmpresa
            cbOrigen.SelectedIndex = 0
            dtpFechaDes.Value = Now
        Else
            cbOrigen.SelectedItem = des.origen
            dtpFechaDes.Value = des.fechaDestajo
        End If

        txtEtiqueta.Text = des.etiqueta
        esPagado.Checked = des.esPagado
        txtBurbujasMolde.Text = des.numBurbujasXMolde
        txtBurbujasEmp.Text = des.numBurbujasXEmpleado
        txtMontoDes.Text = des.montoDestajo
        txtReferencia.Text = des.referenciaExterna
        txtNumPuntos.Text = des.numPuntos
        esActivo.Checked = des.esActivo

        empl = New Empleado(Ambiente)
        empl.idEmpresa = Ambiente.empr.idEmpresa
        empl.idEmpleado = des.idEmpleado
        empl.buscarPID()

        txtIDEmpleado.Text = empl.idEmpleado
        txtNombreEmpleado.Text = empl.nombreCompleto

        lblStatus.Text = des.getDetalleMod()

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = des.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = des.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        cbEtapa.SelectedIndex = -1
        For i As Integer = 0 To cbEtapa.Items.Count - 1
            If objCbEta.Item(i).idEtapa = des.idEtapa Then
                cbEtapa.SelectedIndex = i
                Exit For
            End If
        Next

        cbOrigen.SelectedIndex = -1
        For i As Integer = 0 To cbOrigen.Items.Count - 1
            If objCbOri.Item(i).origen = des.origen Then
                cbOrigen.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

    Public Sub nuevoCalculo(indice As Integer)
        If estadoAnt <> dgvDestajo.Rows(indice).Cells(0).Value Then
            If estadoAnt = True Then
                granTotal -= objDgvDes(indice).montoDestajo
                lblTotalSeleccion.Text = "Total Destajos Seleccionados: " & FormatCurrency(granTotal)
            Else
                granTotal += objDgvDes(indice).montoDestajo
                lblTotalSeleccion.Text = "Total Destajos Seleccionados: " & FormatCurrency(granTotal)
            End If
        End If

    End Sub

    Public Sub calcularTotal()
        Dim accion As Boolean
        accion = chbSelTodo.Checked

        granTotal = 0
        For i As Integer = 0 To dgvDestajo.Rows.Count - 1
            dgvDestajo.Rows(i).Cells(0).Value = accion

            If dgvDestajo.Rows(i).Cells(0).Value = True Then
                granTotal += objDgvDes(i).montoDestajo
            End If
        Next

        lblTotalSeleccion.Text = "Total Destajos Seleccionados: " & FormatCurrency(granTotal)
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        des.etiqueta = txtEtiqueta.Text
        des.idEmpleado = txtIDEmpleado.Text
        des.fechaDestajo = dtpFechaDes.Value
        des.esPagado = esPagado.Checked
        des.numBurbujasXMolde = txtBurbujasMolde.Text
        des.numBurbujasXEmpleado = txtBurbujasEmp.Text
        des.montoDestajo = txtMontoDes.Text
        des.referenciaExterna = txtReferencia.Text
        des.numPuntos = txtNumPuntos.Text
        des.origen = cbOrigen.SelectedItem
        des.esActivo = esActivo.Checked

        If cbSucursal.SelectedIndex <> -1 Then
            des.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            des.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            des.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            des.idEmpresa = Nothing
        End If
        If cbEtapa.SelectedIndex <> -1 Then
            des.idEtapa = objCbEta.Item(cbEtapa.SelectedIndex).idEtapa
        Else
            des.idEtapa = Nothing
        End If
        If cbOrigen.SelectedIndex <> -1 Then
            des.origen = objCbOri.Item(cbOrigen.SelectedIndex).origen
        Else
            des.origen = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            des = objDgvDes.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False

            txtBurbujasMolde.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
    End Sub

    Private Sub frmDestajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ori = New Origen(Ambiente)
        ori.idEmpresa = Ambiente.empr.idEmpresa
        ori.elemento = "Destajo"
        ori.getComboActivo(cbOrigen, objCbOri)

        des = New Destajo(Ambiente)
        des.idEmpresa = Ambiente.empr.idEmpresa

        eta = New Etapa(Ambiente)
        eta.idEmpresa = Ambiente.empr.idEmpresa
        eta.getComboActivo(cbEtapa, objCbEta)

        chbSelTodo.Checked = False

        TabPage2.Parent = Nothing

        cargarDatos()

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        lblStatus.Text = ""

        granTotal = 0
        lblTotalSeleccion.Text = "Total Destajos Seleccionados: " & FormatCurrency(granTotal)
    End Sub

    Sub cargarDatos()
        granTotal = 0
        des.cargaGridCom(dgvDestajo, objDgvDes, chbSoloPendientes.Checked, filtro, idFiltro, chbTodo.Checked)
        lblTotal.Text = "Total: " & dgvDestajo.Rows.Count
        lblTotalSeleccion.Text = "Total Destajos Seleccionados: " & FormatCurrency(granTotal)
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        frmCatalogo.txtValue.Text = filtro
        frmCatalogo.Text = "..:: Buscar Destajo ::.."
        If frmCatalogo.ShowDialog() = DialogResult.OK Then
            filtro = frmCatalogo.txtValue.Text
            idFiltro = frmCatalogo.txtID.Text
            cargarDatos()
            chbSelTodo.Checked = False
        End If
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
            If Not des.guardar() Then
                Mensaje.Mensaje = des.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el destajo"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not des.actualizar() Then
                Mensaje.Mensaje = des.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente destajo"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            cargarDatos()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el destajo: " & des.idEmpleado & "/" & des.referenciaExterna & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If des.eliminar() Then
                cargarDatos()
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = des.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Destajo"
        frmComentario.idTabla = des.idDestajo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cargarDatos()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Destajo"
        frmLogTransaccion.idTabla = des.idDestajo
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvDestajo.SelectedRows.Item(0).Index <> 0 Then
            dgvDestajo.Rows(dgvDestajo.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvDestajo.SelectedRows.Item(0).Index <> dgvDestajo.Rows.Count - 1 Then
            dgvDestajo.Rows(dgvDestajo.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub dgvDestajo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDestajo.CellDoubleClick
        'clicDatos(e.RowIndex)
        'habilitarBotones()
        'TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvDestajo_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDestajo.SelectionChanged
        If dgvDestajo.SelectedRows.Count > 0 Then
            'clicDatos(dgvDestajo.SelectedRows.Item(0).Index)
            'habilitarBotones()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub chbSoloPendientes_Click(sender As Object, e As EventArgs) Handles chbSoloPendientes.Click
        cargarDatos()
    End Sub

    Private Sub SincronizarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SincronizarToolStripMenuItem1.Click
        frmExtraerDestajos.Ambiente = Ambiente
        frmExtraerDestajos.elemento = "Destajo"
        frmExtraerDestajos.ShowDialog()
        cargarDatos()
    End Sub

    Private Sub GenerarPagoSeleccionadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarPagoSeleccionadosToolStripMenuItem.Click
        frmPagoCuenta.Ambiente = Ambiente
        frmPagoCuenta.tipoCuenta = "CxP"

        Dim numCuenta As String = Nothing
        Dim totalCuenta As Decimal

        If frmPagoCuenta.ShowDialog = DialogResult.OK Then
            Dim objDGDestajo As New List(Of Destajo)

            objDGDestajo.Clear()

            For i As Integer = 0 To dgvDestajo.Rows.Count - 1
                If dgvDestajo.Rows(i).Cells(0).Value = True Then
                    objDGDestajo.Add(objDgvDes.Item(i))
                End If

            Next

            Dim objDestajoPago As New DestajoPago(Ambiente)
            objDestajoPago.idEmpresa = Ambiente.empr.idEmpresa
            If objDestajoPago.pagarDestajos(objDGDestajo, frmPagoCuenta.fechaRetorno, frmPagoCuenta.idRetorno, numCuenta, totalCuenta) Then
                Mensaje.Mensaje = "Se genero correctamente la CxP Num: (" & numCuenta & ") por un total de: (" & FormatCurrency(totalCuenta) & ")"
            Else
                Mensaje.Mensaje = objDestajoPago.descripError
            End If

            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()

            cargarDatos()
        End If
    End Sub

    Private Sub dgvDestajo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDestajo.CellEndEdit
        nuevoCalculo(e.RowIndex)
    End Sub

    Private Sub dgvDestajo_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvDestajo.CellBeginEdit
        estadoAnt = dgvDestajo.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub chbSelTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbSelTodo.Click
        calcularTotal()
    End Sub
End Class