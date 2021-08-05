Public Class frmBuscaEquipoTelefonico
    Public Ambiente As AmbienteCls
    Private equipoTelefonico As EquipoTelefonico
    Private objListEquipoTelefonico As New List(Of EquipoTelefonico)
    Public equipoTelefonicoRetorno As EquipoTelefonico
    Public idCompañiaFiltro As Integer
    Private Sub frmBuscaPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        equipoTelefonico = New EquipoTelefonico(Ambiente)
        filtrar()
    End Sub

    Private Sub filtrar()
        equipoTelefonico.idCompañia = idCompañiaFiltro
        equipoTelefonico.cargarGridGen(DataGridView1, txtBuscar.Text, objListEquipoTelefonico)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            equipoTelefonicoRetorno = objListEquipoTelefonico.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            equipoTelefonicoRetorno = objListEquipoTelefonico.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
        Me.Close()
    End Sub

End Class