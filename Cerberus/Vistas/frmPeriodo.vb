Public Class frmPeriodo
    Public Ambiente As AmbienteCls
    Private per As Periodo
    Private concep As ConceptoCuenta
    Private varform As VariableFormula
    Private objCBvarFormula As New List(Of VariableFormula)
    Private objDgvPer As New List(Of Periodo)
    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)
    Private nuevoReg As Boolean
    Public tabla As String
    Public elementoSistema As String

    Private objSincronizar As SincronizarContpaq
    Private objCBPeriodoCTPQ As New List(Of Integer)

    Dim forma As frmBuscaEmpleado

    Private Sub frmPeriodoFlujo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        per = New Periodo(Ambiente)
        per.tabla = tabla
        per.elementoSistema = elementoSistema
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.ejercicio = Now.Year

        varform = New VariableFormula(Ambiente)
        varform.idEmpresa = Ambiente.empr.idEmpresa

        btnComidaDuplicados.Visible = False
        btnModConcentradoPago.Visible = False
        btnImpConcentradoPago.Visible = False
        btnXPeriodo.Visible = False
        btnProcesarHorasExtras.Visible = False
        cbVarFormula.Enabled = False

        txtIDDep.Text = ""
        txtDescripDep.Text = ""
        btnBuscarDep.Enabled = False
        chbSoloPendientes.Enabled = False
        txtDesface.Text = 0

        cbPeriodoContpaqi.Visible = False
        txtDesface.Visible = False
        lblDesface.Visible = False
        lblPeriodos.Visible = False
        btnProcesarIncidencias.Visible = False

        If elementoSistema = "ES" Then
            btnProcesarHorasExtras.Visible = True
            cbVarFormula.Enabled = True
            varform.getComboActivo(cbVarFormula, objCBvarFormula)
            btnBuscarDep.Enabled = True
            chbSoloPendientes.Enabled = True
            btnProcesarIncidencias.Visible = True

            objSincronizar = New SincronizarContpaq(Ambiente)
            objSincronizar.getComboPeriodoCTPQ(cbPeriodoContpaqi, objCBPeriodoCTPQ, "")

            cbPeriodoContpaqi.Visible = True
            txtDesface.Visible = True
            lblDesface.Visible = True
            lblPeriodos.Visible = True
        ElseIf elementoSistema = "EFE" Then
            btnXPeriodo.Visible = True
        ElseIf elementoSistema = "CO" Then
            btnComidaDuplicados.Visible = True
            btnModConcentradoPago.Visible = True
            btnImpConcentradoPago.Visible = True

            btnModConcentradoAgrupado.Visible = True
            btnImprimirConcentradoAgrupado.Visible = True
        End If

        concep = New ConceptoCuenta(Ambiente)
        concep.idEmpresa = Ambiente.empr.idEmpresa

        per.cargaGridCom(DataGridView1, objDgvPer)
        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        lblStatus.Text = ""

        If Ambiente.usuario.desarrollador Then
            ModificarToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub asignaDatos()
        If nuevoReg Then
            per = New Periodo(Ambiente)
            per.tabla = tabla
            per.elementoSistema = elementoSistema
            per.idEmpresa = Ambiente.empr.idEmpresa
            per.inicioPeriodo = Now
            per.finPeriodo = Now
            per.esActivo = True
            btnCerrarPeriodo.Enabled = False
        End If

        txtNombre.Text = per.nombrePeriodo
        esActivo.Checked = per.esActivo
        DateTimePicker1.Value = per.inicioPeriodo
        DateTimePicker2.Value = per.finPeriodo
        txtNoPeriodo.Text = per.numeroPeriodo
        txtEjercicio.Text = per.ejercicio
        txtDesface.Text = per.desfaceCONTPAQ

        cbPeriodoContpaqi.SelectedIndex = -1
        For i As Integer = 0 To cbPeriodoContpaqi.Items.Count - 1
            If per.idPeriodoCTPQ = objCBPeriodoCTPQ(i) Then
                cbPeriodoContpaqi.SelectedIndex = i
            End If
        Next

        If per.esActivo Then
            btnCerrarPeriodo.Enabled = True
            btnProcesarHorasExtras.Enabled = True
            'btnImpXEmpl.Enabled = False
            btnComidaDuplicados.Enabled = True
            btnXPeriodo.Enabled = True
        Else
            btnComidaDuplicados.Enabled = False
            'btnImpXEmpl.Enabled = True
            btnProcesarHorasExtras.Enabled = False
            btnCerrarPeriodo.Enabled = False
            btnXPeriodo.Enabled = False
        End If

        lblStatus.Text = per.getDetalleMod()

        cbVarFormula.SelectedIndex = -1
        For i As Integer = 0 To cbVarFormula.Items.Count - 1
            If objCBvarFormula.Item(i).idVariableFormula = per.idVariableFormula Then
                cbVarFormula.SelectedIndex = i
                Exit For
            End If
        Next

        cbEmpresa.SelectedIndex = -1
        For i As Integer = 0 To cbEmpresa.Items.Count - 1
            If objCbEmpr.Item(i).idEmpresa = per.idEmpresa Then
                cbEmpresa.SelectedIndex = i
                Exit For
            End If
        Next

        cbSucursal.SelectedIndex = -1
        For i As Integer = 0 To cbSucursal.Items.Count - 1
            If objCbSuc.Item(i).idSucursal = per.idSucursal Then
                cbSucursal.SelectedIndex = i
                Exit For
            End If
        Next

        If per.idConceptoCuentaCargo <> Nothing Then
            concep.idConceptoCuenta = per.idConceptoCuentaCargo
            concep.buscarPID()
            txtIDCargo.Text = concep.idConceptoCuenta
            txtDescripConceptoCargo.Text = concep.nombreConceptoCuenta
        Else
            txtIDCargo.Text = ""
            txtDescripConceptoCargo.Text = ""
        End If

        If per.idConceptoCuentaAbono <> Nothing Then
            concep.idConceptoCuenta = per.idConceptoCuentaAbono
            concep.buscarPID()
            txtIDAbono.Text = concep.idConceptoCuenta
            txtDescripConceptoAbono.Text = concep.nombreConceptoCuenta
        Else
            txtIDAbono.Text = ""
            txtDescripConceptoAbono.Text = ""
        End If

    End Sub

    Private Sub obtenerDatos()
        per.nombrePeriodo = txtNombre.Text
        per.esActivo = esActivo.Checked
        per.inicioPeriodo = DateTimePicker1.Value
        per.finPeriodo = DateTimePicker2.Value
        per.numeroPeriodo = If(Not IsNumeric(txtNoPeriodo.Text), 0, txtNoPeriodo.Text)
        per.ejercicio = If(IsNumeric(txtEjercicio.Text), txtEjercicio.Text, 0)
        per.desfaceCONTPAQ = If(IsNumeric(txtDesface.Text), txtDesface.Text, 0)

        If cbPeriodoContpaqi.SelectedIndex <> -1 Then
            per.idPeriodoCTPQ = objCBPeriodoCTPQ(cbPeriodoContpaqi.SelectedIndex)
        Else
            per.idPeriodoCTPQ = Nothing
        End If

        If cbVarFormula.SelectedIndex <> -1 Then
            per.idVariableFormula = objCBvarFormula.Item(cbVarFormula.SelectedIndex).idVariableFormula
        Else
            per.idVariableFormula = Nothing
        End If

        If cbSucursal.SelectedIndex <> -1 Then
            per.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            per.idSucursal = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            per.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            per.idEmpresa = Nothing
        End If

        If txtIDCargo.Text <> Nothing Then
            per.idConceptoCuentaCargo = txtIDCargo.Text
        Else
            per.idConceptoCuentaCargo = Nothing
        End If

        If txtIDAbono.Text <> Nothing Then
            per.idConceptoCuentaAbono = txtIDAbono.Text
        Else
            per.idConceptoCuentaAbono = Nothing
        End If
    End Sub

    Private Sub clicDatos(indice As Integer)
        If indice <> -1 Then
            nuevoReg = False
            per = objDgvPer.Item(indice)
            asignaDatos()
        End If
    End Sub

    Private Sub habilitarBotones()
        If nuevoReg Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnSiguiente.Enabled = False
            btnAnterior.Enabled = False
            txtNombre.Select()

            btnCerrarPeriodo.Enabled = False
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
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nuevoReg = True
        asignaDatos()
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If Not txtEjercicio.MaskCompleted Then
            Mensaje.Mensaje = "Captura un ejercicio valido"
            Mensaje.ShowDialog()
            Exit Sub
        End If
        obtenerDatos()
        If nuevoReg Then
            If Not per.guardar() Then
                Mensaje.Mensaje = per.descripError
            Else
                Mensaje.Mensaje = "Se guardó correctamente el periodo"
                nuevoReg = False
            End If
        Else
            If Not per.actualizar() Then
                Mensaje.Mensaje = per.descripError
            Else
                Mensaje.Mensaje = "Se actualizó correctamente el periodo"
            End If
        End If
        Mensaje.ShowDialog()
        per.cargaGridCom(DataGridView1, objDgvPer)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As Integer
        Mensaje.Mensaje = "¿Seguro que deseas eliminar el Periodo: " & per.nombrePeriodo & "?"
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        respuesta = Mensaje.ShowDialog
        If respuesta = DialogResult.Yes Then
            per.eliminar()
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        frmComentario.tabla = "Periodo"
        frmComentario.idTabla = per.idPeriodo
        frmComentario.Ambiente = Ambiente
        frmComentario.ShowDialog()
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        frmArchivo.tabla = "Periodo"
        frmArchivo.idTabla = per.idPeriodo
        frmArchivo.Ambiente = Ambiente
        frmArchivo.elementoSistema = "Varios"
        frmArchivo.tipoArchivo = "Adjunto"
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        per.cargaGridCom(DataGridView1, objDgvPer)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        frmLogTransaccion.tabla = "Periodo"
        frmLogTransaccion.idTabla = per.idPeriodo
        frmLogTransaccion.Ambiente = Ambiente
        frmLogTransaccion.ShowDialog()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If DataGridView1.SelectedRows.Item(0).Index <> 0 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index - 1).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If DataGridView1.SelectedRows.Item(0).Index <> DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows(DataGridView1.SelectedRows.Item(0).Index + 1).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            clicDatos(DataGridView1.SelectedRows.Item(0).Index)
            habilitarBotones()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clicDatos(e.RowIndex)
        habilitarBotones()
        TabControl1.SelectTab(1)
    End Sub

    Private Sub XEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnImpXEmpl.Click
        Dim idDep As Integer
        Try
            idDep = txtIDDep.Text
        Catch ex As Exception
            idDep = Nothing
        End Try

        per.RPT_ImprimirDatos(idDep)
    End Sub

    Private Sub XEmpleadoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnModXEmpl.Click
        Dim idDep As Integer
        Try
            idDep = txtIDDep.Text
        Catch ex As Exception
            idDep = Nothing
        End Try

        per.RPT_ModificarDatos(idDep)
    End Sub

    Private Sub btnProcesarHorasExtras_Click(sender As Object, e As EventArgs) Handles btnProcesarHorasExtras.Click
        Dim idDep As Integer
        Try
            idDep = txtIDDep.Text
        Catch ex As Exception
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = "Es necesario seleccionar un ""DEPARTAMENTO"" para poder procesar los registros..."
            Mensaje.ShowDialog()
            Exit Sub
        End Try

        Mensaje.tipoMsj = TipoMensaje.Informacion
        If per.procesar("HEXT", idDep, Nothing, True) Then
            Mensaje.Mensaje = "Se proceso correctamente el periodo: " & per.numeroPeriodo & " - " & per.nombrePeriodo
            per.cargaGridCom(DataGridView1, objDgvPer)
        Else
            Mensaje.Mensaje = per.descripError
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnBuscarCargo_Click(sender As Object, e As EventArgs) Handles btnBuscarCargo.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxC"
        If elementoSistema = "ES" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "SYS"
        ElseIf elementoSistema = "CO" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "SYS"
        ElseIf elementoSistema = "EFE" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "EXE"
        End If

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDCargo.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConceptoCargo.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub btnBuscarAbono_Click(sender As Object, e As EventArgs) Handles btnBuscarAbono.Click
        frmBuscarConceptoCuenta.Ambiente = Ambiente
        frmBuscarConceptoCuenta.tipoCuenta = "CxP"
        If elementoSistema = "ES" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "SYS"
        ElseIf elementoSistema = "CO" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "SYS"
        ElseIf elementoSistema = "EFE" Then
            frmBuscarConceptoCuenta.tipoBusqueda = "EXE"
        End If

        If frmBuscarConceptoCuenta.ShowDialog() = DialogResult.OK Then
            txtIDAbono.Text = frmBuscarConceptoCuenta.valorRetorno.idConceptoCuenta
            txtDescripConceptoAbono.Text = frmBuscarConceptoCuenta.valorRetorno.nombreConceptoCuenta
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnComidaDuplicados.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If per.eliminarDuplicadosComida Then
            Mensaje.Mensaje = "Se procesaron correctamente los registros de comida duplicados: " & per.numeroPeriodo & " - " & per.nombrePeriodo
        Else
            Mensaje.Mensaje = per.descripError
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub btnModConcentradoPago_Click(sender As Object, e As EventArgs) Handles btnModConcentradoPago.Click
        per.RPT_ModificarDatosConcentrado()
    End Sub

    Private Sub btnImpConcentradoPago_Click(sender As Object, e As EventArgs) Handles btnImpConcentradoPago.Click
        per.RPT_ImprimirDatosConcentrado()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnXPeriodo.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If per.procesarCuentasXPeriodo() Then
            Mensaje.Mensaje = "Se proceso correctamente el periodo: " & per.numeroPeriodo & " - " & per.nombrePeriodo
            per.cargaGridCom(DataGridView1, objDgvPer)
        Else
            Mensaje.Mensaje = per.descripError
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBuscarDep.Click
        frmBuscaDepartamento.Ambiente = Ambiente

        If frmBuscaDepartamento.ShowDialog() = DialogResult.OK Then
            txtIDDep.Text = frmBuscaDepartamento.EmpleadoRetorno.idDepartamento
            txtDescripDep.Text = frmBuscaDepartamento.EmpleadoRetorno.nombreDepartamento
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIDDep.Text = Nothing
        txtDescripDep.Text = Nothing
    End Sub

    Private Sub btnProcesarIncidencias_Click(sender As Object, e As EventArgs) Handles btnProcesarIncidencias.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        per.procesarIncidencias(0)
        Mensaje.Mensaje = "Proceso concluido...!!"

        Mensaje.ShowDialog()
    End Sub

    Private Sub TotalCocinasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnImprimirConcentradoAgrupado.Click
        per.RPT_ImprimirDatosConcentradoAgrupado()
    End Sub

    Private Sub btnModConcentradoAgrupado_Click(sender As Object, e As EventArgs) Handles btnModConcentradoAgrupado.Click
        per.RPT_ModificarDatosConcentradoAgrupado()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles calculaXdep.Click
        Dim idDep As Integer
        Try
            idDep = txtIDDep.Text
        Catch ex As Exception
            idDep = Nothing
        End Try
        If idDep = Nothing Then
            Mensaje.tipoMsj = TipoMensaje.Pregunta
            Mensaje.Mensaje = "Al no seleccionar departamento el sistema procesara todos los departamentos de la empresa, ¿Desea continuar con este proceso?"
            If Mensaje.ShowDialog() <> DialogResult.Yes Then
                Exit Sub
            End If
        End If

        If idDep = Nothing Then
            Dim listDepartamentos = New List(Of Departamento)
            Dim departamento = New Departamento(Ambiente)
            departamento.getListByEmpresa(listDepartamentos)
            Dim mensajeStr As String
            Mensaje.tipoMsj = TipoMensaje.Informacion
            Mensaje.Mensaje = ""
            calculaXdep.Text = "Procesando...."
            For Each depa In listDepartamentos
                If per.procesar("EFE", depa.idDepartamento, Nothing, If(chbSoloPendientes.Checked, False, True)) Then
                    mensajeStr &= vbCrLf & "Se proceso correctamente el período en " & depa.nombreDepartamento & " : " & per.numeroPeriodo & " - " & per.nombrePeriodo
                Else
                    mensajeStr &= vbCrLf & "Error en: " & depa.nombreDepartamento & " - " & per.descripError
                    Mensaje.tipoMsj = TipoMensaje.Error
                End If
            Next
            per.cargaGridCom(DataGridView1, objDgvPer)
            calculaXdep.Text = "Calcular X dep/emp"
            Mensaje.Mensaje = mensajeStr
            Mensaje.ShowDialog()
        Else
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If per.procesar("EFE", idDep, Nothing, If(chbSoloPendientes.Checked, False, True)) Then
                Mensaje.Mensaje = "Se proceso correctamente el período: " & per.numeroPeriodo & " - " & per.nombrePeriodo
                If idDep = Nothing Then
                    per.cargaGridCom(DataGridView1, objDgvPer)
                End If
            Else
                Mensaje.Mensaje = per.descripError
            End If
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnProesar_Click(sender As Object, e As EventArgs) Handles btnCerrarPeriodo.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "El sistema procesara todos los empleados faltantes de procesar. CERRARÁ Y GENERARÁ LAS CXP del período, ¿Desea continuar con este proceso?"
        If Mensaje.ShowDialog() <> DialogResult.Yes Then
            Exit Sub
        End If
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If per.procesar("EFE", Nothing, Nothing, If(chbSoloPendientes.Checked, False, True)) Then
            Mensaje.Mensaje = "Se proceso correctamente el período: " & per.numeroPeriodo & " - " & per.nombrePeriodo
            per.cargaGridCom(DataGridView1, objDgvPer)
        Else
            Mensaje.Mensaje = per.descripError
        End If
        Mensaje.ShowDialog()
    End Sub
End Class