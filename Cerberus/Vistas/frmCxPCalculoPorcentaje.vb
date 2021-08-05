Public Class frmCxPCalculoPorcentaje

    Private _context As AmbienteCls
    Private _empleado As Empleado
    Private _cuenta As Cuenta
    Private _tabuladorVersion As TabuladorVersion
    Private _Cuentadetalle As CuentaDetalle
    Private Sub frmCxPCalculoPorcentaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _empleado = New Empleado(Context)
    End Sub
    Public Property Context As AmbienteCls
        Get
            Return _context
        End Get
        Set(value As AmbienteCls)
            _context = value
        End Set
    End Property

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If _empleado.idEmpleado > 0 Then
            If dtpFechaMov.Value <> Nothing Then
                Dim porcentaje As Integer = 0
                Try
                    porcentaje = Convert.ToInt32(txtPorcentaje.Text)
                Catch ex As Exception
                    Mensaje.Mensaje = "Ingresa un porcentaje valido."
                    Mensaje.ShowDialog()
                    Return
                End Try
                If porcentaje > 0 And porcentaje < 101 Then
                    insertOrder((_tabuladorVersion.sueldo * (porcentaje / 100)), dtpFechaMov.Value)
                    _empleado = New Empleado(_context)
                    txtIDEmpleado.Text = ""
                    txtPorcentaje.Text = 0
                    txtNombreEmpleado.Text = ""
                    lblMontoFinal.Text = ""
                    lblSueldo.Text = "No Calculado"
                Else
                    Mensaje.Mensaje = "Ingresa un porcentaje valido."
                    Mensaje.ShowDialog()
                End If
            Else
                Mensaje.Mensaje = "Selecciona una Fecha para La cuenta."
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.Mensaje = "Selecciona un Empleado."
            Mensaje.ShowDialog()
        End If

    End Sub

    Private Function insertOrder(monto As Decimal, fechaCuenta As Date) As Boolean
        _cuenta = New Cuenta(Context)
        _cuenta.tipoCuenta = "CxP"
        _cuenta.monto = monto
        _cuenta.idPeriodo = Nothing
        _cuenta.idEmpresa = Context.empr.[idEmpresa]
        _cuenta.idSucursal = _empleado.idSucursal
        _cuenta.idCocina = Nothing
        _cuenta.idEmpleado = _empleado.idEmpleado
        _cuenta.noDocumento = Nothing
        _cuenta.fechaCuenta = fechaCuenta
        _cuenta.creadoPor = _context.usuario.idEmpleado
        _cuenta.estado = "CO" 'BO = Borrador,PA=Por Autorizar, CO = Completo, CA=Cancelado, PR = Procesada
        _cuenta.descripccion = "Pago Sueldo con porcentaje de: " & txtPorcentaje.Text & "%"
        _cuenta.esCuentaManual = Nothing
        _cuenta.sistemaOrigen = "CxPCalculoPorcentaje"
        _cuenta.esAutorizada = 1
        If _cuenta.guardar() = False Then
            Mensaje.Mensaje = "Error al guardar la cuenta " & _cuenta.descripError
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Return False
        Else
            insertOrderLine()
            Return True
        End If
        'End If
        Return False
    End Function

    Protected Friend Function insertOrderLine()
        _Cuentadetalle = New CuentaDetalle(_context)
        _Cuentadetalle.idCuenta = _cuenta.idCuenta
        Dim conceptoCuenta As ConceptoCuenta = New ConceptoCuenta(_context)
        conceptoCuenta.idEmpresa = _empleado.idEmpresa
        conceptoCuenta.buscarPISucursal("PAGO DE SUELDO POR PORCENTAJE")
        _Cuentadetalle.monto = _cuenta.monto
        _Cuentadetalle.idConceptoCuenta = conceptoCuenta.idConceptoCuenta
        _Cuentadetalle.creadoPor = _context.usuario.idEmpleado
        _Cuentadetalle.actualizadoPor = _context.usuario.idEmpleado
        _Cuentadetalle.descripccion = "Pago Sueldo con pocentaje de: " & txtPorcentaje.Text
        If _Cuentadetalle.guardar() Then
            Mensaje.Mensaje = "Cuenta creada con Exito, No. Documento: " & _cuenta.noDocumento
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        Else
            _cuenta.eliminar()
            Mensaje.Mensaje = "Error _Cuentadetalle.guardar() " & _Cuentadetalle.descripError
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If
        Return False
    End Function

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Context
        frmBuscaEmpleado.soloActivos = False
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIDEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreEmpleado.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
            _empleado = frmBuscaEmpleado.EmpleadoRetorno
            _tabuladorVersion = New TabuladorVersion(_context)
            _tabuladorVersion.idTabulador = _empleado.idTabulador
            Dim thisDate As Date
            thisDate = Today
            _tabuladorVersion.buscarActualXFecha(thisDate)
            lblSueldo.Text = "$" & Format(_tabuladorVersion.sueldo, "##,##0.00")
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se pueden ingresar valores de tipo numérico", MsgBoxStyle.Critical, "Ingreso de Número")
        End If
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As Object, e As EventArgs) Handles txtPorcentaje.TextChanged
        Dim porcentaje As Integer = 0
        Try
            porcentaje = Convert.ToInt32(txtPorcentaje.Text)
        Catch ex As Exception
            lblMontoFinal.Text = "% No valido."
        End Try
        If porcentaje > 0 And porcentaje < 101 Then
            lblMontoFinal.Text = "$" & Format((_tabuladorVersion.sueldo * (porcentaje / 100)), "##,##0.00")
        Else
            lblMontoFinal.Text = "% No valido."
        End If
    End Sub
End Class