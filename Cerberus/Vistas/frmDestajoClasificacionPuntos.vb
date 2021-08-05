Imports Cerberus

Public Class frmDestajoClasificacionPuntos
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private dcp As DestajoClasificacionPuntos
    Private objDgvDCP As New List(Of DestajoClasificacionPuntos)

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private eta As Etapa
    Private objCbEta As New List(Of Etapa)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            dcp = New DestajoClasificacionPuntos(Ambiente)
        End If

        txtNombre.Text = dcp.nombreClasificacion
        txtPuntos.Text = dcp.numPuntos
        txtMonto.Text = dcp.montoPagoClasificacion
        esActivo.Checked = dcp.esActivo

        cbEtapa.SelectedIndex = -1
        For i As Integer = 0 To cbEtapa.Items.Count - 1
            If objCbEta.Item(i).idEtapa = dcp.idEtapa Then
                cbEtapa.SelectedIndex = i
                Exit For
            End If
        Next

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = dcp.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = dcp.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        dcp.nombreClasificacion = txtNombre.Text
        dcp.numPuntos = txtPuntos.Text
        dcp.montoPagoClasificacion = txtMonto.Text
        dcp.esActivo = esActivo.Checked

        If cbEtapa.SelectedIndex <> -1 Then
            dcp.idEtapa = objCbEta.Item(cbEtapa.SelectedIndex).idEtapa
        Else
            dcp.idEtapa = Nothing
        End If
        If cbSucursal.SelectedIndex <> -1 Then
            dcp.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            dcp.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            dcp.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            dcp.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            dcp = objDgvDCP.Item(indice)
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

    Private Sub frmDestajoClasificacionPuntos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dcp = New DestajoClasificacionPuntos(Ambiente)

        eta = New Etapa(Ambiente)
        eta.idEmpresa = Ambiente.empr.idEmpresa
        eta.getComboActivo(cbEtapa, objCbEta)

        dcp.cargaGridCom(DataGridView1, objDgvDCP)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        lblStatus.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Dim operacion As Boolean = True
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not dcp.guardar() Then
                Mensaje.Mensaje = dcp.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la clasificación"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not dcp.actualizar() Then
                Mensaje.Mensaje = dcp.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la clasificacion"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            dcp.cargaGridCom(DataGridView1, objDgvDCP)
            habilitarBotones()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la clasificación: " & dcp.nombreClasificacion & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            dcp.eliminar()
            dcp.cargaGridCom(DataGridView1, objDgvDCP)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "DestajoClasificacionPuntos"
        frmComentario.idTabla = dcp.idDestajoClasificacionPuntos
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "DestajoClasificacionPuntos"
        frmArchivo.idTabla = dcp.idDestajoClasificacionPuntos
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        dcp.cargaGridCom(DataGridView1, objDgvDCP)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "DestajoClasificacionPuntos"
        frmLogTransaccion.idTabla = dcp.idDestajoClasificacionPuntos
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