Public Class frmTelefonia
    Implements InterfaceVentanas

    Private objTelefonia As Telefonia
    Private objListTelefonia As New List(Of Telefonia)
    Private objSucursal As Sucursal

    Public Ambiente As AmbienteCls
    Public tipoCuenta As String
    Private objEmpleado As Empleado

    Private nuevoReg As Boolean = True
    Private montoTotal As Decimal
    Private busqueda As String

    Private ObjPlan As Plan
    Private ObjClasificacion As Clasificacion
    Private objCompañia As CompañiaTelefonia
    Private objEquipo As EquipoTelefonico

    Private ctaXperiodo As CuentaXPeriodo
    Private cuenta As Cuenta
    Private cuentaDetalle As CuentaDetalle

    Private Sub frmTelefonia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objTelefonia = New Telefonia(Ambiente)
        objTelefonia.idEmpresa = Ambiente.empr.idEmpresa
        objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, busqueda)
    End Sub



    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            objTelefonia = New Telefonia(Ambiente)
            objTelefonia.idEmpresa = Ambiente.empr.idEmpresa
            objTelefonia.estado = "BO"
            objTelefonia.tipoEquipo = ""
            objTelefonia.contable = False
            objTelefonia.fechaMovimiento = DateTime.Now.ToString("dd/MM/yyyy")
            txtTotalRED.Text = 0
            txtTotalEquipo.Text = 0
            txtTotalEquipo.Text = 0
            txtColor.Text = ""

        Else
            dtpFechaMov.Value = objTelefonia.creado
        End If

        ObjPlan = New Plan(Ambiente)
        ObjPlan.idPlan = objTelefonia.idPlan
        ObjPlan.buscarPID()
        txtIDPlan.Text = ObjPlan.idPlan
        txtNombrePlan.Text = ObjPlan.nombrePlan

        ObjClasificacion = New Clasificacion(Ambiente)
        ObjClasificacion.idClasificacion = objTelefonia.idClasificacion
        ObjClasificacion.buscarPID()
        txtIDClasificacion.Text = ObjClasificacion.idClasificacion
        txtNombreClasificacion.Text = ObjClasificacion.nombre

        objCompañia = New CompañiaTelefonia(Ambiente)
        objCompañia.idCompañia = objTelefonia.idCompañia
        objCompañia.buscarPID()
        txtIDcompañia.Text = objCompañia.idCompañia
        txtNombreCompañia.Text = objCompañia.nombre

        objEquipo = New EquipoTelefonico(Ambiente)
        objEquipo.idEquipoTelefonico = objTelefonia.idEquipoTelefonico
        objEquipo.buscarPID()
        txtIDEquipo.Text = objEquipo.idEquipoTelefonico
        txtNombreEquipo.Text = objEquipo.nombreEquipo


        txtDescrip.Text = objTelefonia.descripcion
        txtMontoPer.Text = objTelefonia.montoxperiodo
        txtNoPer.Text = objTelefonia.numPeriodos
        txtColor.Text = objTelefonia.color
        If objTelefonia.estado = "CO" Then
            txtEstado.Text = "COMPLETO"
        Else
            txtEstado.Text = "BORRADOR"
        End If
        txtNumDocumentoRed.Text = objTelefonia.noDocumentoRed
        txtNumDocEq.Text = objTelefonia.noDocumentoEquipo
        txtTotalRED.Text = objTelefonia.total
        txtTelefono.Text = objTelefonia.telefono
        dtpFechaMov.Value = objTelefonia.fechaMovimiento

        objEmpleado = New Empleado(Ambiente)
        objEmpleado.idEmpresa = Ambiente.empr.idEmpresa
        objEmpleado.idEmpleado = objTelefonia.idEmpleado
        objEmpleado.buscarPID()

        txtIDEmpleado.Text = objEmpleado.idEmpleado
        txtNombreEmpleado.Text = objEmpleado.nombreCompleto

        objSucursal = New Sucursal(Ambiente)
        objSucursal.idSucursal = objEmpleado.idSucursal
        objSucursal.buscarPID()
        txtIDSucursal.Text = objSucursal.idSucursal
        txtNameSucursal.Text = objSucursal.nombreSucursal

        txtIDEmpresa.Text = Ambiente.empr.idEmpresa
        txtNameEmpresa.Text = Ambiente.empr.nombreEmpresa


        If objTelefonia.tipoEquipo.Trim = "Personal" Then
            cbTipoEquipo.SelectedIndex = 0
        ElseIf objTelefonia.tipoEquipo.Trim = "Comodin" Then
            cbTipoEquipo.SelectedIndex = 1
        ElseIf objTelefonia.tipoEquipo.Trim = "Adicional" Then
            cbTipoEquipo.SelectedIndex = 2
        End If

        CBDesactivarCuentas.Checked = objTelefonia.contable

        calcularTotales()

    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos

        objTelefonia.idEmpresa = txtIDEmpresa.Text.Trim
        objTelefonia.idEmpleado = txtIDEmpleado.Text.Trim
        objTelefonia.idSucursal = txtIDSucursal.Text.Trim
        objTelefonia.idPlan = txtIDPlan.Text.Trim
        objTelefonia.idEquipoTelefonico = txtIDEquipo.Text.Trim
        objTelefonia.idClasificacion = txtIDClasificacion.Text.Trim
        objTelefonia.telefono = txtTelefono.Text.Trim
        objTelefonia.numPeriodos = txtNoPer.Text.Trim
        objTelefonia.total = txtTotalEquipo.Text.Trim
        objTelefonia.montoxperiodo = txtMontoPer.Text.Trim
        objTelefonia.descripcion = txtDescrip.Text.Trim
        objTelefonia.noDocumentoRed = txtNumDocumentoRed.Text.Trim
        objTelefonia.noDocumentoEquipo = txtNumDocEq.Text.Trim
        objTelefonia.idCompañia = txtIDcompañia.Text.Trim
        objTelefonia.fechaMovimiento = dtpFechaMov.Value
        objTelefonia.color = txtColor.Text.Trim

        objTelefonia.tipoEquipo = CType(cbTipoEquipo.SelectedItem, String).Trim
        objTelefonia.contable = CBDesactivarCuentas.Checked
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            objTelefonia = objListTelefonia.Item(indice)
            asignaDatos()
            Controles()
        End If
    End Sub
    Private Sub dgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTelefonia.CellDoubleClick
        nuevoReg = False
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub dgvCuentas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTelefonia.SelectionChanged
        If dgvTelefonia.SelectedRows.Count > 0 Then
            nuevoReg = False
            clicDatos(dgvTelefonia.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub
    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnRecargar.Enabled = False
            txtNumDocumentoRed.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnRecargar.Enabled = True
        End If
    End Sub

    Private Sub Controles()
        If objTelefonia.estado = "BO" Then
            dtpFechaMov.Enabled = True
            txtNumDocumentoRed.ReadOnly = False
            Button1.Enabled = True
            txtNoPer.ReadOnly = False
            txtMontoPer.ReadOnly = False
            txtDescrip.ReadOnly = False
        Else
            dtpFechaMov.Enabled = False
            txtNumDocumentoRed.ReadOnly = True
            Button1.Enabled = False
            txtNoPer.ReadOnly = True
            txtMontoPer.ReadOnly = True
            txtDescrip.ReadOnly = True
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        Controles()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub BORRADORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BORRADORToolStripMenuItem.Click
        If objTelefonia.estado = "BO" Then
            guardar("BO")
        Else
            Mensaje.Mensaje = "No se puede cambiar a estado ""BORRADOR"" cuando ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub COMPLETARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COMPLETARToolStripMenuItem.Click
        If objTelefonia.estado = "BO" Then
            If CBDesactivarCuentas.Checked Then
                guardar("CO")
            Else
                If Decimal.Parse(txtNoPer.Text) > 0 And Decimal.Parse(txtMontoPer.Text) > 0 Then
                    Dim validSave As Boolean = False

                    If objTelefonia.idPlan > 0 Then
                        If insertarCuentaXPerido() Then
                            objTelefonia.noDocumentoEquipo = "P/comodin"
                            objTelefonia.noDocumentoRed = "P/comodin"
                            validSave = True
                        Else
                            validSave = False
                        End If
                    End If

                    If objTelefonia.idEquipoTelefonico > 0 Then
                            If insertarCuenta() Then
                                objTelefonia.noDocumentoEquipo = "P/comodin"
                                objTelefonia.noDocumentoRed = "P/comodin"
                                validSave = True
                            Else
                                validSave = False
                            End If
                        End If

                        If validSave Then
                            guardar("CO")
                        Else
                            Mensaje.Mensaje = "No se puede Completar"
                            Mensaje.tipoMsj = TipoMensaje.Informacion
                            Mensaje.ShowDialog()
                            guardar("BO")
                        End If

                    Else
                        Mensaje.Mensaje = "No se puede Completar si el total es 0,No. periodos es 0 ó el Monto Por Periodo es 0"
                    Mensaje.tipoMsj = TipoMensaje.Informacion
                    Mensaje.ShowDialog()
                End If
            End If
        Else
            Mensaje.Mensaje = "No se puede cambiar el estado, cuando con anterioridad ha sido completada..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function insertarCuenta() As Boolean
        If Double.Parse(txtTotalEquipo.Text) < 1 Then
            Return False
        End If

        cuenta = New Cuenta(Ambiente)
        cuenta.tipoCuenta = "CxC"
        cuenta.monto = Double.Parse(txtTotalEquipo.Text)
        cuenta.idPeriodo = Nothing
        cuenta.idEmpresa = Integer.Parse(txtIDEmpresa.Text)
        cuenta.idSucursal = Integer.Parse(txtIDSucursal.Text)
        cuenta.idEmpleado = Integer.Parse(txtIDEmpleado.Text)
        cuenta.fechaCuenta = objTelefonia.fechaMovimiento
        cuenta.estado = "CO"
        cuenta.descripccion = "Cuenta Telefonia"
        cuenta.esCuentaManual = 0
        cuenta.sistemaOrigen = "Cerberus.frmTelefonia"
        cuenta.esAutorizada = 1
        If cuenta.guardar Then
            cuentaDetalle = New CuentaDetalle(Ambiente)
            cuentaDetalle.idCuenta = cuenta.idCuenta
            Dim concepto As ConceptoCuenta = New ConceptoCuenta(Ambiente)
            concepto.idEmpresa = objTelefonia.idEmpresa
            concepto.nombreConceptoCuenta = "DESCUENTO EQUIPO TELEFONICO"
            concepto.buscarPTipo()
            cuentaDetalle.idConceptoCuenta = concepto.idConceptoCuenta
            cuentaDetalle.monto = cuenta.monto
            cuentaDetalle.descripccion = cuenta.descripccion
            If cuentaDetalle.guardar() Then
                txtNumDocEq.Text = cuenta.noDocumento
            Else
                Return False
            End If
        Else
            Return False
        End If

        Return True
    End Function

    Private Function insertarCuentaXPerido() As Boolean
        If Double.Parse(txtTotalRED.Text) < 1 Then
            Return False
        End If

        ctaXperiodo = New CuentaXPeriodo(Ambiente)
        ctaXperiodo.tipoCuenta = "CxC"
        ctaXperiodo.monto = txtTotalRED.Text * txtNoPer.Text
        ctaXperiodo.idEmpresa = objTelefonia.idEmpresa
        ctaXperiodo.idSucursal = objTelefonia.idSucursal
        ctaXperiodo.idEmpleado = txtIDEmpleado.Text
        ctaXperiodo.fechaCuenta = dtpFechaMov.Value.Date
        ctaXperiodo.estado = "CO"
        ctaXperiodo.numeroPeriodos = txtNoPer.Text
        ctaXperiodo.montoXPeriodo = txtMontoPer.Text
        ctaXperiodo.descripccionCuenta = txtDescrip.Text
        ctaXperiodo.esActivo = True
        Dim concepto As ConceptoCuenta = New ConceptoCuenta(Ambiente)
        concepto.idEmpresa = objTelefonia.idEmpresa
        concepto.nombreConceptoCuenta = "RENTA RED CELULAR"
        concepto.buscarPTipo()
        ctaXperiodo.idConceptoCuenta = concepto.idConceptoCuenta
        If ctaXperiodo.guardar() Then
            txtNumDocumentoRed.Text = ctaXperiodo.noDocumento
            Return True
        Else
            Return False
        End If
    End Function

    Private Function guardar(estadoAct As String) As Boolean
        obtenerDatos()
        objTelefonia.estado = estadoAct
        objTelefonia.idEmpleado = txtIDEmpleado.Text

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If nuevoReg Then
            If Not objTelefonia.guardar() Then
                Mensaje.Mensaje = objTelefonia.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente"
                objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, busqueda)
                TabControl1.SelectTab(1)
                nuevoReg = False

            End If
        Else
            If Not objTelefonia.actualizar() Then
                Mensaje.Mensaje = objTelefonia.descripError
                busqueda = " AND ( noDocumentoRed = '" & objTelefonia.noDocumentoRed & "' OR noDocumentoEquipo = '" & objTelefonia.noDocumentoEquipo & "'"
                objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, busqueda)
                TabControl1.SelectTab(1)
            Else
                Mensaje.Mensaje = "Se actualizó correctamente"
            End If
        End If
        Mensaje.ShowDialog()
        objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, busqueda)
        TabControl1.SelectTab(0)
        Return True
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Registro?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If objTelefonia.eliminar() Then
                objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, busqueda)
                TabControl1.SelectTab(0)
            Else
                Mensaje.Mensaje = objTelefonia.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            objEmpleado = frmBuscaEmpleado.EmpleadoRetorno
            txtIDEmpleado.Text = objEmpleado.idEmpleado
            txtNombreEmpleado.Text = objEmpleado.nombreCompleto

            Dim objEmpresa As Empresa = New Empresa(Ambiente)
            objEmpresa.idEmpresa = objEmpleado.idEmpresa
            If objEmpresa.buscarPID() Then
                txtIDEmpresa.Text = objEmpresa.idEmpresa
                txtNameEmpresa.Text = objEmpresa.nombreEmpresa
            End If

            objSucursal = New Sucursal(Ambiente)
            objSucursal.idSucursal = objEmpleado.idSucursal
            objSucursal.idEmpresa = objEmpleado.idEmpresa
            If objSucursal.buscarPID() Then
                txtIDSucursal.Text = objSucursal.idSucursal
                txtNameSucursal.Text = objSucursal.nombreSucursal
            End If
        End If
    End Sub
    Private Function calcularTotales() As Boolean

        If ObjClasificacion.idClasificacion = 7 Then
            txtTotalRED.Text = 0
            txtTotalEquipo.Text = 0
        Else
            txtTotalRED.Text = ObjPlan.costoPlan - ObjClasificacion.porcentajeRed
            txtTotalEquipo.Text = objEquipo.costoEquipo - (objEquipo.costoEquipo * (ObjClasificacion.porcentajeEquipo / 100))
        End If


        Return True
    End Function

    Private Sub btnPlan_Click(sender As Object, e As EventArgs) Handles btnPlan.Click
        frmBuscaPlan.Ambiente = Ambiente
        frmBuscaPlan.idCompañia = txtIDcompañia.Text
        If frmBuscaPlan.ShowDialog() = DialogResult.OK Then
            ObjPlan = frmBuscaPlan.PlanRetorno
            txtIDPlan.Text = ObjPlan.idPlan
            txtNombrePlan.Text = ObjPlan.nombrePlan & " $" & ObjPlan.costoPlan

            calcularTotales()
        End If
    End Sub

    Private Sub bteCompañia_Click(sender As Object, e As EventArgs) Handles bteCompañia.Click
        frmBuscaCompañiaTelefonica.Ambiente = Ambiente
        If frmBuscaCompañiaTelefonica.ShowDialog() = DialogResult.OK Then
            objCompañia = frmBuscaCompañiaTelefonica.compañiaRetorno
            txtIDcompañia.Text = objCompañia.idCompañia
            txtNombreCompañia.Text = objCompañia.nombre
            txtIDPlan.Text = 0
            txtNombrePlan.Text = ""
            ObjPlan = New Plan(Ambiente)
            objEquipo = New EquipoTelefonico(Ambiente)
            txtNombreEquipo.Text = ""
            txtIDEquipo.Text = 0
            calcularTotales()
        End If
    End Sub

    Private Sub bteEquipo_Click(sender As Object, e As EventArgs) Handles bteEquipo.Click
        frmBuscaEquipoTelefonico.Ambiente = Ambiente
        frmBuscaEquipoTelefonico.idCompañiaFiltro = txtIDcompañia.Text
        If frmBuscaEquipoTelefonico.ShowDialog() = DialogResult.OK Then
            objEquipo = frmBuscaEquipoTelefonico.equipoTelefonicoRetorno
            txtIDEquipo.Text = objEquipo.idEquipoTelefonico
            txtNombreEquipo.Text = objEquipo.nombreEquipo & " $" & objEquipo.costoEquipo
            calcularTotales()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmBuscaClasificacion.Ambiente = Ambiente
        If frmBuscaClasificacion.ShowDialog() = DialogResult.OK Then

            ObjClasificacion = frmBuscaClasificacion.ClasificacionRetorno
            txtIDClasificacion.Text = ObjClasificacion.idClasificacion
            txtNombreClasificacion.Text = ObjClasificacion.nombre
            calcularTotales()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        objEquipo = New EquipoTelefonico(Ambiente)
        txtIDEquipo.Text = 0
        txtNombreEquipo.Text = ""
        objTelefonia.idEquipoTelefonico = Nothing
        calcularTotales()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ObjPlan = New Plan(Ambiente)
        txtIDPlan.Text = 0
        txtNombrePlan.Text = ""
        objCompañia = New CompañiaTelefonia(Ambiente)
        txtNombreCompañia.Text = ""
        txtIDcompañia.Text = 0
        objTelefonia.idPlan = Nothing
        objTelefonia.idCompañia = Nothing
        calcularTotales()
    End Sub

    Private Sub txtNoPer_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNoPer.KeyUp
        If Not IsNumeric(txtTotalRED.Text) Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Para hacer el cálculo por periodos, es necesario ingresar el monto total"
            Mensaje.ShowDialog()
        Else
            If IsNumeric(txtNoPer.Text) Then
                If txtNoPer.Text > 0 Then
                    txtMontoPer.Text = Format(Decimal.Parse(txtTotalRED.Text), "0.00")
                Else
                    txtMontoPer.Text = 0.00
                End If
            End If
        End If
    End Sub
    Private rptDatos As Reporte
    Private dsDatos As DataSet

    'Telefonia Proveedor 
    Private Sub creaRPTTelefonia()
        rptDatos = New Reporte(Ambiente, "Telefonia", "solicitudXtelefonia")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub
    Private Sub TelefoniaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TelefoniaToolStripMenuItem.Click
        creaRPTTelefonia()
        rptDatos.imprimir(dsDatos)
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        creaRPTTelefonia()
        rptDatos.modificar(dsDatos)
    End Sub
    'Telfonia Proveedor


    'Telfonia Conformidad
    Private Sub ConformdidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConformdidadToolStripMenuItem.Click
        creaRPTTelefoniaConformidad()
        rptDatos.imprimir(dsDatos)
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        creaRPTTelefoniaConformidad()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaRPTTelefoniaConformidad()
        rptDatos = New Reporte(Ambiente, "Telefonia", "TelefoniaConformidad")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("idTelefonia", objTelefonia.idTelefonia)
    End Sub
    'Telfonia Conformidad



    'Telfonia Entrega  
    Private Sub creaRPTTelefoniaEntrega()
        rptDatos = New Reporte(Ambiente, "Telefonia", "TelefoniaEntrega")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
        rptDatos.agregaVarible("idTelefonia", objTelefonia.idTelefonia)
    End Sub
    Private Sub ModificarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem2.Click
        creaRPTTelefoniaEntrega()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub EntregaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaToolStripMenuItem.Click
        creaRPTTelefoniaEntrega()
        rptDatos.imprimir(dsDatos)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        objTelefonia.cargaGridCom(dgvTelefonia, objListTelefonia, txtFiltro.Text.ToString)
    End Sub

End Class