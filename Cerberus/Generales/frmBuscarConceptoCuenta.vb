Public Class frmBuscarConceptoCuenta
    Public Ambiente As AmbienteCls
    Private concepC As ConceptoCuenta
    Private objCocinaDG As New List(Of ConceptoCuenta)
    Public valorRetorno As ConceptoCuenta
    Public tipoCuenta As String
    Public tipoBusqueda As String 'SYS = Solo los de Sistema, NOSYS = Los que no son de Sistema, EXE=Pago de Excedentes

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        concepC = New ConceptoCuenta(Ambiente)
        concepC.idEmpresa = Ambiente.empr.idEmpresa
        concepC.tipoCuenta = tipoCuenta
        filtrar()
    End Sub

    Private Sub filtrar()
        If tipoBusqueda = "SYS" Then
            concepC.cargaGridSistema(DataGridView1, objCocinaDG, txtBuscar.Text, False)
        ElseIf tipoBusqueda = "EXE" Then
            concepC.cargaGridSistema(DataGridView1, objCocinaDG, txtBuscar.Text, True)
        ElseIf tipoBusqueda = "NOSYS" Then
            concepC.cargaGridSinSistema(DataGridView1, objCocinaDG, txtBuscar.Text)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            valorRetorno = objCocinaDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            filtrar()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.DialogResult = DialogResult.OK

        If DataGridView1.SelectedRows.Count > 0 Then
            valorRetorno = objCocinaDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class