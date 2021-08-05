Public Class frmIMSS
    Public Ambiente As AmbienteCls
    Private idRegPatronal As Integer
    Private objEMA_PR As MovimientosEMA_PR
    Private objDGVEMA_PR As New List(Of MovimientosEMA_PR)

    Private objRegPatronal As RegistroPatronal
    Private objCBRegPatroanal As New List(Of RegistroPatronal)

    Private Sub frmIMSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objEMA_PR = New MovimientosEMA_PR(Ambiente)
        objRegPatronal = New RegistroPatronal(Ambiente)
        objRegPatronal.idEmpresa = Ambiente.empr.idEmpresa
        objRegPatronal.getComboActivo(cbRegPatronal, objCBRegPatroanal)

        If cbRegPatronal.Items.Count > 0 Then
            cbRegPatronal.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        recargar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        If dgv.SelectedRows.Count > 0 Then
            objEMA_PR.diasSinIncapacidad = txtDiasSinInc.Text
        End If

        Mensaje.tipoMsj = TipoMensaje.Informacion

        If Not objEMA_PR.recalcular(dtpFiltro.Value) Then
            Mensaje.Mensaje = objEMA_PR.descripError
        Else
            Mensaje.Mensaje = "Datos actualizados correctamente..."
        End If

        Mensaje.ShowDialog()


        txtDiasSinInc.Text = ""
        btnRecalcular.Enabled = False

        recargar()
    End Sub

    Private Sub recargar()
        If cbRegPatronal.SelectedIndex <> -1 Then
            idRegPatronal = objCBRegPatroanal(cbRegPatronal.SelectedIndex).idRegistroPatronal
            objEMA_PR.cargarGridFiltro(dgv, txtFiltro.Text, dtpFiltro.Value.Month, dtpFiltro.Value.Year, idRegPatronal, objDGVEMA_PR)
        Else
            dgv.Rows.Clear()
        End If


    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        objEMA_PR = objDGVEMA_PR(e.RowIndex)
        txtDiasSinInc.Text = objEMA_PR.diasSinIncapacidad

        btnRecalcular.Enabled = True
    End Sub

    Private Sub btnRep1Imp_Click(sender As Object, e As EventArgs) Handles btnRep1Imp.Click
        objEMA_PR.RPT_ImprimirReporte1(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep2Imp_Click(sender As Object, e As EventArgs) Handles btnRep2Imp.Click
        objEMA_PR.RPT_ImprimirReporte2(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep3Imp_Click(sender As Object, e As EventArgs) Handles btnRep3Imp.Click
        objEMA_PR.RPT_ImprimirReporte3(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep1Mod_Click(sender As Object, e As EventArgs) Handles btnRep1Mod.Click
        objEMA_PR.RPT_ModificarReporte1(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep2Mod_Click(sender As Object, e As EventArgs) Handles btnRep2Mod.Click
        objEMA_PR.RPT_ModificarReporte2(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep3Mod_Click(sender As Object, e As EventArgs) Handles btnRep3Mod.Click
        objEMA_PR.RPT_ModificarReporte3(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        frmImportarIMSS.Ambiente = Ambiente
        frmImportarIMSS.ShowDialog()
    End Sub

    Private Sub cbRegPatronal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegPatronal.SelectedIndexChanged
        recargar()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        If e.KeyCode = Keys.Enter Then
            recargar()
        End If
    End Sub

    Private Sub btnRep4Mod_Click(sender As Object, e As EventArgs) Handles btnRep4Mod.Click
        objEMA_PR.RPT_ModificarReporte4(dtpFiltro.Value, idRegPatronal)
    End Sub

    Private Sub btnRep4Imp_Click(sender As Object, e As EventArgs) Handles btnRep4Imp.Click
        objEMA_PR.RPT_ImprimirReporte4(dtpFiltro.Value, idRegPatronal)
    End Sub
End Class