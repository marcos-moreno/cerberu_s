Imports System.Data.SqlClient
Imports Cerberus

Public Class DetalleFormatoImportacion
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Public idDetalleFormatoImportacion As Integer
    Public idFormatoImportacion As Integer
    Public tabla As String
    Public columnaSQL As String
    Public esLlave As Boolean
    Public columnaArchivo As String
    Public ordenTabla As Integer
    Public ordenColumna As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idDetalleFormatoImportacion = rdr("idDetalleFormatoImportacion")
        idFormatoImportacion = rdr("idFormatoImportacion")
        tabla = rdr("tabla")
        columnaSQL = rdr("columnaSQL")
        esLlave = rdr("esLlave")
        columnaArchivo = If(IsDBNull(rdr("columnaArchivo")), Nothing, rdr("columnaArchivo"))
        ordenTabla = rdr("ordenTabla")
        ordenColumna = rdr("ordenColumna")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Throw New NotImplementedException()
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Throw New NotImplementedException()
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        Throw New NotImplementedException()
    End Function

    Public Sub cargaGrid(grid As DataGridView, obj As List(Of DetalleFormatoImportacion))
        cargarGridGen(grid, "", obj)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of DetalleFormatoImportacion))
        Dim plantilla As DetalleFormatoImportacion
        Dim dtb As New DataTable("DetalleFormatoImportacion")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Tabla", Type.GetType("System.String"))
        dtb.Columns.Add("Es Llave", Type.GetType("System.String"))
        dtb.Columns.Add("Columna SQL", Type.GetType("System.String"))
        dtb.Columns.Add("Columna Archivo", Type.GetType("System.String"))

        obj.Clear()

        conex.Qry = "SELECT D.* FROM DetalleFormatoImportacion AS D WHERE D.idFormatoImportacion = " & idFormatoImportacion & " ORDER BY ordenTabla,ordenColumna " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DetalleFormatoImportacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Tabla") = plantilla.tabla
                row("Es Llave") = plantilla.esLlave
                row("Columna SQL") = plantilla.columnaSQL
                row("Columna Archivo") = plantilla.columnaArchivo

                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DetalleFormatoImportacion.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub



    Public Function detallesFormato(obj As List(Of DetalleFormatoImportacion)) As Boolean
        Dim plantilla As DetalleFormatoImportacion
        Dim indice As Integer = 0
        obj.Clear()
        conex.Qry = "SELECT * FROM DetalleFormatoImportacion WHERE idFormatoImportacion = " & idFormatoImportacion & " ORDER BY ordenColumna "
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New DetalleFormatoImportacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                indice += 1
            End While
            conex.reader.Close()
            Return True
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "DetalleFormatoImportacion.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
        Return False
    End Function
    Public Function Importar(archivo As String, tabla As String, hoja As String, rango As String, valor1 As String, tipoArchivo As String) As Boolean
        Dim objColumnas As New List(Of DetalleFormatoImportacion)
        cargaGrid(New DataGridView, objColumnas)

        If tabla = "Cuenta" Then
            Dim objCuenta As Cuenta
            objCuenta = New Cuenta(Ambiente)

            If Not objCuenta.ImportarExcel(archivo, hoja, rango, objColumnas) Then
                idError = objCuenta.idError
                descripError = objCuenta.descripError
                Return False
            Else
                Return True
            End If
        ElseIf tabla = "Registro" And tipoArchivo.IndexOf("*.xls") <> -1 Then
            Dim objReg As Registro
            objReg = New Registro(Ambiente)
            objReg.operacion = valor1

            If Not objReg.ImportarExcel(archivo, hoja, rango, objColumnas) Then
                idError = objReg.idError
                descripError = objReg.descripError
                Return False
            Else
                Return True
            End If
        ElseIf tabla = "Registro" And tipoArchivo.IndexOf("*.dat") <> -1 Then
            Dim objReg As Registro
            objReg = New Registro(Ambiente)
            objReg.operacion = valor1

            If Not objReg.importarArchivoDAT(archivo) Then
                idError = objReg.idError
                descripError = objReg.descripError
                Return False
            Else
                Return True
            End If
        ElseIf tabla = "Incidencia" Then
            Dim objInci As Incidencia
            objInci = New Incidencia(Ambiente)
            objInci.idEmpresa = Ambiente.empr.idEmpresa

            If Not objInci.ImportarExcel(archivo, hoja, rango, objColumnas) Then
                idError = objInci.idError
                descripError = objInci.descripError
                Return False
            Else
                Return True
            End If
        ElseIf tabla = "MovimientoFonacot" Then

            Dim objInci As MovimientoFonacot
            objInci = New MovimientoFonacot(Ambiente)
            objInci.idEmpresa = Ambiente.empr.idEmpresa
            If Not objInci.ImportarExcel(archivo, hoja, rango, objColumnas) Then
                idError = objInci.idError
                descripError = objInci.descripError
                Return False
            Else
                Return True
            End If
        End If

        Return True
    End Function
End Class
