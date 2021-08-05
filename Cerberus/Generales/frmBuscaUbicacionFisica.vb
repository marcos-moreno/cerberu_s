Public Class frmBuscaUbicacionFisica
    Public Ambiente As AmbienteCls
    Private ubicacion As UbicacionFisica
    Private objEmplDG As New List(Of UbicacionFisica)
    Public UbicacionRetorno As UbicacionFisica
    Public idSucursal As Integer


    Private Sub frmBuscarUbicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ubicacion = New UbicacionFisica(Ambiente)
        ubicacion.idEmpresa = Ambiente.empr.idEmpresa
        filtrar()
    End Sub

    Private Sub filtrar()
        ubicacion.cargaGridCom(DataGridView1, txtBuscar.Text, objEmplDG)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            UbicacionRetorno = objEmplDG.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            UbicacionRetorno = objEmplDG.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If
        Me.Close()
    End Sub
End Class