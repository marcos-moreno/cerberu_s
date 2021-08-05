Public Class frmAsignaLiderDepto
    Public Ambiente As AmbienteCls
    Public lideDepartamento As LiderDepartamento
    Public objVentanalideDepartamento As LiderDepartamento
    Public ListlideDepartamento As List(Of LiderDepartamento)
    Public departamento As Departamento
    Private nuevoReg As Boolean
    Private Sub frmAsignaLiderDepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'grupo1.Text = departamento.nombreDepartamento
        ListlideDepartamento = New List(Of LiderDepartamento)
        objVentanalideDepartamento = New LiderDepartamento(Ambiente)
        objVentanalideDepartamento.idDepartamento = departamento.idDepartamento
        objVentanalideDepartamento.cargaGridCom(dtgrid, ListlideDepartamento)
        lblStatus.Text = departamento.nombreDepartamento
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        frmBuscaEmpleado.buscarEntodasLasEmpresas = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDLider.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreLiderI.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
        frmBuscaEmpleado.buscarEntodasLasEmpresas = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub asignaDatos()
        If nuevoReg Then
            lideDepartamento = New LiderDepartamento(Ambiente)
            lideDepartamento.idDepartamento = departamento.idDepartamento
            txtIDLider.Text = ""
            txtNombreLiderI.Text = ""
            cbTipoLider.SelectedIndex = -1
        Else
            Dim empleado = New Empleado(Ambiente)
            empleado.idEmpleado = lideDepartamento.idEmpleado
            empleado.buscarPID()
            txtIDLider.Text = empleado.idEmpleado
            txtNombreLiderI.Text = empleado.nombreCompleto
            cbTipoLider.SelectedItem = lideDepartamento.tipoLider
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        If obtenerDatos() Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If nuevoReg Then
                If Not lideDepartamento.guardar() Then
                    Mensaje.Mensaje = lideDepartamento.descripError
                    Mensaje.ShowDialog()
                Else
                    Mensaje.Mensaje = "Se guardó correctamente el departamento"
                    nuevoReg = False
                    Mensaje.ShowDialog()
                    objVentanalideDepartamento.cargaGridCom(dtgrid, ListlideDepartamento)
                    TabControl1.SelectTab(0)
                End If
            Else
                If Not lideDepartamento.actualizar() Then
                    Mensaje.Mensaje = lideDepartamento.descripError
                    Mensaje.ShowDialog()
                Else
                    Mensaje.Mensaje = "Se actualizó correctamente el departamento"
                    Mensaje.ShowDialog()
                    objVentanalideDepartamento.cargaGridCom(dtgrid, ListlideDepartamento)
                    TabControl1.SelectTab(0)
                End If
            End If
        End If
    End Sub

    Private Function obtenerDatos() As Boolean
        If IsNumeric(txtIDLider.Text) And cbTipoLider.SelectedItem IsNot Nothing Then
            lideDepartamento.idEmpleado = txtIDLider.Text

            If cbTipoLider.SelectedIndex > -1 Then
                lideDepartamento.tipoLider = cbTipoLider.SelectedItem
                Return True
            Else
                Mensaje.Mensaje = "El Tipo de Líder es obligatorio."
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
                Return False
            End If
        Else
            Mensaje.Mensaje = "El Líder es obligatorio."
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Líder del Departamento?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            lideDepartamento.eliminar()
            objVentanalideDepartamento.cargaGridCom(dtgrid, ListlideDepartamento)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        objVentanalideDepartamento.cargaGridCom(dtgrid, ListlideDepartamento)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dtgrid.SelectedRows.Item(0).Index <> 0 Then
            dtgrid.Rows(dtgrid.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dtgrid.SelectedRows.Item(0).Index <> dtgrid.Rows.Count - 1 Then
            dtgrid.Rows(dtgrid.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrid.CellDoubleClick
        clicDatos(e.RowIndex)
        TabControl1.SelectTab(1)
    End Sub

    Private Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            lideDepartamento = ListlideDepartamento.Item(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dtgrid.SelectionChanged
        If dtgrid.SelectedRows.Count > 0 Then
            clicDatos(dtgrid.SelectedRows.Item(0).Index)
        End If
    End Sub

End Class