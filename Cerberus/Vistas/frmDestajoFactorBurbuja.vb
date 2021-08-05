Imports Cerberus

Public Class frmDestajoFactorBurbuja
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private dfb As DestajoFactorBurbuja
    Private objDgvDFB As New List(Of DestajoFactorBurbuja)

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            dfb = New DestajoFactorBurbuja(Ambiente)
            dfb.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = dfb.nombreFactor
        txtPorcentaje.Text = dfb.porcentajeFactor
        txtMinimo.Text = dfb.minBurbujas
        txtMaximo.Text = dfb.maxBurbujas

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = dfb.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = dfb.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        lblStatus.Text = dfb.getDetalleMod()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        dfb.nombreFactor = txtNombre.Text
        dfb.porcentajeFactor = txtPorcentaje.Text
        dfb.minBurbujas = txtMinimo.Text
        dfb.maxBurbujas = txtMaximo.Text

        If cbEmpresa.SelectedIndex <> -1 Then
            dfb.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            dfb.idEmpresa = Nothing
        End If
        If cbSucursal.SelectedIndex <> -1 Then
            dfb.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            dfb.idSucursal = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            dfb = objDgvDFB.Item(indice)
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

    Private Sub frmDestajoFactorBurbuja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dfb = New DestajoFactorBurbuja(Ambiente)
        dfb.idEmpresa = Ambiente.empr.idEmpresa
        dfb.cargaGridCom(DataGridView1, objDgvDFB)

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
            If Not dfb.guardar() Then
                Mensaje.Mensaje = dfb.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el factor"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not dfb.actualizar() Then
                Mensaje.Mensaje = dfb.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el factor"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            dfb.cargaGridCom(DataGridView1, objDgvDFB)
            habilitarBotones()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el factor: " & dfb.nombreFactor & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            dfb.eliminar()
            dfb.cargaGridCom(DataGridView1, objDgvDFB)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "DestajoFactorBurbuja"
        frmComentario.idTabla = dfb.idDestajoFactorBurbuja
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "DestajoFactorBurbuja"
        frmArchivo.idTabla = dfb.idDestajoFactorBurbuja
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        dfb.cargaGridCom(DataGridView1, objDgvDFB)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "DestajoFactorBurbuja"
        frmLogTransaccion.idTabla = dfb.idDestajoFactorBurbuja
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
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