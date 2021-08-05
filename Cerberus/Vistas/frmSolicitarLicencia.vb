Imports System.Xml

Public Class frmSolicitarLicencia
    Private Sub btnSolicitud_Click(sender As Object, e As EventArgs) Handles btnSolicitud.Click
        Dim m_xmld As New XmlDocument
        Try
            m_xmld.Load("https://www.scsoluciones.com/kairos/?codigo=1000")
        Catch ex As Exception
            MsgBox("Ocurrio un error al leer el XML: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Dim servidor = m_xmld.GetElementsByTagName("Datos")

        Try
            For Each m_node As XmlNode In servidor
                MsgBox("asdasd")
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class