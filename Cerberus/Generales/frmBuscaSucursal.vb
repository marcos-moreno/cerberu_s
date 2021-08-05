Public Class FrmBuscaSucursal
    Public Ambiente As AmbienteCls
    Private objeto As Sucursal
    Private objSucursal As New List(Of Sucursal)
    Public objRetorno As Sucursal

    Private Sub FrmBuscaSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objeto = New Sucursal(Ambiente)
        objeto.idEmpresa = Ambiente.suc.idEmpresa
        Filtrar()
    End Sub

    Private Sub Filtrar()
        objeto.cargaGridCom(DgvSucursal, objSucursal, txtBuscar.Text)
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Filtrar()
        End If
    End Sub

    Private Sub DgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSucursal.CellDoubleClick
        Me.DialogResult = DialogResult.OK

        If DgvSucursal.SelectedRows.Count > 0 Then
            objRetorno = objSucursal.Item(DgvSucursal.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DgvSucursal.SelectedRows.Count > 0 Then
            objRetorno = objSucursal.Item(DgvSucursal.SelectedRows.Item(0).Index)
        End If
    End Sub
End Class