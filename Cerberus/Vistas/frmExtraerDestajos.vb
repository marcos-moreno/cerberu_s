Public Class frmExtraerDestajos
    Private Orig As Origen
    Private objOrigen As New List(Of Origen)
    Public Ambiente As AmbienteCls
    Public elemento As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If cbOrigen.SelectedIndex = -1 Then
            Mensaje.Mensaje = "Es necesario seleccione un Origen, para poder realizar la sincronizacion..."
        Else
            If objOrigen(cbOrigen.SelectedIndex).sincronizar() Then
                Mensaje.Mensaje = "Se sincronizo correctamente..."
            Else
                Mensaje.Mensaje = objOrigen(cbOrigen.SelectedIndex).descripError
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub frmOrigen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Orig = New Origen(Ambiente)
        Orig.idEmpresa = Ambiente.empr.idEmpresa
        Orig.elemento = elemento
        Orig.getComboActivo(cbOrigen, objOrigen)

        cbOrigen.SelectedIndex = -1
    End Sub
End Class