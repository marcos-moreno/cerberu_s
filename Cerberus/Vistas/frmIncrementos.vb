Imports Cerberus

Public Class frmIncrementos
    Implements InterfaceVentanas

    Private nuevoReg As Boolean
    Private nuevoReg2 As Boolean

    Private objCbEmpr As New List(Of Empresa)
    Public Ambiente As AmbienteCls
    Public incremento As Incremento
    Private objDGIncremento As New List(Of Incremento)

    Private per As Periodo
    Private objPer As New List(Of Periodo)

    Private objCbSuc As New List(Of Sucursal)
    Private empleado As Empleado

    Private objDepartamento As Departamento
    Private objCbDepartamento As New List(Of Departamento)

    Private objTabulador As Tabulador
    Private objCbTabuladorAct As New List(Of Tabulador)
    Private objCbTabuladorAplica As New List(Of Tabulador)


    Private objPuesto As Puesto
    Private objCBPuesto As New List(Of Puesto)

    Private obglDetalleIncremento As New List(Of IncrementoDetalle)
    Private detalleIncremento As IncrementoDetalle

    Private objSueldoIMSS As SueldosIMSS
    Private objCBSueldoIMSSFinal As New List(Of SueldosIMSS)
    Private objCBSueldoIMSSAct As New List(Of SueldosIMSS)

    Private Sub frmIncrementos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        detalleIncremento = New IncrementoDetalle(Ambiente)

        objDepartamento = New Departamento(Ambiente)
        objDepartamento.idEmpresa = Ambiente.empr.idEmpresa
        objDepartamento.getComboActivo(cbDepartamento, objCbDepartamento)

        objPuesto = New Puesto(Ambiente)
        objPuesto.idEmpresa = Ambiente.empr.idEmpresa
        objPuesto.getCombo(cbPuesto, objCBPuesto)

        per = New Periodo(Ambiente)
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.elementoSistema = "ES"
        per.tabla = "Registro"
        per.ejercicio = Now.Year
        per.getComboTodos(cbPeriodoInicia, objPer)
        per.getComboTodos(cbPeriodoAplica, objPer)

        empleado = New Empleado(Ambiente)

        incremento = New Incremento(Ambiente)
        incremento.idEmpresa = Ambiente.empr.idEmpresa
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)
        gridGeneral()

    End Sub

    Private Sub gridGeneral()
        incremento.cargaGridFiltrado(dgvIncremento, objDGIncremento)
    End Sub

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        If nuevoReg Then
            'MG lo acabo de agregar 
            incremento = New Incremento(Ambiente)
            incremento.estado = "BO"
            'MG lo acabo de agregar 

            cbPeriodoAplica.SelectedIndex = -1
            cbPeriodoInicia.SelectedIndex = -1
            rtbObservacion.Text = ""
            TabControl2.Enabled = False
        Else

            TabControl2.Enabled = True
            For nInc As Integer = 0 To objPer.Count - 1
                If objPer.Item(nInc).idPeriodo = incremento.idPeriodoAplica Then
                    cbPeriodoAplica.SelectedIndex = nInc
                End If
            Next
            For nInc As Integer = 0 To objPer.Count - 1
                If objPer.Item(nInc).idPeriodo = incremento.idPeriodoInicia Then
                    cbPeriodoInicia.SelectedIndex = nInc
                End If
            Next
            rtbObservacion.Text = incremento.observaciones
            detalleIncremento.cargaGridFiltrado(dgvDetalleIncremento, obglDetalleIncremento, incremento.id_incremento, txtFiltro.Text)
        End If
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos
        If cbPeriodoAplica.SelectedIndex <> -1 Then
            incremento.idPeriodoAplica = objPer.Item(cbPeriodoAplica.SelectedIndex).idPeriodo
        Else
            incremento.idPeriodoAplica = Nothing
        End If

        If cbPeriodoInicia.SelectedIndex <> -1 Then
            incremento.idPeriodoInicia = objPer.Item(cbPeriodoInicia.SelectedIndex).idPeriodo
        Else
            incremento.idPeriodoInicia = Nothing
        End If

        incremento.observaciones = rtbObservacion.Text
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        End If
        'Validación del estado del incremento
        If incremento.estado = "CO" Then
            rtbObservacion.ReadOnly = True
            cbPeriodoInicia.Enabled = False
            cbPeriodoAplica.Enabled = False
            'Detalle de incremento
            btnNuevo2.Enabled = False
            btnGuardar2.Enabled = False
            btnEliminar2.Enabled = False
            Button1.Enabled = False
            txtFiltro.ReadOnly = True
            'Selección
            txtIDEmpleado.ReadOnly = True
            txtNombreEmpleado.ReadOnly = True
            bteEmpleado.Enabled = False
            cbSucursal.Enabled = False
            cbDepartamento.Enabled = False
            txtLider.ReadOnly = True
            cbPuesto.Enabled = False
            txtAltaDireccion.ReadOnly = True
            dtpIngreso.Enabled = False
            txtObservaciones.ReadOnly = True
            cbSueldoIMSSAct.Enabled = False
            cbTabuladorActual.Enabled = False
            cbTabuladorPropuesta.Enabled = False
            cbTabuladorAD.Enabled = False
            cbSueldoIMSSFinal.Enabled = False
            txtSD.ReadOnly = True
            txtImpTrab.ReadOnly = True
            txtImpPatron.ReadOnly = True
            txtNetoPagar.ReadOnly = True
            txtExcedente.ReadOnly = True

        ElseIf incremento.estado = "BO" Then
            rtbObservacion.ReadOnly = False
            cbPeriodoInicia.Enabled = True
            cbPeriodoAplica.Enabled = True
            'Detalle de incremento
            btnNuevo2.Enabled = True
            btnGuardar2.Enabled = True
            btnEliminar2.Enabled = True
            Button1.Enabled = True
            txtFiltro.ReadOnly = False
            'Selección
            txtIDEmpleado.ReadOnly = False
            txtNombreEmpleado.ReadOnly = False
            bteEmpleado.Enabled = True
            cbSucursal.Enabled = True
            cbDepartamento.Enabled = True
            txtLider.ReadOnly = False
            cbPuesto.Enabled = True
            txtAltaDireccion.ReadOnly = False
            dtpIngreso.Enabled = True
            txtObservaciones.ReadOnly = False
            cbSueldoIMSSAct.Enabled = True
            cbTabuladorActual.Enabled = True
            cbTabuladorPropuesta.Enabled = True
            cbTabuladorAD.Enabled = True
            cbSueldoIMSSFinal.Enabled = True
            txtSD.ReadOnly = False
            txtImpTrab.ReadOnly = False
            txtImpPatron.ReadOnly = False
            txtNetoPagar.ReadOnly = False
            txtExcedente.ReadOnly = False

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        nuevoReg2 = True
        asignaDatos()
        asignaDatos2()
        TabControl1.SelectTab(1)
        habilitarBotones()
        habilitarBotones2()
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos()

        If nuevoReg Then
            If Not incremento.guardar() Then
                Mensaje.Mensaje = incremento.descripError
            Else
                Mensaje.Mensaje = "Registro Guardado con Exíto"
            End If
        Else
            If Not incremento.actualizar() Then
                Mensaje.Mensaje = incremento.descripError
            Else
                Mensaje.Mensaje = "Registro actualizó con Exíto"
            End If
        End If
        Mensaje.ShowDialog()

        nuevoReg = False
        gridGeneral()
        TabControl1.SelectTab(0)
    End Sub


    Private Sub dgvIncrementoDetalle_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalleIncremento.SelectionChanged
        If dgvDetalleIncremento.SelectedRows.Count > 0 Then
            'Mg IF lo acabo de agregar 
            If nuevoReg = False Then
                clicDatos2(dgvDetalleIncremento.SelectedRows(0).Index)
            End If
            'Mg lo acabo de agregar 

            'habilitarBotones2()
        End If
    End Sub

    Private Sub dgvIncrementoDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleIncremento.CellDoubleClick
        clicDatos2(e.RowIndex)
        'habilitarBotones2()
        TabControl2.SelectTab(1)
        ' habilitarBotones2()
    End Sub



    Private Sub dgvIncremento_SelectionChanged(sender As Object, e As EventArgs) Handles dgvIncremento.SelectionChanged
        If dgvIncremento.SelectedRows.Count > 0 Then
            clicDatos(dgvIncremento.SelectedRows(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub dgvIncremento_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncremento.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
        habilitarBotones()
    End Sub


    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If dgvIncremento.SelectedRows.Item(0).Index <> dgvIncremento.Rows.Count - 1 Then
            dgvIncremento.Rows(dgvIncremento.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If dgvIncremento.SelectedRows.Item(0).Index <> 0 Then
            dgvIncremento.Rows(dgvIncremento.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        incremento.cargaGridFiltrado(dgvIncremento, objDGIncremento)
        TabControl1.SelectTab(0)
    End Sub


    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "incremento"
        frmComentario.idTabla = incremento.id_incremento
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Incremento: " & incremento.id_incremento & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            If incremento.eliminar() Then
                gridGeneral()
                TabControl1.SelectTab(0)
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "El registro se Elimino exitosamente..."
                nuevoReg = False
                nuevoReg2 = False
                asignaDatos2()
            Else
                Mensaje.Mensaje = incremento.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
            End If
            Mensaje.ShowDialog()
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bteEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = False
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            empleado = frmBuscaEmpleado.EmpleadoRetorno
            asignaDatosEmpleado()
            'MsgBox("Id Puesto : " & empleado.idPuesto & "  Id Departamento : " & empleado.idDepartamento & "  Id Sucursal : " & empleado.idSucursal & "  Id fechaAlta : " & empleado.fechaAlta & "  Id idTabulador : " & empleado.idTabulador)
        End If
    End Sub

    Private Sub btnNuevo2_Click(sender As Object, e As EventArgs) Handles btnNuevo2.Click
        clicBtnNuevo()
    End Sub

    Private Sub clicBtnNuevo()
        nuevoReg2 = True
        asignaDatos2()
        habilitarBotones2()
        TabControl2.SelectTab(1)
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        If indice <> -1 Then
            nuevoReg = False
            incremento = objDGIncremento.Item(indice)
            asignaDatos()
            nuevoReg2 = False
            habilitarBotones2()
        End If
    End Sub

    Public Sub clicDatos2(indice As Integer)
        If indice <> -1 Then
            nuevoReg2 = False
            detalleIncremento = obglDetalleIncremento.Item(indice)
            asignaDatos2()
            nuevoReg = False
            habilitarBotones2()
        End If
    End Sub

    Public Sub habilitarBotones2()
        If nuevoReg Then
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
            btnGuardar2.Enabled = False
            bteEmpleado.Enabled = False
        Else
            If nuevoReg2 Then
                btnNuevo2.Enabled = False
                btnEliminar2.Enabled = False
                btnGuardar2.Enabled = True
                bteEmpleado.Enabled = True
            ElseIf nuevoReg Then
                btnNuevo2.Enabled = True
                btnEliminar2.Enabled = True
                bteEmpleado.Enabled = False
            End If
        End If

        If incremento.estado = "CO" Then
            btnNuevo2.Enabled = False
            btnEliminar2.Enabled = False
        ElseIf incremento.estado = "BO" Then
            btnNuevo2.Enabled = True
            btnEliminar2.Enabled = True
        End If
    End Sub



    Public Function asignaDatosEmpleado()
        Try
            txtIDEmpleado.Text = empleado.idEmpleado
            txtNombreEmpleado.Text = empleado.nombreCompleto
            dtpIngreso.Value = empleado.fechaAlta
            For nInc As Integer = 0 To objCbSuc.Count - 1
                If objCbSuc.Item(nInc).idSucursal = empleado.idSucursal Then
                    cbSucursal.SelectedIndex = nInc
                End If
            Next

            For nInc As Integer = 0 To objCbDepartamento.Count - 1
                If objCbDepartamento.Item(nInc).idDepartamento = empleado.idDepartamento Then
                    cbDepartamento.SelectedIndex = nInc
                End If
            Next

            For nInc As Integer = 0 To objCBPuesto.Count - 1
                If objCBPuesto.Item(nInc).idPuesto = empleado.idPuesto Then
                    cbPuesto.SelectedIndex = nInc
                End If
            Next

            For nInc As Integer = 0 To objCBPuesto.Count - 1
                If objCbTabuladorAct.Item(nInc).idTabulador = empleado.idTabulador Then
                    cbTabuladorActual.SelectedIndex = nInc
                End If
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Sub asignaDatos2()
        If nuevoReg2 Then
            detalleIncremento = New IncrementoDetalle(Ambiente)
            txtIDEmpleado.Text = ""
            txtNombreEmpleado.Text = ""
            cbDepartamento.SelectedIndex = -1
            txtLider.Text = ""
            dtpIngreso.Value = Now
            cbTabuladorAD.SelectedIndex = -1
            cbSucursal.SelectedIndex = -1
            cbPuesto.SelectedIndex = -1
            txtAltaDireccion.Text = ""
            cbTabuladorActual.SelectedIndex = -1
            cbTabuladorPropuesta.SelectedIndex = -1
            txtObservaciones.Text = ""
            txtSD.Text = ""
            txtImpTrab.Text = ""
            txtImpPatron.Text = ""
            txtNetoPagar.Text = ""
        Else
            Try
                objTabulador = New Tabulador(Ambiente)
                objTabulador.idEmpresa = Ambiente.empr.idEmpresa
                If cbPeriodoInicia.SelectedIndex > -1 Then
                    objTabulador.getComboActivoFecha(cbTabuladorActual, objCbTabuladorAct, objPer(cbPeriodoInicia.SelectedIndex).inicioPeriodo)
                    objTabulador.getComboActivoFecha(cbTabuladorPropuesta, objCbTabuladorAplica, objPer(cbPeriodoAplica.SelectedIndex).inicioPeriodo)
                    objTabulador.getComboActivoFecha(cbTabuladorAD, objCbTabuladorAplica, objPer(cbPeriodoAplica.SelectedIndex).inicioPeriodo)

                End If
                empleado.idEmpleado = detalleIncremento.idEmpleado
                empleado.buscarPID()

                txtObservaciones.Text = detalleIncremento.observaciones

                objSueldoIMSS = New SueldosIMSS(Ambiente)
                objSueldoIMSS.idSueldoIMSS = detalleIncremento.idSuledoIMSSActual
                objSueldoIMSS.buscarPID()

                objSueldoIMSS.sueldoActualImms(cbSueldoIMSSAct, objCBSueldoIMSSAct)

                cbSueldoIMSSAct.SelectedIndex = -1

                For nInc As Integer = 0 To objCBSueldoIMSSAct.Count - 1

                    If objCBSueldoIMSSAct.Item(nInc).idSueldoIMSS = detalleIncremento.idSuledoIMSSActual Then
                        cbSueldoIMSSAct.SelectedIndex = nInc
                    End If
                Next

                For nInc As Integer = 0 To objCbTabuladorAplica.Count - 1
                    If objCbTabuladorAplica.Item(nInc).idTabulador = detalleIncremento.idTabuladorAD Then
                        cbTabuladorAD.SelectedIndex = nInc
                    End If
                Next

                If cbTabuladorAD.SelectedIndex <> -1 Then
                    objTabulador.idTabulador = objCbTabuladorAplica(cbTabuladorAD.SelectedIndex).idTabulador
                Else
                    objTabulador.idTabulador = 0
                End If

                objTabulador.buscarPID()

                'objSueldoIMSS.sueldoFinalImms(objCBSueldoIMSSAct(cbSueldoIMSSAct.SelectedIndex).sueldoSemanal, objTabulador.getVersionActualXFecha(objPer(cbPeriodoAplica.SelectedIndex).inicioPeriodo).sueldo, objCBSueldoIMSSFinal, cbSueldoIMSSFinal)

                txtIDEmpleado.Text = empleado.idEmpleado
                txtNombreEmpleado.Text = empleado.nombreCompleto

                For nInc As Integer = 0 To objCbDepartamento.Count - 1
                    If objCbDepartamento.Item(nInc).idDepartamento = detalleIncremento.idDepartamento Then
                        cbDepartamento.SelectedIndex = nInc
                    End If
                Next

                dtpIngreso.Value = detalleIncremento.fechaIgreso

                For nInc As Integer = 0 To objCbTabuladorAct.Count - 1
                    If objCbTabuladorAct.Item(nInc).idTabulador = detalleIncremento.idTabuladorActual Then
                        cbTabuladorActual.SelectedIndex = nInc
                    End If
                Next

                For nInc As Integer = 0 To objCbTabuladorAplica.Count - 1
                    If objCbTabuladorAplica.Item(nInc).idTabulador = detalleIncremento.idTabuladorPropuesta Then
                        cbTabuladorPropuesta.SelectedIndex = nInc
                    End If
                Next

                For nInc As Integer = 0 To objCbSuc.Count - 1
                    If objCbSuc.Item(nInc).idSucursal = detalleIncremento.idSucursal Then
                        cbSucursal.SelectedIndex = nInc
                    End If
                Next

                For nInc As Integer = 0 To objCBPuesto.Count - 1
                    If objCBPuesto.Item(nInc).idPuesto = detalleIncremento.idPuesto Then
                        cbPuesto.SelectedIndex = nInc
                    End If
                Next

                For nInc As Integer = 0 To objCBSueldoIMSSFinal.Count - 1
                    If objCBSueldoIMSSFinal.Item(nInc).idSueldoIMSS = detalleIncremento.idSueldoIMSSFinal Then
                        cbSueldoIMSSFinal.SelectedIndex = nInc
                    End If
                Next
            Catch ex As Exception
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Existe un Error:" & ex.Message
                Mensaje.ShowDialog()
            End Try
        End If

    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        obtenerDatos2()
        If nuevoReg2 Then
            detalleIncremento = New IncrementoDetalle(Ambiente)

            detalleIncremento.creadoPor = Ambiente.usuario.idEmpleado
            detalleIncremento.actualizadoPor = Ambiente.usuario.idEmpleado
            If Not detalleIncremento.guardar() Then
                Mensaje.Mensaje = detalleIncremento.descripError
            Else
                Mensaje.Mensaje = "Registro Guardado con Exíto"
            End If
        Else
            detalleIncremento.actualizadoPor = Ambiente.usuario.idEmpleado
            If Not detalleIncremento.actualizar() Then
                Mensaje.Mensaje = detalleIncremento.descripError
            Else
                Mensaje.Mensaje = "Registro actualizó con Exíto"
            End If
        End If
        nuevoReg2 = False

        Mensaje.ShowDialog()
    End Sub


    Public Sub obtenerDatos2()
        detalleIncremento.idTabuladorActual = objCbTabuladorAct(cbTabuladorActual.SelectedIndex).idTabulador
        detalleIncremento.idSuledoIMSSActual = objCBSueldoIMSSAct(cbSueldoIMSSAct.SelectedIndex).idSueldoIMSS
        detalleIncremento.idTabuladorPropuesta = objCbTabuladorAplica(cbTabuladorPropuesta.SelectedIndex).idTabulador
        detalleIncremento.idTabuladorAD = objCbTabuladorAplica(cbTabuladorAD.SelectedIndex).idTabulador
        detalleIncremento.idSueldoIMSSFinal = objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).idSueldoIMSS
        detalleIncremento.observaciones = txtObservaciones.Text
    End Sub

    Private Sub cbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamento.SelectedIndexChanged
        If cbDepartamento.SelectedIndex <> -1 Then
            txtLider.Text = objCbDepartamento.Item(cbDepartamento.SelectedIndex).nombreLider
            txtAltaDireccion.Text = objCbDepartamento.Item(cbDepartamento.SelectedIndex).altaDireccion
        End If

    End Sub

    Private Sub cbSueldoIMSSFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSueldoIMSSFinal.SelectedIndexChanged
        If cbSueldoIMSSFinal.SelectedIndex <> -1 Then
            txtSD.Text = FormatCurrency(objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).sueldoDiario)
            txtImpTrab.Text = FormatCurrency(objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).ImpuestoTrabajador)
            txtImpPatron.Text = FormatCurrency(objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).impuestroPatron)
            txtNetoPagar.Text = FormatCurrency(objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).netoAPagar)
            txtExcedente.Text = FormatCurrency(objCbTabuladorAplica(cbTabuladorAD.SelectedIndex).getVersionActual.sueldo - objCBSueldoIMSSFinal(cbSueldoIMSSFinal.SelectedIndex).sueldoSemanal)
        End If
    End Sub

    Private Sub cbTabuladorAD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTabuladorAD.SelectedIndexChanged
        If cbTabuladorAD.SelectedIndex <> -1 Then
            objTabulador.idTabulador = objCbTabuladorAplica(cbTabuladorAD.SelectedIndex).idTabulador
            objTabulador.buscarPID()

            objSueldoIMSS.sueldoFinalImms(objCBSueldoIMSSAct(cbSueldoIMSSAct.SelectedIndex).sueldoSemanal, objTabulador.getVersionActualXFecha(objPer(cbPeriodoAplica.SelectedIndex).inicioPeriodo).sueldo, objCBSueldoIMSSFinal, cbSueldoIMSSFinal, If(empleado.perfilCalculo = "Destajista", True, False))

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        detalleIncremento.cargaGridFiltrado(dgvDetalleIncremento, obglDetalleIncremento, incremento.id_incremento, txtFiltro.Text)
    End Sub

    Private Sub btnRPTEscalafonesMod_Click(sender As Object, e As EventArgs) Handles btnRPTEscalafonesMod.Click
        incremento.RPT_ModificarEscalafones()
    End Sub

    Private Sub btnRPTEscalafones_Click(sender As Object, e As EventArgs) Handles btnRPTEscalafones.Click
        incremento.RPT_ImprimirEscalafones()
    End Sub

    Private Sub btnRPTNegociacion_Click(sender As Object, e As EventArgs) Handles btnRPTNegociacion.Click
        detalleIncremento.RPT_ImprimirNegociacion(objPer(cbPeriodoInicia.SelectedIndex).inicioPeriodo)
    End Sub

    Private Sub btnRPTNegociacionMod_Click(sender As Object, e As EventArgs) Handles btnRPTNegociacionMod.Click
        detalleIncremento.RPT_ModificarNegociacion(objPer(cbPeriodoInicia.SelectedIndex).inicioPeriodo)
    End Sub

    Private Sub btnRPTIMSS_Click(sender As Object, e As EventArgs) Handles btnRPTIMSS.Click
        incremento.RPT_ImprimirAjusteIMSS()
    End Sub

    Private Sub btnRPTIMSSMod_Click(sender As Object, e As EventArgs) Handles btnRPTIMSSMod.Click
        incremento.RPT_ModificarAjusteIMSS()
    End Sub

    Private Sub btnRPTPorcentajes_Click(sender As Object, e As EventArgs) Handles btnRPTPorcentajes.Click
        incremento.RPT_ImprimirPorcentajes()
    End Sub

    Private Sub btnRPTPorcentajesMod_Click(sender As Object, e As EventArgs) Handles btnRPTPorcentajesMod.Click
        incremento.RPT_ModificarPorcentajes()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If incremento.estado.Equals("CO") Then
            Mensaje.Mensaje = "EL INCREMENTO YA ESTA CERRADO"
        Else
            If Not incremento.procesarIncremento() Then
                Mensaje.Mensaje = incremento.descripError
            Else
                Mensaje.Mensaje = "Registro actualizado con éxito"
                incremento.cargaGridFiltrado(dgvIncremento, objDGIncremento)
                TabControl1.SelectTab(0)
            End If
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub MSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MSToolStripMenuItem.Click
        incremento.RPT_ImprimirMs()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        incremento.RPT_ModificarMs()
    End Sub
End Class