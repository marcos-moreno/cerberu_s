Public Class frmRenovacion
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls
    Public empleado As Empleado
    Private ObjVentana As Renovacion
    Private listRenovacion As New List(Of Renovacion)
    Private listTipoRenovacion As New List(Of Tipo_renovacion)
    Private tipo_renovacion As Tipo_renovacion
    Private nuevoReg As Boolean
    Private ultimaFechaTermino As Date
    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            ObjVentana = New Renovacion(Ambiente)
            cbRenovacion.SelectedIndex = 0
            If listRenovacion.Count > 0 Then
                dtpFechaRenovacion.Value = DateAdd("d", 1, ultimaFechaTermino)
                dtpFechaTermino.Value = DateAdd("d", listTipoRenovacion.Item(cbRenovacion.SelectedIndex).dias_renovacion, dtpFechaRenovacion.Value)
            Else
                dtpFechaRenovacion.Value = empleado.fechaAlta
                dtpFechaTermino.Value = DateAdd("d", listTipoRenovacion.Item(cbRenovacion.SelectedIndex).dias_renovacion, dtpFechaRenovacion.Value)
            End If
            txtIDRenovacion.Text = ""
            txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado
            lbID.Text = empleado.idEmpleado
        Else
            txtIDRenovacion.Text = ObjVentana.id_renovacion
            txtNOmbreEmpleado.Text = empleado.nombreEmpleado & " " & empleado.apPatEmpleado & " " & empleado.apMatEmpleado
            lbID.Text = empleado.idEmpleado
            For i As Integer = 0 To listTipoRenovacion.Count - 1
                If listTipoRenovacion.Item(i).id_tipo_renovacion = ObjVentana.id_tipo_renovacion Then
                    cbRenovacion.SelectedIndex = i
                End If
            Next
            dtpFechaRenovacion.Value = ObjVentana.fecha_renovacion
            dtpFechaTermino.Value = ObjVentana.fecha_termino
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        If nuevoReg Then
        Else
            ObjVentana.id_tipo_renovacion = txtIDRenovacion.Text
        End If
        ObjVentana.idEmpleado = empleado.idEmpleado
        ObjVentana.id_tipo_renovacion = listTipoRenovacion.Item(cbRenovacion.SelectedIndex).id_tipo_renovacion
        ObjVentana.fecha_renovacion = dtpFechaRenovacion.Value
        ObjVentana.fecha_termino = dtpFechaTermino.Value
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            Try
                ObjVentana = listRenovacion.Item(indice)
                asignaDatos()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRenovaciones.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
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
            If Not ObjVentana.guardar() Then
                Mensaje.Mensaje = ObjVentana.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente..."
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not ObjVentana.actualizar() Then
                Mensaje.Mensaje = ObjVentana.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente..."
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()

        If Not operacion Then
            cargaGrid(dgvRenovaciones, listRenovacion)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Public Sub cargaGrid(a As DataGridView, b As List(Of Renovacion))
        ObjVentana.cargarGridGen(a, b)
        If listRenovacion.Count > 0 Then
            ultimaFechaTermino = listRenovacion.Item(0).ultimaFechaTermino
        Else
            ultimaFechaTermino = Nothing
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la caracteristica seleccionada...?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            ObjVentana.eliminar()
            'ObjVentana.cargarGridGen(dgvRenovaciones, listRenovacion)
            cargaGrid(dgvRenovaciones, listRenovacion)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRenovaciones.SelectionChanged
        clicDatos(dgvRenovaciones.CurrentRow.Index)
        ' MsgBox(dgvRenovaciones.CurrentRow.Index)
        '    If dgvRenovaciones.SelectedRows.Count > 0 Then
        '        ObjVentana.cargarGridGen(dgvRenovaciones, listRenovacion)
        '        habilitarBotones()
        '    End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        'ObjVentana.cargarGridGen(dgvRenovaciones, listRenovacion)
        cargaGrid(dgvRenovaciones, listRenovacion)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvRenovaciones.SelectedRows.Item(0).Index <> dgvRenovaciones.Rows.Count - 1 Then
            dgvRenovaciones.Rows(dgvRenovaciones.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvRenovaciones.SelectedRows.Item(0).Index <> 0 Then
            dgvRenovaciones.Rows(dgvRenovaciones.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub frmRenovacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipo_renovacion = New Tipo_renovacion(Ambiente)
        tipo_renovacion.getCombo(cbRenovacion, listTipoRenovacion)
        ObjVentana = New Renovacion(Ambiente)
        ObjVentana.idEmpleado = empleado.idEmpleado
        cargaGrid(dgvRenovaciones, listRenovacion)
    End Sub

    Private Sub ch(sender As System.Object, e As System.EventArgs) Handles cbRenovacion.SelectedIndexChanged
        dtpFechaTermino.Value = DateAdd("d", listTipoRenovacion.Item(cbRenovacion.SelectedIndex).dias_renovacion, dtpFechaRenovacion.Value)
    End Sub

End Class