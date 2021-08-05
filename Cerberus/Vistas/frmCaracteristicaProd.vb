Public Class frmCaracteristicaProd


    Public Ambiente As AmbienteCls
    Private objProducto As CaracteristicaProducto

    Private objDgvCaracteristicaProducto As New List(Of CaracteristicaProducto)

    Private Sub frmCaracteristicaProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProducto = New CaracteristicaProducto(Ambiente)
        objProducto.getComboActivos()
    End Sub
End Class