Public Class Mensaje
    Public origen As String
    Public Mensaje As String
    Public tipoMsj As Integer

    ' Alerta
    '[Error]
    'Pregunta
    'Informacion
    Private Sub Mensaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipoMsj = TipoMensaje.Informacion Then
            PictureBox1.Image = Cerberus.My.Resources.comprobar 'Image.FromFile(My.Resources.)
            btn1.Visible = False
            btn2.Text = "Aceptar"
            btn2.DialogResult = DialogResult.OK
            RichTextBox1.Text = Mensaje
        ElseIf tipoMsj = TipoMensaje.Error Then
            PictureBox1.Image = Cerberus.My.Resources.cancelar
            btn1.Visible = False
            btn2.Text = "Aceptar"
            btn2.DialogResult = DialogResult.OK
            RichTextBox1.Text = origen & vbCrLf & "Ocurrio un error: " & Mensaje
        ElseIf tipoMsj = TipoMensaje.Pregunta Then
            PictureBox1.Image = Cerberus.My.Resources.advertir
            btn1.Visible = True
            btn1.Text = "Si"
            btn1.DialogResult = DialogResult.Yes
            btn2.Text = "No"
            btn2.DialogResult = DialogResult.No
            RichTextBox1.Text = Mensaje
        ElseIf tipoMsj = TipoMensaje.Alerta Then
            PictureBox1.Image = Cerberus.My.Resources.advertir
            btn1.Visible = False
            btn2.Text = "Aceptar"
            btn2.DialogResult = DialogResult.OK
            RichTextBox1.Text = origen & vbCrLf & "Ocurrio un error: " & Mensaje
        End If
    End Sub

End Class