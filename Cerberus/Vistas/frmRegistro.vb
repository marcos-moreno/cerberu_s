Public Class frmRegistro
    Public Ambiente As AmbienteCls
    Private reg As Registro
    Private disp As Dispositivo
    Private perido As Periodo
    Private objEmp As Empleado
    Private objDep As Departamento
    Private objCBDep As New List(Of Departamento)
    Private objDGEmpl As New List(Of Empleado)
    Private objRegManuales As New List(Of Registro)
    Private objCBDis As New List(Of Dispositivo)
    Private rangoPerido As List(Of Date)
    Private cargado As Boolean

    Private indicedEmpleadoSeleccionado As Integer
    Private indicePeriodo As Integer

    Public elementoSistemas As String

    Private objDia1 As New List(Of Registro)
    Private objDia2 As New List(Of Registro)
    Private objDia3 As New List(Of Registro)
    Private objDia4 As New List(Of Registro)
    Private objDia5 As New List(Of Registro)
    Private objDia6 As New List(Of Registro)
    Private objDia7 As New List(Of Registro)

    Private emplAct As Integer
    Private cambios As New List(Of Registro)

    Private objCbPerido As New List(Of Periodo)

    Private tInci As TipoIncidencia
    Private objInciXDia As New List(Of Incidencia)
    Private objInciXDiaCalculada As New List(Of Incidencia)
    Private objCBTIncidencia As New List(Of TipoIncidencia)
    Private objCBTIncidenciaCalculada As New List(Of TipoIncidencia)

    Private horasExtras As ControlHorasExtras
    Private objVisita As VisitaSucursal

    Dim dtLimpio As New DataSet()


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmpleado.SelectionChanged
        asigaXDG()
    End Sub

    Private Sub asigaXDG()
        lblSeleccion2.Text = "Nada - Seleccionado"

        If dgvEmpleado.SelectedRows.Count > 0 Then
            indicedEmpleadoSeleccionado = dgvEmpleado.SelectedRows.Item(0).Cells(0).Value
            asignarDatos(cbPeriodo.SelectedIndex)
            enableBteHrsExtra()
        Else
            indicedEmpleadoSeleccionado = -1

            dgR1.DataSource = dtLimpio
            dgR2.DataSource = dtLimpio
            dgR3.DataSource = dtLimpio
            dgR4.DataSource = dtLimpio
            dgR5.DataSource = dtLimpio
            dgR6.DataSource = dtLimpio
            dgR7.DataSource = dtLimpio
        End If
    End Sub

    Private Sub frmAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Ambiente.usuario.desarrollador Then
            btnIRModificar.Visible = True
            btnIRDPModificar.Visible = True
            btnIRDEModificar.Visible = True
            btnITiketMod.Visible = True
            btnFaltasXPeriodoMod.Visible = True
            bteModSem.Visible = True
            bteModMes.Visible = True
            bteModAnio.Visible = True
            bteModificarCardex.Visible = True
        Else
            btnIRModificar.Visible = False
            btnIRDPModificar.Visible = False
            btnIRDEModificar.Visible = False
            btnITiketMod.Visible = False
            btnFaltasXPeriodoMod.Visible = False
            bteModSem.Visible = False
            bteModMes.Visible = False
            bteModAnio.Visible = False
            bteModificarCardex.Visible = False
        End If

        If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
            bteModSem.Visible = True
            bteModMes.Visible = True
            bteModAnio.Visible = True
            btnIRDEModificar.Visible = True
            btnIRDPModificar.Visible = True
            btnIRModificar.Visible = True
            btnFaltasXPeriodoMod.Visible = True
            bteInserRegisHO.Visible = True
        Else
            bteModSem.Visible = False
            bteModMes.Visible = False
            bteModAnio.Visible = False
            btnIRDEModificar.Visible = False
            btnIRDPModificar.Visible = False
            btnIRModificar.Visible = False
            btnFaltasXPeriodoMod.Visible = False
        End If


        If Ambiente.empr.idEmpresa = 7 Then
            btePermisos_mg.Visible = False
        End If

        indicedEmpleadoSeleccionado = -1
        cargado = True

        reg = New Registro(Ambiente)
        reg.idEmpresa = Ambiente.empr.idEmpresa

        objVisita = New VisitaSucursal(Ambiente)

        tInci = New TipoIncidencia(Ambiente)
        tInci.idEmpresa = Ambiente.empr.idEmpresa
        tInci.calculada = False

        'tInci.getComboActivoTablaRegistro(cbTipoIncidencia, objCBTIncidencia, " AND idTipoIncidencia NOT IN (5,6,1,12)")
        'If Ambiente.empr.idEmpresa = 1 Or Ambiente.empr.idEmpresa = 1 Or Ambiente.empr.idEmpresa = 1 Then
        If Ambiente.empr.idEmpresa <> 7 And Ambiente.usuario.tipoUsuarioSistema <> "RH" Then
            tInci.getComboActivoTablaRegistro(cbTipoIncidencia, objCBTIncidencia, " AND idTipoIncidencia NOT IN (5,6,1,12)")
        Else
            tInci.getComboActivo(cbTipoIncidencia, objCBTIncidencia)
        End If

        disp = New Dispositivo(Ambiente)
        disp.idEmpresa = Ambiente.empr.idEmpresa
        disp.getComboActivoXTipo(cbDispositivo, objCBDis, elementoSistemas)

        objDep = New Departamento(Ambiente)
        objDep.idEmpresa = Ambiente.empr.idEmpresa
        objDep.getComboActivo(cbDepartamento, objCBDep)

        objEmp = New Empleado(Ambiente)
        objEmp.idEmpresa = Ambiente.empr.idEmpresa
        'CargarGid()

        horasExtras = New ControlHorasExtras(Ambiente)

        perido = New Periodo(Ambiente)
        perido.idEmpresa = Ambiente.empr.idEmpresa
        perido.ejercicio = Now.Year
        perido.tabla = "Registro"
        perido.elementoSistema = elementoSistemas
        If Not perido.getComboTodos(cbPeriodo, objCbPerido) Then
            Mensaje.Mensaje = perido.descripError
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
        End If

        calculosCO.Parent = Nothing
        calculosES.Parent = Nothing
        btnITiket.Visible = False
        btnITiketMod.Visible = False

        If elementoSistemas = "CO" Then
            If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
                calculosCO.Parent = contenTabs
            End If

            btnProcesarHorasExtras.Visible = False

            If Ambiente.usuario.desarrollador Then
                btnITiketMod.Visible = True
            End If

            btnITiket.Visible = True
        End If

        If elementoSistemas = "ES" Then
            btnProcesarHorasExtras.Visible = True
            btnRegInvalidos.Visible = True
            btnIIncidencias.Visible = True

            If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
                calculosES.Parent = contenTabs
            End If
        Else
            btnRegInvalidos.Visible = False
            btnIIncidencias.Visible = False
        End If

        If Ambiente.usuario.desarrollador Then
            btnIRModificar.Visible = True
            btnIRDEModificar.Visible = True
            btnIRDPModificar.Visible = True
            btnFaltasXPeriodoMod.Visible = True
        End If

        'SELECCIONAR LA SEMANA ACTUAL
        For i As Integer = 0 To objCbPerido.Count - 1
            If objCbPerido.Item(i).inicioPeriodo <= Now.Date And objCbPerido.Item(i).finPeriodo >= Now.Date Then
                cbPeriodo.SelectedIndex = i
            End If
        Next

        If elementoSistemas = "ES" Then
            btePermisos_mg.Visible = True
            incidenciasDep.Visible = True
        Else
            btePermisos_mg.Visible = False
            incidenciasDep.Visible = False
        End If
    End Sub

    Private Sub enableBteHrsExtra()
        Dim habilitaCtlHrsExtra As Boolean = False
        Dim solicituPermiso As SolicitudPermiso = New SolicitudPermiso(Ambiente)
        solicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
        Dim depsLider As Integer = solicituPermiso.esLider()
        If (depsLider > 0 Or Ambiente.usuario.tipoUsuarioSistema = "RH") And
            objCbPerido(cbPeriodo.SelectedIndex).esActivo = True Then
            habilitaCtlHrsExtra = True
        Else
            habilitaCtlHrsExtra = False
        End If

        If objDGEmpl.Item(indicedEmpleadoSeleccionado).perfilCalculo = "Destajista" Then
            habilitaCtlHrsExtra = False
        End If

        btnActHorasExtras.Enabled = habilitaCtlHrsExtra
        btnActHorasExtrasEmpleado.Enabled = habilitaCtlHrsExtra
        txtNumHorasExtras.Enabled = habilitaCtlHrsExtra
        chbHorasExtrasAutorizadas.Enabled = habilitaCtlHrsExtra
        chbHorasLimiteHorasExtras.Enabled = habilitaCtlHrsExtra
        chbHorasLimiteHorasExtrasEmpleado.Enabled = habilitaCtlHrsExtra
        chbHorasExtrAutEmpleado.Enabled = habilitaCtlHrsExtra
        txtHrsExtDefault.Enabled = habilitaCtlHrsExtra
    End Sub


    Private Sub CargarGid()
        Dim idDep As Integer

        If cbPeriodo.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cbDepartamento.SelectedIndex <> -1 Then
            idDep = objCBDep.Item(cbDepartamento.SelectedIndex).idDepartamento
        Else
            idDep = Nothing
        End If

        'cargado = False
        objEmp.cargarGridXDepXPeriodo(dgvEmpleado, idDep, txtFiltro.Text.Trim, objDGEmpl, objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo, objCbPerido(cbPeriodo.SelectedIndex).finPeriodo)
        'cargado = True

        If dgvEmpleadosADD.Columns.Count = 0 Then
            Dim dgvc As DataGridViewColumn

            For i As Integer = 0 To dgvEmpleado.ColumnCount - 1
                dgvc = dgvEmpleado.Columns.Item(i).Clone
                dgvEmpleadosADD.Columns.Add(dgvc)
            Next
        End If

        dgvEmpleadoCopy.DataSource = dgvEmpleado.DataSource
    End Sub


    Private Sub asignarDatos(indice As Integer)
        cambios.Clear()

        If indice <> -1 And cargado And indicedEmpleadoSeleccionado <> -1 Then

            Dim idEmpleado As Integer
            Dim indiceDia As Integer

            Select Case cbSemanaRegs.SelectedIndex
                Case 0
                    indiceDia = 0
                Case 1
                    indiceDia = 7
                Case 2
                    indiceDia = 14
                Case 3
                    indiceDia = 21
                Case 4
                    indiceDia = 28
            End Select

            idEmpleado = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            lblSeleccion2.Text = "PIN: (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado & ") - " & UCase(objDGEmpl.Item(indicedEmpleadoSeleccionado).nombreCompleto)

            dtpFechaInicial.Value = objCbPerido.Item(indice).inicioPeriodo
            dtpFechaFinal.Value = objCbPerido.Item(indice).finPeriodo
            perido = objCbPerido.Item(indice)

            rangoPerido = perido.getDiasRango()

            horasExtras.idEmpleado = idEmpleado
            horasExtras.idPeriodo = perido.idPeriodo

            txtHrsExtDefault.Text = objDGEmpl.Item(indicedEmpleadoSeleccionado).cantidadHoras
            txtPerfilCalculo.Text = "Perfil de cálculo: " & objDGEmpl.Item(indicedEmpleadoSeleccionado).perfilCalculo
            chbHorasLimiteHorasExtrasEmpleado.Checked = objDGEmpl.Item(indicedEmpleadoSeleccionado).forzarLimiteHorasExtras
            chbHorasExtrAutEmpleado.Checked = objDGEmpl.Item(indicedEmpleadoSeleccionado).tieneHorasExtrasAut
            cargaCardexHorasExtras()
            cargaHorasExtras()

            If rangoPerido.Count > indiceDia Then
                lbl1.Text = UCase(Format(rangoPerido.Item(indiceDia), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR1, idEmpleado, rangoPerido.Item(indiceDia), objDia1, elementoSistemas, False)
            Else
                lbl1.Text = ""
                dgR1.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 1 Then
                lbl2.Text = UCase(Format(rangoPerido.Item(indiceDia + 1), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR2, idEmpleado, rangoPerido.Item(indiceDia + 1), objDia2, elementoSistemas, False)
            Else
                lbl2.Text = ""
                dgR2.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 2 Then
                lbl3.Text = UCase(Format(rangoPerido.Item(indiceDia + 2), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR3, idEmpleado, rangoPerido.Item(indiceDia + 2), objDia3, elementoSistemas, False)
            Else
                lbl3.Text = ""
                dgR3.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 3 Then
                lbl4.Text = UCase(Format(rangoPerido.Item(indiceDia + 3), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR4, idEmpleado, rangoPerido.Item(indiceDia + 3), objDia4, elementoSistemas, False)
            Else
                lbl4.Text = ""
                dgR4.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 4 Then
                lbl5.Text = UCase(Format(rangoPerido.Item(indiceDia + 4), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR5, idEmpleado, rangoPerido.Item(indiceDia + 4), objDia5, elementoSistemas, False)
            Else
                lbl5.Text = ""
                dgR5.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 5 Then
                lbl6.Text = UCase(Format(rangoPerido.Item(indiceDia + 5), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR6, idEmpleado, rangoPerido.Item(indiceDia + 5), objDia6, elementoSistemas, False)
            Else
                lbl6.Text = ""
                dgR6.DataSource = dtLimpio
            End If

            If rangoPerido.Count > indiceDia + 6 Then
                lbl7.Text = UCase(Format(rangoPerido.Item(indiceDia + 6), "dddd dd / MMMM / yyyy"))
                reg.cargaGridXFechaEmpl(dgR7, idEmpleado, rangoPerido.Item(indiceDia + 6), objDia7, elementoSistemas, False)
            Else
                lbl7.Text = ""
                dgR7.DataSource = dtLimpio
            End If

            If elementoSistemas = "ES" Then
                cargaResultados(idEmpleado)
            ElseIf elementoSistemas = "CO" Then
                cargaResultadosCO(idEmpleado)
            End If

            cargarGridManuales()
        End If
    End Sub

    Public Sub cargaResultadosCO(idEmpleado As Integer)
        Dim rpe As New ResultadoCocina(Ambiente)
        Dim cocina As New Cocina(Ambiente)

        Dim numComidas As Integer
        Dim totalComidas As Decimal

        rpe.idPeriodo = perido.idPeriodo
        rpe.idEmpleado = idEmpleado
        rpe.totalPEmplyPeriodo(numComidas, totalComidas)

        cocina.idCocina = rpe.idCocinaAsig
        cocina.buscarPID()

        txtNumComidas.Text = FormatNumber(numComidas)
        txtDescuentoXComidas.Text = FormatCurrency(totalComidas)
        txtCocinaAsig.Text = cocina.nombreCocina
    End Sub


    Public Sub cargaResultados(idEmpleado As Integer)
        Dim rpe As New ResultadoPeriodoES(Ambiente)
        Dim rfES As New ResultadoFormulaES(Ambiente)

        rpe.idPeriodo = perido.idPeriodo
        rpe.idEmpleado = idEmpleado

        rpe.buscarCalculo()

        txtDP.Text = FormatNumber(rpe.D_PRDO)
        txtA.Text = FormatNumber(rpe.A)
        txtBJL.Text = FormatNumber(rpe.BJL)
        txtCHET.Text = FormatCurrency(rpe.CHET)
        txtCHR.Text = FormatCurrency(rpe.CHR)
        txtD.Text = FormatCurrency(rpe.D)
        txtDF.Text = FormatNumber(rpe.DF)
        txtF.Text = FormatNumber(rpe.F)
        txtI.Text = FormatNumber(rpe.I)
        txtPGS.Text = FormatNumber(rpe.PGS)
        txtPSGS.Text = FormatNumber(rpe.PSGS)
        txtSSI.Text = FormatCurrency(rpe.SSI)
        txtSSR.Text = FormatCurrency(rpe.SSR)
        txtTE.Text = FormatNumber(rpe.TE)
        txtTFN.Text = FormatNumber(rpe.TFN)
        txtTHL.Text = FormatNumber(rpe.THL)
        txtVD.Text = FormatNumber(rpe.VD)
        txtExcedente.Text = FormatCurrency(rpe.excedente)

        rfES.idResultadoPeriodoES = rpe.idResultadoPeriodoES
        rfES.cargaGridXIDPeriodoES(dgvCalculos, New List(Of ResultadoFormulaES))


        objVisita.cargaGridVisitas(dgvExtras, idEmpleado, objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo, objCbPerido(cbPeriodo.SelectedIndex).finPeriodo)
    End Sub

    Private Sub cbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriodo.SelectedIndexChanged
        'Recordar empleado al Cambiar periodo
        If cbPeriodo.SelectedIndex <> -1 Then
            Dim IDSelectEmployee As Integer = 0
            Try
                IDSelectEmployee = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            Catch ex As Exception
            End Try
            CargarGid()
            cargarGridManuales()
            comboSemanas()
            enableBteHrsExtra()
            Try
                Dim index As Integer = 0
                For i = 0 To objDGEmpl.Count - 1
                    If objDGEmpl.Item(i).idEmpleado = IDSelectEmployee Then
                        index = i
                        Exit For
                    End If
                Next
                dgvEmpleado.Rows(index).Selected = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub comboSemanas()
        Dim diasPer As Integer
        Dim semanas As Integer

        diasPer = DateDiff(DateInterval.Day, objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo, objCbPerido(cbPeriodo.SelectedIndex).finPeriodo) + 1

        If diasPer > 0 And diasPer <= 7 Then
            semanas = 1
        ElseIf diasPer > 7 And diasPer <= 14 Then
            semanas = 2
        ElseIf diasPer > 14 And diasPer <= 21 Then
            semanas = 3
        ElseIf diasPer > 21 And diasPer <= 28 Then
            semanas = 4
        ElseIf diasPer > 28 And diasPer <= 36 Then
            semanas = 5
        End If

        cbSemanaRegs.Items.Clear()
        For i As Integer = 1 To semanas
            cbSemanaRegs.Items.Add("SEMANA (" & i & ")")
        Next

        If diasPer > 0 Then
            cbSemanaRegs.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dgvEmpleadoCopy.SelectedRows.Count > 0 Then
            For i As Integer = 0 To dgvEmpleadosADD.Rows.Count - 1
                If dgvEmpleadosADD.Rows(i).Cells(0).Value = dgvEmpleadoCopy.SelectedRows.Item(0).Cells(0).Value Then
                    Exit Sub
                End If
            Next

            For Each drr As DataGridViewRow In dgvEmpleadoCopy.SelectedRows
                Dim row As DataGridViewRow = CType(drr.Clone(), DataGridViewRow)
                For i As Int32 = 0 To drr.Cells.Count - 1
                    row.Cells(i).Value = drr.Cells(i).Value
                Next
                dgvEmpleadosADD.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dgvEmpleadosADD.SelectedRows.Count > 0 Then
            dgvEmpleadosADD.Rows.RemoveAt(dgvEmpleadosADD.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub cargarGridManuales()
        If elementoSistemas = "ES" Then
            Dim idEmpl As Integer

            If dgvEmpleado.SelectedRows.Count > 0 Then
                idEmpl = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado
            Else
                idEmpl = Nothing
            End If

            perido.idEmpresa = Ambiente.empr.idEmpresa
            perido.cargarGridDiasPeriodoXEmpl(dgvIncidencia, idEmpl, objInciXDia)
            perido.cargarGridDiasPeriodoXEmplCalculadas(dgvIncidenciasCalculadas, idEmpl, objInciXDiaCalculada)

            habilitaBotonesInci(False)

            'If perido.esActivo Then
            '    'dgvIncidencia.Enabled = True
            'Else
            '    habilitaBotonesInci(False)
            '    'dgvIncidencia.Enabled = False
            'End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim indice As Integer = 0

        If Not perido.validaFechaEnRango(dtpRegManual.Value) Then
            If perido.idError = 0 Then
                Mensaje.Mensaje = "La fecha Seleccionada no corresponde a ningun Periodo ""Abierto"""
            Else
                Mensaje.Mensaje = perido.descripError
            End If
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
            Exit Sub
        ElseIf cbDispositivo.SelectedIndex = -1 And elementoSistemas = "CO" Then
            Mensaje.Mensaje = "Por Favor selecciona Un Dispositivo..."
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.ShowDialog()
            Exit Sub
        End If

        For i As Integer = 0 To dgvEmpleadosADD.Rows.Count - 1
            reg = New Registro(Ambiente)
            reg.idEmpresa = Ambiente.empr.idEmpresa
            reg.fechaRegistro = dtpRegManual.Value
            reg.esActivo = True
            reg.comentario = txtComentario.Text
            reg.idEmpleado = objDGEmpl.Item(dgvEmpleadosADD.Rows(indice).Cells(0).Value).idEmpleado
            reg.operacion = elementoSistemas

            If cbDispositivo.SelectedIndex <> -1 Then
                reg.idDispositivo = objCBDis(cbDispositivo.SelectedIndex).idDispositivo
                reg.dispositivo = UCase(objCBDis(cbDispositivo.SelectedIndex).nombreDispositivo)
            End If

            If Not reg.guardar() Then
                Mensaje.Mensaje = reg.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
                indice += 1
            Else
                If Not chbConcervar.Checked Then
                    dgvEmpleadosADD.Rows.RemoveAt(indice)
                Else
                    indice += 1
                End If
            End If
        Next
        txtComentario.Text = ""
        cargarGridManuales()
        asigaXDG()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnActualizarRegistros.Click
        guardarRegs()
    End Sub

    Sub guardarRegs()
        'VERSION 2
        Dim idError As Integer
        Dim descripError As String = ""

        For i As Integer = 0 To cambios.Count - 1
            If perido.validaFechaEnRango(cambios(i).fechaRegistro) Then
                cambios(i).actualizar()
            Else
                idError = 1
                descripError &= "Fecha fuera de periodo: " & Format(cambios(i).fechaRegistro, "dd/MM/yyyy HH:mm:ss") & vbCrLf
            End If
        Next
        cambios.Clear()

        Mensaje.tipoMsj = TipoMensaje.Informacion

        If idError <> Nothing Then
            Mensaje.Mensaje = "Algunos registros no fueron guardados: " & vbCrLf & descripError
            asigaXDG()
        Else
            Mensaje.Mensaje = "Proceso completado correctamente... "
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        buscar()
    End Sub

    Private Sub buscar()
        dgvEmpleadosADD.Rows.Clear()
        CargarGid()
        'asigaXDG()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            buscar()
        End If
    End Sub

    Private Sub dgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellDoubleClick
        asigaXDG()
        contenTabs.SelectTab("tabReg")
    End Sub

    Private Sub dgvIncidencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidencia.CellDoubleClick
        indicePeriodo = e.RowIndex
        If indicePeriodo >= 0 Then
            If objInciXDia.Item(indicePeriodo).idIncidencia <> Nothing Then
                frmComentario.Ambiente = Ambiente
                frmComentario.idTabla = objInciXDia.Item(indicePeriodo).idIncidencia
                frmComentario.tabla = "Incidencia"
                frmComentario.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgvIncidencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidencia.CellClick
        indicePeriodo = e.RowIndex
        If indicePeriodo >= 0 Then
            habilitaBotonesInci(True)
        Else
            habilitaBotonesInci(False)
        End If
    End Sub

    Public Sub habilitaBotonesInci(habilitar As Boolean)
        If perido.esActivo Then
            btnActualizar.Enabled = habilitar
            btnEliminarInci.Enabled = habilitar
            cbTipoIncidencia.Enabled = habilitar

        Else
            cbTipoIncidencia.Enabled = False
            btnActualizar.Enabled = False
            btnEliminarInci.Enabled = False
        End If

        'btnAdjuntosIncidencia.Enabled = habilitar

        If Not habilitar Then
            cbTipoIncidencia.SelectedIndex = -1
        Else
            dtpFechaIncidencia.Value = objInciXDia.Item(indicePeriodo).fecha
            cbTipoIncidencia.SelectedIndex = -1
            For i As Integer = 0 To cbTipoIncidencia.Items.Count - 1
                If objCBTIncidencia.Item(i).idTipoIncidencia = objInciXDia.Item(indicePeriodo).idTipoIncidencia Then
                    cbTipoIncidencia.SelectedIndex = i
                End If
            Next
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If validarReglasPermisos() Then
            Dim idEmpl As Integer
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If cbTipoIncidencia.SelectedIndex = -1 Then
                Mensaje.Mensaje = "Por Favor Selecciona un tipo de Incidencia Válido.."
                Mensaje.ShowDialog()
                Exit Sub
            End If
            idEmpl = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            objInciXDia.Item(indicePeriodo).idTipoIncidencia = objCBTIncidencia.Item(cbTipoIncidencia.SelectedIndex).idTipoIncidencia
            objInciXDia.Item(indicePeriodo).idDepartamento = objDGEmpl(indicedEmpleadoSeleccionado).idDepartamento
            objInciXDia.Item(indicePeriodo).nombreLider = objDGEmpl(indicedEmpleadoSeleccionado).getDepartamento.nombreLider
            objInciXDia.Item(indicePeriodo).calculada = objCBTIncidencia.Item(cbTipoIncidencia.SelectedIndex).calculada
            objInciXDia.Item(indicePeriodo).idHorario = objDGEmpl(indicedEmpleadoSeleccionado).idHorario
            objInciXDia.Item(indicePeriodo).incidenciaXDia = objCBTIncidencia.Item(cbTipoIncidencia.SelectedIndex).incidenciaXDia
            If objInciXDia.Item(indicePeriodo).idIncidencia = Nothing Then
                If objInciXDia.Item(indicePeriodo).guardar() Then
                    Mensaje.Mensaje = "Se guardo correctamente la Incidencia..."
                Else
                    Mensaje.Mensaje = objInciXDia.Item(indicePeriodo).descripError
                End If
            Else
                If objInciXDia.Item(indicePeriodo).actualizar() Then
                    Mensaje.Mensaje = "Se actualizo correctamente la Incidencia..."
                Else
                    Mensaje.Mensaje = objInciXDia.Item(indicePeriodo).descripError
                End If
            End If
            perido.cargarGridDiasPeriodoXEmplCalculadas(dgvIncidenciasCalculadas, idEmpl, objInciXDiaCalculada)
            Mensaje.ShowDialog()
            cargarGridManuales()
            habilitaBotonesInci(False)
        End If
    End Sub

    Private Sub VerRegistrosInvalidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnRegInvalidos.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            reg.cargarGridRegistrosInvalidos(frmRegInvalidos.DataGridView1, perido.inicioPeriodo, perido.finPeriodo, "ES", If(cbDepartamento.SelectedIndex <> -1, objCBDep.Item(cbDepartamento.SelectedIndex).idDepartamento, Nothing), txtFiltro.Text)
            frmRegInvalidos.Label1.Text = UCase(If(txtFiltro.Text <> Nothing, "Buscando: """ & txtFiltro.Text & """", "Buscando: ""Todo""") & " | " & If(cbDepartamento.SelectedIndex <> -1, "Departamento: """ & objCBDep.Item(cbDepartamento.SelectedIndex).nombreDepartamento & """", "Departamento: ""Todos"""))
            frmRegInvalidos.MdiParent = Me.MdiParent
            frmRegInvalidos.Show()
            frmRegInvalidos.Activate()
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIRImprimir.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirDatosRegistros(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text, 0)
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIRModificar.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarDatosRegistros(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text, 0)
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If perido.esActivo Then
            If perido.procesar("EFE", Nothing, objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado, True) Then
                Mensaje.Mensaje = "Se proceso correctamente el empleado: " & objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado & " - " & objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).nombreCompleto & " en el periodo: " & perido.numeroPeriodo & " - " & perido.nombrePeriodo
                asigaXDG()
            Else
                Mensaje.Mensaje = perido.descripError
            End If
        Else
            Mensaje.Mensaje = "El periodo ha sido cerrado, no se pueden realizar calculos..."
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub RegAnteriorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnRegAnt.Click
        If dgvEmpleado.SelectedRows.Item(0).Index <> 0 Then
            dgvEmpleado.Rows(dgvEmpleado.SelectedRows.Item(0).Index - 1).Selected = True
            enableBteHrsExtra()
        End If
    End Sub

    Private Sub RegSiguienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnRegSiguiente.Click
        If dgvEmpleado.SelectedRows.Item(0).Index <> dgvEmpleado.Rows.Count - 1 Then
            dgvEmpleado.Rows(dgvEmpleado.SelectedRows.Item(0).Index + 1).Selected = True
            enableBteHrsExtra()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtFiltro.Text = ""
        cbDepartamento.SelectedIndex = -1
        buscar()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmFecha.ShowDialog()

        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "Realmente desea dar de baja al Empleado: (" & objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).nombreCompleto & ") con fecha: (" & UCase(Format(frmFecha.dtpFecha.Value, "dddd dd/MM/yyyy")) & ")"

        If Mensaje.ShowDialog <> DialogResult.Yes Then
            Exit Sub
        End If

        Mensaje.tipoMsj = TipoMensaje.Informacion
        Dim idEmpl As Integer
        idEmpl = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado

        If Not perido.procesarCuentaXPeriodoBajaXEmpleado(idEmpl) Then
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = perido.descripError & vbCrLf
        Else
            If Not perido.generarPagosES(idEmpl) Then
                Mensaje.Mensaje = perido.descripError
            Else
                Dim paso As Boolean
                Dim conVac As New ControlVacaciones(Ambiente)

                If objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).diasVacacionesDisponibles > 0 Then

                    conVac.diasRestantes = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).diasVacacionesDisponibles
                    conVac.idEmpleado = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado
                    conVac.diasMovimiento = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).diasVacacionesDisponibles
                    conVac.idIncidencia = Nothing
                    conVac.concepto = "BAJA DEL EMPLEADO"
                    conVac.tipoMovimiento = "S"

                    If conVac.guardar() Then
                        paso = True
                    Else
                        paso = False
                    End If
                Else
                    paso = True
                End If

                If paso Then
                    objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).esActivo = False
                    objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).fechaBaja = frmFecha.dtpFecha.Value
                    objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).diasVacacionesDisponibles = 0

                    If Not objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).actualizar() Then
                        Mensaje.Mensaje = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).descripError & vbCrLf
                    Else
                        Dim evento = New Evento(Ambiente)
                        evento.idEmpleado = objDGEmpl.Item(dgvEmpleado.SelectedRows.Item(0).Cells(0).Value).idEmpleado
                        Dim result As Integer = evento.execSpBorradoEmpleadoReloj()
                        If result > 0 Then
                            Mensaje.Mensaje = "La baja del Empleado se ha procesado correctamente y se crearon " &
                                result & " Eventos para Eliminar Huellas. " & evento.descripError
                            CargarGid()
                        Else
                            Mensaje.tipoMsj = TipoMensaje.Alerta
                            Mensaje.Mensaje = "La baja del Empleado se ha procesado correctamente, Pero no se crearon los Eventos para Eliminar Huellas. " & evento.descripError
                        End If
                    End If
                Else
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = conVac.descripError
                End If
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnEliminarInci.Click
        If validarReglasPermisos() Then
            If objInciXDia.Item(indicePeriodo).eliminar() Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se Elimino correctamente la Incidencia..."
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = objInciXDia.Item(indicePeriodo).descripError
            End If
            Mensaje.ShowDialog()
            cargarGridManuales()
            habilitaBotonesInci(False)
        End If
    End Sub

    Private Function validarReglasPermisos() As Boolean
        If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
            Return True
        End If
        If objInciXDia.Item(indicePeriodo).idIncidencia <> Nothing Then
            Dim valor = objInciXDia.Item(indicePeriodo).buscarReglaIncidencia()
            If valor = Nothing Then
                Dim motivoPermiso = objInciXDia.Item(indicePeriodo).buscarPermisoIncidencia()
                If motivoPermiso = Nothing Then
                    Dim empleadoCreoIncidencia = New Empleado(Ambiente)
                    empleadoCreoIncidencia.idEmpleado = objInciXDia.Item(indicePeriodo).creadoPor
                    If empleadoCreoIncidencia.buscarPID() Then
                        If empleadoCreoIncidencia.tipoUsuarioSistema = "RH" Then
                            Mensaje.tipoMsj = TipoMensaje.Error
                            Mensaje.Mensaje = "Este Registro fué creado por Recursos Humanos, no se puede Eliminar."
                            Mensaje.ShowDialog()
                            Return False
                        Else
                            Return True
                        End If
                    Else
                        Mensaje.tipoMsj = TipoMensaje.Error
                        Mensaje.Mensaje = empleadoCreoIncidencia.descripError
                        Return False
                    End If
                Else
                    Mensaje.tipoMsj = TipoMensaje.Alerta
                    Mensaje.Mensaje = "Hay un Permiso Aplicado por lo que no podrás eliminar ni modificar el Registro, Motivo del Permiso: " & motivoPermiso
                    Mensaje.ShowDialog()
                    Return False
                End If
            Else
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Hay una Sanción Aplicada por lo que no podrás eliminar ni modificar el Registro, Sanción Aplicada: " & valor
                Mensaje.ShowDialog()
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub dgR1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR1.CellDoubleClick
        dtpRegManual.Value = objDia1.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR2.CellDoubleClick
        dtpRegManual.Value = objDia2.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR3.CellDoubleClick
        dtpRegManual.Value = objDia3.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR4_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR4.CellDoubleClick
        dtpRegManual.Value = objDia4.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR5_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR5.CellDoubleClick
        dtpRegManual.Value = objDia5.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR6_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR6.CellDoubleClick
        dtpRegManual.Value = objDia6.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR7_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgR7.CellDoubleClick
        dtpRegManual.Value = objDia7.Item(e.RowIndex).fechaRegistro
        contenTabs.SelectTab("tabRegManua")
    End Sub

    Private Sub dgR1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR1.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia1.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia1.Item(e.RowIndex).esActivo <> dgR1.Rows(e.RowIndex).Cells(0).Value Then
                objDia1.Item(e.RowIndex).esActivo = dgR1.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia1.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR2.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia2.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia2.Item(e.RowIndex).esActivo <> dgR2.Rows(e.RowIndex).Cells(0).Value Then
                objDia2.Item(e.RowIndex).esActivo = dgR2.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia2.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR3_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR3.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia3.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia3.Item(e.RowIndex).esActivo <> dgR3.Rows(e.RowIndex).Cells(0).Value Then
                objDia3.Item(e.RowIndex).esActivo = dgR3.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia3.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR4_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR4.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia4.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia4.Item(e.RowIndex).esActivo <> dgR4.Rows(e.RowIndex).Cells(0).Value Then
                objDia4.Item(e.RowIndex).esActivo = dgR4.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia4.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR5_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR5.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia5.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia5.Item(e.RowIndex).esActivo <> dgR5.Rows(e.RowIndex).Cells(0).Value Then
                objDia5.Item(e.RowIndex).esActivo = dgR5.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia5.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR6_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR6.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia6.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia6.Item(e.RowIndex).esActivo <> dgR6.Rows(e.RowIndex).Cells(0).Value Then
                objDia6.Item(e.RowIndex).esActivo = dgR6.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia6.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgR7_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgR7.CellEndEdit
        Dim idEmpl As Integer
        Try
            idEmpl = objDia7.Item(e.RowIndex).idEmpleado
        Catch ex As Exception
            idEmpl = 0
        End Try

        If emplAct = idEmpl Then
            If objDia7.Item(e.RowIndex).esActivo <> dgR7.Rows(e.RowIndex).Cells(0).Value Then
                objDia7.Item(e.RowIndex).esActivo = dgR7.Rows(e.RowIndex).Cells(0).Value
                cambios.Add(objDia7.Item(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIRDPImprimir.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirDatosIncidencia(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text)
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles btnIRDPModificar.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarDatosIncidencia(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text)
        End If
    End Sub

    Private Sub btnIRDEImprimir_Click(sender As Object, e As EventArgs) Handles btnIRDEImprimir.Click
        If cbPeriodo.SelectedIndex <> -1 And indicedEmpleadoSeleccionado > -1 Then
            Dim reportesGenerales As New ReportesGenerales(Ambiente)
            reportesGenerales.RPT_frmatPerisoEmpleado(False, objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado, objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo, objCbPerido(cbPeriodo.SelectedIndex).finPeriodo)
        End If
    End Sub

    Private Sub btnProcesarHorasExtras_Click(sender As Object, e As EventArgs) Handles btnProcesarHorasExtras.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            Dim idEmpl As Integer
            Try
                idEmpl = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            Catch ex As Exception
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Es necesario seleccionar un ""EMPLEADO"" para poder procesar los registros..."
                Mensaje.ShowDialog()
                Exit Sub
            End Try

            If objCbPerido(cbPeriodo.SelectedIndex).procesar("HEXT", Nothing, idEmpl, True) Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se procesaron correctamente los registros de (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado & ") """ & objDGEmpl.Item(indicedEmpleadoSeleccionado).nombreCompleto & """ en el periodo: " & objCbPerido(cbPeriodo.SelectedIndex).numeroPeriodo & " - " & objCbPerido(cbPeriodo.SelectedIndex).nombrePeriodo
                cargarGridManuales()
                asigaXDG()
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = objCbPerido(cbPeriodo.SelectedIndex).descripError
            End If

            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub dgR1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR1.CellBeginEdit
        emplAct = objDia1.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR2.CellBeginEdit
        emplAct = objDia2.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR3_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR3.CellBeginEdit
        emplAct = objDia3.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR4_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR4.CellBeginEdit
        emplAct = objDia4.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR5_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR5.CellBeginEdit
        emplAct = objDia5.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR6_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR6.CellBeginEdit
        emplAct = objDia6.Item(e.RowIndex).idEmpleado
    End Sub
    Private Sub dgR7_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgR7.CellBeginEdit
        emplAct = objDia7.Item(e.RowIndex).idEmpleado
    End Sub

    Private Sub btnIRDEModificar_Click(sender As Object, e As EventArgs) Handles btnIRDEModificar.Click
        If cbPeriodo.SelectedIndex <> -1 And indicedEmpleadoSeleccionado > -1 Then
            Dim reportesGenerales As New ReportesGenerales(Ambiente)
            reportesGenerales.RPT_frmatPerisoEmpleado(True, objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado, objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo, objCbPerido(cbPeriodo.SelectedIndex).finPeriodo)
        End If
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles btnAdjuntosIncidencia.Click
        If Not objInciXDia.Item(indicePeriodo).idIncidencia = Nothing Then
            frmArchivo.tabla = "Incidencia"
            frmArchivo.idTabla = objInciXDia.Item(indicePeriodo).idIncidencia
            frmArchivo.Ambiente = Ambiente
            frmArchivo.elementoSistema = "Varios"
            frmArchivo.tipoArchivo = "Adjunto"
            frmArchivo.ShowDialog()
        Else
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Debe existir una Incidencia para poder Adjuntar Archivos..."
            Mensaje.ShowDialog()
        End If
    End Sub



    Private Sub cargaHorasExtras()
        Dim habilitar As Boolean
        habilitar = False

        If horasExtras.buscarPID Then
            If Ambiente.usuario.esSupervisor Then
                habilitar = True
            End If

            txtNumHorasExtras.Text = horasExtras.cantidadHoras
            chbHorasExtrasAutorizadas.Checked = horasExtras.tienenHorasExtrasAut
            chbHorasLimiteHorasExtras.Checked = horasExtras.forzarLimiteHorasExtras

        Else
            If horasExtras.creaHoras() Then
                If horasExtras.buscarPID Then
                    If Ambiente.usuario.esSupervisor Then
                        habilitar = True
                    End If

                    txtNumHorasExtras.Text = horasExtras.cantidadHoras
                    chbHorasExtrasAutorizadas.Checked = horasExtras.tienenHorasExtrasAut
                    chbHorasLimiteHorasExtras.Checked = horasExtras.forzarLimiteHorasExtras
                Else
                    txtNumHorasExtras.Text = "0"
                    chbHorasExtrasAutorizadas.Checked = False
                    chbHorasLimiteHorasExtras.Checked = False
                End If
            Else
                MsgBox("Ocurrio un error: " & horasExtras.descripError, MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub cbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamento.SelectedIndexChanged
        If cbPeriodo.SelectedIndex <> -1 Then
            CargarGid()
            asignarDatos(cbPeriodo.SelectedIndex)
            cargarGridManuales()
        End If
    End Sub

    Private Sub cbSemanaRegs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSemanaRegs.SelectedIndexChanged
        asignarDatos(cbPeriodo.SelectedIndex)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "Registro"
        frmImportar.valor1 = "ES"
        frmImportar.ShowDialog()
    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles Button8.Click
        contenTabs.SelectTab("tabInciCal")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim idEmpl As Integer
        idEmpl = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If perido.procesarIncidencias(idEmpl) Then
            perido.cargarGridDiasPeriodoXEmplCalculadas(dgvIncidenciasCalculadas, idEmpl, objInciXDiaCalculada)
            Mensaje.Mensaje = "Proceso concluido...!!"
            Mensaje.ShowDialog()

            If dgvEmpleado.SelectedRows.Count > 0 Then
                asignarDatos(cbPeriodo.SelectedIndex)
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "No se Pueden Procesar las Incidencias, Error: " & perido.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnITiket_Click(sender As Object, e As EventArgs) Handles btnITiket.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirTiketCO()
        End If
    End Sub

    Private Sub btnITiketMod_Click(sender As Object, e As EventArgs) Handles btnITiketMod.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarTiketCO()
        End If
    End Sub

    Private Sub btnFaltasXPeriodoMod_Click(sender As Object, e As EventArgs) Handles btnFaltasXPeriodoMod.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarFaltasXPeriodo()
        End If
    End Sub

    Private Sub btnFaltasXPeriodo_Click(sender As Object, e As EventArgs) Handles btnFaltasXPeriodo.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirFaltasXPeriodo()
        End If
    End Sub


    Private Sub MaterialRaisedButton1_Click_1(sender As Object, e As EventArgs) Handles btePermisos_mg.Click
        Dim solicituPermiso As SolicitudPermiso = New SolicitudPermiso(Ambiente)
        solicituPermiso.idEmpleado = Ambiente.usuario.idEmpleado
        Dim depsLider As Integer = solicituPermiso.esLider()
        'MsgBox(depsLider)
        If depsLider > 0 Then
            frmPermisoLider.Close()
            frmPermisoLider.Ambiente = Ambiente
            frmPermisoLider.ShowDialog()
        Else
            Try
                If objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado > 0 Then
                    frmPermiso.Close()
                    frmPermiso.Ambiente = Ambiente
                    frmPermiso.empleado = objDGEmpl.Item(indicedEmpleadoSeleccionado)
                    frmPermiso.ShowDialog()
                Else
                    MsgBox("Selecciona un Empleado.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If objInciXDia.Item(indicePeriodo).idIncidencia <> Nothing Then
            Dim valor = objInciXDia.Item(indicePeriodo).buscarReglaIncidencia()
            If valor = Nothing Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "No hay Reglas Aplicadas."
                Mensaje.ShowDialog()
            Else
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se aplicó la Regla: " & valor
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    'X semana
    Private Sub ModificarToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(False, "RPT_TiempoExtraXPeriodo")
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles bteModSem.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(True, "RPT_TiempoExtraXPeriodo")
    End Sub
    'X Semana

    'X Mes
    Private Sub XMesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMesToolStripMenuItem.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(False, "RPT_TiempoExtraXMes")
    End Sub

    Private Sub ModificarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles bteModMes.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(True, "RPT_TiempoExtraXMes")
    End Sub
    'X Mes

    'X Año
    Private Sub XAñoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XAñoToolStripMenuItem.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(False, "RPT_TiempoExtraXanio")
    End Sub

    Private Sub ModificarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles bteModAnio.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TiempoExtra(True, "RPT_TiempoExtraXanio")
    End Sub

    'X Año

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles incidenciasDep.Click
        If cbDepartamento.SelectedIndex > -1 Then
            If cbPeriodo.SelectedIndex > -1 And objCbPerido(cbPeriodo.SelectedIndex).esActivo Then
                Dim Pregunta = MsgBox("Se Procesarán las incidencias de " & objCBDep.Item(cbDepartamento.SelectedIndex).nombreDepartamento &
               " ¿Deseas continuar?", vbYesNo + vbQuestion, "EXCELeINFO")
                If Pregunta = vbNo Then
                    'MsgBox("Elegiste No")
                Else
                    If objCbPerido.Item(cbPeriodo.SelectedIndex).procesarIncidenciasXDep(objCBDep.Item(cbDepartamento.SelectedIndex).idDepartamento) Then
                        Mensaje.tipoMsj = TipoMensaje.Informacion
                        Mensaje.Mensaje = "¡Proceso Completo!"
                        If cbPeriodo.SelectedIndex <> -1 Then
                            CargarGid()
                            asignarDatos(cbPeriodo.SelectedIndex)
                            cargarGridManuales()
                        End If
                        Mensaje.ShowDialog()
                    Else
                        Mensaje.tipoMsj = TipoMensaje.Error
                        Mensaje.Mensaje = objCbPerido.Item(cbPeriodo.SelectedIndex).descripError
                        Mensaje.ShowDialog()
                    End If

                End If
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "El périodo seleccionado es inválido."
                Mensaje.ShowDialog()
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.Mensaje = "Debes seleccionar un Departamento."
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Function cargaCardexHorasExtras() As Boolean
        Dim objCardex As New CardexHorasExtra(Ambiente)
        objCardex.idEmpleado = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
        objCardex.cargarGridGen(dgridCardex)
        Return True
    End Function

    Private Function insertCardex(motivo As String, idEmpleado As Integer, valorAnterior As String, nuevoValor As String, ventanaCambio As String, campo As String) As Boolean
        Dim objCardex As New CardexHorasExtra(Ambiente)
        objCardex.motivoModificacion = motivo
        objCardex.campo = campo
        objCardex.idEmpleado = idEmpleado
        objCardex.valorAnterio = valorAnterior
        objCardex.nuevoValor = nuevoValor
        objCardex.ventanaCambio = ventanaCambio
        objCardex.idPeriodo = objCbPerido(cbPeriodo.SelectedIndex).idPeriodo
        If objCardex.guardar() Then
            Return True
        Else
            Mensaje.Mensaje = "Ocurrio un error: " & objCardex.descripError
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnActHorasExtrasEmpleado.Click
        Dim motivo As String = ""
        motivo = InputBox("Ingresa el motivo de la modificación", "Motivo")
        If motivo = "" Then
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "Proceso Cancelado"
            Mensaje.ShowDialog()
            Return
        End If

        Dim hayModificacion As Boolean = False
        Dim objEmpleado As Empleado = objDGEmpl.Item(indicedEmpleadoSeleccionado)

        If objEmpleado.cantidadHoras.ToString() <> txtHrsExtDefault.Text.ToString() Then
            If insertCardex(motivo, objEmpleado.idEmpleado, objEmpleado.cantidadHoras,
                            txtHrsExtDefault.Text, "Empleado", "cantidadHoras") Then
                Try
                    objEmpleado.cantidadHoras = txtHrsExtDefault.Text
                    hayModificacion = True
                Catch ex As Exception
                    Mensaje.Mensaje = "Valor de horas Inválido..."
                    Mensaje.ShowDialog()
                    txtHrsExtDefault.Select()
                    Exit Sub
                End Try
            End If
        End If

        If Convert.ToBoolean(objEmpleado.tieneHorasExtrasAut) <> Convert.ToBoolean(chbHorasLimiteHorasExtrasEmpleado.Checked) Then
            If insertCardex(motivo, objEmpleado.idEmpleado, objEmpleado.tieneHorasExtrasAut,
                            chbHorasLimiteHorasExtrasEmpleado.Checked, "Empleado", "tieneHorasExtrasAut") Then
                objEmpleado.tieneHorasExtrasAut = chbHorasLimiteHorasExtrasEmpleado.Checked
                hayModificacion = True
            End If
        End If
        'MsgBox(Convert.ToBoolean(objEmpleado.forzarLimiteHorasExtras) & "         " & Convert.ToBoolean(chbHorasExtrAutEmpleado.Checked))

        If Convert.ToBoolean(objEmpleado.forzarLimiteHorasExtras) <> Convert.ToBoolean(chbHorasExtrAutEmpleado.Checked) Then
            If insertCardex(motivo, objEmpleado.idEmpleado, objEmpleado.forzarLimiteHorasExtras,
                            chbHorasExtrAutEmpleado.Checked, "Empleado", "forzarLimiteHorasExtras") Then
                objEmpleado.forzarLimiteHorasExtras = chbHorasExtrAutEmpleado.Checked
                hayModificacion = True
            End If
        End If

        If hayModificacion Then
            If objEmpleado.actualizar() Then
                Mensaje.Mensaje = "Se actualizarón los datos correctamente..."
                Mensaje.tipoMsj = TipoMensaje.Informacion
                cargaCardexHorasExtras()
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & objEmpleado.descripError
                Mensaje.tipoMsj = TipoMensaje.Error
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "No se realizó ningun cambio."
        End If
        Mensaje.ShowDialog()
    End Sub



    Private Sub btnActHorasExtras_Click_1(sender As Object, e As EventArgs) Handles btnActHorasExtras.Click
        'Dim habilitar As Boolean
        'habilitar = False
        'Mensaje.tipoMsj = TipoMensaje.Informacion
        'Try
        '    horasExtras.cantidadHoras = txtNumHorasExtras.Text
        'Catch ex As Exception
        '    Mensaje.Mensaje = "Valor de horas Inválido..."
        '    Mensaje.ShowDialog()
        '    txtNumHorasExtras.Select()
        '    Exit Sub
        'End Try
        'horasExtras.tienenHorasExtrasAut = chbHorasExtrasAutorizadas.Checked
        'horasExtras.forzarLimiteHorasExtras = chbHorasLimiteHorasExtras.Checked
        'If horasExtras.actualizar() Then
        '    Mensaje.Mensaje = "Se actualizaron los datos..."
        'Else
        '    Mensaje.Mensaje = "Ocurrio un error: " & horasExtras.descripError
        'End If 
        'Mensaje.ShowDialog()

        Dim motivo As String = ""
        If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
            motivo = "Proceso Admin."
        Else
            motivo = InputBox("Ingresa el motivo de la modificación", "Motivo")
            If motivo = "" Then
                Mensaje.tipoMsj = TipoMensaje.Alerta
                Mensaje.Mensaje = "Proceso Cancelado"
                Mensaje.ShowDialog()
                Return
            End If
        End If
        Dim hayModificacion As Boolean = False
        'Dim objEmpleado As Empleado = objDGEmpl.Item(indicedEmpleadoSeleccionado)

        If horasExtras.cantidadHoras.ToString() <> txtNumHorasExtras.Text.ToString() Then
            If insertCardex(motivo, horasExtras.idEmpleado, horasExtras.cantidadHoras,
                            txtNumHorasExtras.Text, "ControlHorasExtras", "cantidadHoras") Then
                Try
                    horasExtras.cantidadHoras = txtNumHorasExtras.Text
                    hayModificacion = True
                Catch ex As Exception
                    Mensaje.Mensaje = "Valor de horas Inválido..."
                    Mensaje.ShowDialog()
                    txtNumHorasExtras.Select()
                    Exit Sub
                End Try
            End If
        End If

        If Convert.ToBoolean(horasExtras.tienenHorasExtrasAut) <> Convert.ToBoolean(chbHorasExtrasAutorizadas.Checked) Then
            If insertCardex(motivo, horasExtras.idEmpleado, horasExtras.tienenHorasExtrasAut,
                            chbHorasExtrasAutorizadas.Checked, "ControlHorasExtras", "tienenHorasExtrasAut") Then
                horasExtras.tienenHorasExtrasAut = chbHorasExtrasAutorizadas.Checked
                hayModificacion = True
            End If
        End If

        If Convert.ToBoolean(horasExtras.forzarLimiteHorasExtras) <> Convert.ToBoolean(chbHorasLimiteHorasExtras.Checked) Then
            If insertCardex(motivo, horasExtras.idEmpleado, horasExtras.forzarLimiteHorasExtras,
                            chbHorasLimiteHorasExtras.Checked, "ControlHorasExtras", "forzarLimiteHorasExtras") Then
                horasExtras.forzarLimiteHorasExtras = chbHorasLimiteHorasExtras.Checked
                hayModificacion = True
            End If
        End If

        If hayModificacion Then
            If horasExtras.actualizar() Then
                Mensaje.Mensaje = "Se actualizarón los datos correctamente..."
                Mensaje.tipoMsj = TipoMensaje.Informacion
                cargaCardexHorasExtras()
            Else
                Mensaje.Mensaje = "Ocurrio un error: " & horasExtras.descripError
                Mensaje.tipoMsj = TipoMensaje.Error
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "No se realizó ningun cambio."
        End If
        Mensaje.ShowDialog()
    End Sub

    Private Sub CardexTiempoExtraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CardexTiempoExtraToolStripMenuItem.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_CardexHrsExtra(False, If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text)
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles bteModificarCardex.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_CardexHrsExtra(True, If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text)
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaterialRaisedButton1_Click_2(sender As Object, e As EventArgs) Handles bteInserRegisHO.Click
        Dim comentario As String = ""
        comentario = InputBox("Ingresa el comentario de los registros", "Comentario")
        If comentario = "" Then
            Mensaje.tipoMsj = TipoMensaje.Alerta
            Mensaje.Mensaje = "Proceso Cancelado"
            Mensaje.ShowDialog()
            Return
        End If

        If cbPeriodo.SelectedIndex <> -1 Then
            Dim idEmpl As Integer
            Try
                idEmpl = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            Catch ex As Exception
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = "Es necesario seleccionar un ""EMPLEADO"" para poder Insertar los registros..."
                Mensaje.ShowDialog()
                Exit Sub
            End Try

            If objCbPerido(cbPeriodo.SelectedIndex).spCRegistrosModeHO(idEmpl, comentario) Then
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Se insertarón correctamente los registros de (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado & ") """ & objDGEmpl.Item(indicedEmpleadoSeleccionado).nombreCompleto & """ en el periodo: " & objCbPerido(cbPeriodo.SelectedIndex).numeroPeriodo & " - " & objCbPerido(cbPeriodo.SelectedIndex).nombrePeriodo
                asigaXDG()
                contenTabs.SelectTab("tabReg")
            Else
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.Mensaje = objCbPerido(cbPeriodo.SelectedIndex).descripError
            End If
            Mensaje.ShowDialog()
        End If
    End Sub

End Class