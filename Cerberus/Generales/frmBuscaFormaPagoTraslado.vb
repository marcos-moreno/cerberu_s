Public Class frmBuscaFormaPagoTraslado
    Public Ambiente As AmbienteCls
    Private objeto As FormaPagoTraslado
    Private ObjDGV As New List(Of FormaPagoTraslado)
    Public objRetorno As FormaPagoTraslado

    Private Sub FrmBuscaSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objeto = New FormaPagoTraslado(Ambiente)
        objeto.idEmpresa = Ambiente.suc.idEmpresa
        Filtrar()
    End Sub

    Private Sub Filtrar()
        objeto.cargaGridCom(DgvSucursal, ObjDGV)
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Filtrar()
        End If
    End Sub

    Private Sub DgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSucursal.CellDoubleClick
        Me.DialogResult = DialogResult.OK

        If DgvSucursal.SelectedRows.Count > 0 Then
            objRetorno = ObjDGV.Item(DgvSucursal.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DgvSucursal.SelectedRows.Count > 0 Then
            objRetorno = ObjDGV.Item(DgvSucursal.SelectedRows.Item(0).Index)
        End If
    End Sub
End Class