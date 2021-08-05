Imports Cerberus

Public Class frmSucursal
    Implements InterfaceVentanas

    Private objSuc As Sucursal
    Private objDGVSuc As New List(Of Sucursal)
    Public Ambiente As AmbienteCls
    Private objBanco As Banco
    Private objCBBanco As New List(Of Banco)

    Private nuevoReg As Boolean

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        txtNombre.Text = objSuc.nombreSucursal
        esActivo.Checked = objSuc.esActivo
        excedetesPagaSuc.Checked = objSuc.excedentesPagaSuc
        txtNumCuentaPago.Text = objSuc.cuentapago
        cbBanco.SelectedItem = objSuc.bancopago
        txtTelefono.Text = objSuc.telefono
        cbBanco.SelectedIndex = -1
        For i As Integer = 0 To cbBanco.Items.Count - 1
            If objCBBanco.Item(i).codigoSAT = objSuc.bancopago Then
                cbBanco.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objSuc.nombreSucursal = txtNombre.Text
        objSuc.esActivo = esActivo.Checked
        objSuc.excedentesPagaSuc = excedetesPagaSuc.Checked
        objSuc.cuentapago = txtNumCuentaPago.Text
        objSuc.telefono = txtTelefono.Text
        If cbBanco.SelectedIndex <> -1 Then
            objSuc.bancopago = objCBBanco.Item(cbBanco.SelectedIndex).codigoSAT
        Else
            objSuc.bancopago = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        objSuc = objDGVSuc(indice)
        asignaDatos()
        nuevoReg = False
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub frmSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSuc = New Sucursal(Ambiente)
        objSuc.idEmpresa = Ambiente.empr.idEmpresa

        objBanco = New Banco(Ambiente)
        objBanco.getCombo(cbBanco, objCBBanco)

        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        objSuc.cargaGridCom(dgvSucs, objDGVSuc, "")
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        objSuc = New Sucursal(Ambiente)
        objSuc.idEmpresa = Ambiente.empr.idEmpresa
        nuevoReg = True
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        If nuevoReg Then
            If objSuc.guardar() Then
                Mensaje.Mensaje = "Sucursal Creada Correctamente..."
            Else
                Mensaje.Mensaje = objSuc.descripError
            End If
        Else
            If objSuc.actualizar Then
                Mensaje.Mensaje = "Sucursal Actualizada Correctamente..."
            Else
                Mensaje.Mensaje = objSuc.descripError
            End If
        End If

        Mensaje.ShowDialog()

        cargarDatos()
        habilitarBotones()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta

        Mensaje.Mensaje = "¿Realmente desea eliminar la Sucursal: " & objSuc.nombreSucursal & "?"

        If Mensaje.ShowDialog() = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objSuc.eliminar() Then
                Mensaje.Mensaje = "Sucursal ELIMINADA correctamente..."
            Else
                Mensaje.Mensaje = objSuc.descripError
            End If
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cargarDatos()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub dgvSucs_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSucs.CellDoubleClick
        clicDatos(e.RowIndex)

        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvSucs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSucs.SelectionChanged
        If dgvSucs.SelectedRows.Count > 0 Then
            clicDatos(dgvSucs.SelectedRows(0).Index)
        End If
    End Sub
End Class