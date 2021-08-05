Imports Cerberus

Public Class frmFonacot
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objMovFonactor As MovimientoFonacot
    Private objDGVMovFonacot As New List(Of MovimientoFonacot)

    Private objSuc As Sucursal
    Private objCBSuc As New List(Of Sucursal)

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "MovimientoFonacot"
        frmImportar.ShowDialog()
    End Sub

    Private Sub btnRep1Mod_Click(sender As Object, e As EventArgs) Handles btnRep1Mod.Click
        objMovFonactor.RPT_ModificarReporte1()
    End Sub

    Private Sub frmFonacot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objMovFonactor = New MovimientoFonacot(Ambiente)
        objMovFonactor.idEmpresa = Ambiente.empr.idEmpresa

        objSuc = New Sucursal(Ambiente)
        objSuc.idEmpresa = Ambiente.empr.idEmpresa
        objSuc.getComboActivo(cbSucursal, objCBSuc)

        limpiar()
    End Sub

    Public Sub limpiar()
        cbSucursal.SelectedIndex = -1
        txtFiltro.Text = ""
    End Sub

    Private Sub btnRep1Imp_Click(sender As Object, e As EventArgs) Handles btnRep1Imp.Click
        objMovFonactor.RPT_ImprimirReporte1()
    End Sub

    Private Sub btnRep2Mod_Click(sender As Object, e As EventArgs) Handles btnRep2Mod.Click
        objMovFonactor.RPT_ModificarReporte2()
    End Sub

    Private Sub btnRep2Imp_Click(sender As Object, e As EventArgs) Handles btnRep2Imp.Click
        objMovFonactor.RPT_ImprimirReporte2()
    End Sub

    Private Sub btnRep3Mod_Click(sender As Object, e As EventArgs) Handles btnRep3Mod.Click
        objMovFonactor.RPT_ModificarReporte3()
    End Sub

    Private Sub btnRep3Imp_Click(sender As Object, e As EventArgs) Handles btnRep3Imp.Click
        objMovFonactor.RPT_ImprimirReporte3()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        objMovFonactor.periodo = dtpFiltro.Value.Month
        objMovFonactor.ejercicio = dtpFiltro.Value.Year
        objMovFonactor.cargarGridGen(dgv, objDGVMovFonacot, txtFiltro.Text)

        limpiar()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        objMovFonactor = objDGVMovFonacot(e.RowIndex)

        asignaDatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        obtenerDatos()

        If objMovFonactor.guardar() Then
            Mensaje.Mensaje = "Información actualizada correctamente..."
        Else
            Mensaje.Mensaje = objMovFonactor.descripError
        End If

        Mensaje.ShowDialog()
        limpiar()
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objMovFonactor.idSucursal = objCBSuc(i).idSucursal Then
                cbSucursal.SelectedIndex = i
            End If
        Next

        txtCuotas.Text = objMovFonactor.cuotasPagadas

        cbSucursal.Enabled = True
        txtCuotas.Enabled = True
        btnActualizar.Enabled = True
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        objMovFonactor.idSucursal = objCBSuc(cbSucursal.SelectedIndex).idSucursal
        Try
            objMovFonactor.cuotasPagadas = txtCuotas.Text
        Catch ex As Exception

        End Try

        cbSucursal.Enabled = False
        txtCuotas.Enabled = False
        btnActualizar.Enabled = False
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        Throw New NotImplementedException()
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Throw New NotImplementedException()
    End Sub

    Private Sub btnRep4Mod_Click(sender As Object, e As EventArgs) Handles btnRep4Mod.Click
        objMovFonactor.RPT_ModificarReporte4()
    End Sub

    Private Sub btnRep4Imp_Click(sender As Object, e As EventArgs) Handles btnRep4Imp.Click
        objMovFonactor.RPT_ImprimirReporte4()
    End Sub

    Private Sub btnRep5_Click(sender As Object, e As EventArgs) Handles btnRep5.Click
        objMovFonactor.RPT_ImprimirReporte5()
    End Sub

    Private Sub btnRep6_Click(sender As Object, e As EventArgs) Handles btnRep6.Click
        objMovFonactor.RPT_ImprimirReporte6()
    End Sub

    Private Sub btnRep5Mod_Click(sender As Object, e As EventArgs) Handles btnRep5Mod.Click
        objMovFonactor.RPT_ModificarReporte5()
    End Sub

    Private Sub btnRep6Mod_Click(sender As Object, e As EventArgs) Handles btnRep6Mod.Click
        objMovFonactor.RPT_ModificarReporte6()
    End Sub

    Private Sub btnRep7Mod_Click(sender As Object, e As EventArgs) Handles btnRep7Mod.Click
        objMovFonactor.RPT_ModificarReporte7()
    End Sub

    Private Sub btnRep7_Click(sender As Object, e As EventArgs) Handles btnRep7.Click
        objMovFonactor.RPT_ImprimirReporte7()
    End Sub
End Class