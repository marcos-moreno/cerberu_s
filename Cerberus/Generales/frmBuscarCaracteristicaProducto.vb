Public Class frmBuscarCaracteristicaProducto
    Public Ambiente As AmbienteCls
    Public filtro1 As String
    Private caracteristicaProd As CaracteristicaProducto

    Private objPCaractProd As New List(Of CaracteristicaProducto)
    Public CarProdRetorno As CaracteristicaProducto
    Public soloActivos As Boolean

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        caracteristicaProd = New CaracteristicaProducto(Ambiente)
        caracteristicaProd.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        caracteristicaProd.cargaGrid(DataGridView1, objPCaractProd, filtro1, txtBuscar.Text)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then

            CarProdRetorno = objPCaractProd.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            CarProdRetorno = objPCaractProd.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class