Imports System.Data.SqlClient
Imports Cerberus

Public Class VisitaSucursal
    Implements InterfaceTablas

    '
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public idError As Integer
    Public descripError As String

    Private edoDocs As EstadoDocumentos
    '
    Public idVisitaSucursal As Integer
    Public idEmpleado As Integer
    Public salida As DateTime
    Public regreso As DateTime
    Public idSucOrigen As Integer
    Public idSucDestino As Integer
    Public sucursalPagaHorasExtra As Boolean
    Public totalHorasAut As Decimal
    Public idFormaPagoTraslado As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public descripcion As String
    Public estado As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        edoDocs = New EstadoDocumentos
    End Sub

    Public Function getNombreEstado() As String
        Return edoDocs.getNombreEstado(estado)
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idVisitaSucursal = rdr("idVisitaSucursal")
        idEmpleado = rdr("idEmpleado")
        salida = rdr("salida")
        regreso = rdr("regreso")
        idSucOrigen = rdr("idSucOrigen")
        idSucDestino = rdr("idSucDestino")
        sucursalPagaHorasExtra = rdr("sucursalPagaHorasExtra")
        totalHorasAut = rdr("totalHorasAut")
        idFormaPagoTraslado = rdr("idFormaPagoTraslado")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        descripcion = rdr("descripcion")
        estado = rdr("estado")
    End Sub

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of VisitaSucursal), anio As String)
        Dim filtro As String = ""
        If anio <> "" Then
            filtro = " AND  YEAR(salida) = " & anio.ToString
        End If
        cargarGridGen(dgv, filtro, obj)
    End Sub

    Public Sub cargaGridVisitas(dgv As DataGridView, idEmpleado As Integer, inicioPerido As Date, finPeriodo As Date)
        Dim ds As DataSet

        conex.numCon = 0
        conex.Qry = "EXEC spGetVisitasSuc " & idEmpleado & ",'" & Format(inicioPerido, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'"

        ds = conex.ejecutaConsultaDS(True)

        dgv.DataSource = ds
        dgv.DataMember = "dataTable"
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, obj As List(Of VisitaSucursal))
        Dim plantilla As VisitaSucursal
        Dim dtb As New DataTable("VisitaSucursal")
        Dim row As DataRow

        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Salida", Type.GetType("System.String"))
        dtb.Columns.Add("Regreso", Type.GetType("System.String"))
        dtb.Columns.Add("Suc Origen", Type.GetType("System.String"))
        dtb.Columns.Add("Suc Destino", Type.GetType("System.String"))
        dtb.Columns.Add("Actualizado", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))

        obj.Clear()

        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("V.*")
        conex.agregaCampo("concat(E.nombreEmpleado,' ',E.apPatEmpleado,' ',E.apMatEmpleado) as nEmpleado")
        conex.agregaCampo("SO.nombreSucursal as nSO")
        conex.agregaCampo("SD.nombreSucursal as nSD")
        conex.agregaCampo("A.usuario")

        conex.tabla = "VisitaSucursal as V, Empleado as E, Sucursal as SO, Sucursal as SD,Empleado as A "

        conex.condicion = "WHERE V.idSucOrigen = SO.idSucursal "
        conex.condicion &= "AND V.idSucDestino = SD.idSucursal "
        conex.condicion &= "AND A.idEmpleado = V.actualizadoPor "
        conex.condicion &= "AND E.idEmpleado = V.idEmpleado "
        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            conex.condicion &= "AND E.idDepartamento In (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If
        conex.condicion &= "And E.idEmpleado = V.idEmpleado "
        conex.condicion &= "And V.idEmpresa = " & idEmpresa & " " & condicion

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New VisitaSucursal(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
                row = dtb.NewRow
                row("Empleado") = conex.reader("nEmpleado")
                row("Salida") = Format(plantilla.salida, "dd/MM/yyyy")
                row("Regreso") = Format(plantilla.regreso, "dd/MM/yyyy")
                row("Suc Origen") = conex.reader("nSO")
                row("Suc Destino") = conex.reader("nSD")
                row("Actualizado") = conex.reader("usuario")
                row("Estado") = edoDocs.getNombreEstado(plantilla.estado)

                dtb.Rows.Add(row)
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "VisitaSucursal.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "VisitaSucursal"
            conex.accion = accion

            conex.agregaCampo("salida", salida, False, False)
            conex.agregaCampo("regreso", regreso, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idSucOrigen", idSucOrigen, False, False)
            conex.agregaCampo("idSucDestino", idSucDestino, False, False)
            conex.agregaCampo("sucursalPagaHorasExtra", sucursalPagaHorasExtra, False, False)
            conex.agregaCampo("totalHorasAut", totalHorasAut, False, False)
            conex.agregaCampo("idFormaPagoTraslado", idFormaPagoTraslado, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("descripcion", descripcion, False, False)
            conex.agregaCampo("estado", estado, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idVisitaSucursal = " & idVisitaSucursal

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "VisitaSucursal.armaQry" & vbCrLf & conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "Select @@IDENTITY As ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idVisitaSucursal = conex.reader("ID")
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

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If estado = "BO" Then
            Return armaQry("DELETE", True)
        Else
            idError = 2
            descripError = "No se puede eliminar la VISITA cuando se encuentra COMPLETA.!!"
            Return False
        End If
    End Function

    Public Function moverEstadoDocuento(nuevoEstado As String, accion As Integer) As Boolean
        'accion = 1 GUARDAR     accion = 2 ACTUALIZAR
        Dim estadoAnt As String
        Dim acc As String
        Dim accBool As Boolean
        estadoAnt = estado

        estado = nuevoEstado

        If accion = 1 Then
            acc = "INSERT"
            accBool = True
        Else
            acc = "UPDATE"
            accBool = False
        End If

        If armaQry(acc, accBool) Then
            If estado = "CO" Then
                Dim suc As New Sucursal(Ambiente)
                suc.idSucursal = idSucursal
                suc.buscarPID()

                Dim empl As New Empleado(Ambiente)
                empl.idEmpleado = idEmpleado
                empl.buscarPID()

                Dim formaPago As New FormaPagoTraslado(Ambiente)
                formaPago.idFormaPagoTraslado = idFormaPagoTraslado
                formaPago.buscarPID()

                Dim objTraslado As New Traslado(Ambiente)
                objTraslado.idVisita = idVisitaSucursal
                objTraslado.tipoTraslado = 1 'IDA
                objTraslado.buscarPVisita()

                If Not objTraslado.generaCxP(idEmpleado,
                                             regreso,
                                             idSucDestino,
                                             suc.nombreSucursal,
                                             empl.getTabulador().getVersionActual.costoXhoraExtra,
                                             formaPago.idConceptoCuenta,
                                             formaPago.tipoPago,
                                             formaPago.valorPago) Then

                    idError = objTraslado.idError
                    descripError = objTraslado.descripError
                    Return False
                End If

                objTraslado.tipoTraslado = 2 'REGRESO
                objTraslado.buscarPVisita()

                If Not objTraslado.generaCxP(idEmpleado,
                                             regreso,
                                             idSucDestino,
                                             suc.nombreSucursal,
                                             empl.getTabulador().getVersionActual.costoXhoraExtra,
                                             formaPago.idConceptoCuenta,
                                             formaPago.tipoPago,
                                             formaPago.valorPago) Then

                    idError = objTraslado.idError
                    descripError = objTraslado.descripError
                    Return False
                End If
            Else

            End If

            Return True
        Else
            estado = estadoAnt
            Return False
        End If
    End Function

    Public Function buscarPFechaYEmpl(fecha As Date) As Boolean
        conex.numCon = 0
        conex.accion = "Select"

        conex.agregaCampo("*")

        conex.tabla = "VisitaSucursal"

        conex.condicion = "WHERE convert(Date,'" & Format(fecha, "yyyy-MM-dd") & "') between salida and regreso AND estado = 'CO' AND idEmpleado = " & idEmpleado

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
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
        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "VisitaSucursal"

        conex.condicion = "WHERE idVisitaSucursal=" & idVisitaSucursal

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        creadoPor = Ambiente.usuario.idEmpleado
        actualizadoPor = Ambiente.usuario.idEmpleado

        If descripcion.Length < 5 Then
            idError = 1
            descripError = "Es necesario indicar almenos 5 letras..."
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
End Class
