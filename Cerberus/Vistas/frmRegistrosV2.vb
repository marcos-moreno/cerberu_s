Imports Cerberus

Public Class frmRegistrosV2
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
    Private objCBTIncidencia As New List(Of TipoIncidencia)

    Private horasExtras As ControlHorasExtras
    Private objVisita As VisitaSucursal

    Private diaActivo As Integer

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmpleado.SelectionChanged
        asigaXDG()
    End Sub

    Private Sub asigaXDG()
        If dgvEmpleado.SelectedRows.Count > 0 Then
            indicedEmpleadoSeleccionado = dgvEmpleado.SelectedRows.Item(0).Cells(0).Value
            asignarDatos(cbPeriodo.SelectedIndex, False)
        Else
            indicedEmpleadoSeleccionado = -1
        End If
    End Sub

    Private Sub frmAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        indicedEmpleadoSeleccionado = -1

        reg = New Registro(Ambiente)
        reg.idEmpresa = Ambiente.empr.idEmpresa

        objVisita = New VisitaSucursal(Ambiente)

        tInci = New TipoIncidencia(Ambiente)
        tInci.idEmpresa = Ambiente.empr.idEmpresa
        tInci.cargaGridGen(dgvTipoIncidencia, objCBTIncidencia)

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

        If elementoSistemas = "CO" Then
            If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
                calculosCO.Parent = TabControl1
            End If

            btnProcesarHorasExtras.Visible = False
        End If

        If elementoSistemas = "ES" Then
            btnProcesarHorasExtras.Visible = True
            btnRegInvalidos.Visible = True
            btnIIncidencias.Visible = True

            If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
                calculosES.Parent = TabControl1
            End If
        Else
            btnRegInvalidos.Visible = False
            btnIIncidencias.Visible = False
        End If

        If Ambiente.usuario.desarrollador Then
            btnIRModificar.Visible = True
            btnIRDEModificar.Visible = True
            btnIRDPModificar.Visible = True
        End If

        'SELECCIONAR LA SEMANA ACTUAL
        For i As Integer = 0 To objCbPerido.Count - 1
            If objCbPerido.Item(i).inicioPeriodo <= Now.Date And objCbPerido.Item(i).finPeriodo >= Now.Date Then
                cbPeriodo.SelectedIndex = i
            End If
        Next

        diaActivo = 0
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

        cargado = False
        objEmp.cargarGridXDepXPeriodo(dgvEmpleado, idDep, txtFiltro.Text.Trim, objDGEmpl, dtpFechaInicial.Value, dtpFechaFinal.Value)
        cargado = True

        If dgvEmpleadosADD.Columns.Count = 0 Then
            Dim dgvc As DataGridViewColumn

            For i As Integer = 0 To dgvEmpleado.ColumnCount - 1
                dgvc = dgvEmpleado.Columns.Item(i).Clone
                dgvEmpleadosADD.Columns.Add(dgvc)
            Next
        End If

        dgvEmpleadoCopy.DataSource = dgvEmpleado.DataSource
    End Sub


    Private Sub asignarDatos(indice As Integer, soloRegistros As Boolean)
        cambios.Clear()

        If indice <> -1 And cargado And indicedEmpleadoSeleccionado <> -1 Then

            Dim idEmpleado As Integer

            idEmpleado = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            lblSeleccion.Text = "PIN: (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado & ") - " & UCase(objDGEmpl.Item(indicedEmpleadoSeleccionado).nombreCompleto) & " VD: (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).diasVacacionesDisponibles & ")"

            'dtpFechaInicial.Value = objCbPerido.Item(indice).inicioPeriodo
            'dtpFechaFinal.Value = objCbPerido.Item(indice).finPeriodo
            perido = objCbPerido.Item(indice)

            rangoPerido = perido.getDiasRango()

            horasExtras.idEmpleado = idEmpleado
            horasExtras.idPeriodo = perido.idPeriodo
            cargaHorasExtras()

            lbl1.Text = UCase(Format(rangoPerido.Item(diaActivo), "dddd dd / MMMM / yyyy"))
            reg.cargaGridXFechaEmpl(dgvRegsDia, idEmpleado, rangoPerido.Item(diaActivo), objDia1, elementoSistemas, False)

            Dim idDepFilto As Integer
            If cbDepartamento.SelectedIndex <> -1 Then
                idDepFilto = objCBDep(cbDepartamento.SelectedIndex).idDepartamento
            Else
                idDepFilto = 0
            End If

            If Not soloRegistros Then
                objCbPerido.Item(indice).inicioPeriodo = dtpFechaInicial.Value
                objCbPerido.Item(indice).finPeriodo = dtpFechaFinal.Value

                objCbPerido.Item(indice).cargaGridRegistrosESXPeriodo(dgvPeriodo, idEmpleado)
            End If

            If elementoSistemas = "ES" Then
                cargaResultados(idEmpleado)
            ElseIf elementoSistemas = "CO" Then
                cargaResultadosCO(idEmpleado)
            End If

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
        If cbPeriodo.SelectedIndex <> -1 Then
            CargarGid()
            dtpFechaInicial.Value = objCbPerido(cbPeriodo.SelectedIndex).inicioPeriodo
            dtpFechaInicial.Value = objCbPerido(cbPeriodo.SelectedIndex).finPeriodo
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
            Mensaje.Mensaje = "Favor de seleccionar Un Dispositivo..."
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
        asigaXDG()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            buscar()
        End If
    End Sub

    Private Sub dgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellDoubleClick
        asigaXDG()
        TabControl1.SelectTab(1)
    End Sub

    ''ASD
    'Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
    '    Mensaje.tipoMsj = TipoMensaje.Informacion
    '    If cbTipoIncidencia.SelectedIndex = -1 Then
    '        Mensaje.Mensaje = "Favor de Seleccionar un tipo de Incidencia Válido.."
    '        Mensaje.ShowDialog()
    '        Exit Sub
    '    End If

    '    objInciXDia.Item(indicePeriodo).idTipoIncidencia = objCBTIncidencia.Item(cbTipoIncidencia.SelectedIndex).idTipoIncidencia
    '    objInciXDia.Item(indicePeriodo).idDepartamento = objDGEmpl(indicedEmpleadoSeleccionado).idDepartamento
    '    objInciXDia.Item(indicePeriodo).nombreLider = objDGEmpl(indicedEmpleadoSeleccionado).getDepartamento.nombreLider

    '    If objInciXDia.Item(indicePeriodo).idIncidencia = Nothing Then
    '        If objInciXDia.Item(indicePeriodo).guardar() Then
    '            Mensaje.Mensaje = "Se guardo correctamente la Incidencia..."
    '        Else
    '            Mensaje.Mensaje = Ambiente.conex.Qry & "  " & objInciXDia.Item(indicePeriodo).descripError
    '        End If
    '    Else
    '        If objInciXDia.Item(indicePeriodo).actualizar() Then
    '            Mensaje.Mensaje = "Se actualizo correctamente la Incidencia..."
    '        Else
    '            Mensaje.Mensaje = objInciXDia.Item(indicePeriodo).descripError
    '        End If
    '    End If

    '    Mensaje.ShowDialog()

    '    habilitaBotonesInci(False)
    'End Sub

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
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirDatosRegistros(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text, objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado)
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIRModificar.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarDatosRegistros(If(cbDepartamento.SelectedIndex <> -1, objCBDep(cbDepartamento.SelectedIndex).idDepartamento, 0), txtFiltro.Text, objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado)
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
        End If
    End Sub

    Private Sub RegSiguienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnRegSiguiente.Click
        If dgvEmpleado.SelectedRows.Item(0).Index <> dgvEmpleado.Rows.Count - 1 Then
            dgvEmpleado.Rows(dgvEmpleado.SelectedRows.Item(0).Index + 1).Selected = True
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
                        Mensaje.Mensaje = "La baja del Empleado se ha procesado correctamente..."
                        CargarGid()
                    End If
                Else
                    Mensaje.Mensaje = conVac.descripError
                End If
            End If
        End If

        Mensaje.ShowDialog()
    End Sub

    ''ASD
    'Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnEliminarInci.Click
    '    Mensaje.tipoMsj = TipoMensaje.Informacion
    '    If objInciXDia.Item(indicePeriodo).eliminar() Then
    '        Mensaje.Mensaje = "Se Elimino correctamente la Incidencia..."
    '    Else
    '        Mensaje.Mensaje = objInciXDia.Item(indicePeriodo).descripError
    '    End If
    '    Mensaje.ShowDialog()

    '    habilitaBotonesInci(False)
    'End Sub

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
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ImprimirDatosIncidenciaEmpleado(objDGEmpl(indicedEmpleadoSeleccionado).idEmpleado)
        End If
    End Sub

    Private Sub btnProcesarHorasExtras_Click(sender As Object, e As EventArgs) Handles btnProcesarHorasExtras.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            Dim idEmpl As Integer
            Try
                idEmpl = objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado
            Catch ex As Exception
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.Mensaje = "Es necesario seleccionar un ""EMPLEADO"" para poder procesar los registros..."
                Mensaje.ShowDialog()
                Exit Sub
            End Try

            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objCbPerido(cbPeriodo.SelectedIndex).procesar("HEXT", Nothing, idEmpl, True) Then
                Mensaje.Mensaje = "Se procesaron correctamente los registros de (" & objDGEmpl.Item(indicedEmpleadoSeleccionado).idEmpleado & ") """ & objDGEmpl.Item(indicedEmpleadoSeleccionado).nombreCompleto & """ en el periodo: " & objCbPerido(cbPeriodo.SelectedIndex).numeroPeriodo & " - " & objCbPerido(cbPeriodo.SelectedIndex).nombrePeriodo
                asigaXDG()
            Else
                Mensaje.Mensaje = objCbPerido(cbPeriodo.SelectedIndex).descripError
            End If

            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnIRDEModificar_Click(sender As Object, e As EventArgs) Handles btnIRDEModificar.Click
        If cbPeriodo.SelectedIndex <> -1 Then
            objCbPerido(cbPeriodo.SelectedIndex).RPT_ModificarDatosIncidenciaEmpleado(objDGEmpl(indicedEmpleadoSeleccionado).idEmpleado)
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

    Private Sub btnActHorasExtras_Click(sender As Object, e As EventArgs) Handles btnActHorasExtras.Click
        Dim habilitar As Boolean
        habilitar = False

        Mensaje.tipoMsj = TipoMensaje.Informacion

        Try
            horasExtras.cantidadHoras = txtNumHorasExtras.Text
        Catch ex As Exception
            Mensaje.Mensaje = "Valor de horas Inválido..."
            Mensaje.ShowDialog()
            txtNumHorasExtras.Select()
            Exit Sub
        End Try

        horasExtras.tienenHorasExtrasAut = chbHorasExtrasAutorizadas.Checked
        horasExtras.forzarLimiteHorasExtras = chbHorasLimiteHorasExtras.Checked

        If horasExtras.actualizar() Then
            Mensaje.Mensaje = "Se actualizaron los datos..."
        Else
            Mensaje.Mensaje = "Ocurrio un error: " & horasExtras.descripError
        End If

        Mensaje.ShowDialog()
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

        txtNumHorasExtras.Enabled = habilitar
        chbHorasExtrasAutorizadas.Enabled = habilitar
        chbHorasLimiteHorasExtras.Enabled = habilitar
        btnActHorasExtras.Enabled = habilitar
    End Sub

    Private Sub cbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamento.SelectedIndexChanged
        If cbPeriodo.SelectedIndex <> -1 Then
            CargarGid()
            asignarDatos(cbPeriodo.SelectedIndex, False)
        End If
    End Sub


    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        frmImportar.Ambiente = Ambiente
        frmImportar.tabla = "Registro"
        frmImportar.valor1 = "ES"
        frmImportar.ShowDialog()
    End Sub

    Private Sub dgvPeriodo_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPeriodo.SelectionChanged
        If cbPeriodo.SelectedIndex <> -1 Then
            If dgvPeriodo.SelectedRows.Count > 0 Then
                diaActivo = dgvPeriodo.SelectedRows(0).Index
                asignarDatos(cbPeriodo.SelectedIndex, True)
            End If
        End If
    End Sub
End Class