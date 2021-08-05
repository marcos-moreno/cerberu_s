Imports System.Data.SqlClient
Imports Cerberus

Public Class MovimientosEMA
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idMovimientoEMA As Integer
    Public nss As String
    Public nombre As String
    Public origen As Integer
    Public tipoMovimiento As Integer
    Public fechaMovimiento As Date
    Public dias As Integer
    Public salarioDiario As Decimal
    Public cuotaFija As Decimal
    Public excedentePatronal As Decimal
    Public excedenteObrero As Decimal
    Public prestacionesDineroPatronal As Decimal
    Public prestacionesDineroObrero As Decimal
    Public gastosMedicosPensionadosPatronal As Decimal
    Public gastosMedicosPensionadosObrero As Decimal
    Public riesgoTrabajo As Decimal
    Public invalidezVidaPatronal As Decimal
    Public invalidezVidaObrero As Decimal
    Public guarderiasPrestacionesSociales As Decimal
    Public total As Decimal
    Public periodo As Integer
    Public ejercicio As Integer
    Public idRegistroPatronal As Integer
    Public idEmpresa As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        Throw New NotImplementedException()
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
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
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "MovimientosEMA"
            conex.accion = accion

            conex.agregaCampo("nss", nss, False, False)
            conex.agregaCampo("nombre", nombre, False, False)
            conex.agregaCampo("origen", origen, False, False)
            conex.agregaCampo("tipoMovimiento", tipoMovimiento, False, False)
            conex.agregaCampo("fechaMovimiento", fechaMovimiento, True, False)
            conex.agregaCampo("dias", dias, True, False)
            conex.agregaCampo("salarioDiario", salarioDiario, True, False)
            conex.agregaCampo("cuotaFija", cuotaFija, True, False)
            conex.agregaCampo("excedentePatronal", excedentePatronal, True, False)
            conex.agregaCampo("excedenteObrero", excedenteObrero, True, False)
            conex.agregaCampo("prestacionesDineroPatronal", prestacionesDineroPatronal, True, False)
            conex.agregaCampo("prestacionesDineroObrero", prestacionesDineroObrero, True, False)
            conex.agregaCampo("gastosMedicosPensionadosPatronal", gastosMedicosPensionadosPatronal, True, False)
            conex.agregaCampo("gastosMedicosPensionadosObrero", gastosMedicosPensionadosObrero, True, False)
            conex.agregaCampo("riesgoTrabajo", riesgoTrabajo, True, False)
            conex.agregaCampo("invalidezVidaPatronal", invalidezVidaPatronal, True, False)
            conex.agregaCampo("invalidezVidaObrero", invalidezVidaObrero, True, False)
            conex.agregaCampo("guarderiasPrestacionesSociales", guarderiasPrestacionesSociales, True, False)
            conex.agregaCampo("total", total, True, False)
            conex.agregaCampo("periodo", periodo, False, False)
            conex.agregaCampo("ejercicio", ejercicio, False, False)
            conex.agregaCampo("idRegistroPatronal", idRegistroPatronal, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idMovimientoEMA = " & idMovimientoEMA

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idMovimientoEMA = conex.reader("ID")
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

    Public Function ImportarExcel(archivo As String, hoja As String, rango As String) As Boolean
        'BORRAR INFORMACION ANTERIOR
        conex.accion = "DELETE"
        conex.tabla = "MovimientosEMA_PR"
        conex.condicion = "WHERE idMovimientoEMA IN (SELECT Ma.idMovimientoEMA FROM MovimientosEMA as MA where idRegistroPatronal = " & idRegistroPatronal & " and periodo = " & periodo & " and ejercicio = " & ejercicio & ")"

        conex.armarQry()
        If Not conex.ejecutaQry Then
            idError = conex.ejecutaQry
            descripError = conex.descripError
            Return False
        End If

        conex.accion = "DELETE"
        conex.tabla = "MovimientosEMA"
        conex.condicion = "WHERE idRegistroPatronal = " & idRegistroPatronal & " and periodo = " & periodo & " and ejercicio = " & ejercicio

        conex.armarQry()
        If Not conex.ejecutaQry Then
            idError = conex.ejecutaQry
            descripError = conex.descripError
            Return False
        End If
        '****

        Dim objExcel As New Excel(archivo, hoja, rango)
        Dim objData As DataSet
        objData = objExcel.leer()

        idError = 0
        descripError = ""

        'CREAR COLUMNAS>>>
        Dim objColumnas As New List(Of DetalleFormatoImportacion)

        Dim objPlantilla As DetalleFormatoImportacion

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "NSS"
        objPlantilla.columnaSQL = "nss"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Nombre"
        objPlantilla.columnaSQL = "nombre"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Origen del Movimiento"
        objPlantilla.columnaSQL = "origen"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Tipo del Movimiento"
        objPlantilla.columnaSQL = "tipoMovimiento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Fecha del Movimiento"
        objPlantilla.columnaSQL = "fechaMovimiento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Días"
        objPlantilla.columnaSQL = "dias"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Salario Diario"
        objPlantilla.columnaSQL = "salarioDiario"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Cuota Fija"
        objPlantilla.columnaSQL = "cuotaFija"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Excedente Patronal"
        objPlantilla.columnaSQL = "excedentePatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Excedente Obrero"
        objPlantilla.columnaSQL = "excedenteObrero"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Prestaciones en Dinero Patronal"
        objPlantilla.columnaSQL = "prestacionesDineroPatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Prestaciones en Dinero Obrero"
        objPlantilla.columnaSQL = "prestacionesDineroObrero"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Gastos Médicos y Pensionados Patronal"
        objPlantilla.columnaSQL = "gastosMedicosPensionadosPatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Gastos Médicos y Pensionados Obrero"
        objPlantilla.columnaSQL = "gastosMedicosPensionadosObrero"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Riesgos de Trabajo"
        objPlantilla.columnaSQL = "riesgoTrabajo"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Invalidez y Vida Patronal"
        objPlantilla.columnaSQL = "invalidezVidaPatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Invalidez y Vida Obrero"
        objPlantilla.columnaSQL = "invalidezVidaObrero"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Guarderías y Prestaciones Sociales"
        objPlantilla.columnaSQL = "guarderiasPrestacionesSociales"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "Total"
        objPlantilla.columnaSQL = "total"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "periodo"
        objPlantilla.columnaSQL = "periodo"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "ejercicio"
        objPlantilla.columnaSQL = "ejercicio"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "idRegistroPatronal"
        objPlantilla.columnaSQL = "idRegistroPatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEMA"
        objPlantilla.columnaArchivo = "idEmpresa"
        objPlantilla.columnaSQL = "idEmpresa"
        objColumnas.Add(objPlantilla)
        '****

        For Each fila In objData.Tables(0).Rows 'Filas
            Dim numColumna As Integer
            Dim dato As Object

            Dim objTabla As MovimientosEMA
            objTabla = New MovimientosEMA(Ambiente)

            For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                Try
                    numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                    dato = fila.Item(numColumna)

                    If objColumnas.Item(i).tabla = "MovimientosEMA" Then
                        Select Case objColumnas.Item(i).columnaSQL
                            Case "nss"
                                objTabla.nss = dato
                            Case "nombre"
                                objTabla.nombre = dato
                            Case "origen"
                                objTabla.origen = dato
                            Case "tipoMovimiento"
                                objTabla.tipoMovimiento = dato
                            Case "fechaMovimiento"
                                objTabla.fechaMovimiento = dato
                            Case "dias"
                                objTabla.dias = dato
                            Case "salarioDiario"
                                objTabla.salarioDiario = dato
                            Case "cuotaFija"
                                objTabla.cuotaFija = dato
                            Case "excedentePatronal"
                                objTabla.excedentePatronal = dato
                            Case "excedenteObrero"
                                objTabla.excedenteObrero = dato
                            Case "prestacionesDineroPatronal"
                                objTabla.prestacionesDineroPatronal = dato
                            Case "prestacionesDineroObrero"
                                objTabla.prestacionesDineroObrero = dato
                            Case "gastosMedicosPensionadosPatronal"
                                objTabla.gastosMedicosPensionadosPatronal = dato
                            Case "gastosMedicosPensionadosObrero"
                                objTabla.gastosMedicosPensionadosObrero = dato
                            Case "riesgoTrabajo"
                                objTabla.riesgoTrabajo = dato
                            Case "invalidezVidaPatronal"
                                objTabla.invalidezVidaPatronal = dato
                            Case "invalidezVidaObrero"
                                objTabla.invalidezVidaObrero = dato
                            Case "guarderiasPrestacionesSociales"
                                objTabla.guarderiasPrestacionesSociales = dato
                            Case "total"
                                objTabla.total = dato
                            Case "periodo"
                                objTabla.periodo = dato
                            Case "ejercicio"
                                objTabla.ejercicio = dato
                            Case "idRegistroPatronal"
                                objTabla.idRegistroPatronal = dato
                            Case "idEmpresa"
                                objTabla.idEmpresa = dato
                        End Select
                    End If
                Catch ex As Exception
                    'MsgBox("Error: " & ex.Message)
                End Try
            Next

            'VALIDA DATOS
            If objTabla.idRegistroPatronal = Nothing Then
                objTabla.idRegistroPatronal = idRegistroPatronal
            End If
            If objTabla.idEmpresa = Nothing Then
                objTabla.idEmpresa = idEmpresa
            End If
            If objTabla.periodo = Nothing Then
                objTabla.periodo = periodo
            End If
            If objTabla.ejercicio = Nothing Then
                objTabla.ejercicio = ejercicio
            End If
            '******

            If Not objTabla.guardar() Then
                idError = objTabla.idError
                descripError &= "MovimientosEMA: " & objTabla.descripError & vbCrLf
            End If
        Next

        If idError = 0 Then
            '****PROCESAR LOS REGISTROS
            conex.Qry = "EXEC spExcelIMSS '" & ejercicio & "-" & periodo & "-01'," & idRegistroPatronal & ",0,0"

            If conex.ejecutaQry() Then
                Return True
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
            '********* 
        Else
            Return False
        End If
    End Function
End Class
