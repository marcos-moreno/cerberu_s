Public Class frmBuscaPlan
    Public Ambiente As AmbienteCls
    Private plan As Plan
    Private objListPlan As New List(Of Plan)
    Public PlanRetorno As Plan
    Public idCompañia As Integer
    Private Sub frmBuscaPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        plan = New Plan(Ambiente)
        plan.idCompañia = idCompañia
        filtrar()
    End Sub

    Private Sub filtrar()
        plan.cargarGridGen(DataGridView1, txtBuscar.Text, objListPlan)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            PlanRetorno = objListPlan.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            PlanRetorno = objListPlan.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
        Me.Close()
    End Sub

End Class