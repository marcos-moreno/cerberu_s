Imports Cerberus

Public Class FrmCargasGasolina
    Implements InterfaceVentanas

    Public Ambiente As AmbienteCls
    Private objGasolina As CargasGasolina
    Private ReadOnly objDGVCargasGasolina As New List(Of CargasGasolina)
    Private ReadOnly objCBPeriodo As New List(Of Periodo)
    Private objPeriodo As Periodo
    Private inicioPeriodo As Date
    Private finPeriodo As Date

    Private objExcel As Excel
    Private fechaFinalEditable As String

    Public Sub asignaDatos() Implements InterfaceVentanas.asignaDatos
        TxtVehiculo.Text = objGasolina.vehiculo
        Txtplacas.Text = objGasolina.placa
        TxtDescripcion.Text = objGasolina.descripcion
        TxtGrupo.Text = objGasolina.grupo
        TxtEstacion.Text = objGasolina.estacion
        txtFechaYHora.Text = Format(objGasolina.fechaYhora, "yyyy-MM-dd HH:mm:ss")
        txtPocision.Text = objGasolina.pocision
        txtProducto.Text = objGasolina.producto
        txtCantidad.Text = objGasolina.cantidad
        txtMonto.Text = objGasolina.monto
        txtDespacho.Text = objGasolina.despacho
        txtEstado.Text = objGasolina.getNombreEstado()
        txtEstado.BackColor = objGasolina.getColorEstado()
        chbProcesado.Checked = objGasolina.procesada

        Dim objCuenta As New Cuenta(Ambiente)
        objCuenta.idCuenta = objGasolina.idCuenta

        If objCuenta.buscarPID() Then
            DtpFechaCuenta.Value = objCuenta.fechaCuenta
        End If

        txtNoCuenta.Text = objCuenta.noDocumento
        txtMontoCuenta.Text = objCuenta.monto

        If objGasolina.generaCobro Then
            rbCobroSi.Checked = True
        Else
            rbCobroNo.Checked = True
        End If

        txtDescuento.Text = objGasolina.porcentajeDescuento

        Dim objEmpleado As New Empleado(Ambiente)
        objEmpleado.idEmpleado = objGasolina.asignadoA
        objEmpleado.buscarPID()

        txtIdAsignadoA.Text = objEmpleado.idEmpleado
        txtNombreAsignadoA.Text = objEmpleado.nombreCompleto

        Dim objUnidad As New Unidad(Ambiente)
        objUnidad.idUnidad = objGasolina.idUnidad
        objUnidad.buscarPID()

        txtPlaca.Text = objUnidad.placa
        txtNombreUnidad.Text = objUnidad.marca & " " & objUnidad.modelo

        habilitarBotones()
    End Sub

    Public Sub obtenerDatos() Implements InterfaceVentanas.obtenerDatos

        Dim filtro As String = "Archivos de Excel (*.xls)|*.xls"
        Dim tituloVentana = "Eliga un archivo de EXCEL para importar..."

        Mensaje.tipoMsj = TipoMensaje.Informacion
        OpenFileDialog1.Filter = filtro
        OpenFileDialog1.Title = tituloVentana
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            Dim miValorEntrada = InputBox("¿Qué hoja se importará?", "Nombre de hoja a importar", "Hoja1")
            If miValorEntrada = Nothing Then
                'Usuario canceló
            Else
                If objGasolina.importarDesdeExcel(OpenFileDialog1.FileName, miValorEntrada) Then

                    cargarGrid()

                    Mensaje.Mensaje = "Se importó correctamente el archivo de Excel...."
                    Mensaje.ShowDialog()
                Else
                    Mensaje.tipoMsj = TipoMensaje.Error
                    Mensaje.Mensaje = objGasolina.descripError
                    Mensaje.ShowDialog()
                End If
            End If
        End If
    End Sub

    Public Sub clicDatos(indice As Integer) Implements InterfaceVentanas.clicDatos
        TabGasolina.SelectedIndex = 1
        objGasolina = objDGVCargasGasolina.Item(indice)
        asignaDatos()

        fechaFinalEditable = txtFechaYHora.Text
    End Sub

    Public Sub habilitarBotones() Implements InterfaceVentanas.habilitarBotones
        Dim valor As Boolean

        If objGasolina.idCuenta = Nothing Then
            valor = True
            txtDescuento.ReadOnly = False
        Else
            valor = False
            txtDescuento.ReadOnly = True
        End If

        DtpFechaCuenta.Enabled = valor
        BtnGenerarCxp.Enabled = valor
        btnEmpleado.Enabled = valor
        btnEliminarEmpleado.Enabled = valor
        rbCobroSi.Enabled = valor
        rbCobroNo.Enabled = valor
    End Sub

    Private Sub ImportarExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarExcelToolStripMenuItem.Click
        obtenerDatos()
    End Sub

    Private Sub FrmGasolina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objGasolina = New CargasGasolina(Ambiente)
        objGasolina.idEmpresa = Ambiente.empr.idEmpresa
        cargarGrid()
        objPeriodo = New Periodo(Ambiente)

        cargarComboPeriodo()
        cargarComboFiltro()

    End Sub

    Private Sub gdgvGasolina_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvGasolina.CellFormatting
        'Se le da color a las celdas de acuerdo a la condición
        If dgvGasolina.Columns(e.ColumnIndex).Name = "Estado" Then
            If Me.dgvGasolina.Columns(e.ColumnIndex).Name = "Estado" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If valor = "COBRADO" Or valor = "SIN COBRO" Then
                        e.CellStyle.BackColor = Color.LightGreen
                    ElseIf valor = "NO COBRADO" Or valor = "CANCELADA" Then
                        e.CellStyle.BackColor = Color.LightSalmon
                    Else
                        e.CellStyle.BackColor = Color.Salmon
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cargarComboFiltro()
        Dim arrayElementos(4) As String
        arrayElementos(0) = "TODOS"
        arrayElementos(1) = "COBRADO"
        arrayElementos(2) = "NO COBRADO"
        arrayElementos(3) = "SIN COBRO"
        arrayElementos(4) = "CANCELADO"
        For Each elemento In arrayElementos
            CmbFiltro.Items.Add(elemento)
        Next
        CmbFiltro.SelectedItem = "TODOS"
    End Sub

    Private Sub cargarComboPeriodo()
        objPeriodo.idEmpresa = objGasolina.idEmpresa
        objPeriodo.elementoSistema = "EFE"
        objPeriodo.tabla = "Cuenta"
        objPeriodo.ejercicio = Now.Year
        objPeriodo.getDiasRango()
        objPeriodo.getComboTodos(CmbPeriodo, objCBPeriodo)

        CmbPeriodo.SelectedIndex = CmbPeriodo.Items.Count - 1
    End Sub

    Private Sub dgvGasolina_CellDoubleCick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGasolina.CellDoubleClick
        If dgvGasolina.SelectedRows.Count > 0 Then
            clicDatos(dgvGasolina.SelectedRows.Item(0).Index)
        End If
    End Sub

    Private Sub BtnGenerarCxp_Click(sender As Object, e As EventArgs) Handles BtnGenerarCxp.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion

        If objGasolina.generarCuentaxP(DtpFechaCuenta.Value) Then
            Mensaje.Mensaje = "Se genero correctamente la cuenta"
            asignaDatos()
        Else
            Mensaje.Mensaje = objGasolina.descripError
        End If

        Mensaje.ShowDialog()
    End Sub

    Private Sub CmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFiltro.SelectedIndexChanged
        cargarGrid()
    End Sub

    Private Function GetParametroFiltro(selectedIndex As Integer) As String

        CmbFiltro.SelectedText = 0

        Select Case (selectedIndex)
            Case 0
                Return ""
            Case 1
                Return "CB"
            Case 2
                Return "NC"
            Case 3
                Return "SC"
            Case 4
                Return "CA"
            Case Else
                Return ""
        End Select
    End Function

    Private Sub CmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPeriodo.SelectedIndexChanged

        inicioPeriodo = objCBPeriodo(CmbPeriodo.SelectedIndex).inicioPeriodo
        finPeriodo = objCBPeriodo(CmbPeriodo.SelectedIndex).finPeriodo

        cargarGrid()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Mensaje.tipoMsj = TipoMensaje.Pregunta
        Mensaje.Mensaje = "¿Realmente desea " & If(objGasolina.estadoDocumento = "BO", "Eliminar ", "Cancelar ") & "esta Carga de gasolina?"

        If Mensaje.ShowDialog = DialogResult.Yes Then
            Mensaje.tipoMsj = TipoMensaje.Informacion
            If objGasolina.eliminar Then
                Mensaje.Mensaje = "Se eliminó/canceló la carga de gasolina seleccionada..."
                TabGasolina.SelectedIndex = 0
            Else
                Mensaje.Mensaje = objGasolina.descripError
            End If
            cargarGrid()
            Mensaje.ShowDialog()
        End If
    End Sub

    Private Sub cargarGrid()
        objGasolina.cargarGridComp(objDGVCargasGasolina, dgvGasolina, GetParametroFiltro(CmbFiltro.SelectedIndex), inicioPeriodo, finPeriodo, txtFiltro.Text)
    End Sub

    Private Sub AdjuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntosToolStripMenuItem.Click
        cargarGrid()
    End Sub

    Private Sub btnEliminarEmpleado_Click(sender As Object, e As EventArgs) Handles btnEliminarEmpleado.Click
        txtIdAsignadoA.Text = ""
        txtNombreAsignadoA.Text = ""
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = True
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            txtIdAsignadoA.Text = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            txtNombreAsignadoA.Text = frmBuscaEmpleado.EmpleadoRetorno.nombreCompleto
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            inicioPeriodo = objCBPeriodo(CmbPeriodo.SelectedIndex).inicioPeriodo
            finPeriodo = objCBPeriodo(CmbPeriodo.SelectedIndex).finPeriodo

            cargarGrid()
        End If
    End Sub

End Class