
Imports System.Data.SqlClient

Public Class CargasGasolina
    Implements InterfaceTablas

    'Variables que usa la tabla
    Public idCargasGasolina As Integer
    Public vehiculo As Integer
    Public placa As String
    Public descripcion As String
    Public grupo As String
    Public estacion As String
    Public fechaYhora As DateTime
    Public despacho As String
    Public pocision As Integer
    Public producto As String
    Public cantidad As Decimal
    Public monto As Decimal
    Public idUnidad As Integer
    Public idCuenta As Integer
    Public fechaCarga As DateTime
    Public estadoDocumento As String
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public asignadoA As Integer
    Public generaCobro As Boolean
    Public porcentajeDescuento As Decimal
    Public idConceptoCuenta As Integer
    Public procesada As Integer

    'variables y objetos
    Public Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private periodo As Periodo
    Private objCuenta As Cuenta
    Private edoDocs As EstadoDocumentos
    Public idError As Integer
    Public descripError As String
    Private objActualizadoPor As Empleado

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
        edoDocs = New EstadoDocumentos
    End Sub

    Public Function ActualizaCargasConPlaca(asignadoA As Integer, idUnidad As Integer, placa As String, generaCobro As Boolean, porcentajeDescuento As Decimal, idConceptoCuenta As Integer) As Boolean
        conex.numCon = 0
        conex.accion = "UPDATE"
        conex.tabla = "CargasGasolina"

        conex.agregaCampo("asignadoA", asignadoA, False, False)
        conex.agregaCampo("idUnidad", idUnidad, False, False)
        conex.agregaCampo("generaCobro", generaCobro, False, False)
        conex.agregaCampo("porcentajeDescuento", porcentajeDescuento, False, False)
        conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)
        conex.agregaCampo("idSucursal", "(SELECT idSucursal From Empleado where idEmpleado = " & asignadoA & ")", False, True)

        If generaCobro Then
            conex.agregaCampo("estadoDocumento", "NC", False, False)
        Else
            conex.agregaCampo("estadoDocumento", "SC", False, False)
        End If

        conex.condicion = "WHERE placa='" & placa & "' AND estadoDocumento in ('SC','NC') AND procesada = 0"

        conex.armarQry()

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function actualizaXPeriodoCerrado(inicioPeriodo As Date, finPeriodo As Date) As Boolean
        conex.numCon = 0
        conex.accion = "UPDATE"
        conex.tabla = "CargasGasolina"

        conex.agregaCampo("procesada", procesada, False, False)

        conex.condicion = "WHERE convert(date,fechaYHora) between convert(date,'" & Format(inicioPeriodo, "yyyy-MM-dd") & "') and convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') AND idEmpresa = " & idEmpresa & " AND idSucursal = " & idSucursal

        conex.armarQry()

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If

        Return True
    End Function

    Public Sub cargarGridComp(objDGVCargasGasolina As List(Of CargasGasolina), dgvGasolina As DataGridView, filtroCombo As String, iniPeriodo As Date, finPeriodo As Date, filtroCaja As String)
        Dim filtro As String
        filtro = " AND estadoDocumento like '%" & filtroCombo & "%' "
        filtro &= " AND (despacho like '%" & filtroCaja & "%'"
        filtro &= "OR descripcion like '%" & filtroCaja & "%'"
        filtro &= ")"

        cargaGridGen(dgvGasolina, objDGVCargasGasolina, iniPeriodo, finPeriodo, filtro)
    End Sub

    Private Sub cargaGridGen(dgvGasolina As DataGridView, objDGVCargasGasolina As List(Of CargasGasolina), inicioPeriodo As Date, finPeriodo As Date, filtro As String)

        Dim plantilla As CargasGasolina
        Dim dtb As New DataTable("CargasGasolina")
        Dim row As DataRow


        dtb.Columns.Add("Despacho", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Carga", Type.GetType("System.String"))
        dtb.Columns.Add("Descripción", Type.GetType("System.String"))
        dtb.Columns.Add("Monto", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))
        dtb.Columns.Add("Genera cobro", Type.GetType("System.String"))

        objDGVCargasGasolina.Clear()

        conex.numCon = 0
        conex.accion = "Select"
        conex.agregaCampo("*")
        conex.tabla = "CargasGasolina C"
        conex.condicion = "WHERE convert(Date,fechaYHora) between convert(Date,'" & Format(inicioPeriodo, "yyyy-MM-dd") & "') and convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') "
        conex.condicion &= "And C.idEmpresa=" & idEmpresa
        conex.condicion &= filtro & " ORDER BY fechaYhora"

        conex.armarQry()

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New CargasGasolina(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objDGVCargasGasolina.Add(plantilla)
                row = dtb.NewRow

                row("Despacho") = plantilla.despacho
                row("Fecha Carga") = Format(plantilla.fechaYhora, "ddd dd/MM/yyyy")
                row("Descripción") = plantilla.descripcion
                row("Monto") = FormatCurrency(plantilla.monto)
                row("Estado") = edoDocs.getNombreEstado(plantilla.estadoDocumento)
                row("Genera cobro") = If(plantilla.generaCobro, "Sí", "No")

                dtb.Rows.Add(row)
            End While
            conex.reader.Close()
            dgvGasolina.DataSource = dtb

            'Es para no permitir el reordenado de las coulmnas
            For i As Integer = 0 To dgvGasolina.Columns.Count - 1
                dgvGasolina.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "CargasGasolina.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function importarDesdeExcel(archivo As String, hoja As String) As Boolean
        'listaPlacas = New List(Of String)

        Dim errores As String
        errores = ""
        Dim objExcel As New Excel(archivo, hoja, "A1:L2000")
        Dim objDS As DataSet
        objDS = objExcel.leer()
        Dim fechaf As Date
        Dim avanzar As Boolean
        Dim plantilla As CargasGasolina

        If objDS.Tables.Count > 0 Then
            For Each tabla As DataTable In objDS.Tables
                For Each row As DataRow In tabla.Rows

                    If Not IsDBNull(row(0)) Or IsNumeric(row(0)) Then
                        avanzar = True
                    Else
                        avanzar = False
                    End If

                    If avanzar Then
                        plantilla = New CargasGasolina(Ambiente)
                        If Not IsDate(row(5)) Or IsDBNull(row(5)) Then
                            fechaf = DateTime.MinValue
                        Else
                            fechaf = DateTime.Parse(row(5) & " " & row(6))
                        End If

                        plantilla.vehiculo = If(IsDBNull(row(0)), 0, row(0)) Or If(Not IsNumeric(row(0)), 0, row(0))
                        plantilla.placa = If(IsDBNull(row(1)), "VACIO", row(1))
                        plantilla.descripcion = If(IsDBNull(row(2)), "VACIO", row(2))
                        plantilla.grupo = If(IsDBNull(row(3)), "VACIO", row(3))
                        plantilla.estacion = If(IsDBNull(row(4)), "VACIO", row(4))
                        plantilla.fechaYhora = fechaf
                        plantilla.despacho = If(IsDBNull(row(7)), "VACIO", row(7))
                        plantilla.pocision = If(IsDBNull(row(8)), 0, row(8)) Or If(Not IsNumeric(row(8)), 0, row(8))
                        plantilla.producto = If(IsDBNull(row(9)), "VACIO", row(9))
                        plantilla.cantidad = If(IsDBNull(row(10)), 0, row(10))
                        plantilla.monto = If(IsDBNull(row(11)), 0, row(11))
                        plantilla.fechaCarga = DateTime.Now
                        plantilla.estadoDocumento = "NC"
                        plantilla.creado = DateTime.Now
                        plantilla.creadoPor = Ambiente.usuario.idEmpleado
                        plantilla.actualizado = DateTime.Now
                        plantilla.actualizadoPor = Ambiente.usuario.idEmpleado
                        plantilla.idEmpresa = Ambiente.empr.idEmpresa
                        plantilla.idSucursal = Ambiente.suc.idSucursal

                        If Not plantilla.guardar() Then
                            errores &= plantilla.descripError & vbCrLf
                        End If
                    End If
                Next
            Next
        Else
            idError = 1
            descripError = "No se pudo importar el archivo de excel, por que no tiene datos..."
            Return False
        End If

        If errores = "" Then
            Return True
        Else
            descripError = "Ocurrio un error: " & vbCrLf & errores
            Return False
        End If

    End Function

    Public Function generarCuentaxP(fechaYhora As Date) As Boolean
        Dim CxP As New Cuenta(Ambiente)
        Dim montoFInal = monto - (monto * porcentajeDescuento) / (100)

        CxP.tipoCuenta = "CxC"
        CxP.monto = montoFInal
        CxP.fechaCuenta = fechaYhora
        CxP.estado = "CO"
        CxP.idEmpleado = asignadoA
        CxP.idEmpresa = idEmpresa
        CxP.idSucursal = idSucursal
        CxP.descripccion = "CARGA DE COMBUSTIBLE: " & despacho & " - " & descripcion
        CxP.esCuentaManual = False
        CxP.sistemaOrigen = "CargasGasolina.GenerarCuentaxC"

        If CxP.guardar Then
            Dim CxPD As New CuentaDetalle(Ambiente)
            CxPD.descripccion = CxP.descripccion
            CxPD.idConceptoCuenta = idConceptoCuenta
            CxPD.monto = montoFInal
            CxPD.idCuenta = CxP.idCuenta

            If Not CxPD.guardar Then
                idError = CxPD.idError
                descripError = CxPD.descripError
                Return False
            Else
                idCuenta = CxP.idCuenta
                estadoDocumento = "CB"

                Return actualizar()
            End If
        Else
            idError = CxP.idError
            descripError = "D: " & despacho & " - " & CxP.descripError
            Return False
        End If

    End Function


    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCargasGasolina = rdr("idCargasGasolina")
        vehiculo = rdr("vehiculo")
        placa = rdr("placa")
        descripcion = rdr("descripcion")
        grupo = rdr("grupo")
        estacion = rdr("estacion")
        fechaYhora = rdr("fechaYHora")
        despacho = rdr("despacho")
        pocision = rdr("pocision")
        producto = rdr("producto")
        cantidad = rdr("cantidad")
        monto = rdr("monto")
        idUnidad = If(IsDBNull(rdr("idUnidad")), Nothing, rdr("idUnidad"))
        idCuenta = If(IsDBNull(rdr("idCuenta")), Nothing, rdr("idCuenta"))
        fechaCarga = rdr("fechaCarga")
        estadoDocumento = rdr("estadoDocumento")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        generaCobro = If(IsDBNull(rdr("generaCobro")), Nothing, rdr("generaCobro"))
        asignadoA = If(IsDBNull(rdr("asignadoA")), Nothing, rdr("asignadoA"))
        porcentajeDescuento = If(IsDBNull(rdr("porcentajeDescuento")), Nothing, rdr("porcentajeDescuento"))
        idConceptoCuenta = If(IsDBNull(rdr("idConceptoCuenta")), Nothing, rdr("idConceptoCuenta"))
        procesada = rdr("procesada")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry

        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "CargasGasolina"
            conex.accion = accion

            conex.agregaCampo("vehiculo", vehiculo, False, False)
            conex.agregaCampo("placa", placa, False, False)
            conex.agregaCampo("descripcion", descripcion, False, False)
            conex.agregaCampo("grupo", grupo, False, False)
            conex.agregaCampo("estacion", estacion, False, False)
            conex.agregaCampo("fechaYHora", fechaYhora, False, False)
            conex.agregaCampo("despacho", despacho, False, False)
            conex.agregaCampo("pocision", pocision, False, False)
            conex.agregaCampo("producto", producto, False, False)
            conex.agregaCampo("cantidad", cantidad, False, False)
            conex.agregaCampo("monto", monto, False, False)
            conex.agregaCampo("fechaCarga", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)

            If esInsert Then
                conex.agregaCampo("idUnidad", "(SELECT idUnidad from Unidad WHERE placa='" & placa & "')", False, True)
                conex.agregaCampo("estadoDocumento", "(iif((select generaCobro from Unidad WHERE placa='" & placa & "')=0,'SC','NC'))", False, True)
                conex.agregaCampo("generaCobro", "(SELECT generaCobro from Unidad WHERE placa='" & placa & "')", False, True)
                conex.agregaCampo("asignadoA", "(SELECT asignadoA from Unidad WHERE placa='" & placa & "')", False, True)
                conex.agregaCampo("porcentajeDescuento", "(SELECT porcentajeDescuento from Unidad WHERE placa='" & placa & "')", False, True)
                conex.agregaCampo("idConceptoCuenta", "(SELECT idConceptoCuenta from Unidad WHERE placa='" & placa & "')", False, True)
                conex.agregaCampo("idSucursal", "(ISNULL((SELECT idSucursal FROM Empleado where idEmpleado = (SELECT asignadoA from Unidad WHERE placa='" & placa & "')), (SELECT idSucursal from Unidad WHERE placa='" & placa & "')))", False, True)

                conex.agregaCampo("creado", creado, False, False)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            Else
                conex.agregaCampo("idUnidad", idUnidad, False, False)
                conex.agregaCampo("estadoDocumento", estadoDocumento, False, False)
                conex.agregaCampo("generaCobro", generaCobro, False, False)
                conex.agregaCampo("asignadoA", asignadoA, False, False)
                conex.agregaCampo("porcentajeDescuento", porcentajeDescuento, False, False)
                conex.agregaCampo("idConceptoCuenta", idConceptoCuenta, False, False)
                conex.agregaCampo("idSucursal", idSucursal, False, False)
            End If

            conex.agregaCampo("idCuenta", idCuenta, True, False)
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("procesada", procesada, False, False)

            conex.condicion = "where idCargasGasolina=" & idCargasGasolina

            conex.armarQry()
            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    obtenerID()
                    buscarPID()

                    If asignadoA <> Nothing And generaCobro Then
                        Return generarCuentaxP(fechaYhora)
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = "CargasGasolina.armaQry" & vbCrLf & conex.descripError & vbCrLf & "PLACA / MONTO: " & placa & " / " & FormatCurrency(monto)
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Private Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idCargasGasolina = conex.reader("ID")
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

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar

        'Si es sin cobro, eliminar registro
        If estadoDocumento = "NC" Then
            Return armaQry("DELETE", False)

        ElseIf estadoDocumento = "CA" Then

            idError = 1
            descripError = "Esta cuenta está cancelada..."
            Return False

            'Si es cobrado, cancela cuenta
        ElseIf estadoDocumento = "CB" Then

            Dim objCuenta As New Cuenta(Ambiente)
            objCuenta.idCuenta = idCuenta
            objCuenta.buscarPID()
            objCuenta.eliminar()

            cancelarEstadoCargaGasolina(idCargasGasolina)

            Return True

        ElseIf estadoDocumento = Nothing Then
            idError = 1
            descripError = "Seleccione un registro para poder continuar..."
            Return False
        Else
            idError = 1
            descripError = "No se pudo ELIMINAR esta carga de gasolina..."
            Return False
        End If
    End Function

    Private Function cancelarEstadoCargaGasolina(idCargasGasolina As Integer) As Boolean
        Dim acc As String = "UPDATE"
        Dim nuevoEstadoDocumento As String = "CA"
        conex.numCon = 0
        conex.tabla = "CargasGasolina"
        conex.accion = acc

        conex.agregaCampo("estadoDocumento", nuevoEstadoDocumento, False, False)
        conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
        conex.agregaCampo("actualizadoPor", Ambiente.usuario.idEmpleado, False, False)
        conex.condicion = "WHERE idCargasGasolina=" & idCargasGasolina

        conex.armarQry()

        If conex.ejecutaQry Then
            Return True
        Else
            idError = conex.idError
            descripError = "CargasGasolina.cancelarEstadoCarga" & vbCrLf & conex.descripError
            Return False
        End If

    End Function

    Public Function getColorEstado() As Color
        Return edoDocs.getColor(estadoDocumento)
    End Function
    Public Function getNombreEstado() As String
        Return edoDocs.getNombreEstado(estadoDocumento)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.accion = "SELECT"
        conex.tabla = "CargasGasolina"
        conex.agregaCampo("*")
        conex.condicion = "WHERE idCargasGasolina=" & idCargasGasolina

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
        If objActualizadoPor Is Nothing Then
            objActualizadoPor = New Empleado(Ambiente)
            objActualizadoPor.idEmpleado = actualizadoPor
            objActualizadoPor.buscarPID()
        End If
        Return objActualizadoPor
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function
End Class
