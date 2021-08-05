Imports Cerberus

Public Class frmHorario
    Implements InterfaceVentanas

    Public tabla As String
    Public tipoHorario As String
    Public Ambiente As AmbienteCls
    Private nuevoReg As Boolean

    Private objCbSuc As New List(Of Sucursal)
    Private objCbEmpr As New List(Of Empresa)

    Private horDet As HorarioDetalle

    Private hor As Horario
    Private objDgvHor As New List(Of Horario)

    Private objCmpDtpI As New List(Of DateTimePicker)
    Private objCmpDtpF As New List(Of DateTimePicker)
    Private objCmpDtpMin As New List(Of DateTimePicker)
    Private objCmpDtpC As New List(Of DateTimePicker)

    Private objCmpChk As New List(Of CheckBox)

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            hor = New Horario(Ambiente)
            hor.idEmpresa = Ambiente.empr.idEmpresa
        End If

        txtNombre.Text = hor.nombreHorario
        esActivo.Checked = hor.esActivo

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = hor.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = hor.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        horDet.idHorario = hor.idHorario

        For x As Integer = 0 To 6
            horDet.numDia = x + 1

            objCmpChk.Item(x).Checked = horDet.buscarPID()

            If objCmpChk.Item(x).Checked Then
                objCmpDtpI.Item(x).Value = horDet.horaInicial
                objCmpDtpF.Item(x).Value = horDet.horaFinal
                objCmpDtpMin.Item(x).Value = horDet.minLaborar
                objCmpDtpC.Item(x).Value = horDet.tiempoComida
            Else
                objCmpDtpI.Item(x).Value = Now
                objCmpDtpF.Item(x).Value = Now
                objCmpDtpMin.Item(x).Value = Now
                objCmpDtpC.Item(x).Value = Now.Year & "-" & Now.Month & "-" & Now.Day & " 01:00:00"
            End If

        Next
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        hor.nombreHorario = txtNombre.Text
        hor.esActivo = esActivo.Checked
        hor.tabla = tabla
        hor.tipoHorario = tipoHorario

        If cbSucursal.SelectedIndex <> -1 Then
            hor.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            hor.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            hor.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            hor.idEmpresa = Nothing
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            hor = objDgvHor.Item(indice)
            asignaDatos()
        End If
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim acc As Boolean

        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnReportes.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False

            txtNombre.Select()
            acc = True

        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnReportes.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True

            acc = False
            'acc = True 'Claustro...
        End If

        For i As Integer = 0 To objCmpDtpI.Count - 1
            objCmpDtpI(i).Enabled = acc
            objCmpDtpF(i).Enabled = acc
            objCmpDtpMin(i).Enabled = acc
            objCmpChk(i).Enabled = acc
            objCmpDtpC(i).Enabled = acc
        Next

        cbSucursal.Enabled = acc
        txtNombre.Enabled = acc
        btnCopiar.Enabled = acc
    End Sub

    Private Sub definirOperacion()
        For x As Integer = 0 To 6
            horDet.numDia = x + 1

            If objCmpChk.Item(x).Checked Then
                horDet.horaInicial = objCmpDtpI.Item(x).Value
                horDet.horaFinal = objCmpDtpF.Item(x).Value
                horDet.minLaborar = objCmpDtpMin.Item(x).Value
                horDet.tiempoComida = objCmpDtpC.Item(x).Value
                If Not horDet.guardar() Then
                    MsgBox("Error: " & horDet.descripError)
                End If
            Else
                horDet.eliminar()
            End If
        Next
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Dim operacion As Boolean = True
        obtenerDatos()
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not hor.guardar() Then
                Mensaje.Mensaje = hor.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el horario"
                horDet.idHorario = hor.idHorario
                definirOperacion()
                nuevoReg = False
                operacion = False
            End If
        Else
            If Not hor.actualizar() Then
                Mensaje.Mensaje = hor.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el horario"
                definirOperacion()
                operacion = False
            End If
        End If
        Mensaje.ShowDialog()
        If Not operacion Then
            hor.cargaGridCom(DataGridView1, objDgvHor)
            habilitarBotones()
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el horario: " & hor.nombreHorario & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            hor.eliminar()
            definirOperacion()
            hor.cargaGridCom(DataGridView1, objDgvHor)
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Horario"
        frmComentario.idTabla = hor.idHorario
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        hor.cargaGridCom(DataGridView1, objDgvHor)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Horario"
        frmLogTransaccion.idTabla = hor.idHorario
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub frmHorario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim visibleDtp As Boolean

        listas()

        hor = New Horario(Ambiente)
        horDet = New HorarioDetalle(Ambiente)

        hor.idEmpresa = Ambiente.empr.idEmpresa
        hor.tabla = tabla
        hor.tipoHorario = tipoHorario

        hor.cargaGridCom(DataGridView1, objDgvHor)

        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        lblStatus.Text = ""

        If tipoHorario = "CO" Then
            visibleDtp = False
        Else
            visibleDtp = True
        End If

        lblMinLaborar.Visible = visibleDtp

        For i As Integer = 0 To objCmpDtpMin.Count - 1
            objCmpDtpMin(i).Visible = visibleDtp
        Next

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub listas()
        fechaInicial()
        fechaFinal()
        minLaborar()
        estado()
        tiempoComida()
    End Sub

    Private Sub tiempoComida()
        objCmpDtpC.Clear()
        objCmpDtpC.Add(DtpC1)
        objCmpDtpC.Add(DtpC2)
        objCmpDtpC.Add(DtpC3)
        objCmpDtpC.Add(DtpC4)
        objCmpDtpC.Add(DtpC5)
        objCmpDtpC.Add(DtpC6)
        objCmpDtpC.Add(DtpC7)
    End Sub

    Private Sub fechaInicial()
        objCmpDtpI.Clear()
        objCmpDtpI.Add(DtpI1)
        objCmpDtpI.Add(DtpI2)
        objCmpDtpI.Add(DtpI3)
        objCmpDtpI.Add(DtpI4)
        objCmpDtpI.Add(DtpI5)
        objCmpDtpI.Add(DtpI6)
        objCmpDtpI.Add(DtpI7)
    End Sub

    Private Sub fechaFinal()
        objCmpDtpF.Clear()
        objCmpDtpF.Add(DtpF1)
        objCmpDtpF.Add(DtpF2)
        objCmpDtpF.Add(DtpF3)
        objCmpDtpF.Add(DtpF4)
        objCmpDtpF.Add(DtpF5)
        objCmpDtpF.Add(DtpF6)
        objCmpDtpF.Add(DtpF7)
    End Sub

    Private Sub minLaborar()
        objCmpDtpMin.Clear()
        objCmpDtpMin.Add(DtpMin1)
        objCmpDtpMin.Add(DtpMin2)
        objCmpDtpMin.Add(DtpMin3)
        objCmpDtpMin.Add(DtpMin4)
        objCmpDtpMin.Add(DtpMin5)
        objCmpDtpMin.Add(DtpMin6)
        objCmpDtpMin.Add(DtpMin7)
    End Sub

    Private Sub estado()
        objCmpChk.Clear()
        objCmpChk.Add(Chb1)
        objCmpChk.Add(Chb2)
        objCmpChk.Add(Chb3)
        objCmpChk.Add(Chb4)
        objCmpChk.Add(Chb5)
        objCmpChk.Add(Chb6)
        objCmpChk.Add(Chb7)
    End Sub

    Private Sub DtpI1_ValueChanged(sender As Object, e As EventArgs) Handles DtpI1.ValueChanged
        calculaMinimo(DtpI1.Value, DtpF1.Value, DtpMin1)
    End Sub

    Private Sub DtpI2_ValueChanged(sender As Object, e As EventArgs) Handles DtpI2.ValueChanged
        calculaMinimo(DtpI2.Value, DtpF2.Value, DtpMin2)
    End Sub

    Private Sub DtpI3_ValueChanged(sender As Object, e As EventArgs) Handles DtpI3.ValueChanged
        calculaMinimo(DtpI3.Value, DtpF3.Value, DtpMin3)
    End Sub

    Private Sub DtpI4_ValueChanged(sender As Object, e As EventArgs) Handles DtpI4.ValueChanged
        calculaMinimo(DtpI4.Value, DtpF4.Value, DtpMin4)
    End Sub

    Private Sub DtpI5_ValueChanged(sender As Object, e As EventArgs) Handles DtpI5.ValueChanged
        calculaMinimo(DtpI5.Value, DtpF5.Value, DtpMin5)
    End Sub

    Private Sub DtpI6_ValueChanged(sender As Object, e As EventArgs) Handles DtpI6.ValueChanged
        calculaMinimo(DtpI6.Value, DtpF6.Value, DtpMin6)
    End Sub

    Private Sub DtpI7_ValueChanged(sender As Object, e As EventArgs) Handles DtpI7.ValueChanged
        calculaMinimo(DtpI7.Value, DtpF7.Value, DtpMin7)
    End Sub

    Private Sub DtpF1_ValueChanged(sender As Object, e As EventArgs) Handles DtpF1.ValueChanged
        calculaMinimo(DtpI1.Value, DtpF1.Value, DtpMin1)
    End Sub

    Private Sub DtpF2_ValueChanged(sender As Object, e As EventArgs) Handles DtpF2.ValueChanged
        calculaMinimo(DtpI2.Value, DtpF2.Value, DtpMin2)
    End Sub

    Private Sub DtpF3_ValueChanged(sender As Object, e As EventArgs) Handles DtpF3.ValueChanged
        calculaMinimo(DtpI3.Value, DtpF3.Value, DtpMin3)
    End Sub

    Private Sub DtpF4_ValueChanged(sender As Object, e As EventArgs) Handles DtpF4.ValueChanged
        calculaMinimo(DtpI4.Value, DtpF4.Value, DtpMin4)
    End Sub

    Private Sub DtpF5_ValueChanged(sender As Object, e As EventArgs) Handles DtpF5.ValueChanged
        calculaMinimo(DtpI5.Value, DtpF5.Value, DtpMin5)
    End Sub

    Private Sub DtpF6_ValueChanged(sender As Object, e As EventArgs) Handles DtpF6.ValueChanged
        calculaMinimo(DtpI6.Value, DtpF6.Value, DtpMin6)
    End Sub

    Private Sub DtpF7_ValueChanged(sender As Object, e As EventArgs)
        calculaMinimo(DtpI7.Value, DtpF7.Value, DtpMin7)
    End Sub

    Private Sub calculaMinimo(fecha1 As Date, fecha2 As Date, asignarValor As DateTimePicker)
        Try
            asignarValor.Value = DateAdd(DateInterval.Second, (DateDiff(DateInterval.Second, fecha1, fecha2) - 3600) / 2, CDate(Format(Now, "yyyy-MM-dd")))
        Catch ex As Exception
            MsgBox(ex.Message)
            asignarValor.Value = Now
        End Try

    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        For i As Integer = 1 To objCmpChk.Count - 1
            If objCmpChk(i).Checked Then
                objCmpDtpC(i).Value = objCmpDtpC(0).Value
                objCmpDtpI(i).Value = objCmpDtpI(0).Value
                objCmpDtpF(i).Value = objCmpDtpF(0).Value
                objCmpDtpMin(i).Value = objCmpDtpMin(0).Value
            End If
        Next
    End Sub
End Class