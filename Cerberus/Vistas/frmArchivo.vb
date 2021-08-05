Public Class frmArchivo
    Private arch As Archivo
    Public Ambiente As AmbienteCls

    Public tabla As String
    Public idTabla As Integer
    Public elementoSistema As String
    Public tipoArchivo As String

    Private objDGArchivo As New List(Of Archivo)

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtUrl.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub frmArchivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        arch = New Archivo(Ambiente)
        arch.tabla = tabla
        arch.idTabla = idTabla
        arch.elementoSistema = elementoSistema
        arch.tipoArchivo = tipoArchivo

        arch.cargarGrid(DataGridView1, objDGArchivo)

        txtUrl.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtUrl.Text <> "" Then
            arch = New Archivo(Ambiente)
            arch.tabla = tabla
            arch.idTabla = idTabla
            arch.elementoSistema = elementoSistema
            arch.tipoArchivo = tipoArchivo

            arch.rutaOriginal = txtUrl.Text

            If arch.guardar() Then
                Mensaje.Mensaje = "Se guardo correctamente el archivo..."
                arch.cargarGrid(DataGridView1, objDGArchivo)
            Else
                Mensaje.Mensaje = arch.descripError
            End If
        Else
            Mensaje.Mensaje = "Favor de seleccionar un archivo adjunto para poder continuar..."
        End If

        Mensaje.tipoMsj = TipoMensaje.Informacion
        Mensaje.ShowDialog()
    End Sub

    Private Sub btnComentario_Click(sender As Object, e As EventArgs) Handles btnComentario.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            frmComentario.tabla = "Archivo"
            frmComentario.idTabla = objDGArchivo(DataGridView1.SelectedRows(0).Index).idArchivo
            frmComentario.Ambiente = Ambiente
            frmComentario.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex <> -1 Then
            If Not objDGArchivo(DataGridView1.SelectedRows(0).Index).abrirArchivo() Then
                Mensaje.Mensaje = objDGArchivo(DataGridView1.SelectedRows(0).Index).descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub bntEliminar_Click(sender As Object, e As EventArgs) Handles bntEliminar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Mensaje.Mensaje = "¿Realmente desea eliminar el archivo seleccionado: """ & objDGArchivo(DataGridView1.SelectedRows(0).Index).nombreArchivo & """?"
            Mensaje.tipoMsj = TipoMensaje.Pregunta

            If Mensaje.ShowDialog = DialogResult.Yes Then
                If Not objDGArchivo(DataGridView1.SelectedRows(0).Index).eliminar() Then
                    Mensaje.Mensaje = objDGArchivo(DataGridView1.SelectedRows(0).Index).descripError
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.ShowDialog()
                Else
                    arch.cargarGrid(DataGridView1, objDGArchivo)
                End If
            End If
        End If
    End Sub
End Class