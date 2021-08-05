Public Class frmEmpleado
    Private objEmpl As Empleado
    Private objDgEmp As New List(Of Empleado)

    Private objCbEmpr As New List(Of Empresa)
    Private objCbSuc As New List(Of Sucursal)

    Private objCbRegimenFiscal As New List(Of RegimenFiscal)
    Private objRegimenFiscal As RegimenFiscal

    Private objCocina As Cocina
    Private objCbCocina As New List(Of Cocina)

    Private objDepartamento As Departamento
    Private objCbDepartamento As New List(Of Departamento)

    Private objNivelPuesto As NivelPuesto
    Private listNivelPuesto As New List(Of NivelPuesto)

    Private objTabulador As Tabulador
    Private objCbTabulador As New List(Of Tabulador)

    Private objUMF As UMF
    Private objCbUMF As New List(Of UMF)

    Private objPuesto As Puesto
    Private objCBPuesto As New List(Of Puesto)

    Private objLugarNacimiento As LugarNacimiento
    Private objCbLugarNacimiento As New List(Of LugarNacimiento)

    Private objCbArea As New List(Of Area)
    Private objBanco As Banco

    Private objHorario As Horario
    Private objCbHorario As New List(Of Horario)
    Private objCbHorarioComida As New List(Of Horario)

    Private objCbRegatronal As New List(Of RegistroPatronal)
    Private objRegPatronal As RegistroPatronal

    Public idEmpleado As Integer
    Public value As String
    Public Ambiente As AmbienteCls

    Private indiceSeleccion As Integer
    Private eventoActual As Integer

    Private cargado As Boolean
    Private soloActivos As Boolean

    Private objDesClaPun As DestajoClasificacionPuntos
    Private objCBDesClaPun As New List(Of DestajoClasificacionPuntos)
    Private objDesClaEmpl As DestajoClasificacionEmpleado
    Private objCBDesClaEmpl As New List(Of DestajoClasificacionEmpleado)
    Private objCBBanco As New List(Of Banco)

    Private objSueldoIMSS As SueldosIMSS
    Private objFactorInt As FactorIntegracion

    Private objCBSueldoIMSS As New List(Of SueldosIMSS)
    Private objCBFactorIntegracion As New List(Of FactorIntegracion)


    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bteAtivarEmpleado.Visible = False
        objEmpl = New Empleado(Ambiente)
        objEmpl.idEmpresa = Ambiente.empr.idEmpresa


        objNivelPuesto = New NivelPuesto(Ambiente)
        objNivelPuesto.getComboNivelPuesto(cbNivelPuesto, listNivelPuesto)

        'COMBOS
        Ambiente.empr.getComboActivo(cbEmpresa, objCbEmpr)
        Ambiente.suc.getComboActivo(cbSucursal, objCbSuc)

        objCocina = New Cocina(Ambiente)
        objCocina.idEmpresa = Ambiente.empr.idEmpresa
        objCocina.getComboActivo(cbCocina, objCbCocina)

        objDepartamento = New Departamento(Ambiente)
        objDepartamento.idEmpresa = Ambiente.empr.idEmpresa
        objDepartamento.getComboActivo(cbDepartamento, objCbDepartamento)

        objTabulador = New Tabulador(Ambiente)
        objTabulador.idEmpresa = Ambiente.empr.idEmpresa
        objTabulador.getComboActivo(cbTabulador, objCbTabulador)

        objUMF = New UMF(Ambiente)
        objUMF.getComboUMF(cbUMF, objCbUMF)

        objPuesto = New Puesto(Ambiente)
        objPuesto.idEmpresa = Ambiente.empr.idEmpresa
        objPuesto.getCombo(cbPuesto, objCBPuesto)

        objLugarNacimiento = New LugarNacimiento(Ambiente)
        objLugarNacimiento.getCombo(cbLugarNacimiento, objCbLugarNacimiento)

        objHorario = New Horario(Ambiente)
        objHorario.idEmpresa = Ambiente.empr.idEmpresa
        objHorario.tipoHorario = "LA"
        objHorario.tabla = "Empleado"
        objHorario.getComboActivo(cbHorario, objCbHorario)

        'objHorario.tipoHorario = "CO"
        'objHorario.getComboActivo(cbHorarioComida, objCbHorarioComida)

        objRegPatronal = New RegistroPatronal(Ambiente)
        objRegPatronal.idEmpresa = Ambiente.empr.idEmpresa
        objRegPatronal.getComboActivo(cbRegPatronal, objCbRegatronal)

        objDesClaPun = New DestajoClasificacionPuntos(Ambiente)
        objDesClaPun.idEmpresa = Ambiente.empr.idEmpresa
        objDesClaPun.getComboActivo(cbClasificacionPuntosDestajo, objCBDesClaPun)

        objDesClaEmpl = New DestajoClasificacionEmpleado(Ambiente)
        objDesClaEmpl.idEmpresa = Ambiente.empr.idEmpresa
        objDesClaEmpl.getComboActivo(cbDestajoClasificacionEmpleado, objCBDesClaEmpl)

        objBanco = New Banco(Ambiente)
        objBanco.getCombo(cbBancoPago, objCBBanco)

        objFactorInt = New FactorIntegracion(Ambiente)
        objFactorInt.idEmpresa = Ambiente.empr.idEmpresa
        objFactorInt.getComboActivo(cbFactorDeIntegracion, objCBFactorIntegracion)

        Ambiente.accesoBotones.validaMenu("frmEmpleado", MenuStrip1)

        'If Ambiente.empr.rfcEmpresa.Trim <> "RTP1810192I3" Or Ambiente.empr.rfcEmpresa.Trim = "RICM9012159B5" Then
        '    btnContratoDet.Visible = False
        'End If

        If Not Ambiente.usuario.desarrollador Then
            btnModKardex.Visible = False
            btnModAtributos.Visible = False
            btnAltaIMSSMod.Visible = False
            btnBajaIMSSMod.Visible = False
            btnModIMSSMod.Visible = False
        End If

        objRegimenFiscal = New RegimenFiscal(Ambiente)
        objRegimenFiscal.idEmpresa = Ambiente.empr.idEmpresa
        objRegimenFiscal.getCombo(cbRegFiscal, objCbRegimenFiscal)

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex <> -1 Then
            TabControl1.SelectTab(1)
            indiceSeleccion = e.RowIndex
            eventoActual = 1
            asignarDatos(indiceSeleccion, objDgEmp.Item(indiceSeleccion))
        End If
    End Sub

    Private Sub asignarDatos(indice As Integer, objEmp As Empleado)
        If Not cargado Or indice = -1 Then
            txtNombre.Text = ""
            txtApPaterno.Text = ""
            txtApMaterno.Text = ""
            'Es Deudor
            CheckDeudor.Checked = False
            esNomina100p.Checked = False

            txtUsuario.Text = ""
            txtPass.Text = ""

            lblStatus.Text = ""
            txtPassZk.Text = ""
            txtRFC.Text = ""
            txtNSS.Text = ""
            txtTarjeta.Text = ""
            txtDiasVacacionesDisponibles.Text = ""
            txtCorreoEmpresa.Text = ""
            txtCorreoPersonal.Text = ""
            txtCurp.Text = ""
            txtCLABEPago.Text = ""
            txtSucursalPago.Text = ""
            txtCuentaPago.Text = ""
            txtIDEmpleado.Text = "0"

            picRostro.Image = Image.FromFile("Images\faceDisabled.jpg")
            picHD0.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHD1.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHD2.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHD3.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHD4.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHI5.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHI6.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHI7.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHI8.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            picHI9.Image = Image.FromFile("Images\huella-digitalDisabled.png")

            esActivo.Checked = True
            esSupervisor.Checked = False

            cbCocina.SelectedIndex = -1
            cbDepartamento.SelectedIndex = -1

            cbEmpresa.SelectedIndex = -1
            For i As Integer = 0 To cbEmpresa.Items.Count - 1
                If objCbEmpr.Item(i).idEmpresa = Ambiente.empr.idEmpresa Then
                    cbEmpresa.SelectedIndex = i
                    Exit For
                End If
            Next

            'Regimen Fiscal
            cbRegFiscal.SelectedIndex = -1


            cbHorario.SelectedIndex = -1
            'cbHorarioComida.SelectedIndex = -1
            cbSucursal.SelectedIndex = -1
            cbTabulador.SelectedIndex = -1
            cbTipoUsuario.SelectedIndex = -1
            cbPerfilCalculo.SelectedIndex = -1
            cbDestajoClasificacionEmpleado.SelectedIndex = -1
            cbClasificacionPuntosDestajo.SelectedIndex = -1
            cbTipoUsuarioSistema.SelectedIndex = 0
            cbRegPatronal.SelectedIndex = -1
            cbUMF.SelectedIndex = -1
            cbLugarNacimiento.SelectedIndex = -1
            cbPuesto.SelectedIndex = -1
            cbGenero.SelectedIndex = 0
            cbBancoPago.SelectedIndex = -1
            cbSueldoIMSS.SelectedIndex = -1

            If listNivelPuesto.Count > 0 Then
                cbNivelPuesto.SelectedIndex = 0
            End If

            cbFactorDeIntegracion.SelectedIndex = 0

            chbTieneHorasExtraAut.Checked = False
            chbForzarLimite.Checked = False
            chbNoBorrarMisIncidencias.Checked = False
            txtCantidadHoras.Text = 0
            txtSueldoSemIMSS.Text = 0
            '   dtpFechaNacimiento
            chbFonacot.Checked = False
            chbInfonavit.Checked = False

            dtpFechaNacimiento.Value = Now
            dtpFechaAlta.Value = Now
            txtFechaBaja.Text = Format(objEmp.fechaBaja, "dd/MM/yyyy HH:mm:ss")
            txtExcedente.Text = FormatCurrency(0)
            txtSD.Text = FormatCurrency(0)
            txtSDI.Text = 0

            cbEstadoCivil.SelectedIndex = -1
            cbEscolaridad.SelectedIndex = -1
            txtNombreMadre.Text = ""
            txtNombrePadre.Text = ""

            txtTelContacto.Text = ""
            txtTelRed.Text = ""
            cbCompania.SelectedItem = ""
            txtContratoBancario.Text = ""
            txtNumCreditoInfonavit.Text = ""
            cbFactorInfonavit.SelectedItem = ""
            txtRetencionInfonavit.Text = ""
            txttelCasa.Text = ""
            txt_no_cheque.Text = ""
            txtMotivoContratacion.Text = ""

            btnFonacot.Enabled = False


        Else
            txtIDEmpleado.Text = objEmp.idEmpleado
            CheckDeudor.Checked = objEmp.esDeudor
            esNomina100p.Checked = objEmp.esNomina100p

            txtNombre.Text = objEmp.nombreEmpleado
            txtApPaterno.Text = objEmp.apPatEmpleado
            txtApMaterno.Text = objEmp.apMatEmpleado
            dtpFechaAlta.Value = objEmp.fechaAlta
            txtFechaBaja.Text = Format(objEmp.fechaBaja, "dd/MM/yyyy HH:mm:ss")
            txtExcedente.Text = FormatCurrency(objEmp.getTabulador.getVersionActual.sueldo - objEmp.sueldoSemanalIMSS)

            txtCorreoEmpresa.Text = objEmp.correoEmpresa
            txtCorreoPersonal.Text = objEmp.correoPersonal

            txtUsuario.Text = objEmp.usuario
            txtPass.Text = objEmp.password

            lblStatus.Text = objEmp.getDetalleMod
            esActivo.Checked = objEmp.esActivo
            esSupervisor.Checked = objEmp.esSupervisor
            chbNoBorrarMisIncidencias.Checked = objEmp.noBorrarMisIncidencias
            txtPassZk.Text = objEmp.pwdZK

            txtRFC.Text = objEmp.rfc
            txtNSS.Text = objEmp.nss
            txtTarjeta.Text = objEmp.numeroTarjeta
            txtCurp.Text = objEmp.curp
            txtSD.Text = FormatCurrency(objEmp.SD)
            txtSDI.Text = objEmp.SDI

            txtCLABEPago.Text = objEmp.clabePago
            txtSucursalPago.Text = objEmp.sucursalPago
            txtCuentaPago.Text = objEmp.numCuentaPago

            chbFonacot.Checked = objEmp.tieneFonacot
            txttelCasa.Text = objEmp.telcasa
            txt_no_cheque.Text = RTrim(LTrim(objEmp.no_cheque))
            txtMotivoContratacion.Text = objEmp.motivoContratacion

            If chbFonacot.Checked Then
                btnFonacot.Enabled = True
            Else
                btnFonacot.Enabled = False
            End If

            chbInfonavit.Checked = objEmp.tieneInfonavit

            If objEmp.rostro.Length > 0 Then
                Dim arch As New Archivo(Ambiente)
                arch.tabla = "Empleado"
                arch.tipoArchivo = "Foto"
                arch.elementoSistema = "FotoReloj"
                arch.idTabla = objEmp.idEmpleado
                arch.idEmpresa = objEmp.idEmpresa

                If arch.buscarArchivoPTblIdTTipoArchivoElem Then
                    picRostro.Image = arch.ByteToImage()

                Else
                    picRostro.Image = Image.FromFile("Images\face.jpg")
                End If
            Else
                picRostro.Image = Image.FromFile("Images\faceDisabled.jpg")
            End If

            If objEmp.huella0.Length > 0 Then
                picHD0.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHD0.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella1.Length > 0 Then
                picHD1.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHD1.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella2.Length > 0 Then
                picHD2.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHD2.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella3.Length > 0 Then
                picHD3.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHD3.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella4.Length > 0 Then
                picHD4.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHD4.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella5.Length > 0 Then
                picHI5.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHI5.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella6.Length > 0 Then
                picHI6.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHI6.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella7.Length > 0 Then
                picHI7.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHI7.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella8.Length > 0 Then
                picHI8.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHI8.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            If objEmp.huella9.Length > 0 Then
                picHI9.Image = Image.FromFile("Images\huella-digital.png")
            Else
                picHI9.Image = Image.FromFile("Images\huella-digitalDisabled.png")
            End If

            cbBancoPago.SelectedIndex = -1
            For i As Integer = 0 To cbBancoPago.Items.Count - 1
                If objCBBanco.Item(i).codigoSAT = objEmp.bancoPago Then
                    cbBancoPago.SelectedIndex = i
                    Exit For
                End If
            Next

            cbEmpresa.SelectedIndex = -1
            For i As Integer = 0 To cbEmpresa.Items.Count - 1
                If objCbEmpr.Item(i).idEmpresa = objEmp.idEmpresa Then
                    cbEmpresa.SelectedIndex = i
                    Exit For
                End If
            Next

            cbCocina.SelectedIndex = -1
            For i As Integer = 0 To cbCocina.Items.Count - 1
                If objCbCocina.Item(i).idCocina = objEmp.idCocina Then
                    cbCocina.SelectedIndex = i
                    Exit For
                End If
            Next

            cbDepartamento.SelectedIndex = -1
            For i As Integer = 0 To cbDepartamento.Items.Count - 1
                If objCbDepartamento.Item(i).idDepartamento = objEmp.idDepartamento Then
                    cbDepartamento.SelectedIndex = i
                    Exit For
                End If
            Next

            cbHorario.SelectedIndex = -1
            For i As Integer = 0 To cbHorario.Items.Count - 1
                If objCbHorario.Item(i).idHorario = objEmp.idHorario Then
                    cbHorario.SelectedIndex = i
                    Exit For

                End If
            Next

            'cbHorarioComida.SelectedIndex = -1
            'For i As Integer = 0 To cbHorarioComida.Items.Count - 1
            '    If objCbHorarioComida.Item(i).idHorario = objEmp.idHorarioComida Then
            '        cbHorarioComida.SelectedIndex = i
            '        Exit For

            '    End If
            'Next

            cbSucursal.SelectedIndex = -1
            For i As Integer = 0 To cbSucursal.Items.Count - 1
                If objCbSuc.Item(i).idSucursal = objEmp.idSucursal Then
                    cbSucursal.SelectedIndex = i
                    Exit For
                End If
            Next

            cbPerfilCalculo.SelectedItem = objEmp.perfilCalculo

            '============Tabulador con base al Nivel
            'objTabulador = New Tabulador(Ambiente)
            'objTabulador.idEmpresa = Ambiente.empr.idEmpresa
            'objTabulador.getComboActivoPorNivel(cbTabulador,
            '                            objCbTabulador,
            '                            objEmp.idNivelPuesto,
            '                            objEmp.idTabulador)

            cbTabulador.SelectedIndex = -1
            For i As Integer = 0 To cbTabulador.Items.Count - 1
                If objCbTabulador.Item(i).idTabulador = objEmp.idTabulador Then
                    cbTabulador.SelectedIndex = i
                    Exit For
                End If
            Next
            '============@Tabulador con base al Nivel 

            cbSueldoIMSS.SelectedIndex = -1
            For i As Integer = 0 To cbSueldoIMSS.Items.Count - 1
                If objCBSueldoIMSS.Item(i).idSueldoIMSS = objEmp.idSueldoIMSS Then
                    cbSueldoIMSS.SelectedIndex = i
                    Exit For
                End If
            Next

            cbNivelPuesto.SelectedIndex = -1
            For i As Integer = 0 To cbNivelPuesto.Items.Count - 1
                If listNivelPuesto.Item(i).idNivelPuesto = objEmp.idNivelPuesto Then
                    cbNivelPuesto.SelectedIndex = i
                    Exit For
                End If
            Next

            cbFactorDeIntegracion.SelectedIndex = -1
            For i As Integer = 0 To cbFactorDeIntegracion.Items.Count - 1
                If objCBFactorIntegracion.Item(i).idFactorIntegracion = objEmp.idFactorIntegracion Then
                    cbFactorDeIntegracion.SelectedIndex = i
                    Exit For

                End If
            Next

            cbClasificacionPuntosDestajo.SelectedIndex = -1
            For i As Integer = 0 To cbClasificacionPuntosDestajo.Items.Count - 1
                If objCBDesClaPun.Item(i).idDestajoClasificacionPuntos = objEmp.idDestajoClasificacionPuntos Then
                    cbClasificacionPuntosDestajo.SelectedIndex = i
                    Exit For
                End If
            Next

            cbDestajoClasificacionEmpleado.SelectedIndex = -1
            For i As Integer = 0 To cbDestajoClasificacionEmpleado.Items.Count - 1
                If objCBDesClaEmpl.Item(i).idDestajoClasificacionEmpeado = objEmp.idDestajoClasificacionEmpeado Then
                    cbDestajoClasificacionEmpleado.SelectedIndex = i
                    Exit For
                End If
            Next

            cbArea.SelectedIndex = -1
            For i As Integer = 0 To cbArea.Items.Count - 1
                If objCbArea.Item(i).idArea = objEmp.idArea Then
                    cbArea.SelectedIndex = i
                    Exit For
                End If
            Next

            cbUMF.SelectedIndex = -1
            For i As Integer = 0 To cbUMF.Items.Count - 1
                If objCbUMF.Item(i).idUMF = objEmp.idUMF Then
                    cbUMF.SelectedIndex = i
                    Exit For
                End If
            Next

            cbPuesto.SelectedIndex = -1
            For i As Integer = 0 To cbPuesto.Items.Count - 1
                If objCBPuesto.Item(i).idPuesto = objEmp.idPuesto Then
                    cbPuesto.SelectedIndex = i
                    Exit For
                End If
            Next

            cbLugarNacimiento.SelectedIndex = -1
            For i As Integer = 0 To cbLugarNacimiento.Items.Count - 1
                If objCbLugarNacimiento.Item(i).idLugarNacimiento = objEmp.idLugarNacimiento Then
                    cbLugarNacimiento.SelectedIndex = i
                    Exit For
                End If
            Next

            cbRegPatronal.SelectedIndex = -1
            For i As Integer = 0 To cbRegPatronal.Items.Count - 1
                If objCbRegatronal.Item(i).idRegistroPatronal = objEmp.idRegistroPatronal Then
                    cbRegPatronal.SelectedIndex = i
                    Exit For
                End If
            Next

            'MGM=====Regimen Fiscal 
            cbRegFiscal.SelectedIndex = -1
            For i As Integer = 0 To cbRegFiscal.Items.Count - 1
                If objCbRegimenFiscal.Item(i).idRegimen = objEmp.idRegimenFiscal Then
                    cbRegFiscal.SelectedIndex = i
                    Exit For
                End If
            Next
            Try
                dtpFechacambioReg.Value = objEmp.fechacambioReg
            Catch ex As Exception

            End Try

            '=========


            cbGenero.SelectedItem = objEmp.genero
            dtpFechaNacimiento.Value = objEmp.fechaNacimiento
            chbTieneHorasExtraAut.Checked = objEmp.tieneHorasExtrasAut
            chbForzarLimite.Checked = objEmp.forzarLimiteHorasExtras
            txtCantidadHoras.Text = objEmp.cantidadHoras
            txtSueldoSemIMSS.Text = objEmp.sueldoSemanalIMSS
            cbTipoUsuarioSistema.SelectedItem = objEmp.tipoUsuarioSistema
            txtDiasVacacionesDisponibles.Text = objEmp.diasVacacionesDisponibles

            cbTipoUsuario.SelectedIndex = If(objEmp.idTipoUsuario = 3, 1, 0)

            cbEstadoCivil.SelectedItem = objEmp.estadoCivil
            cbEscolaridad.SelectedItem = objEmp.escolaridad
            txtNombreMadre.Text = objEmp.nombreMadre
            txtNombrePadre.Text = objEmp.nombrePadre

            txtTelContacto.Text = objEmp.telcontacto
            txtTelRed.Text = objEmp.telred
            cbCompania.SelectedItem = objEmp.compania
            txtContratoBancario.Text = objEmp.nocontratobancario
            txtNumCreditoInfonavit.Text = objEmp.numcreditoinfonavit
            cbFactorInfonavit.SelectedItem = objEmp.factordescuentoinfonavit
            txtRetencionInfonavit.Text = objEmp.retencioninfonavit

            If objEmp.esActivo = 0 Then
                bteAtivarEmpleado.Visible = True
            Else
                bteAtivarEmpleado.Visible = False
            End If


        End If

            habilitaBotones()
    End Sub

    Private Sub obtenerDatos(objEmp As Empleado)

        If IsNumeric(txtIDEmpleado.Text) Then
            If objEmp.idEmpleado <> txtIDEmpleado.Text Then
                objEmp.nuevoID = txtIDEmpleado.Text
            Else
                objEmp.nuevoID = Nothing
            End If
        End If

        objEmp.nombreEmpleado = txtNombre.Text
        objEmp.apPatEmpleado = txtApPaterno.Text
        objEmp.apMatEmpleado = txtApMaterno.Text

        objEmp.usuario = txtUsuario.Text
        objEmp.password = txtPass.Text
        objEmp.numeroTarjeta = txtTarjeta.Text
        objEmp.idTipoUsuario = If(cbTipoUsuario.SelectedIndex = 1, 3, 0)
        objEmp.creadoPor = Ambiente.usuario.idEmpleado
        objEmp.actualizadoPor = Ambiente.usuario.idEmpleado
        objEmp.pwdZK = txtPassZk.Text
        objEmp.esActivo = esActivo.Checked
        objEmp.esSupervisor = esSupervisor.Checked
        objEmp.noBorrarMisIncidencias = chbNoBorrarMisIncidencias.Checked
        objEmp.rfc = txtRFC.Text
        objEmp.nss = txtNSS.Text
        objEmp.sueldoSemanalIMSS = If(txtSueldoSemIMSS.Text = "", 0, txtSueldoSemIMSS.Text)
        objEmp.fechaAlta = dtpFechaAlta.Value
        objEmp.tipoUsuarioSistema = cbTipoUsuarioSistema.SelectedItem
        objEmp.correoEmpresa = txtCorreoEmpresa.Text
        objEmp.correoPersonal = txtCorreoPersonal.Text
        objEmp.curp = txtCurp.Text
        objEmp.fechaNacimiento = dtpFechaNacimiento.Value
        objEmp.SDI = txtSDI.Text
        objEmp.genero = cbGenero.SelectedItem
        objEmp.sucursalPago = txtSucursalPago.Text
        objEmp.numCuentaPago = txtCuentaPago.Text
        objEmp.clabePago = txtCLABEPago.Text
        objEmp.tieneFonacot = chbFonacot.Checked
        objEmp.tieneInfonavit = chbInfonavit.Checked
        objEmp.telcasa = txttelCasa.Text
        objEmp.no_cheque = RTrim(LTrim(txt_no_cheque.Text))
        objEmp.motivoContratacion = txtMotivoContratacion.Text
        objEmp.esDeudor = CheckDeudor.Checked
        objEmp.esNomina100p = esNomina100p.Checked
        If cbBancoPago.SelectedIndex <> -1 Then
            objEmp.bancoPago = objCBBanco.Item(cbBancoPago.SelectedIndex).codigoSAT
        Else
            objEmp.bancoPago = Nothing
        End If

        If cbEmpresa.SelectedIndex <> -1 Then
            objEmp.idEmpresa = objCbEmpr.Item(cbEmpresa.SelectedIndex).idEmpresa
        Else
            objEmp.idEmpresa = Nothing
        End If

        If cbSucursal.SelectedIndex <> -1 Then
            objEmp.idSucursal = objCbSuc.Item(cbSucursal.SelectedIndex).idSucursal
        Else
            objEmp.idSucursal = Nothing
        End If

        If cbCocina.SelectedIndex <> -1 Then
            objEmp.idCocina = objCbCocina.Item(cbCocina.SelectedIndex).idCocina
        Else
            objEmp.idCocina = Nothing
        End If

        If cbHorario.SelectedIndex <> -1 Then
            objEmp.idHorario = objCbHorario.Item(cbHorario.SelectedIndex).idHorario
        Else
            objEmp.idHorario = Nothing
        End If

        'If cbHorarioComida.SelectedIndex <> -1 Then
        '    objEmp.idHorarioComida = objCbHorarioComida.Item(cbHorarioComida.SelectedIndex).idHorario
        'Else
        '    objEmp.idHorarioComida = Nothing
        'End If

        If cbTabulador.SelectedIndex <> -1 Then
            objEmp.idTabulador = objCbTabulador.Item(cbTabulador.SelectedIndex).idTabulador
        Else
            objEmp.idTabulador = Nothing
        End If

        If cbDepartamento.SelectedIndex <> -1 Then
            objEmp.idDepartamento = objCbDepartamento.Item(cbDepartamento.SelectedIndex).idDepartamento
        Else
            objEmp.idDepartamento = Nothing
        End If

        If cbPerfilCalculo.SelectedIndex <> -1 Then
            objEmp.perfilCalculo = cbPerfilCalculo.SelectedItem
        Else
            objEmp.perfilCalculo = Nothing
        End If

        If cbClasificacionPuntosDestajo.SelectedIndex <> -1 Then
            objEmp.idDestajoClasificacionPuntos = objCBDesClaPun.Item(cbClasificacionPuntosDestajo.SelectedIndex).idDestajoClasificacionPuntos
        Else
            objEmp.idDestajoClasificacionPuntos = Nothing
        End If

        If cbDestajoClasificacionEmpleado.SelectedIndex <> -1 Then
            objEmp.idDestajoClasificacionEmpeado = objCBDesClaEmpl.Item(cbDestajoClasificacionEmpleado.SelectedIndex).idDestajoClasificacionEmpeado
        Else
            objEmp.idDestajoClasificacionEmpeado = Nothing
        End If

        If cbArea.SelectedIndex <> -1 Then
            objEmp.idArea = objCbArea.Item(cbArea.SelectedIndex).idArea
        Else
            objEmp.idArea = Nothing
        End If

        If cbUMF.SelectedIndex <> -1 Then
            objEmp.idUMF = objCbUMF.Item(cbUMF.SelectedIndex).idUMF
        Else
            objEmp.idUMF = Nothing
        End If

        If cbPuesto.SelectedIndex <> -1 Then
            objEmp.idPuesto = objCBPuesto.Item(cbPuesto.SelectedIndex).idPuesto
        Else
            objEmp.idPuesto = Nothing
        End If

        If cbLugarNacimiento.SelectedIndex <> -1 Then
            objEmp.idLugarNacimiento = objCbLugarNacimiento.Item(cbLugarNacimiento.SelectedIndex).idLugarNacimiento
        Else
            objEmp.idLugarNacimiento = Nothing
        End If

        If cbRegPatronal.SelectedIndex <> -1 Then
            objEmp.idRegistroPatronal = objCbRegatronal.Item(cbRegPatronal.SelectedIndex).idRegistroPatronal
        Else
            objEmp.idRegistroPatronal = Nothing
        End If

        If cbFactorDeIntegracion.SelectedIndex <> -1 Then
            objEmp.idFactorIntegracion = objCBFactorIntegracion.Item(cbFactorDeIntegracion.SelectedIndex).idFactorIntegracion
        Else
            objEmp.idFactorIntegracion = Nothing
        End If

        If cbSueldoIMSS.SelectedIndex <> -1 Then
            objEmp.idSueldoIMSS = objCBSueldoIMSS.Item(cbSueldoIMSS.SelectedIndex).idSueldoIMSS
        Else
            objEmp.idSueldoIMSS = Nothing
        End If

        If cbNivelPuesto.SelectedIndex <> -1 Then
            objEmp.idNivelPuesto = listNivelPuesto.Item(cbNivelPuesto.SelectedIndex).idNivelPuesto
        Else
            objEmp.idNivelPuesto = Nothing
        End If


        'MGMG=======Regimen Fiscal
        If cbRegFiscal.SelectedIndex <> -1 Then
            objEmp.idRegimenFiscal = objCbRegimenFiscal.Item(cbRegFiscal.SelectedIndex).idRegimen
        Else
            objEmp.idRegimenFiscal = Nothing
        End If
        objEmp.fechacambioReg = dtpFechacambioReg.Value
        '=======


        objEmp.tieneHorasExtrasAut = chbTieneHorasExtraAut.Checked
        objEmp.forzarLimiteHorasExtras = chbForzarLimite.Checked
        objEmp.cantidadHoras = txtCantidadHoras.Text

        objEmp.estadoCivil = cbEstadoCivil.SelectedItem
        objEmp.escolaridad = cbEscolaridad.SelectedItem
        objEmp.nombreMadre = txtNombreMadre.Text
        objEmp.nombrePadre = txtNombrePadre.Text

        objEmp.telcontacto = txtTelContacto.Text
        objEmp.telred = txtTelRed.Text
        objEmp.compania = cbCompania.SelectedItem
        objEmp.nocontratobancario = txtContratoBancario.Text
        objEmp.numcreditoinfonavit = txtNumCreditoInfonavit.Text
        objEmp.factordescuentoinfonavit = cbFactorInfonavit.SelectedItem

        Try
            objEmp.retencioninfonavit = txtRetencionInfonavit.Text
        Catch ex As Exception
            objEmp.retencioninfonavit = Nothing
        End Try

    End Sub

    Private Sub habilitaBotones()
        If eventoActual = EventoVentana.NuevoRegistro Then
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            btnComentarios.Enabled = False
            btnAdjuntos.Enabled = False
            btnReportes.Enabled = False
            btnRecargar.Enabled = False
            btnDetalle.Enabled = False
            btnAtributoEmpleado.Enabled = False
            TabControl1.SelectTab(1)
            txtNombre.Select()
        Else
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
            btnComentarios.Enabled = True
            btnAdjuntos.Enabled = True
            btnReportes.Enabled = True
            btnRecargar.Enabled = True
            btnDetalle.Enabled = True
            btnAtributoEmpleado.Enabled = True

        End If

        If Ambiente.usuario.tipoUsuarioSistema = "USR" Then
            cbTipoUsuarioSistema.Enabled = False
        Else
            cbTipoUsuarioSistema.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            indiceSeleccion = DataGridView1.SelectedRows.Item(0).Index
            eventoActual = 1
            asignarDatos(indiceSeleccion, objDgEmp.Item(indiceSeleccion))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frmCatalogo.Name = "..:: Empleado ::.."
        frmCatalogo.lblValue.Text = "Valor: "

        Dim resultado As Integer
        resultado = frmCatalogo.ShowDialog()

        If IsNumeric(frmCatalogo.txtID.Text) Then
            idEmpleado = frmCatalogo.txtID.Text
        Else
            idEmpleado = 0
        End If
        value = frmCatalogo.txtValue.Text

        buscarPDialog(resultado)
    End Sub

    Public Sub buscarPDialog(resultado As Integer)
        If resultado = DialogResult.OK Then 'Buscara
            soloActivos = frmCatalogo.soloActivos.Checked
            eventoActual = EventoVentana.BuscaRegistros
            cargaGrid(soloActivos)
        ElseIf resultado = DialogResult.Yes Then  'Documento Nuevo
            'eventoActual = EventoVentana.NuevoRegistro
            'idEmpleado = 0
            'value = ""
            'asignarDatos(-1, New Empleado(Ambiente))
            eventoActual = EventoVentana.NuevoRegistro
            idEmpleado = 0
            value = ""
            asignarDatos(-1, New Empleado(Ambiente))
        ElseIf resultado = DialogResult.Cancel Then  'No realizara nada..
            'No hara NADA
        End If
    End Sub


    Private Sub cargaGrid(soloActivos As Boolean)
        cargado = False
        objEmpl.cargarGrid(DataGridView1, idEmpleado, value, objDgEmp, soloActivos)
        cargado = True

        If DataGridView1.Rows.Count = 0 Then
            indiceSeleccion = -1
            asignarDatos(indiceSeleccion, New Empleado(Ambiente))
        Else
            indiceSeleccion = 0
            asignarDatos(indiceSeleccion, objDgEmp.Item(indiceSeleccion))
        End If

        lblTotalReg.Text = "Total Registros: " & DataGridView1.Rows.Count
    End Sub


    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles btnImprAtributos.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirAtributos()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnModAtributos.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarAtributos()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cargaGrid(soloActivos)
    End Sub

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        If eventoActual = EventoVentana.NuevoRegistro Then
            Dim plantillaEmp As New Empleado(Ambiente)

            obtenerDatos(plantillaEmp)

            If plantillaEmp.guardar() Then
                eventoActual = EventoVentana.BuscaRegistros

                Mensaje.Mensaje = "Datos Guardados correctamente."
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()

                cargaGrid(soloActivos)
            Else
                Mensaje.Mensaje = "No se guardo la información: " & plantillaEmp.descripError
                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()
            End If

        Else
            If indiceSeleccion = -1 Then
                Exit Sub
            End If

            obtenerDatos(objDgEmp(indiceSeleccion))
            Mensaje.tipoMsj = TipoMensaje.Informacion

            If objDgEmp(indiceSeleccion).actualizar() Then
                Mensaje.Mensaje = "Datos Actualizados correctamente."
                Mensaje.ShowDialog()
                objDgEmp(indiceSeleccion).cargaGrid(DataGridView1, indiceSeleccion)
            Else
                Mensaje.Mensaje = objDgEmp(indiceSeleccion).descripError
                Mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If indiceSeleccion <> -1 And indiceSeleccion <> 0 Then
            eventoActual = 1
            indiceSeleccion -= 1
            asignarDatos(indiceSeleccion, objDgEmp.Item(indiceSeleccion))
            DataGridView1.Rows(indiceSeleccion).Selected = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If indiceSeleccion <> -1 And indiceSeleccion <> DataGridView1.Rows.Count - 1 Then
            eventoActual = 1
            indiceSeleccion += 1
            asignarDatos(indiceSeleccion, objDgEmp.Item(indiceSeleccion))
            DataGridView1.Rows(indiceSeleccion).Selected = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        eventoActual = EventoVentana.NuevoRegistro
        idEmpleado = 0
        value = ""
        asignarDatos(-1, New Empleado(Ambiente))
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If indiceSeleccion <> -1 Then
            Mensaje.Mensaje = "¿Desea eliminar el empleado seleccionado: """ & objDgEmp.Item(indiceSeleccion).nombreCompleto & """?"
            Mensaje.tipoMsj = TipoMensaje.Pregunta
            If Mensaje.ShowDialog() = DialogResult.Yes Then
                Dim resp As Boolean
                resp = objDgEmp(indiceSeleccion).eliminar()

                If resp Then
                    Mensaje.Mensaje = "Se elimino correctamente el empleado..."
                Else
                    Mensaje.Mensaje = objDgEmp(indiceSeleccion).descripError
                End If

                Mensaje.tipoMsj = TipoMensaje.Informacion
                Mensaje.ShowDialog()

                If resp Then
                    cargaGrid(soloActivos)
                End If
            End If
        End If
    End Sub

    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        If indiceSeleccion <> -1 Then
            frmComentario.tabla = "Empleado"
            frmComentario.idTabla = objDgEmp(indiceSeleccion).idEmpleado
            frmComentario.Ambiente = Ambiente
            frmComentario.ShowDialog()
        End If
    End Sub

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        If indiceSeleccion <> -1 Then
            frmArchivo.tabla = "Empleado"
            frmArchivo.idTabla = objDgEmp(indiceSeleccion).idEmpleado
            frmArchivo.Ambiente = Ambiente
            frmArchivo.elementoSistema = "Varios"
            frmArchivo.tipoArchivo = "Adjunto"
            frmArchivo.ShowDialog()
        End If
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        If indiceSeleccion <> -1 Then
            frmLogTransaccion.tabla = "Empleado"
            frmLogTransaccion.idTabla = objDgEmp(indiceSeleccion).idEmpleado
            frmLogTransaccion.Ambiente = Ambiente
            frmLogTransaccion.ShowDialog()
        End If
    End Sub

    Private Sub cbPerfilCalculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPerfilCalculo.SelectedIndexChanged
        If cbPerfilCalculo.SelectedItem <> "Destajista" Then
            cbClasificacionPuntosDestajo.SelectedIndex = -1
            cbDestajoClasificacionEmpleado.SelectedIndex = -1
            cbClasificacionPuntosDestajo.Enabled = False
            cbDestajoClasificacionEmpleado.Enabled = False
        Else
            cbClasificacionPuntosDestajo.Enabled = True
            cbDestajoClasificacionEmpleado.Enabled = True
        End If
    End Sub

    Private Sub cbTipoUsuarioSistema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoUsuarioSistema.SelectedIndexChanged
        If cbTipoUsuarioSistema.SelectedIndex <> 0 Then
            txtPass.ReadOnly = False
            txtUsuario.ReadOnly = False
        Else
            txtPass.ReadOnly = True
            txtUsuario.ReadOnly = True
            'txtPass.Clear()
            'txtUsuario.Clear()
        End If
    End Sub

    Private Sub cbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamento.SelectedIndexChanged
        cargarArea()
    End Sub

    Private Sub cargarArea()
        Dim objArea As New Area(Ambiente)
        objArea.idEmpresa = Ambiente.empr.idEmpresa
        If cbDepartamento.SelectedIndex >= 0 Then
            objArea.idDepartamento = objCbDepartamento(cbDepartamento.SelectedIndex).idDepartamento
        Else
            objArea.idDepartamento = Nothing
        End If

        objArea.getComboActivos(cbArea, objCbArea)
    End Sub

    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles btnAtributoEmpleado.Click
        If indiceSeleccion <> -1 Then
            MsgSeleccionaValores.Mensaje = "¿Qué tipo  de Atributos deseas Agregar?"
            MsgSeleccionaValores.StartPosition = FormStartPosition.CenterScreen
            If MsgSeleccionaValores.ShowDialog() Then
                If MsgSeleccionaValores.resultado = "Credenciales" Then
                    frmCredenciales.Ambiente = Ambiente
                    frmCredenciales.tabla = "Empleado"
                    frmCredenciales.idTabla = objDgEmp(indiceSeleccion).idEmpleado
                    frmCredenciales.ShowDialog()
                ElseIf MsgSeleccionaValores.resultado = "Uniformes" Then
                    frmCacteristicaTabla.Ambiente = Ambiente
                    frmCacteristicaTabla.tabla = "Empleado"
                    frmCacteristicaTabla.idTabla = objDgEmp(indiceSeleccion).idEmpleado
                    frmCacteristicaTabla.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        frmDireccionEmpleado.Ambiente = Ambiente
        frmDireccionEmpleado.idEmpleado = objDgEmp(indiceSeleccion).idEmpleado
        frmDireccionEmpleado.ShowDialog()
    End Sub

    Private Sub ImprimirModIMSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAltaIMSS.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirAltaIMSS()
        End If
    End Sub

    Private Sub ModificarModIMSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAltaIMSSMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarAltaIMSS()
        End If
    End Sub

    Private Sub btnBjaIMSS_Click(sender As Object, e As EventArgs) Handles btnBjaIMSS.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirBajaIMSS()
        End If
    End Sub

    Private Sub btnBajaIMSSMod_Click(sender As Object, e As EventArgs) Handles btnBajaIMSSMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarBajaIMSS()
        End If
    End Sub

    Private Sub ModificacionIMSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnModIMSS.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirModIMSS()
        End If
    End Sub

    Private Sub btnModIMSSMod_Click(sender As Object, e As EventArgs) Handles btnModIMSSMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarModIMSS()
        End If
    End Sub

    Private Sub btnCartaPatronal_Click(sender As Object, e As EventArgs) Handles btnCartaPatronal.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirCartaPatronal()
        End If
    End Sub


    Private Sub ModificarToolStripMenuItem_Click_5(sender As Object, e As EventArgs) Handles btnCartaPatronalMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarCartaPatronal()
        End If
    End Sub

    Private Sub btnKardex_Click(sender As Object, e As EventArgs) Handles btnKardex.Click
        If indiceSeleccion <> -1 Then
            Dim ctrlVac As New ControlVacaciones(Ambiente)
            ctrlVac.idEmpleado = objDgEmp(indiceSeleccion).idEmpleado
            ctrlVac.imprimeKardex()
        End If
    End Sub

    Private Sub btnModKardex_Click(sender As Object, e As EventArgs) Handles btnModKardex.Click
        If indiceSeleccion <> -1 Then
            Dim ctrlVac As New ControlVacaciones(Ambiente)
            ctrlVac.idEmpleado = objDgEmp(indiceSeleccion).idEmpleado
            ctrlVac.modificarKardex()
        End If
    End Sub

    Private Sub picRostro_Click(sender As Object, e As EventArgs) Handles picRostro.Click
        frmArchivo.Ambiente = Ambiente
        frmArchivo.tabla = "Empleado"
        frmArchivo.idTabla = objDgEmp(indiceSeleccion).idEmpleado
        frmArchivo.elementoSistema = "FotoReloj"
        frmArchivo.tipoArchivo = "Foto"
        frmArchivo.ShowDialog()

    End Sub

    Private Sub btnHojaContratacion_Click(sender As Object, e As EventArgs) Handles btnHojaContratacion.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirHojaContratacion()
        End If
    End Sub

    Private Sub btnHojaContrataMod_Click(sender As Object, e As EventArgs) Handles btnHojaContrataMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarHojaContratacion()
        End If
    End Sub

    Private Sub btnAltaBanco_Click(sender As Object, e As EventArgs) Handles btnAltaBanco.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirAltaBanco()
        End If
    End Sub

    Private Sub btnAltaBancoMod_Click(sender As Object, e As EventArgs) Handles btnAltaBancoMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarAltaBanco()
        End If
    End Sub

    Private Sub btnCambioPuestoDep_Click(sender As Object, e As EventArgs) Handles btnCambioPuestoDep.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirCambioDepPuesto()
        End If
    End Sub

    Private Sub btnCambioPuestoDepMod_Click(sender As Object, e As EventArgs) Handles btnCambioPuestoDepMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarCambioDepPuesto()
        End If
    End Sub

    Private Sub cbSueldoIMSS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSueldoIMSS.SelectedIndexChanged
        If cbSueldoIMSS.SelectedIndex <> -1 Then
            txtSueldoSemIMSS.Text = objCBSueldoIMSS(cbSueldoIMSS.SelectedIndex).sueldoSemanal
            txtSD.Text = objCBSueldoIMSS(cbSueldoIMSS.SelectedIndex).sueldoDiario
            If cbTabulador.SelectedIndex <> -1 Then
                txtExcedente.Text = FormatCurrency(objCbTabulador(cbTabulador.SelectedIndex).getVersionActual.sueldo - objCBSueldoIMSS(cbSueldoIMSS.SelectedIndex).sueldoSemanal)
            Else
                txtExcedente.Text = FormatCurrency(0)
            End If

            If cbFactorDeIntegracion.SelectedIndex <> -1 And cbSueldoIMSS.SelectedIndex <> -1 Then
                txtSDI.Text = Format(objCBSueldoIMSS(cbSueldoIMSS.SelectedIndex).sueldoDiario * objCBFactorIntegracion(cbFactorDeIntegracion.SelectedIndex).factor, "0.00")
            Else
                txtSDI.Text = 0
            End If
        Else
            txtSueldoSemIMSS.Text = 0
            txtSD.Text = 0
            txtExcedente.Text = FormatCurrency(0)
        End If
    End Sub


    'Private Sub cbNivelSueldo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNivelPuesto.SelectedIndexChanged
    '    '@============== 
    '    If cbNivelPuesto.SelectedIndex > -1 Then
    '        objTabulador = New Tabulador(Ambiente)
    '        objTabulador.idEmpresa = Ambiente.empr.idEmpresa
    '        'Try
    '        If objDgEmp.Count > 0 Then
    '            objTabulador.getComboActivoPorNivel(cbTabulador,
    '                                   objCbTabulador,
    '                                   listNivelPuesto.Item(cbNivelPuesto.SelectedIndex).idNivelPuesto,
    '                                    objDgEmp.Item(indiceSeleccion).idTabulador)
    '            cbTabulador.SelectedIndex = -1
    '            For i As Integer = 0 To cbTabulador.Items.Count - 1
    '                If objCbTabulador.Item(i).idTabulador = objDgEmp.Item(indiceSeleccion).idTabulador Then
    '                    cbTabulador.SelectedIndex = i
    '                    Exit For
    '                End If
    '            Next

    '            cbSueldoIMSS.SelectedIndex = -1
    '            For i As Integer = 0 To cbSueldoIMSS.Items.Count - 1
    '                If objCBSueldoIMSS.Item(i).idSueldoIMSS = objDgEmp.Item(indiceSeleccion).idSueldoIMSS Then
    '                    cbSueldoIMSS.SelectedIndex = i
    '                    Exit For
    '                End If
    '            Next
    '        Else
    '            objTabulador.getComboActivoPorNivel(cbTabulador,
    '                                  objCbTabulador,
    '                                  listNivelPuesto.Item(cbNivelPuesto.SelectedIndex).idNivelPuesto,
    '                                   0)
    '        End If


    '        'Catch ex As Exception

    '        'End Try

    '    End If
    'End Sub

    Private Sub cbFactorDeIntegracion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFactorDeIntegracion.SelectedIndexChanged
        If cbFactorDeIntegracion.SelectedIndex <> -1 And cbSueldoIMSS.SelectedIndex <> -1 Then
            txtSDI.Text = Format(objCBSueldoIMSS(cbSueldoIMSS.SelectedIndex).sueldoDiario * objCBFactorIntegracion(cbFactorDeIntegracion.SelectedIndex).factor, "0.00")
        Else
            txtSDI.Text = 0
        End If
    End Sub

    Private Sub cbTabulador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTabulador.SelectedIndexChanged
        If cbTabulador.SelectedIndex <> -1 Then
            objSueldoIMSS = New SueldosIMSS(Ambiente)
            objSueldoIMSS.idEmpresa = Ambiente.empr.idEmpresa
            objSueldoIMSS.sueldoFinalImms(0, objCbTabulador(cbTabulador.SelectedIndex).getVersionActual.sueldo, objCBSueldoIMSS, cbSueldoIMSS, If(cbPerfilCalculo.SelectedItem = "Destajista", True, False))
        End If
    End Sub

    Private Sub dtpFechaAlta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaAlta.ValueChanged
        lblTiempo.Text = "Tiempo Laborando: " & DateDiff(DateInterval.Month, dtpFechaAlta.Value, Now) & " Meses"
    End Sub

    Private Sub btnContrato_Click(sender As Object, e As EventArgs) Handles btnContrato.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirContrato()
        End If
    End Sub

    Private Sub btnContratoMod_Click(sender As Object, e As EventArgs) Handles btnContratoMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarContrato()
        End If
    End Sub

    Private Sub ConvenioVMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnConvenioVM.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirConvenioVM()
        End If
    End Sub

    Private Sub btnConvenioVMMod_Click(sender As Object, e As EventArgs) Handles btnConvenioVMMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarConvenioVM()
        End If
    End Sub

    Private Sub btnConvenioG_Click(sender As Object, e As EventArgs) Handles btnConvenioG.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirConvenio()
        End If
    End Sub

    Private Sub btnConvenioGMod_Click(sender As Object, e As EventArgs) Handles btnConvenioGMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarConvenio()
        End If
    End Sub

    Private Sub btnFormatoNeg_Click(sender As Object, e As EventArgs) Handles btnFormatoNeg.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirFormatoNeg()
        End If
    End Sub

    Private Sub btnFormatoNegMod_Click(sender As Object, e As EventArgs) Handles btnFormatoNegMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarFormatoNeg()
        End If
    End Sub

    Private Sub btnContratoDet_Click(sender As Object, e As EventArgs) Handles btnContratoDet.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirContratoDeterminado()
        End If
    End Sub

    Private Sub btnContratoDetMod_Click(sender As Object, e As EventArgs) Handles btnContratoDetMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarContratoDeterminado()
        End If
    End Sub

    Private Sub btnFonacot_Click(sender As Object, e As EventArgs) Handles btnFonacot.Click
        If indiceSeleccion <> -1 Then
            frmCreditoFonacot.Ambiente = Ambiente
            frmCreditoFonacot.idEmpleadoActivo = objDgEmp(indiceSeleccion).idEmpleado
            frmCreditoFonacot.ShowDialog()
        End If
    End Sub

    Private Sub BajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnFormatoBaja.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirRenuncia()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles btnFormatoBajaMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarRenuncia()
        End If
    End Sub

    Private Sub Contrato60DíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnContrato60Días.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirReporte60d()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles btnContrato60DíasMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarReporte60d()
        End If
    End Sub

    Private Sub Contrato30DíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnContrato30Dias.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirReporte30d()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_3(sender As Object, e As EventArgs) Handles btnContrato30DiasMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarReporte30d()
        End If
    End Sub



    Private Sub FormatoNúmeroDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bteFNumcuenta.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirReporteEmpCuentBanco()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_4(sender As Object, e As EventArgs) Handles bteFnumCuentaMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarReporteEmpCuentBanco()
        End If
    End Sub

    Private Sub bteAvisoPriv_Click(sender As Object, e As EventArgs) Handles bteAvisoPriv.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirReporteEmpAvisoPrivacidad()
        End If
    End Sub

    Private Sub bteAvisoPrivMod_Click(sender As Object, e As EventArgs) Handles bteAvisoPrivMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarReporteEmpAvisoPrivacidad()
        End If
    End Sub

    Private Sub bteEtiquetaExpP_Click(sender As Object, e As EventArgs) Handles bteEtiquetaExpP.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirReporteEmpEtiqueta()
        End If
    End Sub

    Private Sub bteEtiquetaExpPMod_Click(sender As Object, e As EventArgs) Handles bteEtiquetaExpPMod.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarReporteEmpEtiqueta()
        End If
    End Sub

    Private Sub bteConvenLiq_Click(sender As Object, e As EventArgs) Handles bteConvenLiq.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ImprimirConvenioLiq()
        End If
    End Sub

    Private Sub bteModConLiq_Click(sender As Object, e As EventArgs) Handles bteModConLiq.Click
        If indiceSeleccion <> -1 Then
            objDgEmp(indiceSeleccion).RPT_ModificarConvenioLiq()
        End If
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        frmRenovacion.empleado = objDgEmp.Item(indiceSeleccion)
        frmRenovacion.Ambiente = Ambiente
        frmRenovacion.Show()
        frmRenovacion.Activate()
    End Sub

    Private Sub MaterialRaisedButton4_Click(sender As Object, e As EventArgs) Handles bteAtivarEmpleado.Click
        Mensaje.tipoMsj = TipoMensaje.Informacion
        If indiceSeleccion = -1 Then
            Exit Sub
        End If
        If objDgEmp(indiceSeleccion).activaEmpleado() Then
            Mensaje.Mensaje = "Empleado Ativado Correctamente."
            Mensaje.ShowDialog()
            cargaGrid(soloActivos)
        Else
            Mensaje.Mensaje = objDgEmp(indiceSeleccion).descripError
            Mensaje.ShowDialog()
        End If
    End Sub
End Class