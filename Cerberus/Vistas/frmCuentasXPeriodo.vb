Imports Cerberus

Public Class frmCuentasXPeriodo
    Implements InterfaceVentanas

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Public Ambiente As AmbienteCls
    Public tipoCuenta As String

    Private cta As CuentaXPeriodo
    Private objDGCuenta As New List(Of CuentaXPeriodo)

    Private ctaD As CuentaXPeriodoDetalle
    Private objDGCuentaD As New List(Of CuentaXPeriodoDetalle)

    Private per As Periodo
    Private objPer As New List(Of Periodo)

    Private conceptoCta As ConceptoCuenta

    Private empl As Empleado

    Private nuevoReg As Boolean = True
    Private montoTotal As Decimal
    Private busqueda As String

    Private Sub frmGenerarCuentasXPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cta = New CuentaXPeriodo(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa

        conceptoCta = New ConceptoCuenta(Ambiente)
        conceptoCta.idEmpresa = Ambiente.empr.idEmpresa
        conceptoCta.tipoCuenta = tipoCuenta

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        per = New Periodo(Ambiente)
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.tabla = "Cuenta"
        per.elementoSistema = "EFE"
        per.ejercicio = Now.Year

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = cta.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = cta.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Function guardar(estadoAct As String) As Boolean
        obtenerDatos()
        cta.estado = estadoAct
        cta.idEmpleado = txtIDEmpleado.Text

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not cta.guardar() Then
                Mensaje.Mensaje = cta.descripError
                Return False
            Else
                Mensaje.Mensaje = "Se guardó correctamente la Cuenta"
                nuevoReg = False
                busqueda = cta.noDocumento
                cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
                TabControl1.SelectTab(1)
                Return True
            End If
        Else
            If Not cta.actualizar() Then
                Mensaje.Mensaje = cta.descripError
                busqueda = cta.noDocumento
                cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
                TabControl1.SelectTab(1)
                Return False
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la Cuenta"
                Return True
            End If
        End If
        Mensaje.ShowDialog()
        cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
        TabControl1.SelectTab(0)
    End Function

    Private Sub cbTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoCuenta.SelectedIndexChanged
        If cbTipoCuenta.SelectedIndex <> -1 Then
            tipoCuenta = cbTipoCuenta.SelectedItem
        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        frmBuscar.Text = "..:: Buscar Cuenta (" & tipoCuenta & ") ::.."
        frmBuscar.valorBuscado = ""
        If frmBuscar.ShowDialog = DialogResult.OK Then
            busqueda = frmBuscar.valorBuscado
            cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        Controles()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvDetalleCuenta.Rows.Count > 0 Then
            Mensaje.Mensaje = "No se puede eliminar una cuenta que ya contiene uno o más pagos"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Exit Sub
        End If
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la Cuenta: " & cta.noDocumento & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If cta.eliminar() Then
                cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = cta.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "CuentaXPeriodo"
        frmComentario.idTabla = cta.idCuentaXPeriodo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "CuentaXPeriodo"
        frmArchivo.idTabla = cta.idCuentaXPeriodo
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cta.cargaGridCom(dgvCuentas, objDGCuenta, busqueda)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "CuentaXPeriodo"
        frmLogTransaccion.idTabla = cta.idCuentaXPeriodo
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvCuentas.SelectedRows.Item(0).Index <> 0 Then
            dgvCuentas.Rows(dgvCuentas.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvCuentas.SelectedRows.Item(0).Index <> dgvCuentas.Rows.Count - 1 Then
            dgvCuentas.Rows(dgvCuentas.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            cta = New CuentaXPeriodo(Ambiente)
            cta.tipoCuenta = tipoCuenta
            cta.idEmpresa = Ambiente.empr.idEmpresa
            cta.estado = "BO"
            cta.esActivo = True
            dtpFechaMov.Value = Now
            cbTipoCuenta.SelectedIndex = -1
        Else
            dtpFechaMov.Value = cta.fechaCuenta
            cbTipoCuenta.SelectedItem = cta.tipoCuenta
        End If

        ctaD = New CuentaXPeriodoDetalle(Ambiente)
        ctaD.idCuentaXPeriodo = cta.idCuentaXPeriodo
        ctaD.cargaGridCom(dgvDetalleCuenta, objDGCuentaD)

        txtDescrip.Text = cta.descripccionCuenta
        txtMontoPer.Text = cta.montoXPeriodo
        txtNoPer.Text = cta.numeroPeriodos
        txtEstado.Text = cta.getNombreEstado
        txtNumDocumento.Text = cta.noDocumento
        txtMontoTotal.Text = cta.monto
        esActivo.Checked = cta.esActivo

        empl = New Empleado(Ambiente)
        empl.idEmpresa = Ambiente.empr.idEmpresa
        empl.idEmpleado = cta.idEmpleado
        empl.buscarPID()

        txtIDEmpleado.Text = empl.idEmpleado
        txtNombreEmpleado.Text = empl.nombreCompleto

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = cta.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = cta.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        conceptoCta = New ConceptoCuenta(Ambiente)
        conceptoCta.idEmpresa = Ambiente.empr.idEmpresa
        conceptoCta.tipoCuenta = tipoCuenta
        conceptoCta.idConceptoCuenta = cta.idConceptoCuenta
        If conceptoCta.buscarPID() Then
            txtIDConcepto.Text = conceptoCta.idConceptoCuenta
            txtDescripConcepto.Text = conceptoCta.nombreConceptoCuenta
        Else
            txtIDConcepto.Text = ""
            txtDescripConcepto.Text = ""
        End If

        lblStatus.Text = cta.getDetalleMod()

        txtPagado.Text = dgvDetalleCuenta.Rows.Count
        txtRestante.Text = Integer.Parse(txtNoPer.Text) - Integer.Parse(txtPagado.Text)
    End Sub

    Private Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        cta.tipoCuenta = cbTipoCuenta.SelectedItem
        cta.noDocumento = txtNumDocumento.Text
        cta.fechaCuenta = dtpFechaMov.Value.Date
        cta.descripccionCuenta = txtDescrip.Text
        cta.montoXPeriodo = txtMontoPer.Text
        cta.numeroPeriodos = txtNoPer.Text
        cta.esActivo = esActivo.Checked
        cta.idEmpleado = txtIDEmpleado.Text
        cta.monto = txtMontoTotal.Text

        If cbSucursal.SelectedIndex <> -1 Then
            cta.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            cta.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            cta.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            cta.idEmpresa = Nothing
        End If

        If txtIDConcepto.Text <> Nothing Then
            cta.idConceptoCuenta = txtIDConcepto.Text
        Else
            cta.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            cta = objDGCuenta.Item(indice)
            asignaDatos()
            Controles()
        End If
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

    Private Sub BORRADORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BORRADORToolStripMenuItem.Click
        If cta.estado = "BO" Then
            guardar("BO")
        Else
            Mensaje.Mensaje = "No se puede cambiar a estado ""BORRADOR"" cuando ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub COMPLETARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COMPLETARToolStripMenuItem.Click
        If cta.estado = "BO" Then
            guardar("CO")
        Else
            Mensaje.Mensaje = "No se puede cambiar el estado, cuando con anterioridad ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvCuentas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCuentas.SelectionChanged
        If dgvCuentas.SelectedRows.Count > 0 Then
            clicDatos(dgvCuentas.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub txtNoPer_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNoPer.KeyUp
        If Not IsNumeric(txtMontoTotal.Text) Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Para hacer el cálculo por periodos, es necesario ingresar el monto total"
            Mensaje.ShowDialog()
        Else
            If IsNumeric(txtNoPer.Text) Then
                If txtNoPer.Text > 0 Then
                    txtMontoPer.Text = Format(Decimal.Parse(txtMontoTotal.Text) / Integer.Parse(txtNoPer.Text), "0.00")
                Else
                    txtMontoPer.Text = 0.00
                End If
            End If
        End If
    End Sub

    Private Sub txtMontoPer_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMontoPer.KeyUp
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If Not IsNumeric(txtMontoTotal.Text) Then
            Mensaje.Mensaje = "Para hacer el cálculo por periodos, es necesario ingresar el monto total"
            Mensaje.ShowDialog()
        Else
            If IsNumeric(txtMontoPer.Text) Then
                If txtMontoPer.Text > 0 Then
                    If Decimal.Parse(txtMontoPer.Text) > Decimal.Parse(txtMontoTotal.Text) Then
                        Mensaje.Mensaje = "No se puede ingresar una cantidad mayor a la cantidad total"
                        Mensaje.ShowDialog()
                        txtMontoPer.Text = Mid(txtMontoPer.Text, 1, (txtMontoPer.Text.Length - 1))
                        Exit Sub
                    End If
                    txtNoPer.Text = Math.Ceiling(Decimal.Parse(txtMontoTotal.Text) / Decimal.Parse(txtMontoPer.Text))
                Else
                    txtNoPer.Text = 0
                End If
            End If
        End If
    End Sub

    Private Sub Controles()
        If cta.estado = "BO" Then
            dtpFechaMov.Enabled = True
            txtNumDocumento.ReadOnly = False
            cbSucursal.Enabled = True
            Button1.Enabled = True
            txtMontoTotal.ReadOnly = False
            txtNoPer.ReadOnly = False
            txtMontoPer.ReadOnly = False
            txtDescrip.ReadOnly = False
        Else
            dtpFechaMov.Enabled = False
            txtNumDocumento.ReadOnly = True
            cbSucursal.Enabled = False
            Button1.Enabled = False
            txtMontoTotal.ReadOnly = True
            txtNoPer.ReadOnly = True
            txtMontoPer.ReadOnly = True
            txtDescrip.ReadOnly = True
        End If
    End Sub

    Private Sub btnConcepto_Click(sender As Object, e As EventArgs) Handles btnConcepto.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = tipoCuenta
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub btnImporEXCEL_Click(sender As Object, e As EventArgs) Handles btnImporEXCEL.Click

    End Sub
End Class