Imports Cerberus

Public Class frmPrestamo
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls

    Private objPrestamo As Prestamo
    Private objDgvPrestamo As New List(Of Prestamo)
    Private objDgvCargoAbono As New List(Of CargoAbonoPrestamo)
    Private objCbSuc As New List(Of Sucursal)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos

        If objPrestamo.estado = "CO" Then
            txtEstado.BackColor = Color.GreenYellow
        Else
            txtEstado.BackColor = Color.Aquamarine
        End If

        txtEstado.Text = objPrestamo.getNombreEstado

        If objPrestamo.idSocioNegocio = Nothing Then
            rbtnEmpleado.Checked = True

            Dim objEmpl As New Empleado(Ambiente)
            objEmpl.idEmpleado = objPrestamo.idEmpleado
            objEmpl.buscarPID()

            txtIDEmpSocio.Text = objEmpl.idEmpleado
            txtNombreEmplSocio.Text = objEmpl.nombreCompleto
        Else
            rbtnSocio.Checked = True

            Dim objSocio As New SocioNegocio(Ambiente)
            objSocio.idSocioNegocio = objPrestamo.idSocioNegocio
            objSocio.buscarPID()

            txtIDEmpSocio.Text = objSocio.idSocioNegocio
            txtNombreEmplSocio.Text = objSocio.nombreSocio
        End If

        txtCantidad.Text = objPrestamo.cantidad
        txtInteresAnual.Text = objPrestamo.interesAnual

        If nuevoReg Then
            dtpFechaInteres.Value = Now
            dtpFechaPrestamo.Value = Now
            dtpUltimoProceso.Value = Now
        Else
            dtpFechaInteres.Value = objPrestamo.fechaInteres
            dtpFechaPrestamo.Value = objPrestamo.fechaPrestamo
            dtpUltimoProceso.Value = objPrestamo.ultimoProceso
        End If

        txtObservaciones.Text = objPrestamo.observaciones
        txtSaldo.Text = FormatCurrency(objPrestamo.saldo)

        cbPeriodoInteres.SelectedIndex = -1
        cbPeriodoInteres.SelectedItem = objPrestamo.periodoInteres
        cbTipoInteres.SelectedIndex = -1
        cbTipoInteres.SelectedItem = objPrestamo.tipoInteres

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To objCbSuc.Count - 1
            If objCbSuc(i).idSucursal = objPrestamo.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        Dim objCargosAbonos As New CargoAbonoPrestamo(Ambiente)
        objCargosAbonos.idPrestamo = objPrestamo.idPrestamo
        objCargosAbonos.cargaGrid(dgvPagoCobro, objDgvCargoAbono)

    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos

        If rbtnEmpleado.Checked Then
            objPrestamo.idEmpleado = txtIDEmpSocio.Text
            objPrestamo.idSocioNegocio = Nothing
        ElseIf rbtnSocio.Checked Then
            objPrestamo.idSocioNegocio = txtIDEmpSocio.Text
            objPrestamo.idEmpleado = Nothing
        End If

        objPrestamo.cantidad = txtCantidad.Text
        objPrestamo.interesAnual = txtInteresAnual.Text
        objPrestamo.fechaInteres = dtpFechaInteres.Value
        objPrestamo.fechaPrestamo = dtpFechaPrestamo.Value
        objPrestamo.observaciones = txtObservaciones.Text
        objPrestamo.periodoInteres = cbPeriodoInteres.SelectedItem
        objPrestamo.tipoInteres = cbTipoInteres.SelectedItem
        objPrestamo.idSucursal = objCbSuc(cbSucursal.SelectedIndex).idSucursal

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            objPrestamo = objDgvPrestamo.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim habilitado As Boolean
        Dim soloLectura As Boolean

        If objPrestamo.estado = "CO" Or objPrestamo.estado = "CA" Or objPrestamo.estado = "PA" Then
            habilitado = False
            soloLectura = True

            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnDetalle.Enabled = True
        Else
            habilitado = True
            soloLectura = False

            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnDetalle.Enabled = False
        End If

        cbSucursal.Enabled = habilitado
        btnGuardar.Enabled = habilitado
        rbtnEmpleado.Enabled = habilitado
        rbtnSocio.Enabled = habilitado
        btnSocioEmpl.Enabled = habilitado
        txtCantidad.ReadOnly = soloLectura
        dtpFechaInteres.Enabled = habilitado
        dtpFechaPrestamo.Enabled = habilitado
        txtInteresAnual.Enabled = habilitado
        cbTipoInteres.Enabled = habilitado
        cbPeriodoInteres.Enabled = habilitado
        txtObservaciones.ReadOnly = soloLectura
    End Sub

    Private Sub frmPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objSuc As New Sucursal(Ambiente)
        objSuc.idEmpresa = Ambiente.empr.idEmpresa
        objSuc.getComboActivo(cbSucursal, objCbSuc)

        objPrestamo = New Prestamo(Ambiente)
        objPrestamo.idEmpresa = Ambiente.empr.idEmpresa
        objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)

        If Ambiente.usuario.desarrollador Then
            btnModRepPrestamo.Visible = True
        Else
            btnModRepPrestamo.Visible = False
        End If
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        If objPrestamo.idPrestamo <> Nothing Then
            frmArchivo.tabla = "Prestamo"
            frmArchivo.idTabla = objPrestamo.idPrestamo
            frmArchivo.Ambiente = Ambiente
            frmArchivo.elementoSistema = "Varios"
            frmArchivo.tipoArchivo = "Adjunto"
            frmArchivo.ShowDialog()
        End If
    End Sub

    Private Sub btnSocioEmpl_Click(sender As Object, e As EventArgs) Handles btnSocioEmpl.Click
        If rbtnEmpleado.Checked Then
            frmBuscaEmpleado.Ambiente = Ambiente
            frmBuscaEmpleado.soloActivos = True
            If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
                txtIDEmpSocio.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
                txtNombreEmplSocio.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
            End If
        ElseIf rbtnSocio.Checked Then
            frmBuscaSocio.Ambiente = Ambiente
            frmBuscaSocio.todos = True
            frmBuscaSocio.soloActivos = True
            frmBuscaSocio.soloClientes = False
            frmBuscaSocio.soloProveedores = False

            If frmBuscaSocio.ShowDialog() = DialogResult.OK Then
                txtIDEmpSocio.Text = frmBuscaSocio.socioRetorno.idSocioNegocio
                txtNombreEmplSocio.Text = frmBuscaSocio.socioRetorno.nombreSocio
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        If objPrestamo.idPrestamo <> Nothing Then
            frmComentario.tabla = "Prestamo"
            frmComentario.idTabla = objPrestamo.idPrestamo
            frmComentario.Ambiente = Ambiente
            frmComentario.ShowDialog()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        objPrestamo = New Prestamo(Ambiente)
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        frmNuevoEstado.setEstadoBD("CO")
        frmNuevoEstado.cbEstado.Enabled = False

        If frmNuevoEstado.ShowDialog() = DialogResult.OK Then

            objPrestamo.estado = frmNuevoEstado.getEstadoDB

            Dim operacion As Boolean = True
            obtenerDatos()
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If nuevoReg Then
                If Not objPrestamo.guardar() Then
                    Mensaje.Mensaje = objPrestamo.descripError
                Else
                    Mensaje.Mensaje = "Se guardó correctamente el Prestamo"
                    nuevoReg = False
                    operacion = False
                End If
            Else
                If Not objPrestamo.actualizar() Then
                    Mensaje.Mensaje = objPrestamo.descripError
                Else
                    Mensaje.Mensaje = "Se actualizó correctamente el Prestamo"
                    operacion = False
                End If
            End If

            Mensaje.ShowDialog()
            If Not operacion Then
                objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)
                TabControl1.SelectTab(0)
            End If
        End If
        frmNuevoEstado.cbEstado.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas CANCELAR el Prestamo: " & objPrestamo.idPrestamo & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            objPrestamo.eliminar()
            objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Prestamo"
        frmLogTransaccion.idTabla = objPrestamo.idPrestamo
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvPrestamo.SelectedRows.Item(0).Index <> 0 Then
            dgvPrestamo.Rows(dgvPrestamo.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvPrestamo.SelectedRows.Item(0).Index <> dgvPrestamo.Rows.Count - 1 Then
            dgvPrestamo.Rows(dgvPrestamo.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub dgvPrestamo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrestamo.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvPrestamo_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPrestamo.SelectionChanged
        If dgvPrestamo.SelectedRows.Count > 0 Then
            clicDatos(dgvPrestamo.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub rbtnSocio_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSocio.CheckedChanged
        txtIDEmpSocio.Text = ""
        txtNombreEmplSocio.Text = ""
    End Sub

    Private Sub rbtnEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEmpleado.CheckedChanged
        txtIDEmpSocio.Text = ""
        txtNombreEmplSocio.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmCargoAbonoPrestamo.Ambiente = Ambiente
        frmCargoAbonoPrestamo.idPrestamo = objPrestamo.idPrestamo
        frmCargoAbonoPrestamo.idCargoAbono = Nothing
        frmCargoAbonoPrestamo.ShowDialog()
        frmCargoAbonoPrestamo.Activate()

        objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub dgvPagoCobro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPagoCobro.CellDoubleClick
        frmCargoAbonoPrestamo.Ambiente = Ambiente
        frmCargoAbonoPrestamo.idPrestamo = objPrestamo.idPrestamo
        frmCargoAbonoPrestamo.idCargoAbono = objDgvCargoAbono(e.RowIndex).idCargoAbonoPrestamo
        frmCargoAbonoPrestamo.ShowDialog()
        frmCargoAbonoPrestamo.Activate()
    End Sub

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnImpRepPrestamo.Click
        objPrestamo.imprimeRecibo()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnModRepPrestamo.Click
        objPrestamo.modificaRecibo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If objPrestamo.calculaIntereses() Then
            objPrestamo.cargaGrid(dgvPrestamo, objDgvPrestamo)
            TabControl1.SelectTab(0)
            Mensaje.Mensaje = "Proceso Concluido..."
        Else
            Mensaje.Mensaje = "Ocurrio un error: " & objPrestamo.descripError
        End If

        Mensaje.ShowDialog()
    End Sub
End Class