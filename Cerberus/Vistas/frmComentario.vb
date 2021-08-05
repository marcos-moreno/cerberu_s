Public Class frmComentario
    Private cm As Comentario
    Public Ambiente As AmbienteCls
    Public tabla As String
    Public idTabla As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frmComentario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cm = New Comentario(Ambiente)
        RichTextBox1.Text = ""
        cm.idTabla = idTabla
        cm.tabla = tabla
        cm.cargarGrid(DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Limpiar" Then
            RichTextBox1.Text = ""
            RichTextBox1.ReadOnly = False
            Button2.Text = "Guardar"
        Else
            cm = New Comentario(Ambiente)
            cm.idTabla = idTabla
            cm.tabla = tabla
            cm.descripccion = RichTextBox1.Text

            If cm.guardar() Then
                RichTextBox1.Text = ""
                cm.cargarGrid(DataGridView1)
            Else
                Mensaje.Mensaje = cm.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        RichTextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        RichTextBox1.ReadOnly = True
        Button2.Text = "Limpiar"
    End Sub

End Class