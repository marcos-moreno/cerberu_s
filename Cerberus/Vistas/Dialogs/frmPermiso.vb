Public Class frmPermiso

    Public Ambiente As AmbienteCls
    Public empleado As Empleado
    Private nuevoReg As Boolean
    Private tInci As TipoIncidencia
    Private ListTipoIncidencia As New List(Of TipoIncidencia)
    Private ListSolicituPermiso As New List(Of SolicitudPermiso)
    Private objSolicituPermiso As SolicitudPermiso
    Private liderDepartamento As LiderDepartamento
    Private ListLiderDepartamento As New List(Of LiderDepartamento)

    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Ambiente.usuario.desarrollador = True Then
            bteModificarFormato.Visible = True
        Else
            bteModificarFormato.Visible = False
        End If
        tInci = New TipoIncidencia(Ambiente)
        tInci.idEmpresa = Ambiente.empr.idEmpresa
        tInci.calculada = False
        tInci.getComboActivoTablaRegistro(cbTipoIncidencia, ListTipoIncidencia, " AND idTipoIncidencia IN (5,6,1,12)")
        txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado

        liderDepartamento = New LiderDepartamento(Ambiente)
        liderDepartamento.getComboLiderXdepartamento(cbLider, ListLiderDepartamento, empleado.idDepartamento)

        objSolicituPermiso = New SolicitudPermiso(Ambiente)
        objSolicituPermiso.idEmpleado = empleado.idEmpleado
        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, False, pendientes.Checked)
        TabControl1.SelectTab(0)
    End Sub


    Private Sub ch(sender As System.Object, e As System.EventArgs)
        If ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia = False Then
            horaInicio.Visible = True
            horaFin.Visible = True
        Else
            horaInicio.Visible = False
            horaFin.Visible = False
        End If
    End Sub
    Public Sub asignaDatos()
        horaInicio.Visible = False
        horaFin.Visible = False
        If nuevoReg Then
            bteFormato.Visible = False
            objSolicituPermiso = New SolicitudPermiso(Ambiente)
            objSolicituPermiso.idEmpleado = empleado.idEmpleado
            cbTipoIncidencia.SelectedIndex = 0
            txtIDSolicitudPermiso.Text = 0
            txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado
            dtpFechaPermiso.Value = DateAdd("d", 1, Now.Date)
            txtMotivo.Text = ""
            txtEstado.Text = ""
            txtComentarioLider.Text = ""
            cbLider.SelectedIndex = -1
            If ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia = False Then
                horaInicio.Visible = True
                horaFin.Visible = True
            Else
                horaInicio.Visible = False
                horaFin.Visible = False
            End If

            horaInicio.Value = Now
            horaFin.Value = Now
            cbTipoIncidencia.Visible = True
        Else
            txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado
            For i As Integer = 0 To ListTipoIncidencia.Count - 1
                If ListTipoIncidencia.Item(i).idTipoIncidencia = objSolicituPermiso.idTipoIncidencia Then
                    cbTipoIncidencia.SelectedIndex = i
                End If
            Next

            For i As Integer = 0 To ListLiderDepartamento.Count - 1
                If ListLiderDepartamento.Item(i).idEmpleado = objSolicituPermiso.idLider Then
                    cbLider.SelectedIndex = i
                End If
            Next

            txtIDSolicitudPermiso.Text = objSolicituPermiso.idSolicitudPermiso
            dtpFechaPermiso.Value = objSolicituPermiso.fechaPermiso
            txtMotivo.Text = objSolicituPermiso.motivo
            Select Case objSolicituPermiso.estado
                Case "RE"
                    txtEstado.Text = "RECHAZADO"
                    bteFormato.Visible = False
                Case "AU"
                    txtEstado.Text = "AUTORIZADO"
                    bteFormato.Visible = True
                Case "PA"
                    txtEstado.Text = "PENDIENTE DE AUTORIZAR"
                    bteFormato.Visible = False
            End Select
            txtComentarioLider.Text = objSolicituPermiso.respuesta
            If ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia = False Then
                cbTipoIncidencia.Visible = True
                horaInicio.Visible = True
                horaFin.Visible = True
            Else
                cbTipoIncidencia.Visible = True
                horaInicio.Visible = False
                horaFin.Visible = False
            End If
            horaInicio.Value = Convert.ToDateTime(objSolicituPermiso.horaI.ToString)
            horaFin.Value = Convert.ToDateTime(objSolicituPermiso.horaF.ToString)
        End If
    End Sub

    Public Function obtenerDatos() As Boolean
        Try
            If cbLider.SelectedIndex < 0 Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Selecciona el Líder."
                Mensaje.ShowDialog()
                Return False
            End If

            If cbTipoIncidencia.SelectedIndex < 0 Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Selecciona la Incidencia."
                Mensaje.ShowDialog()
                Return False
            End If

            objSolicituPermiso.idTipoIncidencia = ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).idTipoIncidencia
            objSolicituPermiso.calculada = ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia
            objSolicituPermiso.fechaPermiso = dtpFechaPermiso.Value
            objSolicituPermiso.motivo = txtMotivo.Text
            objSolicituPermiso.horaI = TimeSpan.Parse(Format(horaInicio.Value, "HH:mm:ss"))
            objSolicituPermiso.horaF = TimeSpan.Parse(Format(horaFin.Value, "HH:mm:ss"))
            objSolicituPermiso.idLider = ListLiderDepartamento.Item(cbLider.SelectedIndex).idEmpleado
            Return True
        Catch ex As Exception
            MsgBox("obtenerDatos: " & ex.Message)
            Return False
        End Try
    End Function

    Public Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            Try
                objSolicituPermiso = ListSolicituPermiso.Item(indice)
                asignaDatos()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub resetView()
        cbTipoIncidencia.SelectedIndex = 0
        txtIDSolicitudPermiso.Text = 0
        txtNOmbreEmpleado.Text = ""
        dtpFechaPermiso.Value = Now
        txtMotivo.Text = ""
        txtEstado.Text = ""
        txtComentarioLider.Text = ""
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        If obtenerDatos() Then
            If objSolicituPermiso.fechaPermiso.ToShortDateString() = Now.ToShortDateString() And nuevoReg Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "NO puedes crear una SOLICITUD DE PERMISO para el mismo día, por favor verifica la fecha."
                Mensaje.ShowDialog()
                Return
            End If

            If objSolicituPermiso.fechaPermiso.ToShortDateString() = Now.ToShortDateString() Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "NO puedes Modificar una SOLICITUD DE PERMISO para el mismo día, por favor verifica la fecha."
                Mensaje.ShowDialog()
                Return
            End If

            If objSolicituPermiso.fechaPermiso > Now.ToShortDateString() Then
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "El permiso debé ser en una fecha mayor."
                Mensaje.ShowDialog()
                Return
            End If
            'InputBox("", "", objSolicituPermiso.horaF.ToString & "   " & objSolicituPermiso.horaI.ToString)
            If objSolicituPermiso.horaF <= objSolicituPermiso.horaI And objSolicituPermiso.calculada = False Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "La hora del permiso no es válida."
                Mensaje.ShowDialog()
                Return
            End If
            If Len(objSolicituPermiso.motivo) < 10 Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Debes ingresar el motivo del permiso, mínimo 10 caracteres."
                Mensaje.ShowDialog()
                Return
            End If


            If nuevoReg Then
                objSolicituPermiso.estado = "PA"
                If Not objSolicituPermiso.guardar(False) Then
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = objSolicituPermiso.descripError
                    Mensaje.ShowDialog()
                    Return
                Else
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.Mensaje = "Se guardó correctamente..."
                    nuevoReg = False
                End If
            Else
                If objSolicituPermiso.estado = "PA" Or objSolicituPermiso.estado = "RE" Then
                    objSolicituPermiso.estado = "PA"
                    If Not objSolicituPermiso.actualizar(False) Then
                        Mensaje.tipoMsj = TipoMensaje.Error
                        Mensaje.Mensaje = objSolicituPermiso.descripError
                        Mensaje.ShowDialog()
                        Return
                    Else
                        Mensaje.tipoMsj = TipoMensaje.Informacion
                        Mensaje.Mensaje = "Se actualizó correctamente..."
                    End If
                Else
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = "El estado de permiso no permite Actualizar el registro"
                    Mensaje.ShowDialog()
                    Return
                End If


            End If
            Mensaje.ShowDialog()
            resetView()
            objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, False, pendientes.Checked)
            TabControl1.SelectTab(0)
        End If
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la Solicitud seleccionada?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If objSolicituPermiso.eliminar(False) Then
                resetView()
                objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, False, pendientes.Checked)
                TabControl1.SelectTab(0)
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se Eliminó correctamente..."
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = objSolicituPermiso.descripError
            End If
            Mensaje.ShowDialog()
        End If
    End Sub


    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        resetView()
        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, False, pendientes.Checked)
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
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dtgrid_SelectionChanged(sender As Object, e As EventArgs) Handles dtgrid.SelectionChanged

        clicDatos(dtgrid.CurrentRow.Index)

    End Sub
    Private Sub pendientes_CheckedChanged(sender As Object, e As EventArgs) Handles pendientes.CheckedChanged
        objSolicituPermiso = New SolicitudPermiso(Ambiente)
        objSolicituPermiso.idEmpleado = empleado.idEmpleado
        resetView()
        objSolicituPermiso.cargarGridGen(dtgrid, ListSolicituPermiso, False, pendientes.Checked)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cbTipoIncidencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoIncidencia.SelectedIndexChanged
        If ListTipoIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia = False Then
            horaInicio.Visible = True
            horaFin.Visible = True
        Else
            horaInicio.Visible = False
            horaFin.Visible = False
        End If
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles bteFormato.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_frmatPeriso(False, objSolicituPermiso.idSolicitudPermiso)
    End Sub

    Private Sub bteModificarFormato_Click(sender As Object, e As EventArgs) Handles bteModificarFormato.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_frmatPeriso(True, objSolicituPermiso.idSolicitudPermiso)
    End Sub
End Class