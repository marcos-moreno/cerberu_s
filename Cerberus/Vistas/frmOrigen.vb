Imports Cerberus

Public Class frmOrigen
    Implements InterfaceVentanas

    Public elemento As String
    Public origen As String
    Public Ambiente As AmbienteCls

    Private objOrigen As Origen
    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtContrasena.Text = objOrigen.contrasena
        txtDireccionIP.Text = objOrigen.direccionIP
        txtElemento.Text = objOrigen.elemento
        txtEsquema.Text = objOrigen.esquema
        txtInstancia.Text = objOrigen.instancia
        txtNombreBD.Text = objOrigen.nombreBD
        txtOrigen.Text = objOrigen.origen
        txtPuerto.Text = objOrigen.puerto
        txtUsuario.Text = objOrigen.usuario
        chbEsActivo.Checked = objOrigen.esActivo
        cbTipoBD.SelectedItem = objOrigen.tipoBD

        If cbTipoBD.SelectedIndex = -1 Then
            cbTipoBD.SelectedIndex = 0
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objOrigen.contrasena = txtContrasena.Text
        objOrigen.direccionIP = txtDireccionIP.Text
        objOrigen.elemento = txtElemento.Text
        objOrigen.esquema = txtEsquema.Text
        objOrigen.instancia = txtInstancia.Text
        objOrigen.nombreBD = txtNombreBD.Text
        objOrigen.origen = txtOrigen.Text
        objOrigen.puerto = txtPuerto.Text
        objOrigen.usuario = txtUsuario.Text
        objOrigen.esActivo = chbEsActivo.Checked
        objOrigen.tipoBD = cbTipoBD.SelectedItem
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Throw New NotImplementedException()
    End Sub

    Private Sub frmOrigen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objOrigen = New Origen(Ambiente)
        objOrigen.idEmpresa = Ambiente.empr.idEmpresa
        objOrigen.elemento = elemento
        objOrigen.origen = origen

        If objOrigen.buscarPID() Then
            nuevoReg = False
        Else
            nuevoReg = True
        End If

        asignaDatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos()

        If nuevoReg Then
            If objOrigen.guardar() Then
                Mensaje.Mensaje = "Se guardo correctamente la información..."
                nuevoReg = False
            Else
                Mensaje.Mensaje = Ambiente.conex.Qry & objOrigen.descripError
            End If
        Else
            If objOrigen.actualizar() Then
                Mensaje.Mensaje = "Se actualizo correctamente la información..."
            Else
                Mensaje.Mensaje = Ambiente.conex.Qry & objOrigen.descripError
            End If
        End If

        Mensaje.ShowDialog()
    End Sub
End Class