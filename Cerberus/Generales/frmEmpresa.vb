Imports Cerberus

Public Class frmEmpresa
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public objEmpr As Empresa

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtNombre.Text = objEmpr.nombreEmpresa
        txtRFC.Text = objEmpr.rfcEmpresa
        txtRazonSocial.Text = objEmpr.razonSocial
        chbTiempoxTiempo.Checked = objEmpr.tiempoXTiempo
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objEmpr.nombreEmpresa = txtNombre.Text
        objEmpr.rfcEmpresa = txtRFC.Text
        objEmpr.razonSocial = txtRazonSocial.Text
        objEmpr.tiempoXTiempo = chbTiempoxTiempo.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        If objEmpr.actualizar() Then
            Mensaje.Mensaje = "Se actualizaron correctamente los datos..."
            Ambiente.empr = objEmpr
        Else
            Mensaje.Mensaje = objEmpr.descripError
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub frmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objEmpr = Ambiente.empr
        asignaDatos()
        habilitarBotones()
    End Sub
End Class