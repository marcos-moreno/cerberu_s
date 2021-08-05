Imports Cerberus

Public Class frmDestajoUnionEmpleado
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls

    Private empl As Empleado

    Private ori As Origen
    Private objCbOri As New List(Of Origen)

    Private due As DestajoUnionEmpleado
    Private objDgvDUE As New List(Of DestajoUnionEmpleado)

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            due = New DestajoUnionEmpleado(Ambiente)
            due.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtReferencia.Text = due.referenciaExterna
        esActivo.Checked = due.esActivo

        empl = New Empleado(Ambiente)
        empl.idEmpresa = Ambiente.empr.idEmpresa
        empl.idEmpleado = due.idEmpleado
        empl.buscarPID()

        txtIDEmpleado.Text = empl.idEmpleado
        txtNombreEmpleado.Text = empl.nombreCompleto

        lblStatus.Text = due.getDetalleMod()

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = due.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = due.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        'cbOrigen.SelectedIndex = -1
        For i As Integer = 0 To cbOrigen.Items.Count - 1
            If objCbOri.Item(i).origen = due.origen Then
                cbOrigen.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos

        due.referenciaExterna = txtReferencia.Text
        due.esActivo = esActivo.Checked
        due.origen = cbOrigen.SelectedItem
        due.idEmpleado = txtIDEmpleado.Text

        If cbSucursal.SelectedIndex <> -1 Then
            due.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            due.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            due.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            due.idEmpresa = Nothing
        End If
        If cbOrigen.SelectedIndex <> -1 Then
            due.origen = objCbOri.Item(cbOrigen.SelectedIndex).origen
        Else
            due.origen = Nothing
        End If

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            due = objDgvDUE.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False

            txtReferencia.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
    End Sub

    Private Sub frmDestajoUnionEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ori = New Origen(Ambiente)
        ori.idEmpresa = Ambiente.empr.idEmpresa
        ori.elemento = "Destajo"
        ori.getComboActivo(cbOrigen, objCbOri)

        due = New DestajoUnionEmpleado(Ambiente)
        due.idEmpresa = Ambiente.empr.idEmpresa
        due.origen = cbOrigen.SelectedItem
        due.cargaGridCom(dgvDestajoUnionEmp, objDgvDUE)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)
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
            If Not due.guardar() Then
                Mensaje.Mensaje = due.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente la unión"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not due.actualizar() Then
                Mensaje.Mensaje = due.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente la unión"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            due.cargaGridCom(dgvDestajoUnionEmp, objDgvDUE)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la union: " & due.idEmpleado & "/" & due.referenciaExterna & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If due.eliminar() Then
                due.cargaGridCom(dgvDestajoUnionEmp, objDgvDUE)
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = due.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "DestajoUnionEmpleado"
        frmComentario.idTabla = due.referenciaExterna
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        due.cargaGridCom(dgvDestajoUnionEmp, objDgvDUE)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "DestajoUnionEmpleado"
        frmLogTransaccion.idTabla = due.referenciaExterna
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvDestajoUnionEmp.SelectedRows.Item(0).Index <> 0 Then
            dgvDestajoUnionEmp.Rows(dgvDestajoUnionEmp.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvDestajoUnionEmp.SelectedRows.Item(0).Index <> dgvDestajoUnionEmp.Rows.Count - 1 Then
            dgvDestajoUnionEmp.Rows(dgvDestajoUnionEmp.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDestajoUnionEmp.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvCuentas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDestajoUnionEmp.SelectionChanged
        If dgvDestajoUnionEmp.SelectedRows.Count > 0 Then
            clicDatos(dgvDestajoUnionEmp.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub cbOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOrigen.SelectedIndexChanged
        If cbOrigen.SelectedIndex <> -1 And Not due Is Nothing Then
            due.origen = cbOrigen.SelectedItem
            due.cargaGridCom(dgvDestajoUnionEmp, objDgvDUE)
        End If
    End Sub
End Class