Public Class frmBuscaProveedor

    Public Ambiente As AmbienteCls
    Private proveedor As ProveedorProductos
    Private objProvDG As New List(Of ProveedorProductos)
    Public proveedorRetorno As ProveedorProductos


    Private Sub frmBuscaProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        proveedor = New ProveedorProductos(Ambiente)
        proveedor.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        proveedor.cargaGrid(DataGridView1, objProvDG, txtBuscar.Text)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            proveedorRetorno = objProvDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.DialogResult = DialogResult.OK

        If DataGridView1.SelectedRows.Count > 0 Then
            proveedorRetorno = objProvDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class