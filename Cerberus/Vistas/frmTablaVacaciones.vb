Imports Cerberus

Public Class frmTablaVacaciones
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private tabVac As TablaVacaciones
    Private objDgvTabVac As New List(Of TablaVacaciones)

    Private objCbEmpr As New List(Of Empresa)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            tabVac = New TablaVacaciones(Ambiente)
            tabVac.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtDiasVacaciones.Text = tabVac.diasVacaciones
        txtAniosCumplidos.Text = tabVac.aniosCumplidos

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = tabVac.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        lblStatus.Text = tabVac.getDetalleMod()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        tabVac.aniosCumplidos = txtAniosCumplidos.Text
        tabVac.diasVacaciones = txtDiasVacaciones.Text

        If cbEmpresa.SelectedIndex <> -1 Then
            tabVac.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            tabVac.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            tabVac = objDgvTabVac.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
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
            If Not tabVac.guardar() Then
                Mensaje.Mensaje = tabVac.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la especificación"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not tabVac.actualizar() Then
                Mensaje.Mensaje = tabVac.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la especificación"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            tabVac.cargaGridCom(DataGridView1, objDgvTabVac)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el ID: " & tabVac.idTablaVacaciones & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            tabVac.eliminar()
            tabVac.cargaGridCom(DataGridView1, objDgvTabVac)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        tabVac.cargaGridCom(DataGridView1, objDgvTabVac)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "TablaVacaciones"
        frmLogTransaccion.idTabla = tabVac.idTablaVacaciones
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

    Private Sub frmTablaVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabVac = New TablaVacaciones(Ambiente)
        tabVac.idEmpresa = Ambiente.empr.idEmpresa

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)

        tabVac.cargaGridCom(DataGridView1, objDgvTabVac)
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