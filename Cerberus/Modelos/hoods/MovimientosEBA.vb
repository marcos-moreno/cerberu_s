Imports System.Data.SqlClient
Imports Cerberus

Public Class MovimientosEBA
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idMovimientoEBA As Integer
    Public idEmpresa As Integer
    Public idRegistroPatronal As Integer
    Public nss As String
    Public nombre As String
    Public origen As String
    Public tipoMovimiento As Integer
    Public fechaMovimiento As DateTime
    Public dias As Integer
    Public salarioDiario As Decimal
    Public retiro As Decimal
    Public CEAVP As Decimal
    Public CEAVO As Decimal
    Public subtotalRCV As Decimal
    Public aportacionPatronal As Decimal
    Public tipoDocumento As String
    Public valorDescuento As Decimal
    Public numCredito As String
    Public amortizacion As Decimal
    Public subtotalInfonavit As Decimal
    Public total As Decimal
    Public ejercicio As Integer
    Public periodo As Integer

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idMovimientoEBA = rdr("idMovimientoEBA")
        idEmpresa = rdr("idEmpresa")
        idRegistroPatronal = rdr("idRegistroPatronal")
        nss = rdr("nss")
        nombre = rdr("nombre")
        origen = rdr("origen")
        tipoMovimiento = rdr("tipoMovimiento")
        fechaMovimiento = rdr("fechaMovimiento")
        dias = rdr("dias")
        salarioDiario = rdr("salarioDiario")
        retiro = rdr("retiro")
        CEAVP = rdr("CEAVP")
        CEAVO = rdr("CEAVO")
        subtotalRCV = rdr("subtotalRCV")
        aportacionPatronal = rdr("aportacionPatronal")
        tipoDocumento = rdr("tipoDocumento")
        valorDescuento = rdr("valorDescuento")
        numCredito = rdr("numCredito")
        amortizacion = rdr("amortizacion")
        subtotalInfonavit = rdr("subtotalInfonavit")
        total = rdr("total")
        ejercicio = rdr("ejercicio")
        periodo = rdr("periodo")
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
        Throw New NotImplementedException()
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos

        If idEmpresa = Nothing Then
            idEmpresa = Ambiente.empr.idEmpresa
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
        If validaDatos(esInsert) Then

            If nss = Nothing Then
                Return True
            End If

            conex.numCon = 0
            conex.tabla = "MovimientosEBA"
            conex.accion = accion

            conex.agregaCampo("nss", nss, False, False)
            conex.agregaCampo("nombre", nombre, False, False)
            conex.agregaCampo("origen", origen, False, False)
            conex.agregaCampo("tipoMovimiento", tipoMovimiento, False, False)
            conex.agregaCampo("fechaMovimiento", fechaMovimiento, True, False)
            conex.agregaCampo("dias", dias, True, False)
            conex.agregaCampo("salarioDiario", salarioDiario, True, False)
            conex.agregaCampo("retiro", retiro, True, False)
            conex.agregaCampo("CEAVP", CEAVP, True, False)
            conex.agregaCampo("CEAVO", CEAVO, True, False)
            conex.agregaCampo("subtotalRCV", subtotalRCV, True, False)
            conex.agregaCampo("aportacionPatronal", aportacionPatronal, True, False)
            conex.agregaCampo("tipoDocumento", tipoDocumento, True, False)
            conex.agregaCampo("valorDescuento", valorDescuento, True, False)
            conex.agregaCampo("numCredito", numCredito, True, False)
            conex.agregaCampo("amortizacion", amortizacion, True, False)
            conex.agregaCampo("subtotalInfonavit", subtotalInfonavit, True, False)
            conex.agregaCampo("total", total, True, False)
            conex.agregaCampo("periodo", periodo, False, False)
            conex.agregaCampo("ejercicio", ejercicio, False, False)
            conex.agregaCampo("idRegistroPatronal", idRegistroPatronal, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idMovimientoEBA = " & idMovimientoEBA

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
                idMovimientoEBA = conex.reader("ID")
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
        conex.tabla = "MovimientosEBA_PR"
        conex.condicion = "WHERE idMovimientosEBA IN (SELECT BA.idMovimientoEBA FROM MovimientosEBA as BA where BA.idRegistroPatronal = " & idRegistroPatronal & " and BA.periodo = " & periodo & " and BA.ejercicio = " & ejercicio & ")"

        conex.armarQry()
        If Not conex.ejecutaQry Then
            idError = conex.ejecutaQry
            descripError = conex.descripError
            Return False
        End If

        conex.accion = "DELETE"
        conex.tabla = "MovimientosEBA"
        conex.condicion = "WHERE idRegistroPatronal = " & idRegistroPatronal & " and periodo = " & Periodo & " and ejercicio = " & ejercicio

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
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "NSS"
        objPlantilla.columnaSQL = "nss"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Nombre"
        objPlantilla.columnaSQL = "nombre"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Origen del Movimiento"
        objPlantilla.columnaSQL = "origen"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Tipo del Movimiento"
        objPlantilla.columnaSQL = "tipoMovimiento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Fecha del Movimiento"
        objPlantilla.columnaSQL = "fechaMovimiento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Días"
        objPlantilla.columnaSQL = "dias"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Salario Diario"
        objPlantilla.columnaSQL = "salarioDiario"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Retiro"
        objPlantilla.columnaSQL = "retiro"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Cesantía en Edad Avanzada y Vejez Patronal"
        objPlantilla.columnaSQL = "CEAVP"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Cesantía en Edad Avanzada y Vejez Obrero"
        objPlantilla.columnaSQL = "CEAVO"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Subtotal RCV"
        objPlantilla.columnaSQL = "subtotalRCV"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Aportación Patronal"
        objPlantilla.columnaSQL = "aportacionPatronal"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Tipo de Descuento"
        objPlantilla.columnaSQL = "tipoDocumento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Valor de Descuento"
        objPlantilla.columnaSQL = "valorDescuento"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Número de Crédito"
        objPlantilla.columnaSQL = "numCredito"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Amortización"
        objPlantilla.columnaSQL = "amortizacion"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Subtotal Infonavit"
        objPlantilla.columnaSQL = "subtotalInfonavit"
        objColumnas.Add(objPlantilla)

        objPlantilla = New DetalleFormatoImportacion(Ambiente)
        objPlantilla.tabla = "MovimientosEBA"
        objPlantilla.columnaArchivo = "Total"
        objPlantilla.columnaSQL = "total"
        objColumnas.Add(objPlantilla)

        '****

        For Each fila In objData.Tables(0).Rows 'Filas
            Dim numColumna As Integer
            Dim dato As Object

            Dim objTabla As MovimientosEBA
            objTabla = New MovimientosEBA(Ambiente)

            For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                Try
                    numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                    dato = fila.Item(numColumna)

                    If objColumnas.Item(i).tabla = "MovimientosEBA" Then
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
                            Case "retiro"
                                objTabla.retiro = dato
                            Case "CEAVP"
                                objTabla.CEAVP = dato
                            Case "CEAVO"
                                objTabla.CEAVO = dato
                            Case "subtotalRCV"
                                objTabla.subtotalRCV = dato
                            Case "aportacionPatronal"
                                objTabla.aportacionPatronal = dato
                            Case "tipoDocumento"
                                objTabla.tipoDocumento = dato
                            Case "valorDescuento"
                                objTabla.valorDescuento = dato
                            Case "numCredito"
                                objTabla.numCredito = dato
                            Case "amortizacion"
                                objTabla.amortizacion = dato
                            Case "subtotalInfonavit"
                                objTabla.subtotalInfonavit = dato
                            Case "total"
                                objTabla.total = dato
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
                objTabla.periodo = Periodo
            End If
            If objTabla.ejercicio = Nothing Then
                objTabla.ejercicio = ejercicio
            End If
            '******

            If Not objTabla.guardar() Then
                idError = objTabla.idError
                descripError &= "MovimientosEBA: " & objTabla.descripError & vbCrLf
            End If
        Next

        If idError = 0 Then
            '****PROCESAR LOS REGISTROS
            conex.Qry = "EXEC spCalculaINFONAVIT '" & ejercicio & "-" & periodo & "-01'," & idRegistroPatronal

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
