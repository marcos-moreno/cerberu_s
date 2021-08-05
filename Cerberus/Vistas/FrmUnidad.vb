Imports Cerberus

Public Class FrmUnidad
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objUnidad As Unidad
    Private objDGVUnidad As New List(Of Unidad)
    Private objCuenta As frmCuenta
    Private objConceptoCuenta As ConceptoCuenta

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        Dim objSuc As New Sucursal(Ambiente)
        Dim objEmpleado As New Empleado(Ambiente)

        objEmpleado.idEmpleado = objUnidad.asignadoA
        objEmpleado.buscarPID()

        objSuc.idSucursal = objUnidad.idSucursal
        objSuc.buscarPID()

        txtPlaca.Text = objUnidad.placa
        txtMarca.Text = objUnidad.marca
        txtModelo.Text = objUnidad.modelo


        If objUnidad.generaCobro Then
            RdSi.Checked = True
        Else
            RdNo.Checked = True
        End If

        txtNumTagAsignado.Text = objUnidad.numTagAsignado
        txtNumTarjetaGasolina.Text = objUnidad.numTarjetaGasolina
        txtPorcentajeDescuento.Text = objUnidad.porcentajeDescuento

        txtIdEmpleado.Text = objEmpleado.idEmpleado
        txtNombreEmpleado.Text = objEmpleado.nombreCompleto
        txtComentario.Text = objUnidad.comentario

        objConceptoCuenta = New ConceptoCuenta(Ambiente)
        objConceptoCuenta.idConceptoCuenta = objUnidad.idConceptoCuenta
        objConceptoCuenta.buscarPID()

        TxtIdConceptoCuenta.Text = objConceptoCuenta.idConceptoCuenta
        TxtNombreConcepto.Text = objConceptoCuenta.nombreConceptoCuenta

        txtIDSuc.Text = objSuc.idSucursal
        txtNombreSucursal.Text = objSuc.nombreSucursal
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objUnidad.asignadoA = If(IsDBNull(txtIdEmpleado.Text), Nothing, txtIdEmpleado.Text)
        objUnidad.placa = txtPlaca.Text
        objUnidad.marca = txtMarca.Text
        objUnidad.modelo = txtModelo.Text

        If RdSi.Checked Then
            objUnidad.generaCobro = True
        ElseIf RdNo.Checked Then
            objUnidad.generaCobro = False
        End If

        objUnidad.numTagAsignado = txtNumTagAsignado.Text
        objUnidad.numTarjetaGasolina = txtNumTarjetaGasolina.Text
        objUnidad.porcentajeDescuento = txtPorcentajeDescuento.Text

        objUnidad.comentario = txtComentario.Text
        objUnidad.idConceptoCuenta = TxtIdConceptoCuenta.Text
        objUnidad.idSucursal = txtIDSuc.Text

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        TabUnidad.SelectedIndex = 1
        objUnidad = objDGVUnidad.Item(indice)
        asignaDatos()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        If frmBuscaEmpleado.ShowDialog = DialogResult.OK Then
            txtIdEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub FrmUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objUnidad = New Unidad(Ambiente)
        objUnidad.idEmpresa = Ambiente.empr.idEmpresa
        objUnidad.cargaGridCom(objDGVUnidad, dgvUnidad)

        objCuenta = New frmCuenta()
    End Sub

    Private Sub dgvUnidad_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnidad.CellDoubleClick
        If dgvUnidad.SelectedRows.Count > 0 Then
            clicDatos(dgvUnidad.SelectedRows.Item(0).Index)
        End If

    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TabUnidad.SelectedIndex = 1
        objUnidad = New Unidad(Ambiente)
        asignaDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos()
        Dim tipoAcc As Integer

        If objUnidad.idUnidad = Nothing Then
            tipoAcc = 1
        Else
            tipoAcc = 2
        End If

        If tipoAcc = 1 Then
            If objUnidad.guardar() Then
                objUnidad.cargaGridCom(objDGVUnidad, dgvUnidad)
                Mensaje.Mensaje = "Se GUARDO correctamente..."
                TabUnidad.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objUnidad.descripError
            End If
        ElseIf tipoAcc = 2 Then
            If objUnidad.actualizar() Then
                Mensaje.Mensaje = "Se Actualizó correctamente..."
                objUnidad.cargaGridCom(objDGVUnidad, dgvUnidad)
                TabUnidad.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objUnidad.descripError
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "¿Realmente desea eliminar esta unidad?"

        If Mensaje.ShowDialog = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objUnidad.eliminar Then
                Mensaje.Mensaje = "Se eliminó correctamente la unidad"
            Else
                Mensaje.Mensaje = objUnidad.descripError
            End If
            Mensaje.ShowDialog()
            objUnidad.cargaGridCom(objDGVUnidad, dgvUnidad)
            TabUnidad.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        MsgBox("Adjuntos")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxC"
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"
        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            TxtIdConceptoCuenta.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            TxtNombreConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If

    End Sub

    Private Sub RecargarGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarGridToolStripMenuItem.Click
        objUnidad.cargaGridCom(objDGVUnidad, dgvUnidad)
    End Sub

    Private Sub RdNo_CheckedChanged(sender As Object, e As EventArgs) Handles RdNo.CheckedChanged
        txtPorcentajeDescuento.Text = 100
        txtPorcentajeDescuento.ReadOnly = True
    End Sub

    Private Sub RdSi_CheckedChanged(sender As Object, e As EventArgs) Handles RdSi.CheckedChanged
        txtPorcentajeDescuento.Text = objUnidad.porcentajeDescuento
        txtPorcentajeDescuento.ReadOnly = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmBuscaSucursal.Ambiente = Ambiente
        If FrmBuscaSucursal.ShowDialog() = DialogResult.OK Then
            txtIDSuc.Text = FrmBuscaSucursal.objRetorno.idSucursal
            txtNombreSucursal.Text = FrmBuscaSucursal.objRetorno.nombreSucursal
        End If
    End Sub
End Class