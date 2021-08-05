Public Class frmBuscaEmpleado
    Public Ambiente As AmbienteCls
    Private empl As Empleado
    Private objEmplDG As New List(Of Empleado)
    Public EmpleadoRetorno As Empleado
    Public soloActivos As Boolean
    Public buscarEntodasLasEmpresas As Boolean = False

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        empl = New Empleado(Ambiente)
        empl.buscarEnTodasLasEmpresas = buscarEntodasLasEmpresas
        empl.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        soloActivos = cbSoloActivos.Checked
        empl.cargarGrid(DataGridView1, 0, txtBuscar.Text, objEmplDG, soloActivos)
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            EmpleadoRetorno = objEmplDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            filtrar()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.DialogResult = DialogResult.OK

        If DataGridView1.SelectedRows.Count > 0 Then
            EmpleadoRetorno = objEmplDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub

End Class