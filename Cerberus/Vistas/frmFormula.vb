Imports System.CodeDom.Compiler
Imports System.Reflection
Imports System.Text
Imports NCalc

Public Class frmFormula
    Private busqueda As String

    Private form As Formula
    Private varFor As VariableFormula
    Public Ambiente As AmbienteCls
    Private objDgvFor As New List(Of Formula)
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private objCbVarFor As New List(Of VariableFormula)
    Private nuevoReg As Boolean

    Private Sub frmFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTipoCalculo.SelectedIndex = 0

        form = New Formula(Ambiente)
        form.idEmpresa = Ambiente.empr.idEmpresa
        form.tipoCalculo = cbTipoCalculo.SelectedItem

        varFor = New VariableFormula(Ambiente)
        varFor.idEmpresa = Ambiente.empr.idEmpresa
        varFor.getComboActivo(cbElemento, objCbVarFor)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        form.cargaGridCom(DataGridView1, objDgvFor, busqueda)

        lblStatus.Text = ""
    End Sub

    Private Sub asignaDatos()
        If nuevoReg Then
            form = New Formula(Ambiente)
            form.idEmpresa = Ambiente.empr.idEmpresa
            form.tipoCalculo = cbTipoCalculo.SelectedItem
        End If

        RichTextBox1.Text = form.formula
        lblStatus.Text = form.getDetalleMod()
        txtOrden.Text = form.ordenEnReporte
        esImpreso.Checked = form.esImpreso

        cbElemento.SelectedIndex = -1
        For i As Integer = 0 To cbElemento.Items.Count - 1
            If objCbVarFor.Item(i).idVariableFormula = form.idVariableFormula Then
                cbElemento.SelectedIndex = i
                Exit For
            End If
        Next

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = form.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = form.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

    Private Sub obtenerDatos()
        form.formula = RichTextBox1.Text
        form.ordenEnReporte = txtOrden.Text
        form.esImpreso = esImpreso.Checked

        If cbElemento.SelectedIndex <> -1 Then
            form.idVariableFormula = objCbVarFor.Item(cbElemento.SelectedIndex).idVariableFormula
        Else
            form.idVariableFormula = Nothing
        End If

        If cbSucursal.SelectedIndex <> -1 Then
            form.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            form.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            form.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            form.idEmpresa = Nothing
        End If
    End Sub

    Private Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            form = objDgvFor.Item(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub habilitarBotones()
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
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
            If Not form.guardar() Then
                Mensaje.Mensaje = form.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la fórmula"
                nuevoReg = False
                operacion = True
            End If
        Else
            If Not form.actualizar() Then
                Mensaje.Mensaje = form.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la fórmula"
                operacion = True
            End If
        End If
        Mensaje.ShowDialog()
        If operacion Then
            form.cargaGridCom(DataGridView1, objDgvFor, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frmBuscar.Text = "..:: Buscar Fórmula ::.."
        frmBuscar.valorBuscado = ""
        If frmBuscar.ShowDialog = DialogResult.OK Then
            busqueda = frmBuscar.valorBuscado
            form.cargaGridCom(DataGridView1, objDgvFor, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la fórmula: " & form.getNombreVariableFormula().nombreVariable & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            form.eliminar()
            form.cargaGridCom(DataGridView1, objDgvFor, busqueda)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Formula"
        frmComentario.idTabla = form.idFormula
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click

    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        form.cargaGridCom(DataGridView1, objDgvFor, busqueda)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Formula"
        frmLogTransaccion.idTabla = form.idFormula
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

    Private Sub cbTipoCalculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoCalculo.SelectedIndexChanged
        If Not form Is Nothing Then
            form.tipoCalculo = cbTipoCalculo.SelectedItem
            form.cargaGridCom(DataGridView1, objDgvFor, busqueda)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmVariablesFormulas.MdiParent = Me.MdiParent
        frmVariablesFormulas.Show()
    End Sub
End Class