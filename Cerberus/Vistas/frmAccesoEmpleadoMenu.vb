Public Class frmAccesoEmpleadoMenu
    Public Ambiente As AmbienteCls
    Private acceso As AccesoEmpleado
    Dim objAcceso As New List(Of AccesoEmpleado)
    Dim objAModificar As New List(Of AccesoEmpleado)

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto

            acceso.idEmpleado = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado

            cargarGrid()
        End If
    End Sub

    Private Sub cargarGrid()
        acceso.cargaGridMenu(DataGridView1, objAcceso, cbVentanas.SelectedItem)
    End Sub

    Private Sub frmAccesoEmpleadoMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        acceso = New AccesoEmpleado(Ambiente)
        txtIDEmpleadoCocina.Text = ""
        txtNombreEmpleadoCocina.Text = ""

        cbVentanas.SelectedIndex = 0

        DataGridView1.Rows.Clear()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cargarGrid()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        For i As Integer = 0 To objAModificar.Count - 1
            objAModificar(i).actualizar()
        Next
        objAModificar.Clear()

        cargarGrid()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If objAcceso.Item(e.RowIndex).activa <> DataGridView1.Rows(e.RowIndex).Cells(0).Value Then
            objAcceso.Item(e.RowIndex).activa = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            objAModificar.Add(objAcceso.Item(e.RowIndex))
        End If

    End Sub
End Class