Imports Cerberus

Public Class frmTipoIncidencia
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public nuevoReg As Boolean

    Private objTipoIncidencia As TipoIncidencia
    Private objCGVTipoIncidencia As New List(Of TipoIncidencia)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            objTipoIncidencia = New TipoIncidencia(Ambiente)
            objTipoIncidencia.idEmpresa = Ambiente.empr.idEmpresa

            chbDefault.Enabled = False
        End If

        habilitarBotones()

        txtCodigo.Text = objTipoIncidencia.codigoIncidencia
        txtNombreIncidencia.Text = objTipoIncidencia.nombreIncidencia

        chbEsActiva.Checked = objTipoIncidencia.esActivo
        chbDefault.Checked = objTipoIncidencia.isDefault
        chbCalculada.Checked = objTipoIncidencia.calculada
        chbIncidenciaXDia.Checked = objTipoIncidencia.incidenciaXDia

        txtTolerancia.Text = objTipoIncidencia.tolerancia
        txtIDIincCTPQ.Text = objTipoIncidencia.idTipoIncidenciaCTPQ
        txtNombreInciCTPQ.Text = objTipoIncidencia.nombreCTPQ
        chbPrimaVac.Checked = objTipoIncidencia.pagaPrimaVac
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objTipoIncidencia.codigoIncidencia = txtCodigo.Text
        objTipoIncidencia.nombreIncidencia = txtNombreIncidencia.Text

        objTipoIncidencia.esActivo = chbEsActiva.Checked
        objTipoIncidencia.calculada = chbCalculada.Checked
        objTipoIncidencia.isDefault = chbDefault.Checked
        objTipoIncidencia.tolerancia = If(IsNumeric(txtTolerancia.Text), txtTolerancia.Text, 0)
        objTipoIncidencia.incidenciaXDia = chbIncidenciaXDia.Checked

        objTipoIncidencia.idTipoIncidenciaCTPQ = txtIDIincCTPQ.Text
        objTipoIncidencia.nombreCTPQ = txtNombreInciCTPQ.Text
        objTipoIncidencia.pagaPrimaVac = chbPrimaVac.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        objTipoIncidencia = objCGVTipoIncidencia(indice)

        asignaDatos()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If objTipoIncidencia.isDefault Then
            txtCodigo.ReadOnly = True
            BtnEliminar.Enabled = False
            'chbDefault.Enabled = False
            chbEsActiva.Enabled = False
            chbIncidenciaXDia.Enabled = False

        Else
            txtCodigo.ReadOnly = False
            BtnEliminar.Enabled = True
            'chbDefault.Enabled = True
            chbEsActiva.Enabled = True
            chbIncidenciaXDia.Enabled = True
        End If

        If txtCodigo.Text = "VD" Then
            chbPrimaVac.Enabled = True
        Else
            chbPrimaVac.Enabled = False
        End If


        If txtCodigo.Text = "RE" Then
            txtTolerancia.Text = 0
            txtTolerancia.Visible = True
            lblTolerancia.Visible = True
        Else
            txtTolerancia.Text = 0
            txtTolerancia.Visible = False
            lblTolerancia.Visible = False
        End If

    End Sub

    Private Sub frmTipoIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objTipoIncidencia = New TipoIncidencia(Ambiente)
        objTipoIncidencia.idEmpresa = Ambiente.empr.idEmpresa
        objTipoIncidencia.cargaGridGen(dgvTipoIncidencia, objCGVTipoIncidencia)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmIncidenciasCTPQ.Ambiente = Ambiente
        If frmIncidenciasCTPQ.ShowDialog() = DialogResult.OK Then
            txtIDIincCTPQ.Text = frmIncidenciasCTPQ.idRetorno
            txtNombreInciCTPQ.Text = frmIncidenciasCTPQ.nombreRetorno
        End If
    End Sub

    Private Sub dgvRuta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipoIncidencia.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvRuta_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTipoIncidencia.SelectionChanged
        If dgvTipoIncidencia.SelectedRows.Count > 0 Then
            clicDatos(dgvTipoIncidencia.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not objTipoIncidencia.guardar() Then
                Mensaje.Mensaje = objTipoIncidencia.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente"
                nuevoReg = False
            End If
        Else
            If Not objTipoIncidencia.actualizar() Then
                Mensaje.Mensaje = objTipoIncidencia.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente"
            End If
        End If
        Mensaje.ShowDialog()

        objTipoIncidencia.cargaGridGen(dgvTipoIncidencia, objCGVTipoIncidencia)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If Not objTipoIncidencia.eliminar() Then
            Mensaje.Mensaje = objTipoIncidencia.descripError
        Else
            Mensaje.Mensaje = "Se ELIMINO Correctamente"
        End If

        Mensaje.ShowDialog()
    End Sub
End Class