Imports System.Data.OleDb


Public Class Excel
    Private campos As New List(Of String)
    Private objDataSet As DataSet

    Public ruta As String
    Public hoja As String
    Public rango As String
    Public nombreArchivo As String

    Public idError As String
    Public descripError As String

    Public Sub New(ruta As String, hoja As String, rango As String)
        Me.ruta = ruta
        Me.hoja = hoja
        Me.rango = rango
    End Sub

    Public Function leer() As DataSet
        If loadRange(ruta, hoja, rango) Then
            Return objDataSet
        Else
            Return New DataSet()
        End If
    End Function

    Public Function guardar() As Boolean
        Return True

    End Function

    Public Function cargarExcel(archivo As String, nombreHoja As String) As Object(,)
        Try
            Dim con As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & archivo & ";Extended Properties=Excel 12.0"
            Using connection As New OleDbConnection(con)
                connection.Open()
                Dim adaptador As New OleDbDataAdapter("select * from [" & nombreHoja & "$]", connection)
                Dim dtb As New DataTable
                adaptador.Fill(dtb)

                Dim matriz(dtb.Rows.Count - 1, dtb.Columns.Count - 1) As Object
                For filasInt As Integer = 0 To dtb.Rows.Count - 1
                    For columnasInt As Integer = 0 To dtb.Columns.Count - 1
                        matriz(filasInt, columnasInt) = dtb.Rows(filasInt).Item(columnasInt)
                    Next columnasInt
                Next filasInt
                connection.Close()
                Return matriz
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Excel.CargarExcel()")
            Return Nothing
        End Try
    End Function

    Public Sub agregarCampos(campo As String)
        campos.Add(campo)
    End Sub

    Private Function loadRange(
         ByVal sFileName As String,
         ByVal sSheetName As String,
         ByVal sRange As String) As Boolean
        Try
            ' // Comprobar que el archivo Excel existe
            If System.IO.File.Exists(sFileName) Then
                Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
                ' // Declarar la Cadena de conexión
                Dim sCs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sFileName & ";Extended Properties=Excel 12.0"

                Dim objOleConnection As System.Data.OleDb.OleDbConnection
                objOleConnection = New System.Data.OleDb.OleDbConnection(sCs)

                ' // Declarar la consulta SQL que indica el libro y el rango de la hoja
                Dim sSql As String = "select * from " & "[" & sSheetName & "$" & sRange & "]"
                ' // Obtener los datos
                objDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSql, objOleConnection)

                ' // Crear DataSet y llenarlo
                objDataSet = New System.Data.DataSet

                objDataAdapter.Fill(objDataSet)
                ' // Cerrar la conexión
                objOleConnection.Close()
            Else
                idError = 1
                descripError = "No se ha encontrado el archivo: " & sFileName
                Return False
            End If

        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            MsgBox(ex.Message, vbExclamation, "Excel.loadRange")
            Return False
        End Try

        Return True
    End Function
End Class
