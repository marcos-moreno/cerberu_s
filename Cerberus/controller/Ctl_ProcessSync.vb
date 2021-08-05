
Imports System.IO

Public Class Ctl_ProcessSync

    Public idError As Integer
    Public descripError As String
    Private _context As AmbienteCls
    Private _dao_AD_PP_Order As Dao_AD_PP_Order
    Private _Cuenta As Cuenta
    Private _Cuentadetalle As CuentaDetalle
    Private _Empleado As Empleado
    Private archivoXMLPgSQLHOODS As String = "dataconPgSQL.xml"
    Private archivoXMLPgSQLRFV As String = "dataconPgSQLRFV.xml"
    Private dataconPgSQLMEGA As String = "dataconPgSQLMEGA.xml"
    Public conPgSQL As ConexionPG
    Public postgresState As Boolean = False
    Public Function LeerPgSQL() As Boolean
        Try
            If _context.empr.idEmpresa = 1 Then
                conPgSQL = New ConexionPG(archivoXMLPgSQLHOODS, 1)
            ElseIf _context.empr.idEmpresa = 5 Then
                conPgSQL = New ConexionPG(archivoXMLPgSQLRFV, 1)
            ElseIf _context.empr.idEmpresa = 9 Then
                conPgSQL = New ConexionPG(dataconPgSQLMEGA, 1)
            End If
            Try
                conPgSQL.conn.Item(0).Close()
                conPgSQL.conn.Item(0).Open()
                postgresState = True
            Catch ex As Exception
                postgresState = False
            End Try
        Catch ex As Exception
            Mensaje.Mensaje = "Error de Conexión: " & ex.Message
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Return False
        End Try
        Return True
    End Function



    Public Sub New(_context As AmbienteCls)
        Me._context = _context
        conectarAD()
        _dao_AD_PP_Order = New Dao_AD_PP_Order(Me._context, conPgSQL)

    End Sub

    Public Function fillComboSucursales(combo As ComboBox, idCombos As List(Of Integer)) As Boolean
        Return _dao_AD_PP_Order.getComboSucursales(combo, idCombos)
    End Function


    Private Function conectarAD() As Boolean
        Return LeerPgSQL()
    End Function

    Friend Sub execute(idOrgSelected As Integer)
        'Consultar Distinto pagos=
        If _dao_AD_PP_Order.consult_Distinct_C_Payment_ID(idOrgSelected) Then
            If _dao_AD_PP_Order.ListOfDistinct_C_Payment_ID.Count > 0 Then
                'Recorrer los pagos
                For Each C_Payment_ID As Integer In _dao_AD_PP_Order.ListOfDistinct_C_Payment_ID
                    Dim _dao_AD_PP_OrderUnit As Dao_AD_PP_Order = New Dao_AD_PP_Order(_context, Me.conPgSQL)
                    'Buscar linas por pago
                    _dao_AD_PP_OrderUnit.C_Payment_ID = C_Payment_ID
                    If _dao_AD_PP_OrderUnit.consult_AD_PP_Order(idOrgSelected) Then
                        If _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Count > 0 Then
                            If getEmpleado(_dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0)) Then
                                If insertOrder(_dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0)) Then
                                    If _Cuenta.noDocumento.Length > 0 Then
                                        For Each AD_PP As Dto_AD_PP_Order In _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP
                                            insertOrderLine(AD_PP)
                                        Next
                                        _Empleado = Nothing
                                    End If
                                Else
                                    addLine(" - Error al insertar la orden:" & _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0).PagoDestajo)
                                    MsgBox(" - Error al insertar la orden:" & _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0).PagoDestajo)
                                End If
                            Else
                                addLine(" - No se econtró un empleado activo, NSS:" & _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0).SeguroSocial)
                                MsgBox(" - No se econtró un empleado activo, NSS:" & _dao_AD_PP_OrderUnit.ListOf_Dto_AD_PP.Item(0).SeguroSocial)
                            End If
                        End If
                    End If
                Next
            Else
                Mensaje.Mensaje = "No hay Pagos"
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Protected Function getEmpleado(_AD_PP As Dto_AD_PP_Order)
        _Empleado = New Empleado(_context)
        _Empleado.curp = _AD_PP.CURP
        _Empleado.nss = _AD_PP.SeguroSocial
        _Empleado.buscarPNSS()
        If _Empleado.idEmpleado < 1 Or _Empleado.idEmpleado = Nothing Then
            _Empleado.buscarCURP()
        End If
        If _Empleado.idEmpleado < 1 Or _Empleado.idEmpleado = Nothing Then
            Return False
        End If
        Return True
    End Function
    Protected Friend Function insertOrderLine(_AD_PP As Dto_AD_PP_Order)
        _Cuentadetalle = New CuentaDetalle(_context)
        _Cuentadetalle.idCuenta = _Cuenta.idCuenta

        Dim conceptoCuenta As ConceptoCuenta = New ConceptoCuenta(_context)
        conceptoCuenta.idEmpresa = _Empleado.idEmpresa

        If _AD_PP.CalculoTotalFinal < 0 Then
            conceptoCuenta.buscarPISucursal("DESCUENTO DESTAJO")
            _Cuentadetalle.idConceptoCuenta = conceptoCuenta.idConceptoCuenta
            _Cuentadetalle.monto = (_AD_PP.TotalesFinales * -1)
        Else
            conceptoCuenta.buscarPISucursal("PAGO A DESTAJO")
            _Cuentadetalle.idConceptoCuenta = conceptoCuenta.idConceptoCuenta
            _Cuentadetalle.monto = _AD_PP.TotalesFinales
        End If


        _Cuentadetalle.creadoPor = 3395
        _Cuentadetalle.actualizadoPor = 3395
        _Cuentadetalle.descripccion = "Documento Manufactura: " & _AD_PP.OrdenManoFactura
        If _Cuentadetalle.guardar() Then
            _AD_PP.Identificationmark = _Cuenta.noDocumento
            Dim _Dao_AD_PP_Orderloc As Dao_AD_PP_Order = New Dao_AD_PP_Order(_context, Me.conPgSQL)
            _Dao_AD_PP_Orderloc.Dto_AD_PP_Order = _AD_PP
            If _Dao_AD_PP_Orderloc.update_identificationmark() = False Then
                Mensaje.Mensaje = "Error update_identificationmark:" & _Dao_AD_PP_Orderloc.descripError
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.Mensaje = "Error _Cuentadetalle.guardar() " & _Cuentadetalle.descripError
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If
        Return False
    End Function


    Protected Friend Function insertOrder(_AD_PP As Dto_AD_PP_Order) As Boolean
        _Cuenta = New Cuenta(_context)
        'Dim _CuentaLoc = New Dao_cerb_Cuenta(_context)
        '_CuentaLoc.descripccion = _AD_PP.PP_Cost_Collector_id
        'If _CuentaLoc.buscarPDescLike() Or 1 = 1 Then
        '    addLine(" Ya se ha insertado el ID: " & _AD_PP.PP_Cost_Collector_id)
        '    _Empleado = Nothing
        '    Return False
        'Else

        If _AD_PP.CalculoTotalFinal < 0 Then
            _Cuenta.tipoCuenta = "CxC"
            _Cuenta.monto = (_AD_PP.CalculoTotalFinal * -1)
        Else
            _Cuenta.tipoCuenta = "CxP"
            _Cuenta.monto = _AD_PP.CalculoTotalFinal
        End If
        _Cuenta.idPeriodo = Nothing
        _Cuenta.idEmpresa = _Empleado.idEmpresa
        _Cuenta.idSucursal = _Empleado.idSucursal
        _Cuenta.idCocina = Nothing
        _Cuenta.idEmpleado = _Empleado.idEmpleado
        _Cuenta.noDocumento = Nothing
        _Cuenta.fechaCuenta = _AD_PP.FechaPago
        _Cuenta.creadoPor = 3395
        _Cuenta.estado = "BO" 'BO = Borrador,PA=Por Autorizar, CO = Completo, CA=Cancelado, PR = Procesada
        _Cuenta.descripccion = " Documento Pago Destajo AD:" & _AD_PP.PagoDestajo
        _Cuenta.esCuentaManual = Nothing
        _Cuenta.sistemaOrigen = "synchronizer_CXP_AD_CERB_Destajo"
        _Cuenta.esAutorizada = 0

        If _Cuenta.guardar() = False Then
            Mensaje.Mensaje = "Error al guardar la cuenta " & _Cuenta.descripError
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Return False
        Else
            Return True
        End If
        'End If
        Return False
    End Function

    Private Sub addLine(linea As String)
        Dim path As String = "C:\Users\" & Environment.UserName & "\.cerberus\Logs\"
        Dim LogFile As String = path & DateTime.Now.ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("hh") + ".log"
        If Dir(path, vbDirectory) = "" Then
            My.Computer.FileSystem.CreateDirectory(path)
        End If
        If Not File.Exists(LogFile) Then
            Dim fs As FileStream = File.Create(LogFile)
            fs.Close()
        End If
        Using outputFile As New StreamWriter(LogFile, True)
            outputFile.WriteLine(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss") + " - " + linea)
        End Using
    End Sub
End Class
