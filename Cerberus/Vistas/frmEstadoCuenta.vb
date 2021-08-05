Public Class frmEstadoCuenta
    Public Ambiente As AmbienteCls

    Private edoCuenta As EstadoCuenta
    Private per As Periodo
    Private objPer As New List(Of Periodo)

    Private Sub ejecutar(accion As String)
        If cbPeriodo.SelectedIndex <> -1 Then
            Dim idBusqueda As Integer
            Dim idDep As Integer
            Dim idEmpl As Integer
            Dim tipoRep As Integer

            If IsNumeric(txtIDEmpleadoDep.Text) Then
                idBusqueda = txtIDEmpleadoDep.Text
            Else
                idBusqueda = Nothing
            End If



            idEmpl = Nothing
            idDep = Nothing

            If rbtnEdoCuenta.Checked Then
                tipoRep = TipoReporteEdoCuenta.EstadosCuenta

                If rdbDepartamento.Checked Then
                    idDep = idBusqueda
                ElseIf rbtnEmpleado.Checked Then
                    idEmpl = idBusqueda
                End If
            ElseIf rbtnConcentradoEntrega.Checked Then
                tipoRep = TipoReporteEdoCuenta.ConcentradosEntrega
            ElseIf rbtnSolEfec.Checked Then
                tipoRep = TipoReporteEdoCuenta.SolicitudEfectivo
            ElseIf rbtnSobres.Checked Then
                tipoRep = TipoReporteEdoCuenta.Sobres
            ElseIf rbtnTotalGen.Checked Then
                tipoRep = TipoReporteEdoCuenta.TotalGeneral
            ElseIf rbtnPagoExc.Checked Then
                tipoRep = TipoReporteEdoCuenta.PagoExcedentes
            ElseIf rbtnPercepPeriodo.Checked Then
                tipoRep = TipoReporteEdoCuenta.PercepcionesPeriodo
            End If

            If accion = "IMP" Then
                edoCuenta.RPT_ImprimirDatos(objPer(cbPeriodo.SelectedIndex), idEmpl, idDep, tipoRep)
            Else
                edoCuenta.RPT_ModificarDatos(objPer(cbPeriodo.SelectedIndex), idEmpl, idDep, tipoRep)
            End If

        Else
            Mensaje.Mensaje = "Es necesario seleccionar un Periodo para poder continuar..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub frmEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        edoCuenta = New EstadoCuenta(Ambiente)

        per = New Periodo(Ambiente)
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.elementoSistema = "EFE"
        per.tabla = "CUENTA"
        per.ejercicio = Now.Year
        per.getComboTodos(cbPeriodo, objPer)

        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnEmpleadoDep.Click
        If rdbDepartamento.Checked Then
            frmBuscaDepartamento.Ambiente = Ambiente

            If frmBuscaDepartamento.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoDep.Text = frmBuscaDepartamento.EmpleadoRetorno.idDepartamento
                txtNombreEmpleadoDep.Text = frmBuscaDepartamento.EmpleadoRetorno.nombreDepartamento
            End If
        Else
            frmBuscaEmpleado.Ambiente = Ambiente
            frmBuscaEmpleado.soloActivos = False
            If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoDep.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
                txtNombreEmpleadoDep.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
            End If
        End If
    End Sub

    Private Sub cbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriodo.SelectedIndexChanged
        If cbPeriodo.SelectedIndex <> -1 Then
            dtpInicial.Value = objPer(cbPeriodo.SelectedIndex).inicioPeriodo
            dtpFinal.Value = objPer(cbPeriodo.SelectedIndex).finPeriodo
        Else
            dtpInicial.Value = Now
            dtpFinal.Value = Now
        End If
    End Sub


    Private Sub rdbDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDepartamento.CheckedChanged
        lblEmpleadoDepartamento.Text = "Departamento:"
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
        btnEmpleadoDep.Enabled = True
    End Sub

    Private Sub rbtnEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEmpleado.CheckedChanged
        lblEmpleadoDepartamento.Text = "Empleado:"
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
        btnEmpleadoDep.Enabled = True
    End Sub

    Private Sub rbtnNinguno_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnNinguno.CheckedChanged
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
        btnEmpleadoDep.Enabled = False
    End Sub

    Private Sub rbtnEdoCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEdoCuenta.CheckedChanged
        GroupBox1.Enabled = True
        rbtnNinguno.Checked = True
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub rbtnSolEfec_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSolEfec.CheckedChanged
        GroupBox1.Enabled = False
        rbtnNinguno.Checked = True
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub rbtnConcentradoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnConcentradoEntrega.CheckedChanged
        GroupBox1.Enabled = False
        rbtnNinguno.Checked = True
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub rbtnSobres_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSobres.CheckedChanged
        GroupBox1.Enabled = False
        rbtnNinguno.Checked = True
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub rbPercepPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPercepPeriodo.CheckedChanged
        GroupBox1.Enabled = False
        rbtnNinguno.Checked = True
        txtIDEmpleadoDep.Text = ""
        txtNombreEmpleadoDep.Text = ""
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Me.Close()
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        ejecutar("IMP")
    End Sub

    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        ejecutar("MOD")
    End Sub
End Class