Public Class frmActivarLicencia
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public tabla As String


    Private ObjVentana As EstacionTrabajo
    Private objDgv As New List(Of EstacionTrabajo)
    Private nuevoReg As Boolean
    Private objUbicacionFisica As UbicacionFisica
    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            ObjVentana = New EstacionTrabajo(Ambiente)
        End If

        objUbicacionFisica = New UbicacionFisica(Ambiente)
        objUbicacionFisica.idUbicacionFisica = ObjVentana.idUbicacionFisica
        objUbicacionFisica.buscarPID()

        txtIDUbicacion.Text = objUbicacionFisica.idUbicacionFisica
        txtNombreUbicacion.Text = objUbicacionFisica.nombreUbicacionFisica
        txtLicencia.Text = ObjVentana.licencia
        txtNombreEstacion.Text = ObjVentana.nombreEstacion
        txtObservacion.Text = ObjVentana.observaciones
        txtDescripcion.Text = ObjVentana.descripcion
        canLogin.Checked = ObjVentana.canLogin
        cbxEstado_au.SelectedItem = castEstadoInv(ObjVentana.estado_au)
        lastAcces.Text = "Último Acceso: " & ObjVentana.lastAccess

        If ObjVentana.estado_au = "AU" Then
            bteAutorizar.Visible = False
        Else
            bteAutorizar.Visible = True
        End If

    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        Try
            ObjVentana.creadoPor = Ambiente.usuario.idEmpleado
            ObjVentana.actualizadoPor = Ambiente.usuario.idEmpleado
            ObjVentana.idUbicacionFisica = txtIDUbicacion.Text
            ObjVentana.nombreEstacion = txtNombreEstacion.Text
            ObjVentana.licencia = txtLicencia.Text
            ObjVentana.observaciones = txtObservacion.Text
            ObjVentana.descripcion = txtDescripcion.Text
            ObjVentana.estado_au = castEstado(cbxEstado_au.SelectedItem.ToString)
            ObjVentana.canLogin = canLogin.Checked
        Catch ex As Exception
            Mensaje.Mensaje = "Error: " & ex.Message & "...?"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Show()
        End Try

        If nuevoReg Then
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            ObjVentana = objDgv.Item(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub frmCacteristicaTabla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterEstado.SelectedIndex = 3
        ObjVentana = New EstacionTrabajo(Ambiente)
        ObjVentana.cargaGridCom(DataGridView1, objDgv, "", castEstado(filterEstado.SelectedItem.ToString))
    End Sub

    Private Function castEstado(valor As String) As String
        Select Case valor
            Case "Autorizado"
                Return "AU"
            Case "Pendiente Por Autorizar"
                Return "PA"
            Case "No Autorizado"
                Return "NA"
            Case Else
                Return "ALL"
        End Select
    End Function

    Private Function castEstadoInv(valor As String) As String
        Select Case valor
            Case "AU"
                Return "Autorizado"
            Case "PA"
                Return "Pendiente Por Autorizar"
            Case Else
                Return "No Autorizado"
        End Select
    End Function
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabGeneral.SelectTab(1)
    End Sub

    Public Function guardar() As Boolean
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If ObjVentana.guardar() = True Then
                Mensaje.Mensaje = "Se Guardo el registro correctamente..."
                Mensaje.ShowDialog()
                ObjVentana.cargaGridCom(DataGridView1, objDgv, "", castEstado(filterEstado.SelectedItem.ToString))
                TabGeneral.SelectTab(0)
                Return True
            Else
                Mensaje.Mensaje = ObjVentana.descripError
                Mensaje.ShowDialog()
                Return False
            End If
        Else
            If ObjVentana.actualizar() = True Then
                Mensaje.Mensaje = "Se Actualizó el registro correctamente..."
                Mensaje.ShowDialog()
                ObjVentana.cargaGridCom(DataGridView1, objDgv, "", castEstado(filterEstado.SelectedItem.ToString))
                TabGeneral.SelectTab(0)
                Return True
            Else
                Mensaje.Mensaje = ObjVentana.descripError
                Mensaje.ShowDialog()
                Return False
            End If
        End If
        Return False
    End Function


    Private Sub btnComentarios_Click(sender As Object, e As EventArgs)
        frmComentario.tabla = "EstacionTrabajo"
        frmComentario.idTabla = ObjVentana.idEstacionTrabajo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs)
        frmArchivo.tabla = "EstacionTrabajo"
        frmArchivo.idTabla = ObjVentana.idEstacionTrabajo
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnAtributo_Click(sender As Object, e As EventArgs) Handles btnAtributo.Click
        frmBuscaUbicacionFisica.Ambiente = Ambiente
        If frmBuscaUbicacionFisica.ShowDialog() = DialogResult.OK Then  
            txtIDUbicacion.Text = frmBuscaUbicacionFisica.UbicacionRetorno.idUbicacionFisica
            txtNombreUbicacion.Text = frmBuscaUbicacionFisica.UbicacionRetorno.nombreUbicacionFisica
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        TabGeneral.SelectTab(1)
        nuevoReg = True
        asignaDatos()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        guardar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la estación de Trabajo: " & ObjVentana.nombreEstacion & "...?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            ObjVentana.eliminar()
            ObjVentana.cargaGridCom(DataGridView1, objDgv, "", castEstado(filterEstado.SelectedItem.ToString))
            TabGeneral.SelectTab(0)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bteFiltrar.Click
        ObjVentana.cargaGridCom(DataGridView1, objDgv, txtBuscar.Text, castEstado(filterEstado.SelectedItem.ToString))
        TabGeneral.SelectTab(0)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bteAutorizar.Click
        ObjVentana.autorizo = Ambiente.usuario.idEmpleado
        ObjVentana.canLogin = True
        ObjVentana.estado_au = "AU"

        If ObjVentana.actualizar() = True Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Se Autorizo correctamente..."
            Mensaje.ShowDialog()
            ObjVentana.cargaGridCom(DataGridView1, objDgv, "", castEstado(filterEstado.SelectedItem.ToString))
            TabGeneral.SelectTab(0)
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = ObjVentana.descripError
            Mensaje.ShowDialog()
        End If

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    frmCryptLicencia.objEstacionTrabajo = ObjVentana
    '    If frmCryptLicencia.ShowDialog() = DialogResult.OK And frmCryptLicencia.modificado = True Then
    '        ObjVentana = frmCryptLicencia.objEstacionTrabajo
    '        txtLicencia.Text = ObjVentana.licencia
    '    End If
    'End Sub

    'Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click

    'End Sub
End Class