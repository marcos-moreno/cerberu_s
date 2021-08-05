Imports System.IO
Imports System.Threading
Public Class frmImportador

    Private _context As AmbienteCls
    Private _empleado As Empleado
    Private _table As String
    Private arch As Archivo
    Private objFormatoImportacion As FormatoImportacion
    Private objDetalleFormatoImportacion As DetalleFormatoImportacion
    Private listFormatoImportacion As New List(Of FormatoImportacion)
    Private listDetalleFormatoImportacion As List(Of DetalleFormatoImportacion) = New List(Of DetalleFormatoImportacion)
    Private lisCuentas As List(Of Cuenta) = New List(Of Cuenta)
    Private EXL As Microsoft.Office.Interop.Excel.Application
    Private W As Microsoft.Office.Interop.Excel.Workbook
    Private S As Microsoft.Office.Interop.Excel.Worksheet
    Private threadImportar As Thread 'hilo 1 
    Public Property Context As AmbienteCls
        Get
            Return _context
        End Get
        Set(value As AmbienteCls)
            _context = value
        End Set
    End Property

    Public Property Table As String
        Get
            Return _table
        End Get
        Set(value As String)
            _table = value
        End Set
    End Property

    Private Sub frmExportarInformacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        objFormatoImportacion = New FormatoImportacion(_context)
        objFormatoImportacion.tabla = _table
        objFormatoImportacion.idEmpresa = _context.empr.idEmpresa
        objFormatoImportacion.getComboCuentas(cbFormato, listFormatoImportacion)
    End Sub

    Private Sub MaterialRaisedButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        'Ejemplo
        Try
            If cbFormato.SelectedIndex > -1 Then
                frmArchivo.Ambiente = _context
                frmArchivo.tabla = "FormatoImportacion"
                frmArchivo.idTabla = listFormatoImportacion.Item(cbFormato.SelectedIndex).idFormatoImportacion
                frmArchivo.elementoSistema = "FormatoImportacion"
                frmArchivo.tipoArchivo = "Exel"
                frmArchivo.ShowDialog()
            Else
                MsgBox("Selecciona El Formato.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        OpenFileDialog1.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls;*‌​.xml;"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Dim path As String = OpenFileDialog1.FileName
            Try
                Dim text As String = File.ReadAllText(path)
                Me.Text = Me.Text + " | Excel Cargado"
                txtPath.Text = path
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.Text = "Error"
            End Try
        End If
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        If cbFormato.SelectedIndex > -1 Then
            If txtPath.Text <> Nothing Then
                Select Case listFormatoImportacion.Item(cbFormato.SelectedIndex).idFormatoImportacion
                    Case 1
                        createCuentas()
                    Case 6
                        createCuentasXperiodos()
                End Select
            Else
                MessageBox.Show("Elige un Archivo Excel")
            End If
        Else
            MsgBox("Selecciona El Formato.")
        End If
    End Sub


    Private Function createCuentas() As Boolean
        Try
            imgLoad.Visible = True
            threadImportar = New Thread(AddressOf executeCuentas)
            threadImportar.Start()
        Catch ex As ThreadAbortException
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Private Function executeCuentas()
        If getDetalle() Then
            getExcel()
        End If
        imgLoad.Visible = False
        Return True
    End Function


    'X periodos
    Private Function createCuentasXperiodos() As Boolean
        Try
            imgLoad.Visible = True
            threadImportar = New Thread(AddressOf executeCuentasXperiodos)
            threadImportar.Start()
        Catch ex As ThreadAbortException
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Private Function executeCuentasXperiodos()
        If getDetalle() Then
            getExcelXperiodos()
        End If
        imgLoad.Visible = False
        Return True
    End Function

    '////X Periodos



    Private Function getExcel() As Boolean
        If File.Exists(txtPath.Text) Then
            Try
                EXL = New Microsoft.Office.Interop.Excel.Application
                W = EXL.Workbooks.Open(txtPath.Text)
                S = W.Sheets("Hoja1")
                Dim i = 1
                Dim listaEncabezados = New List(Of String)
                Do While 1 = 1
                    Dim valueHead As String
                    valueHead = S.Cells(1, i).Value
                    If valueHead IsNot Nothing Then
                        listaEncabezados.Add(valueHead)
                    Else
                        Exit Do
                    End If
                    i += 1
                Loop
                Dim todoValido As Boolean = True
                i = 2
                Do While 1 = 1
                    Try
                        Dim indexIdEmpleado = searchValueList(listaEncabezados, "idEmpleado")
                        Dim valueIdEmpleado = (S.Cells(i, indexIdEmpleado).Value)
                        If valueIdEmpleado IsNot Nothing Then
                            Dim Cuenta As New Cuenta(_context)
                            Dim empleado As New Empleado(_context)
                            empleado.idEmpleado = Convert.ToInt32(valueIdEmpleado)
                            If empleado.buscarPID() Then
                                Cuenta.idEmpresa = empleado.idEmpresa
                                Cuenta.idSucursal = empleado.idSucursal
                                Cuenta.idEmpleado = empleado.idEmpleado
                                Cuenta.sistemaOrigen = "Importador de Cuentas MG"
                                Cuenta.esCuentaManual = Nothing
                                Cuenta.esAutorizada = Nothing
                                Dim id_concepto = 0
                                For Each detailFormat As DetalleFormatoImportacion In listDetalleFormatoImportacion
                                    Select Case detailFormat.columnaSQL
                                        Case "tipoCuenta"
                                            Cuenta.tipoCuenta = S.Cells(i, searchValueList(listaEncabezados, "tipoCuenta")).Value
                                        Case "monto"
                                            Cuenta.monto = S.Cells(i, searchValueList(listaEncabezados, "monto")).Value
                                        Case "fechaCuenta"
                                            Cuenta.fechaCuenta = S.Cells(i, searchValueList(listaEncabezados, "fecha cuenta")).Value
                                        Case "estado"
                                            Cuenta.estado = S.Cells(i, searchValueList(listaEncabezados, "estado")).Value
                                        Case "descripccion"
                                            Cuenta.descripccion = S.Cells(i, searchValueList(listaEncabezados, "Descripcion")).Value
                                        Case "idConceptoCuenta"
                                            id_concepto = S.Cells(i, searchValueList(listaEncabezados, "id Concepto")).Value
                                    End Select
                                Next
                                Dim periodo = New Periodo(_context)
                                periodo.idEmpresa = Cuenta.idEmpresa
                                periodo.idSucursal = Cuenta.idSucursal
                                periodo.elementoSistema = "EFE"
                                If periodo.buscarPFecha(Cuenta.fechaCuenta) Then
                                    Cuenta.idPeriodo = periodo.idPeriodo
                                    If Cuenta.guardar() Then
                                        Dim detallCuenta = New CuentaDetalle(_context)
                                        detallCuenta.idCuenta = Cuenta.idCuenta
                                        detallCuenta.idConceptoCuenta = id_concepto
                                        detallCuenta.monto = Cuenta.monto
                                        detallCuenta.descripccion = Cuenta.descripccion
                                        If detallCuenta.guardar() Then
                                            S.Cells(i, listaEncabezados.Count + 1).Value = "Listo"
                                        Else
                                            S.Cells(i, listaEncabezados.Count + 1).Value = "Error Cuenta: " & detallCuenta.descripError
                                            todoValido = False
                                        End If
                                    Else
                                        todoValido = False
                                        S.Cells(i, listaEncabezados.Count + 1).Value = "Error Cuenta: " & Cuenta.descripError
                                    End If
                                Else
                                    todoValido = False
                                    S.Cells(i, listaEncabezados.Count + 1).Value = "Error périodo No Encontrado"
                                End If
                            Else
                                S.Cells(i, listaEncabezados.Count + 1).Value = "Error empleado: Empleado No encontrado."
                                todoValido = False
                            End If
                        Else
                            Exit Do
                        End If
                        i += 1
                    Catch ex As Exception
                        MsgBox("Excepcion:" & ex.Message)
                    End Try
                Loop
                If todoValido Then
                    Dim Style = vbOK + vbInformation    ' Define buttons.
                    MsgBox("Se importó correctamente la información.", Style, "Exito")
                Else
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = "Algunas cuentas No se Importarón, En el Excel se mencionan los ERRORES."
                    Mensaje.ShowDialog()
                End If
                S = Nothing
                W.Save()
                W.Close()
                W = Nothing
                EXL = Nothing
                Return True
            Catch ex As Exception
                MsgBox(ex.ToString)
                Try
                    W.Close()
                Catch dc As Exception
                End Try
            Finally
            End Try
        Else
            MessageBox.Show("El Archivo Excel no Exite")
            Return False
        End If
        Return False
    End Function


    Private Function getExcelXperiodos() As Boolean
        If File.Exists(txtPath.Text) Then
            Try
                EXL = New Microsoft.Office.Interop.Excel.Application
                W = EXL.Workbooks.Open(txtPath.Text)
                S = W.Sheets("Hoja1")
                Dim i = 1
                Dim listaEncabezados = New List(Of String)
                Do While 1 = 1
                    Dim valueHead As String
                    valueHead = S.Cells(1, i).Value
                    If valueHead IsNot Nothing Then
                        listaEncabezados.Add(valueHead)
                    Else
                        Exit Do
                    End If
                    i += 1
                Loop
                Dim todoValido As Boolean = True
                i = 2
                Do While 1 = 1
                    Try
                        Dim indexIdEmpleado = searchValueList(listaEncabezados, "idEmpleado")
                        Dim valueIdEmpleado = (S.Cells(i, indexIdEmpleado).Value)
                        If valueIdEmpleado IsNot Nothing Then
                            Dim Cuenta As New CuentaXPeriodo(_context)
                            Dim empleado As New Empleado(_context)
                            empleado.idEmpleado = Convert.ToInt32(valueIdEmpleado)
                            If empleado.buscarPID() Then
                                Cuenta.idEmpresa = empleado.idEmpresa
                                Cuenta.idSucursal = empleado.idSucursal
                                Cuenta.idEmpleado = empleado.idEmpleado
                                Cuenta.esActivo = 1
                                Dim id_concepto = 0
                                Try
                                    For Each detailFormat As DetalleFormatoImportacion In listDetalleFormatoImportacion
                                        Select Case detailFormat.columnaSQL
                                            Case "tipoCuenta"
                                                Cuenta.tipoCuenta = S.Cells(i, searchValueList(listaEncabezados, "tipoCuenta")).Value
                                            Case "monto"
                                                Cuenta.monto = S.Cells(i, searchValueList(listaEncabezados, "monto")).Value
                                            Case "fechaCuenta"
                                                Cuenta.fechaCuenta = S.Cells(i, searchValueList(listaEncabezados, "fecha cuenta")).Value
                                            Case "estado"
                                                Cuenta.estado = S.Cells(i, searchValueList(listaEncabezados, "estado")).Value
                                            Case "descripccion"
                                                Cuenta.descripccionCuenta = S.Cells(i, searchValueList(listaEncabezados, "Descripcion")).Value
                                            Case "idConceptoCuenta"
                                                Cuenta.idConceptoCuenta = S.Cells(i, searchValueList(listaEncabezados, "id Concepto")).Value
                                            Case "numeroPeriodos"
                                                Cuenta.numeroPeriodos = S.Cells(i, searchValueList(listaEncabezados, "No periodos")).Value
                                            Case "montoXPeriodo"
                                                Cuenta.montoXPeriodo = S.Cells(i, searchValueList(listaEncabezados, "montoXPeriodo")).Value
                                        End Select
                                    Next
                                Catch ex As Exception
                                    todoValido = False
                                    S.Cells(i, listaEncabezados.Count + 1).Value = "Una Columna del encabezado esta corrupta."
                                    Exit Do
                                End Try
                                Dim periodo = New Periodo(_context)
                                periodo.idEmpresa = Cuenta.idEmpresa
                                periodo.idSucursal = Cuenta.idSucursal
                                periodo.elementoSistema = "EFE"
                                If periodo.buscarPFecha(Cuenta.fechaCuenta) Then
                                    If Cuenta.guardar() Then
                                        S.Cells(i, listaEncabezados.Count + 1).Value = "Listo"
                                    Else
                                        todoValido = False
                                        S.Cells(i, listaEncabezados.Count + 1).Value = "Error Cuenta: " & Cuenta.descripError
                                    End If
                                Else
                                    todoValido = False
                                    S.Cells(i, listaEncabezados.Count + 1).Value = "Error périodo No Encontrado"
                                End If
                            Else
                                S.Cells(i, listaEncabezados.Count + 1).Value = "Error empleado: Empleado No encontrado."
                                todoValido = False
                            End If
                        Else
                            Exit Do
                        End If
                        i += 1
                    Catch ex As Exception
                        MsgBox("Excepcion:" & ex.Message)
                    End Try
                Loop
                If todoValido Then
                    Dim Style = vbOK + vbInformation    ' Define buttons.
                    MsgBox("Se importó correctamente la información.", Style, "Exito")
                Else
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = "Algunas cuentas No se Importarón, En el Excel se mencionan los ERRORES."
                    Mensaje.ShowDialog()
                End If
                S = Nothing
                W.Save()
                W.Close()
                W = Nothing
                EXL = Nothing
                Return True
            Catch ex As Exception
                MsgBox(ex.ToString)
                Try
                    W.Close()
                Catch dc As Exception
                End Try
            Finally
            End Try
        Else
            MessageBox.Show("El Archivo Excel no Exite")
            Return False
        End If
        Return False
    End Function

    Private Function searchValueList(lista As List(Of String), nombre As String) As Integer
        For i As Integer = 0 To lista.Count - 1
            If nombre = lista.Item(i) Then
                Return i + 1
            End If
        Next
        Return 0
    End Function
    Private Function getDetalle() As Boolean
        Try
            objDetalleFormatoImportacion = New DetalleFormatoImportacion(_context)
            objDetalleFormatoImportacion.idFormatoImportacion = listFormatoImportacion.Item(cbFormato.SelectedIndex).idFormatoImportacion
            If objDetalleFormatoImportacion.detallesFormato(listDetalleFormatoImportacion) Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class