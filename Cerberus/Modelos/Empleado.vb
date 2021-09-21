Imports System.Data.SqlClient
Imports Cerberus

Public Class Empleado
    Implements InterfaceTablas

    Public buscarEnTodasLasEmpresas As Boolean = False

    'VARIABLES EXTRAS
    Public nombreCompleto As String
    Public idError As Integer
    Public descripError As String

    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado
    Private objEmpresa As Empresa
    Private objSucursal As Sucursal
    Private objHorario As Horario
    Private objHorarioComida As Horario

    Private objTabulador As Tabulador
    Private objCocina As Cocina
    Private objDepartamento As Departamento

    Private objRegimenFiscal As RegimenFiscal

    'VARIABLES
    Public nuevoID As Integer
    Public idEmpleado As Integer
    Public nombreEmpleado As String
    Public apPatEmpleado As String
    Public apMatEmpleado As String
    Public usuario As String
    Public password As String
    Public pwdZK As String
    Public nss As String
    Public rfc As String
    Public esActivo As Boolean
    Public creado As DateTime
    Public actualizado As DateTime
    Public rostro As String
    Public huella0 As String
    Public huella1 As String
    Public huella2 As String
    Public huella3 As String
    Public huella4 As String
    Public huella5 As String
    Public huella6 As String
    Public huella7 As String
    Public huella8 As String
    Public huella9 As String
    Public perfilCalculo As String
    Public tieneHorasExtrasAut As Boolean
    Public forzarLimiteHorasExtras As Boolean
    Public cantidadHoras As Decimal
    Public sueldoSemanalIMSS As Decimal
    Public fechaAlta As DateTime
    Public fechaBaja As DateTime
    Public tipoUsuarioSistema As String
    Public diasVacacionesDisponibles As Integer
    Public esSupervisor As Boolean
    Public numeroTarjeta As String
    Public desarrollador As Boolean
    Public correoEmpresa As String
    Public correoPersonal As String
    Public idArea As Integer
    Public idRegistroPatronal As Integer
    Public idUMF As Integer
    Public idLugarNacimiento As Integer
    Public curp As String
    Public idPuesto As Integer
    Public fechaNacimiento As Date
    Public SD As Decimal
    Public SDI As Decimal
    Public genero As String
    Public bancoPago As String
    Public sucursalPago As String
    Public numCuentaPago As String
    Public clabePago As String
    Public noBorrarMisIncidencias As Boolean
    Public tieneFonacot As Boolean
    Public tieneInfonavit As Boolean
    Public estadoCivil As String
    Public escolaridad As String
    Public nombrePadre As String
    Public nombreMadre As String
    Public telcontacto As String
    Public telred As String
    Public compania As String
    Public nocontratobancario As String
    Public numcreditoinfonavit As String
    Public factordescuentoinfonavit As String
    Public retencioninfonavit As Decimal
    Public telcasa As String
    Public no_cheque As String
    Public motivoContratacion As String
    Public nacionalidad As String
    Public idSueldoIMSS As Integer
    Public idFactorIntegracion As Integer
    Public fechacambioReg As Date
    Public esDeudor As Boolean
    Public esNomina100p As Boolean
    Public idNivelPuesto As Integer


    'OBJETOS
    Public idDepartamento As Integer
    Public idHorario As Integer
    Public idRegimenFiscal As Integer

    'Public idHorarioComida As Integer
    Public idCocina As Integer
    Public idTabulador As Integer
    Public idTipoUsuario As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creadoPor As Integer
    Public actualizadoPor As Integer
    Public idDestajoClasificacionPuntos As Integer
    Public idDestajoClasificacionEmpeado As Integer


    'PRIVADAS
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private rptDatos As Reporte
    Private dsDatos As DataSet


    Private objDesClasifEmpl As DestajoClasificacionEmpleado

    Sub New(amb As AmbienteCls)
        Ambiente = amb
        conex = amb.conex
    End Sub

    Private Sub creaDSDatos()
        Dim dr As DataRow

        rptDatos = New Reporte(Ambiente, "Empleado", "DatosEmpleado")
        dsDatos = New DataSet

        'Tabla
        dsDatos.Tables.Add("Empleado")

        'Columnas
        dsDatos.Tables(0).Columns.Add("idEmpleado")
        dsDatos.Tables(0).Columns.Add("nombreCompleto")
        dsDatos.Tables(0).Columns.Add("nss")

        'Registros
        dr = dsDatos.Tables(0).NewRow
        dr(0) = idEmpleado
        dr(1) = nombreCompleto
        dr(2) = nss

        dsDatos.Tables(0).Rows.Add(dr)
    End Sub

    Private Sub creaDSAtributos()
        rptDatos = New Reporte(Ambiente, "Empleado", "AtributosEmpleado")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa)
    End Sub


    Private Sub creaDSModIMSS(tipoDoc As String)
        rptDatos = New Reporte(Ambiente, "Empleado", tipoDoc)
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpleado", idEmpleado)
        rptDatos.agregaVarible("elaboro", Ambiente.usuario.nombreCompleto)
    End Sub

    Public Function getDestajoClasificacion() As DestajoClasificacionEmpleado
        If objDesClasifEmpl Is Nothing Then
            objDesClasifEmpl = New DestajoClasificacionEmpleado(Ambiente)
            objDesClasifEmpl.idDestajoClasificacionEmpeado = idDestajoClasificacionEmpeado
            objDesClasifEmpl.buscarPID()

        End If
        Return objDesClasifEmpl
    End Function


    Public Function buscarPUsuario() As Boolean
        If usuario = "" Then
            Return False
        End If
        conex.Qry = "SELECT TOP 1 * FROM Empleado WHERE Usuario = @user  AND tipoUsuarioSistema in ('DEP','RH') AND esActivo = 1 order by idEmpleado desc"
        conex.numCon = 0
        Dim listNameParam As New List(Of String)
        Dim listParams As New List(Of Object)
        listNameParam.Add("@user")
        listParams.Add(usuario)
        If conex.ejecutaConsultaPrepareStart(listNameParam, listParams) Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Empleado.buscarPUsuario: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarPNSS() As Boolean

        conex.Qry = "SELECT * FROM Empleado WHERE nss = '" & nss & "' and esActivo = 1 AND idEmpresa = " & Ambiente.empr.idEmpresa
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If

        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Empleado.buscarPNSS: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarCURP() As Boolean

        conex.Qry = "SELECT * FROM Empleado WHERE curp = '" & curp & "' and esActivo = 1 AND idEmpresa = " & Ambiente.empr.idEmpresa
        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If

        Else
            MessageBox.Show(conex.descripError)
            Return False
        End If
    End Function

    Public Function registraAcceso() As Boolean
        Try
            '"EXEC spRegAccess " & usuario & "," & idEmpleado
            conex.Qry = "DECLARE @res As Bit" &
            " EXEC @res = spRegAccess '" & usuario & "'," & idEmpleado &
            " SELECT @res As result"
            'InputBox("", "", conex.Qry)
            conex.numCon = 0
            If conex.ejecutaConsulta() Then
                If conex.reader.Read Then
                    If conex.reader("result") Then
                        conex.reader.Close()
                        Return True
                    Else
                        conex.reader.Close()
                        Return False
                    End If
                Else
                    conex.reader.Close()
                    Return False
                End If

            Else
                MessageBox.Show("EROORS: " & conex.descripError)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function validaPassword(txtPass As String) As Boolean
        If txtPass.Equals(password) Then
            If registraAcceso() Then
                Return True
            Else
                descripError = "No cuentas con Acceso al Sistema, Comunicate con un Administrador"
                Return False
            End If
        Else
            descripError = "La contraseña ingresada no es valida para el usuario ingresado, favor de verificarla..."
            Return False
        End If
    End Function

    Public Sub RPT_ImprimirDatos()
        creaDSDatos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatos()
        creaDSDatos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirAtributos()
        creaDSAtributos()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarAtributos()
        creaDSAtributos()
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirAltaIMSS()
        creaDSModIMSS("AltaIMSS")
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarAltaIMSS()
        creaDSModIMSS("AltaIMSS")
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirBajaIMSS()
        creaDSModIMSS("BajaIMSS")
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarBajaIMSS()
        creaDSModIMSS("BajaIMSS")
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirModIMSS()
        creaDSModIMSS("ModIMSS")
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarModIMSS()
        creaDSModIMSS("ModIMSS")
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirCartaPatronal()
        creaDSModIMSS("CartaPatronal")
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarCartaPatronal()
        creaDSModIMSS("CartaPatronal")
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirHojaContratacion()
        creaDSHojaContratacion()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarHojaContratacion()
        creaDSHojaContratacion()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSHojaContratacion()
        rptDatos = New Reporte(Ambiente, "Empleado", "HojaContratacion")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmp", idEmpleado)
        rptDatos.agregaVarible("vIDEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ImprimirAltaBanco()
        creaDSAltaBanco()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarAltaBanco()
        creaDSAltaBanco()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSAltaBanco()
        rptDatos = New Reporte(Ambiente, "Empleado", "AltaBanco")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIDEmp", idEmpleado)
        rptDatos.agregaVarible("vIDEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ImprimirCambioDepPuesto()
        creaDSCambioDepPuesto()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarCambioDepPuesto()
        creaDSCambioDepPuesto()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSCambioDepPuesto()
        rptDatos = New Reporte(Ambiente, "Empleado", "CambioPustoDep")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIDEmp", idEmpleado)
        rptDatos.agregaVarible("vIDEmpresa", Ambiente.empr.idEmpresa)
    End Sub

    Public Sub RPT_ImprimirContrato()
        creaDSContrato()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarContrato()
        creaDSContrato()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSContrato()
        rptDatos = New Reporte(Ambiente, "Empleado", "Contrato")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        If idEmpleado <= 0 Then
            descripError = "ID < 0"
            Return False
        End If

        conex.Qry = "SELECT * FROM Empleado WHERE idEmpleado = " & idEmpleado
        conex.numCon = 0
        ' InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If

        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Empleado.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        If objCreadoPor Is Nothing Then
            objCreadoPor = New Empleado(Ambiente)
            objCreadoPor.idEmpleado = creadoPor
            objCreadoPor.buscarPID()
        End If
        Return objCreadoPor
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        If objActualizadoPor Is Nothing Then
            objActualizadoPor = New Empleado(Ambiente)
            objActualizadoPor.idEmpleado = actualizadoPor
            objActualizadoPor.buscarPID()

        End If
        Return objActualizadoPor
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        If objEmpresa Is Nothing Then
            objEmpresa = New Empresa(Ambiente)
            objEmpresa.idEmpresa = idEmpresa
            objEmpresa.buscarPID()
        End If
        Return objEmpresa
    End Function

    Public Function getHorario() As Horario
        If objHorario Is Nothing Then
            objHorario = New Horario(Ambiente)
            objHorario.idHorario = idHorario
            objHorario.buscarPID()
        End If
        Return objHorario
    End Function

    'Public Function getHorarioComida() As Horario
    '    If objHorarioComida Is Nothing Then
    '        objHorarioComida = New Horario(Ambiente)
    '        objHorarioComida.idHorario = idHorarioComida
    '        objHorarioComida.buscarPID()
    '    End If
    '    Return objHorario
    'End Function

    Public Function getTabulador() As Tabulador
        If objTabulador Is Nothing Then
            objTabulador = New Tabulador(Ambiente)
            objTabulador.idTabulador = idTabulador
            objTabulador.buscarPID()
        End If
        Return objTabulador
    End Function

    Public Function getDepartamento() As Departamento
        If objDepartamento Is Nothing Then
            objDepartamento = New Departamento(Ambiente)
            objDepartamento.idDepartamento = idDepartamento
            objDepartamento.buscarPID()
        End If
        Return objDepartamento
    End Function
    '==========Regimen fiscal
    Public Function getRegimenFiscal() As RegimenFiscal
        If objRegimenFiscal Is Nothing Then
            objRegimenFiscal = New RegimenFiscal(Ambiente)
            objRegimenFiscal.idRegimen = idRegimenFiscal
            objRegimenFiscal.buscarPID()
        End If
        Return objRegimenFiscal
    End Function
    '==========Regimen fiscal

    Public Function getCocia() As Cocina
        If objCocina Is Nothing Then
            objCocina = New Cocina(Ambiente)
            objCocina.idCocina = idCocina
            objCocina.buscarPID()
        End If
        Return objCocina
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        If objSucursal Is Nothing Then
            objSucursal = New Sucursal(Ambiente)
            objSucursal.idSucursal = idSucursal
            objSucursal.buscarPID()
        End If
        Return objSucursal
    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idEmpleado = rdr("idEmpleado")
        nombreEmpleado = rdr("nombreEmpleado")
        apPatEmpleado = rdr("apPatEmpleado")
        apMatEmpleado = rdr("apMatEmpleado")
        esActivo = rdr("esActivo")
        creado = rdr("creado")
        actualizado = rdr("actualizado")
        creadoPor = rdr("creadoPor")
        actualizadoPor = rdr("actualizadoPor")
        tipoUsuarioSistema = rdr("tipoUsuarioSistema")

        numeroTarjeta = If(IsDBNull(rdr("numeroTarjeta")), "", rdr("numeroTarjeta"))
        usuario = If(IsDBNull(rdr("usuario")), "", rdr("usuario"))
        password = If(IsDBNull(rdr("password")), "", rdr("password"))
        idDepartamento = If(IsDBNull(rdr("idDepartamento")), 0, rdr("idDepartamento"))
        idCocina = If(IsDBNull(rdr("idCocina")), 0, rdr("idCocina"))
        idHorario = If(IsDBNull(rdr("idHorario")), 0, rdr("idHorario"))
        'idHorarioComida = If(IsDBNull(rdr("idHorarioComida")), 0, rdr("idHorarioComida"))
        idTabulador = If(IsDBNull(rdr("idTabulador")), 0, rdr("idTabulador"))
        idTipoUsuario = If(IsDBNull(rdr("idTipoUsuario")), 0, rdr("idTipoUsuario"))
        idEmpresa = If(IsDBNull(rdr("idEmpresa")), 0, rdr("idEmpresa"))
        idSucursal = If(IsDBNull(rdr("idSucursal")), 0, rdr("idSucursal"))
        pwdZK = If(IsDBNull(rdr("pwdZK")), "", rdr("pwdZK"))
        nss = If(IsDBNull(rdr("nss")), "", rdr("nss"))
        rfc = If(IsDBNull(rdr("rfc")), "", rdr("rfc"))
        rostro = If(IsDBNull(rdr("rostro")), "", rdr("rostro"))
        huella0 = If(IsDBNull(rdr("huella0")), "", rdr("huella0"))
        huella1 = If(IsDBNull(rdr("huella1")), "", rdr("huella1"))
        huella2 = If(IsDBNull(rdr("huella2")), "", rdr("huella2"))
        huella3 = If(IsDBNull(rdr("huella3")), "", rdr("huella3"))
        huella4 = If(IsDBNull(rdr("huella4")), "", rdr("huella4"))
        huella5 = If(IsDBNull(rdr("huella5")), "", rdr("huella5"))
        huella6 = If(IsDBNull(rdr("huella6")), "", rdr("huella6"))
        huella7 = If(IsDBNull(rdr("huella7")), "", rdr("huella7"))
        huella8 = If(IsDBNull(rdr("huella8")), "", rdr("huella8"))
        huella9 = If(IsDBNull(rdr("huella9")), "", rdr("huella9"))
        perfilCalculo = If(IsDBNull(rdr("perfilCalculo")), Nothing, rdr("perfilCalculo"))
        tieneHorasExtrasAut = If(IsDBNull(rdr("tieneHorasExtrasAut")), Nothing, rdr("tieneHorasExtrasAut"))
        forzarLimiteHorasExtras = If(IsDBNull(rdr("forzarLimiteHorasExtras")), Nothing, rdr("forzarLimiteHorasExtras"))
        cantidadHoras = If(IsDBNull(rdr("cantidadHoras")), Nothing, rdr("cantidadHoras"))
        sueldoSemanalIMSS = If(IsDBNull(rdr("sueldoSemanalIMSS")), Nothing, rdr("sueldoSemanalIMSS"))
        idDestajoClasificacionPuntos = If(IsDBNull(rdr("idDestajoClasificacionPuntos")), Nothing, rdr("idDestajoClasificacionPuntos"))
        idDestajoClasificacionEmpeado = If(IsDBNull(rdr("idDestajoClasificacionEmpeado")), Nothing, rdr("idDestajoClasificacionEmpeado"))
        fechaAlta = If(IsDBNull(rdr("fechaAlta")), Nothing, rdr("fechaAlta"))
        fechaBaja = If(IsDBNull(rdr("fechaBaja")), Nothing, rdr("fechaBaja"))
        diasVacacionesDisponibles = If(IsDBNull(rdr("diasVacacionesDisponibles")), Nothing, rdr("diasVacacionesDisponibles"))
        esSupervisor = rdr("esSupervisor")
        desarrollador = If(IsDBNull(rdr("desarrollador")), Nothing, rdr("desarrollador"))
        correoEmpresa = If(IsDBNull(rdr("correoEmpresa")), Nothing, rdr("correoEmpresa"))
        correoPersonal = If(IsDBNull(rdr("correoPersonal")), Nothing, rdr("correoPersonal"))
        idArea = If(IsDBNull(rdr("idArea")), Nothing, rdr("idArea"))
        idRegistroPatronal = If(IsDBNull(rdr("idRegistroPatronal")), Nothing, rdr("idRegistroPatronal"))
        idUMF = If(IsDBNull(rdr("idUMF")), Nothing, rdr("idUMF"))
        idLugarNacimiento = If(IsDBNull(rdr("idLugarNacimiento")), Nothing, rdr("idLugarNacimiento"))
        curp = If(IsDBNull(rdr("curp")), Nothing, rdr("curp"))
        idPuesto = If(IsDBNull(rdr("idPuesto")), Nothing, rdr("idPuesto"))
        fechaNacimiento = If(IsDBNull(rdr("fechaNacimiento")), DateTimePicker.MinimumDateTime, rdr("fechaNacimiento"))
        SD = If(IsDBNull(rdr("SD")), Nothing, rdr("SD"))
        SDI = If(IsDBNull(rdr("SDI")), Nothing, rdr("SDI"))
        genero = If(IsDBNull(rdr("genero")), Nothing, rdr("genero"))
        bancoPago = If(IsDBNull(rdr("bancoPago")), Nothing, rdr("bancoPago"))
        sucursalPago = If(IsDBNull(rdr("sucursalPago")), Nothing, rdr("sucursalPago"))
        numCuentaPago = If(IsDBNull(rdr("numCuentaPago")), Nothing, rdr("numCuentaPago"))
        clabePago = If(IsDBNull(rdr("clabePago")), Nothing, rdr("clabePago"))
        noBorrarMisIncidencias = If(IsDBNull(rdr("noBorrarMisIncidencias")), Nothing, rdr("noBorrarMisIncidencias"))
        tieneFonacot = If(IsDBNull(rdr("tieneFonacot")), Nothing, rdr("tieneFonacot"))
        tieneInfonavit = If(IsDBNull(rdr("tieneInfonavit")), Nothing, rdr("tieneInfonavit"))
        estadoCivil = If(IsDBNull(rdr("estadoCivil")), Nothing, rdr("estadoCivil"))
        escolaridad = If(IsDBNull(rdr("escolaridad")), Nothing, rdr("escolaridad"))
        nombrePadre = If(IsDBNull(rdr("nombrePadre")), Nothing, rdr("nombrePadre"))
        nombreMadre = If(IsDBNull(rdr("nombreMadre")), Nothing, rdr("nombreMadre"))
        telcontacto = If(IsDBNull(rdr("telcontacto")), Nothing, rdr("telcontacto"))
        telred = If(IsDBNull(rdr("telred")), Nothing, rdr("telred"))
        compania = If(IsDBNull(rdr("compania")), Nothing, rdr("compania"))
        nocontratobancario = If(IsDBNull(rdr("nocontratobancario")), Nothing, rdr("nocontratobancario"))
        numcreditoinfonavit = If(IsDBNull(rdr("numcreditoinfonavit")), Nothing, rdr("numcreditoinfonavit"))
        factordescuentoinfonavit = If(IsDBNull(rdr("factordescuentoinfonavit")), Nothing, rdr("factordescuentoinfonavit"))
        retencioninfonavit = If(IsDBNull(rdr("retencioninfonavit")), Nothing, rdr("retencioninfonavit"))
        telcasa = If(IsDBNull(rdr("telcasa")), Nothing, rdr("telcasa"))
        no_cheque = If(IsDBNull(rdr("no_cheque")), Nothing, rdr("no_cheque").Trim)
        motivoContratacion = If(IsDBNull(rdr("motivoContratacion")), Nothing, rdr("motivoContratacion"))
        nacionalidad = If(IsDBNull(rdr("nacionalidad")), Nothing, rdr("nacionalidad"))
        idSueldoIMSS = If(IsDBNull(rdr("idSueldoIMSS")), Nothing, rdr("idSueldoIMSS"))
        idFactorIntegracion = If(IsDBNull(rdr("idFactorIntegracion")), Nothing, rdr("idFactorIntegracion"))

        nombreCompleto = rdr("apPatEmpleado") & " " & rdr("apMatEmpleado") & " " & rdr("nombreEmpleado")

        '==MGMG esto escribí ..... 
        idRegimenFiscal = If(IsDBNull(rdr("idRegimenFiscal")), 0, rdr("idRegimenFiscal"))
        fechacambioReg = If(IsDBNull(rdr("fechacambioReg")), "01/01/0001", rdr("fechacambioReg"))
        esDeudor = If(IsDBNull(rdr("esDeudor")), False, rdr("esDeudor"))
        esNomina100p = If(IsDBNull(rdr("esNomina100p")), False, rdr("esNomina100p"))
        idNivelPuesto = If(IsDBNull(rdr("idNivelPuesto")), 0, rdr("idNivelPuesto"))
    End Sub

    Public Sub cargaGrid(grid As DataGridView, indice As Integer)
        nombreCompleto = nombreEmpleado & " " & apPatEmpleado & " " & apMatEmpleado

        'grid.Rows.Item(indice).Cells(0).Value = ""
        grid.Rows.Item(indice).Cells(1).Value = nombreCompleto
        grid.Rows.Item(indice).Cells(2).Value = getDepartamento.nombreDepartamento
        grid.Rows.Item(indice).Cells(3).Value = nss
        grid.Rows.Item(indice).Cells(4).Value = rfc
    End Sub

    Protected Friend Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Empleado))
        Dim plantilla As Empleado
        Dim dtb As New DataTable("Empleado")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("No.", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Empleado", Type.GetType("System.String"))
        dtb.Columns.Add("Departamento", Type.GetType("System.String"))
        dtb.Columns.Add("NSS", Type.GetType("System.String"))
        dtb.Columns.Add("RFC", Type.GetType("System.String"))
        dtb.Columns.Add("D.Vacac. Disp.", Type.GetType("System.String"))

        objEmp.Clear()

        If Ambiente.usuario.tipoUsuarioSistema = "DEP" Then
            condicion &= " AND E.idDepartamento in (" & If(Ambiente.idsDepartamentos = "", "0", Ambiente.idsDepartamentos) & ") "
        End If

        conex.Qry = "SELECT E.*,isnull(D.nombreDepartamento,'') as nombreDepartamento 
                    FROM Empleado as E LEFT 
                    JOIN Departamento as D ON E.idDepartamento = D.idDepartamento 
                    WHERE 1 = 1 " &
                        If(buscarEnTodasLasEmpresas, "", "  AND E.idEmpresa = " & idEmpresa) & " " &
                        condicion & " 
                    ORDER BY D.nombreDepartamento,E.apPatEmpleado,E.apMatEmpleado,E.nombreEmpleado"

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Empleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("No.") = indice
                row("Nombre Empleado") = plantilla.nombreCompleto
                row("Departamento") = conex.reader("nombreDepartamento")
                row("NSS") = plantilla.nss
                row("RFC") = plantilla.rfc
                row("D.Vacac. Disp.") = plantilla.diasVacacionesDisponibles

                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()

            grid.DataSource = dtb
            grid.Columns(0).Visible = False

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Empleado.cargarGrid"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargarGrid(grid As DataGridView, idBusqueda As Integer, value As String, objEmp As List(Of Empleado), soloActivos As Boolean)
        Dim condicion As String
        value = value.Replace("*", "%")

        If idBusqueda <> 0 Then
            condicion = " AND E.idEmpleado = " & idBusqueda
        Else
            condicion = " AND (E.nombreEmpleado like '%" & value & "%' OR E.apPatEmpleado like '%" & value & "%' 
                    OR E.apMatEmpleado like '%" & value & "%' OR concat(E.nombreEmpleado,' ',E.apPatEmpleado,' ',E.apMatEmpleado) like '%" & value & "%' 
                    OR E.nss like '%" & value & "%'
                    OR D.nombreDepartamento like '%" & value & "%')"
        End If

        If soloActivos Then
            condicion &= " AND E.esActivo=1 "
        End If

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Sub cargarGridXDepOID(grid As DataGridView, idDepartamento As Integer, idEmpleado As Integer, objEmp As List(Of Empleado), soloActivos As Boolean, finPeriodo As Date)
        Dim condicion As String = ""

        If idEmpleado <> Nothing Then
            condicion &= " AND idEmpleado = " & idEmpleado
        Else
            If idDepartamento <> Nothing Then
                condicion &= " AND D.idDepartamento = " & idDepartamento
            End If
        End If

        If soloActivos Then
            condicion &= " AND E.esActivo=1 "
        End If

        condicion &= " AND convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') >= E.fechaAlta AND (E.fechaBaja >= convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') or E.fechaBaja is null)"

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Sub cargarGridXCocinaAsignada(grid As DataGridView, idCocina As Integer, objEmp As List(Of Empleado))
        Dim condicion As String = ""

        condicion &= " AND E.idCocina = " & idCocina
        condicion &= " AND E.esActivo= 1 "

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Sub cargarGridXDep(grid As DataGridView, idDepartamento As Integer, value As String, objEmp As List(Of Empleado), soloActivos As Boolean)
        Dim condicion As String = ""

        If value = Nothing Then
            value = ""
        End If

        value = value.Replace("*", "%")

        If idDepartamento <> Nothing Then
            condicion &= " AND D.idDepartamento = " & idDepartamento
        End If

        If value.Trim.Length > 0 Then
            condicion &= " AND (E.idEmpleado like '%" & value & "%' OR E.nombreEmpleado like '%" & value & "%' OR E.apPatEmpleado like '%" & value & "%' 
                    OR E.apMatEmpleado like '%" & value & "%' OR concat(E.nombreEmpleado,E.apPatEmpleado,E.apMatEmpleado) like '%" & value & "%' 
                    OR E.nss like '%" & value & "%')"
        End If

        If soloActivos Then
            condicion &= " AND E.esActivo=1 "
        End If

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Sub cargarGridXDepXPeriodo(grid As DataGridView, idDepartamento As Integer, value As String, objEmp As List(Of Empleado), inicioPeriodo As Date, finPeriodo As Date)
        Dim condicion As String = ""

        If value = Nothing Then
            value = ""
        End If

        value = value.Replace("*", "%")

        If idDepartamento <> Nothing Then
            condicion &= " AND D.idDepartamento = " & idDepartamento
        End If

        If value.Trim.Length > 0 Then
            condicion &= " AND (E.idEmpleado like '%" & value & "%' OR E.nombreEmpleado like '%" & value & "%' OR E.apPatEmpleado like '%" & value & "%' 
                    OR E.apMatEmpleado like '%" & value & "%' OR concat(E.nombreEmpleado,E.apPatEmpleado,E.apMatEmpleado) like '%" & value & "%' 
                    OR E.nss like '%" & value & "%')"
        End If

        condicion &= " AND convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') >= E.fechaAlta AND (E.fechaBaja >= convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') or E.fechaBaja is null)"

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Sub cargarGridXDepXPeriodoV2(grid As DataGridView, idEmpleado As Integer, objEmp As List(Of Empleado), inicioPeriodo As Date, finPeriodo As Date)
        Dim condicion As String = ""

        If idDepartamento <> Nothing Then
            condicion &= " AND D.idDepartamento = " & idDepartamento
        End If

        condicion &= " AND (E.idEmpleado = " & idEmpleado & ")"

        condicion &= " AND convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') >= E.fechaAlta AND (E.fechaBaja >= convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "') or E.fechaBaja is null)"

        cargarGridGen(grid, condicion, objEmp)
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Empleado"
            conex.accion = accion

            If idEmpleado = Nothing And esInsert Then
                conex.agregaCampo("idEmpleado", "(SELECT max(idEmpleado) + 1 FROM Empleado)", False, True)
            ElseIf nuevoID <> Nothing Then
                conex.agregaCampo("idEmpleado", nuevoID, False, False)
            End If

            conex.agregaCampo("nombreEmpleado", nombreEmpleado, False, False)
            conex.agregaCampo("apPatEmpleado", apPatEmpleado, False, False)
            conex.agregaCampo("apMatEmpleado", apMatEmpleado, False, False)
            conex.agregaCampo("idTipoUsuario", idTipoUsuario, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("usuario", usuario, True, False)
            conex.agregaCampo("password", password, True, False)
            conex.agregaCampo("pwdZK", pwdZK, True, False)
            conex.agregaCampo("nss", nss, True, False)
            conex.agregaCampo("rfc", rfc, True, False)
            conex.agregaCampo("idDepartamento", idDepartamento, True, False)
            conex.agregaCampo("idHorario", idHorario, True, False)
            'conex.agregaCampo("idHorarioComida", idHorarioComida, True, False)
            conex.agregaCampo("idCocina", idCocina, True, False)
            conex.agregaCampo("idTabulador", idTabulador, True, False)
            conex.agregaCampo("idEmpresa", idEmpresa, True, False)
            conex.agregaCampo("idSucursal", idSucursal, True, False)

            'MGMG 
            conex.agregaCampo("idRegimenFiscal", idRegimenFiscal, True, False)
            conex.agregaCampo("fechacambioReg", fechacambioReg, True, False)
            conex.agregaCampo("esDeudor", esDeudor, True, False)
            conex.agregaCampo("esNomina100p", esNomina100p, True, False)
            conex.agregaCampo("idNivelPuesto", idNivelPuesto, True, False)





            If esInsert Then
                    conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                    conex.agregaCampo("creadoPor", creadoPor, False, False)
                End If

                conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)
                conex.agregaCampo("rostro", rostro, True, False)
                conex.agregaCampo("huella0", huella0, True, False)
                conex.agregaCampo("huella1", huella1, True, False)
                conex.agregaCampo("huella2", huella2, True, False)
                conex.agregaCampo("huella3", huella3, True, False)
                conex.agregaCampo("huella4", huella4, True, False)
                conex.agregaCampo("huella5", huella5, True, False)
                conex.agregaCampo("huella6", huella6, True, False)
                conex.agregaCampo("huella7", huella7, True, False)
                conex.agregaCampo("huella8", huella8, True, False)
                conex.agregaCampo("huella9", huella9, True, False)
                conex.agregaCampo("perfilCalculo", perfilCalculo, True, False)
                conex.agregaCampo("tieneHorasExtrasAut", tieneHorasExtrasAut, True, False)
                conex.agregaCampo("forzarLimiteHorasExtras", forzarLimiteHorasExtras, True, False)
                conex.agregaCampo("cantidadHoras", cantidadHoras, True, False)
                conex.agregaCampo("sueldoSemanalIMSS", sueldoSemanalIMSS, True, False)
                conex.agregaCampo("idDestajoClasificacionPuntos", idDestajoClasificacionPuntos, True, False)
                conex.agregaCampo("idDestajoClasificacionEmpeado", idDestajoClasificacionEmpeado, True, False)
                conex.agregaCampo("fechaAlta", fechaAlta, False, False)
                conex.agregaCampo("fechaBaja", fechaBaja, True, False)
                conex.agregaCampo("tipoUsuarioSistema", tipoUsuarioSistema, False, False)
                conex.agregaCampo("diasVacacionesDisponibles", diasVacacionesDisponibles, True, False)
                conex.agregaCampo("esSupervisor", esSupervisor, False, False)
                conex.agregaCampo("numeroTarjeta", numeroTarjeta, True, False)
                conex.agregaCampo("desarrollador", desarrollador, True, False)
                conex.agregaCampo("correoEmpresa", correoEmpresa, True, False)
                conex.agregaCampo("correoPersonal", correoPersonal, True, False)
                conex.agregaCampo("idArea", idArea, False, False)
                conex.agregaCampo("idRegistroPatronal", idRegistroPatronal, False, False)
                conex.agregaCampo("idUMF", idUMF, True, False)
                conex.agregaCampo("idLugarNacimiento", idLugarNacimiento, True, False)
                conex.agregaCampo("curp", curp, True, False)
                conex.agregaCampo("idPuesto", idPuesto, True, False)
                conex.agregaCampo("fechaNacimiento", fechaNacimiento, True, False)
                conex.agregaCampo("SDI", SDI, True, False)
                conex.agregaCampo("genero", genero, True, False)
                conex.agregaCampo("bancoPago", bancoPago, True, False)
                conex.agregaCampo("sucursalPago", sucursalPago, True, False)
                conex.agregaCampo("numCuentaPago", numCuentaPago, True, False)
                conex.agregaCampo("clabePago", clabePago, True, False)
                conex.agregaCampo("noBorrarMisIncidencias", noBorrarMisIncidencias, True, False)
                conex.agregaCampo("tieneInfonavit", tieneInfonavit, True, False)
                conex.agregaCampo("tieneFonacot", tieneFonacot, True, False)
                conex.agregaCampo("estadoCivil", estadoCivil, True, False)
                conex.agregaCampo("escolaridad", escolaridad, True, False)
                conex.agregaCampo("nombrePadre", nombrePadre, True, False)
                conex.agregaCampo("nombreMadre", nombreMadre, True, False)
                conex.agregaCampo("telcontacto", telcontacto, True, False)
                conex.agregaCampo("telred", telred, True, False)
                conex.agregaCampo("compania", compania, True, False)
                conex.agregaCampo("nocontratobancario", nocontratobancario, True, False)
                conex.agregaCampo("numcreditoinfonavit", numcreditoinfonavit, True, False)
                conex.agregaCampo("factordescuentoinfonavit", factordescuentoinfonavit, True, False)
                conex.agregaCampo("retencioninfonavit", retencioninfonavit, True, False)
            conex.agregaCampo("telcasa", telcasa, True, False)
            conex.agregaCampo("no_cheque", no_cheque, True, False)
            conex.agregaCampo("motivoContratacion", motivoContratacion, True, False)
            conex.agregaCampo("nacionalidad", nacionalidad, True, False)
            conex.agregaCampo("idSueldoIMSS", idSueldoIMSS, True, False)
            conex.agregaCampo("idFactorIntegracion", idFactorIntegracion, True, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idEmpleado = " & idEmpleado
            conex.armarQry()
            If conex.ejecutaQry Then
                    procesaPermisos()
                    Return True
                Else
                    idError = conex.idError
                    descripError = conex.descripError
                    Return False
                End If
            Else
                Return False
        End If
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        objActualizadoPor = Nothing
        objEmpresa = Nothing
        objSucursal = Nothing
        objDepartamento = Nothing

        objHorario = Nothing
        objTabulador = Nothing
        objCocina = Nothing

        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        conex.Qry = "DELETE FROM Empleado WHERE idEmpleado =" & idEmpleado
        conex.numCon = 0
        If conex.ejecutaQry Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function



    Public Function activaEmpleado() As Boolean
        conex.numCon = 0
        conex.agregaCampo("fechaBaja", fechaBaja, True, False)
        conex.Qry = "Update Empleado SET
                esActivo = 1 , fechaBaja = null,
               actualizado = CURRENT_TIMESTAMP, 
               actualizadoPor = " & Ambiente.usuario.idEmpleado & " WHERE idEmpleado = " & idEmpleado
        If conex.ejecutaQry Then
            procesaPermisos()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If nuevo Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        actualizadoPor = Ambiente.usuario.idEmpleado

        If perfilCalculo <> "Destajista" Then
            idDestajoClasificacionPuntos = Nothing
            idDestajoClasificacionEmpeado = Nothing
        End If

        If nombreEmpleado = Nothing Then
            idError = 1
            descripError = "El nombre del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf apPatEmpleado = Nothing Then
            idError = 2
            descripError = "El apellido paterno del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf apMatEmpleado = Nothing Then
            idError = 3
            descripError = "El apellido materno del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf idTipoUsuario = -1 Then
            idError = 4
            descripError = "El tipo de Usuario del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf rfc = Nothing Then
            idError = 6
            descripError = "El RFC del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf idDepartamento = Nothing Then
            idError = 7
            descripError = "El Departamento del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf idHorario = Nothing Then
            idError = 8
            descripError = "El Horario Asignado del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf idCocina = Nothing Then
            idError = 9
            descripError = "La Cocina del Empleado es un VALOR Obligatorio..."
            Return False
        ElseIf idTabulador = Nothing Then
            idError = 10
            descripError = "El Tabulador del Empleado es un VALOR Obligatorio..."
            Return False
            'ElseIf idHorarioComida = Nothing Then
            '    idError = 11
            '    descripError = "El Horario de Comida del Empleado es un VALOR Obligatorio..."
            '    Return False
        ElseIf idArea = Nothing Then
            idError = 11
            descripError = "El necesario seleccionar una Área, a la que pertece..."
            Return False
        ElseIf perfilCalculo = Nothing Then
            idError = 12
            descripError = "El Perfil de Cálculos del Empleado es un VALOR Obligatorio..."
            Return False
            'ElseIf perfilCalculo = "Destajista" Then
            '    If idDestajoClasificacionPuntos = Nothing Then
            '        idError = 14
            '        descripError = "Es necesario indicar la clasificación de Puntos para el empleado, siendo un VALOR Obligatorio para los destajistas..."
            '        Return False
            '    ElseIf idDestajoClasificacionEmpeado = Nothing Then
            '        idError = 15
            '        descripError = "Es necesario indicar la clasificación ""TIPO de DESTAJISTA"" para el empleado, siendo un VALOR Obligatorio para los destajistas..."
            '        Return False
            '    End If
        ElseIf tipoUsuarioSistema = Nothing Then
            idError = 16
            descripError = "El tipo de usuario para el acceso al sistema es un VALOR Obligatorio..."
            Return False
        ElseIf idSueldoIMSS = Nothing Then
            idError = 17
            descripError = "El Sueldo en IMSS es obligatorio..."
            Return False
        ElseIf idFactorIntegracion = Nothing Then
            idError = 18
            descripError = "El factor de integración es obligatorio..."
            Return False
        End If

        Return True
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idEmpleado & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function getEmpleadosXDepartamento(obj As List(Of Empleado), cond As String) As Boolean
        Dim plantilla As Empleado
        obj.Clear()
        conex.Qry = "SELECT e.* FROM Empleado AS e INNER JOIN Departamento AS d ON e.idDepartamento=d.idDepartamento WHERE d.idEmpresa=" & idEmpresa & " AND e.esActivo=1 " & cond
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Empleado(Ambiente)
                plantilla.seteaDatos(conex.reader)
                obj.Add(plantilla)
            End While
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub procesaPermisos()

        If usuario = Nothing Then
            conex.Qry = "DELETE FROM AccesoEmpleado WHERE idEmpleado = " & idEmpleado
        ElseIf usuario <> Nothing Then
            conex.Qry = "INSERT INTO [dbo].[AccesoEmpleado] (idEmpleado, nombreTabla, creado, creadoPor, actualizado, actualizadoPor, soloLectura, idAcceso, activa, idElementoSistema)
                            VALUES (" & idEmpleado & ",'Empresa',CURRENT_TIMESTAMP, " & Ambiente.usuario.idEmpleado & ", CURRENT_TIMESTAMP," & Ambiente.usuario.idEmpleado & ", 1, " & Ambiente.empr.idEmpresa & ", 1, 1);"
            conex.Qry &= "INSERT INTO [dbo].[AccesoEmpleado] (idEmpleado, nombreTabla, creado, creadoPor, actualizado, actualizadoPor, soloLectura, idAcceso, activa, idElementoSistema)
                            VALUES (" & idEmpleado & ",'Sucursal',CURRENT_TIMESTAMP, " & Ambiente.usuario.idEmpleado & ", CURRENT_TIMESTAMP," & Ambiente.usuario.idEmpleado & ", 1, " & Ambiente.suc.idSucursal & ", 1, 1);"
            conex.Qry &= "EXEC spCreaMenuAcceso " & idEmpleado & ",1,1,1"

        End If

        conex.ejecutaQry()
    End Sub


    Public Sub RPT_ImprimirReporte60d()
        creaReporte60d()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte60d()
        creaReporte60d()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaReporte60d()
        rptDatos = New Reporte(Ambiente, "Empleado", "Reporte60d")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub


    Public Sub RPT_ImprimirRenuncia()
        creaRenuncia()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarRenuncia()
        creaRenuncia()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaRenuncia()
        rptDatos = New Reporte(Ambiente, "Empleado", "Renuncia")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub


    Public Sub RPT_ImprimirConvenioVM()
        creaDSConvenioVM()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarConvenioVM()
        creaDSConvenioVM()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSConvenioVM()
        rptDatos = New Reporte(Ambiente, "Empleado", "ConvenioVM")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirReporte30d()
        creaReporte30d()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporte30d()
        creaReporte30d()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaReporte30d()
        rptDatos = New Reporte(Ambiente, "Empleado", "Reporte30d")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub


    '======= EMPLEADO NUMERO DE CUENTA
    Private Sub creaReporteEmpCuentBanco()
        rptDatos = New Reporte(Ambiente, "Empleado", "EmpCuentBanco")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirReporteEmpCuentBanco()
        creaReporteEmpCuentBanco()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporteEmpCuentBanco()
        creaReporteEmpCuentBanco()
        rptDatos.modificar(dsDatos)
    End Sub
    '=============

    '======= EMPLEADO AVISO DE PRiVACIDAD
    Private Sub creaReporteEmpAvisoPrivacidad()
        rptDatos = New Reporte(Ambiente, "Empleado", "EmpAvisoPrivacidad")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirReporteEmpAvisoPrivacidad()
        creaReporteEmpAvisoPrivacidad()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporteEmpAvisoPrivacidad()
        creaReporteEmpAvisoPrivacidad()
        rptDatos.modificar(dsDatos)
    End Sub
    '=============


    '======= EMPLEADO Etiqueta
    Private Sub creaReporteEmpEtiqueta()
        rptDatos = New Reporte(Ambiente, "Empleado", "EmpEtiqueta")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIdEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirReporteEmpEtiqueta()
        creaReporteEmpEtiqueta()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarReporteEmpEtiqueta()
        creaReporteEmpEtiqueta()
        rptDatos.modificar(dsDatos)
    End Sub
    '=============


    '======= EMPLEADO Convenio de Liquidación
    Private Sub creaConvenioLiq()
        rptDatos = New Reporte(Ambiente, "Empleado", "ConvenioLiq")
        dsDatos = New DataSet
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("idEmpleado", idEmpleado, GetType(Integer))
        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirConvenioLiq()
        creaConvenioLiq()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarConvenioLiq()
        creaConvenioLiq()
        rptDatos.modificar(dsDatos)
    End Sub
    '=============


    Public Sub RPT_ImprimirConvenio()
        creaDSConvenio()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarConvenio()
        creaDSConvenio()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSConvenio()
        rptDatos = New Reporte(Ambiente, "Empleado", "Convenio")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vidEmp", idEmpleado, GetType(Integer))
    End Sub

    Public Sub RPT_ImprimirFormatoNeg()
        creaDSFormatoNeg()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarFormatoNeg()
        creaDSFormatoNeg()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSFormatoNeg()
        rptDatos = New Reporte(Ambiente, "Empleado", "FormatoNeg")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIDEmpl", idEmpleado, GetType(Integer))
    End Sub


    Public Sub RPT_ImprimirContratoDeterminado()
        creaDSContratoDeterminado()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarContratoDeterminado()
        creaDSContratoDeterminado()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSContratoDeterminado()
        rptDatos = New Reporte(Ambiente, "Empleado", "ContratoDeterminado")
        dsDatos = New DataSet

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
        rptDatos.agregaVarible("vIDEmpl", idEmpleado, GetType(Integer))
    End Sub
End Class