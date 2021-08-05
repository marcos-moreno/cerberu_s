Imports Cerberus

Public Class frmPuestos
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public objPuesto As Puesto
    Private listobjPuesto As New List(Of Puesto)
    Private nuevoReg As Boolean



    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            txtNombrePuesto.Text = ""
            activo.Checked = False
        Else
            txtNombrePuesto.Text = objPuesto.puesto
            activo.Checked = objPuesto.esActivo
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objPuesto.puesto = txtNombrePuesto.Text
        objPuesto.esActivo = activo.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        objPuesto = listobjPuesto(indice)
        asignaDatos()

    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones

    End Sub

    Private Sub frmPuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPuesto = New Puesto(Ambiente)
        objPuesto.idEmpresa = Ambiente.empr.idEmpresa
        buscarActivod.Checked = True
        nuevoReg = False
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        If buscarActivod.Checked Then
            objPuesto.cargaGridCom(dgvPuesto, listobjPuesto, "", 1)
        Else
            objPuesto.cargaGridCom(dgvPuesto, listobjPuesto, "", 0)
        End If
        'objPuesto.cargaGridCom(dgvPuesto, listobjPuesto, "", 1)
        'buscarActivod.Checked = True
    End Sub

    Private Sub dgvPuest_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuesto.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvSucs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPuesto.SelectionChanged
        If dgvPuesto.SelectedRows.Count > 0 Then
            clicDatos(dgvPuesto.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        If nuevoReg Then
            If objPuesto.guardar() Then
                Mensaje.Mensaje = "Puesto creado correctamente..."
            Else
                Mensaje.Mensaje = objPuesto.descripError
            End If
        Else
            If objPuesto.actualizar Then
                Mensaje.Mensaje = "Puesto actualizado correctamente..."
            Else
                Mensaje.Mensaje = objPuesto.descripError
            End If
        End If

        Mensaje.ShowDialog()
        cargarDatos()
        habilitarBotones()
        TabControl1.SelectTab(0)

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        objPuesto = New Puesto(Ambiente)
        objPuesto.idEmpresa = Ambiente.empr.idEmpresa
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "¿Realmente desea eliminar el Puesto: " & objPuesto.puesto & "?"
        If Mensaje.ShowDialog() = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objPuesto.eliminar() Then
                Mensaje.Mensaje = "Puesto eliminado correctamente..."
                cargarDatos()
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = objPuesto.descripError
            End If
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub BuscarActivod_CheckedChanged(sender As Object, e As EventArgs) Handles buscarActivod.CheckedChanged
        cargarDatos()
        habilitarBotones()
        TabControl1.SelectTab(0)
    End Sub
End Class