Public Class frmCryptLicencia
    Dim encrip As New EncriptarLicencia
    Public objEstacionTrabajo As EstacionTrabajo
    Public modificado As Boolean = False
    Public licencia As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dato As String
            dato = encrip.Desencriptar(txtLicenciaOld.Text)
            '  MsgBox(dato) 
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Dim datitos As String()
            datitos = Split(dato, "||")
            dato = Format(Now, "yyyy-MM-dd") & "||" & datitos(1) & "||" & Format(dtpFechaVencimiento.Value, "yyyy-MM-dd")
            objEstacionTrabajo.licencia = encrip.Encriptar(dato)

            If Not objEstacionTrabajo.actualizar() Then
                Mensaje.Mensaje = objEstacionTrabajo.descripError
                Mensaje.ShowDialog()
            Else
                Mensaje.Mensaje = "Se guardó correctamente la Licencia."
                modificado = True
                Mensaje.ShowDialog()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            Mensaje.Mensaje = ex.Message
            Mensaje.ShowDialog()
        End Try
    End Sub

    Private Sub frmCryptLicencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLicenciaOld.Text = objEstacionTrabajo.licencia
    End Sub
End Class