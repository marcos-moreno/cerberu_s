Public Class frmBuscarProductoCompuesto
    Public Ambiente As AmbienteCls
    Private productoCompuesto As ProductoCompuesto
    Private objProductoComp As New List(Of ProductoCompuesto)
    Public productoRetorno As ProductoCompuesto
    Public soloActivos As Boolean
    Public wExistence As Boolean

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productoCompuesto = New ProductoCompuesto(Ambiente)
        productoCompuesto.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        productoCompuesto.cargaGrid(DataGridView1, objProductoComp, txtBuscar.Text, wExistence)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            productoRetorno = objProductoComp.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            productoRetorno = objProductoComp.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class