Public Class frmBuscaSocio
    Public Ambiente As AmbienteCls
    Private socio As SocioNegocio
    Private objSocioDG As New List(Of SocioNegocio)
    Public socioRetorno As SocioNegocio
    Public soloActivos As Boolean
    Public soloClientes As Boolean
    Public soloProveedores As Boolean
    Public todos As Boolean

    Private Sub frmBuscaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        socio = New SocioNegocio(Ambiente)
        socio.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        socio.cargaGridFiltro(DataGridView1, txtBuscar.Text, todos, soloClientes, soloProveedores, soloActivos, objSocioDG)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            socioRetorno = objSocioDG.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            socioRetorno = objSocioDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub
End Class