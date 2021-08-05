Public Class frmBuscarCocina
    Public Ambiente As AmbienteCls
    Private coc As Cocina
    Private objCocinaDG As New List(Of Cocina)
    Public CocinaRetorno As Cocina

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        coc = New Cocina(Ambiente)
        coc.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        coc.cargaGridXParam(DataGridView1, objCocinaDG, txtBuscar.Text, True)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            CocinaRetorno = objCocinaDG.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            CocinaRetorno = objCocinaDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class