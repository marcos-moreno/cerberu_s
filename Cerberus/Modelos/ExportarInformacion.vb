Imports System.Data.SqlClient
Imports Cerberus


Public Class ExportarInformacion
    Implements InterfaceTablas

    Public IdExportarInformacion As Integer
    Public nombreExportacion As String
    Public pk_as As String
    Public sql As String
    Public ptp As String
    Public tabla As String
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String
    Private conex As ConexionSQL

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        IdExportarInformacion = rdr("IdExportarInformacion")
        nombreExportacion = rdr("nombreExportacion")
        sql = rdr("sql")
        tabla = rdr("tabla")
        pk_as = rdr("pk_as")
        ptp = rdr("ptp")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID

        conex.accion = "SELECT"
        conex.agregaCampo("*")
        conex.tabla = "ExportarInformacion"
        conex.condicion = "WHERE nombreExportacion=" & nombreExportacion
        conex.condicion += "  AND IdExportarInformacion=" & IdExportarInformacion
        conex.armarQry()
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function


    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
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

    Public Sub getCombo(combo As ComboBox, idCombos As List(Of ExportarInformacion), filtro As String)
        Dim plantilla As ExportarInformacion
        combo.Items.Clear()
        idCombos.Clear()
        conex.Qry = "SELECT * FROM ExportarInformacion WHERE tabla='" & tabla & "' AND esActivo =1 "
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New ExportarInformacion(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.nombreExportacion)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Horario.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub getComboField(combo As ComboBox, filtro As String)
        combo.Items.Clear()
        'varchar date' 
        conex.Qry = "SELECT * FROM Information_Schema.Columns 
                        WHERE TABLE_NAME = '" & tabla & "' 
                        AND CAST(DATA_TYPE As varchar) LIKE  '%" & filtro & "%' 
                        /*OR (
                            COLUMN_NAME = CASE WHEN '" & filtro & "' = 'varchar' THEN 'idDepartamento' ELSE '' END
						        AND TABLE_NAME = 'Empleado' 
							)*/
                        ORDER BY COLUMN_NAME  "
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                combo.Items.Add(conex.reader("COLUMN_NAME"))
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Horario.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        conex.numCon = 0
        conex.tabla = "ExportarInformacion"
        conex.accion = accion
        conex.agregaCampo("nombreExportacion", nombreExportacion, False, False)
        conex.agregaCampo("sql", sql, False, False)
        conex.agregaCampo("tabla", tabla, False, False)
        conex.condicion = " WHERE IdExportarInformacion = " & IdExportarInformacion
        conex.armarQry()
        If conex.ejecutaQry Then
            If accion = "INSERT" Then
                Return obtenerID()
            Else
                Return True
            End If
        Else
            idError = conex.idError
            descripError = "Cuenta.armaQry" & vbCrLf & conex.descripError
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                IdExportarInformacion = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo Obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        Throw New NotImplementedException()
    End Function

    Public Function generateExcel(sql As String) As Boolean
        Dim listColums As List(Of String) = New List(Of String)
        conex.Qry = Replace(sql, "@idEmpresa", Ambiente.empr.idEmpresa)
        conex.numCon = 0
        Dim columnasListas = False
        Try
            'Create file excel
            Dim appXL As Microsoft.Office.Interop.Excel.Application
            Dim wbXl As Microsoft.Office.Interop.Excel.Workbook
            Dim shXL As Microsoft.Office.Interop.Excel.Worksheet
            Dim indice As Integer = 2
            appXL = CreateObject("Excel.Application")
            appXL.Visible = False 'No visible while fill
            wbXl = appXL.Workbooks.Add
            shXL = wbXl.ActiveSheet
            'InputBox("", "", conex.Qry)

            If conex.ejecutaConsulta() Then
                Dim formatRange As Microsoft.Office.Interop.Excel.Range
                formatRange = shXL.Range("a1")
                formatRange.EntireRow.Font.Bold = True
                While conex.reader.Read
                    If columnasListas = False Then
                        For index As Integer = 0 To conex.reader.FieldCount - 1
                            shXL.Cells(1, index + 1).Value = conex.reader.GetName(index).ToString
                            listColums.Add(conex.reader.GetName(index).ToString)
                        Next index
                        columnasListas = True
                    End If
                    formatRange = shXL.Range("a" & indice, listColums.Count & ":" & indice)
                    formatRange.NumberFormat = "@"
                    For index_ As Integer = 0 To listColums.Count - 1
                        shXL.Cells(indice, index_ + 1).Value = conex.reader(listColums.Item(index_)).ToString
                    Next index_
                    indice += 1
                End While
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.origen = "generateExcel.ejecutaConsulta:"
                Mensaje.Mensaje = conex.descripError
                Mensaje.ShowDialog()
            End If
            'dialog para que el usuario indique donde quiere guardar el excel
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Title = "Guardar documento Excel"
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.FileName = "Cerberus_export_" & Ambiente.empr.nombreEmpresa & ".xlsx"
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                wbXl.SaveAs(saveFileDialog1.FileName) ' Guardamos el excel en la ruta que ha especificado el usuario
                appXL.Workbooks.Close() ' Cerramos el workbook
                appXL.Quit() ' Eliminamos el objeto excel
                Return True
            Else
                appXL.Workbooks.Close() ' Cerramos el workbook
                appXL.Quit() ' Eliminamos el objeto excel
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error al exportar los datos a excel. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conex.reader.Close()
        End Try
        Return False
    End Function
End Class
