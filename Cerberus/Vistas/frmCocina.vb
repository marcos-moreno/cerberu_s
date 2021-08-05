Imports Cerberus

Public Class frmCocina
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private coci As Cocina

    Private objDgvCoci As New List(Of Cocina)
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private objCbHorario As New List(Of Horario)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            coci = New Cocina(Ambiente)
            coci.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = coci.nombreCocina
        txtTelefono.Text = coci.telefono
        txtCorreo.Text = coci.correo
        txtContacto.Text = coci.contacto
        txtUbicacion.Text = coci.ubicacionGeografica
        txtCostoComida.Text = coci.costoComida
        txtDescuento.Text = coci.descuentoXColaborador
        txtSancion.Text = coci.sancion
        esActivo.Checked = coci.esActivo
        esGeneral.Checked = coci.esGeneral
        txtObservaciones.Text = coci.observaciones

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = coci.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = coci.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        lblStatus.Text = coci.getDetalleMod()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        coci.nombreCocina = txtNombre.Text
        coci.telefono = txtTelefono.Text
        coci.correo = txtCorreo.Text
        coci.contacto = txtContacto.Text
        coci.ubicacionGeografica = txtUbicacion.Text
        coci.costoComida = txtCostoComida.Text
        coci.descuentoXColaborador = txtDescuento.Text
        coci.sancion = txtSancion.Text
        coci.esActivo = esActivo.Checked
        coci.esGeneral = esGeneral.Checked
        coci.observaciones = txtObservaciones.Text

        If cbSucursal.SelectedIndex <> -1 Then
            coci.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            coci.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            coci.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            coci.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            coci = objDgvCoci.Item(indice)
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

            txtNombre.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
    End Sub

    Private Sub frmCocina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        coci = New Cocina(Ambiente)
        coci.idEmpresa = Ambiente.empr.idEmpresa

        coci.cargaGridCom(DataGridView1, objDgvCoci)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        If Ambiente.usuario.desarrollador Then
            btnRepEmplXCocinaMod.Visible = True
        Else
            btnRepEmplXCocinaMod.Visible = False
        End If

        If Ambiente.usuario.desarrollador Then
            btnRepEmplXCocinaMod.Visible = True
            btnRepAsigCocinaMod.Visible = True
        Else
            btnRepEmplXCocinaMod.Visible = False
            btnRepAsigCocinaMod.Visible = False
        End If

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
            If Not coci.guardar() Then
                Mensaje.Mensaje = coci.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la cocina"
                nuevoReg = False
                operacion = True
            End If
        Else
            If Not coci.actualizar() Then
                Mensaje.Mensaje = coci.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la cocina"
                operacion = True
            End If
        End If
        Mensaje.ShowDialog()
        If operacion Then
            coci.cargaGridCom(DataGridView1, objDgvCoci)
            TabControl1.SelectTab(0)
            habilitarBotones()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la cocina: " & coci.nombreCocina & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            coci.eliminar()
            coci.cargaGridCom(DataGridView1, objDgvCoci)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Cocina"
        frmComentario.idTabla = coci.idCocina
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        coci.cargaGridCom(DataGridView1, objDgvCoci)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Cocina"
        frmLogTransaccion.idTabla = coci.idCocina
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

    Private Sub btnRepEmplXCocinaImp_Click(sender As Object, e As EventArgs) Handles btnRepEmplXCocinaImp.Click
        coci.RPT_ImprimirEmplXCocina()
    End Sub

    Private Sub btnRepEmplXCocinaMod_Click(sender As Object, e As EventArgs) Handles btnRepEmplXCocinaMod.Click
        coci.RPT_ModificarEmplXCocina()
    End Sub

    Private Sub btnRepAsigCocinaImp_Click(sender As Object, e As EventArgs) Handles btnRepAsigCocinaImp.Click
        coci.RPT_ImprimirAsigCocina()
    End Sub

    Private Sub btnRepAsigCocinaMod_Click(sender As Object, e As EventArgs) Handles btnRepAsigCocinaMod.Click
        coci.RPT_ModificarAsigCocina()
    End Sub
End Class