Imports System.Threading
Public Class frmExportarInformacion

    Private _context As AmbienteCls
    Private _empleado As Empleado
    Private _departamento As Departamento
    Private _listDepartamento As List(Of Departamento)
    Private _table As String
    Private _exportarInformacion As ExportarInformacion
    Private _listExportarInformacion As List(Of ExportarInformacion)
    Private threadExportar As Thread 'hilo 1 
    Private sql As String
    Public Property Context As AmbienteCls
        Get
            Return _context
        End Get
        Set(value As AmbienteCls)
            _context = value
        End Set
    End Property

    Public Property Table As String
        Get
            Return _table
        End Get
        Set(value As String)
            _table = value
        End Set
    End Property

    Private Sub frmExportarInformacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        _listExportarInformacion = New List(Of ExportarInformacion)
        _exportarInformacion = New ExportarInformacion(_context)
        _departamento = New Departamento(_context)
        _listDepartamento = New List(Of Departamento)
        _exportarInformacion.tabla = _table
        _exportarInformacion.getComboField(cbFieldDate, "date")
        _exportarInformacion.getComboField(cbFieldText, "varchar")
        _departamento.idEmpresa = _context.empr.idEmpresa
        _departamento.getComboActivo(cbDepartamento, _listDepartamento)
        _exportarInformacion.getCombo(cbFormato, _listExportarInformacion, "")
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles bteExportar.Click
        If cbFormato.SelectedIndex > -1 Then
            bteExportar.Text = "Ejecutando....."
            Dim filter As String = ""
            If lbText.Text <> ":" Then
                Dim fText = Replace(lbText.Text, ":", "")
                fText = Replace(fText, "CONTENGA", " LIKE ")
                fText = Replace(fText, "|", "OR")
                filter = " AND (" & fText & ")"
            End If
            If lbFecha.Text <> ":" Then
                Dim fDate = Replace(Replace(lbFecha.Text, ":", ""), "Entre", " BETWEEN ")
                fDate = Replace(fDate, "y", "AND")
                fDate = Replace(fDate, "|", "OR")
                filter = filter & " AND (" & fDate & ")"
            End If
            If txtFilterIDs.Text <> "" Then
                filter = filter & " AND ( " & _listExportarInformacion.Item(cbFormato.SelectedIndex).pk_as & " IN (" & txtFilterIDs.Text & "))"
            End If

            If cbDepartamento.SelectedIndex <> -1 Then
                filter = filter & " AND (e.idDepartamento = " & _listDepartamento.Item(cbDepartamento.SelectedIndex).idDepartamento & ")"
            End If

            filter = filter & " AND (perfilCalculo <> 'Estadia')"

            sql = ""
            sql = Replace(_listExportarInformacion.Item(cbFormato.SelectedIndex).sql, "#########Filter", filter)
            sql = Replace(sql, " OR )", ")")
            sql = Replace(sql, "**", _listExportarInformacion.Item(cbFormato.SelectedIndex).ptp)

            If _exportarInformacion.generateExcel(sql) Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Formato Creado Correctamente"
                Mensaje.ShowDialog()
                lbFecha.Text = ":"
                lbText.Text = ":"
                txtFilterIDs.Text = ""
                txtFilterText.Text = ""
                bteExportar.Text = "Exportar"
            Else
                bteExportar.Text = "Exportar"
                MsgBox(_exportarInformacion.descripError)
            End If
        Else
            'bteExportar.Enabled = False
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "Selecciona Un Formato"
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        If cbFieldDate.SelectedIndex > -1 Then
            lbFecha.Text = lbFecha.Text & "**" & cbFieldDate.SelectedItem & " Entre '" & Format(dtpInicio.Value, "dd/MM/yyyy") & "' y '" & Format(dtpFin.Value, "dd/MM/yyyy") & "' | "
        End If
    End Sub

    Private Sub MaterialRaisedButton4_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton4.Click
        If txtSQL.Text <> "" Then
            If _exportarInformacion.generateExcel(txtSQL.Text) Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Formato Creado Correctamente"
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "Ingresa la Sentencia SQL."
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        If cbFieldText.SelectedIndex > -1 Then
            lbText.Text = lbText.Text & "**" & cbFieldText.SelectedItem & " CONTENGA '%" & txtFilterText.Text & "%' | "
        End If
    End Sub

    Private Sub MaterialRaisedButton5_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton5.Click
        lbFecha.Text = ":"
    End Sub

    Private Sub MaterialRaisedButton6_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton6.Click
        lbText.Text = ":"
    End Sub
End Class