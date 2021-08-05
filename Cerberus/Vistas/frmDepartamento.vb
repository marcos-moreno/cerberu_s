Public Class frmDepartamento
    Private dep As Departamento
    Public Ambiente As AmbienteCls
    Private objDgvDep As New List(Of Departamento)
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private nuevoReg As Boolean

    Private nuevoRegArea As Boolean
    Private objDgvArea As New List(Of Area)
    Private area As Area

    Private Sub frmDepartamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dep = New Departamento(Ambiente)
        dep.idEmpresa = Ambiente.empr.idEmpresa
        dep.cargaGridCom(DataGridView1, objDgvDep)
        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)
        lblStatus.Text = ""
    End Sub

    Private Sub asignaDatos()
        If nuevoReg Then
            dep = New Departamento(Ambiente)
            dep.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = dep.nombreDepartamento
        txtNombreLider.Text = dep.nombreLider
        txtAltaDireccion.Text = dep.altaDireccion
        txtFirmaConcenEntrega.Text = dep.firmaConcenEntrega
        esActivo.Checked = dep.esActivo

        lblStatus.Text = dep.getDetalleMod()
        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = dep.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = dep.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        cargarGridArea()
    End Sub

    Public Sub cargarGridArea()
        area = New Area(Ambiente)
        area.idEmpresa = Ambiente.empr.idEmpresa
        area.idDepartamento = dep.idDepartamento

        area.cargaGridCom(dgvArea, objDgvArea)
    End Sub

    Public Sub asignaDatosArea()
        If nuevoRegArea Then
            area = New Area(Ambiente)
            area.idEmpresa = Ambiente.empr.idEmpresa
            area.idDepartamento = dep.idDepartamento
        End If

        txtNombreArea.Text = area.nombreArea
        txtDescripArea.Text = area.descripcion
        esActivoArea.Checked = area.esActivo
    End Sub

    Public Sub obtenerDatosArea()
        area.nombreArea = txtNombreArea.Text
        area.descripcion = txtDescripArea.Text
        area.esActivo = esActivoArea.Checked
    End Sub

    Private Sub obtenerDatos()
        dep.nombreDepartamento = txtNombre.Text
        dep.nombreLider = txtNombreLider.Text
        dep.firmaConcenEntrega = txtFirmaConcenEntrega.Text
        dep.altaDireccion = txtAltaDireccion.Text
        dep.esActivo = esActivo.Checked
        If cbSucursal.SelectedIndex <> -1 Then
            dep.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            dep.idSucursal = Nothing
        End If
        If cbEmpresa.SelectedIndex <> -1 Then
            dep.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            dep.idEmpresa = Nothing
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            dep = objDgvDep.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub clicDatosArea(indice As Integer)
        If indice <> -1 Then
            nuevoRegArea = False
            area = objDgvArea.Item(indice)
            asignaDatosArea()
        End If
    End Sub

    Private Sub habilitarBotones()
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnReportes.Enabled = False
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
            btnReportes.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el departamento: " & dep.nombreDepartamento & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            dep.eliminar()
            dep.cargaGridCom(DataGridView1, objDgvDep)
            TabControl1.SelectTab(0)
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
            If Not dep.guardar() Then
                Mensaje.Mensaje = dep.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el departamento"
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not dep.actualizar() Then
                Mensaje.Mensaje = dep.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el departamento"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            dep.cargaGridCom(DataGridView1, objDgvDep)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Departamento"
        frmComentario.idTabla = dep.idDepartamento
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "Departamento"
        frmArchivo.idTabla = dep.idDepartamento
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem1.Click
        dep.RPT_ImprimirDatos()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        dep.RPT_ModificarDatos()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        dep.cargaGridCom(DataGridView1, objDgvDep)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Departamento"
        frmLogTransaccion.idTabla = dep.idDepartamento
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

    Private Sub dgvArea_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArea.CellDoubleClick
        clicDatosArea(e.RowIndex)
        TabControl2.SelectTab(1)
    End Sub

    Private Sub dgvArea_SelectionChanged(sender As Object, e As EventArgs) Handles dgvArea.SelectionChanged
        If dgvArea.SelectedRows.Count > 0 Then
            clicDatosArea(dgvArea.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub btnNuevaArea_Click(sender As Object, e As EventArgs) Handles btnNuevaArea.Click
        nuevoRegArea = True
        asignaDatosArea()
        TabControl2.SelectTab(1)
    End Sub

    Private Sub btnGuardarArea_Click(sender As Object, e As EventArgs) Handles btnGuardarArea.Click
        Dim operacion As Boolean = True
        obtenerDatosArea()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoRegArea Then
            If Not area.guardar() Then
                Mensaje.Mensaje = area.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el área"
                nuevoRegArea = False
                operacion = False
            End If
        Else
            If Not area.actualizar() Then
                Mensaje.Mensaje = area.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el área"
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()

        If Not operacion Then
            area.cargaGridCom(dgvArea, objDgvArea)
            TabControl2.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminarArea_Click(sender As Object, e As EventArgs) Handles btnEliminarArea.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el área: " & area.nombreArea & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            area.eliminar()
            area.cargaGridCom(dgvArea, objDgvArea)
            TabControl2.SelectTab(0)
        End If
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        frmAsignaLiderDepto.Ambiente = Ambiente
        frmAsignaLiderDepto.departamento = dep
        frmAsignaLiderDepto.Show()
    End Sub
End Class