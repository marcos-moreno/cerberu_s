Public Class frmCambioPassword
    Public Ambiente As AmbienteCls


    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        If validarFields() Then
            If Ambiente.usuario.password = txtPassword.Text Then
                If txtNewPassword.Text = txtRepeatNewPassword.Text Then
                    Ambiente.usuario.password = txtNewPassword.Text
                    If Ambiente.usuario.actualizar() Then
                        Mensaje.Mensaje = "Cambio de contraseña Exitoso"
                        Mensaje.tipoMsj = TipoMensaje.Informacion
                        Mensaje.ShowDialog()
                    Else
                        Mensaje.Mensaje = Ambiente.usuario.descripError
                        Mensaje.tipoMsj = TipoMensaje.Error
                        Mensaje.ShowDialog()
                    End If
                Else
                    Mensaje.Mensaje = "Las nueva contraseña no coincide"
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.ShowDialog()
                End If
            Else
                Mensaje.Mensaje = "La contraseña anterior no coincide"
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
            End If
        End If
    End Sub
    Private Function validarFields()
        If txtPassword.Text.Length > 0 Then
            If txtNewPassword.Text.Length > 0 Then
                If txtRepeatNewPassword.Text.Length > 0 Then
                    Return True
                Else
                    Mensaje.Mensaje = "Es necesario que confirmes la contraseña nueva"
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.ShowDialog()
                End If
            Else
                Mensaje.Mensaje = "Es necesaria una contraseña nueva"
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.Mensaje = "Es necesaria tu contraseña anterior"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If
        Return False
    End Function
End Class