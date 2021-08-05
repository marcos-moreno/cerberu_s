Public Class frmDispositivo
    Private eve As Evento
    Private disp As Dispositivo
    Private ubi As UbicacionFisica
    Private coci As Cocina
    Public Ambiente As AmbienteCls
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private objDgvDisp As New List(Of Dispositivo)
    Private objCbUbi As New List(Of UbicacionFisica)
    Private objCbCocina As New List(Of Cocina)
    Private nuevoReg As Boolean

    Private Sub frmDispositivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disp = New Dispositivo(Ambiente)
        disp.idEmpresa = Ambiente.empr.idEmpresa

        eve = New Evento(Ambiente)
        eve.idEmpresa = Ambiente.empr.idEmpresa

        coci = New Cocina(Ambiente)
        coci.idEmpresa = Ambiente.empr.idEmpresa
        coci.getComboActivo(cbCocina, objCbCocina)

        ubi = New UbicacionFisica(Ambiente)
        ubi.idEmpresa = Ambiente.empr.idEmpresa
        ubi.getComboActivo(cbUbicacion, objCbUbi)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)
        disp.cargaGridCom(DataGridView1, objDgvDisp, cbActivo.Checked)

        lblStatus.Text = ""
    End Sub

    Private Sub asignaDatos()
        If nuevoReg Then
            disp = New Dispositivo(Ambiente)
            disp.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = disp.nombreDispositivo
        esActivo.Checked = disp.esActivo
        esGeneral.Checked = disp.esGeneral
        txtDireccion.Text = disp.direccionIP
        txtIdZk.Text = disp.idZk
        txtPuerto.Text = disp.puertoDispositivo
        txtNoSerie.Text = disp.serieDispositivo
        txtModelo.Text = disp.modeloDispositivo
        txtFirmwareV.Text = disp.firmwareVersion
        esSincronizacionAut.Checked = disp.esSincronizacionAut
        chbEliminarRegs.Checked = disp.eliminarRegs
        txtActivacion.Text = disp.activacion

        lblStatus.Text = disp.getDetalleMod()
        lblDispositivoSeleccion.Text = "DISPOSITIVO SELECCIONADO: " + disp.nombreDispositivo

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = disp.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = disp.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        cbUbicacion.SelectedIndex = -1
        For i As Integer = 0 To cbUbicacion.Items.Count - 1
            If objCbUbi.Item(i).idUbicacionFisica = disp.idUbicacionFisica Then
                cbUbicacion.SelectedIndex = i
                Exit For
            End If
        Next

        cbCocina.SelectedIndex = -1
        For i As Integer = 0 To cbCocina.Items.Count - 1
            If objCbCocina.Item(i).idCocina = disp.idCocina Then
                cbCocina.SelectedIndex = i
                Exit For
            End If
        Next

        If disp.tipoDispositivo = "ES" Then
            cbTipoDisp.SelectedIndex = 0
        ElseIf disp.tipoDispositivo = "CO" Then
            cbTipoDisp.SelectedIndex = 1
        Else
            cbTipoDisp.SelectedIndex = -1
        End If

    End Sub

    Private Sub obtenerDatos()
        disp.nombreDispositivo = txtNombre.Text
        disp.esActivo = esActivo.Checked
        disp.direccionIP = txtDireccion.Text
        disp.puertoDispositivo = txtPuerto.Text
        'disp.serieDispositivo = txtNoSerie.Text
        'disp.modeloDispositivo = txtModelo.Text
        'disp.firmwareVersion = txtFirmwareV.Text
        'disp.idZk = txtIdZk.Text
        disp.esSincronizacionAut = esSincronizacionAut.Checked
        disp.eliminarRegs = chbEliminarRegs.Checked
        disp.activacion = txtActivacion.Text

        disp.esGeneral = esGeneral.Checked

        If cbCocina.SelectedIndex <> -1 Then
            disp.idCocina = objCbCocina.Item(cbCocina.SelectedIndex).idCocina
        Else
            disp.idCocina = Nothing
        End If

        If cbSucursal.SelectedIndex <> -1 Then
            disp.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            disp.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            disp.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            disp.idEmpresa = Nothing
        End If

        If cbUbicacion.SelectedIndex <> -1 Then
            disp.idUbicacionFisica = objCbUbi.Item(cbUbicacion.SelectedIndex).idUbicacionFisica
        Else
            disp.idUbicacionFisica = Nothing
        End If

        If cbTipoDisp.SelectedIndex = -1 Then
            disp.tipoDispositivo = Nothing
        ElseIf cbTipoDisp.SelectedIndex = 1 Then
            disp.tipoDispositivo = "CO"
        ElseIf cbTipoDisp.SelectedIndex = 0 Then
            disp.tipoDispositivo = "ES"
        End If
    End Sub

    Private Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            disp = objDgvDisp.Item(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub habilitarBotones()
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Dim operacion As Boolean = False
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not disp.guardar() Then
                Mensaje.Mensaje = disp.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el dispositivo"
                nuevoReg = False
                operacion = True
            End If
        Else
            If Not disp.actualizar() Then
                Mensaje.Mensaje = disp.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el dispositivo"
                operacion = True
            End If
        End If
        Mensaje.ShowDialog()
        If operacion Then
            disp.cargaGridCom(DataGridView1, objDgvDisp, cbActivo.Checked)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el dispositivo: " & disp.nombreDispositivo & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            disp.eliminar()
            disp.cargaGridCom(DataGridView1, objDgvDisp, cbActivo.Checked)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Dispositivo"
        frmComentario.idTabla = disp.idDispositivo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "Dispositivo"
        frmArchivo.idTabla = disp.idDispositivo
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        disp.cargaGridCom(DataGridView1, objDgvDisp, cbActivo.Checked)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Dispositivo"
        frmLogTransaccion.idTabla = disp.idDispositivo
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub btnExtraccionAsistencias_Click(sender As Object, e As EventArgs) Handles btnExtraccionAsistencias.Click
        asignarValoresEventos(TipoEvento.ExtraerRegistros, False, False, False, True)
    End Sub

    Private Sub btnRegistroEmpleado_Click(sender As Object, e As EventArgs) Handles btnRegistroEmpleado.Click
        asignarValoresEventos(TipoEvento.RegistrarEmpleado, True, False, False, True)
    End Sub

    Private Sub btnExtraccionDatosBiom_Click(sender As Object, e As EventArgs) Handles btnExtraccionDatosBiom.Click
        asignarValoresEventos(TipoEvento.ExtraerInformacionBiometrica, True, False, False, True)
    End Sub

    Private Sub btnAsignacionFechaHora_Click(sender As Object, e As EventArgs) Handles btnAsignacionFechaHora.Click
        asignarValoresEventos(TipoEvento.FijarFecha, False, False, False, True)
    End Sub

    Private Sub btnExtraccionInfoDisp_Click(sender As Object, e As EventArgs) Handles btnExtraccionInfoDisp.Click
        asignarValoresEventos(TipoEvento.ExtraerInformacionReloj, False, False, False, True)
    End Sub

    Private Sub btnEliminarEmpleado_Click(sender As Object, e As EventArgs) Handles btnEliminarEmpleado.Click
        asignarValoresEventos(TipoEvento.BorrarEmpleado, True, False, False, False)
    End Sub

    Private Sub btnResetearDispositivo_Click(sender As Object, e As EventArgs) Handles btnResetearDispositivo.Click
        asignarValoresEventos(TipoEvento.EliminarTodo, False, False, False, True)
    End Sub

    Private Sub asignarValoresEventos(tipoEvento As Integer, requiereEmpleado As Boolean, esXDep As Boolean, xCocina As Boolean, soloActivos As Boolean)
        If Not requiereEmpleado Then
            eve.idSucursal = disp.idSucursal
            eve.idTipoEvento = tipoEvento
            eve.idDispositivo = disp.idDispositivo
            eve.esActivo = True

            almacenarEvento(False, False)
        Else
            asignarEmpleadoEvento(esXDep, xCocina, tipoEvento, soloActivos)
        End If
    End Sub

    Private Sub asignarEmpleadoEvento(esXDep As Boolean, xCocina As Boolean, tipoEvento As Integer, soloActivos As Boolean)
        If esXDep Then
            Dim objEmpl As Empleado
            Dim objsEmpl As New List(Of Empleado)
            frmBuscaDepartamento.Ambiente = Ambiente
            If frmBuscaDepartamento.ShowDialog() = DialogResult.OK Then
                objEmpl = New Empleado(Ambiente)
                objEmpl.idDepartamento = frmBuscaDepartamento.EmpleadoRetorno.idDepartamento
                objEmpl.idEmpresa = Ambiente.empr.idEmpresa
                objEmpl.cargarGridXDepOID(DataGridView2, objEmpl.idDepartamento, Nothing, objsEmpl, soloActivos, Now())

                For i As Integer = 0 To objsEmpl.Count - 1
                    eve.idSucursal = disp.idSucursal
                    eve.idTipoEvento = tipoEvento
                    eve.idDispositivo = disp.idDispositivo
                    eve.esActivo = True
                    eve.idEmpleado = objsEmpl(i).idEmpleado
                    almacenarEvento(True, True)
                Next

                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "¡Proceso concluido, favor de verificar los eventos...!"
                Mensaje.ShowDialog()


            End If
        ElseIf xCocina Then
            Dim objEmpl As Empleado
            Dim objsEmpl As New List(Of Empleado)
            frmBuscarCocina.Ambiente = Ambiente
            If frmBuscarCocina.ShowDialog() = DialogResult.OK Then
                objEmpl = New Empleado(Ambiente)
                objEmpl.idCocina = frmBuscarCocina.CocinaRetorno.idCocina
                objEmpl.idEmpresa = Ambiente.empr.idEmpresa
                objEmpl.cargarGridXCocinaAsignada(DataGridView2, objEmpl.idCocina, objsEmpl)

                For i As Integer = 0 To objsEmpl.Count - 1
                    eve.idSucursal = disp.idSucursal
                    eve.idTipoEvento = tipoEvento
                    eve.idDispositivo = disp.idDispositivo
                    eve.esActivo = True

                    eve.idEmpleado = objsEmpl(i).idEmpleado
                    almacenarEvento(True, True)
                Next

                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "¡Proceso concluido, favor de verificar los eventos...!"
                Mensaje.ShowDialog()

            End If
        Else
            frmBuscaEmpleado.Ambiente = Ambiente
            frmBuscaEmpleado.soloActivos = soloActivos
            If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
                eve.idSucursal = disp.idSucursal
                eve.idTipoEvento = tipoEvento
                eve.idDispositivo = disp.idDispositivo
                eve.esActivo = True

                eve.idEmpleado = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
                almacenarEvento(True, False)
            End If
        End If

    End Sub


    Private Sub almacenarEvento(requiereEmpleado As Boolean, silencioso As Boolean)
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If eve.esActivoBD(requiereEmpleado) Then
            Mensaje.Mensaje = "¡Ya existe un evento activo!"
        Else
            If eve.guardar() Then
                'eve = New Evento(Ambiente)
                'eve.idEmpresa = Ambiente.empr.idEmpresa
                Mensaje.Mensaje = "Se guardó correctamente el evento seleccionado"
            Else
                Mensaje.Mensaje = eve.descripError
            End If
        End If

        If Not silencioso Then
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        asignarValoresEventos(TipoEvento.RegistrarEmpleado, True, True, False, True)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        asignarValoresEventos(TipoEvento.RegistrarEmpleado, True, False, True, True)
    End Sub

    Private Sub btnExtraerXPeriodo_Click(sender As Object, e As EventArgs) Handles btnExtraerXPeriodo.Click
        frmRangoFechas.dtpFechaInicial.Format = DateTimePickerFormat.Custom
        frmRangoFechas.dtpFechaInicial.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        frmRangoFechas.dtpFechaInicial.Value = Format(Now, "dd-MM-yyyy 00:00:00")

        frmRangoFechas.dtpFechaFinal.Format = DateTimePickerFormat.Custom
        frmRangoFechas.dtpFechaFinal.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        frmRangoFechas.dtpFechaFinal.Value = Now

        If frmRangoFechas.ShowDialog() = DialogResult.OK Then
            eve.fechaInicial = frmRangoFechas.dtpFechaInicial.Value
            eve.fechaFinal = frmRangoFechas.dtpFechaFinal.Value
            asignarValoresEventos(TipoEvento.ExtraerRegistros, False, False, False, True)
        Else
            MsgBox("Acción cancelada...")
        End If
    End Sub

    Private Sub cbTipoDisp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoDisp.SelectedIndexChanged
        cbCocina.SelectedIndex = -1

        If cbTipoDisp.SelectedItem = "Entrada/Salida" Then
            cbCocina.Enabled = False
        Else
            cbCocina.Enabled = True
        End If
    End Sub

    Private Sub cbActivo_CheckedChanged(sender As Object, e As EventArgs) Handles cbActivo.CheckedChanged
        Try
            disp.cargaGridCom(DataGridView1, objDgvDisp, cbActivo.Checked)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnEliminarEmpleadoDepartamento_Click(sender As Object, e As EventArgs) Handles btnEliminarEmpleadoDepartamento.Click
        asignarValoresEventos(TipoEvento.BorrarEmpleado, True, True, False, True)

    End Sub
End Class