Imports Cerberus

Public Class frmCargoAbonoPrestamo
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public idPrestamo As Integer
    Public idCargoAbono As Integer

    Private objCargoAbono As CargoAbonoPrestamo

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtIDPrestamo.Text = idPrestamo

        If objCargoAbono.estado = "CO" Then
            txtEstado.BackColor = Color.GreenYellow
        Else
            txtEstado.BackColor = Color.Aquamarine
        End If

        txtEstado.Text = objCargoAbono.getNombreEstado

        If objCargoAbono.tipo = "CxC" Then
            rbtnCargo.Checked = True
        Else
            rbtnAbono.Checked = True
        End If

        txtCantidad.Text = objCargoAbono.cantidad

        Dim concepto As New ConceptoCuenta(Ambiente)
        concepto.idConceptoCuenta = objCargoAbono.idConceptoCuenta
        concepto.buscarPID()
        txtIDConcepto.Text = concepto.idConceptoCuenta
        txtDescripConcepto.Text = concepto.nombreConceptoCuenta

        If idCargoAbono = Nothing Then
            dtpFechaCargoAbono.Value = Now
        Else
            dtpFechaCargoAbono.Value = objCargoAbono.fecha
        End If

        txtReferencia.Text = objCargoAbono.referencia
        txtObservaciones.Text = objCargoAbono.observaciones
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos

        objCargoAbono.idPrestamo = txtIDPrestamo.Text

        If rbtnCargo.Checked Then
            objCargoAbono.tipo = "CxC"
        Else
            objCargoAbono.tipo = "CxP"
        End If

        objCargoAbono.cantidad = txtCantidad.Text
        objCargoAbono.idConceptoCuenta = txtIDConcepto.Text
        objCargoAbono.fecha = dtpFechaCargoAbono.Value
        objCargoAbono.referencia = txtReferencia.Text
        objCargoAbono.observaciones = txtObservaciones.Text

    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim estado As Boolean
        Dim read As Boolean

        If objCargoAbono.estado = "CO" Then
            estado = False
            read = True
        Else
            estado = True
            read = False
        End If

        rbtnAbono.Enabled = estado
        rbtnCargo.Enabled = estado
        txtCantidad.ReadOnly = read
        btnBuscaConcepto.Enabled = estado
        dtpFechaCargoAbono.Enabled = estado
        txtReferencia.Enabled = estado
        txtObservaciones.Enabled = estado
        btnGuardar.Enabled = estado

        btnComentarios.Enabled = read
        btnAdjuntos.Enabled = read
        btnReportes.Enabled = read
    End Sub

    Private Sub frmCargoAbonoPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar()

        If Ambiente.usuario.desarrollador Then
            btnModRecibo.Visible = True
        Else
            btnModRecibo.Visible = False
        End If

    End Sub

    Private Sub cargar()
        objCargoAbono = New CargoAbonoPrestamo(Ambiente)

        If idCargoAbono <> Nothing Then
            objCargoAbono.idCargoAbonoPrestamo = idCargoAbono
            objCargoAbono.buscarPID()
        Else
            Dim objPrestamo As New Prestamo(Ambiente)
            objPrestamo.idPrestamo = idPrestamo
            objPrestamo.buscarPID()

            objCargoAbono.idEmpresa = Ambiente.empr.idEmpresa
            objCargoAbono.idSucursal = objPrestamo.idSucursal
        End If

        asignaDatos()
        habilitarBotones()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        frmNuevoEstado.setEstadoBD("CO")
        frmNuevoEstado.cbEstado.Enabled = False

        If frmNuevoEstado.ShowDialog() = DialogResult.OK Then

            objCargoAbono.estado = frmNuevoEstado.getEstadoDB

            Dim operacion As Boolean = True
            obtenerDatos()
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If idCargoAbono = Nothing Then 'esNuevo Registro si no contiene ID el Objeto
                If Not objCargoAbono.guardar() Then
                    Mensaje.Mensaje = objCargoAbono.descripError
                Else
                    Mensaje.Mensaje = "Se guardó correctamente el Documento"
                    idCargoAbono = objCargoAbono.idCargoAbonoPrestamo
                    operacion = False
                End If
            Else
                If Not objCargoAbono.actualizar() Then
                    Mensaje.Mensaje = objCargoAbono.descripError
                Else
                    Mensaje.Mensaje = "Se actualizó correctamente el Documento"
                    operacion = False
                End If
            End If

            Mensaje.ShowDialog()
            If Not operacion Then
                cargar()
            End If
        End If

        frmNuevoEstado.cbEstado.Enabled = True
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "CargoAbonoPrestamo"
        frmComentario.idTabla = objCargoAbono.idCargoAbonoPrestamo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "CargoAbonoPrestamo"
        frmArchivo.idTabla = objCargoAbono.idCargoAbonoPrestamo
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub CancelarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas CANCELAR el Documento: " & objCargoAbono.idCargoAbonoPrestamo & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            objCargoAbono.eliminar()
            cargar()
        End If
    End Sub

    Private Sub btnBuscaConcepto_Click(sender As Object, e As EventArgs) Handles btnBuscaConcepto.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoBusqueda = "NOSYS"

        If rbtnCargo.Checked Then
            frmBuscarConceptoCuenta.tipoCuenta = "CxC"
        Else
            frmBuscarConceptoCuenta.tipoCuenta = "CxP"
        End If

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConcepto.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub rbtnCargo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCargo.CheckedChanged
        txtIDConcepto.Text = ""
        txtDescripConcepto.Text = ""
    End Sub

    Private Sub rbtnAbono_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAbono.CheckedChanged
        txtIDConcepto.Text = ""
        txtDescripConcepto.Text = ""
    End Sub

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnImpRecibo.Click
        objCargoAbono.imprimeRecibo()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnModRecibo.Click
        objCargoAbono.modificaRecibo()
    End Sub
End Class