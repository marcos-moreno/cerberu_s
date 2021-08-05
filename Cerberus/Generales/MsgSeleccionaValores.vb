Public Class MsgSeleccionaValores

    Public resultado As String
    Public Mensaje As String
    Private Sub MsgSeleccionaValores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = Mensaje
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        resultado = "Uniformes"
        Me.DialogResult = DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        resultado = "Credenciales"
        Me.DialogResult = DialogResult.OK
        'Me.Close()
    End Sub
End Class