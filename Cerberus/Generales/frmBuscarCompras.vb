Public Class frmBuscarCompras

    Public Ambiente As AmbienteCls
    Public elementoSistema As String

    Public estado As String
    Public idSucursal As Integer
    Public fechaInicial As Date
    Public fechaFinal As Date
    Private objCbSuc As New List(Of Sucursal)
    Private objEstado As New List(Of String)
    Public estadoDocumentos As String
    Public documentos As String
    Private edoDocs As EstadoDocumentos

    Private Sub frmBuscarCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        edoDocs = New EstadoDocumentos

        cbEstado.Items.Clear()
        cbEstado.Items.Add(edoDocs.getNombreEstado("BO"))
        cbEstado.Items.Add(edoDocs.getNombreEstado("PA"))
        cbEstado.Items.Add(edoDocs.getNombreEstado("CO"))
        cbEstado.Items.Add(edoDocs.getNombreEstado("CA"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fechaFinal = dtpFechaMovcompra.Value
        edoDocs = New EstadoDocumentos
        estadoDocumentos = edoDocs.getContaccion(cbEstado.Text)
        Try
            idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Catch ex As Exception
            idSucursal = Nothing
        End Try
        documentos = txtDocumento.Text
    End Sub
End Class