Imports System.Management

Public Class Utilerias
    Public nombreSO As String
    Public versionSO As String
    Public ArquitecturaSO As String
    Public nombrePC As String
    Public usuarioPC As String
    Public serialHDD As String
    Public serialMotherboard As String


    Public Function quitarAcentos(texto As String) As String
        Dim textoMod As String
        textoMod = texto

        textoMod = Replace(textoMod, "á", "a")
        textoMod = Replace(textoMod, "é", "e")
        textoMod = Replace(textoMod, "í", "i")
        textoMod = Replace(textoMod, "ó", "o")
        textoMod = Replace(textoMod, "ú", "u")

        textoMod = Replace(textoMod, "Á", "A")
        textoMod = Replace(textoMod, "É", "E")
        textoMod = Replace(textoMod, "Í", "I")
        textoMod = Replace(textoMod, "Ó", "O")
        textoMod = Replace(textoMod, "Ú", "U")

        Return textoMod
    End Function

    Public Sub New()
        ':::Obtenemos la informacion del Sistema operativo
        nombreSO = My.Computer.Info.OSFullName
        versionSO = My.Computer.Info.OSVersion

        Dim consultaSQLArquitectura As String = "SELECT * FROM Win32_Processor"
        Dim objArquitectura As New ManagementObjectSearcher(consultaSQLArquitectura)

        For Each info As ManagementObject In objArquitectura.Get()
            ArquitecturaSO = info.Properties("AddressWidth").Value.ToString()
        Next info

        ':::Obtenemos la informacion del Equipo
        nombrePC = My.Computer.Name
        usuarioPC = Security.Principal.WindowsIdentity.GetCurrent().Name

        ':::Obtenemos el serial del Disco Duro
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        serialHDD = serialDD.Properties("SerialNumber").Value.ToString

        ':::Obtenemos el serial de la Board
        Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
        For Each serialB As ManagementObject In serial.Get()
            serialMotherboard = (serialB.GetPropertyValue("SerialNumber").ToString)
        Next
    End Sub

End Class
