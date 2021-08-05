Public Class frmBuscarCuentas
    Private per As Periodo
    Private objPer As New List(Of Periodo)
    Private objEstado As New List(Of String)

    Public Ambiente As AmbienteCls
    Public elementoSistema As String

    Public estado As String
    Public idElemento As Integer
    Public fechaInicial As Date
    Public fechaFinal As Date

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click

        If elementoSistema = "Empleado" Then
            frmBuscaEmpleado.Ambiente = Ambiente
            frmBuscaEmpleado.soloActivos = False
            If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
                txtNombreEmpleadoCocina.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
            End If
        Else
            frmBuscarCocina.Ambiente = Ambiente
            If frmBuscarCocina.ShowDialog() = DialogResult.OK Then
                txtIDEmpleadoCocina.Text = frmBuscarCocina.CocinaRetorno.idCocina
                txtNombreEmpleadoCocina.Text = frmBuscarCocina.CocinaRetorno.nombreCocina
            End If
        End If
    End Sub

    Private Sub frmBuscarCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        per = New Periodo(Ambiente)
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.elementoSistema = "ES"
        per.ejercicio = Now.Year
        per.tabla = "Registro"
        per.getComboTodos(cbPeriodo, objPer)

        objEstado.Clear()
        objEstado.Add("TO")
        objEstado.Add("BO")
        objEstado.Add("PA")
        objEstado.Add("CO")
        objEstado.Add("CA")

        txtIDEmpleadoCocina.Text = ""
        txtNombreEmpleadoCocina.Text = ""

        cbEstado.SelectedIndex = 0
        cbPeriodo.SelectedIndex = -1

        For i As Integer = 0 To cbPeriodo.Items.Count - 1
            If Now < objPer(i).finPeriodo Then
                cbPeriodo.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        estado = objEstado(cbEstado.SelectedIndex)

        Try
            idElemento = txtIDEmpleadoCocina.Text
        Catch ex As Exception
            idElemento = Nothing
        End Try

        fechaInicial = objPer(cbPeriodo.SelectedIndex).inicioPeriodo
        fechaFinal = objPer(cbPeriodo.SelectedIndex).finPeriodo
    End Sub
End Class