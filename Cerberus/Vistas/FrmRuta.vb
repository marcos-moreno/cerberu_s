Imports Cerberus

Public Class FrmRuta
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objRuta As Ruta
    Private objDGVRuta As New List(Of Ruta)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        'Este método tiene la función de recojer los datos
        'del objeto y asignarlos a las cajas de texto y id's de ambiente
        Dim objSuc As New Sucursal(Ambiente)
        Dim objEmpl As New Empleado(Ambiente)

        txtEstado.BackColor = objRuta.getColorEstado()

        objEmpl.idEmpleado = objRuta.idEmpleado
        objEmpl.buscarPID()
        'Asigno el objeto de sucursal con el origen
        objSuc.idSucursal = objRuta.origen
        objSuc.buscarPID()
        txtOrigen.Text = objSuc.nombreSucursal
        txtIdSucOrigen.Text = objSuc.idSucursal
        'Asigno el objeto de sucursal con el destino
        objSuc.idSucursal = objRuta.destino
        TxtNombreEmpleado.Text = objEmpl.nombreCompleto

        If objSuc.buscarPID() Then
            DtpSalida.Value = objRuta.fechaSalida
            Dtpegreso.Value = objRuta.fechaRegreso
        Else
            DtpSalida.Value = Now
            Dtpegreso.Value = Now
        End If

        txtIdSucDest.Text = objSuc.idSucursal
        txtDestino.Text = objSuc.nombreSucursal
        txtEstado.Text = objRuta.getNombreEstado
        TxtNombreRuta.Text = objRuta.nombre
        TxtKMRecorridos.Text = objRuta.kmRecorrido
        TxtCorrdenadasOrigen.Text = objRuta.coordenadasOrigen
        TxtCoordenadasDestino.Text = objRuta.coordenadasDestino

        TxtIdEmpleado.Text = objRuta.idEmpleado

        Dim objCuenta As New Cuenta(Ambiente)
        objCuenta.idCuenta = objRuta.idCuenta
        objCuenta.buscarPID()

        TxtCuenta.Text = objCuenta.noDocumento
        TxtMonto.Text = objCuenta.monto
        txtComentario.Text = objRuta.comentario

    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        'obtiene los datos de las cajas de texto para
        'efectuar el guardado/actualización de la información
        objRuta.estadoDocumento = txtEstado.Text
        objRuta.nombre = TxtNombreRuta.Text
        objRuta.origen = txtIdSucOrigen.Text
        objRuta.destino = txtIdSucDest.Text
        objRuta.descripError = txtIdSucDest.Text
        objRuta.kmRecorrido = If(IsNumeric(TxtKMRecorridos.Text), TxtKMRecorridos.Text, 0)
        objRuta.coordenadasOrigen = TxtCoordenadasDestino.Text
        objRuta.coordenadasDestino = TxtCoordenadasDestino.Text
        objRuta.idEmpleado = TxtIdEmpleado.Text
        objRuta.fechaSalida = DtpSalida.Value
        objRuta.fechaRegreso = Dtpegreso.Value
        objRuta.comentario = txtComentario.Text

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        TabControl1.SelectedIndex = 1
        objRuta = objDGVRuta.Item(indice)
        asignaDatos()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim estadoCtrls As Boolean

        If objRuta.estadoDocumento = "CO" Then
            estadoCtrls = False
        Else
            estadoCtrls = True
        End If

        BtnGuardar.Enabled = estadoCtrls
        btnOrigen.Enabled = estadoCtrls
        btnDestino.Enabled = estadoCtrls
        BtnEmpleado.Enabled = estadoCtrls
        DtpSalida.Enabled = estadoCtrls
        Dtpegreso.Enabled = estadoCtrls
        TxtKMRecorridos.Enabled = estadoCtrls
        TxtCoordenadasDestino.Enabled = estadoCtrls
        TxtCorrdenadasOrigen.Enabled = estadoCtrls
        txtComentario.ReadOnly = If(estadoCtrls, False, True)

        If objRuta.estadoDocumento = Nothing Then
            GbEmpleado.Visible = False
        Else
            GbEmpleado.Visible = False
        End If
    End Sub

    Private Sub FrmRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRuta = New Ruta(Ambiente)
        objRuta.idEmpresa = Ambiente.empr.idEmpresa
        objRuta.cargaGridCom(objDGVRuta, dgvRuta)
        DtpSalida.Value = Now
        Dtpegreso.Value = Now
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Dim tipoAcc As Integer
        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos()
        frmNuevoEstado.setEstadoBD(objRuta.estadoDocumento)

        If objRuta.estadoDocumento = "COMPLETO" Then
            Mensaje.Mensaje = "No se puede volver a guardar el estado de documento cuando esté COMPLETO"
            Mensaje.ShowDialog()
            Exit Sub
        End If


        If frmNuevoEstado.ShowDialog() = DialogResult.OK Then

            If objRuta.idRuta = Nothing Then
                tipoAcc = 1
            Else
                tipoAcc = 2
            End If

            If frmNuevoEstado.getEstadoDB = Nothing Then
                Mensaje.Mensaje = "Seleccione un estado de documento"
                Mensaje.ShowDialog()
                Exit Sub
            End If

            If objRuta.moverEstadoDocumento(frmNuevoEstado.getEstadoDB, tipoAcc) Then
                Mensaje.Mensaje = "Se GUARDO correctamente..."
                objRuta.cargaGridCom(objDGVRuta, dgvRuta)
                TabControl1.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objRuta.descripError
            End If
            Mensaje.ShowDialog()
        End If

    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TabControl1.SelectedIndex = 1
        objRuta = New Ruta(Ambiente)
        asignaDatos()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "¿Realmente desea " & If(objRuta.estadoDocumento = "BO", "eliminar TODOS los datos", "CANCELAR todos los datos") & " de esta ruta?."

        If Mensaje.ShowDialog = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objRuta.eliminar() Then
                Mensaje.Mensaje = "Se ELIMINÓ/CANCELÓ la ruta correctamente..."
            Else
                Mensaje.Mensaje = objRuta.descripError
            End If
            Mensaje.ShowDialog()
            cargarGrid()

        End If
    End Sub

    Private Sub cargarGrid()
        TabControl1.SelectedIndex = 0
        objRuta.cargaGridCom(objDGVRuta, dgvRuta)
    End Sub
    Private Sub dgvRuta_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRuta.SelectionChanged
        If dgvRuta.SelectedRows.Count > 0 Then
            clicDatos(dgvRuta.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub btnOrigen_Click_1(sender As Object, e As EventArgs) Handles btnOrigen.Click
        FrmBuscaSucursal.Ambiente = Ambiente
        If FrmBuscaSucursal.ShowDialog() = DialogResult.OK Then
            txtIdSucOrigen.Text = FrmBuscaSucursal.objRetorno.idSucursal
            txtOrigen.Text = FrmBuscaSucursal.objRetorno.nombreSucursal
        End If
    End Sub

    Private Sub btnDestino_Click_1(sender As Object, e As EventArgs) Handles btnDestino.Click
        FrmBuscaSucursal.Ambiente = Ambiente
        If FrmBuscaSucursal.ShowDialog() = DialogResult.OK Then
            txtIdSucDest.Text = FrmBuscaSucursal.objRetorno.idSucursal
            txtDestino.Text = FrmBuscaSucursal.objRetorno.nombreSucursal
        End If
    End Sub

    Private Sub BtnEmpleado_Click_1(sender As Object, e As EventArgs) Handles BtnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            TxtIdEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            TxtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub btnCuenta_Click_1(sender As Object, e As EventArgs)
        frmBuscarCuentas.Ambiente = Ambiente
        If frmBuscarCuentas.ShowDialog() = DialogResult.OK Then
            TxtCuenta.Text = frmBuscarCuentas.idElemento
            TxtMonto.Text = frmBuscarCuentas.fechaFinal

        End If
    End Sub

    Private Sub dgvRuta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRuta.CellDoubleClick
        If dgvRuta.SelectedRows.Count > 0 Then
            clicDatos(dgvRuta.SelectedRows.Item(0).Index)
        End If
    End Sub
End Class