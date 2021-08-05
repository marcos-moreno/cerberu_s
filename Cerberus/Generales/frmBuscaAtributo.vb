Public Class frmBuscaAtributo
    Public objRetorno As Atributo
    Public Ambiente As AmbienteCls
    Public idCaracteristica As Integer

    Private objDgv As New List(Of Atributo)

    Private Sub frmBuscaAtributo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRetorno = New Atributo(Ambiente)
        objRetorno.idCaracteristica = idCaracteristica
        filtrar()
    End Sub

    Private Sub filtrar()
        objRetorno.cargaGridFiltro(DataGridView1, objDgv, txtBuscar.Text)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If btnAgregar.Text = "Agregar Nuevo" Then
            objRetorno = New Atributo(Ambiente)
            objRetorno.idCaracteristica = idCaracteristica
            objRetorno.nombreAtributo = txtNombreAtributo.Text

            If objRetorno.guardar() Then
                filtrar()
                Mensaje.Mensaje = "Se agregó correctamente..."
                txtNombreAtributo.Text = ""
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objRetorno.descripError
            End If
        Else
            objRetorno.nombreAtributo = txtNombreAtributo.Text

            If objRetorno.actualizar() Then
                filtrar()
                Mensaje.Mensaje = "Se actualizo correctamente.."
                txtNombreAtributo.Text = ""
                btnAgregar.Text = "Agregar Nuevo"
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objRetorno.descripError
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            objRetorno = objDgv.Item(DataGridView1.SelectedRows.Item(0).Index)
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
            objRetorno = objDgv.Item(DataGridView1.SelectedRows.Item(0).Index)
        End If

        Me.Close()
    End Sub

    Private Sub btn2Valor_Click(sender As Object, e As EventArgs) Handles btn2Valor.Click
        If btn2Valor.Text = "Eliminar" Then
            Mensaje.tipoMsj = TipoMensaje.Pregunta
            Mensaje.Mensaje = "¿Realmente desea eliminar """ & objRetorno.nombreAtributo & """?"
            If Mensaje.ShowDialog = DialogResult.Yes Then
                If Not objRetorno.eliminar() Then
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.Mensaje = "No se puede eliminar el registro: " & objRetorno.descripError
                    Mensaje.ShowDialog()
                End If
                btnAgregar.Text = "Agregar Nuevo"
                btn2Valor.Text = "Modificar"
                txtNombreAtributo.Text = ""
                filtrar()
            End If
        Else
            If DataGridView1.SelectedRows.Count > 0 Then
                btnAgregar.Text = "Modificar"
                btn2Valor.Text = "Eliminar"
                objRetorno = objDgv.Item(DataGridView1.SelectedRows.Item(0).Index)
                txtNombreAtributo.Text = objRetorno.nombreAtributo
            End If
        End If
    End Sub
End Class