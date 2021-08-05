Public Class frmDetalleFormatoImportacion
    Public idFormatoImportacion As Integer
    Public Ambiente As AmbienteCls

    Private objDetalleFI As DetalleFormatoImportacion
    Private objDGVDetalleFI As New List(Of DetalleFormatoImportacion)

    Private Sub frmDetalleFormatoImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objDetalleFI = New DetalleFormatoImportacion(Ambiente)
        objDetalleFI.idFormatoImportacion = idFormatoImportacion
        objDetalleFI.cargaGrid(DataGridView1, objDGVDetalleFI)
    End Sub
End Class