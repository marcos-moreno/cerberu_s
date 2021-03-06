Public Class frmBuscaCompañiaTelefonica
    Public Ambiente As AmbienteCls
    Private compañia As CompañiaTelefonia
    Private objListCompañia As New List(Of CompañiaTelefonia)
    Public compañiaRetorno As CompañiaTelefonia
    Public idCompañia As Integer
    Private Sub frmBuscaPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        compañia = New CompañiaTelefonia(Ambiente)
        compañia.idCompañia = idCompañia
        filtrar()
    End Sub

    Private Sub filtrar()
        compañia.cargarGridGen(DataGridView1, txtBuscar.Text, objListCompañia)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            compañiaRetorno = objListCompañia.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            compañiaRetorno = objListCompañia.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
        Me.Close()
    End Sub

End Class