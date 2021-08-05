Imports System.Data.SqlClient
Imports Cerberus

Public Class Cuenta
    Implements InterfaceTablas


    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado
    Private objEmpleado As Empleado
    Private objSucursal As Sucursal

    Public idCuenta As Integer
    Public tipoCuenta As String
    Public monto As Decimal
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public noDocumento As String
    Public fechaCuenta As Date
    Public creado As DateTime
    Public actualizado As DateTime
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public estado As String 'BO = Borrador,PA=Por Autorizar, CO = Completo, CA=Cancelado, PR = Procesada
    Public idPeriodo As Integer
    Public esCuentaManual As Boolean
    Public sistemaOrigen As String
    Public esAutorizada As Boolean

    Public idCocina As Integer
    Public idEmpleado As Integer

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls
    Public idError As Integer
    Public descripError As String

    Public descripccion As String
    Private consec As Consecutivo

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Private edoDocs As EstadoDocumentos

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        edoDocs = New EstadoDocumentos
    End Sub

    Private Sub creaDSDatos()
        rptDatos = New Reporte(Ambiente, "Cuenta", tipoCuenta)

        conex.numCon = 0

        conex.Qry = "EXEC spImprimirCuenta " & idCuenta

        'rptDatos.agregaVarible("", "")

        dsDatos = conex.ejecutaConsultaDS(False)
    End Sub

    Public Sub RPT_ImprimirDatos()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatos()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idCuenta = rdr("idCuenta")
        tipoCuenta = rdr("tipoCuenta")
        monto = rdr("monto")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        noDocumento = rdr("noDocumento")
        fechaCuenta = rdr("fechaCuenta")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        estado = rdr("estado")
        idCocina = If(IsDBNull(rdr("idCocina")), Nothing, rdr("idCocina"))
        idEmpleado = If(IsDBNull(rdr("idEmpleado")), Nothing, rdr("idEmpleado"))
        idPeriodo = If(IsDBNull(rdr("idPeriodo")), Nothing, rdr("idPeriodo"))
        descripccion = rdr("descripccion")
        sistemaOrigen = If(IsDBNull(rdr("sistemaOrigen")), Nothing, rdr("sistemaOrigen"))
        esCuentaManual = If(IsDBNull(rdr("esCuentaManual")), Nothing, rdr("esCuentaManual"))
        esAutorizada = If(IsDBNull(rdr("esAutorizada")), Nothing, rdr("esAutorizada"))
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
            conex.tabla = "Cuenta"
            conex.accion = accion

            conex.agregaCampo("tipoCuenta", tipoCuenta, False, False)
            conex.agregaCampo("monto", monto, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("noDocumento", noDocumento, False, False)
            conex.agregaCampo("fechaCuenta", fechaCuenta, False, False)
            conex.agregaCampo("estado", estado, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, True, False)
            conex.agregaCampo("idCocina", idCocina, True, False)
            conex.agregaCampo("idPeriodo", idPeriodo, True, False)
            conex.agregaCampo("descripccion", descripccion, False, False)
            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
            conex.agregaCampo("esCuentaManual", esCuentaManual, False, False)
            conex.agregaCampo("esAutorizada", esAutorizada, False, False)
            conex.agregaCampo("sistemaOrigen", sistemaOrigen, True, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idCuenta = " & idCuenta
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
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idCuenta = conex.reader("ID")
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

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Cuenta), estado As String, idElemento As Integer, fechaInicial As Date, fechaFinal As Date, elemento As String)
        Dim condicion As String
        condicion = ""

        If elemento = "Empleado" Then
            If idElemento <> Nothing Then
                condicion = " AND Empleado.idEmpleado=" & idElemento
            End If

            If estado <> "TO" And estado <> "" Then
                condicion &= " AND estado = '" & estado & "' "
            End If

            condicion &= " AND convert(date,fechaCuenta) between convert(date,'" & Format(fechaInicial, "yyyy-MM-dd") & "') AND convert(date,'" & Format(fechaFinal, "yyyy-MM-dd") & "') "

            If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
                condicion &= " AND Empleado.idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
            End If

            cargarGridGenEmpl(dgv, condicion, obj)
        Else
            If idElemento <> Nothing Then
                condicion = " AND Cocina.idCocina=" & idElemento
            End If

            If estado <> "TO" And estado <> "" Then
                condicion &= " AND estado = '" & estado & "' "
            End If

            condicion &= " AND convert(date,fechaCuenta) between convert(date,'" & Format(fechaInicial, "yyyy-MM-dd") & "') AND convert(date,'" & Format(fechaFinal, "yyyy-MM-dd") & "') "

            cargarGridGenCocina(dgv, condicion, obj)
        End If
    End Sub

    Public Sub cargaGridCom(dgv As DataGridView, obj As List(Of Cuenta), idCuenta As Integer, elemento As String)
        Dim condicion As String
        condicion = ""

        If elemento = "Empleado" Then
            condicion = " AND idCuenta = " & idCuenta

            cargarGridGenEmpl(dgv, condicion, obj)
        Else
            condicion = " AND idCuenta = " & idCuenta

            cargarGridGenCocina(dgv, condicion, obj)
        End If
    End Sub

    Private Sub cargarGridGenCocina(grid As DataGridView, condicion As String, objEmp As List(Of Cuenta))
        Dim plantilla As Cuenta
        Dim dtb As New DataTable("Cuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento", Type.GetType("System.String"))
        dtb.Columns.Add("Descripccion", Type.GetType("System.String"))
        dtb.Columns.Add("Cocina", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Total Cuenta", Type.GetType("System.Double"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT Cuenta.*,Cocina.NombreCocina FROM Cuenta,Cocina WHERE Cuenta.idCocina = Cocina.idCocina AND Cuenta.idEmpresa = " & idEmpresa & " AND Cuenta.tipoCuenta='" & tipoCuenta & "' " & condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Cuenta(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento") = plantilla.noDocumento
                row("Descripccion") = plantilla.descripccion
                row("Cocina") = conex.reader("NombreCocina")
                row("Fecha Cuenta") = Format(plantilla.fechaCuenta, "dd/MM/yyyy")
                row("Total Cuenta") = plantilla.monto
                row("Estado") = edoDocs.getNombreEstado(plantilla.estado)

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
            Mensaje.origen = "Cuenta.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaDatosEmplXLinea(grid As DataGridView, indice As Integer)
        objActualizadoPor = Nothing
        objEmpleado = Nothing
        objSucursal = Nothing

        grid.Rows.Item(indice).Cells(0).Value = noDocumento
        grid.Rows.Item(indice).Cells(1).Value = descripccion
        grid.Rows.Item(indice).Cells(2).Value = getSucursal().nombreSucursal
        Dim empleado_temp = getEmpleado()
        grid.Rows.Item(indice).Cells(3).Value = empleado_temp.nombreEmpleado & " " & empleado_temp.apPatEmpleado & " " & empleado_temp.apMatEmpleado
        grid.Rows.Item(indice).Cells(4).Value = Format(fechaCuenta, "dd/MM/yyyy")
        grid.Rows.Item(indice).Cells(5).Value = FormatCurrency(monto)
        grid.Rows.Item(indice).Cells(6).Value = edoDocs.getNombreEstado(estado)
    End Sub

    Private Sub cargarGridGenEmpl(grid As DataGridView, condicion As String, objEmp As List(Of Cuenta))
        Dim plantilla As Cuenta
        Dim dtb As New DataTable("Cuenta")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("Documento", Type.GetType("System.String"))
        dtb.Columns.Add("Descripccion", Type.GetType("System.String"))
        dtb.Columns.Add("Sucursal", Type.GetType("System.String"))
        dtb.Columns.Add("Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Total Cuenta", Type.GetType("System.String"))
        dtb.Columns.Add("Estado", Type.GetType("System.String"))

        objEmp.Clear()

        conex.Qry = "SELECT Cuenta.*,Sucursal.nombreSucursal,Concat(Empleado.NombreEmpleado,' ',Empleado.ApPatEmpleado,' ',Empleado.ApMatEmpleado) as nEmpleado FROM Cuenta,Empleado,Sucursal WHERE Cuenta.idSucursal = Sucursal.idSucursal AND Cuenta.idEmpleado = Empleado.idEmpleado AND Cuenta.idEmpresa = " & idEmpresa & " AND Cuenta.tipoCuenta='" & tipoCuenta & "' " & condicion & " ORDER BY Sucursal.nombreSucursal,Cuenta.noDocumento DESC"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Cuenta(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Documento") = plantilla.noDocumento
                row("Descripccion") = plantilla.descripccion
                row("Sucursal") = conex.reader("nombreSucursal")
                row("Empleado") = conex.reader("nEmpleado")
                row("Fecha Cuenta") = Format(plantilla.fechaCuenta, "dd/MM/yyyy")
                row("Total Cuenta") = FormatCurrency(plantilla.monto)
                row("Estado") = edoDocs.getNombreEstado(plantilla.estado)

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
            Mensaje.origen = "Cuenta.cargarGridGenEmpl"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        If estado = "BO" Then
            Return armaQry("DELETE", False)
        ElseIf estado = "CO" Or estado = "PA" Then
            estado = "CA"
            Return armaQry("UPDATE", False)
        ElseIf estado = "PR" Then
            idError = 1
            descripError = "No se puede eliminar la Cuenta debido a que ya se encuentra Procesada."
            Return False
        Else
            Return True
        End If
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("*")

        conex.tabla = "Cuenta"

        conex.condicion = "WHERE idCuenta=" & idCuenta

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                idError = 1
                descripError = "No se encontro el ID buscado..."
                Return False
            End If

        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idCuenta & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function


    Private Function validaPeriodoActivo(ByRef valorPeriodo As Boolean) As Boolean
        conex.Qry = "SELECT esActivo FROM Periodo WHERE idEmpresa=" & idEmpresa & " AND elementoSistema='EFE' AND tabla='Cuenta' AND CONVERT(DATE,'" & Format(fechaCuenta, "yyyy-MM-dd") & "') BETWEEN inicioPeriodo AND finPeriodo ORDER BY esActivo"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read() Then
                valorPeriodo = conex.reader("esActivo")
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        creadoPor = Ambiente.usuario.idEmpleado
        actualizadoPor = Ambiente.usuario.idEmpleado

        If sistemaOrigen <> "synchronizer_CXP_AD_CERB_Destajo" Then
            Dim valorPeriodo As Boolean
            If validaPeriodoActivo(valorPeriodo) Then
                If valorPeriodo = False Then
                    descripError = "El periodo en el que se intenta guardar la cuenta se encuentra cerrado"
                    Return False
                End If
            Else
                descripError = "El periodo en el que se intenta guardar la cuenta no existe"
                Return False
            End If
            If descripccion = Nothing Then
                descripError = "El campo ""Descripcción"" de la CUENTA es Obligatorio"
                Return False
            End If

            consec = New Consecutivo(Ambiente)
            consec.idEmpresa = Ambiente.empr.idEmpresa
            consec.dato = tipoCuenta
            consec.prefijo = tipoCuenta
            consec.tabla = "Cuenta"
        End If

        If sistemaOrigen = "synchronizer_CXP_AD_CERB_Destajo" Then
            consec = New Consecutivo(Ambiente)
            consec.idEmpresa = idEmpresa
            consec.dato = tipoCuenta
            consec.prefijo = tipoCuenta
            consec.tabla = "Cuenta"
        End If

        If noDocumento = Nothing Then
            If consec.generaSiguienteConsec Then
                noDocumento = consec.siguienteConsecutivo
            Else
                idError = consec.idError
                descripError = consec.descripError
                Return False
            End If
        End If

        If estado = "CO" And Not Ambiente.usuario.esSupervisor And sistemaOrigen <> "CxPCalculoPorcentaje" Then
            estado = "PA"
            esAutorizada = True
        End If

        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        If objCreadoPor Is Nothing Then
            objCreadoPor = New Empleado(Ambiente)
            objCreadoPor.idEmpleado = creadoPor
            objCreadoPor.buscarPID()
        End If
        Return objCreadoPor
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
        If objSucursal Is Nothing Then
            objSucursal = New Sucursal(Ambiente)
            objSucursal.idSucursal = idSucursal
            objSucursal.buscarPID()
        End If
        Return objSucursal
    End Function


    Public Function getEmpleado() As Empleado
        If objEmpleado Is Nothing Then
            objEmpleado = New Empleado(Ambiente)
            objEmpleado.idEmpleado = idEmpleado
            objEmpleado.buscarPID()

        End If
        Return objEmpleado
    End Function

    Public Function ImportarExcel(archivo As String, hoja As String, rango As String, objColumnas As List(Of DetalleFormatoImportacion)) As Boolean
        Dim objExcel As New Excel(archivo, hoja, rango)
        Dim objData As DataSet
        objData = objExcel.leer()

        Dim llaveAnterior As String
        llaveAnterior = ""
        Dim llaveActual As String
        llaveActual = ""

        idError = 0
        descripError = ""

        For Each fila In objData.Tables(0).Rows 'Filas
            Dim numColumna As Integer
            Dim dato As Object

            Dim objCuenta As Cuenta
            Dim plantillaCuenta As Cuenta
            Dim objCuentaDetalle As CuentaDetalle

            plantillaCuenta = New Cuenta(Ambiente)
            objCuentaDetalle = New CuentaDetalle(Ambiente)

            For i As Integer = 0 To objColumnas.Count - 1 'Columnas IMPORTACION
                numColumna = objData.Tables(0).Columns(objColumnas.Item(i).columnaArchivo).Ordinal
                dato = fila.Item(numColumna)

                If objColumnas.Item(i).esLlave Then
                    llaveActual = dato
                End If

                If objColumnas.Item(i).tabla = "Cuenta" Then
                    Select Case objColumnas.Item(i).columnaSQL
                        Case "tipoCuenta"
                            plantillaCuenta.tipoCuenta = dato
                        Case "monto"
                            plantillaCuenta.monto = dato
                        Case "idPeriodo"
                            plantillaCuenta.idPeriodo = dato
                        Case "idEmpresa"
                            plantillaCuenta.idEmpresa = dato
                        Case "idSucursal"
                            plantillaCuenta.idSucursal = dato
                        Case "idCocina"
                            plantillaCuenta.idCocina = dato
                        Case "idEmpleado"
                            plantillaCuenta.idEmpleado = dato
                        Case "noDocumento"
                            plantillaCuenta.noDocumento = dato
                        Case "fechaCuenta"
                            plantillaCuenta.fechaCuenta = dato
                        Case "estado"
                            plantillaCuenta.estado = dato
                        Case "descripccion"
                            plantillaCuenta.descripccion = dato
                        Case "esCuentaManual"
                            plantillaCuenta.esCuentaManual = dato
                        Case "sistemaOrigen"
                            plantillaCuenta.sistemaOrigen = dato
                        Case "esAutorizada"
                            plantillaCuenta.esAutorizada = dato
                    End Select

                ElseIf objColumnas.Item(i).tabla = "CuentaDetalle" Then
                    Select Case objColumnas.Item(i).columnaSQL
                        Case "idConceptoCuenta"
                            objCuentaDetalle.idConceptoCuenta = dato
                        Case "monto"
                            objCuentaDetalle.monto = dato
                        Case "descripccion"
                            objCuentaDetalle.descripccion = dato
                    End Select
                End If
            Next

            If llaveAnterior <> llaveActual Then
                objCuenta = plantillaCuenta
                If Not objCuenta.guardar() Then
                    idError = objCuenta.idError
                    descripError &= "Cuenta: " & objCuenta.descripError & vbCrLf
                End If
            End If

            objCuentaDetalle.idCuenta = objCuenta.idCuenta
            If Not objCuentaDetalle.guardar() Then
                idError = objCuentaDetalle.idError
                descripError &= "CuentaDetalle: " & objCuentaDetalle.descripError & vbCrLf
            End If

            llaveAnterior = llaveActual
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub creaDSCuentasManuales()
        rptDatos = New Reporte(Ambiente, "Cuenta", "cuentasManuales")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("nombreEmpresa", Ambiente.empr.nombreEmpresa)
    End Sub
    'dev. Marcos Moreno
    Public Sub RPT_ImprimirCuentasManuales()
        creaDSCuentasManuales()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarCuentasManuales()
        creaDSCuentasManuales()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSPercepcionesXPeriodo()
        rptDatos = New Reporte(Ambiente, "Cuenta", "PercepcioneXPeriodo")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("nombreEmpresa", Ambiente.empr.nombreEmpresa)
    End Sub


    Public Sub RPT_ImprimirPercepcionesXPeriodo()
        creaDSPercepcionesXPeriodo()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPercepcionesXPeriodo()
        creaDSPercepcionesXPeriodo()
        rptDatos.modificar(dsDatos)
    End Sub
    'Fn dev. Marcos Moreno

    'dev. Marcos Moreno
    Public Sub RPT_ImprimirEstatus()
        creaDSEstatus()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarEstatus()
        creaDSEstatus()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSEstatus()
        rptDatos = New Reporte(Ambiente, "Estatus", "estatus")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno



    'dev. Marcos Moreno Credenciales
    Public Sub RPT_ImprimirCredenciales()
        creaDSCredenciales()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarCredenciales()
        creaDSCredenciales()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSCredenciales()
        rptDatos = New Reporte(Ambiente, "Credenciales", "empleado")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno Credenciales

    'dev. Marcos Moreno
    Public Sub RPT_ImprimirPagoTerceros()
        creaDSPagoTerceros()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPagoTerceros()
        creaDSPagoTerceros()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSPagoTerceros()
        rptDatos = New Reporte(Ambiente, "PagoTerceros", "rptPagoTerceros")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno

    'dev. Marcos Moreno
    Public Sub RPT_ImprimirFiniquitoDeuda()
        creaDSFiniquitoDeuda()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarFiniquitoDeuda()
        creaDSFiniquitoDeuda()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSFiniquitoDeuda()
        rptDatos = New Reporte(Ambiente, "FiniquitoDeuda", "rptFiniquitoDeuda")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno

    'dev. Marcos Moreno
    Public Sub RPT_ImprimirFiniquitosEntregar()
        creaDSFiniquitosEntregar()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarFiniquitosEntregar()
        creaDSFiniquitosEntregar()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSFiniquitosEntregar()
        rptDatos = New Reporte(Ambiente, "FiniquitosEntregar", "rptFiniquitosEntregar")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Marcos Moreno


    'dev. Comportamiento de Finiquitos Marcos Moreno
    Public Sub RPT_ImprimirComportamientoFiniq()
        creaDSComportamientoFiniq()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarComportamientoFiniq()
        creaDSComportamientoFiniq()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSComportamientoFiniq()
        rptDatos = New Reporte(Ambiente, "ComportamientoFiniq", "rptComportamientoFiniq")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    'Fn dev. Comportamiento de Finiquitos Marcos Moreno



    Private Sub creaRPTUniformesTallas()
        rptDatos = New Reporte(Ambiente, "Tallas", "tallasporcolaborador")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ImprimirRPTUniformesTallas()
        creaRPTUniformesTallas()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarRPTUniformesTallas()
        creaRPTUniformesTallas()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaRPTUniformesOrdenCompra()
        rptDatos = New Reporte(Ambiente, "OrdenCompraUni", "ordenCompreaUniformes")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ImprimirRPTUniformesOrdenCompra()
        creaRPTUniformesOrdenCompra()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarRPTUniformesOrdenCompra()
        creaRPTUniformesOrdenCompra()
        rptDatos.modificar(dsDatos)
    End Sub
End Class

