Public Class frmIncidenciasCTPQ
    Public Ambiente As AmbienteCls
    Public idRetorno As Integer
    Public nombreRetorno As String

    Private ids As New List(Of Integer)
    Private sincro As SincronizarContpaq
    Private Sub frmIncidenciasCTPQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sincro = New SincronizarContpaq(Ambiente)
        sincro.cargaGridInciencias(dgvIncidencia, ids)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If dgvIncidencia.SelectedRows.Count > 0 Then
            idRetorno = ids.Item(dgvIncidencia.SelectedRows.Item(0).Index)
            nombreRetorno = dgvIncidencia.SelectedRows.Item(0).Cells(1).Value
        End If
    End Sub

    Private Sub dgvIncidencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidencia.CellDoubleClick
        Me.DialogResult = DialogResult.OK

        If dgvIncidencia.SelectedRows.Count > 0 Then
            idRetorno = ids.Item(dgvIncidencia.SelectedRows.Item(0).Index)
            nombreRetorno = dgvIncidencia.SelectedRows.Item(0).Cells(1).Value
        End If

        Me.Close()
    End Sub
End Class