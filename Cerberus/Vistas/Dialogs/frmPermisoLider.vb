Public Class frmPermisoLider
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls
    Public empleado As Empleado
    'Private nuevoReg As Boolean
    Private tInci As TipoIncidencia
    Private ListTipoIncidencia As New List(Of TipoIncidencia)
    Private ListSolicituPermiso As New List(Of SolicitudPermiso)
    Private objSolicituPermiso As SolicitudPermiso
    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tInci = New TipoIncidencia(Ambiente)
        tInci.idEmpresa = Ambiente.empr.idEmpresa
        tInci.calculada = False
        'tInci.getComboActivoTablaRegistro(cbTipoIncidencia, ListTipoIncidencia, " AND idTipoIncidencia IN (16,5,6,1,12)")
        tInci.getComboActivoTablaRegistro(cbTipoIncidencia, ListTipoIncidencia, " ")

        'objSolicituPermiso = New SolicitudPermiso(Ambiente)
        'objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
        'objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
        TabControl1.SelectTab(0)
        pendientes.Checked = True
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        'If nuevoReg Then
        'Else
        empleado = New Empleado(Ambiente)
        empleado.idEmpleado = objSolicituPermiso.idEmpleado
        empleado.buscarPID()

        txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado
        For i As Integer = 0 To ListTipoIncidencia.Count - 1
            If ListTipoIncidencia.Item(i).idTipoIncidencia = objSolicituPermiso.idTipoIncidencia Then
                cbTipoIncidencia.SelectedIndex = i
            End If
        Next
        txtIDSolicitudPermiso.Text = objSolicituPermiso.idSolicitudPermiso
        dtpFechaPermiso.Value = objSolicituPermiso.fechaPermiso
        txtMotivo.Text = objSolicituPermiso.motivo
        Select Case objSolicituPermiso.estado
            Case "RE"
                txtEstado.Text = "RECHAZADO"
            Case "AU"
                txtEstado.Text = "AUTORIZADO"
            Case "PA"
                txtEstado.Text = "PENDIENTE DE AUTORIZAR"
        End Select
        txtComentarioLider.Text = objSolicituPermiso.respuesta
        If ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia = True Then
            horaInicio.Visible = False
            horaFin.Visible = False
        Else
            horaInicio.Visible = True
            horaFin.Visible = True
        End If
        horaInicio.Value = Convert.ToDateTime(objSolicituPermiso.horaI.ToString)
        horaFin.Value = Convert.ToDateTime(objSolicituPermiso.horaF.ToString)
        'End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objSolicituPermiso.idLider = Ambiente.usuario.idEmpleado
        objSolicituPermiso.respuesta = txtComentarioLider.Text
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            'nuevoReg = False
            Try
                objSolicituPermiso = ListSolicituPermiso.Item(indice)
                asignaDatos()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
    End Sub
    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        'ObjVentana.cargarGridGen(dtgrid, listRenovacion)
        objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
        resetView()
        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        If dtgrid.SelectedRows.Item(0).Index <> dtgrid.Rows.Count - 1 Then
            dtgrid.Rows(dtgrid.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs)
        If dtgrid.SelectedRows.Item(0).Index <> 0 Then
            dtgrid.Rows(dtgrid.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub dtgrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrid.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub


    Private Sub AutorizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizarToolStripMenuItem.Click
        obtenerDatos()
        If objSolicituPermiso.estado = "AU" Then
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "El permiso ya esta Autorizado."
            Mensaje.ShowDialog()

            Return
        End If

        If (DateTime.Compare(Now.ToShortDateString(), objSolicituPermiso.fechaPermiso.ToShortDateString()) < 0) Then
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "El permiso debé ser en una fecha mayor."
            Mensaje.ShowDialog()
            Return
        End If

        Dim colaborador = New Empleado(Ambiente)
        colaborador.idEmpleado = objSolicituPermiso.idEmpleado
        colaborador.buscarPID()

        Dim lider = New Empleado(Ambiente)
        lider.idEmpleado = objSolicituPermiso.idLider
        lider.buscarPID()

        Dim incidencia As New Incidencia(Ambiente)
        incidencia.idEmpleado = colaborador.idEmpleado
        incidencia.idHorario = colaborador.idHorario
        incidencia.idSucursal = colaborador.idSucursal
        incidencia.idTipoIncidencia = objSolicituPermiso.idTipoIncidencia
        incidencia.fecha = objSolicituPermiso.fechaPermiso
        incidencia.nombreLider = lider.nombreEmpleado & " " & lider.apPatEmpleado & " " & lider.apMatEmpleado
        incidencia.esActivo = True
        incidencia.idEmpresa = colaborador.idEmpresa
        incidencia.idDepartamento = colaborador.idDepartamento

        Dim tipoincidencia = New TipoIncidencia(Ambiente)
        tipoincidencia.idTipoIncidencia = incidencia.idTipoIncidencia
        tipoincidencia.buscarPID()
        incidencia.incidenciaXDia = tipoincidencia.incidenciaXDia

        'If Not objSolicituPermiso.crearPermiso(objSolicituPermiso.respuesta) Then
        '    Mensaje.Mensaje = objSolicituPermiso.descripError
        'Else
        '    Mensaje.Mensaje = "Se Autorizó correctamente..."
        'End If

        If incidencia.guardar() Then
            objSolicituPermiso.estado = "AU"
            objSolicituPermiso.idIncidencia = incidencia.idIncidencia
            If objSolicituPermiso.actualizar(True) Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se autorizó Correctamente."
                Mensaje.ShowDialog()
                objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
                resetView()
                objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
                TabControl1.SelectTab(0)
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.origen = "objSolicituPermiso.guardar"
                Mensaje.Mensaje = objSolicituPermiso.descripError
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "incidencia.guardar"
            Mensaje.Mensaje = incidencia.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub resetView()
        cbTipoIncidencia.SelectedIndex = 0
        txtIDSolicitudPermiso.Text = 0
        txtNOmbreEmpleado.Text = ""
        dtpFechaPermiso.Value = Now
        txtMotivo.Text = ""
        txtEstado.Text = ""
        txtComentarioLider.Text = ""
        horaInicio.Visible = False
        horaFin.Visible = False
    End Sub

    Private Sub RechazarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechazarToolStripMenuItem.Click
        obtenerDatos()

        If objSolicituPermiso.fechaPermiso >= Now.ToShortDateString() Then
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "No es posible RECHAZAR permisos de fechas pasadas."
            Mensaje.ShowDialog()
            Return
        End If

        If objSolicituPermiso.estado = "RE" Then
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "El permiso ya fué Rechazado."
            Mensaje.ShowDialog()
            Return
        End If

        If objSolicituPermiso.estado = "AU" Then
            If Len(objSolicituPermiso.respuesta) > 9 Then
                Dim incidencia As New Incidencia(Ambiente)
                incidencia.idIncidencia = objSolicituPermiso.idIncidencia
                If Not incidencia.eliminar() Then
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = incidencia.descripError
                    Mensaje.ShowDialog()
                Else
                    objSolicituPermiso.estado = "RE"
                    objSolicituPermiso.idIncidencia = Nothing
                    If Not objSolicituPermiso.actualizar(True) Then
                        Mensaje.tipoMsj = TipoMensaje.Error
                        Mensaje.Mensaje = objSolicituPermiso.descripError
                        Mensaje.ShowDialog()
                    Else
                        Mensaje.tipoMsj = TipoMensaje.Informacion
                        Mensaje.Mensaje = "Se rechazó correctamente el permiso..."
                        Mensaje.ShowDialog()
                        objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
                        resetView()
                        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
                        TabControl1.SelectTab(0)
                    End If
                End If
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Debes ingresar un Comentario, mínimo 10 caracteres."
                Mensaje.ShowDialog()
                Return
            End If

        ElseIf objSolicituPermiso.estado = "PA" Then
            If Len(objSolicituPermiso.respuesta) > 9 Then
                objSolicituPermiso.estado = "RE"
                objSolicituPermiso.idIncidencia = Nothing
                If Not objSolicituPermiso.actualizar(True) Then
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = objSolicituPermiso.descripError
                    Mensaje.ShowDialog()
                Else
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.Mensaje = "Se rechazó correctamente el permiso..."
                    Mensaje.ShowDialog()
                    objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
                    resetView()
                    objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
                    TabControl1.SelectTab(0)
                End If
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Debes ingresar un Comentario, mínimo 10 caracteres."
                Mensaje.ShowDialog()
                Return
            End If
        End If

    End Sub

    Private Sub pendientes_CheckedChanged(sender As Object, e As EventArgs) Handles pendientes.CheckedChanged
        objSolicituPermiso = New SolicitudPermiso(Ambiente)
        objSolicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
        resetView()
        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, True, pendientes.Checked)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub dtgrid_SelectionChanged(sender As Object, e As EventArgs) Handles dtgrid.SelectionChanged
        clicDatos(dtgrid.CurrentRow.Index)
    End Sub

End Class