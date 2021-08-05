Public Class frmImportar
    Public Ambiente As AmbienteCls
    Public tabla As String
    Public valor1 As String
    Public valor2 As String

    Private objFormatoImportacion As FormatoImportacion
    Private cbFormatoImportacion As New List(Of FormatoImportacion)

    Private objDetalleImport As DetalleFormatoImportacion
    'Private columnas As New List(Of DetalleFormatoImportacion)

    Private Sub frmImportar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objFormatoImportacion = New FormatoImportacion(Ambiente)
        objFormatoImportacion.tabla = tabla
        objFormatoImportacion.idEmpresa = Ambiente.empr.idEmpresa

        objFormatoImportacion.getComboActivo(cbFormatoImp, cbFormatoImportacion)

        objDetalleImport = New DetalleFormatoImportacion(Ambiente)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarArchivo.Filter = cbFormatoImportacion(cbFormatoImp.SelectedIndex).tipoArchivo
        buscarArchivo.Multiselect = False
        If buscarArchivo.ShowDialog() = DialogResult.OK Then
            txtRutaArchivo.Text = buscarArchivo.FileName
        End If
    End Sub

    Private Sub cbFormatoImp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFormatoImp.SelectedIndexChanged
        If cbFormatoImp.SelectedIndex = -1 Then
            btnBuscar.Enabled = False
            btnDetalle.Enabled = False
        Else
            btnBuscar.Enabled = True
            btnDetalle.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDetalle.Click
        If cbFormatoImp.SelectedIndex <> -1 Then
            frmDetalleFormatoImportacion.idFormatoImportacion = cbFormatoImportacion(cbFormatoImp.SelectedIndex).idFormatoImportacion
            frmDetalleFormatoImportacion.Ambiente = Ambiente
            frmDetalleFormatoImportacion.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If txtRutaArchivo.Text = "" Then
            Mensaje.Mensaje = "Es necesario seleccionar un archivo para continuar..."
        Else
            objDetalleImport.idFormatoImportacion = cbFormatoImportacion(cbFormatoImp.SelectedIndex).idFormatoImportacion
            If objDetalleImport.Importar(txtRutaArchivo.Text, tabla, txtHoja.Text, txtRango.Text, valor1, cbFormatoImportacion(cbFormatoImp.SelectedIndex).tipoArchivo) Then
                Mensaje.Mensaje = "Se importo correctamente la información."
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objDetalleImport.descripError
            End If
        End If
        Mensaje.ShowDialog()
    End Sub
End Class