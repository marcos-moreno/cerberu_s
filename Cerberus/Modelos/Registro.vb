Imports System.Data.SqlClient
Imports Cerberus

Public Class Registro
    Implements InterfaceTablas

    Public idError As Integer
    Public descripError As String

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idRegistro As Integer
    Public idEmpleado As Integer
    Public idDispositivo As Integer
    Public fechaRegistro As DateTime
    Public idEvento As Integer
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public tipoRegistro As String
    Public dispositivo As String
    Public comentario As String
    Public tipoVerificacion As Integer
    Public modoEntradaSalida As Integer
    Public idTrabajo As Integer
    Public operacion As String 'ES = Entrada / Salida >> CO = Comida

    Public anio As Integer
    Public mes As Integer
    Public dia As Integer
    Public minuto As Integer
    Public segundo As Integer
    Public hora As Integer

    Private per As Periodo

    Public Sub armaFecha()
        Try
            fechaRegistro = anio & "-" & mes & "-" & dia & " " & hora & ":" & minuto & ":" & segundo
        Catch ex As Exception

        End Try
    End Sub

    Public Sub desarmaFecha()
        anio = fechaRegistro.Year
        mes = fechaRegistro.Month
        dia = fechaRegistro.Day
        hora = fechaRegistro.Hour
        minuto = fechaRegistro.Minute
        segundo = fechaRegistro.Second
    End Sub

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub cargarGridRegistrosInvalidos(grid As DataGridView, fechaIncial As Date, fechaFinal As Date, operacion As String, dep As Integer, filtro As String)
        Dim condicion As String
        condicion = ""

        If Not filtro = Nothing Then
            filtro = filtro.Replace("*", "%")
            condicion &= " AND (convert(date,fechaRegistro) like '%" & filtro & "%' "
            condicion &= " OR Concat(E.NombreEmpleado,' ',E.ApPatEmpleado,' ',E.ApMatEmpleado) like '%" & filtro & "%') "
        End If
        If Not dep = Nothing Then
            condicion &= " AND E.idDepartamento = " & dep
        End If

        condicion &= " AND E.esActivo = 1"

        cargarGridGen(grid, fechaIncial, fechaFinal, operacion, condicion)
    End Sub

    Public Sub cargarGridRegistrosInvalidos(grid As DataGridView, fechaIncial As Date, fechaFinal As Date, operacion As String, idEmpl As Integer)
        Dim condicion As String
        condicion = ""

        If Not idEmpl = Nothing Then
            condicion &= " AND E.idEmpleado = " & idEmpl
        End If

        condicion &= " AND E.esActivo = 1"

        cargarGridGen(grid, fechaIncial, fechaFinal, operacion, condicion)
    End Sub

    Public Sub cargarGridRegistrosInvalidosXDepEmpl(grid As DataGridView, fechaIncial As Date, fechaFinal As Date, operacion As String, idDepartamento As Integer, idEmpleado As Integer)
        Dim condicion As String
        condicion = ""

        If Not idEmpleado = Nothing Then
            condicion &= " AND E.idEmpleado = " & idEmpleado
        Else
            If Not idDepartamento = Nothing Then
                condicion &= " AND E.idDepartamento = " & idDepartamento
            End If
        End If

        condicion &= " AND E.esActivo = 1"

        cargarGridGen(grid, fechaIncial, fechaFinal, operacion, condicion)
    End Sub

    Public Sub cargarGridRegistrosInvalidos(grid As DataGridView, fechaIncial As Date, fechaFinal As Date, operacion As String)
        Dim condicion As String
        condicion = ""
        condicion &= " AND E.esActivo = 1"

        cargarGridGen(grid, fechaIncial, fechaFinal, operacion, condicion)
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, fechaIncial As Date, fechaFinal As Date, operacion As String, filtro As String)
        Dim dtb As New DataTable("Registro")
        Dim row As DataRow

        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Num Registros", Type.GetType("System.Int32"))

        conex.Qry = "SELECT "
        conex.Qry &= "convert(date,fechaRegistro) as Fecha,"
        conex.Qry &= "concat('(',R.idEmpleado,') ', E.nombreEmpleado,' ', E.apPatEmpleado,' ', E.apMatEmpleado) as nEmpleado,"
        conex.Qry &= "count(*) as NumReg "
        conex.Qry &= "from "
        conex.Qry &= "Registro As R,"
        conex.Qry &= "Empleado as E "
        conex.Qry &= "where "
        conex.Qry &= "operacion = 'ES' "
        conex.Qry &= "And Convert(Date, fechaRegistro) between convert(Date,'" & Format(fechaIncial, "dd/MM/yyyy") & "') AND convert(date,'" & Format(fechaFinal, "dd/MM/yyyy") & "') "
        conex.Qry &= "ANd R.esActivo = 1 "
        conex.Qry &= "ANd E.idEmpresa = " & idEmpresa & " "
        conex.Qry &= "And R.idEmpleado = E.idEmpleado "
        conex.Qry &= filtro
        conex.Qry &= "GROUP BY "
        conex.Qry &= "convert(date,fechaRegistro),"
        conex.Qry &= "concat('(',R.idEmpleado,') ', E.nombreEmpleado,' ', E.apPatEmpleado,' ', E.apMatEmpleado) "
        conex.Qry &= "HAVING "
        conex.Qry &= "count(*) % 2 > 0 "
        conex.Qry &= "ORDER BY "
        conex.Qry &= "2,1"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                row = dtb.NewRow
                row("Fecha") = Format(conex.reader("Fecha"), "dd/MM/yyyy")
                row("Empleado") = conex.reader("nEmpleado")
                row("Num Registros") = conex.reader("NumReg")

                dtb.Rows.Add(row)
            End While

            grid.DataSource = dtb
            conex.reader.Close()

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Registro.cargarGridRegistrosInvalidos"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridXFechaEmpl(grid As DataGridView, idEmpleado As Integer, fecha As DateTime, objCls As List(Of Registro), operacion As String, soloActivos As Boolean)
        Dim condicion As String
        Dim plantilla As Registro
        Dim dtb As New DataTable("Registro")
        Dim row As DataRow

        dtb.Columns.Add("Activo", Type.GetType("System.Boolean"))
        dtb.Columns.Add("Hora", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo Registro", Type.GetType("System.String"))
        dtb.Columns.Add("Dispositivo", Type.GetType("System.String"))
        dtb.Columns.Add("Descrip", Type.GetType("System.String"))
        dtb.Columns.Add("Usuario", Type.GetType("System.String"))

        objCls.Clear()

        condicion = " AND R.idEmpleado = " & idEmpleado & " AND convert(date,R.fechaRegistro) = convert(date,'" & Format(fecha, "yyyy-MM-dd") & "')"

        If soloActivos Then
            condicion &= " AND R.esActivo = 1 "
        End If

        conex.Qry = "SELECT R.*,E.usuario FROM Registro as R,Empleado as E WHERE E.idEmpleado = R.ActualizadoPor  AND R.operacion = '" & operacion & "' AND R.idEmpresa = " & idEmpresa & " " & condicion & " ORDER BY R.fechaRegistro"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Registro(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objCls.Add(plantilla)

                row = dtb.NewRow
                row("Activo") = plantilla.esActivo
                row("Hora") = Format(plantilla.fechaRegistro, "HH:mm:ss")
                row("Tipo Registro") = plantilla.tipoRegistro
                row("Dispositivo") = plantilla.dispositivo
                row("Usuario") = conex.reader("usuario")
                row("Descrip") = plantilla.comentario

                dtb.Rows.Add(row)
            End While

            grid.DataSource = dtb
            conex.reader.Close()

            'Bloquear REORDENAR
            grid.ReadOnly = False
            For i As Integer = 0 To grid.Columns.Count - 1
                If i <> 0 Then
                    grid.Columns(i).ReadOnly = True
                End If
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Registro.cargaGridXFechaEmpl"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If

    End Sub

    Public Sub cargaGridXRangoFecha(grid As DataGridView, fechaInicial As DateTime, fechaFinal As DateTime, objCls As List(Of Registro), soloManuales As Boolean, operacion As String, idFiltro As Integer)
        Dim condicion As String
        Dim plantilla As Registro
        Dim dtb As New DataTable("Registro")
        Dim row As DataRow
        Dim indice As Integer

        dtb.Columns.Add("No.", Type.GetType("System.Int32"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Hora", Type.GetType("System.String"))
        dtb.Columns.Add("Dispositivo", Type.GetType("System.String"))
        dtb.Columns.Add("Activo", Type.GetType("System.Boolean"))
        dtb.Columns.Add("Comentario", Type.GetType("System.String"))
        dtb.Columns.Add("Creado Por", Type.GetType("System.String"))
        dtb.Columns.Add("Creado", Type.GetType("System.String"))
        dtb.Columns.Add("Tipo", Type.GetType("System.String"))


        objCls.Clear()

        condicion = " AND convert(date,R.fechaRegistro) between convert(date,'" & Format(fechaInicial, "yyyy-MM-dd") & "') AND convert(date,'" & Format(fechaFinal, "yyyy-MM-dd") & "')"

        If soloManuales Then
            condicion &= " And tipoRegistro ='MANUAL'"
        End If
        conex.Qry = "SELECT R.*,C.usuario,concat(rtrim(E.nombreEmpleado),' ', rtrim(E.apPatEmpleado),' ', rtrim(E.apMatEmpleado)) as nEmpleado FROM Registro as R,Empleado as E,Empleado as C  WHERE E.idEmpleado = R.idEmpleado AND R.idEmpleado =" & idFiltro & " AND C.idEmpleado = R.CreadoPor AND R.operacion = '" & operacion & "' AND R.idEmpresa = " & idEmpresa & " " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Registro(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objCls.Add(plantilla)

                row = dtb.NewRow
                row("No.") = indice
                row("Empleado") = conex.reader("nEmpleado")
                row("Fecha Hora") = Format(plantilla.fechaRegistro, "dd/MM/yyyy HH:mm:ss")
                row("Dispositivo") = plantilla.dispositivo
                row("Comentario") = plantilla.comentario
                row("Activo") = plantilla.esActivo
                row("Creado Por") = conex.reader("usuario")
                row("Creado") = Format(plantilla.creado, "dd/MM/yyy HH:mm")
                row("Tipo") = plantilla.tipoRegistro

                dtb.Rows.Add(row)
                indice += 1
            End While

            grid.DataSource = dtb
            grid.Columns(0).Visible = False
            conex.reader.Close()

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Registro.cargaGridXRangoFecha"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If

    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idRegistro = rdr("idRegistro")
        idEmpleado = rdr("idEmpleado")
        idDispositivo = If(IsDBNull(rdr("idDispositivo")), Nothing, rdr("idDispositivo"))
        fechaRegistro = rdr("fechaRegistro")
        idEvento = If(IsDBNull(rdr("idEvento")), Nothing, rdr("idEvento"))
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        tipoRegistro = rdr("tipoRegistro")
        dispositivo = rdr("dispositivo")
        comentario = If(IsDBNull(rdr("comentario")), Nothing, rdr("comentario"))
        tipoVerificacion = If(IsDBNull(rdr("tipoVerificacion")), Nothing, rdr("tipoVerificacion"))
        modoEntradaSalida = If(IsDBNull(rdr("modoEntradaSalida")), Nothing, rdr("modoEntradaSalida"))
        idTrabajo = If(IsDBNull(rdr("idTrabajo")), Nothing, rdr("idTrabajo"))
        operacion = rdr("operacion")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return ejecutaQry("INSERT", True)
    End Function

    Private Function ejecutaQry(accion As String, esInsert As Boolean) As Boolean
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Registro"
            conex.accion = accion

            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idDispositivo", idDispositivo, True, False)
            conex.agregaCampo("fechaRegistro", fechaRegistro, False, False)
            conex.agregaCampo("idEvento", idEvento, True, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("tipoRegistro", tipoRegistro, False, False)
            conex.agregaCampo("dispositivo", dispositivo, False, False)
            conex.agregaCampo("comentario", comentario, True, False)
            conex.agregaCampo("tipoVerificacion", tipoVerificacion, True, False)
            conex.agregaCampo("modoEntradaSalida", modoEntradaSalida, True, False)
            conex.agregaCampo("idTrabajo", idTrabajo, True, False)
            conex.agregaCampo("operacion", operacion, False, False)

            If esInsert Then
                conex.insertConSelect = True
                conex.condicion = "WHERE NOT EXISTS (SELECT 
	                                                    idPeriodo 
                                                    FROM 
	                                                    Periodo 
                                                    WHERE 
	                                                    elementoSistema = '" & operacion & "' 
	                                                    AND esActivo = 0 
	                                                    AND idEmpresa = " & idEmpresa & " 
	                                                    AND convert(date,'" & Format(fechaRegistro, "yyyy-MM-dd") & "') BETWEEN inicioPeriodo AND finPeriodo)"
            Else
                conex.condicion = "WHERE idRegistro =" & idRegistro
            End If

            conex.armarQry()

            If conex.ejecutaQryConVerif Then
                Return True
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        End If

        Return False
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return ejecutaQry("UPDATE", False)
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

        If tipoRegistro = Nothing Then
            tipoRegistro = "MANUAL"
        End If

        If dispositivo = Nothing Then
            dispositivo = "S/A"
        End If

        If comentario = Nothing Then
            comentario = ""
        End If

        If idEmpresa = Nothing Then
            idEmpresa = Ambiente.empr.idEmpresa
        End If

        If idSucursal = Nothing Then
            idSucursal = Ambiente.suc.idSucursal
        End If

        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If

        If nuevo Then
            If actualizadoPor = Nothing Then
                actualizadoPor = Ambiente.usuario.idEmpleado
            End If
        Else
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If

        If idEmpleado = Nothing Then
            idError = 1
            descripError = "Es necesario indicar el empleado para poder continuar..."
            Return False

        ElseIf comentario.Trim.Length < 5 And tipoRegistro = "MANUAL" Then
            idError = 2
            descripError = "Es necesario indicar almenos 5 caracteres, en el campo: ""Comentario"""
            Return False
        End If

        Return True
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

    Public Function importarArchivoDAT(archivo As String) As Boolean
        Dim MyReader As New Microsoft.VisualBasic.
              FileIO.TextFieldParser(
                archivo)
        Dim currentRow As String()

        idError = 0
        descripError = ""

        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(vbTab)

        While Not MyReader.EndOfData 'FILAS
            Dim objReg As Registro
            objReg = New Registro(Ambiente)
            currentRow = MyReader.ReadFields() 'LEE COLUMNAS

            objReg.esActivo = True
            objReg.idEmpleado = Trim(currentRow(0))
            objReg.fechaRegistro = currentRow(1)
            objReg.tipoVerificacion = currentRow(4)
            objReg.tipoRegistro = "IMPORTADO"
            objReg.dispositivo = "IMPORTADO"
            objReg.comentario = archivo
            objReg.operacion = operacion

            If Not objReg.guardar() Then
                idError = objReg.idError
                descripError &= "Empleado / Fecha: " & objReg.idEmpleado & "/" & Format(objReg.fechaRegistro, "dd/MM/yyyy HH:mm:ss") & " - " & objReg.descripError & vbCrLf
            End If
        End While

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ImportarExcel(archivo As String, hoja As String, rango As String, objColumnas As List(Of DetalleFormatoImportacion)) As Boolean
        Dim objExcel As New Excel(archivo, hoja, rango)
        Dim objData As DataSet
        objData = objExcel.leer()

        idError = 0
        descripError = ""

        For Each fila In objData.Tables(0).Rows 'Filas
            Dim numColumna As Integer
            Dim dato As Object

            Dim objTabla As Registro
            objTabla = New Registro(Ambiente)
            objTabla.esActivo = True

            For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                dato = fila.Item(numColumna)

                If objColumnas.Item(i).tabla = "Registro" Then
                    Select Case objColumnas.Item(i).columnaSQL
                        Case "idEmpleado"
                            objTabla.idEmpleado = dato
                        Case "idDispositivo"
                            objTabla.idDispositivo = dato
                        Case "fechaRegistro"
                            objTabla.fechaRegistro = dato
                        Case "esActivo"
                            objTabla.esActivo = dato
                        Case "idEmpresa"
                            objTabla.idEmpresa = dato
                        Case "idSucursal"
                            objTabla.idSucursal = dato
                        Case "tipoRegistro"
                            objTabla.tipoRegistro = dato
                        Case "dispositivo"
                            objTabla.dispositivo = dato
                        Case "comentario"
                            objTabla.comentario = dato
                        Case "tipoVerificacion"
                            objTabla.tipoVerificacion = dato
                        Case "modoEntradaSalida"
                            objTabla.modoEntradaSalida = dato
                        Case "idTrabajo"
                            objTabla.idTrabajo = dato
                        Case "operacion"
                            objTabla.operacion = dato
                    End Select
                End If
            Next

            'VALIDACION DE CAMPOS
            If objTabla.operacion = Nothing Then
                objTabla.operacion = operacion
            End If
            '-----

            If Not objTabla.guardar() Then
                idError = objTabla.idError
                descripError &= "Registro: " & objTabla.descripError & vbCrLf
            End If
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
