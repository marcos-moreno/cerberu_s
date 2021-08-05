Public Class frmBuscar
    Public valorBuscado As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        valorBuscado = TextBox1.Text
    End Sub

    Private Sub frmBuscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = valorBuscado
    End Sub
End Class