Imports Cerberus

Public Class frmCredenciales
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Public tabla As String
    Public idTabla As Integer

    Private ObjVentana As CaracteristicaTabla
    Private objDgv As New List(Of CaracteristicaTabla)
    Private nuevoReg As Boolean
    Private objValor As Valor

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            ObjVentana = New CaracteristicaTabla(Ambiente)
            ObjVentana.idTabla = idTabla
            ObjVentana.tabla = tabla + "Credenciales"
            cbActivo.Checked = True
        End If

        Dim objCarac As New Caracteristica(Ambiente)
        objCarac.idCaracteristica = ObjVentana.idCaracteristica
        objCarac.buscarPID()
        txtIDCaracteristica.Text = objCarac.idCaracteristica
        txtNombreCaracteristica.Text = objCarac.nombreCaracteristica

        Dim objAtributo As New Atributo(Ambiente)
        objAtributo.idAtributo = ObjVentana.idAtributo
        objAtributo.buscarPID()
        txtIDAtributo.Text = objAtributo.idAtributo
        txtNombreAtributo.Text = objAtributo.nombreAtributo

        objValor = New Valor(Ambiente)
        objValor.idValor = ObjVentana.idValor
        objValor.buscarPID()
        txtIDValor.Text = objValor.idValor
        txtNombreVlor.Text = objValor.valor

        cbActivo.Checked = ObjVentana.activo
        txtComentario.Text = ObjVentana.comentario
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        ObjVentana.idCaracteristica = txtIDCaracteristica.Text
        ObjVentana.idAtributo = txtIDAtributo.Text
        ObjVentana.idValor = txtIDValor.Text
        ObjVentana.comentario = txtComentario.Text
        ObjVentana.activo = cbActivo.Checked
        If nuevoReg Then
            ObjVentana.tabla = tabla
            ObjVentana.idTabla = idTabla
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            ObjVentana = objDgv.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
    End Sub

    Private Sub btnCaracteristica_Click(sender As Object, e As EventArgs) Handles btnCaracteristica.Click
        frmBuscaCaracteristica.Ambiente = Ambiente
        frmBuscaCaracteristica.tabla = tabla + "Credenciales"

        If frmBuscaCaracteristica.ShowDialog() = DialogResult.OK Then
            txtIDCaracteristica.Text = frmBuscaCaracteristica.objRetorno.idCaracteristica
            txtNombreCaracteristica.Text = frmBuscaCaracteristica.objRetorno.nombreCaracteristica

            txtIDAtributo.Text = 0
            txtNombreAtributo.Text = ""
            txtIDValor.Text = 0
            txtNombreVlor.Text = ""
        End If
    End Sub

    Private Sub btnAtributo_Click(sender As Object, e As EventArgs) Handles btnAtributo.Click
        frmBuscaAtributo.Ambiente = Ambiente
        frmBuscaAtributo.idCaracteristica = txtIDCaracteristica.Text

        If frmBuscaAtributo.ShowDialog() = DialogResult.OK Then
            txtIDAtributo.Text = frmBuscaAtributo.objRetorno.idAtributo
            txtNombreAtributo.Text = frmBuscaAtributo.objRetorno.nombreAtributo
        End If
    End Sub
    Private Sub frmCacteristicaTabla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObjVentana = New CaracteristicaTabla(Ambiente)
        ObjVentana.idTabla = idTabla
        ObjVentana.tabla = tabla + "Credenciales"
        ObjVentana.cargaGridCom(DataGridView1, objDgv)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Public Function guardarValor() As Boolean
        If nuevoReg Then
            objValor = New Valor(Ambiente)
            objValor.valor = txtNombreVlor.Text
            objValor.idAtributo = txtIDAtributo.Text
            objValor.idEmpresa = Ambiente.empr.idEmpresa

            If objValor.guardar() = True Then
                txtIDValor.Text = objValor.idValor
                Return True
            Else
                Mensaje.Mensaje = objValor.descripError
                Mensaje.ShowDialog()
                Return False
            End If
        Else
            objValor.valor = txtNombreVlor.Text
            objValor.idAtributo = txtIDAtributo.Text
            objValor.idEmpresa = Ambiente.empr.idEmpresa
            If objValor.actualizar() = True Then
                'Mensaje.Mensaje = "Se Actualizó el valor correctamente..."
                'Mensaje.ShowDialog()
                txtIDValor.Text = objValor.idValor
                txtNombreVlor.Text = objValor.valor
                Return True
            Else
                Mensaje.Mensaje = objValor.descripError
                Mensaje.ShowDialog()
                Return False
            End If
        End If
        Return False
    End Function

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        If guardarValor() Then
            Dim operacion As Boolean = True
            obtenerDatos()
            Mensaje.tipoMsj = TipoMensaje.Informacion
            ObjVentana.tabla = tabla + "Credenciales"
            If nuevoReg Then
                If Not ObjVentana.guardar() Then
                    Mensaje.Mensaje = ObjVentana.descripError
                Else
                    Mensaje.Mensaje = "Se guardó correctamente..."
                    nuevoReg = False
                    operacion = False
                End If
            Else
                If Not ObjVentana.actualizar() Then
                    Mensaje.Mensaje = ObjVentana.descripError
                Else
                    Mensaje.Mensaje = "Se actualizó correctamente..."
                    operacion = False
                End If
            End If
            Mensaje.ShowDialog()

            If Not operacion Then
                ObjVentana.cargaGridCom(DataGridView1, objDgv)
                TabControl1.SelectTab(0)
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar la caracteristica seleccionada...?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            ObjVentana.eliminar()
            ObjVentana.cargaGridCom(DataGridView1, objDgv)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs)
        frmComentario.tabla = "CaracteristicaTabla"
        frmComentario.idTabla = ObjVentana.idCaracteristicaTabla
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs)
        frmArchivo.tabla = "CaracteristicaTabla"
        frmArchivo.idTabla = ObjVentana.idCaracteristicaTabla
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        ObjVentana.cargaGridCom(DataGridView1, objDgv)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "CaracteristicaTabla"
        frmLogTransaccion.idTabla = ObjVentana.idCaracteristicaTabla
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

End Class