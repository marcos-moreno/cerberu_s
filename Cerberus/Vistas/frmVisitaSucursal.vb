Imports Cerberus

Public Class frmVisitaSucursal
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objVisita As VisitaSucursal
    Private objDGVVisita As New List(Of VisitaSucursal)

    Private objSalida As Traslado
    Private objRegreso As Traslado

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        Dim objSuc As New Sucursal(Ambiente)
        Dim objFPT As New FormaPagoTraslado(Ambiente)
        Dim objEmpl As New Empleado(Ambiente)
        objSalida = New Traslado(Ambiente)
        objRegreso = New Traslado(Ambiente)

        If objVisita.estado = "CO" Then
            txtEstado.BackColor = Color.GreenYellow
        Else
            txtEstado.BackColor = Color.Aquamarine
        End If

        ToolStripStatusLabel1.Text = "ID: " & objVisita.idVisitaSucursal
        txtEstado.Text = objVisita.getNombreEstado

        txtIDEmpleado.Text = objVisita.idEmpleado
        objEmpl.idEmpleado = objVisita.idEmpleado
        objEmpl.buscarPID()
        txtNombreEmpleado.Text = objEmpl.nombreCompleto

        txtIDSucOrigen.Text = objVisita.idSucOrigen
        objSuc.idSucursal = objVisita.idSucOrigen
        objSuc.buscarPID()
        txtNombreSucOrigen.Text = objSuc.nombreSucursal

        txtIdSucDestino.Text = objVisita.idSucDestino
        objSuc.idSucursal = objVisita.idSucDestino
        objSuc.buscarPID()
        txtNombreSucDestino.Text = objSuc.nombreSucursal

        txtHorasExtraAut.Text = objVisita.totalHorasAut

        txtIDFormaPago.Text = objVisita.idFormaPagoTraslado
        objFPT.idFormaPagoTraslado = objVisita.idFormaPagoTraslado
        objFPT.buscarPID()
        txtNombreFormaPago.Text = objFPT.nombreFormaPagoT

        If objVisita.sucursalPagaHorasExtra Then
            rbtnYes.Checked = True
        Else
            rbtnNot.Checked = True
        End If

        txtDescrip.Text = objVisita.descripcion

        objSalida.idVisita = objVisita.idVisitaSucursal
        objSalida.tipoTraslado = 1

        If objSalida.buscarPVisita() Then
            dtpSalidaSalida.Value = objSalida.salida
            dtpLlegadaSalida.Value = objSalida.llegada
        Else
            dtpSalidaSalida.Value = Now
            dtpLlegadaSalida.Value = Now
        End If

        txtTotalSalida.Text = objSalida.tiempoTraslado
        txtCuentaSalida.Text = objSalida.getCuenta.noDocumento
        txtTotalCuenta.Text = FormatCurrency(objSalida.getCuenta.monto)

        objRegreso.idVisita = objVisita.idVisitaSucursal
        objRegreso.tipoTraslado = 2

        If objRegreso.buscarPVisita() Then
            dtpSalidaRegreso.Value = objRegreso.salida
            dtpLlegadaRegreso.Value = objRegreso.llegada
        Else
            dtpSalidaRegreso.Value = Now
            dtpLlegadaRegreso.Value = Now
        End If

        txtTotalRegreso.Text = objRegreso.tiempoTraslado
        txtCuentaRegreso.Text = objRegreso.getCuenta.noDocumento
        txtTotalCuentaR.Text = FormatCurrency(objRegreso.getCuenta.monto)

        habilitarBotones()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objVisita.descripcion = txtDescrip.Text
        'objVisita.estado = ""
        objVisita.idEmpleado = txtIDEmpleado.Text
        objVisita.idEmpresa = Ambiente.empr.idEmpresa
        objVisita.idFormaPagoTraslado = txtIDFormaPago.Text
        objVisita.idSucOrigen = txtIDSucOrigen.Text
        objVisita.idSucDestino = txtIdSucDestino.Text
        objVisita.idSucursal = txtIdSucDestino.Text
        objVisita.salida = dtpSalidaSalida.Value
        objVisita.regreso = dtpLlegadaRegreso.Value 
        objVisita.sucursalPagaHorasExtra = rbtnYes.Checked
        objVisita.totalHorasAut = txtHorasExtraAut.Text
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        TabControl1.SelectedIndex = 1
        objVisita = objDGVVisita.Item(indice)
        asignaDatos()
    End Sub

    Private Sub cargarGrid()
        TabControl1.SelectedIndex = 0
        objVisita.cargaGridCom(dgvVisitas, objDGVVisita, anio_filter.SelectedValue)
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim estadoCtrls As Boolean

        If objVisita.estado = "CO" Then
            estadoCtrls = False
        Else
            estadoCtrls = True
        End If

        btnGuardar.Enabled = estadoCtrls

        BtnEmpleado.Enabled = estadoCtrls
        BtnSucDestino.Enabled = estadoCtrls
        BtnSucOrigen.Enabled = estadoCtrls
        txtHorasExtraAut.Enabled = estadoCtrls
        rbtnYes.Enabled = estadoCtrls
        rbtnNot.Enabled = estadoCtrls
        txtDescrip.Enabled = estadoCtrls
        btnFormaPagoT.Enabled = estadoCtrls

        dtpLlegadaRegreso.Enabled = estadoCtrls
        dtpSalidaRegreso.Enabled = estadoCtrls
        dtpLlegadaSalida.Enabled = estadoCtrls
        dtpSalidaSalida.Enabled = estadoCtrls

        btnSalida.Enabled = estadoCtrls
        btnRegreso.Enabled = estadoCtrls

        If objVisita.estado = Nothing Then
            gbSalida.Visible = False
            gbRegreso.Visible = False
        Else
            gbSalida.Visible = True
            gbRegreso.Visible = True
        End If
    End Sub

    Private Sub frmVisita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objVisita = New VisitaSucursal(Ambiente)
        objVisita.idEmpresa = Ambiente.empr.idEmpresa
        anio_filter.SelectedItem = Now.Year.ToString
        'objVisita.cargaGridCom(dgvVisitas, objDGVVisita, anio_filter.SelectedValue)
        dtpLlegadaRegreso.Value = Now
        dtpLlegadaSalida.Value = Now
        dtpSalidaRegreso.Value = Now
        dtpSalidaSalida.Value = Now
    End Sub

    Private Sub BtnEmpleado_Click(sender As Object, e As EventArgs) Handles BtnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub BtnSucOrigen_Click(sender As Object, e As EventArgs) Handles BtnSucOrigen.Click
        FrmBuscaSucursal.Ambiente = Ambiente
        If FrmBuscaSucursal.ShowDialog() = DialogResult.OK Then
            txtIDSucOrigen.Text = FrmBuscaSucursal.objRetorno.idSucursal
            txtNombreSucOrigen.Text = FrmBuscaSucursal.objRetorno.nombreSucursal
        End If
    End Sub

    Private Sub BtnSucDestino_Click(sender As Object, e As EventArgs) Handles BtnSucDestino.Click
        FrmBuscaSucursal.Ambiente = Ambiente
        If FrmBuscaSucursal.ShowDialog() = DialogResult.OK Then
            txtIdSucDestino.Text = FrmBuscaSucursal.objRetorno.idSucursal
            txtNombreSucDestino.Text = FrmBuscaSucursal.objRetorno.nombreSucursal
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnFormaPagoT.Click
        frmBuscaFormaPagoTraslado.Ambiente = Ambiente
        If frmBuscaFormaPagoTraslado.ShowDialog() = DialogResult.OK Then
            txtIDFormaPago.Text = frmBuscaFormaPagoTraslado.objRetorno.idFormaPagoTraslado
            txtNombreFormaPago.Text = frmBuscaFormaPagoTraslado.objRetorno.nombreFormaPagoT
        End If
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tipoAcc As Integer
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        frmNuevoEstado.setEstadoBD(objVisita.estado)
        If frmNuevoEstado.ShowDialog() = DialogResult.OK Then

            If objVisita.idVisitaSucursal = Nothing Then
                tipoAcc = 1
            Else
                tipoAcc = 2
            End If

            If frmNuevoEstado.getEstadoDB = "CO" Then
                If objSalida.idTraslado = Nothing And objSalida.idTraslado = Nothing Then
                    Mensaje.Mensaje = "Es necesario capture los datos de traslado a la SUCURSAL y REGRESO para poder continuar..."
                    Mensaje.ShowDialog()
                    Exit Sub
                End If
            End If

            If objVisita.moverEstadoDocuento(frmNuevoEstado.getEstadoDB, tipoAcc) Then
                Mensaje.Mensaje = "Se GUARDO correctamente..."
                anio_filter.SelectedIndex = -1
                objVisita.cargaGridCom(dgvVisitas, objDGVVisita, "")
                TabControl1.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objVisita.descripError
            End If

            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSalida.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        objSalida.idVisita = objVisita.idVisitaSucursal
        objSalida.salida = dtpSalidaSalida.Value
        objSalida.llegada = dtpLlegadaSalida.Value
        objSalida.tipoTraslado = 1
        objSalida.tiempoTraslado = txtTotalSalida.Text

        If objSalida.idTraslado = Nothing Then
            If objSalida.guardar() Then
                Mensaje.Mensaje = "Se GUARDO correctamente..."
            Else
                Mensaje.Mensaje = objSalida.descripError
            End If
        Else
            If objSalida.actualizar() Then
                Mensaje.Mensaje = "Se ACTUALIZO correctamente..."
            Else
                Mensaje.Mensaje = objSalida.descripError
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegreso.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        objRegreso.idVisita = objVisita.idVisitaSucursal
        objRegreso.salida = dtpSalidaRegreso.Value
        objRegreso.llegada = dtpLlegadaRegreso.Value
        objRegreso.tipoTraslado = 2
        objRegreso.tiempoTraslado = txtTotalRegreso.Text

        If objRegreso.idTraslado = Nothing Then
            If objRegreso.guardar() Then
                Mensaje.Mensaje = "Se GUARDO correctamente..."
            Else
                Mensaje.Mensaje = objRegreso.descripError
            End If
        Else
            If objRegreso.actualizar() Then
                Mensaje.Mensaje = "Se ACTUALIZO correctamente..."
            Else
                Mensaje.Mensaje = objRegreso.descripError
            End If
        End If

        Mensaje.ShowDialog()

    End Sub

    Private Sub dtpSalidaSalida_ValueChanged(sender As Object, e As EventArgs) Handles dtpSalidaSalida.ValueChanged
        calcularTiempo(txtTotalSalida, dtpSalidaSalida.Value, dtpLlegadaSalida.Value)
    End Sub

    Private Sub dtpLlegadaSalida_ValueChanged(sender As Object, e As EventArgs) Handles dtpLlegadaSalida.ValueChanged
        calcularTiempo(txtTotalSalida, dtpSalidaSalida.Value, dtpLlegadaSalida.Value)
    End Sub

    Public Sub calcularTiempo(txt As TextBox, inicio As Date, fin As Date)
        Dim total As Decimal
        total = DateDiff(DateInterval.Second, inicio, fin)
        total = (total / 60) / 60

        txt.Text = FormatNumber(total)
    End Sub

    Private Sub dtpSalidaRegreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpSalidaRegreso.ValueChanged
        calcularTiempo(txtTotalRegreso, dtpSalidaRegreso.Value, dtpLlegadaRegreso.Value)
    End Sub

    Private Sub dtpLlegadaRegreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpLlegadaRegreso.ValueChanged
        calcularTiempo(txtTotalRegreso, dtpSalidaRegreso.Value, dtpLlegadaRegreso.Value)
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        TabControl1.SelectedIndex = 1
        objVisita = New VisitaSucursal(Ambiente)
        asignaDatos()
    End Sub

    Private Sub dgvVisitas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvVisitas.SelectionChanged
        If dgvVisitas.SelectedRows.Count > 0 Then
            clicDatos(dgvVisitas.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "Realmente desea " & If(objVisita.estado = "BO", "eliminar TODOS los datos", "CANCELAR") & " esta visita."

        If Mensaje.ShowDialog = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objVisita.eliminar() Then
                Mensaje.Mensaje = "Se ELIMINO/CANCELO la visita correctamente..."
            Else
                Mensaje.Mensaje = objVisita.descripError
            End If

            Mensaje.ShowDialog()
            cargarGrid()
        End If
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "VisitaSucursal"
        frmArchivo.idTabla = objVisita.idVisitaSucursal
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub dgvVisitas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVisitas.CellDoubleClick
        If dgvVisitas.SelectedRows.Count > 0 Then
            clicDatos(dgvVisitas.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub Anio_filter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles anio_filter.SelectedIndexChanged
        objVisita.cargaGridCom(dgvVisitas, objDGVVisita, anio_filter.SelectedItem)
        TabControl1.SelectedIndex = 0
    End Sub
End Class