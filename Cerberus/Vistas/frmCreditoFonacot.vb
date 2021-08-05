Imports Cerberus

Public Class frmCreditoFonacot
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public idEmpleadoActivo As Integer

    Private objCreditoF As CreditoFonacot
    Private objGDCreditoF As New List(Of CreditoFonacot)

    Private nuevoRegistro As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoRegistro Then
            objCreditoF = New CreditoFonacot(Ambiente)
            objCreditoF.idEmpleado = idEmpleadoActivo
            objCreditoF.fechaInicioCredito = Now
        End If

        txtCliente.Text = objCreditoF.numCliente
        txtCredito.Text = objCreditoF.numCredito
        txtMontoCredito.Text = objCreditoF.montoCredito
        txtPlazos.Text = objCreditoF.plazos
        txtRetencionMensual.Text = objCreditoF.retencionMensual
        dtpFechaCredito.Value = objCreditoF.fechaInicioCredito
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objCreditoF.numCliente = txtCliente.Text
        objCreditoF.numCredito = txtCredito.Text
        objCreditoF.montoCredito = txtMontoCredito.Text
        objCreditoF.plazos = txtPlazos.Text
        objCreditoF.retencionMensual = txtRetencionMensual.Text
        objCreditoF.fechaInicioCredito = dtpFechaCredito.Value
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoRegistro = False
            objCreditoF = objGDCreditoF(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoRegistro Then
            btnAdjuntos.Enabled = False
            btnComentarios.Enabled = False
            btnEliminar.Enabled = False
            btnNuevo.Enabled = False
        Else
            btnAdjuntos.Enabled = True
            btnComentarios.Enabled = True
            btnEliminar.Enabled = True
            btnNuevo.Enabled = True
        End If
    End Sub

    Private Sub frmCreditoFonacot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objCreditoF = New CreditoFonacot(Ambiente)
        objCreditoF.idEmpleado = idEmpleadoActivo

        objCreditoF.cargaGridEmpleado(dgvCreditos, objGDCreditoF)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoRegistro = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvCreditos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCreditos.CellDoubleClick
        TabControl1.SelectTab(1)
        clicDatos(e.RowIndex)
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Archivos"
        frmArchivo.tabla = "CreditoFonacot"
        frmArchivo.idTabla = objCreditoF.idCreditoFonacot
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        TabControl1.SelectTab(0)
        objCreditoF.cargaGridEmpleado(dgvCreditos, objGDCreditoF)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        If nuevoRegistro Then
            If objCreditoF.guardar() Then
                Mensaje.Mensaje = "Datos generados correctamente..."
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objCreditoF.descripError
            End If
        Else
            If objCreditoF.actualizar() Then
                Mensaje.Mensaje = "Datos actualizado correctamente..."
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objCreditoF.descripError
            End If
        End If

        Mensaje.ShowDialog()

        TabControl1.SelectTab(0)
        objCreditoF.cargaGridEmpleado(dgvCreditos, objGDCreditoF)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Crédito seleccionado: " & objCreditoF.numCredito & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            objCreditoF.eliminar()
            objCreditoF.cargaGridEmpleado(dgvCreditos, objGDCreditoF)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub dgvCreditos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCreditos.SelectionChanged
        If dgvCreditos.SelectedRows.Count > 0 Then
            clicDatos(dgvCreditos.SelectedRows.Item(0).Index)
            habilitarBotones()
        Else
            txtCliente.Text = ""
            txtCredito.Text = ""
            txtMontoCredito.Text = 0
            txtPlazos.Text = 0
            txtRetencionMensual.Text = 0
            dtpFechaCredito.Value = Now
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "CreditoFonacot"
        frmComentario.idTabla = objCreditoF.idCreditoFonacot
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub
End Class