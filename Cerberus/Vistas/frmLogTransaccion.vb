Public Class frmLogTransaccion
    Public Ambiente As AmbienteCls
    Public idTabla As Integer
    Public tabla As String

    Private log As LogTransaccion
    Private objDGLog As New List(Of LogTransaccion)

    Private Sub frmLogTransaccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log = New LogTransaccion(Ambiente)
        log.idTabla = idTabla
        log.tabla = tabla

        log.cargarGrid(DataGridView1, objDGLog)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class