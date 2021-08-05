Imports System.IO
Imports System.Xml
Imports System.Net

Public Class frmSelecConexion
    Private WithEvents WC As New WebClient
    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Dim rutaFileInfo As String = "InfoAboutDownload.txt"
    Dim InfoAboutUpdActualizador As String = "InfoAboutUpdActualizador.txt"
    Private archivoConfig As String

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        archivoConfig = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        cargarConexion()
    End Sub

    Private Sub cargarConexion()
        Me.Hide()
        conex = New ConexionSQL(archivoConfig, 2)
        If Not conex.estadoConn(0) Then
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "frmSelecConexion.Load:"
            Mensaje.Mensaje = conex.descripError & ", por lo que se cerrará la aplicación."
            Mensaje.ShowDialog()
            Me.Dispose()
        End If
        Ambiente = New AmbienteCls(conex)
        Ambiente.estacion = My.Computer.Name
        frmLogin.Ambiente = Ambiente
        frmLogin.Show()
    End Sub

    Private Sub frmSelecConexion_Load(sender As Object, e As EventArgs) Handles Me.Load
        'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        If dowloandActualizador() Then
            saveInfoAboutDownload(InfoAboutUpdActualizador)
        End If
        If check() Then
            Try
                Dim startInfo = New ProcessStartInfo("actualizador.exe")
                startInfo.Verb = "runas"
                Process.Start(startInfo)
                Me.Close()
            Catch ex As Exception
                conex = New ConexionSQL("conexiones.xml", DataGridView1)
            End Try
        Else
            conex = New ConexionSQL("conexiones.xml", DataGridView1)
        End If
    End Sub

    Private Sub saveInfoAboutDownload(ruta As String)
        ' Dim ruta As String = "InfoAboutDownload.txt"
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(ruta)
        Dim thisDate As String
        thisDate = Format(Today, "yyyy/MM/dd")
        'MsgBox(thisDate)
        objStreamWriter.WriteLine(thisDate)
        objStreamWriter.Close()
    End Sub

    Private Sub saveInfoAboutDownload()
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(InfoAboutUpdActualizador)
        Dim thisDate As String
        thisDate = Format(Today, "yyyy/MM/dd")
        'MsgBox(thisDate)
        objStreamWriter.WriteLine(thisDate)
        objStreamWriter.Close()
    End Sub

    Private Function dowloandActualizador() As Boolean
        Dim value As Boolean = True
        If checkUpdActualizador() Then
            prepare.Visible = True
            Try
                If File.Exists("actualizador.exe") Then
                    My.Computer.FileSystem.DeleteFile("actualizador.exe")
                End If
                WC.DownloadFileAsync(New Uri("http://refividrio.com.mx/programas/refividrio/apps/actualizacionCerberus/actualizador.exe"), "actualizador.exe")
                value = True
            Catch ex As Exception
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = ex.Message
                Mensaje.ShowDialog()
                value = False
            End Try
        Else
            value = False
        End If
        prepare.Visible = False
        Return value
    End Function

    Private Function checkUpdActualizador() As Boolean
        Dim _dateUpdate As String
        If ReadfoAboutDownload(True) Is Nothing Then
            _dateUpdate = "0000-00-00"
        Else
            _dateUpdate = ReadfoAboutDownload(True)
        End If
        Try
            Dim iDate As String = _dateUpdate
            Dim oDate As DateTime = Convert.ToDateTime(iDate)
            _dateUpdate = oDate.Year & "-" & oDate.Month & "-" & oDate.Day
        Catch ex As Exception
            _dateUpdate = "0000-00-00"
        End Try

        Try
            Dim request As WebRequest =
            WebRequest.Create("http://refividrio.com.mx/programas/refividrio/apps/actualizacionCerberus/actualizador.php?date=" & _dateUpdate)
            Dim response As WebResponse = request.GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim res As String = reader.ReadToEnd()
            reader.Close()
            response.Close()
            If res = "SI" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "No cuentas Con Acceso a Internet."
            Mensaje.ShowDialog()
            Return False
        End Try
    End Function

    Private Function check() As Boolean
        Dim _dateUpdate As String
        If ReadfoAboutDownload(False) Is Nothing Then
            _dateUpdate = "0000-00-00"
        Else
            _dateUpdate = ReadfoAboutDownload(False)
        End If
        Try
            Dim iDate As String = _dateUpdate
            Dim oDate As DateTime = Convert.ToDateTime(iDate)
            _dateUpdate = oDate.Year & "-" & oDate.Month & "-" & oDate.Day
        Catch ex As Exception
            _dateUpdate = "0000-00-00"
        End Try

        Try
            Dim request As WebRequest =
            WebRequest.Create("http://refividrio.com.mx/programas/refividrio/apps/actualizacionCerberus/index.php?date=" & _dateUpdate)
            Dim response As WebResponse = request.GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim res As String = reader.ReadToEnd()
            reader.Close()
            response.Close()
            If res = "SI" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "No cuentas Con Acceso a Internet."
            Mensaje.ShowDialog()
            Return False
        End Try
    End Function

    Private Function ReadfoAboutDownload(isActualizador As Boolean) As String
        Dim nameFile As String
        If isActualizador Then
            nameFile = InfoAboutUpdActualizador
        Else
            nameFile = rutaFileInfo
        End If
        If File.Exists(nameFile) Then
            Dim leer As New StreamReader(nameFile)
            Dim value As String = Nothing
            Try
                While leer.Peek <> -1
                    Dim linea As String = leer.ReadLine()
                    value = linea
                End While
                leer.Close()
                Return value
            Catch ex As Exception
                Return Nothing
            End Try
            Return Nothing
        Else
            Return Nothing
        End If
    End Function


    Private Sub frmSelecConexion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If DataGridView1.Rows.Count = 1 Then
            archivoConfig = DataGridView1.Rows(0).Cells(2).Value
            cargarConexion()
        End If
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        If DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value = "VPN" Then
            If File.Exists("conexiones.xml") Then
                My.Computer.FileSystem.DeleteFile("conexiones.xml")
            End If
            If Not File.Exists("conexiones.xml") Then
                My.Computer.FileSystem.CopyFile("conexionesVPN.xml", "conexiones.xml")
                MessageBox.Show("Hecho")
            End If
        ElseIf DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value = "RED LOCAL" Then
            If File.Exists("conexiones.xml") Then
                My.Computer.FileSystem.DeleteFile("conexiones.xml")
            End If
            If Not File.Exists("conexiones.xml") Then
                My.Computer.FileSystem.CopyFile("conexionesLOCAL.xml", "conexiones.xml")
                MessageBox.Show("Hecho")
            End If
        End If
    End Sub
End Class