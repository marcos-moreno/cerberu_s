Imports System.Security.Cryptography
Imports System.Text

Public Class Encriptar
    Private des As New TripleDESCryptoServiceProvider 'Algorithmo TripleDES
    Private hashmd5 As New MD5CryptoServiceProvider 'objeto md5
    Public myKey As String = "RFJJ2017" 'Clave secreta(puede alterarse)

    'Funcion para el Encriptado de Cadenas de Texto
    Public Function Encriptar(ByVal texto As String) As String
        Dim textoR As String = ""

        If Trim(texto) = "" Then
            textoR = ""
        Else
            Try
                des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
                des.Mode = CipherMode.ECB
                Dim encrypt As ICryptoTransform = des.CreateEncryptor()
                Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
                textoR = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
            Catch ex As Exception
                textoR = ""
            End Try
        End If

        Return textoR
    End Function


    'Funcion para el Desencriptado de Cadenas de Texto
    Public Function Desencriptar(ByVal texto As String) As String
        Dim textoR As String = ""

        If Trim(texto) = "" Then
            textoR = ""
        Else
            Try
                des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
                des.Mode = CipherMode.ECB
                Dim desencrypta As ICryptoTransform = des.CreateDecryptor()
                Dim buff() As Byte = Convert.FromBase64String(texto)
                textoR = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length))
            Catch ex As Exception
                textoR = ""
            End Try

        End If

        Return textoR
    End Function

End Class
