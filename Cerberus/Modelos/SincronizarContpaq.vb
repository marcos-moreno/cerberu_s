Public Class SincronizarContpaq
    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private conexionesCTQ As New List(Of ConexionSQL)
    Private orig As Origen
    Private origenes As New List(Of Origen)

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        orig = New Origen(Ambiente)
        orig.idEmpresa = Ambiente.empr.idEmpresa
        orig.elemento = "Nomina"
        orig.getComboActivo(New ComboBox, origenes)

        conexionesCTQ.Clear()
        For i As Integer = 0 To origenes.Count - 1
            conexionesCTQ.Add(New ConexionSQL(origenes(i).direccionIP & "\" & origenes(i).instancia, origenes(i).nombreBD, origenes(i).usuario, origenes(i).contrasena, 1))
        Next
    End Sub

    Public Function creaProcedimientos() As Boolean
        descripError = ""
        idError = 0

        conexionesCTQ(0).Qry = "DROP PROCEDURE [spCreaIncidencia]; DROP PROCEDURE [spGetNomina]; DROP FUNCTION [getDiasDisponibles];"
        conexionesCTQ(0).ejecutaQry()

        conexionesCTQ(0).Qry = "CREATE PROCEDURE [dbo].[spCreaIncidencia] 
(
	@idPeriodo INT, 
	@nss NVARCHAR(15), 
	@idTipoIncidencia INT,
	@fecha DATE,
	@dias INT,
	@prima DECIMAL(18,2),
	@estado INT OUT
)
AS

DECLARE @idControlVac INT
DECLARE @idEmpleado INT
SET @idControlVac = 0
DECLARE @contador INT
SET @contador = 0

SET @idEmpleado = (SELECT idempleado FROM NOM10001 WHERE numerosegurosocial = @nss)

IF NOT EXISTS(SELECT * FROM NOM10010 WHERE idempleado = @idEmpleado AND fecha = @fecha AND idPeriodo = @idPeriodo)
	BEGIN
		IF @idTipoIncidencia = 14 --CUANDO ES VACACIÓN
		BEGIN
			INSERT INTO NOM10014 (idempleado,ejercicio,diasvacaciones,diasprimavacacional,fechainicio,fechafin,timestamp,fechapago)
			VALUES (@idEmpleado,year(@fecha),@dias,@prima,@fecha,DATEADD(DAY,@dias-1,@fecha),CURRENT_TIMESTAMP,DATEADD(DAY,@dias-1,@fecha))
	
			SET @idControlVac = (SELECT @@IDENTITY)
		END

		--CREA LA INCIDENCIA

		WHILE @contador < @dias
		BEGIN
			INSERT INTO NOM10010 (idperiodo,idempleado,idtipoincidencia,idtarjetaincapacidad,idtcontrolvacaciones,fecha,valor,timestamp) 
			VALUES (@idPeriodo,@idEmpleado,@idTipoIncidencia,0,@idControlVac,DATEADD(DAY,@contador,@fecha),1,CURRENT_TIMESTAMP)

			SET @contador = @contador + 1
		END
			
		--SE GENERO DE MANERA CORRECTA
		SET @estado = 0
	END
ELSE
	BEGIN
		SET @estado = 1 --YA EXISTE MOVIMIENTO
	END"

        If Not conexionesCTQ(0).ejecutaQry() Then
            idError = 1
            descripError = conexionesCTQ(0).descripError & vbCrLf
        End If

        conexionesCTQ(0).Qry = "CREATE PROCEDURE [dbo].[spGetNomina] (@idPeriodo INT)
                                    AS
                                    IF EXISTS (SELECT * FROM [nom10008] WHERE idperiodo = @idPeriodo)
	                                    BEGIN
		                                    SELECT 
			                                    H.idPeriodo,
			                                    E.idempleado,
			                                    E.numerosegurosocial,
			                                    E.nombreLargo,
			                                    sum(H.importetotal) as totalNomina,
			                                    concat('(',ejercicio,'-',numeroperiodo,') ',convert(date,fechainicio),'-',convert(date,fechafin)) as datosPeriodo
		                                    FROM 
			                                    [dbo].[nom10008] as H,
			                                    [dbo].[nom10004] as C,
			                                    [dbo].[nom10001] as E,
			                                    [dbo].[nom10002] as P
		                                    WHERE
			                                    H.idconcepto = C.idconcepto
			                                    AND P.idperiodo = H.idPeriodo
			                                    AND E.idempleado = H.idempleado
			                                    AND C.idconcepto in (3,4,20)
			                                    AND H.idPeriodo = @idPeriodo
		                                    GROUP BY
			                                    E.idempleado,
			                                    E.numerosegurosocial,
			                                    E.nombreLargo,
			                                    H.idPeriodo,
			                                    P.ejercicio,
			                                    P.numeroperiodo,
			                                    P.fechainicio,
			                                    P.fechafin
	                                    END
                                    ELSE
	                                    BEGIN
		                                    SELECT 
			                                    H.idPeriodo,
			                                    E.idempleado,
			                                    E.numerosegurosocial,
			                                    E.nombreLargo,
			                                    sum(H.importetotal) as totalNomina,
			                                    concat('(',ejercicio,'-',numeroperiodo,') ',convert(date,fechainicio),'-',convert(date,fechafin)) as datosPeriodo
		                                    FROM 
			                                    [dbo].[nom10007] as H,
			                                    [dbo].[nom10004] as C,
			                                    [dbo].[nom10001] as E,
			                                    [dbo].[nom10002] as P
		                                    WHERE
			                                    H.idconcepto = C.idconcepto
			                                    AND P.idperiodo = H.idPeriodo
			                                    AND E.idempleado = H.idempleado
			                                    AND C.idconcepto in (3,4,20)
			                                    AND H.idPeriodo = @idPeriodo
		                                    GROUP BY
			                                    E.idempleado,
			                                    E.numerosegurosocial,
			                                    E.nombreLargo,
			                                    H.idPeriodo,
			                                    P.ejercicio,
			                                    P.numeroperiodo,
			                                    P.fechainicio,
			                                    P.fechafin
	                                    END"

        If Not conexionesCTQ(0).ejecutaQry() Then
            idError = 2
            descripError &= conexionesCTQ(0).descripError & vbCrLf
        End If

        conexionesCTQ(0).Qry = "CREATE FUNCTION [dbo].[getDiasDisponibles](@idEmpleado INT)
                                    RETURNS INT
                                    BEGIN
	                                    DECLARE @retorno INT

	                                    SET @retorno =(
					                                    SELECT 
						                                    sum(t4.valor) - (SELECT sum(diasvacaciones) FROM NOM10014 WHERE idEmpleado = @idEmpleado and fechaInicio > (SELECT iif(fechaReingreso = convert(date,'1899-12-30'),fechaAlta,fechaReingreso) FROM NOM10001 where idEmpleado = @idEmpleado))
					                                    FROM 
						                                    NOM10028 as t1 
							                                    INNER JOIN NOM10029 t2 ON t1.numerotabla = t2.numerotabla and t1.numerocolumna = t2.numerocolumna
							                                    INNER JOIN NOM10028 t3 ON t3.numerotabla = t1.numerotabla 
							                                    INNER JOIN NOM10029 as t4 ON t3.numerotabla = t4.numerotabla and t3.numerocolumna = t4.numerocolumna AND t2.numerorenglon = t4.numerorenglon
					                                    where 
						                                    t1.numerocolumna = 0 and t1.numerotabla = 1
						                                    and t3.numerocolumna = 1
						                                    AND t2.valor <= (SELECT 
											                                    (datediff(month,iif(fechaReingreso = convert(date,'1899-12-30'),fechaAlta,fechaReingreso), CURRENT_TIMESTAMP) 
											                                    - datediff(month,iif(fechaReingreso = convert(date,'1899-12-30'),fechaAlta,fechaReingreso), CURRENT_TIMESTAMP) % 12) / 12 FROM NOM10001 where idEmpleado = @idEmpleado)
					                                    )

	                                    RETURN isNull(@retorno,0)
                                    END"

        If Not conexionesCTQ(0).ejecutaQry() Then
            idError = 3
            descripError &= conexionesCTQ(0).descripError & vbCrLf
        End If

        If idError <> 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function creaIncidencias(objPeriodo As Periodo, idPeriodoCTPQ As Integer) As Boolean
        Dim reporte As String
        Dim objIncidencias As New List(Of Incidencia)
        Dim objInci As New Incidencia(Ambiente)
        objInci.idEmpresa = Ambiente.empr.idEmpresa
        objInci.getInicidenciaXRangoFechasCTPQ(objIncidencias, objPeriodo.inicioPeriodo, objPeriodo.finPeriodo)

        Dim objEmpl As New Empleado(Ambiente)
        Dim objTipoInci As New TipoIncidencia(Ambiente)

        'Para vacaciones
        Dim dias As Integer
        Dim emplAnt As Integer
        Dim emplAct As Integer
        Dim nssAnt As String
        Dim fechaAnt As Date
        Dim fechaAct As Date
        Dim inciAnt As String
        Dim idInciAnt As Integer
        Dim inciAct As String
        Dim pagaPrimaVac As Boolean

        Dim guardar As Boolean
        Dim guardarAnt As Boolean

        reporte = ""

        For i As Integer = 0 To objIncidencias.Count - 1
            objEmpl.idEmpleado = objIncidencias(i).idEmpleado
            objEmpl.buscarPID()

            If objEmpl.nss <> "" And objEmpl.nss <> "0" Then
                objTipoInci.idTipoIncidencia = objIncidencias(i).idTipoIncidencia
                objTipoInci.buscarPID()

                emplAct = objEmpl.idEmpleado
                fechaAct = DateAdd(DateInterval.Day, objPeriodo.desfaceCONTPAQ * -1, objIncidencias(i).fecha)
                inciAct = objTipoInci.codigoIncidencia

                If inciAct = "VD" And (inciAct = inciAnt Or inciAnt = Nothing) And (emplAct = emplAnt Or emplAnt = Nothing) And (fechaAct = fechaAnt.AddDays(1) Or fechaAnt = Nothing) Then
                    dias += 1
                    guardarAnt = False

                    If objIncidencias.Count = 1 Then
                        guardar = True
                    Else
                        guardar = False
                    End If

                ElseIf inciAnt = "VD" Then
                    guardarAnt = True

                    If i = objIncidencias.Count - 1 Then
                        guardar = True
                    Else
                        guardar = False
                    End If

                Else
                    dias = 1
                    guardar = True
                    If inciAnt <> "VD" Then
                        guardarAnt = True
                    Else
                        guardarAnt = False
                    End If
                End If

                Dim objParam(6, 2) As Object
                    Dim objParamOUT(1, 2) As Object

                    If guardarAnt Then
                        objParam(0, 0) = "@idPeriodo"
                        objParam(0, 1) = idPeriodoCTPQ

                        objParam(1, 0) = "@nss"
                        objParam(1, 1) = nssAnt

                        objParam(2, 0) = "@idTipoIncidencia"
                        objParam(2, 1) = idInciAnt

                        objParam(3, 0) = "@fecha"
                        objParam(3, 1) = DateAdd(DateInterval.Day, (dias - 1) * -1, fechaAnt)

                        objParam(4, 0) = "@dias"
                        objParam(4, 1) = dias

                        objParam(5, 0) = "@prima"
                        objParam(5, 1) = If(pagaPrimaVac, dias * 0.25, 0)


                        objParamOUT(0, 0) = "@estado"
                        objParamOUT(0, 1) = SqlDbType.Int

                        conexionesCTQ(0).numCon = 0
                        conexionesCTQ(0).Qry = "spCreaIncidencia"

                        If conexionesCTQ(0).ejecutaSP(objParam, objParamOUT) Then
                            conexionesCTQ(0).reader.Close()
                        Else
                            idError = conexionesCTQ(0).idError
                            descripError = conexionesCTQ(0).descripError
                            reporte &= "(" & emplAct & ") " & objEmpl.nombreCompleto & " - " & objTipoInci.nombreIncidencia & " - " & fechaAct & " - ERROR (" & descripError & ")" & vbCrLf
                        End If

                        If objParamOUT(0, 1) = 1 Then
                            'reporte &= "(" & objEmpl.idEmpleado & ") " & objEmpl.nombreCompleto & " - " & objTipoInci.nombreIncidencia & " - " & objIncidencias(i).fecha & " - DUPLICADO" & vbCrLf
                        End If

                        dias = 1
                    End If



                    objParam(0, 0) = "@idPeriodo"
                    objParam(0, 1) = idPeriodoCTPQ

                    objParam(1, 0) = "@nss"
                    objParam(1, 1) = objEmpl.nss

                    objParam(2, 0) = "@idTipoIncidencia"
                    objParam(2, 1) = objTipoInci.idTipoIncidenciaCTPQ

                    objParam(3, 0) = "@fecha"
                    objParam(3, 1) = fechaAct

                    objParam(4, 0) = "@dias"
                    objParam(4, 1) = dias

                    objParam(5, 0) = "@prima"
                    objParam(5, 1) = If(objTipoInci.pagaPrimaVac, dias * 0.25, 0)



                    objParamOUT(0, 0) = "@estado"
                    objParamOUT(0, 1) = SqlDbType.Int

                    conexionesCTQ(0).numCon = 0
                    conexionesCTQ(0).Qry = "spCreaIncidencia"

                    If guardar Then
                        If conexionesCTQ(0).ejecutaSP(objParam, objParamOUT) Then
                            conexionesCTQ(0).reader.Close()
                        Else
                            idError = conexionesCTQ(0).idError
                            descripError = conexionesCTQ(0).descripError
                            reporte &= "(" & emplAct & ") " & objEmpl.nombreCompleto & " - " & objTipoInci.nombreIncidencia & " - " & fechaAct & " - ERROR (" & descripError & ")" & vbCrLf
                        End If

                        If objParamOUT(0, 1) = 1 Then
                            'reporte &= "(" & objEmpl.idEmpleado & ") " & objEmpl.nombreCompleto & " - " & objTipoInci.nombreIncidencia & " - " & objIncidencias(i).fecha & " - DUPLICADO" & vbCrLf
                        End If
                    End If

                    emplAnt = emplAct
                    fechaAnt = fechaAct
                    inciAnt = objTipoInci.codigoIncidencia
                    idInciAnt = objTipoInci.idTipoIncidenciaCTPQ
                    pagaPrimaVac = objTipoInci.pagaPrimaVac
                    nssAnt = objEmpl.nss
                End If
        Next

        If reporte <> "" Then
            idError = 1
            descripError = reporte
            Return False
        Else
            Return True
        End If


    End Function

    Public Function getComboPeriodoCTPQxID(combo As ComboBox, objCombo As List(Of Integer), idPeriodoCTPQ As Integer) As Boolean
        Dim filtro As String
        filtro = "AND idperiodo = " & idPeriodoCTPQ

        Return getComboPeriodoCTPQ(combo, objCombo, filtro)
    End Function

    Public Function getComboPeriodoCTPQ(combo As ComboBox, objCombo As List(Of Integer), filtro As String) As Boolean
        idError = 0
        descripError = ""

        objCombo.Clear()
        combo.Items.Clear()

        If conexionesCTQ.Count = 0 Then
            descripError = "No existen datos de conexion a CONTPAQi Nominas"
            Return False
        End If

        conexionesCTQ(0).numCon = 0

        conexionesCTQ(0).Qry = "Select
                        idperiodo,
                        concat(tp.nombretipoperiodo, ' (',p.ejercicio,'-',numeroperiodo,') ',convert(date,fechainicio),'-',convert(date,fechafin)) as datos 
                        FROM 
                        nom10002 as p INNER JOIN NOM10023 as tp 
						ON p.idtipoperiodo = tp.idtipoperiodo
                                WHERE
                                p.ejercicio >= Year(CURRENT_TIMESTAMP) " & filtro & "
	                    ORDER BY 
						tp.nombretipoperiodo,
                        p.ejercicio,
                        numeroPeriodo"

        If conexionesCTQ(0).ejecutaConsulta Then
            While conexionesCTQ(0).reader.Read
                combo.Items.Add(conexionesCTQ(0).reader("datos"))
                objCombo.Add(conexionesCTQ(0).reader("idperiodo"))
            End While
            conexionesCTQ(0).reader.Close()

            Return True
        Else
            idError = conexionesCTQ(0).idError
            descripError = conexionesCTQ(0).descripError
            Return False
        End If
    End Function

    Public Function getComboTipoPeriodosCTPQxID(combo As ComboBox, objCombo As List(Of Integer), idPeriodoCTPQ As Integer) As Boolean
        Dim filtro As String
        filtro = "AND idperiodo = " & idPeriodoCTPQ

        Return getComboPeriodoCTPQ(combo, objCombo, filtro)
    End Function

    Public Function getComboTipoPeriodosCTPQ(combo As ComboBox, objCombo As List(Of Integer), filtro As String) As Boolean
        idError = 0
        descripError = ""

        objCombo.Clear()
        combo.Items.Clear()

        If conexionesCTQ.Count = 0 Then
            descripError = "No existen datos de conexión a CONTPAQi Nominas"
            Return False
        End If

        conexionesCTQ(0).numCon = 0

        conexionesCTQ(0).Qry = "select idtipoperiodo,nombretipoperiodo from NOM10023"

        If conexionesCTQ(0).ejecutaConsulta Then
            While conexionesCTQ(0).reader.Read
                combo.Items.Add(conexionesCTQ(0).reader("nombretipoperiodo"))
                objCombo.Add(conexionesCTQ(0).reader("idtipoperiodo"))
            End While
            conexionesCTQ(0).reader.Close()

            Return True
        Else
            idError = conexionesCTQ(0).idError
            descripError = conexionesCTQ(0).descripError
            Return False
        End If
    End Function

    Public Sub cargaGridInciencias(dgv As DataGridView, ids As List(Of Integer))
        Dim dtb As New DataTable("Dispositivo")
        Dim row As DataRow
        Dim indice As Integer = 0

        dtb.Columns.Add("ID", Type.GetType("System.String"))
        dtb.Columns.Add("Nombre", Type.GetType("System.String"))

        ids.Clear()

        conexionesCTQ(0).Qry = "SELECT idTipoIncidencia, descripcion FROM NOM10022"

        conexionesCTQ(0).numCon = 0
        If conexionesCTQ(0).ejecutaConsulta() Then
            While conexionesCTQ(0).reader.Read
                ids.Add(conexionesCTQ(0).reader("idTipoIncidencia"))

                row = dtb.NewRow
                row("ID") = conexionesCTQ(0).reader("idTipoIncidencia")
                row("Nombre") = conexionesCTQ(0).reader("descripcion")

                dtb.Rows.Add(row)
                indice += 1
            End While
            conexionesCTQ(0).reader.Close()

            dgv.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "SincronizaContpaq.cargaGridInciencias"
            Mensaje.Mensaje = conexionesCTQ(0).descripError
            Mensaje.ShowDialog()
        End If

    End Sub

    Public Function sincronizaPeriodos(nombrePers As String, idConceptoCuentaAbono As Integer, idConceptoCuentaCargo As Integer, idVariableFormula As Integer) As Boolean
        Dim conexCTQ As ConexionSQL
        Dim objPer As Periodo
        Dim idsExtraidos As String

        objPer = New Periodo(Ambiente)
        objPer.idEmpresa = Ambiente.empr.idEmpresa
        objPer.tabla = "Registro"
        objPer.elementoSistema = "ES"
        idsExtraidos = objPer.getIDsCOMPAC()

        idError = 0
        descripError = ""

        For i As Integer = 0 To conexionesCTQ.Count - 1
            conexCTQ = conexionesCTQ(i)

            conexCTQ.numCon = 0

            conexCTQ.accion = "SELECT"

            conexCTQ.agregaCampo("ejercicio")
            conexCTQ.agregaCampo("numeroperiodo")
            conexCTQ.agregaCampo("fechainicio")
            conexCTQ.agregaCampo("fechafin")

            conexCTQ.tabla = "NOM10002 as P"
            conexCTQ.condicion = "where idperiodo not  in (" & idsExtraidos & ") AND idtipoperiodo = 2"
            conexCTQ.armarQry()

            If conexCTQ.ejecutaConsulta Then
                While conexCTQ.reader.Read
                    objPer = New Periodo(Ambiente)
                    objPer.idEmpresa = Ambiente.empr.idEmpresa
                    objPer.idSucursal = Ambiente.suc.idSucursal
                    objPer.tabla = "Registro"
                    objPer.elementoSistema = "ES"
                    objPer.inicioPeriodo = conexCTQ.reader("fechainicio")
                    objPer.finPeriodo = conexCTQ.reader("fechafin")
                    objPer.ejercicio = conexCTQ.reader("ejercicio")
                    objPer.numeroPeriodo = conexCTQ.reader("numeroperiodo")
                    objPer.nombrePeriodo = UCase(nombrePers) & " " & objPer.numeroPeriodo
                    objPer.esActivo = 1
                    objPer.idConceptoCuentaAbono = idConceptoCuentaAbono
                    objPer.idConceptoCuentaCargo = idConceptoCuentaCargo
                    objPer.idVariableFormula = idVariableFormula

                    If Not objPer.guardar() Then
                        idError = objPer.idError
                        descripError &= objPer.descripError & vbCrLf
                    End If
                End While
                conexCTQ.reader.Close()
            Else
                idError = conexCTQ.idError
                descripError = conexCTQ.descripError
            End If
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Function sincronizarEmpleados(empleados As Boolean, actualizarVac As Boolean, todos As Boolean, filtro As String, idTipoPerido As Integer) As Boolean
        Dim encontrado As Boolean
        Dim actualizaciones As Integer
        Dim altas As Integer
        Dim empl As Empleado
        idError = 0
        descripError = ""

        actualizaciones = 0
        altas = 0

        Dim conexCTQ As ConexionSQL

        For i As Integer = 0 To conexionesCTQ.Count - 1
            conexCTQ = conexionesCTQ(i)

            conexCTQ.numCon = 0

            conexCTQ.accion = "SELECT"
            conexCTQ.agregaCampo("sueldodiario*7 as sueldoSemanal")
            conexCTQ.agregaCampo("numerosegurosocial")
            conexCTQ.agregaCampo("nombre")
            conexCTQ.agregaCampo("apellidopaterno")
            conexCTQ.agregaCampo("apellidomaterno")
            conexCTQ.agregaCampo("numerosegurosocial")
            conexCTQ.agregaCampo("fechaalta")
            conexCTQ.agregaCampo("sueldointegrado")
            conexCTQ.agregaCampo("fechanacimiento")
            conexCTQ.agregaCampo("lugarnacimiento")
            conexCTQ.agregaCampo("curpi+replace(convert(varchar(10),fechanacimiento,11),'/','')+curpf as Curp")
            conexCTQ.agregaCampo("rfc+replace(convert(varchar(10),fechanacimiento,11),'/','')+homoclave as rfc")
            conexCTQ.agregaCampo("case when fechaReingreso = convert(date,'1899-12-30') then fechaAlta else fechaReingreso end as fecAlta")
            conexCTQ.agregaCampo("sueldoDiario")
            conexCTQ.agregaCampo("EstadoEmpleado")
            conexCTQ.agregaCampo("umf")
            conexCTQ.agregaCampo("sexo")
            conexCTQ.agregaCampo("correoElectronico")
            conexCTQ.agregaCampo("clabeInterbancaria")
            conexCTQ.agregaCampo("bancoPagoElectronico")
            conexCTQ.agregaCampo("cuentaPagoElectronico")
            conexCTQ.agregaCampo("sucursalPagoElectronico")
            conexCTQ.agregaCampo("(select P.descripcion from NOM10006 as P where P.idPuesto = E.idpuesto) as nPuesto")
            conexCTQ.agregaCampo("(select D.descripcion from NOM10003 as D where D.idDepartamento = E.idDepartamento) as nDepartamento")
            conexCTQ.agregaCampo("dbo.getDiasDisponibles(E.idEmpleado) as diasVacDisponibles")

            conexCTQ.tabla = "nom10001 as E"

            conexCTQ.condicion = "WHERE EstadoEmpleado IN ('A','R') "

            If filtro.Length >= 2 And todos = False Then
                If filtro.Trim.Substring(0, 1) = ">" Or filtro.Trim.Substring(0, 1) = "<" Then
                    filtro = Replace(filtro, ">", ">'")
                    filtro = Replace(filtro, "<", "<'")
                    conexCTQ.condicion &= "AND codigoempleado" & filtro & "'"
                ElseIf filtro.Trim.Substring(0, 1) = "=" Then
                    filtro = Replace(filtro, "=", "='")
                    conexCTQ.condicion &= "AND codigoempleado" & filtro & "'"
                ElseIf filtro.IndexOf("-") <> -1 Then
                    Dim cadenas() As String
                    cadenas = Split(filtro, "-")

                    If cadenas.Length >= 2 Then
                        conexCTQ.condicion &= "AND codigoempleado between '" & cadenas(0) & "' AND '" & cadenas(1) & "'"
                    Else
                        descripError = "Parametros inválidos"
                        Return False
                    End If
                Else
                    descripError = "Parametros inválidos"
                    Return False
                End If
            End If


            If idTipoPerido <> 0 Then
                conexCTQ.condicion &= " AND idtipoperiodo=" & idTipoPerido
            End If


            conexCTQ.armarQry()

            If conexCTQ.ejecutaConsulta Then
                encontrado = False

                While conexCTQ.reader.Read

                    empl = New Empleado(Ambiente)
                    empl.nss = Trim(conexCTQ.reader("numerosegurosocial"))

                    If empl.buscarPNSS() Then
                        encontrado = True
                        actualizaciones += 1
                    Else
                        encontrado = False
                        altas += 1
                    End If

                    If empleados Then

                        empl.esActivo = If(conexCTQ.reader("EstadoEmpleado") = "A" Or conexCTQ.reader("EstadoEmpleado") = "R", 1, 0)
                        empl.idEmpresa = Ambiente.empr.idEmpresa
                        empl.idSucursal = Ambiente.suc.idSucursal

                        empl.apPatEmpleado = UCase(Trim(conexCTQ.reader("apellidopaterno")))
                        empl.apMatEmpleado = UCase(Trim(conexCTQ.reader("apellidomaterno")))
                        empl.nombreEmpleado = UCase(Trim(conexCTQ.reader("nombre")))
                        empl.fechaAlta = conexCTQ.reader("fecAlta")
                        empl.SD = conexCTQ.reader("sueldoDiario")
                        empl.SDI = conexCTQ.reader("sueldointegrado")
                        empl.correoPersonal = conexCTQ.reader("correoElectronico")

                        empl.genero = If(conexCTQ.reader("sexo") = "M", "MASCULINO", "FEMENINO")
                        empl.fechaNacimiento = conexCTQ.reader("fechanacimiento")
                        empl.rfc = Trim(conexCTQ.reader("rfc"))
                        empl.curp = Trim(conexCTQ.reader("Curp"))
                        'DIRECCION...
                        empl.bancoPago = If(IsDBNull(conexCTQ.reader("bancoPagoElectronico")), Nothing, Trim(conexCTQ.reader("bancoPagoElectronico")))
                        empl.numCuentaPago = Trim(conexCTQ.reader("cuentaPagoElectronico"))
                        empl.sucursalPago = Trim(conexCTQ.reader("sucursalPagoElectronico"))
                        empl.clabePago = Trim(conexCTQ.reader("clabeInterbancaria"))

                        Dim objLugarNac As LugarNacimiento
                        objLugarNac = New LugarNacimiento(Ambiente)
                        objLugarNac.lugarNacimiento = conexCTQ.reader("lugarnacimiento")

                        If objLugarNac.buscarPNombre() Then
                            empl.idLugarNacimiento = objLugarNac.idLugarNacimiento
                        End If

                        'empl.idRegistroPatronal = ""

                        Dim objDep As Departamento
                        objDep = New Departamento(Ambiente)
                        objDep.nombreDepartamento = conexCTQ.reader("nDepartamento")
                        If Not objDep.buscarPNombre Then
                            objDep.altaDireccion = ""
                            objDep.esActivo = 1
                            objDep.nombreLider = ""
                            objDep.idSucursal = Ambiente.suc.idSucursal
                            objDep.firmaConcenEntrega = ""
                            objDep.idEmpresa = Ambiente.empr.idEmpresa

                            If Not objDep.guardar() Then
                                idError = objDep.idError
                                descripError &= "objDep.guardar(): " & objDep.descripError & vbCrLf
                            End If
                        End If

                        empl.idDepartamento = objDep.idDepartamento

                        Dim objPuesto As Puesto
                        objPuesto = New Puesto(Ambiente)
                        objPuesto.puesto = conexCTQ.reader("nPuesto")
                        If Not objPuesto.buscarPNombre Then
                            objPuesto.idEmpresa = Ambiente.empr.idEmpresa

                            If Not objPuesto.guardar() Then
                                idError = objPuesto.idError
                                descripError &= "objPuesto.guardar(): " & objPuesto.descripError & vbCrLf
                            End If
                        End If

                        empl.idPuesto = objPuesto.idPuesto

                        Dim objUMF As UMF
                        objUMF = New UMF(Ambiente)
                        objUMF.numUMF = conexCTQ.reader("umf")
                        If Not objUMF.buscarPNUM() Then
                            objUMF.UMF = "UMF " & objUMF.numUMF

                            If Not objUMF.guardar Then
                                idError = objPuesto.idError
                                descripError &= "objUMF.guardar(): " & objPuesto.descripError & vbCrLf
                            End If
                        End If

                        empl.idUMF = objUMF.idUMF

                        Dim objHorario As Horario
                        objHorario = New Horario(Ambiente)
                        objHorario.idEmpresa = Ambiente.empr.idEmpresa
                        objHorario.tabla = "Empleado"
                        objHorario.tipoHorario = "LA"
                        objHorario.horarioDefault()

                        empl.idHorario = objHorario.idHorario

                        objHorario.tabla = "Empleado"
                        objHorario.tipoHorario = "CO"
                        objHorario.horarioDefault()

                        'empl.idHorarioComida = objHorario.idHorario

                        Dim objCocina As Cocina
                        objCocina = New Cocina(Ambiente)
                        objCocina.idEmpresa = Ambiente.empr.idEmpresa
                        objCocina.cocinaDefault()

                        empl.idCocina = objCocina.idCocina

                        Dim objTab As Tabulador
                        objTab = New Tabulador(Ambiente)
                        objTab.idEmpresa = Ambiente.empr.idEmpresa
                        objTab.tabuladorDefault()

                        empl.idTabulador = objTab.idTabulador

                        Dim objArea As Area
                        objArea = New Area(Ambiente)
                        objArea.idDepartamento = objDep.idDepartamento
                        If Not objArea.areaDefault() Then
                            objArea.idEmpresa = Ambiente.empr.idEmpresa
                            objArea.nombreArea = objDep.nombreDepartamento
                            objArea.esActivo = 1
                            If objArea.guardar() Then
                                idError = objArea.idError
                                descripError &= "objArea.guardar(): " & objArea.descripError & vbCrLf
                            End If
                        End If

                        empl.idArea = objArea.idArea
                        empl.perfilCalculo = "Tabulador"
                        empl.idTipoUsuario = 0
                        empl.tipoUsuarioSistema = "USR"

                        Dim objRegPatronal As RegistroPatronal
                        objRegPatronal = New RegistroPatronal(Ambiente)
                        objRegPatronal.idEmpresa = Ambiente.empr.idEmpresa
                        objRegPatronal.registroPatronalDefault()

                        empl.idRegistroPatronal = objRegPatronal.idRegistroPatronal

                        If encontrado Then
                            If Not empl.actualizar() Then
                                idError = empl.idError
                                descripError &= "empl.actualizar(): " & empl.descripError & vbCrLf
                            End If
                        Else
                            If Not empl.guardar() Then
                                idError = empl.idError
                                descripError &= "empl.guardar(): " & empl.descripError & vbCrLf
                            End If
                        End If
                    End If

                    'ACTUALIZAR VACACIONES
                    If actualizarVac Then
                        Dim vacCTPQ As Integer
                        vacCTPQ = conexCTQ.reader("diasVacDisponibles")
                        If empl.diasVacacionesDisponibles <> vacCTPQ Then
                            Dim control As ControlVacaciones
                            Dim diasMov As Integer
                            diasMov = empl.diasVacacionesDisponibles - vacCTPQ

                            control = New ControlVacaciones(Ambiente)
                            If diasMov > 0 Then
                                control.tipoMovimiento = "S"
                            Else
                                control.tipoMovimiento = "E"
                            End If
                            control.concepto = "AJUSTE SINCRONIZACIÓN CONTPAQi"
                            control.idEmpleado = empl.idEmpleado
                            control.diasRestantes = empl.diasVacacionesDisponibles
                            control.diasMovimiento = Math.Abs(diasMov)

                            control.guardar()

                            empl.diasVacacionesDisponibles = vacCTPQ
                            empl.actualizar()
                        End If
                    End If

                End While
                conexCTQ.reader.Close()

                If altas + actualizaciones = 0 Then
                    idError = 1
                    descripError &= "No se encontraron empleados..." & vbCrLf
                End If
            Else
                idError = conexCTQ.idError
                descripError &= conexCTQ.descripError & vbCrLf & conexCTQ.Qry & vbCrLf
            End If
        Next

        If idError <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
