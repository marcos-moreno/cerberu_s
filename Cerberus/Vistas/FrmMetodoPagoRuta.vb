Imports Cerberus

Public Class FrmMetodoPagoRuta
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls
    Private objMetodoPago As MetodoPagoRuta
    Private objDGVMetodoPago As New List(Of MetodoPagoRuta)
    Dim tipoMetodoCaracter(1) As String
    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        tipoMetodoCaracter(0) = CmTipoMetodo.Text
        objMetodoPago.inicioKm = txtKMInicio.Text
        objMetodoPago.finKm = TxtKMFin.Text
        objMetodoPago.tipoMetodo = tipoMetodoCaracter(0).Chars(0)
        objMetodoPago.valorMetodo = txtValorMetodo.Text
        objMetodoPago.idConceptoCuenta = TxtIdCuenta.Text
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        TabMetodoPago.SelectedIndex = 1
        objMetodoPago = objDGVMetodoPago.Item(indice)
        asignaDatos()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Throw New NotImplementedException()
    End Sub

    Private Sub FrmMetodoPagoRuta_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        objMetodoPago = New MetodoPagoRuta(Ambiente)
        objMetodoPago.idEmpresa = Ambiente.empr.idEmpresa
        objMetodoPago.cargarGridComp(objDGVMetodoPago, dgvMetodoPagoRuta)

        cargarCombo()
    End Sub

    Private Sub cargarCombo()
        Dim elementos(1) As String
        elementos(0) = "Fijo"
        elementos(1) = "Porcentaje"

        For Each elem As String In elementos
            CmTipoMetodo.Items.Add(elem)
        Next
    End Sub

    Private Sub cargarGrid()
        TabMetodoPago.SelectedIndex = 0
        objMetodoPago.cargarGridComp(objDGVMetodoPago, dgvMetodoPagoRuta)
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "¿Realmente desea eliminar este método de pago?"

        If Mensaje.ShowDialog = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objMetodoPago.eliminar Then
                Mensaje.Mensaje = "Se eliminó el método de pago correctamente"
            Else
                Mensaje.Mensaje = objMetodoPago.descripError
            End If
            Mensaje.ShowDialog()
            cargarGrid()
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TabMetodoPago.SelectedIndex = 1
        objMetodoPago = New MetodoPagoRuta(Ambiente)
        asignaDatos()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos()
        Dim tipoAcc As Integer
        Dim esInsert As Boolean

        If objMetodoPago.idMetodoPago = Nothing Then
            tipoAcc = 1
        Else
            tipoAcc = 2
        End If


        If tipoAcc = 1 Then
            If objMetodoPago.validaDatos(esInsert) Then
                If objMetodoPago.guardar() Then
                    objMetodoPago.cargarGridComp(objDGVMetodoPago, dgvMetodoPagoRuta)
                    Mensaje.Mensaje = "Se GUARDO correctamente..."
                    TabMetodoPago.SelectedIndex = 0
                Else
                    Mensaje.Mensaje = objMetodoPago.descripError
                End If
            Else
                Mensaje.Mensaje = "Favor de ingresar todos los campos necesarios"
            End If
        ElseIf tipoAcc = 2 Then
            If objMetodoPago.actualizar() Then
                Mensaje.Mensaje = "Se Actualizó correctamente..."
                objMetodoPago.cargarGridComp(objDGVMetodoPago, dgvMetodoPagoRuta)
                TabMetodoPago.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objMetodoPago.descripError
            End If
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        Dim objCCuenta As New ConceptoCuenta(Ambiente)

        txtKMInicio.Text = objMetodoPago.inicioKm
        TxtKMFin.Text = objMetodoPago.finKm
        txtValorMetodo.Text = objMetodoPago.valorMetodo
        TxtIdCuenta.Text = objMetodoPago.idConceptoCuenta

        'Chech
        CmTipoMetodo.SelectedItem = objMetodoPago.getNombreMeotodo

        objCCuenta.idConceptoCuenta = objMetodoPago.idConceptoCuenta
        objCCuenta.buscarPID()
        TxtNombreCuenta.Text = objCCuenta.nombreConceptoCuenta

    End Sub

    Private Sub dgvMetodoPagoRuta_CellDoubleClick(sender As Object, e As System.EventArgs) Handles dgvMetodoPagoRuta.CellDoubleClick
        If dgvMetodoPagoRuta.SelectedRows.Count > 0 Then
            clicDatos(dgvMetodoPagoRuta.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub dgvMetodoPagoRuta_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvMetodoPagoRuta.SelectionChanged
        If dgvMetodoPagoRuta.SelectedRows.Count > 0 Then
            clicDatos(dgvMetodoPagoRuta.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub BtnIdCuenta_Click(sender As Object, e As EventArgs) Handles BtnIdCuenta.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxP"
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"
        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            TxtIdCuenta.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            TxtNombreCuenta.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub
End Class