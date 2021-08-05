Imports Cerberus

Public Class frmTabulador
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls

    Private tab As Tabulador
    Private tabVer As TabuladorVersion

    Private objDgvTabVer As New List(Of TabuladorVersion)
    Private objDgvTab As New List(Of Tabulador)
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private busqueda As String = ""
    Private nuevoReg As Boolean
    Private nuevoReg2 As Boolean

    Private objNivelPuesto As NivelPuesto
    Private listNivelPuesto As New List(Of NivelPuesto)


    Private Sub frmTabulador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tab = New Tabulador(Ambiente)
        tab.idEmpresa = Ambiente.empr.idEmpresa

        tabVer = New TabuladorVersion(Ambiente)

        tab.cargaGridCom(dgvTabulador, objDgvTab, busqueda)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        objNivelPuesto = New NivelPuesto(Ambiente)
        objNivelPuesto.getComboNivelPuesto(cbNivelPuesto, listNivelPuesto)

        lblStatus.Text = ""
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        frmBuscar.Text = "..:: Buscar Tabulador ::.."
        frmBuscar.valorBuscado = ""
        If frmBuscar.ShowDialog = DialogResult.OK Then
            busqueda = frmBuscar.valorBuscado
            tab.cargaGridCom(dgvTabulador, objDgvTab, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        nuevoReg2 = True
        asignaDatos()
        habilitarBotones()
        recargaGridVersion()
        asignaDatos2()
        btnNuevo2.Enabled = False
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Dim operacion As Boolean = False
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not tab.guardar() Then
                Mensaje.Mensaje = tab.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el tabulador"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not tab.actualizar() Then
                Mensaje.Mensaje = tab.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el tabulador"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            tab.cargaGridCom(dgvTabulador, objDgvTab, busqueda)
            habilitarBotones()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el tabulador: " & tab.nombreTabulador & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            tab.eliminar()
            tab.cargaGridCom(dgvTabulador, objDgvTab, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Tabulador"
        frmComentario.idTabla = tab.idTabulador
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        tab.cargaGridCom(dgvTabulador, objDgvTab, busqueda)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Tabulador"
        frmLogTransaccion.idTabla = tab.idTabulador
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvTabulador.SelectedRows.Item(0).Index <> 0 Then
            dgvTabulador.Rows(dgvTabulador.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvTabulador.SelectedRows.Item(0).Index <> dgvTabulador.Rows.Count - 1 Then
            dgvTabulador.Rows(dgvTabulador.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnNuevo2_Click(sender As Object, e As EventArgs) Handles btnNuevo2.Click
        nuevoReg2 = True
        asignaDatos2()
        habilitarBotones2()
        TabControl2.SelectTab(1)
    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        Dim operacion As Boolean = True
        obtenerDatos2()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg2 Then
            If Not tabVer.guardar() Then
                Mensaje.Mensaje = tabVer.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la versión"
                nuevoReg2 = False
                operacion = False
            End If
        Else
            If Not tabVer.actualizar() Then
                Mensaje.Mensaje = tab.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la versión"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            tabVer.cargaGridCom(dgvDetalleCuenta, objDgvTabVer, busqueda)
            habilitarBotones2()
            TabControl2.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar2_Click(sender As Object, e As EventArgs)
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la version: " & tabVer.version & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            tabVer.eliminar()
            tabVer.cargaGridCom(dgvDetalleCuenta, objDgvTabVer, busqueda)
            TabControl2.SelectTab(0)
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTabulador.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        recargaGridVersion()
        btnNuevo2.Enabled = True
        TabControl1.SelectTab(1)
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTabulador.SelectionChanged
        If dgvTabulador.SelectedRows.Count > 0 Then
            clicDatos(dgvTabulador.SelectedRows.Item(0).Index)
            habilitarBotones()
            recargaGridVersion()
            btnNuevo2.Enabled = True
        End If
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            tab = New Tabulador(Ambiente)
            tab.idEmpresa = Ambiente.empr.idEmpresa
            cbNivelPuesto.SelectedIndex = -1
        End If

        txtNombre.Text = tab.nombreTabulador
        esActivo.Checked = tab.esActivo

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = tab.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = tab.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        cbNivelPuesto.SelectedIndex = -1
        For i As Integer = 0 To cbNivelPuesto.Items.Count - 1
            If listNivelPuesto.Item(i).idNivelPuesto = tab.idNivelPuesto Then
                cbNivelPuesto.SelectedIndex = i
                Exit For
            End If
        Next

        lblStatus.Text = tab.getDetalleMod()
    End Sub

    Public Sub asignaDatos2()
        If nuevoReg2 Then
            tabVer = New TabuladorVersion(Ambiente)
        End If

        dtpValidoDesde.Value = If(tabVer.validoDesde = Nothing, Now, tabVer.validoDesde)
        txtVersion.Text = tabVer.version
        txtCostoHoraExtra.Text = tabVer.sueldo
        txtSeptimoDia.Text = tabVer.septimoDia
        txtCostoHora.Text = tabVer.costoXhora
        txtCostoHoraExtra.Text = tabVer.costoXhoraExtra
        txtSueldo.Text = tabVer.sueldo

        lblStatus.Text += " - " & tabVer.getDetalleMod()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        tab.nombreTabulador = txtNombre.Text
        tab.esActivo = esActivo.Checked

        If cbSucursal.SelectedIndex <> -1 Then
            tab.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            tab.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            tab.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            tab.idEmpresa = Nothing
        End If

        If cbNivelPuesto.SelectedIndex <> -1 Then
            tab.idNivelPuesto = listNivelPuesto.Item(cbNivelPuesto.SelectedIndex).idNivelPuesto
        Else
            tab.idNivelPuesto = Nothing
        End If
    End Sub

    Public Sub obtenerDatos2()
        tabVer.idTabulador = tab.idTabulador
        tabVer.version = txtVersion.Text
        tabVer.sueldo = txtSueldo.Text
        tabVer.septimoDia = txtSeptimoDia.Text
        tabVer.costoXhora = txtCostoHora.Text
        tabVer.costoXhoraExtra = txtCostoHoraExtra.Text
        tabVer.validoDesde = dtpValidoDesde.Value
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            tab = objDgvTab.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub clicDatos2(indice As Integer)
        If indice <> -1 Then
            nuevoReg2 = False
            tabVer = objDgvTabVer.Item(indice)
            asignaDatos2()
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

            txtNombre.Select()
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
        If Not nuevoReg2 Then
            btnNuevo2.Enabled = True
            btnGuardar2.Enabled = False
            txtSueldo.ReadOnly = True
            txtCostoHoraExtra.ReadOnly = True
            dtpValidoDesde.Enabled = False
        Else
            btnNuevo2.Enabled = False
            btnGuardar2.Enabled = True
            txtSueldo.ReadOnly = False
            txtCostoHoraExtra.ReadOnly = False
            dtpValidoDesde.Enabled = True
        End If
    End Sub

    Private Sub dgvDetalleCuenta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCuenta.CellDoubleClick
        clicDatos2(e.RowIndex)
        habilitarBotones2()
        TabControl2.SelectTab(1)
    End Sub

    Private Sub dgvDetalleCuenta_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalleCuenta.SelectionChanged
        If dgvDetalleCuenta.SelectedRows.Count > 0 Then
            clicDatos2(dgvDetalleCuenta.SelectedRows.Item(0).Index)
            habilitarBotones2()
        End If
    End Sub

    Private Sub txtSueldo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSueldo.KeyUp
        If Not IsNumeric(txtSueldo.Text) Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Para hacer el cálculo del sueldo, es necesario que sea ingresado"
            Mensaje.ShowDialog()
        Else
            If Not txtSueldo.ReadOnly Then
                If txtSueldo.Text > 0 Then
                    txtCostoHora.Text = Format(Decimal.Parse(txtSueldo.Text) / 48, "0.00")
                    txtSeptimoDia.Text = Format(Decimal.Parse(txtSueldo.Text) / 7, "0.00")
                Else
                    txtCostoHora.Text = 0.00
                    txtSeptimoDia.Text = 0.00
                End If
            End If
        End If
    End Sub

    Private Sub recargaGridVersion()
        tabVer.idTabulador = tab.idTabulador
        tabVer.cargaGridCom(dgvDetalleCuenta, objDgvTabVer, busqueda)
    End Sub
End Class