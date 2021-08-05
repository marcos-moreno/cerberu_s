Imports System.Data.SqlClient
Imports System.IO
Imports Cerberus

Public Class Archivo
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idArchivo As Integer
    Public tabla As String
    Public datos As Byte()
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public extension As String
    Public tipoArchivo As String
    Public nombreArchivo As String
    Public creadoPor As Integer
    Public creado As DateTime
    Public actualizadoPor As Integer
    Public actualizado As DateTime
    Public rutaOriginal As String
    Public idTabla As Integer
    Public elementoSistema As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Function ByteToImage() As Bitmap
        Dim mStream As New MemoryStream()
        mStream.Write(datos, 0, Convert.ToInt32(datos.Length))
        Dim bm As New Bitmap(mStream, False)
        mStream.Dispose()
        Return bm
    End Function

    Public Function abrirArchivo() As Boolean
        Dim folderName As String
        Dim path As String = "C:\Users\" & Environment.UserName & "\.cerberus\"
        folderName = path & "adjuntos\"
        If creaArchivo(folderName) Then
            Process.Start(folderName & nombreArchivo)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function creaArchivo(folderName As String) As Boolean
        Try
            If Not Directory.Exists(folderName) Then
                Directory.CreateDirectory(folderName)
            End If
        Catch ex As Exception
            idError = 1
            descripError = ex.Message
        End Try

        Dim fileName As String
        Dim path As String = "C:\Users\" & Environment.UserName & "\.cerberus\"
        fileName = path & "adjuntos\" & nombreArchivo

        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles("Temporales\" & nombreArchivo, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
                File.Delete(foundFile)
            Next
        Catch ex As Exception

        End Try

        Try
            Dim dbyte As Byte() = datos

            File.WriteAllBytes(fileName, dbyte)
            If Not System.IO.File.Exists(fileName) Then
                idError = 2
                descripError = "No se creo el archivo correctamente..."
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function

    Public Sub cargarGrid(grid As DataGridView, objEmp As List(Of Archivo))
        Dim plantilla As Archivo
        Dim dtb As New DataTable("Archivo")
        Dim row As DataRow

        dtb.Columns.Add("Tipo de Archivo", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre Archivo", Type.GetType("System.String"))
        dtb.Columns.Add("Creado", Type.GetType("System.String"))
        dtb.Columns.Add("Creado Por", Type.GetType("System.String"))

        objEmp.Clear()

        conex.accion = "SELECT"
        conex.agregaCampo("a.*")
        conex.agregaCampo("e.nombreEmpleado")
        conex.tabla = "Archivo as a,Empleado as e"
        conex.condicion = "WHERE a.creadoPor = e.idEmpleado AND a.idTabla = " & idTabla
        conex.condicion &= " AND a.tabla = '" & tabla & "' AND elementoSistema='" & elementoSistema & "' AND tipoArchivo='" & tipoArchivo & "'"

        conex.armarQry()

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Archivo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)

                row = dtb.NewRow
                row("Tipo de Archivo") = plantilla.extension
                row("Nombre Archivo") = plantilla.nombreArchivo
                row("Creado") = plantilla.creado
                row("Creado Por") = conex.reader("CreadoPor")

                dtb.Rows.Add(row)
            End While

            grid.DataSource = dtb
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Archivo.cargarGrid"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function buscarArchivoPTblTipoArchivo() As Boolean
        conex.Qry = "SELECT * FROM Archivo WHERE tabla = '" & tabla & "' and idEmpresa = " & idEmpresa & " AND tipoArchivo = '" & tipoArchivo & "' AND elementoSistema ='" & elementoSistema & "'"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                conex.descripError = "El Archivo Buscado no Existe...."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError

            Return False
        End If
    End Function

    Public Function buscarArchivoPTblIdTTipoArchivoElem() As Boolean
        conex.Qry = "SELECT * FROM Archivo WHERE tabla = '" & tabla & "' and idTabla = " & idTabla & " and idEmpresa = " & idEmpresa & " AND tipoArchivo = '" & tipoArchivo & "' AND elementoSistema ='" & elementoSistema & "'"
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                conex.descripError = "El Archivo Buscado no Existe...."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError

            Return False
        End If
    End Function

    Public Function buscarArchivoPTblAndID() As Boolean
        conex.Qry = "SELECT * FROM Archivo WHERE tabla = '" & tabla & "' and idTabla = " & idTabla
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                idError = 1
                conex.descripError = "El Archivo Buscado no Existe...."
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError

            Return False
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idArchivo = rdr("idArchivo")
        tabla = rdr("tabla")
        datos = rdr("datos")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        extension = rdr("extension")
        tipoArchivo = rdr("tipoArchivo")
        nombreArchivo = rdr("nombreArchivo")
        creadoPor = rdr("creadoPor")
        creado = rdr("creado")
        actualizadoPor = rdr("actualizadoPor")
        actualizado = rdr("actualizado")
        rutaOriginal = rdr("rutaOriginal")
        elementoSistema = rdr("elementoSistema")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        idError = 0
        descripError = ""

        If Not validaDatos(True) Then
            Return False
        End If

        conex.numCon = 0

        conex.tabla = "Archivo"
        conex.accion = "INSERT"

        conex.agregaCampo("elementoSistema", elementoSistema, False, False)
        conex.agregaCampo("idTabla", idTabla, False, False)
        conex.agregaCampo("tabla", tabla, False, False)
        conex.agregaCampo("datos", "@Datos", False, True)
        conex.agregaCampo("idEmpresa", idEmpresa, True, False)
        conex.agregaCampo("idSucursal", idSucursal, True, False)
        conex.agregaCampo("extension", extension, False, False)
        conex.agregaCampo("tipoArchivo", tipoArchivo, False, False)
        conex.agregaCampo("nombreArchivo", nombreArchivo, False, False)
        conex.agregaCampo("creadoPor", creadoPor, False, False)
        conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
        conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
        conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
        conex.agregaCampo("rutaOriginal", rutaOriginal, False, False)

        conex.armarQry()

        'conex.Qry = "INSERT INTO Archivo (elementoSistema,idTabla,tabla,datos,idEmpresa,idSucursal,extension,tipoArchivo,nombreArchivo,creadoPor,creado,actualizadoPor,actualizado,rutaOriginal) 
        'VALUES('" & elementoSistema & "'," & idTabla & ",'" & tabla & "',@Datos," & idEmpresa & "," & idSucursal & ",'" & extension & "','" & tipoArchivo & "','" & nombreArchivo & "'," & creadoPor & ",CURRENT_TIMESTAMP," & actualizadoPor & ", CURRENT_TIMESTAMP, '" & rutaOriginal & "')"

        If conex.ejecutaQry(datos) Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError ' & "  &    " & conex.Qry
            Return False
        End If

    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        idError = 0
        descripError = ""

        If Not validaDatos(False) Then
            Return False
        End If

        conex.numCon = 0
        conex.Qry = "UPDATE Archivo SET datos=@Datos,actualizado=CURRENT_TIMESTAMP,actualizadoPor=" & actualizadoPor & " WHERE idEmpresa = " & idEmpresa & " AND tabla='" & tabla & "' AND tipoArchivo = '" & tipoArchivo & "' AND elementoSistema='" & elementoSistema & "'"

        If conex.ejecutaQry(datos) Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError

            Return False
        End If
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        conex.numCon = 0
        conex.Qry = "DELETE FROM Archivo WHERE idArchivo = " & idArchivo
        If conex.ejecutaQry Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        idError = 0
        descripError = ""

        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado

            If idEmpresa = 0 Then
                idEmpresa = Ambiente.empr.idEmpresa
            End If

            If idSucursal = 0 Then
                idSucursal = Ambiente.suc.idSucursal
            End If

            Try
                Dim fInfo As New FileInfo(rutaOriginal)
                Dim numBytes As Long = fInfo.Length
                Dim fs As New FileStream(rutaOriginal, FileMode.Open, FileAccess.Read)
                Dim br As New BinaryReader(fs)

                'CARGA DATOS
                datos = br.ReadBytes(CInt(numBytes))
                extension = fInfo.Extension

                If nombreArchivo = "" Then
                    nombreArchivo = fInfo.Name
                End If

                br.Close()
                fs.Close()

            Catch ex As Exception
                idError = ex.HResult
                descripError = ex.Message
                Return False
            End Try
        End If

        actualizadoPor = Ambiente.usuario.idEmpleado

        Return True
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        Throw New NotImplementedException()
    End Function
End Class
