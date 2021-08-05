Imports System.ComponentModel

Public Class frmEvento
    Public Ambiente As AmbienteCls
    Private eve As Evento
    Private disp As Dispositivo
    Private objDGEvento As New List(Of Evento)
    Private objCBDispo As New List(Of Dispositivo)

    Private Sub frmEvento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        eve = New Evento(Ambiente)
        eve.idEmpresa = Ambiente.empr.idEmpresa

        cargarGrid()

        disp = New Dispositivo(Ambiente)
        disp.idEmpresa = Ambiente.empr.idEmpresa
        disp.getComboActivo(cbDispositivo, objCBDispo)
    End Sub

    Private Sub EjecutarEventoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EjecutarEventoToolStripMenuItem.Click
        EjecutarEventoToolStripMenuItem.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        pbAccion.Maximum = 10
        pbAccion.Value = 5

        Dim eventosEjecutados As Integer
        Mensaje.Mensaje = ""

        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                eve.idEvento = objDGEvento.Item(DataGridView1.SelectedRows(i).Index).idEvento
                If eve.buscarPID() Then
                    If eve.ejecutarEvento() Then
                        eventosEjecutados += 1
                        eve.esActivo = False
                    Else
                        eve.intentos += 1
                        eve.ultimoError = eve.descripError
                        If eve.idError = -100 Then
                            eve.fechaInicial = Nothing
                            eve.fechaFinal = Nothing
                        End If
                        Mensaje.Mensaje &= "ERROR ID (" & eve.idEvento & ") - " & eve.descripError & vbCrLf
                    End If

                    If Not eve.actualizar() Then
                        Mensaje.Mensaje &= "Ocurrio un eroro al Intentar Actualizar el Evento: " & eve.descripError & vbCrLf
                    End If
                Else
                    Mensaje.Mensaje &= "NO SE ENCONTRO EL ID (" & eve.idEvento & ") - " & eve.descripError & vbCrLf
                End If
            Next

            If eventosEjecutados > 0 Then
                Mensaje.Mensaje &= "Se ejecutaron (" & eventosEjecutados & ") evento(s), correctamente..."
            End If

            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        EjecutarEventoToolStripMenuItem.Enabled = True
        cargarGrid()
        pbAccion.Maximum = 0
        pbAccion.Value = 0
    End Sub

    Private Sub cargarGrid()
        Dim estacion As String

        If chbSoloLocales.Checked Then
            estacion = Ambiente.estacion
        Else
            estacion = ""
        End If

        If cbDispositivo.SelectedIndex <> -1 Then
            eve.cargaGrid(DataGridView1, objDGEvento, objCBDispo.Item(cbDispositivo.SelectedIndex).idDispositivo, estacion)
        Else
            eve.cargaGrid(DataGridView1, objDGEvento, Nothing, estacion)
        End If
    End Sub

    Private Sub SoloLosDeMiUbicaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoloLosDeMiUbicaciónToolStripMenuItem.Click
        cargarGrid()
    End Sub

    Private Sub cbDispositivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDispositivo.SelectedIndexChanged
        cargarGrid()
    End Sub

    Private Sub ExtraccionDeRegistrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtraccionDeRegistrosToolStripMenuItem.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        Dim todoBien As Boolean
        If eve.generarExtraccionAutDispositivos() Then
            Mensaje.Mensaje = "Se generaron correctamente los eventos pendientes de extraccion de registros..."
            todoBien = True
        Else
            Mensaje.Mensaje = eve.descripError
            todoBien = False
        End If
        Mensaje.ShowDialog()

        If todoBien Then
            cargarGrid()
        End If
    End Sub

    Private Sub FijarFechaHoraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FijarFechaHoraToolStripMenuItem1.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        Dim todoBien As Boolean
        If eve.generarFijarHoraAutDispositivos() Then
            Mensaje.Mensaje = "Se generaron correctamente los eventos pendientes para fijar la hora correcta de los Dispositivos..."
            todoBien = True
        Else
            Mensaje.Mensaje = eve.descripError
            todoBien = False
        End If
        Mensaje.ShowDialog()

        If todoBien Then
            cargarGrid()
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim eventosEjecutados As Integer = 0
        Mensaje.Mensaje = ""

        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                eve.idEvento = objDGEvento.Item(DataGridView1.SelectedRows(i).Index).idEvento
                If eve.buscarPID() Then
                    eve.esActivo = False
                    eve.ultimoError = "CANCELADO MANUALMENTE " & Ambiente.usuario.usuario

                    If Not eve.actualizar() Then
                        Mensaje.Mensaje &= "Ocurrio un eroro al Intentar Actualizar el Evento: " & eve.descripError & vbCrLf
                    Else
                        eventosEjecutados += 1
                    End If
                Else
                    Mensaje.Mensaje &= "NO SE ENCONTRO EL ID (" & eve.idEvento & ") - " & eve.descripError & vbCrLf
                End If
            Next

            If eventosEjecutados > 0 Then
                Mensaje.Mensaje &= "Se Eliminaron (" & eventosEjecutados & ") evento(s), correctamente..."
                cargarGrid()
            End If

            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub chbSoloLocales_Click(sender As Object, e As EventArgs) Handles chbSoloLocales.Click
        cargarGrid()
    End Sub
End Class