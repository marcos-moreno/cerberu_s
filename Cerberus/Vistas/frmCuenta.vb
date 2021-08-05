Imports Cerberus

Public Class frmCuenta
    Implements InterfaceVentanas

    Private nuevoReg As Boolean
    Private nuevoReg2 As Boolean

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private montoTotal As Decimal
    Private empl As Empleado
    Private coci As Cocina

    Public Ambiente As AmbienteCls
    Public tipoCuenta As String
    Public elemento As String

    Private cta As Cuenta
    Private objDGCuenta As New List(Of Cuenta)

    Private ctaD As CuentaDetalle
    Private objDGCuentaD As New List(Of CuentaDetalle)

    Private conceptoCta As ConceptoCuenta
    Private edoDocs As EstadoDocumentos

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            cta = New Cuenta(Ambiente)
            cta.tipoCuenta = tipoCuenta
            cta.idEmpresa = Ambiente.empr.idEmpresa
            cta.estado = "BO"

            dtpFechaMov.Value = Now
            TabControl2.Enabled = False
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
            btnGuardar2.Enabled = False
        Else
            dtpFechaMov.Value = cta.fechaCuenta
            TabControl2.Enabled = True

            If cta.estado = "BO" Then
                btnNuevo2.Enabled = True
                btnEliminar2.Enabled = True
                btnGuardar2.Enabled = True
                If chbGeneral.Checked Then
                    btnConcepto.Enabled = False
                Else
                    btnConcepto.Enabled = True
                End If
            End If

        End If

            ctaD = New CuentaDetalle(Ambiente)
        ctaD.idCuenta = cta.idCuenta
        ctaD.cargaGridCom(dgvDetalleCuenta, objDGCuentaD)

        txtTipoMovimiento.Text = cta.tipoCuenta
        txtEstado.Text = edoDocs.getNombreEstado(cta.estado)
        txtNumDocumento.Text = cta.noDocumento
        montoTotal = cta.monto
        txtMontoTotal.Text = FormatCurrency(montoTotal)
        rtbDescripCuenta.Text = cta.descripccion


        If elemento = "Empleado" Then
            empl = New Empleado(Ambiente)
            empl.idEmpresa = Ambiente.empr.idEmpresa
            empl.idEmpleado = cta.idEmpleado
            empl.buscarPID()

            txtIDEmpleadoCocina.Text = empl.idEmpleado
            txtNombreEmpleadoCocina.Text = empl.nombreCompleto
        Else
            coci = New Cocina(Ambiente)
            coci.idEmpresa = Ambiente.empr.idEmpresa
            coci.idCocina = cta.idCocina
            coci.buscarPID()

            txtIDEmpleadoCocina.Text = coci.idCocina
            txtNombreEmpleadoCocina.Text = coci.nombreCocina
        End If

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

        If elemento = "Empleado" Then
            lblEmplCocina.Text = "Empleado (PIN):"
        Else
            lblEmplCocina.Text = "Cocina:"
        End If

        Controles()
        lblStatus.Text = cta.getDetalleMod() & " | " & ctaD.getDetalleMod()
    End Sub

    Public Sub asignaDatos2()
        If nuevoReg2 Then
            ctaD = New CuentaDetalle(Ambiente)
            ctaD.idCuenta = cta.idCuenta
        End If

        txtMonto.Text = ctaD.monto
        txtDescrip.Text = ctaD.descripccion

        conceptoCta.idConceptoCuenta = ctaD.idConceptoCuenta
        If conceptoCta.buscarPID() Then
            txtIDConcepto.Text = conceptoCta.idConceptoCuenta
            txtDescripConcepto.Text = conceptoCta.nombreConceptoCuenta
        Else
            txtIDConcepto.Text = ""
            txtDescripConcepto.Text = ""
        End If

        If chbGeneral.Checked Then
            txtDescrip.Text = txtDescripConcepGen.Text
            txtIDConcepto.Text = txtIDConcepGen.Text
            txtDescripConcepto.Text = txtDescripConcepGen.Text
        End If

        lblStatus.Text = cta.getDetalleMod() & " | " & ctaD.getDetalleMod()
    End Sub

    Public Sub obtenerDatos2()
        If IsNumeric(txtMonto.Text) Then
            ctaD.monto = txtMonto.Text
        Else
            ctaD.monto = 0
        End If

        ctaD.descripccion = txtDescrip.Text

        If txtIDConcepto.Text <> Nothing Then
            ctaD.idConceptoCuenta = txtIDConcepto.Text
        Else
            ctaD.idConceptoCuenta = Nothing
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        cta.tipoCuenta = txtTipoMovimiento.Text
        cta.noDocumento = txtNumDocumento.Text
        cta.fechaCuenta = dtpFechaMov.Value
        cta.monto = montoTotal
        cta.descripccion = rtbDescripCuenta.Text

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
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            cta = objDGCuenta.Item(indice)
            asignaDatos()
            Controles()
        End If
    End Sub

    Public Sub clicDatos2(indice As Integer)
        If indice <> -1 Then
            nuevoReg2 = False
            ctaD = objDGCuentaD.Item(indice)
            asignaDatos2()
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

    Public Sub habilitarBotones2()
        If nuevoReg2 Then
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
            If chbGeneral.Checked Then
                btnConcepto.Enabled = False
            Else
                btnConcepto.Enabled = True
            End If

            txtMonto.Select()
        Else
            btnNuevo2.Enabled = True
            btnEliminar2.Enabled = True
            btnConcepto.Enabled = False
        End If
    End Sub

    Private Sub frmCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        edoDocs = New EstadoDocumentos

        cta = New Cuenta(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa
        cta.tipoCuenta = tipoCuenta
        cta.cargaGridCom(dgvCuentas, objDGCuenta, "", 0, Now, Now, elemento)

        conceptoCta = New ConceptoCuenta(Ambiente)
        conceptoCta.idEmpresa = Ambiente.empr.idEmpresa
        conceptoCta.tipoCuenta = tipoCuenta

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        lblStatus.Text = ""

        If Ambiente.usuario.desarrollador Then
            btnModificar.Visible = True
        Else
            btnModificar.Visible = False
        End If
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCuentas.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvDetalleCuenta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCuenta.CellDoubleClick
        clicDatos2(e.RowIndex)
        If cta.estado = "BO" Then
            habilitarBotones2()
        End If
        TabControl2.SelectTab(1)
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

    Private Sub BORRADORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BORRADORToolStripMenuItem.Click
        If cta.estado = "BO" Then
            guardar("BO")
        Else
            Mensaje.Mensaje = "No se puede cambiar a estado ""BORRADOR"" cuando ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub guardar(estadoAct As String)
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If estadoAct = "CO" And montoTotal = 0 Then
            Mensaje.Mensaje = "La cuenta no puede ser COMPLETADA cuando el valor de la cuenta es CERO"
            Mensaje.ShowDialog()
            Exit Sub
        End If

        obtenerDatos()
        cta.estado = estadoAct

        If elemento = "Empleado" Then
            cta.idEmpleado = txtIDEmpleadoCocina.Text
        Else
            cta.idCocina = txtIDEmpleadoCocina.Text
        End If

        If nuevoReg Then
            cta.esCuentaManual = True
            cta.sistemaOrigen = "VentanaCuenta"

            If Not cta.guardar() Then
                Mensaje.Mensaje = cta.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la Cuenta"
                nuevoReg = False
                'cta.cargaGridCom(dgvCuentas, objDGCuenta, "", 0, Now, Now, elemento)
                cta.cargaGridCom(dgvCuentas, objDGCuenta, cta.idCuenta, elemento)
                clicBtnNuevo()
                TabControl1.SelectTab(1)
            End If
        Else
            If Not cta.actualizar() Then
                Mensaje.Mensaje = cta.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la Cuenta"
                'cta.cargaGridCom(dgvCuentas, objDGCuenta, "", 0, Now, Now, elemento)
                cta.cargaDatosEmplXLinea(dgvCuentas, dgvCuentas.SelectedRows.Item(0).Index)
                'cta.cargaGridCom(dgvCuentas, objDGCuenta, cta.idCuenta, elemento)
                TabControl1.SelectTab(0)
                clicDatos(dgvCuentas.SelectedRows.Item(0).Index)
                habilitarBotones()
                btnConcepto.Enabled = False
            End If
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub COMPLETARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COMPLETARToolStripMenuItem.Click
        Dim estado As String

        If nuevoReg Then
            estado = "BO"
        Else
            estado = "CO"
        End If

        If cta.estado = "BO" Or cta.estado = "PA" Then
            guardar(estado)
        Else
            Mensaje.Mensaje = "No se puede cambiar el estado, cuando con anterioridad ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la Cuenta: " & cta.noDocumento & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If cta.eliminar() Then
                cta.cargaGridCom(dgvCuentas, objDGCuenta, "", 0, Now, Now, elemento)
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = cta.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Cuenta"
        frmComentario.idTabla = cta.idCuenta
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "Cuenta"
        frmArchivo.idTabla = cta.idCuenta
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cta.cargaGridCom(dgvCuentas, objDGCuenta, "", 0, Now, Now, elemento)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Cuenta"
        frmLogTransaccion.idTabla = cta.idCuenta
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

    Private Sub dgvCuentas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCuentas.SelectionChanged
        If dgvCuentas.SelectedRows.Count > 0 Then
            clicDatos(dgvCuentas.SelectedRows.Item(0).Index)
            habilitarBotones()
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
            TabControl2.SelectTab(0)
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Function guardar2() As Boolean
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg2 Then
            If Not ctaD.guardar() Then
                Mensaje.Mensaje = ctaD.descripError
                Return False
            Else
                ctaD.cargaGridCom(dgvDetalleCuenta, objDGCuentaD)
                montoTotal = 0
                For i As Integer = 0 To objDGCuentaD.Count - 1
                    montoTotal += objDGCuentaD.Item(i).monto
                Next
                cta.monto = montoTotal
                If cta.actualizar() Then
                    Mensaje.Mensaje = "Se guardó correctamente el movimiento"
                    nuevoReg = False
                Else
                    Mensaje.Mensaje = cta.descripError
                    Return False
                End If
                txtMontoTotal.Text = FormatCurrency(montoTotal)
            End If
        Else
            If Not ctaD.actualizar() Then
                Mensaje.Mensaje = ctaD.descripError
                Return False
            Else
                ctaD.cargaGridCom(dgvDetalleCuenta, objDGCuentaD)
                montoTotal = 0
                For i As Integer = 0 To objDGCuentaD.Count - 1
                    montoTotal += objDGCuentaD.Item(i).monto
                Next
                cta.monto = montoTotal
                If cta.actualizar() Then
                    Mensaje.Mensaje = "Se actualizó correctamente el movimiento"
                    nuevoReg = False
                Else
                    Mensaje.Mensaje = cta.descripError
                    Return False
                End If
                txtMontoTotal.Text = FormatCurrency(montoTotal)
            End If
        End If
        Return True
    End Function

    Private Sub btnEliminar2_Click(sender As Object, e As EventArgs) Handles btnEliminar2.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el movimiento seleccionado?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If ctaD.eliminar() Then
                ctaD.cargaGridCom(dgvDetalleCuenta, objDGCuentaD)
                montoTotal = 0
                For i As Integer = 0 To objDGCuentaD.Count - 1
                    montoTotal += objDGCuentaD.Item(i).monto
                Next
                cta.monto = montoTotal
                If cta.actualizar() Then
                    Mensaje.Mensaje = "Se actualizó correctamente el movimiento"
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.ShowDialog()
                Else
                    Mensaje.Mensaje = cta.descripError
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.ShowDialog()
                End If
                txtMontoTotal.Text = FormatCurrency(montoTotal)
            End If
            TabControl2.SelectTab(0)
        End If
    End Sub

    Private Sub dgvDetalleCuenta_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalleCuenta.SelectionChanged
        If dgvDetalleCuenta.SelectedRows.Count > 0 Then
            clicDatos2(dgvDetalleCuenta.SelectedRows.Item(0).Index)
            If cta.estado = "BO" Then
                habilitarBotones2()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        If elemento = "Empleado" Then
            frmBuscaEmpleado.Ambiente = Ambiente
            frmBuscaEmpleado.soloActivos = False
            If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
                txtNombreEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto

                cbSucursal.SelectedIndex = -1
                For i As Integer = 0 To cbSucursal.Items.Count - 1
                    If objCbSuc.Item(i).idSucursal = frmBuscaEmpleado.EmpleadoRetorno.idSucursal Then
                        cbSucursal.SelectedIndex = i
                    End If
                Next
            End If
        Else
            frmBuscarCocina.Ambiente = Ambiente
            If frmBuscarCocina.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoCocina.Text = frmBuscarCocina.CocinaRetorno.idCocina
                txtNombreEmpleadoCocina.Text = frmBuscarCocina.CocinaRetorno.nombreCocina
            End If
        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        frmBuscarCuentas.Ambiente = Ambiente
        frmBuscarCuentas.elementoSistema = elemento
        If frmBuscarCuentas.ShowDialog = DialogResult.OK Then
            cta.cargaGridCom(dgvCuentas, objDGCuenta, frmBuscarCuentas.estado, frmBuscarCuentas.idElemento, frmBuscarCuentas.fechaInicial, frmBuscarCuentas.fechaFinal, elemento)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub Controles()
        If cta.estado = "BO" Then
            dtpFechaMov.Enabled = True
            txtNumDocumento.ReadOnly = False
            cbSucursal.Enabled = True
            txtMonto.ReadOnly = False
            If chbGeneral.Checked Then
                rtbDescripCuenta.ReadOnly = True
                txtDescrip.ReadOnly = True
            Else
                txtDescrip.ReadOnly = False
                rtbDescripCuenta.ReadOnly = False
            End If
            btnEmpleado.Enabled = True

            If nuevoReg Then
                btnNuevo2.Enabled = False
                btnGuardar2.Enabled = False
                btnEliminar2.Enabled = False
            Else
                If cta.estado = "BO" Then
                    btnNuevo2.Enabled = True
                    btnGuardar2.Enabled = True
                    btnEliminar2.Enabled = True
                End If
            End If
        Else
            dtpFechaMov.Enabled = False
            txtNumDocumento.ReadOnly = True
            cbSucursal.Enabled = False
            btnNuevo2.Enabled = False
            btnGuardar2.Enabled = False
            btnEliminar2.Enabled = False
            txtMonto.ReadOnly = True
            txtDescrip.ReadOnly = True
            rtbDescripCuenta.ReadOnly = True
            btnEmpleado.Enabled = False
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

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem1.Click
        cta.RPT_ImprimirDatos()
    End Sub

    Private Sub MoificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        cta.RPT_ModificarDatos()
    End Sub

    Private Sub ImportacionEXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportacionEXCELToolStripMenuItem.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "Cuenta"
        frmImportar.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        rtbDescripCuenta.Text = txtDescripConcepto.Text
        txtDescrip.Text = txtDescripConcepto.Text
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chbGeneral.CheckedChanged
        If chbGeneral.Checked Then
            btnConceptoGeneral.Enabled = True
            rtbDescripCuenta.ReadOnly = True
            txtDescrip.ReadOnly = True
            rtbDescripCuenta.Text = txtDescripConcepGen.Text
            btnConcepto.Enabled = False
        Else
            btnConceptoGeneral.Enabled = False
            rtbDescripCuenta.ReadOnly = False
            txtDescrip.ReadOnly = False
            btnConcepto.Enabled = True
        End If

    End Sub

    Private Sub btnConceptoGeneral_Click(sender As Object, e As EventArgs) Handles btnConceptoGeneral.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = tipoCuenta
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDConcepGen.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConcepGen.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
            rtbDescripCuenta.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub txtNombreEmpleadoCocina_TextChanged(sender As Object, e As EventArgs) Handles txtNombreEmpleadoCocina.TextChanged

    End Sub

    Private Sub txtIDEmpleadoCocina_TextChanged(sender As Object, e As EventArgs) Handles txtIDEmpleadoCocina.TextChanged

    End Sub

End Class