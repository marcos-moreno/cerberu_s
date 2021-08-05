Public Class frmImportarCONTPAQ
    Private sincro As SincronizarContpaq

    Private varform As VariableFormula
    Private objCBvarFormula As New List(Of VariableFormula)
    Private objIDTipos As New List(Of Integer)

    Public Ambiente As AmbienteCls

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim idTipoPerido As Integer
        sincro = New SincronizarContpaq(Ambiente)

        Mensaje.tipoMsj = TipoMensaje.Informacion

        If Not chbTiposPeriodo.Checked Then
            If cbTiposPeriodos.SelectedIndex <> -1 Then
                idTipoPerido = objIDTipos(cbTiposPeriodos.SelectedIndex)
            Else
                Mensaje.Mensaje = "Debe seleccionar un Tipo de Periodo a importar, o activar ""De todos los tipos de periodos"""
                Mensaje.ShowDialog()
                Exit Sub
            End If
        Else
            idTipoPerido = 0
        End If


        If sincro.sincronizarEmpleados(chbEmpleados.Checked, chbImporDiasVac.Checked, chbTodos.Checked, txtIDsSincro.Text, idTipoPerido) Then
            Mensaje.Mensaje = "Empleados: Se Sincronizaron Correctamente" & vbCrLf
        Else
            Mensaje.Mensaje = "Empleados: " & sincro.descripError & vbCrLf
        End If

        If chbPeriodos.Checked Then
            If txtIDAbono.Text = "" Or txtIDCargo.Text = "" Or cbVarFormula.SelectedIndex = -1 Then
                Mensaje.Mensaje &= "Periodos: No se sincronizo, es necesario seleccionar un CARGO,UN ABONO y una VARIABLE DE FORMULA, para poder continuar..." & sincro.descripError & vbCrLf
            Else
                If sincro.sincronizaPeriodos(txtNombrePers.Text, txtIDAbono.Text, txtIDCargo.Text, objCBvarFormula(cbVarFormula.SelectedIndex).idVariableFormula) Then
                    Mensaje.Mensaje &= "Periodos: Se Sincronizaron Correctamente" & vbCrLf
                Else
                    Mensaje.Mensaje &= "Periodos: " & sincro.descripError & vbCrLf
                End If
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub frmImportarDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sincro = New SincronizarContpaq(Ambiente)

        varform = New VariableFormula(Ambiente)
        varform.idEmpresa = Ambiente.empr.idEmpresa
        varform.getComboActivo(cbVarFormula, objCBvarFormula)

        sincro.getComboTipoPeriodosCTPQ(cbTiposPeriodos, objIDTipos, "")
    End Sub

    Private Sub btnBuscarCargo_Click(sender As Object, e As EventArgs) Handles btnBuscarCargo.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxC"
        frmBuscarConceptoCuenta.tipoBusqueda = "SYS"

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDCargo.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConceptoCargo.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub btnBuscarAbono_Click(sender As Object, e As EventArgs) Handles btnBuscarAbono.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxP"
        frmBuscarConceptoCuenta.tipoBusqueda = "SYS"

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDAbono.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConceptoAbono.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmOrigen.Ambiente = Ambiente
        frmOrigen.elemento = "Nomina"
        frmOrigen.origen = "CnxNomina"
        frmOrigen.cbTipoBD.SelectedItem = "SQL"
        frmOrigen.cbTipoBD.Enabled = False

        If frmOrigen.ShowDialog() = DialogResult.OK Then
            sincro = New SincronizarContpaq(Ambiente)
            If Not sincro.creaProcedimientos() Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Error: " & sincro.descripError
                Mensaje.ShowDialog()
            End If
        End If

        frmOrigen.cbTipoBD.Enabled = True
    End Sub

    Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
        txtIDsSincro.Text = ""

        If chbTodos.Checked Then
            txtIDsSincro.Enabled = False
        Else
            txtIDsSincro.Enabled = True
        End If
    End Sub

    Private Sub chbTiposPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbTiposPeriodo.CheckedChanged
        If chbTiposPeriodo.Checked Then
            cbTiposPeriodos.Enabled = False
        Else
            cbTiposPeriodos.Enabled = True
        End If

        cbTiposPeriodos.SelectedIndex = -1
    End Sub
End Class