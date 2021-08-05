Public Class frmCatalogo
    Private Sub frmCatalogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtID.Text = ""
        txtValue.Text = ""
        soloActivos.Checked = True
        txtValue.Select()
    End Sub

    Private Sub txtIDEmpleado_KeyUp(sender As Object, e As KeyEventArgs) Handles txtID.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub txtvalor_KeyUp(sender As Object, e As KeyEventArgs) Handles txtValue.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class