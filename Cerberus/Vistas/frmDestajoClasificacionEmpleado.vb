Imports Cerberus

Public Class frmDestajoClasificacionEmpleado
    Implements InterfaceVentanas

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Public Ambiente As AmbienteCls
    Private nuevoReg As Boolean

    Private dce As DestajoClasificacionEmpleado
    Private objDgvDCE As New List(Of DestajoClasificacionEmpleado)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            dce = New DestajoClasificacionEmpleado(Ambiente)
            dce.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = dce.nombreClasificacion
        txtPorcentaje.Text = dce.porcentajePago
        esActivo.Checked = dce.esActivo

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = dce.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = dce.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        lblStatus.Text = dce.getDetalleMod()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        dce.nombreClasificacion = txtNombre.Text
        dce.porcentajePago = txtPorcentaje.Text
        dce.esActivo = esActivo.Checked

        If cbEmpresa.SelectedIndex <> -1 Then
            dce.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            dce.idEmpresa = Nothing
        End If
        If cbSucursal.SelectedIndex <> -1 Then
            dce.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            dce.idSucursal = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            dce = objDgvDCE.Item(indice)
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

    Private Sub frmDestajoClasificacionEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dce = New DestajoClasificacionEmpleado(Ambiente)
        dce.idEmpresa = Ambiente.empr.idEmpresa

        dce.cargaGridCom(DataGridView1, objDgvDCE)

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
            If Not dce.guardar() Then
                Mensaje.Mensaje = dce.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la clasificación"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not dce.actualizar() Then
                Mensaje.Mensaje = dce.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la clasificación"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            dce.cargaGridCom(DataGridView1, objDgvDCE)
            habilitarBotones()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la clasificacion: " & dce.nombreClasificacion & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            dce.eliminar()
            dce.cargaGridCom(DataGridView1, objDgvDCE)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "DestajoClasificacionEmpeado"
        frmComentario.idTabla = dce.idDestajoClasificacionEmpeado
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "DestajoClasificacionEmpeado"
        frmArchivo.idTabla = dce.idDestajoClasificacionEmpeado
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        dce.cargaGridCom(DataGridView1, objDgvDCE)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "DestajoClasificacionEmpeado"
        frmLogTransaccion.idTabla = dce.idDestajoClasificacionEmpeado
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