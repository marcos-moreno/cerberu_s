Imports System.IO
Imports System.Text
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary

Public Class Reporte
    Private mrt As StiReport
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Private arch As Archivo
    Private var As StiVariablesCollection
    Private elementoSistema As String
    Private tabla As String

    Private conexSti As New List(Of String)
    Private conexStringSti As New List(Of String)

    Public Sub New(Ambiente As AmbienteCls, tabla As String, elementoSistema As String)
        Me.Ambiente = Ambiente
        Me.tabla = tabla
        Me.elementoSistema = elementoSistema

        arch = New Archivo(Ambiente)
        mrt = New StiReport
        Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkJzUxpYOSQt2qENCafURbabXVb7Mus7QkJPq3zJ3xo+2YTtV" +
                                            "K97cSbxCZ0Md98tI5FtH599DJK57dt5aiYoncFVz1U4BeeyyULN4r4ovQILM6YcWsmuMh2IJoOW9RpGLiVE3bjs4W8" +
                                            "WcSl0sykEIBDuciWPsSFSWiCxrQGvzPxwp5eRmuf8o+3C9BMJOq/XornO4Q8jWUf8jXkkkIWiPrzhRSJeOZ/G4qifw" +
                                            "QnfDpSACiCtZ8ZRJ03HudaGoM6vutaKa4mw6g/kODaxwpugRcSAb+PvPEfrxkLxeblwbAQWphETpIudmU5eXa/RrxC" +
                                            "HCcBzm8nsXfqSaBkvj9F+7t9Th5iflSawOTUAy1vBiu7VbEkysqzHpbV2tqWNAMFAg6tEL7rT4lYwXnDGCQIrFtDdS" +
                                            "MWUp/1mfFTNpkJdS/LHcrd591zTVCiRkc8jeo6XXjRhhDSE7FGTjCBAvuiFax+myKk+WijfGX5zd3HHt4AdpwAawqh" +
                                            "yeNAGyN6Bj1lAPg4qldFy9uTzC0v2tQJF8gl"

        var = New StiVariablesCollection
        conexSti.Clear()
        conexStringSti.Clear()
    End Sub

    Public Sub agregaVarible(nombreVar As String, datoVar As Object, tipo As Type)
        Dim valorVar As New StiVariable
        valorVar.Type = tipo
        valorVar.ValueObject = datoVar
        valorVar.Name = nombreVar
        valorVar.Alias = nombreVar

        var.Add(valorVar)
    End Sub

    Public Sub agregaVaribleRU(nombreVar As String, datoVar As Object, tipo As Type)
        Dim valorVar As New StiVariable
        valorVar.Type = tipo
        valorVar.ValueObject = datoVar
        valorVar.Name = nombreVar
        valorVar.Alias = nombreVar
        valorVar.RequestFromUser = True

        var.Add(valorVar)
    End Sub

    Public Sub agregaVarible(nombreVar As String, datoVar As String)
        var.Add(nombreVar, datoVar)
    End Sub

    Public Sub modConexSti(nombreConex As String, conexion As String)
        conexSti.Add(nombreConex)
        conexStringSti.Add(conexion)
    End Sub


    Private Function ObtenerArchivo() As Boolean
        arch = New Archivo(Ambiente)
        arch.tabla = tabla
        arch.idEmpresa = Ambiente.empr.idEmpresa
        arch.elementoSistema = elementoSistema
        arch.tipoArchivo = "Reporte"

        If arch.buscarArchivoPTblTipoArchivo() Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub CrearArchivo()
        arch = New Archivo(Ambiente)

        arch.tabla = tabla
        arch.tipoArchivo = "Reporte"
        arch.elementoSistema = elementoSistema

        If arch.rutaOriginal = "" Then
            arch.rutaOriginal = "Plantilla.mrt"
            arch.nombreArchivo = "Rpt_" & tabla & ".mrt"
        End If

        If arch.guardar() Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Se guardo el reporte correctamente..."
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Reporte.CrearArchivo"
            Mensaje.Mensaje = arch.descripError
        End If
        Mensaje.ShowDialog()
    End Sub

    Public Sub imprimir(ds As DataSet)
        If Not ObtenerArchivo() Then
            CrearArchivo()
        End If

        mrt.Load(arch.datos)
        mrt.RegData(tabla, ds)

        'AGREGA VARIABLEs
        For Each varSys As StiVariable In var
            mrt.Dictionary.Variables.Add(varSys)
        Next

        'MODIFICAR CADENA DE CONEXIONES.
        Dim sqlDB As New StiSqlDatabase
        For i As Integer = 0 To conexSti.Count - 1
            sqlDB = CType(mrt.Dictionary.Databases(conexSti(i)), StiSqlDatabase)
            If sqlDB Is Nothing Then
            Else
                sqlDB.ConnectionString = conexStringSti(i)
            End If
        Next

        mrt.Dictionary.Synchronize()
        mrt.Render()

        mrt.Show()
    End Sub

    Public Sub modificar(ds As DataSet)
        Dim nombreTemp As String

        If Not ObtenerArchivo() Then
            CrearArchivo()
        End If
        Dim path As String = "C:\Users\" & Environment.UserName & "\.cerberus\"

        nombreTemp = path & "Temp_" & tabla & ".mrt"

        If Dir(path, vbDirectory) = "" Then
            My.Computer.FileSystem.CreateDirectory(path)
        End If
        mrt.Load(arch.datos)
        mrt.Save(nombreTemp)
        mrt.RegData(tabla, ds)
        'AGREGA VARIABLEs
        For Each varSys As StiVariable In var
            mrt.Dictionary.Variables.Add(varSys)
        Next

        'MODIFICAR CADENA DE CONEXIONES.
        Dim sqlDB As New StiSqlDatabase
        For i As Integer = 0 To conexSti.Count - 1
            sqlDB = CType(mrt.Dictionary.Databases(conexSti(i)), StiSqlDatabase)
            If sqlDB Is Nothing Then
            Else
                sqlDB.ConnectionString = conexStringSti(i) '"Server=db.refividrio.com.mx; Port=65432; Database=rfhoods;User Id=adempiere; Password=[_rfhood_.?/];"
            End If
        Next
        mrt.Dictionary.Synchronize()
        mrt.Design(True)
        arch.datos = mrt.SaveToByteArray()
        arch.actualizar()
        If File.Exists(nombreTemp) Then
            File.Delete(nombreTemp)
        End If
    End Sub
End Class
