Imports System.ComponentModel
Imports System.IO

Public Class frmLogin
    Private conex As ConexionSQL
    Private usr As Empleado
    Private empr As Empresa
    Private suc As Sucursal
    Private log As LogAcceso
    Private accesos As AccesoEmpleado
    Private cmbEmpresaIds As New List(Of Empresa)
    Private cmbSucursalIds As New List(Of Sucursal)

    Public Ambiente As AmbienteCls

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conex = Ambiente.conex

        txtEstacion.Text = Ambiente.estacion

        Dim worstation As New EstacionTrabajo(Ambiente)
        worstation.nombreEstacion = Ambiente.estacion

        'If Not worstation.buscarPID() Then
        '    MsgBox("Esta terminal no tiene acceso a usar este Software...FAVOR DE CONSULTAR AL ADMINISTRADOR...", MsgBoxStyle.Critical, "ALERTA!!!")
        '    frmSelecConexion.Dispose()
        'End If

        'If Not worstation.licenciaValida Then
        '    MsgBox(worstation.descripError & "...FAVOR DE CONSULTAR AL ADMINISTRADOR...", MsgBoxStyle.Critical, "ALERTA!!!")
        '    btnValida.Visible = False
        '    btnValida.SetBounds(0, 0, 0, 0)
        '    txtUsuario.Enabled = False
        '    txtPass.Enabled = False

        '    txtNombreUsuario.Text = "SOLICITUD: " & worstation.codigoSolicitud
        'End If

        'lblLicencia.Text = worstation.licencia & " >>> Válida Hasta: " & UCase(Format(worstation.validaHasta, "dd/MMMM/yyyy"))
        'lblLicencia.Text = worstation.licencia & " >>> Válida Hasta: " & UCase(Format(worstation.validaHasta, "dd/MMMM/yyyy"))

        'VALIDADOR DE VERSION
        'Dim vSistema As Decimal
        'Dim startInfo As ProcessStartInfo = New ProcessStartInfo("Actualizador.exe")
        'startInfo.WindowStyle = ProcessWindowStyle.Normal

        'vSistema = CDec(My.Application.Info.Version.Major.ToString)
        'vSistema = vSistema + (CDec(My.Application.Info.Version.Minor.ToString) / 100)

        'Dim versionAct As Version
        'versionAct = New Version(Ambiente)
        'versionAct.idUbicacionFisica = worstation.idUbicacionFisica
        'versionAct.getVersionActual()

        'If versionAct.version > vSistema Then
        '    Mensaje.tipoMsj = TipoMensaje.Informacion
        '    Mensaje.Mensaje = "Es necesario actualizar la aplicación,Novedades:  " & versionAct.observaciones & ", se cerrara para poder realizar el proceso..."
        '    Mensaje.ShowDialog()

        '    If versionAct.usuario = Nothing Then
        '        startInfo.Arguments = versionAct.rutaActualizacion
        '    Else
        '        startInfo.Arguments = versionAct.rutaActualizacion & " " & versionAct.dominio & " " & versionAct.usuario & " " & versionAct.password
        '    End If
        '    Process.Start(startInfo)
        '    Me.Close()
        '    Me.Dispose()
        '    Exit Sub
        'End If
        '----

        Ambiente.accesoBotones = New AccesoEmpleado(Ambiente)

        usr = New Empleado(Ambiente)
        empr = New Empresa(Ambiente)
        suc = New Sucursal(Ambiente)
        accesos = New AccesoEmpleado(Ambiente)

        TabPage2.Enabled = False
        txtUsuario.Select()
    End Sub

    Private Sub txtUsuario_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyUp
        If e.KeyCode = Keys.Enter Then
            getUser()
        End If
    End Sub

    Private Sub getUser()
        usr.usuario = txtUsuario.Text
        If usr.buscarPUsuario() Then
            txtNombreUsuario.Text = usr.nombreCompleto
            txtPass.Select()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "El Usuario ingresado no existe, favor de verificarlo..."
            Mensaje.ShowDialog()
            txtUsuario.Select()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'frmSolicitarLicencia.ShowDialog()
        validaPass()
    End Sub

    Private Sub validaPass()
        If usr.validaPassword(txtPass.Text) Then
            TabPage2.Enabled = True
            tbConfig.SelectTab(1)
            empr.getComboXEmplado(cmbEmpresa, cmbEmpresaIds, usr.idEmpleado)
        Else
            TabPage2.Enabled = False
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = usr.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function validarDatos() As Boolean
        If cmbEmpresa.SelectedIndex = -1 Or cmbSucursal.SelectedIndex = -1 Then
            Return False
        End If
        Return True
    End Function

    Private Sub txtPass_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPass.KeyUp
        If e.KeyCode = Keys.Enter Then
            validaPass()
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If cmbEmpresa.SelectedIndex <> -1 Then
            suc.getComboXEmplado(cmbSucursal, cmbSucursalIds, usr.idEmpleado, cmbEmpresaIds.Item(cmbEmpresa.SelectedIndex).idEmpresa)
        Else
            cmbSucursal.Items.Clear()
        End If
    End Sub

    Private Sub txtUsuario_LostFocus(sender As Object, e As EventArgs) Handles txtUsuario.LostFocus
        If txtNombreUsuario.Text = "" Then
            txtUsuario.Select()
        End If
    End Sub

    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmSelecConexion.Close()
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        validaPass()
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles btnValida.Click
        If validarDatos() Then
            Dim principal As frmPrincipal
            principal = New frmPrincipal
            Ambiente.usuario = usr
            Ambiente.empr = cmbEmpresaIds.Item(cmbEmpresa.SelectedIndex)
            Ambiente.suc = cmbSucursalIds.Item(cmbSucursal.SelectedIndex)

            If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
                accesos.idEmpleado = Ambiente.usuario.idEmpleado
                accesos.nombreTabla = "Departamento"
                accesos.obtenerAccesosXEmplXTabla(Ambiente.idsDepartamentos, "ID", "ID")
            End If

            Ambiente.accesoBotones.nombreTabla = "Boton"
            Ambiente.accesoBotones.idEmpleado = usr.idEmpleado

            principal.Ambiente = Ambiente
            principal.Show()
            Me.Visible = False
        Else
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.origen = ""
            Mensaje.Mensaje = "Debe seleccionar una empresa y una Sucursal para poder continuar..."
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub MaterialRaisedButton2_Click_1(sender As Object, e As EventArgs)
        If File.Exists("conexiones.xml") Then
            My.Computer.FileSystem.DeleteFile("conexiones.xml")
        End If
        If Not File.Exists("conexiones.xml") Then
            My.Computer.FileSystem.CopyFile("conexionesDUAL.xml", "conexiones.xml")
            MessageBox.Show("Echo")
        End If
    End Sub
End Class