Public Class frmImportarIMSS
    Private objRegPatronal As RegistroPatronal
    Private objCBRegPatronal As New List(Of RegistroPatronal)

    Public Ambiente As AmbienteCls

    Private Sub frmImportarIMSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRegPatronal = New RegistroPatronal(Ambiente)
        objRegPatronal.idEmpresa = Ambiente.empr.idEmpresa
        objRegPatronal.getComboActivo(cbRegPatronal, objCBRegPatronal)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarArchivo.Filter = "Archivo Excel 93-2003 *.xls | *.xls"
        buscarArchivo.Multiselect = False
        If buscarArchivo.ShowDialog() = DialogResult.OK Then
            txtRutaArchivo.Text = buscarArchivo.FileName
        End If
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If validaDatos Then
            Dim objMovEMA As MovimientosEMA
            objMovEMA = New MovimientosEMA(Ambiente)

            objMovEMA.idEmpresa = Ambiente.empr.idEmpresa
            objMovEMA.periodo = dtpFecha.Value.Month
            objMovEMA.ejercicio = dtpFecha.Value.Year
            objMovEMA.idRegistroPatronal = objCBRegPatronal(cbRegPatronal.SelectedIndex).idRegistroPatronal

            If Not objMovEMA.ImportarExcel(txtRutaArchivo.Text, txtHoja.Text, txtRango.Text) Then
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = objMovEMA.descripError
            Else
                Mensaje.Mensaje = "DATOS IMPORTADOS CORRECTAMENTE..."

            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Public Function validaDatos() As Boolean
        If cbRegPatronal.SelectedIndex = -1 Then
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "Favor de seleccionar un registro patronal"
            Return False
        ElseIf txtRutaArchivo.Text = "" Then
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "FAVOR DE SELECCIONAR un archivo Excel..."
            Return False
        Else
            Return True
        End If
    End Function
End Class