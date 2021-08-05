Imports Cerberus

Public Class frmConceptoCuenta
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private conCuen As ConceptoCuenta
    Private objDgvCC As New List(Of ConceptoCuenta)
    Private objCbCC As New List(Of ConceptoCuenta)

    Private objCbSuc As New List(Of Sucursal)
    Private objCbEmpr As New List(Of Empresa)

    Private busqueda As String
    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            conCuen = New ConceptoCuenta(Ambiente)
            conCuen.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = conCuen.nombreConceptoCuenta
        cbTipoCuenta.SelectedItem = conCuen.tipoCuenta
        esActivo.Checked = conCuen.esActivo
        chkExcedentes.Checked = conCuen.esPagoDeExcedentes
        chkReservado.Checked = conCuen.esReservado

        lblStatus.Text = conCuen.getDetalleMod()

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = conCuen.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = conCuen.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        conCuen.nombreConceptoCuenta = txtNombre.Text
        conCuen.esActivo = esActivo.Checked
        conCuen.tipoCuenta = cbTipoCuenta.SelectedItem
        conCuen.esPagoDeExcedentes = chkExcedentes.Checked
        conCuen.esReservado = chkReservado.Checked

        If cbSucursal.SelectedIndex <> -1 Then
            conCuen.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            conCuen.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            conCuen.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            conCuen.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            conCuen = objDgvCC.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
            btnReportes.Enabled = False
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
            btnReportes.Enabled = True
        End If
    End Sub

    Private Sub frmConceptoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conCuen = New ConceptoCuenta(Ambiente)
        conCuen.idEmpresa = Ambiente.empr.idEmpresa

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        conCuen.cargaGridCom(DataGridView1, objDgvCC, busqueda)

        lblStatus.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Dim operacion As Boolean = False
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not conCuen.guardar() Then
                Mensaje.Mensaje = conCuen.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la fórmula"
                nuevoReg = False
                operacion = True
            End If
        Else
            If Not conCuen.actualizar() Then
                Mensaje.Mensaje = conCuen.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la fórmula"
                operacion = True
            End If
        End If
        Mensaje.ShowDialog()
        If operacion Then
            conCuen.cargaGridCom(DataGridView1, objDgvCC, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frmBuscar.Text = "..:: Buscar Concepto ::.."
        frmBuscar.valorBuscado = ""
        If frmBuscar.ShowDialog = DialogResult.OK Then
            busqueda = frmBuscar.valorBuscado
            conCuen.cargaGridCom(DataGridView1, objDgvCC, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el concepto: " & conCuen.nombreConceptoCuenta & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            conCuen.eliminar()
            conCuen.cargaGridCom(DataGridView1, objDgvCC, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "ConceptoCuenta"
        frmComentario.idTabla = conCuen.idConceptoCuenta
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click

    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click

    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        conCuen.cargaGridCom(DataGridView1, objDgvCC, busqueda)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "ConceptoCuenta"
        frmLogTransaccion.idTabla = conCuen.idConceptoCuenta
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub
End Class