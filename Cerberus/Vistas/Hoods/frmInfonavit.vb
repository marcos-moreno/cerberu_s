Imports Cerberus

Public Class frmInfonavit
    Implements InterfaceVentanas
    Public Ambiente As AmbienteCls

    Private objMovimientoEBA_PR As MovimientosEBA_PR
    Private objRegPatronal As RegistroPatronal
    Private objCBRegPatronal As New List(Of RegistroPatronal)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Throw New NotImplementedException()
    End Sub

    Private Sub frmInfonavit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objMovimientoEBA_PR = New MovimientosEBA_PR(Ambiente)
        objRegPatronal = New RegistroPatronal(Ambiente)
        objRegPatronal.idEmpresa = Ambiente.empr.idEmpresa
        objRegPatronal.getComboActivo(cbRegPatronal, objCBRegPatronal)

        If cbRegPatronal.Items.Count > 0 Then
            cbRegPatronal.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnRep1Mod_Click(sender As Object, e As EventArgs) Handles btnRep1Mod.Click
        objMovimientoEBA_PR.RPT_ModificarReporte1(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep1Imp_Click(sender As Object, e As EventArgs) Handles btnRep1Imp.Click
        objMovimientoEBA_PR.RPT_ImprimirReporte1(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        frmImportarINFONAVIT.Ambiente = Ambiente
        frmImportarINFONAVIT.ShowDialog()
    End Sub

    Private Sub btnRep2Mod_Click(sender As Object, e As EventArgs) Handles btnRep2Mod.Click
        objMovimientoEBA_PR.RPT_ModificarReporte2(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep2Imp_Click(sender As Object, e As EventArgs) Handles btnRep2Imp.Click
        objMovimientoEBA_PR.RPT_ImprimirReporte2(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep3Mod_Click(sender As Object, e As EventArgs) Handles btnRep3Mod.Click
        objMovimientoEBA_PR.RPT_ModificarReporte3(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep3Imp_Click(sender As Object, e As EventArgs) Handles btnRep3Imp.Click
        objMovimientoEBA_PR.RPT_ImprimirReporte3(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep4Imp_Click(sender As Object, e As EventArgs) Handles btnRep4Imp.Click
        objMovimientoEBA_PR.RPT_ImprimirReporte4(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep4Mod_Click(sender As Object, e As EventArgs) Handles btnRep4Mod.Click
        objMovimientoEBA_PR.RPT_ModificarReporte4(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep5Mod_Click(sender As Object, e As EventArgs) Handles btnRep5Mod.Click
        objMovimientoEBA_PR.RPT_ModificarReporte5(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub

    Private Sub btnRep5Imp_Click(sender As Object, e As EventArgs) Handles btnRep5Imp.Click
        objMovimientoEBA_PR.RPT_ImprimirReporte5(dtpFiltro.Value, objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal)
    End Sub
End Class