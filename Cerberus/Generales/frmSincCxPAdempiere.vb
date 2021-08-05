Imports System.IO
Imports System.Threading

Public Class frmSincCxPAdempiere

    Public ambiente As AmbienteCls
    Private controllerSync As Ctl_ProcessSync
    Private threadConect As Thread 'hilo 1 
    Private threadSinc As Thread 'hilo 2

    Private _ListidCombos As List(Of Integer) = New List(Of Integer)


    Private Sub frmSincCxPAdempiere_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        threadConect = New Thread(AddressOf connectADempiere)
        imgLoad.Visible = True
        threadConect.Start()
    End Sub


    Private Sub processConsult()
        lblEstado.Text = "Sincronizando...."
        imgLoad.Visible = True
        threadSinc = New Thread(AddressOf Sincronizar)
        threadSinc.Start()
    End Sub


    Public Sub Sincronizar()
        Try
            controllerSync.execute(_ListidCombos.Item(cbxSucursal.SelectedIndex))
            lblEstado.Text = "Sincronización Terminada."
            imgLoad.Visible = False
            Mensaje.Mensaje = "Sincronización Completa"
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        Catch ex As ThreadAbortException

        End Try
    End Sub

    Public Sub connectADempiere()
        Try
            lblEstado.Text = "Conectando Con ADempi " & ambiente.empr.nombreEmpresa & "......"
            controllerSync = New Ctl_ProcessSync(ambiente)
            If controllerSync.postgresState Then
                imgLoad.Visible = False
                lblEstado.Text = "Conectado con ADempiere " & ambiente.empr.nombreEmpresa
                controllerSync.fillComboSucursales(cbxSucursal, _ListidCombos)
            Else
                imgLoad.Visible = True
                lblEstado.Text = "Error, no se puede conectar con ADempiere, Contacta al Administrador."
            End If
        Catch ex As ThreadAbortException
            lblEstado.Text = "La conexión no se pudo establecer."
            imgLoad.Visible = False
        End Try
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim path As String = "C:\Users\" & Environment.UserName & "\.cerberus\Logs\"
        Dim fileName As String = path & DateTime.Now.ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("hh") + ".log"
        If Not File.Exists(fileName) Then
            Process.Start("explorer.exe", My.Computer.FileSystem.CurrentDirectory)
        Else
            Process.Start("notepad.exe", fileName)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbxSucursal.SelectedIndex > -1 Then
            processConsult()
        Else
            Mensaje.Mensaje = "Selecciona una sucursal"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If


    End Sub
End Class