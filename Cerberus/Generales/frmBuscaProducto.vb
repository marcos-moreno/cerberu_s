Public Class frmBuscaProducto
    Public Ambiente As AmbienteCls
    Private producto As Producto

    Private objProducto As New List(Of Producto)
    Public productoRetorno As Producto
    Public soloActivos As Boolean

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        producto = New Producto(Ambiente)
        producto.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        producto.cargaGrid(DataGridView1, objProducto, txtBuscar.Text)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            productoRetorno = objProducto.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            productoRetorno = objProducto.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub

End Class