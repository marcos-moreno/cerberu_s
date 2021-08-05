Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary

Public Class frmPrincipal
    Public Ambiente As AmbienteCls
    Private objFrmCuenta1 As frmCuenta
    Private objFrmCuenta2 As frmCuenta
    Private objFrmCuenta3 As frmCuenta
    Private objFrmCuenta4 As frmCuenta
    Private objFrmEdoCuenta1 As frmEstadoCuenta
    Private objFrmEdoCuenta2 As frmEstadoCuenta
    Private objFrmES As frmPeriodo
    Private objFrmCO As frmPeriodo
    Private objFrmReg As frmRegistro
    Private objFrmReg2 As frmRegistrosV2
    Private objFrmLab As frmHorario
    Private per As Periodo
    Dim objRegPatronal As RegistroPatronal

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDetalle.Text = Ambiente.usuario.nombreCompleto & " | " & Ambiente.empr.nombreEmpresa & " | " & Ambiente.suc.nombreSucursal & " | " & Ambiente.conex.conexBuild(0).InitialCatalog & " | v1.4.0"
        Ambiente.accesoBotones.validaMenu("frmPrincipal", MenuStrip1)
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCEmpleado.Click
        frmCatalogo.Text = "..:: Buscar Empleado(s) ::.."
        frmCatalogo.lblValue.Text = "Valor: "

        Dim resultado As Integer
        resultado = frmCatalogo.ShowDialog()
        If resultado = DialogResult.OK Or resultado = DialogResult.Yes Then
            If IsNumeric(frmCatalogo.txtID.Text) Then
                frmEmpleado.idEmpleado = frmCatalogo.txtID.Text
            Else
                frmEmpleado.idEmpleado = 0
            End If

            frmEmpleado.value = frmCatalogo.txtValue.Text

            frmEmpleado.Ambiente = Ambiente
            frmEmpleado.MdiParent = Me
            frmEmpleado.Show()
            frmEmpleado.Activate()
            frmEmpleado.buscarPDialog(resultado)
        End If
    End Sub

    Private Sub frmPrincipal_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmSelecConexion.Dispose()
    End Sub

    Private Sub DispositivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDispositivo.Click
        frmDispositivo.Ambiente = Ambiente
        frmDispositivo.MdiParent = Me
        frmDispositivo.Show()
        frmDispositivo.Activate()
    End Sub

    Private Sub EventosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnMEventosDispo.Click
        frmEvento.Ambiente = Ambiente
        frmEvento.MdiParent = Me
        frmEvento.Show()
        frmEvento.Activate()
    End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDep.Click
        frmDepartamento.Ambiente = Ambiente
        frmDepartamento.MdiParent = Me
        frmDepartamento.Show()
        frmDepartamento.Activate()
    End Sub


    Private Sub EntradasYSalidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAEntradasSalidas.Click
        If objFrmReg Is Nothing OrElse (Not objFrmReg.IsHandleCreated) Then
            objFrmReg = New frmRegistro
        End If
        objFrmReg.Ambiente = Ambiente
        objFrmReg.elementoSistemas = "ES"
        objFrmReg.Text = " ..:: Mantenimiento a Registros de Entradas y Salidas ::.."
        objFrmReg.MdiParent = Me
        objFrmReg.Show()
        objFrmReg.Activate()
    End Sub

    Private Sub FlujoEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCPFlujo.Click
        frmPeriodo.Ambiente = Ambiente
        frmPeriodo.MdiParent = Me
        frmPeriodo.elementoSistema = "EFE"
        frmPeriodo.tabla = "Cuenta"
        frmPeriodo.Text = " ..:: Mantenimiento a Periodo de Flujos de Efectivo ::.."
        frmPeriodo.Show()
        frmPeriodo.Activate()
    End Sub

    Private Sub AsistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCPAsistencia.Click
        If objFrmES Is Nothing OrElse (Not objFrmES.IsHandleCreated) Then
            objFrmES = New frmPeriodo
        End If
        objFrmES.Ambiente = Ambiente
        objFrmES.MdiParent = Me
        objFrmES.elementoSistema = "ES"
        objFrmES.tabla = "Registro"
        objFrmES.Text = " ..:: Mantenimiento a Periodo de Asistencias ::.."
        objFrmES.Show()
        objFrmES.Activate()
    End Sub

    Private Sub CocinaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCPCocina.Click
        If objFrmCO Is Nothing OrElse (Not objFrmCO.IsHandleCreated) Then
            objFrmCO = New frmPeriodo
        End If
        objFrmCO.Ambiente = Ambiente
        objFrmCO.MdiParent = Me
        objFrmCO.elementoSistema = "CO"
        objFrmCO.tabla = "Registro"
        objFrmCO.Text = " ..:: Mantenimiento a Periodo de Cocinas ::.."
        objFrmCO.Show()
        objFrmCO.Activate()
    End Sub

    Private Sub FormulasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCFormula.Click
        frmFormula.Ambiente = Ambiente
        frmFormula.MdiParent = Me
        frmFormula.Show()
        frmFormula.Activate()
    End Sub

    Private Sub ComidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAComidas.Click
        frmRegistro.Ambiente = Ambiente
        frmRegistro.elementoSistemas = "CO"
        frmRegistro.Text = " ..:: Mantenimiento a Registros de Comidas en Cocinas ::.."
        frmRegistro.MdiParent = Me
        frmRegistro.Show()
        frmRegistro.Activate()
    End Sub

    Private Sub ConceptosCYAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCConceptoCA.Click
        frmConceptoCuenta.Ambiente = Ambiente
        frmConceptoCuenta.MdiParent = Me
        frmConceptoCuenta.Show()
        frmConceptoCuenta.Activate()
    End Sub

    Private Sub EntradasYSalidasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnCHLaboral.Click
        If objFrmLab Is Nothing OrElse (Not objFrmLab.IsHandleCreated) Then
            objFrmLab = New frmHorario
        End If
        objFrmLab.Ambiente = Ambiente
        objFrmLab.Text = "Horarios Laborales"
        objFrmLab.MdiParent = Me
        objFrmLab.tipoHorario = "LA"
        objFrmLab.tabla = "Empleado"
        objFrmLab.Show()
        objFrmLab.Activate()
    End Sub

    Private Sub CocinasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCHCocina.Click
        frmHorario.Ambiente = Ambiente
        frmHorario.Text = "Horarios de Cocina"
        frmHorario.MdiParent = Me
        frmHorario.tipoHorario = "CO"
        frmHorario.tabla = "Empleado"
        frmHorario.Show()
        frmHorario.Activate()
    End Sub

    Private Sub CocinasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnCCocinas.Click
        frmCocina.Ambiente = Ambiente
        frmCocina.MdiParent = Me
        frmCocina.Show()
        frmCocina.Activate()
    End Sub

    Private Sub TabuladoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCTabulador.Click
        frmTabulador.Ambiente = Ambiente
        frmTabulador.MdiParent = Me
        frmTabulador.Show()
        frmTabulador.Activate()
    End Sub

    Private Sub ClasificaciónDeEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDClasifEmpl.Click
        frmDestajoClasificacionEmpleado.Ambiente = Ambiente
        frmDestajoClasificacionEmpleado.MdiParent = Me
        frmDestajoClasificacionEmpleado.Show()
        frmDestajoClasificacionEmpleado.Activate()
    End Sub

    Private Sub ClasificaciónDePuntosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDClassPuntos.Click
        frmDestajoClasificacionPuntos.Ambiente = Ambiente
        frmDestajoClasificacionPuntos.MdiParent = Me
        frmDestajoClasificacionPuntos.Show()
        frmDestajoClasificacionPuntos.Activate()
    End Sub

    Private Sub EmpleadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnFCCEmpleado.Click
        If objFrmCuenta1 Is Nothing OrElse (Not objFrmCuenta1.IsHandleCreated) Then
            objFrmCuenta1 = New frmCuenta
        End If
        objFrmCuenta1.Ambiente = Ambiente
        objFrmCuenta1.Text = "Cuentas Por Pagar"
        objFrmCuenta1.MdiParent = Me
        objFrmCuenta1.tipoCuenta = "CxP"
        objFrmCuenta1.elemento = "Empleado"
        objFrmCuenta1.Show()
        objFrmCuenta1.Activate()
    End Sub

    Private Sub EmpleadosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles btnFCCxCEmpl.Click
        If objFrmCuenta2 Is Nothing OrElse (Not objFrmCuenta2.IsHandleCreated) Then
            objFrmCuenta2 = New frmCuenta
        End If
        objFrmCuenta2.Ambiente = Ambiente
        objFrmCuenta2.Text = "Cuentas Por Cobrar"
        objFrmCuenta2.MdiParent = Me
        objFrmCuenta2.tipoCuenta = "CxC"
        objFrmCuenta2.elemento = "Empleado"
        objFrmCuenta2.Show()
        objFrmCuenta2.Activate()
    End Sub

    Private Sub CocinasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles btnFCCCocina.Click
        If objFrmCuenta3 Is Nothing OrElse (Not objFrmCuenta3.IsHandleCreated) Then
            objFrmCuenta3 = New frmCuenta
        End If
        objFrmCuenta3.Ambiente = Ambiente
        objFrmCuenta3.Text = "Cuentas Por Pagar"
        objFrmCuenta3.MdiParent = Me
        objFrmCuenta3.tipoCuenta = "CxP"
        objFrmCuenta3.elemento = "Cocina"
        objFrmCuenta3.Show()
        objFrmCuenta3.Activate()
    End Sub

    Private Sub CocinasToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles btnFCCxCCocina.Click
        If objFrmCuenta4 Is Nothing OrElse (Not objFrmCuenta4.IsHandleCreated) Then
            objFrmCuenta4 = New frmCuenta
        End If
        objFrmCuenta4.Ambiente = Ambiente
        objFrmCuenta4.Text = "Cuentas Por Cobrar"
        objFrmCuenta4.MdiParent = Me
        objFrmCuenta4.tipoCuenta = "CxC"
        objFrmCuenta4.elemento = "Cocina"
        objFrmCuenta4.Show()
        objFrmCuenta4.Activate()
    End Sub

    Private Sub EmpleadosToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles btnFCCxPCxCAutEmpl.Click
        frmCuentasXPeriodo.Ambiente = Ambiente
        frmCuentasXPeriodo.MdiParent = Me
        frmCuentasXPeriodo.Show()
        frmCuentasXPeriodo.Activate()
    End Sub

    Private Sub EmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnFEEmpleado.Click
        If objFrmEdoCuenta1 Is Nothing OrElse (Not objFrmEdoCuenta1.IsHandleCreated) Then
            objFrmEdoCuenta1 = New frmEstadoCuenta
            objFrmEdoCuenta1.Text = "..:: Estados de Cuenta - EMPLEADOS ::.."
        End If
        objFrmEdoCuenta1.Ambiente = Ambiente
        objFrmEdoCuenta1.ShowDialog()
    End Sub

    Private Sub FactorDeBurbujaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDFacBurbuja.Click
        frmDestajoFactorBurbuja.Ambiente = Ambiente
        frmDestajoFactorBurbuja.MdiParent = Me
        frmDestajoFactorBurbuja.Show()
        frmDestajoFactorBurbuja.Activate()
    End Sub

    Private Sub DestajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDDestajo.Click
        frmDestajo.Ambiente = Ambiente
        frmDestajo.MdiParent = Me
        frmDestajo.Show()
        frmDestajo.Activate()
    End Sub

    Private Sub UniónDestajoEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCDunioonDE.Click
        frmDestajoUnionEmpleado.Ambiente = Ambiente
        frmDestajoUnionEmpleado.MdiParent = Me
        frmDestajoUnionEmpleado.Show()
        frmDestajoUnionEmpleado.Activate()
    End Sub

    Private Sub ConfiguracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCVConfig.Click
        frmTablaVacaciones.Ambiente = Ambiente
        frmTablaVacaciones.MdiParent = Me
        frmTablaVacaciones.Show()
        frmTablaVacaciones.Activate()
    End Sub

    Private Sub btnCAccesoM_Click(sender As Object, e As EventArgs) Handles btnCAccesoM.Click
        frmAccesoEmpleadoMenu.Ambiente = Ambiente
        frmAccesoEmpleadoMenu.MdiParent = Me
        frmAccesoEmpleadoMenu.Show()
        frmAccesoEmpleadoMenu.Activate()
    End Sub

    Private Sub AsignacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCVAsignaciones.Click
        frmControlVacaciones.Ambiente = Ambiente
        frmControlVacaciones.ShowDialog()
    End Sub

    Private Sub btnVisitaSucursal_Click(sender As Object, e As EventArgs) Handles btnVisitaSucursal.Click
        frmVisitaSucursal.Ambiente = Ambiente
        frmVisitaSucursal.MdiParent = Me
        frmVisitaSucursal.Show()
        frmVisitaSucursal.Activate()
    End Sub

    Private Sub RutaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnARuta.Click
        'Pedro Ramos Millán
        FrmRuta.Ambiente = Ambiente
        FrmRuta.MdiParent = Me
        FrmRuta.Show()
        FrmRuta.Activate()
    End Sub

    Private Sub BtnMetodoPago_Click(sender As Object, e As EventArgs) Handles BtnMetodoPago.Click
        'Pedro Ramos Millán
        FrmMetodoPagoRuta.Ambiente = Ambiente
        FrmMetodoPagoRuta.MdiParent = Me
        FrmMetodoPagoRuta.Show()
        FrmMetodoPagoRuta.Activate()
    End Sub

    Private Sub UnidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnUnidad.Click
        'Pedro Ramos Millán
        FrmUnidad.Ambiente = Ambiente
        FrmUnidad.MdiParent = Me
        FrmUnidad.Show()
        FrmUnidad.Activate()
    End Sub

    Private Sub btnCargas_Click(sender As Object, e As EventArgs) Handles btnCargas.Click
        'Pedro Ramos Millán
        FrmCargasGasolina.Ambiente = Ambiente
        FrmCargasGasolina.MdiParent = Me
        FrmCargasGasolina.Show()
        FrmCargasGasolina.Activate()
    End Sub

    Private Sub btnSocioNegocio_Click(sender As Object, e As EventArgs) Handles btnSocioNegocio.Click
        frmSocioNegocio.Ambiente = Ambiente
        frmSocioNegocio.MdiParent = Me
        frmSocioNegocio.Show()
        frmSocioNegocio.Activate()
    End Sub

    Private Sub btnFCAPrestamo_Click(sender As Object, e As EventArgs) Handles btnFCAPrestamo.Click
        frmPrestamo.Ambiente = Ambiente
        frmPrestamo.MdiParent = Me
        frmPrestamo.Show()
        frmPrestamo.Activate()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCVRVxDepImprimir.Click
        Dim ctrlVac As New ControlVacaciones(Ambiente)
        ctrlVac.imprimeDiasVacXDep()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCVRVxDepModificar.Click
        Dim ctrlVac As New ControlVacaciones(Ambiente)
        ctrlVac.modificarDiasVacXDep()
    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnCRImprimirReporte.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.imprimeReporteRegistros()
    End Sub

    Private Sub btnModificarReporte_Click(sender As Object, e As EventArgs) Handles btnCRModificarReporte.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.modificaReporteRegistros()
    End Sub

    Private Sub ImportarCATALOGOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnMICEICatalogos.Click
        frmImportarCONTPAQ.Ambiente = Ambiente
        frmImportarCONTPAQ.ShowDialog()
    End Sub

    Private Sub EnviarINCIDENCIASToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles btnMICEIncidencias.Click
        frmEnviaIncidencias.Ambiente = Ambiente
        frmEnviaIncidencias.ShowDialog()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles btnCIEmpleados.Click
        frmIncidencia.Ambiente = Ambiente
        frmIncidencia.ShowDialog()
    End Sub

    Private Sub btnCITiposInci_Click(sender As Object, e As EventArgs) Handles btnCITiposInci.Click
        frmTipoIncidencia.Ambiente = Ambiente
        frmTipoIncidencia.ShowDialog()
    End Sub

    Private Sub btnMRGCImprimir_Click(sender As Object, e As EventArgs) Handles btnMRGCImprimir.Click
        Ambiente.empr.RPT_ImprimirConfiguraciones()
    End Sub

    Private Sub btnMRGCModificar_Click(sender As Object, e As EventArgs) Handles btnMRGCModificar.Click
        Ambiente.empr.RPT_ModificarConfiguraciones()
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCEmpresa.Click
        frmEmpresa.Ambiente = Ambiente
        frmEmpresa.ShowDialog()
    End Sub

    Private Sub btnMCImss_Click(sender As Object, e As EventArgs) Handles btnMCImss.Click
        frmIMSS.Ambiente = Ambiente
        frmIMSS.ShowDialog()
    End Sub

    Private Sub btnMCFonacot_Click(sender As Object, e As EventArgs) Handles btnMCFonacot.Click
        frmFonacot.Ambiente = Ambiente
        frmFonacot.ShowDialog()
    End Sub

    Private Sub btnMCInfonavit_Click(sender As Object, e As EventArgs) Handles btnMCInfonavit.Click
        frmInfonavit.Ambiente = Ambiente
        frmInfonavit.ShowDialog()
    End Sub

    Private Sub btnMAcerca_Click(sender As Object, e As EventArgs) Handles btnMAcerca.Click
        frmAcercaDE.ShowDialog()
    End Sub

    Private Sub btnMRConvenios_Click(sender As Object, e As EventArgs) Handles btnMRConvenios.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.tabla = "Principal"
        frmArchivo.idTabla = Ambiente.empr.idEmpresa
        frmArchivo.ShowDialog()
    End Sub

    Private Sub btnCRegPatronal_Click(sender As Object, e As EventArgs) Handles btnCRegPatronal.Click

    End Sub

    Private Sub SucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnMCSucursal.Click
        frmSucursal.Ambiente = Ambiente
        frmSucursal.MdiParent = Me
        frmSucursal.Show()
        frmSucursal.Activate()
    End Sub

    Private Sub btnMRAModificar_Click(sender As Object, e As EventArgs) Handles btnMRAModificar.Click
        Dim cta As Cuenta
        cta = New Cuenta(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa
        cta.RPT_ModificarCuentasManuales()
    End Sub

    Private Sub btnMRAImprimir_Click(sender As Object, e As EventArgs) Handles btnMRAImprimir.Click
        Dim cta As Cuenta
        cta = New Cuenta(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa
        cta.RPT_ImprimirCuentasManuales()
    End Sub

    Private Sub btnMRPromerioDestajoMod_Click(sender As Object, e As EventArgs) Handles btnMRPromedioDestajoMod.Click
        Dim idEmpleado As Integer
        Dim objDesta As Destajo
        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = False
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            idEmpleado = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado
            objDesta = New Destajo(Ambiente)
            objDesta.idEmpresa = Ambiente.empr.idEmpresa
            objDesta.RPT_ModificarPromedioDestajo(idEmpleado)
        End If
    End Sub

    Private Sub btnMRPromerioDestajoImp_Click(sender As Object, e As EventArgs) Handles btnMRPromedioDestajoImp.Click
        Dim idEmpleado As Integer
        Dim objDesta As Destajo

        frmBuscaEmpleado.Ambiente = Ambiente
        frmBuscaEmpleado.soloActivos = False
        If frmBuscaEmpleado.ShowDialog() = DialogResult.OK Then
            idEmpleado = frmBuscaEmpleado.EmpleadoRetorno.idEmpleado

            objDesta = New Destajo(Ambiente)
            objDesta.idEmpresa = Ambiente.empr.idEmpresa
            objDesta.RPT_ImprimirPromedioDestajo(idEmpleado)
        End If
    End Sub

    Private Sub btnAEntradasSalidasV2_Click(sender As Object, e As EventArgs) Handles btnAEntradasSalidasV2.Click
        If objFrmReg2 Is Nothing OrElse (Not objFrmReg.IsHandleCreated) Then
            objFrmReg2 = New frmRegistrosV2
        End If
        objFrmReg2.Ambiente = Ambiente
        objFrmReg2.elementoSistemas = "ES"
        objFrmReg2.Text = " ..:: Mantenimiento a Registros de Entradas y Salidas ::.."
        objFrmReg2.MdiParent = Me
        objFrmReg2.Show()
        objFrmReg2.Activate()
    End Sub

    Private Sub btnCRespaldarBD_Click(sender As Object, e As EventArgs) Handles btnCRespaldarBD.Click
        Ambiente.respaldarBB()
    End Sub

    Private Sub btnMCNomina_Click(sender As Object, e As EventArgs) Handles btnMCNomina.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirConciliacion()
    End Sub

    Private Sub btnMCNominaMod_Click(sender As Object, e As EventArgs) Handles btnMCNominaMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarConciliacion()
    End Sub

    Private Sub btnMNLbancomer_Click(sender As Object, e As EventArgs) Handles btnMNLbancomer.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirLayoutBancomer()
    End Sub

    Private Sub btnMNLBancMod_Click(sender As Object, e As EventArgs) Handles btnMNLBancMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarLayoutBancomer()
    End Sub

    Private Sub btnMRPercepMod_Click(sender As Object, e As EventArgs) Handles btnMRPercepMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarPercepciones()
    End Sub

    Private Sub btnMRPercepciones_Click(sender As Object, e As EventArgs) Handles btnMRPercepciones.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirPercepciones()
    End Sub

    Private Sub btnMNLBanaMod_Click(sender As Object, e As EventArgs) Handles btnMNLBanaMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarLayoutBanamex()
    End Sub

    Private Sub btnMNLbanamex_Click(sender As Object, e As EventArgs) Handles btnMNLbanamex.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirLayoutBanamex()
    End Sub

    Private Sub btnMNLbanorte_Click(sender As Object, e As EventArgs) Handles btnMNLbanorte.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirLayoutBanorte()
    End Sub

    Private Sub btnMNLbanorteMod_Click(sender As Object, e As EventArgs) Handles btnMNLbanorteMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarLayoutBanorte()
    End Sub

    Private Sub btnMNLdosP_Click(sender As Object, e As EventArgs) Handles btnMNLdosP.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirDosP()
    End Sub

    Private Sub btnMNLdosPMod_Click(sender As Object, e As EventArgs) Handles btnMNLdosPMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarDosP()
    End Sub

    Private Sub btnMNPolizaMod_Click(sender As Object, e As EventArgs) Handles btnMNPolizaMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarPoliza()
    End Sub

    Private Sub btnMNPoliza_Click(sender As Object, e As EventArgs) Handles btnMNPoliza.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirPoliza()
    End Sub

    Private Sub btnMRSueldosMod_Click(sender As Object, e As EventArgs) Handles btnMRSueldosMod.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.modificaReporteSueldos()
    End Sub

    Private Sub btnMRSueldos_Click(sender As Object, e As EventArgs) Handles btnMRSueldos.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.imprimeReporteSueldos()
    End Sub

    Private Sub btnMRTabMod_Click(sender As Object, e As EventArgs) Handles btnMRTabMod.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.modificaReporteTabuladores()
    End Sub

    Private Sub btnMRTab_Click(sender As Object, e As EventArgs) Handles btnMRTab.Click
        If objRegPatronal Is Nothing Then
            objRegPatronal = New RegistroPatronal(Ambiente)
        End If

        objRegPatronal.imprimeReporteTabuladores()
    End Sub

    Private Sub btnMNNomXSemXSegMod_Click(sender As Object, e As EventArgs) Handles btnMNNomXSemXSegMod.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ModificarNomXSeg()
    End Sub

    Private Sub btnMNNomXSemXSeg_Click(sender As Object, e As EventArgs) Handles btnMNNomXSemXSeg.Click
        If per Is Nothing Then
            per = New Periodo(Ambiente)
        End If
        per.idEmpresa = Ambiente.empr.idEmpresa
        per.RPT_ImprimirNomXSeg()
    End Sub

    Private Sub btnCProducto_Click(sender As Object, e As EventArgs) Handles btnCProducto.Click
        frmProducto.Ambiente = Ambiente
        frmProducto.MdiParent = Me
        frmProducto.Show()
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCProveedor.Click
        frmProveedor.Ambiente = Ambiente
        frmProveedor.MdiParent = Me
        frmProveedor.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmCompras.Ambiente = Ambiente
        frmCompras.MdiParent = Me
        frmCompras.Show()
    End Sub

    Private Sub btnCProductoCompuesto_Click(sender As Object, e As EventArgs) Handles btnCProductoCompuesto.Click
        frmProductoCompuesto.Ambiente = Ambiente
        frmProductoCompuesto.MdiParent = Me
        frmProductoCompuesto.Show()
    End Sub

    Private Sub CaracterToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmCaracteristicaProd.Ambiente = Ambiente
        frmCaracteristicaProd.MdiParent = Me
        frmCaracteristicaProd.Show()
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click
        frmCompras.Ambiente = Ambiente
        frmCompras.MdiParent = Me
        frmCompras.Show()
    End Sub

    Private Sub btnEntregas_Click(sender As Object, e As EventArgs) Handles btnEntregas.Click
        frmEntregas.Ambiente = Ambiente
        frmEntregas.MdiParent = Me
        frmEntregas.Show()
    End Sub

    Private Sub IncrementosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIncrementos.Click
        frmIncrementos.Ambiente = Ambiente
        frmIncrementos.MdiParent = Me
        frmIncrementos.Show()
    End Sub

    Private Sub PuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnPuesto.Click
        frmPuestos.Ambiente = Ambiente
        frmPuestos.MdiParent = Me
        frmPuestos.Show()
    End Sub

    Private Sub btnMRPercepXPer_Click(sender As Object, e As EventArgs) Handles btnMRPercepXPer.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirPercepcionesXPeriodo()
    End Sub

    Private Sub btnMRPercepXPerMod_Click(sender As Object, e As EventArgs) Handles btnMRPercepXPerMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarPercepcionesXPeriodo()
    End Sub

    Private Sub btnMNSolEfectivo_Click(sender As Object, e As EventArgs) Handles btnMNSolEfectivo.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirFiniquitoDeuda()
    End Sub

    Private Sub btnMNSolEfectivoMod_Click(sender As Object, e As EventArgs) Handles btnMNSolEfectivoMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarFiniquitoDeuda()
    End Sub

    Private Sub btnMRTabuladores_Click(sender As Object, e As EventArgs) Handles btnMRTabuladores.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirEstatus()
    End Sub

    Private Sub btnMRTabuladoresMod_Click(sender As Object, e As EventArgs) Handles btnMRTabuladoresMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarEstatus()
    End Sub

    Private Sub btnMNEfectivoMod_Click(sender As Object, e As EventArgs) Handles btnMNEfectivoMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarPagoTerceros()
    End Sub

    Private Sub btnMNEfectivo_Click(sender As Object, e As EventArgs) Handles btnMNEfectivo.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirPagoTerceros()
    End Sub

    Private Sub FiniquitosAEntregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnFiniqEntregar.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirFiniquitosEntregar()
    End Sub

    Private Sub ModicarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnFiniqEntregarModicar.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarFiniquitosEntregar()
    End Sub

    Private Sub ComportamientoDeExcedentesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCompExcedent.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirComportamientoFiniq()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles btnCompExcedentMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarComportamientoFiniq()
    End Sub


    Private Sub btnOCRPT_Click(sender As Object, e As EventArgs) Handles btnOCRPT.Click
        Dim cta As Cuenta
        cta = New Cuenta(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa
        cta.RPT_ImprimirRPTUniformesOrdenCompra()
    End Sub

    Private Sub btnOCRPTMod_Click(sender As Object, e As EventArgs) Handles btnOCRPTMod.Click
        Dim cta As Cuenta
        cta = New Cuenta(Ambiente)
        cta.idEmpresa = Ambiente.empr.idEmpresa
        cta.RPT_ModificarRPTUniformesOrdenCompra()
    End Sub

    Private Sub btnTallasRPT_Click(sender As Object, e As EventArgs) Handles btnTallasRPT.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirRPTUniformesTallas()
    End Sub

    Private Sub btnTallasRPTmod_Click(sender As Object, e As EventArgs) Handles btnTallasRPTmod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarRPTUniformesTallas()
    End Sub

    Private Sub bteTelefonia_Click(sender As Object, e As EventArgs) Handles bteTelefonia.Click
        frmTelefonia.Ambiente = Ambiente
        frmTelefonia.MdiParent = Me
        frmTelefonia.Show()
    End Sub

    Private Sub SincronizarCxPDestajosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteSincronizarCxPDestajos.Click
        frmSincCxPAdempiere.ambiente = Ambiente
        frmSincCxPAdempiere.MdiParent = Me
        frmSincCxPAdempiere.Show()
    End Sub


    'REPORTE CREDENCIALES
    Private Sub btnRPTCredenciales_Click(sender As Object, e As EventArgs) Handles btnRPTCredenciales.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ImprimirCredenciales()

    End Sub

    Private Sub btnRPTCredencialesMod_Click(sender As Object, e As EventArgs) Handles btnRPTCredencialesMod.Click
        Dim cta As New Cuenta(Ambiente)
        cta.RPT_ModificarCredenciales()
    End Sub

    'END REPORTE CREDENCIALES

    Private Sub EstaciónDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnEstacionTbj.Click
        frmActivarLicencia.Ambiente = Ambiente
        frmActivarLicencia.MdiParent = Me
        frmActivarLicencia.Show()
    End Sub

    Private Sub ProcesarIncidenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteProcesarIncidencias.Click
        frmProcesaIncidenciasGen.Ambiente = Ambiente
        frmProcesaIncidenciasGen.MdiParent = Me
        frmProcesaIncidenciasGen.Show()
    End Sub

    Private Sub bteReporteGenTelefonia_Click(sender As Object, e As EventArgs) Handles bteReporteGenTelefonia.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TelefoniaGen(False)
    End Sub

    Private Sub bteReporteGenTelefoniaMod_Click(sender As Object, e As EventArgs) Handles bteReporteGenTelefoniaMod.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_TelefoniaGen(True)
    End Sub

    Private Sub bteActualizar_Click(sender As Object, e As EventArgs) Handles bteActualizar.Click
        Dim startInfo = New ProcessStartInfo("actualizador.exe")
        startInfo.Verb = "runas"
        Process.Start(startInfo)
        Me.Close()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteChangePassword.Click
        frmCambioPassword.Ambiente = Ambiente
        frmCambioPassword.MdiParent = Me
        frmCambioPassword.Show()
    End Sub

    Private Sub SueldoEnCxPPorPorcentajeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btmSueldoCxPporcentaje.Click
        frmCxPCalculoPorcentaje.Context = Ambiente
        frmCxPCalculoPorcentaje.MdiParent = Me
        frmCxPCalculoPorcentaje.Show()
    End Sub

    Private Sub mnuChequeFiniquito_Click(sender As Object, e As EventArgs) Handles mnuChequeFiniquito.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_Cheques_Finiquito(False)
    End Sub

    Private Sub ModificarmnuChequeFiniquito_Click(sender As Object, e As EventArgs) Handles ModificarmnuChequeFiniquito.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_Cheques_Finiquito(True)
    End Sub

    Private Sub RenovaciónDeContraroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteMenuRenovacionContrato.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_RenovacionContrato(False)
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles bteMenuRenovacionContratoMod.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_RenovacionContrato(True)
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteExportar.Click
        frmExportarInformacion.Context = Ambiente
        frmExportarInformacion.Table = "Empleado"
        frmExportarInformacion.MdiParent = Me
        frmExportarInformacion.Show()
    End Sub

    Private Sub ImportadorDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btImportadorCuentas.Click
        frmImportador.Context = Ambiente
        frmImportador.MdiParent = Me
        frmImportador.Show()
    End Sub

    Private Sub bte3pExtra_Click(sender As Object, e As EventArgs) Handles bte3pExtra.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_3p_extraordinario(False)
    End Sub

    Private Sub bte3pExtraModificar_Click(sender As Object, e As EventArgs) Handles bte3pExtraModificar.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_3p_extraordinario(True)
    End Sub

    Private Sub btePolizapExtra_Click(sender As Object, e As EventArgs) Handles btePolizapExtra.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_poliza_Nomina_extraordinario(False)
    End Sub

    Private Sub btePolizapExtraModificar_Click(sender As Object, e As EventArgs) Handles btePolizapExtraModificar.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_poliza_Nomina_extraordinario(True)
    End Sub

    Private Sub BteEmpleEmpreSuc_Click(sender As Object, e As EventArgs) Handles bteEmpleEmpreSuc.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_EmpleEmpreSuc(False)
    End Sub

    Private Sub BteEmpleEmpreSucMod_Click(sender As Object, e As EventArgs) Handles bteEmpleEmpreSucMod.Click
        Dim reportesGenerales As New ReportesGenerales(Ambiente)
        reportesGenerales.RPT_EmpleEmpreSuc(True)
    End Sub
End Class