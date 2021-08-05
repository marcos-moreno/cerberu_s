Imports System.Data.SqlClient
Imports Cerberus
Imports NCalc

Public Class Periodo
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL
    Private objCreadoPor As Empleado
    Private objActualizadoPor As Empleado
    Private diasRango As New List(Of Date)

    Public idError As Integer
    Public descripError As String

    Public idPeriodo As Integer
    Public nombrePeriodo As String
    Public inicioPeriodo As Date
    Public finPeriodo As Date
    Public ejercicio As Integer
    Public idEmpresa As Integer
    Public idSucursal As Integer
    Public creado As DateTime
    Public creadoPor As Integer
    Public actualizado As DateTime
    Public actualizadoPor As Integer
    Public numeroPeriodo As Integer
    Public tabla As String
    Public esActivo As Boolean
    Public elementoSistema As String
    Public idConceptoCuentaCargo As Integer
    Public idConceptoCuentaAbono As Integer
    Public idVariableFormula As Integer
    Public idPeriodoCTPQ As Integer
    Public desfaceCONTPAQ As Integer

    Private rptDatos As Reporte
    Private dsDatos As DataSet

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex

        rptDatos = New Reporte(Ambiente, "Periodo", elementoSistema)
        dsDatos = New DataSet
    End Sub

    Public Function getIDsCOMPAC() As String
        Dim valorRetono As String
        valorRetono = "0"

        conex.numCon = 0
        conex.Qry = "SELECT stuff((select ', ' + convert(varchar,idPeriodoCTPQ) from Periodo where idPeriodoCTPQ is not null and idEmpresa = " & idEmpresa & " and elementoSistema = '" & elementoSistema & "' and tabla = '" & tabla & "' for xml path('')),1,1,'') as datos"

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                If IsDBNull(conex.reader("datos")) Then
                    conex.reader.Close()
                    Return valorRetono
                Else
                    valorRetono = conex.reader("datos")
                    conex.reader.Close()
                    Return valorRetono
                End If
            Else
                conex.reader.Close()
                Return valorRetono
            End If
        Else
            Return valorRetono
        End If

    End Function


    Public Function procesar(tipo As String, idDepartamento As Integer, idEmpleado As Integer, recalcular As Boolean) As Boolean
        Select Case tabla
            Case "Registro"
                If elementoSistema = "CO" Then 'COCINAS
                    Return procesaComidas()
                ElseIf elementoSistema = "ES" Then 'ENTRADAS Y SALIDAS
                    If tipo = "EFE" Then
                        If procesaES(idDepartamento, idEmpleado, recalcular) Then
                            If idDepartamento = Nothing And idEmpleado = Nothing Then
                                If generarPagosES() Then
                                    If actualizaCargasGas() Then
                                        esActivo = False
                                        Return actualizar()
                                    Else
                                        Return False
                                    End If
                                Else
                                    Return False
                                End If
                            Else
                                Return True
                            End If
                        Else
                            Return False
                        End If
                    ElseIf tipo = "HEXT" Then
                        Return procesarHorasExtra(idDepartamento, idEmpleado)
                    End If
                End If
            Case "Cuenta"
                If elementoSistema = "EFE" Then 'FLUJO EFECTIVO (EXCEDENTES)
                    Return procesarExedentes()
                End If
        End Select

        Return False
    End Function



    Public Function spCRegistrosModeHO(idEmpleado As Integer, Comentarios As String) As String
        Dim valorRetono As String
        valorRetono = "0"
        conex.numCon = 0
        conex.Qry = "EXEC [spCRegistrosModeHO] " & idPeriodo & "," & idEmpleado & ",'" & Comentarios & "'," & Ambiente.usuario.idEmpleado
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                If IsDBNull(conex.reader("result")) Then
                    conex.reader.Close()
                    Return valorRetono
                Else
                    valorRetono = conex.reader("result")
                    conex.reader.Close()
                    Return valorRetono
                End If
            Else
                conex.reader.Close()
                Return valorRetono
            End If
        Else
            descripError = conex.descripError
            Return valorRetono
        End If
    End Function

    Private Function actualizaCargasGas() As Boolean
        Dim objCargas As New CargasGasolina(Ambiente)
        objCargas.idEmpresa = idEmpresa
        objCargas.idSucursal = idSucursal
        objCargas.procesada = True

        If objCargas.actualizaXPeriodoCerrado(inicioPeriodo, finPeriodo) Then
            Return True
        Else
            idError = objCargas.idError
            descripError = "Periodo.actualizaCargasGas: " & objCargas.descripError
            Return False
        End If
    End Function

    Public Function procesarCuentaXPeriodoBajaXEmpleado(idEmpleado As Integer) As Boolean
        Return procesarCuentasXPeriodo(idEmpleado, True)
    End Function

    Public Function procesarCuentasXPeriodo() As Boolean
        Return procesarCuentasXPeriodo(Nothing, False)
    End Function

    Public Function procesarCuentasXPeriodo(idEmpleado As Integer, esBaja As Boolean) As Boolean
        idError = Nothing
        descripError = ""

        Dim ds As DataSet
        Dim plantilla As Cuenta
        Dim plantillaDetalle As CuentaDetalle

        Dim idSucursalAct As Integer
        Dim idEmpleadoAct As Integer
        Dim monto As Decimal
        Dim tipoCuenta As String
        'Dim referencia As String
        Dim idConceptoCuenta As Integer
        Dim idCuentaXPeriodo As Integer
        Dim descuentoNum As Integer
        Dim numDescuentos As Integer
        Dim numVeces As Integer

        conex.numCon = 0
        conex.Qry = "EXEC spPagaExcedentesXPeriodo '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa & "," & idPeriodo & "," & idEmpleado
        ds = conex.ejecutaConsultaDS(False)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            idCuentaXPeriodo = ds.Tables(0).Rows(i).Item(0)
            numDescuentos = ds.Tables(0).Rows(i).Item(1)
            tipoCuenta = ds.Tables(0).Rows(i).Item(2)
            idSucursalAct = ds.Tables(0).Rows(i).Item(3)
            idEmpleadoAct = ds.Tables(0).Rows(i).Item(4)
            descuentoNum = ds.Tables(0).Rows(i).Item(8) + 1
            monto = ds.Tables(0).Rows(i).Item(9)
            idConceptoCuenta = ds.Tables(0).Rows(i).Item(11)

            If esBaja Then
                numVeces = (numDescuentos - descuentoNum)
            Else
                numVeces = 0
            End If

            For x As Integer = 0 To numVeces
                plantilla = New Cuenta(Ambiente)
                plantillaDetalle = New CuentaDetalle(Ambiente)

                plantilla.idPeriodo = idPeriodo
                plantilla.tipoCuenta = tipoCuenta
                plantilla.idEmpresa = idEmpresa
                plantilla.idSucursal = idSucursalAct
                plantilla.idEmpleado = idEmpleadoAct
                plantilla.fechaCuenta = finPeriodo
                plantilla.estado = "CO"
                plantilla.monto = monto
                plantilla.descripccion = "PAGO (" & descuentoNum + x & "/" & numDescuentos & ") - """ & ds.Tables(0).Rows(i).Item(10) & """, DOCUMENTO: " & ds.Tables(0).Rows(i).Item(5)
                plantilla.esCuentaManual = False
                plantilla.sistemaOrigen = "Cerberus.CuentasXPeriodo"

                If Not plantilla.guardar() Then
                    idError = plantilla.idError
                    descripError &= "CuentaXPeriodo: " & plantilla.descripError & vbCrLf
                Else
                    plantillaDetalle = New CuentaDetalle(Ambiente)
                    plantillaDetalle.idCuenta = plantilla.idCuenta
                    plantillaDetalle.idConceptoCuenta = idConceptoCuenta
                    plantillaDetalle.monto = monto
                    plantillaDetalle.descripccion = "PAGO (" & descuentoNum + x & "/" & numDescuentos & ") - """ & ds.Tables(0).Rows(i).Item(10) & """, DOCUMENTO: " & ds.Tables(0).Rows(i).Item(5)

                    If Not plantillaDetalle.guardar() Then
                        idError = conex.idError
                        descripError &= "Cuenta.DetalleXPeriodo: " & plantillaDetalle.descripError & vbCrLf
                    Else
                        Dim CxPD As New CuentaXPeriodoDetalle(Ambiente)
                        CxPD.idCuentaXPeriodo = idCuentaXPeriodo
                        CxPD.idCuenta = plantilla.idCuenta
                        CxPD.idPeriodo = idPeriodo
                        CxPD.descuentoNum = descuentoNum + x
                        If Not CxPD.guardar() Then
                            idError = CxPD.idError
                            descripError &= "CuentaXPeriodoDetalle.Guardar: " & CxPD.descripError & vbCrLf
                        End If

                        If numDescuentos = descuentoNum + x Then
                            conex.numCon = 0
                            conex.Qry = "UPDATE CuentaXPeriodo SET esActivo = 0 WHERE idCuentaXPeriodo=" & idCuentaXPeriodo

                            If Not conex.ejecutaQry() Then
                                idError = conex.idError
                                descripError &= "CuentaXPeriodoDetalle.Guardar.UPDATE.CuentaXPeriodo: " & conex.descripError & vbCrLf
                            End If
                        End If
                    End If
                End If
            Next
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function procesarExedentes() As Boolean
        Dim ds As DataSet
        Dim plantilla As Cuenta
        Dim plantillaDetalle As CuentaDetalle

        Dim idSucursalAct As Integer
        Dim idEmpleadoAct As Integer
        Dim monto As Decimal

        idError = Nothing
        descripError = ""

        'Call limpiarPeriodo(Nothing, Nothing)
        'Call procesarCuentasXPeriodo()

        conex.numCon = 0
        conex.Qry = "EXEC spPagaExecedentes '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa

        ds = conex.ejecutaConsultaDS(False)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            idSucursalAct = ds.Tables(0).Rows(i).Item(1)
            idEmpleadoAct = ds.Tables(0).Rows(i).Item(0)
            monto = ds.Tables(0).Rows(i).Item(2)

            plantilla = New Cuenta(Ambiente)
            plantillaDetalle = New CuentaDetalle(Ambiente)

            plantilla.idPeriodo = idPeriodo
            plantilla.tipoCuenta = "CxC"
            plantilla.idEmpresa = idEmpresa
            plantilla.idSucursal = idSucursalAct
            plantilla.idEmpleado = idEmpleadoAct
            plantilla.fechaCuenta = finPeriodo
            plantilla.estado = "PR"
            plantilla.monto = monto
            plantilla.esCuentaManual = False
            plantilla.sistemaOrigen = "Periodo.ProcesaExcedentes"
            plantilla.descripccion = "PAGO DE SALDO PENDIENTE (EXCEDENTES) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

            If Not plantilla.guardar() Then
                idError = plantilla.idError
                descripError &= "Cuenta: " & plantilla.descripError & vbCrLf
            Else
                plantillaDetalle = New CuentaDetalle(Ambiente)
                plantillaDetalle.idCuenta = plantilla.idCuenta
                plantillaDetalle.idConceptoCuenta = idConceptoCuentaCargo
                plantillaDetalle.monto = monto
                plantillaDetalle.descripccion = "PAGO DE SALDO PENDIENTE (EXCEDENTES) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                If Not plantillaDetalle.guardar() Then
                    idError = conex.idError
                    descripError &= "Cuenta.Detalle: " & plantillaDetalle.descripError & vbCrLf
                End If
            End If
        Next

        If idError = 0 Then
            esActivo = False
            If Not actualizar() Then
                idError = conex.idError
                descripError &= "Periodo.Actualizar: " & plantillaDetalle.descripError & vbCrLf
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Function generarPagosES() As Boolean
        Return generarPagosES(Nothing)
    End Function

    Public Function generarPagosES(idEmpleado As Integer) As Boolean
        Dim plantilla As Cuenta
        Dim plantillaDetalle As CuentaDetalle

        Dim cuentas As New List(Of Cuenta)
        Dim detalles As New List(Of CuentaDetalle)

        Dim idEmpleadoAct As Integer
        Dim idSucursalAct As Integer
        Dim monto As Decimal
        Dim descrip As String

        'PAGO CUENTAS VISITAS SUCURSAL
        Dim idResultadoPeriodoES As New List(Of Integer)
        Dim idEmpleados As New List(Of Integer)

        idError = Nothing
        descripError = ""

        conex.numCon = 0
        conex.Qry = "EXEC spGetPagosxPeriodo " & idPeriodo & "," & idEmpleado

        If conex.ejecutaConsulta Then
            While conex.reader.Read
                idEmpleadoAct = conex.reader("idEmpleado")
                idSucursalAct = conex.reader("idSucursal")
                monto = conex.reader("resultado")
                descrip = conex.reader("nombreVariable")

                'PAGO CUENTAS VISITAS SUCURSAL
                idResultadoPeriodoES.Add(conex.reader("idResultadoPeriodoES"))
                idEmpleados.Add(idEmpleadoAct)

                If monto <> 0 Then
                    plantilla = New Cuenta(Ambiente)
                    plantillaDetalle = New CuentaDetalle(Ambiente)

                    If monto > 0 Then
                        plantilla.tipoCuenta = "CxP"
                        plantillaDetalle.idConceptoCuenta = idConceptoCuentaAbono
                    Else
                        plantilla.tipoCuenta = "CxC"
                        plantillaDetalle.idConceptoCuenta = idConceptoCuentaCargo
                    End If

                    monto = Math.Abs(monto)

                    'If idEmpleadoAct <> idEmpleadoAnt Then
                    plantilla.idPeriodo = idPeriodo
                    plantilla.idEmpresa = idEmpresa
                    plantilla.idSucursal = idSucursalAct
                    plantilla.idEmpleado = idEmpleadoAct
                    plantilla.fechaCuenta = finPeriodo
                    plantilla.estado = "CO"
                    plantilla.monto = monto
                    plantilla.esCuentaManual = False
                    plantilla.sistemaOrigen = "Periodo.generarPagosES"
                    plantilla.descripccion = "(" & descrip & ") del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                    cuentas.Add(plantilla)
                    'End If

                    plantillaDetalle.monto = monto
                    plantillaDetalle.descripccion = "(" & descrip & ") del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                    detalles.Add(plantillaDetalle)

                    'idEmpleadoAnt = idEmpleadoAct
                End If
            End While
            conex.reader.Close()

            'PAGO CUENTAS VISITAS SUCURSAL
            Dim objRPV As ResultadoPagoVisita
            Dim listObjs As New List(Of ResultadoPagoVisita)

            For z As Integer = 0 To idEmpleados.Count - 1
                objRPV = New ResultadoPagoVisita(Ambiente)
                objRPV.idResultadoPeriodoES = idResultadoPeriodoES(z)
                objRPV.getPagoVisitas(listObjs)

                For i As Integer = 0 To listObjs.Count - 1
                    plantilla = New Cuenta(Ambiente)

                    plantilla.tipoCuenta = "CxP"
                    plantilla.idEmpresa = idEmpresa
                    plantilla.idSucursal = listObjs(i).idSucursal
                    plantilla.idEmpleado = idEmpleados(z)
                    plantilla.fechaCuenta = finPeriodo
                    plantilla.estado = "CO"
                    plantilla.monto = If(listObjs(i).totalHoras > listObjs(i).limiteHoras, listObjs(i).limiteHoras, listObjs(i).totalHoras) * listObjs(i).CHET
                    plantilla.esCuentaManual = False
                    plantilla.sistemaOrigen = "Periodo.generarPagosES.VisitasSuc"
                    plantilla.descripccion = listObjs(i).observaciones

                    If plantilla.monto <> 0 Then
                        If Not plantilla.guardar() Then
                            idError = plantilla.idError
                            descripError &= "Periodo.Cuenta.VisitaSuc: " & plantilla.descripError & vbCrLf
                        Else
                            listObjs(i).idCuenta = plantilla.idCuenta
                            listObjs(i).actualizar()
                        End If

                        plantillaDetalle = New CuentaDetalle(Ambiente)

                        plantillaDetalle.idCuenta = plantilla.idCuenta
                        plantillaDetalle.idConceptoCuenta = listObjs(i).idConceptoCuenta
                        plantillaDetalle.monto = plantilla.monto
                        plantillaDetalle.descripccion = listObjs(i).observaciones

                        If Not plantillaDetalle.guardar() Then
                            idError = plantillaDetalle.idError
                            descripError &= "Periodo.CuentaDetalle.VisitaSuc: " & plantillaDetalle.descripError & vbCrLf
                        End If
                    End If
                Next
            Next
            '----

            For i As Integer = 0 To cuentas.Count - 1
                If Not cuentas(i).guardar() Then
                    idError = cuentas(i).idError
                    descripError &= "Cuenta: " & cuentas(i).descripError & vbCrLf
                Else
                    detalles(i).idCuenta = cuentas(i).idCuenta
                    If Not detalles(i).guardar() Then
                        idError = detalles(i).idError
                        descripError &= "Cuenta.Detalle: " & detalles(i).descripError & vbCrLf
                    End If
                End If
            Next

            If idError = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Function procesarHorasExtra(idDepartamento As Integer, idEmpleado As Integer) As Boolean
        If esActivo = False Then
            idError = 1
            descripError = "El Periodo ha sido ""CERRADO"", por lo cual no se puede realizar el proceso..."
            Return False
        End If

        Dim dias As List(Of Date)
        Dim horarioD As New HorarioDetalle(Ambiente)
        Dim horario As New Horario(Ambiente)
        Dim tiempoComida As Decimal
        Dim segTiempoComida As Integer
        Dim empleados As New List(Of Empleado)
        Dim registros As New List(Of Registro)
        Dim ultimoReg As Registro
        Dim primerRegistro As Registro
        Dim operacion As String
        Dim reg As New Registro(Ambiente)
        Dim vtna As New frmRegInvalidos
        Dim dgv As DataGridView
        dgv = vtna.DataGridView1
        Dim empl As New Empleado(Ambiente)
        Dim desactivar As Boolean

        descripError = ""
        idError = 0

        operacion = "ES"
        reg.idEmpresa = Ambiente.empr.idEmpresa

        If idEmpleado = Nothing Then
            reg.cargarGridRegistrosInvalidos(dgv, inicioPeriodo, finPeriodo, operacion, idDepartamento, Nothing)
        Else
            reg.cargarGridRegistrosInvalidos(dgv, inicioPeriodo, finPeriodo, operacion, idEmpleado)
        End If

        If dgv.Rows.Count > 0 Then
            idError = 1
            descripError = "El periodo no puede ser procesado debido a que existen: (" & dgv.Rows.Count & ") registro(s) inválido(s)..."
            Return False
        End If

        empl.idEmpresa = Ambiente.empr.idEmpresa
        If idEmpleado = Nothing Then
            empl.cargarGridXDep(dgv, idDepartamento, Nothing, empleados, True)
        Else
            empl.idEmpleado = idEmpleado
            empl.buscarPID()

            empleados.Clear()
            empleados.Add(empl)
        End If

        dias = getDiasRango()
        For e As Integer = 0 To empleados.Count - 1
            'HORARIOS NOCTURNOS
            horario.idHorario = empleados(e).idHorario
            horario.buscarPID()

            If horario.esNocturno Then
                'aaa
            End If


            If empleados.Item(e).perfilCalculo = "Tabulador" Then
                For i As Integer = 0 To dias.Count - 1
                    reg.cargaGridXFechaEmpl(New DataGridView, empleados.Item(e).idEmpleado, dias.Item(i), registros, operacion, True)

                    'BUSCO HORARIO LABORAL ASIGNADO X DIA
                    horarioD.idHorario = empleados.Item(e).idHorario
                    'horarioD.numDia = i + 1
                    horarioD.numDia = dias.Item(i).DayOfWeek

                    If horarioD.buscarPID() Then
                        If registros.Count > 0 Then
                            segTiempoComida = DateDiff(DateInterval.Second, CDate(Format(horarioD.tiempoComida, "yyyy-MM-dd 00:00:00")), horarioD.tiempoComida)

                            primerRegistro = registros(0)
                            horarioD.horaInicial = Format(primerRegistro.fechaRegistro, "yyyy-MM-dd") & " " & Format(horarioD.horaInicial, "HH:mm:ss")

                            ultimoReg = registros(registros.Count - 1)
                            horarioD.horaFinal = Format(ultimoReg.fechaRegistro, "yyyy-MM-dd") & " " & Format(horarioD.horaFinal, "HH:mm:ss")

                            'HORARIO DE COMIDA
                            Dim inicio As DateTime
                            Dim fin As DateTime
                            tiempoComida = 0
                            For z As Integer = 1 To ((registros.Count - 2) / 2)
                                inicio = registros((z * 2) - 1).fechaRegistro
                                fin = registros(z * 2).fechaRegistro
                                tiempoComida += DateDiff(DateInterval.Second, inicio, fin)
                            Next

                            If tiempoComida < segTiempoComida And registros.Count >= 4 Then
                                reg = New Registro(Ambiente)
                                reg.comentario = "PR. AUT. COMIDA"
                                reg.idEmpresa = Ambiente.empr.idEmpresa
                                reg.idEmpleado = empleados.Item(e).idEmpleado
                                reg.esActivo = True
                                reg.tipoRegistro = "MANUAL"
                                reg.dispositivo = "SISTEMA"
                                reg.operacion = "ES"
                                reg.fechaRegistro = registros(2).fechaRegistro.AddSeconds(segTiempoComida - tiempoComida)
                                If Not reg.guardar() Then
                                    desactivar = False
                                    'idError = reg.idError
                                    'descripError &= "REG: (" & reg.idEmpleado & ") - " & Format(reg.fechaRegistro, "dd/MM/yyyy") & " :" & reg.descripError & vbCrLf
                                Else
                                    desactivar = True
                                End If

                                If desactivar Then
                                    registros(2).esActivo = False
                                    If Not registros(2).actualizar() Then
                                        idError = 10
                                        descripError &= "ACT CO: (" & reg.idEmpleado & ") - " & registros(2).fechaRegistro & " :" & registros(2).descripError & vbCrLf
                                    End If
                                End If
                            End If

                            'ENTRADA DE TURNO
                            If primerRegistro.fechaRegistro < horarioD.horaInicial Then
                                reg = New Registro(Ambiente)
                                reg.comentario = "PROCESO AUTOMATICO"
                                reg.idEmpresa = Ambiente.empr.idEmpresa
                                reg.idEmpleado = empleados.Item(e).idEmpleado
                                reg.esActivo = True
                                reg.tipoRegistro = "MANUAL"
                                reg.dispositivo = "SISTEMA"
                                reg.operacion = "ES"
                                reg.fechaRegistro = horarioD.horaInicial
                                If Not reg.guardar() Then
                                    desactivar = False
                                    'idError = reg.idError
                                    'descripError &= "REG: (" & reg.idEmpleado & ") - " & Format(reg.fechaRegistro, "dd/MM/yyyy") & " :" & reg.descripError & vbCrLf
                                Else
                                    desactivar = True
                                End If

                                If desactivar Then
                                    primerRegistro.esActivo = False
                                    If Not primerRegistro.actualizar() Then
                                        idError = 10
                                        descripError &= "ACT PR: (" & reg.idEmpleado & ") - " & primerRegistro.fechaRegistro & " :" & primerRegistro.descripError & vbCrLf
                                    End If
                                End If
                            End If

                            'SALIDA DE TURNO
                            If ultimoReg.fechaRegistro > horarioD.horaFinal And Not empleados.Item(e).tieneHorasExtrasAut Then
                                reg = New Registro(Ambiente)
                                reg.comentario = "PROCESO AUTOMATICO"
                                reg.idEmpresa = Ambiente.empr.idEmpresa
                                reg.idEmpleado = empleados.Item(e).idEmpleado
                                reg.esActivo = True
                                reg.tipoRegistro = "MANUAL"
                                reg.dispositivo = "SISTEMA"
                                reg.operacion = "ES"
                                reg.fechaRegistro = horarioD.horaFinal
                                If Not reg.guardar() Then
                                    desactivar = False
                                    'idError = reg.idError
                                    'descripError &= "REG: (" & reg.idEmpleado & ") - " & Format(reg.fechaRegistro, "dd/MM/yyyy") & " :" & reg.descripError & vbCrLf
                                Else
                                    desactivar = True
                                End If

                                If desactivar Then
                                    ultimoReg.esActivo = False
                                    If Not ultimoReg.actualizar() Then
                                        idError = 10
                                        descripError &= "ACT UR: (" & reg.idEmpleado & ") - " & ultimoReg.fechaRegistro & " :" & ultimoReg.descripError & vbCrLf
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If horarioD.idError <> 1 Then
                            descripError &= "HORARIO: " & horarioD.descripError & vbCrLf
                        End If
                    End If
                Next
            End If
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function limpiarPeriodo(idDepartamento As Integer, idEmpleado As Integer) As Boolean
        conex.numCon = 0
        conex.Qry = "EXEC limpiarMovPeriodo " & idPeriodo & "," & idDepartamento & "," & idEmpleado & "," & idEmpresa

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = "limpiarPeriodo(): " & conex.descripError
            Return False
        End If

    End Function

    Private Function procesaES(idDepartamento As Integer, idEmpleado As Integer, recalcular As Boolean) As Boolean
        Dim res As ResultadoPeriodoES
        Dim resForm As ResultadoFormulaES
        Dim inci As Incidencia
        Dim form As Formula
        Dim horasExtra As ControlHorasExtras

        Dim tiempoLaborado As Decimal
        Dim dias As List(Of Date)
        Dim horarioD As New HorarioDetalle(Ambiente)
        Dim empleados As New List(Of Empleado)
        Dim registros As New List(Of Registro)
        Dim operacion As String
        Dim reg As New Registro(Ambiente)
        Dim vtna As New frmRegInvalidos
        Dim dgv As DataGridView
        dgv = vtna.DataGridView1
        Dim empl As New Empleado(Ambiente)
        Dim tiempoExtraEnDiasNoLaboradoras As Decimal
        Dim resVisitaSuc As New List(Of ResultadoPagoVisita)
        Dim plantillaPV As ResultadoPagoVisita
        Dim debeLaborarHoy As Boolean
        Dim minutosDelDia As Decimal

        descripError = ""
        idError = 0

        If recalcular Then
            limpiarPeriodo(idDepartamento, idEmpleado)
        End If

        operacion = "ES"
        reg.idEmpresa = Ambiente.empr.idEmpresa
        reg.cargarGridRegistrosInvalidosXDepEmpl(dgv, inicioPeriodo, finPeriodo, operacion, idDepartamento, idEmpleado)

        If dgv.Rows.Count > 0 Then
            idError = 1
            descripError = "El(Los) Empleado(s) no puede(n) ser procesado(s) debido a que existen: (" & dgv.Rows.Count & ") registro(s) inválido(s)"
            Return False
        End If

        empl.idEmpresa = Ambiente.empr.idEmpresa
        empl.cargarGridXDepOID(dgv, idDepartamento, idEmpleado, empleados, True, finPeriodo)

        dias = getDiasRango()

        For e As Integer = 0 To empleados.Count - 1
            res = New ResultadoPeriodoES(Ambiente)
            res.idPeriodo = idPeriodo
            res.idEmpleado = empleados(e).idEmpleado

            If empleados(e).perfilCalculo <> "Estadia" Then 'Estadias no se calculan...
                If Not res.buscarCalculo Then ' CALCULOS DE LOS FALTANTES
                    res.idHorario = empleados(e).idHorario
                    res.idDepartamento = empleados(e).idDepartamento
                    res.BJL = 48
                    res.CHET = empleados(e).getTabulador.getVersionActual.costoXhoraExtra
                    res.CHR = empleados(e).getTabulador.getVersionActual.costoXhora
                    res.D = 0 'DESTAJO
                    res.SSI = empleados(e).sueldoSemanalIMSS
                    res.SSR = empleados(e).getTabulador.getVersionActual.sueldo
                    res.idRegistroPatronal = empleados(e).idRegistroPatronal

                    tiempoExtraEnDiasNoLaboradoras = 0
                    resVisitaSuc.Clear()

                    For i As Integer = 0 To dias.Count - 1 'DIAS DEL PERIODO A PROCESAR...
                        reg.cargaGridXFechaEmpl(New DataGridView, empleados.Item(e).idEmpleado, dias.Item(i), registros, operacion, True)
                        horarioD.idHorario = empleados.Item(e).idHorario
                        'horarioD.numDia = i + 1
                        'horarioD.numDia = dias.Item(i).DayOfWeek
                        If dias.Item(i).DayOfWeek = 0 Then
                            horarioD.numDia = 7
                        Else
                            horarioD.numDia = dias.Item(i).DayOfWeek
                        End If

                        tiempoLaborado = 0
                        '&&&&&&&&&&&&&&&&&&&&&&&&
                        Dim FaltaXSitema As Boolean
                        FaltaXSitema = False

                        Dim incidencias As New List(Of Incidencia)

                        inci = New Incidencia(Ambiente)
                        inci.idEmpresa = Ambiente.empr.idEmpresa
                        inci.fecha = dias(i)
                        inci.idEmpleado = empleados.Item(e).idEmpleado
                        inci.calculada = True

                        inci.buscarXFechaXEmpl(incidencias)

                        For cInci As Integer = 0 To incidencias.Count - 1
                            If incidencias(cInci).getTipoInicidencia.codigoIncidencia = "FXS" Then
                                FaltaXSitema = True
                            End If
                        Next
                        '&&&&&&&&&&&&&&&&&&

                        If horarioD.buscarPID() Then
                            res.D_PRDO += 1
                            debeLaborarHoy = True

                            If registros.Count > 0 Then
                                calcularTiempos(tiempoLaborado, registros)

                                'If tiempoLaborado < DateDiff(DateInterval.Minute, CDate(Format(Now, "yyyy-MM-dd 00:00:00")), horarioD.minLaborar) Then
                                If FaltaXSitema Then
                                    tiempoExtraEnDiasNoLaboradoras += tiempoLaborado
                                    res.F += 1
                                    If empleados.Item(e).perfilCalculo = "Tabulador" Then
                                        res.BJL -= ((DateDiff(DateInterval.Minute, horarioD.horaInicial, horarioD.horaFinal) - 60) / 60) 'HORAS Del Horario (MINUTOS) -1 Hora de Comida / 60
                                    End If
                                Else
                                    res.THL += tiempoLaborado
                                    res.A += 1
                                End If

                            Else
                                res.F += 1
                                If empleados.Item(e).perfilCalculo = "Tabulador" Then
                                    res.BJL -= ((DateDiff(DateInterval.Minute, horarioD.horaInicial, horarioD.horaFinal) - 60) / 60) 'HORAS Del Horario (MINUTOS) -1 Hora de Comida / 60
                                End If
                            End If

                            minutosDelDia = DateDiff(DateInterval.Minute, horarioD.horaInicial, horarioD.horaFinal)

                            'HORAS EXTRAS QUE PAGA O NO OTRA SUCURSAL X DIA...
                            Dim objVisita As New VisitaSucursal(Ambiente)
                            Dim formaPago As New FormaPagoTraslado(Ambiente)
                            Dim encontrado As Boolean
                            Dim indice As Integer
                            encontrado = False
                            Dim tiempoExtraHoy As Decimal
                            tiempoExtraHoy = (tiempoLaborado - (minutosDelDia - 60)) / 60 '-60 MIN DE COMIDA - /60 PASAR A HORAS

                            objVisita.idEmpleado = empleados.Item(e).idEmpleado

                            If objVisita.buscarPFechaYEmpl(dias.Item(i)) Then
                                For v As Integer = 0 To resVisitaSuc.Count - 1
                                    If resVisitaSuc(v).idSucursal = objVisita.idSucursal Then
                                        encontrado = True
                                        indice = v
                                        Exit For
                                    End If
                                Next

                                If encontrado Then
                                    resVisitaSuc(indice).totalHoras += If(tiempoExtraHoy > 0, tiempoExtraHoy, 0)
                                Else
                                    formaPago.idFormaPagoTraslado = objVisita.idFormaPagoTraslado
                                    formaPago.buscarPID()

                                    plantillaPV = New ResultadoPagoVisita(Ambiente)
                                    plantillaPV.idVisita = objVisita.idVisitaSucursal
                                    plantillaPV.idSucursal = objVisita.idSucDestino
                                    plantillaPV.totalHoras = If(tiempoExtraHoy > 0, tiempoExtraHoy, 0)
                                    plantillaPV.CHET = res.CHET
                                    plantillaPV.limiteHoras = objVisita.totalHorasAut
                                    plantillaPV.idConceptoCuenta = formaPago.idConceptoCuenta
                                    plantillaPV.observaciones = "PAGO VISITA SUCURSAL FORANEA: " & objVisita.descripcion
                                    resVisitaSuc.Add(plantillaPV)
                                End If
                            End If
                            '------------------
                        Else
                            If horarioD.idError <> 1 Then
                                idError = horarioD.idError
                                descripError &= "HORARIO: " & horarioD.descripError & vbCrLf
                            Else 'VERIFICAR SI TIENE tiempo EXTRA ESTE DIA.
                                Dim tiempoExDNL As Decimal
                                tiempoExDNL = 0
                                calcularTiempos(tiempoExDNL, registros)
                                tiempoExtraEnDiasNoLaboradoras += tiempoExDNL
                            End If

                            minutosDelDia = 0
                            debeLaborarHoy = False
                        End If

                        'BUSCANDO INCIDENCIAS
                        inci = New Incidencia(Ambiente)
                        inci.idEmpresa = Ambiente.empr.idEmpresa
                        inci.fecha = dias(i)
                        inci.idEmpleado = empleados.Item(e).idEmpleado
                        inci.calculada = False

                        If inci.buscarXFechaXEmpl() Then
                            Dim minComida As Integer

                            If debeLaborarHoy Then
                                minComida = 60 '60 MIN DE LA HORA DE COMIDA
                            Else
                                minComida = 0
                            End If

                            If inci.getTipoInicidencia.codigoIncidencia = "DF" Then
                                res.DF += 1
                                If empleados.Item(e).perfilCalculo = "X Horas" Then
                                    res.THL += minutosDelDia - minComida
                                End If
                            ElseIf inci.getTipoInicidencia.codigoIncidencia = "I" Then
                                res.I += 1
                            ElseIf inci.getTipoInicidencia.codigoIncidencia = "PGS" Then
                                res.PGS += 1
                                If empleados.Item(e).perfilCalculo = "X Horas" Then
                                    res.THL += minutosDelDia - minComida
                                End If
                            ElseIf inci.getTipoInicidencia.codigoIncidencia = "PSGS" Then
                                res.PSGS += 1
                            ElseIf inci.getTipoInicidencia.codigoIncidencia = "VD" Then
                                res.VD += 1
                                If empleados.Item(e).perfilCalculo = "X Horas" Then
                                    res.THL += minutosDelDia - minComida
                                End If
                            End If


                        Else
                            If inci.idError <> 1 Then
                                idError = inci.idError
                                descripError &= "INCIDENCIA: " & inci.descripError & vbCrLf
                            End If
                        End If
                    Next

                    'CALCULOS EXTRAS
                    res.THL /= 60  'PASAR MINUTOS A HORAS
                    res.TE = res.THL - res.BJL

                    If empleados.Item(e).perfilCalculo = "X Horas" Then
                        res.TE = If(res.TE < 0, 0, res.TE)
                    End If

                    horasExtra = New ControlHorasExtras(Ambiente)
                    horasExtra.idEmpleado = empleados.Item(e).idEmpleado
                    horasExtra.idPeriodo = idPeriodo
                    horasExtra.buscarPID()

                    'HORAS EXTRAS EN OTRA SUCURSAL
                    Dim tiempo As Decimal
                    Dim tiempoExtraXDiaSucForanea As Decimal

                    For v As Integer = 0 To resVisitaSuc.Count - 1
                        tiempoExtraXDiaSucForanea = resVisitaSuc(v).totalHoras

                        If tiempoExtraXDiaSucForanea > 0 And res.TE > 0 Then
                            tiempo = res.TE - tiempoExtraXDiaSucForanea

                            If tiempo > 0 Then
                                res.TE = tiempo
                            Else
                                tiempoExtraXDiaSucForanea = res.TE
                                res.TE = 0
                            End If

                            resVisitaSuc(v).totalHoras = tiempoExtraXDiaSucForanea
                        End If
                    Next
                    '-----------

                    If res.TE > horasExtra.cantidadHoras And horasExtra.forzarLimiteHorasExtras Then
                        res.TE = horasExtra.cantidadHoras
                    End If

                    If res.BJL < 0 Then
                        res.BJL = 0
                    End If

                    'TIEMPO EXTRA EN DIAS NO LABORABLES
                    tiempoExtraEnDiasNoLaboradoras /= 60 'PASAR MINUTOS A HORAS
                    res.TFN = tiempoExtraEnDiasNoLaboradoras

                    'TIEMPO X TIEMPO
                    Dim objTiempoXtiempo As TiempoXTiempo

                    If Ambiente.empr.tiempoXTiempo Then
                        objTiempoXtiempo = New TiempoXTiempo(Ambiente)
                        objTiempoXtiempo.tipoMov = "E"
                        objTiempoXtiempo.idEmpresa = Ambiente.empr.idEmpresa

                        objTiempoXtiempo.valor = res.TE * 60
                        objTiempoXtiempo.valor += res.TFN * 60

                        res.TE = 0
                        res.TFN = 0
                    End If


                    If Not res.guardar() Then
                        idError = res.idError
                        descripError &= "RESULTADO: " & res.descripError & vbCrLf
                    Else
                        'TIEMPO X TIEMPO
                        If Ambiente.empr.tiempoXTiempo Then
                            objTiempoXtiempo.idResultadoPeriodoES = res.idResultadoPeriodoES
                            objTiempoXtiempo.guardar()
                        End If

                        'GUARDAR TIEMPO EXTRA SUCURSALES
                        For v As Integer = 0 To resVisitaSuc.Count - 1
                            resVisitaSuc(v).idResultadoPeriodoES = res.idResultadoPeriodoES

                            If resVisitaSuc(v).totalHoras > 0 Then
                                If Not resVisitaSuc(v).guardar() Then
                                    idError = resVisitaSuc(v).idError
                                    descripError &= "RESULTADO VISITA: " & resVisitaSuc(v).descripError & vbCrLf
                                End If
                            End If
                        Next

                        'CALCULO DE FORMULAS
                        Dim calculo As Expression
                        Dim objsFormulas As New List(Of Formula)
                        form = New Formula(Ambiente)
                        form.idEmpresa = Ambiente.empr.idEmpresa
                        form.tipoCalculo = empleados.Item(e).perfilCalculo
                        form.getComboActivo(New ComboBox, objsFormulas)

                        For i As Integer = 0 To objsFormulas.Count - 1
                            resForm = New ResultadoFormulaES(Ambiente)
                            resForm.idFormula = objsFormulas(i).idFormula
                            resForm.formula = objsFormulas(i).formula
                            resForm.idResultadoPeriodoES = res.idResultadoPeriodoES

                            'FORMULAS
                            For x As Integer = 0 To 2
                                form.buscarPElementoTCal("SD_IMSS")
                                resForm.formula = resForm.formula.Replace("SD_IMSS", "(" & form.formula & ")")
                                form.buscarPElementoTCal("7MO_D")
                                resForm.formula = resForm.formula.Replace("7MO_D", "(" & form.formula & ")")
                                form.buscarPElementoTCal("ESSE")
                                resForm.formula = resForm.formula.Replace("ESSE", "(" & form.formula & ")")
                                form.buscarPElementoTCal("AAEC")
                                resForm.formula = resForm.formula.Replace("AAEC", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PPGS")
                                resForm.formula = resForm.formula.Replace("PPGS", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PTHL")
                                resForm.formula = resForm.formula.Replace("PTHL", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PDF")
                                resForm.formula = resForm.formula.Replace("PDF", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PES")
                                resForm.formula = resForm.formula.Replace("PES", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PHE")
                                resForm.formula = resForm.formula.Replace("PHE", "(" & form.formula & ")")
                                form.buscarPElementoTCal("PVD")
                                resForm.formula = resForm.formula.Replace("PVD", "(" & form.formula & ")")
                                form.buscarPElementoTCal("TN")
                                resForm.formula = resForm.formula.Replace("TN", "(" & form.formula & ")")
                                form.buscarPElementoTCal("DP")
                                resForm.formula = resForm.formula.Replace("DP", "(" & form.formula & ")")
                                form.buscarPElementoTCal("DT")
                                resForm.formula = resForm.formula.Replace("DT", "(" & form.formula & ")")
                                form.buscarPElementoTCal("ES")
                                resForm.formula = resForm.formula.Replace("ES", "(" & form.formula & ")")
                                form.buscarPElementoTCal("TP")
                                resForm.formula = resForm.formula.Replace("TP", "(" & form.formula & ")")
                            Next

                            'VARIABLES
                            resForm.formula = resForm.formula.Replace("D_PRDO", res.D_PRDO)
                            resForm.formula = resForm.formula.Replace("PSGS", res.PSGS)
                            resForm.formula = resForm.formula.Replace("CHET", res.CHET)
                            resForm.formula = resForm.formula.Replace("BJL", res.BJL)
                            resForm.formula = resForm.formula.Replace("CHR", res.CHR)
                            resForm.formula = resForm.formula.Replace("PGS", res.PGS)
                            resForm.formula = resForm.formula.Replace("SSI", res.SSI)
                            resForm.formula = resForm.formula.Replace("SSR", res.SSR)
                            resForm.formula = resForm.formula.Replace("THL", res.THL)
                            resForm.formula = resForm.formula.Replace("TFN", res.TFN)
                            resForm.formula = resForm.formula.Replace("VD", res.VD)
                            resForm.formula = resForm.formula.Replace("TE", res.TE)
                            resForm.formula = resForm.formula.Replace("DF", res.DF)
                            resForm.formula = resForm.formula.Replace("A", res.A)
                            resForm.formula = resForm.formula.Replace("D", res.D)
                            resForm.formula = resForm.formula.Replace("F", res.F)
                            resForm.formula = resForm.formula.Replace("I", res.I)

                            Try
                                calculo = New Expression(resForm.formula)
                                resForm.resultado = calculo.Evaluate
                            Catch ex As Exception
                                idError = ex.HResult
                                descripError &= "EVA FORMULA: [(" & objsFormulas(i).formula & ")-(" & resForm.formula & ")] " & ex.Message & vbCrLf
                            End Try

                            resForm.formula = objsFormulas(i).formula

                            If Not resForm.guardar Then
                                idError = resForm.idError
                                descripError &= "RES FORMULA: " & resForm.descripError & vbCrLf
                            End If
                        Next
                    End If
                End If 'CALCULOS DE LOS FALNTANTES
            End If 'CALCULO DE LAS ESTADIAS
        Next

        If idError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub calcularTiempos(ByRef tiempoLaborado As Decimal, regs As List(Of Registro))
        If regs.Count > 0 Then
            Dim entrada As Date
            Dim salida As Date
            Dim x As Integer
            x = regs.Count / 2

            entrada = regs(0).fechaRegistro
            salida = regs(regs.Count - 1).fechaRegistro

            tiempoLaborado = 0

            For i As Integer = 0 To x - 1
                entrada = regs(i * 2).fechaRegistro
                salida = regs(i * 2 + 1).fechaRegistro

                tiempoLaborado += DateDiff(DateInterval.Second, entrada, salida)
            Next

            tiempoLaborado = tiempoLaborado / 60 'CONVERSION A MINUTOS
        End If
    End Sub

    Private Function procesaComidas() As Boolean
        idError = Nothing
        descripError = ""

        limpiarPeriodo(Nothing, Nothing)

        conex.numCon = 0
        conex.Qry = "EXEC spProcesaRegistrosComida " & idEmpresa & "," & idPeriodo & "," & Ambiente.usuario.idEmpleado

        If Not conex.ejecutaQry() Then
            idError = conex.idError
            descripError = conex.descripError
            Return False
        Else

            conex.numCon = 0
            conex.Qry = "SELECT 
	                        E.idEmpleado,
                            E.idSucursal,
	                        Cr.idCocina,
	                        sum(R.numReg) numComidas,
	                        sum(isnull(IIF(R.idCocinaAsig = R.idCocinaReg,(R.costoComida - R.descuento)* numReg, R.sansion * numReg),0)) as Costo,
                            R.costoComida * sum(R.numReg) as TotalCocina,
                            E.perfilCalculo
                        FROM 
	                        ResultadoCocina as R
                        INNER JOIN 
	                        Empleado as E
                        ON 
	                        E.idEmpleado = R.idEmpleado
                        LEFT JOIN 
	                        Departamento as D
                        ON D.idDepartamento = R.idDepartamento
                        LEFT JOIN
	                        Cocina as Ca
                        On 
	                        Ca.idCocina = R.idCocinaAsig
                        LEFT JOIN
	                        Cocina as Cr
                        ON	
	                        Cr.idCocina = R.idCocinaReg
                        WHERE R.idPeriodo = " & idPeriodo & "
                        GROUP BY E.idEmpleado,Cr.idCocina,E.idSucursal,R.costoComida,E.perfilCalculo
                        ORDER BY E.idEmpleado,Cr.idCocina"
            Dim plantilla As Cuenta
            Dim plantillaCocina As Cuenta
            Dim plantillaDetalle As CuentaDetalle

            Dim idEmpleadoAnt As Integer
            Dim idEmpleadoAct As Integer
            Dim idCocinaAct As Integer
            Dim encontado As Boolean

            Dim idSucursalAct As Integer
            Dim numComidas As Integer
            Dim totalCargos As Decimal
            Dim numComidasCuenta As Integer
            Dim monto As Decimal
            Dim montoCocina As Decimal
            Dim perfilEmpleado As String

            Dim cuentaCocina As New List(Of Cuenta)
            Dim contadorComidas As New List(Of Integer)

            Dim ds As DataSet

            ds = conex.ejecutaConsultaDS(True)

            If Not ds Is Nothing Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    idEmpleadoAct = ds.Tables(0).Rows(i).Item(0)
                    idSucursalAct = ds.Tables(0).Rows(i).Item(1)
                    idCocinaAct = ds.Tables(0).Rows(i).Item(2)
                    numComidas = ds.Tables(0).Rows(i).Item(3)
                    monto = ds.Tables(0).Rows(i).Item(4)
                    montoCocina = ds.Tables(0).Rows(i).Item(5)
                    perfilEmpleado = ds.Tables(0).Rows(i).Item(6)

                    'CUENTA x PAGAR COCINA
                    encontado = False
                    For x As Integer = 0 To cuentaCocina.Count - 1
                        If cuentaCocina(x).idCocina = idCocinaAct Then
                            encontado = True
                            cuentaCocina(x).monto += montoCocina
                            contadorComidas(x) += numComidas
                        End If
                    Next

                    If Not encontado Then
                        plantillaCocina = New Cuenta(Ambiente)
                        plantillaCocina.idPeriodo = idPeriodo
                        plantillaCocina.tipoCuenta = "CxP"
                        plantillaCocina.idEmpresa = idEmpresa
                        plantillaCocina.idSucursal = idSucursalAct
                        plantillaCocina.idCocina = idCocinaAct
                        plantillaCocina.fechaCuenta = finPeriodo
                        plantillaCocina.estado = "CO"
                        plantillaCocina.monto = montoCocina
                        plantillaCocina.esCuentaManual = False
                        plantillaCocina.sistemaOrigen = "Periodo.procesaComidas"

                        plantillaCocina.descripccion = "(*NUM*) Comida(s) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                        cuentaCocina.Add(plantillaCocina)
                        contadorComidas.Add(numComidas)
                    End If
                    '********************************************

                    If idEmpleadoAct <> idEmpleadoAnt Then
                        If Not plantilla Is Nothing Then 'GUARDAR LA CUENTA
                            plantilla.monto = totalCargos
                            plantilla.descripccion = Replace(plantilla.descripccion, "*NUM*", numComidasCuenta)

                            If Not plantilla.actualizar() Then
                                idError = plantilla.idError
                                descripError &= "Cuenta.Actualizar: " & plantilla.descripError & vbCrLf
                            End If
                        End If

                        totalCargos = 0
                        numComidasCuenta = 0

                        plantilla = New Cuenta(Ambiente)
                        plantilla.idPeriodo = idPeriodo
                        plantilla.tipoCuenta = "CxC"
                        plantilla.idEmpresa = idEmpresa
                        plantilla.idSucursal = idSucursalAct
                        plantilla.idEmpleado = idEmpleadoAct
                        plantilla.fechaCuenta = finPeriodo
                        plantilla.estado = "CO"
                        plantilla.esCuentaManual = False
                        plantilla.sistemaOrigen = "Periodo.procesaComidas"

                        plantilla.descripccion = "(*NUM*) Comida(s) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                        If Not plantilla.guardar() Then
                            idError = plantilla.idError
                            descripError &= "Cuenta: " & plantilla.descripError & vbCrLf
                        End If
                    End If

                    plantillaDetalle = New CuentaDetalle(Ambiente)
                    plantillaDetalle.idCuenta = plantilla.idCuenta
                    plantillaDetalle.idConceptoCuenta = idConceptoCuentaCargo
                    plantillaDetalle.monto = monto
                    plantillaDetalle.descripccion = "(" & numComidas & ") Comida(s) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                    numComidasCuenta += numComidas

                    If Not plantillaDetalle.guardar() Then
                        idError = plantillaDetalle.idError
                        descripError &= "Cuenta.Detalle: " & plantillaDetalle.descripError & vbCrLf
                    Else
                        totalCargos += plantillaDetalle.monto
                    End If

                    'PERSONAL ESTADIAS
                    If perfilEmpleado = "Estadia" Then
                        plantillaDetalle = New CuentaDetalle(Ambiente)
                        plantillaDetalle.idCuenta = plantilla.idCuenta
                        plantillaDetalle.idConceptoCuenta = idConceptoCuentaCargo
                        plantillaDetalle.monto = (totalCargos * -1)
                        plantillaDetalle.descripccion = "AYUDA A ESTADIA POR (" & numComidas & ") Comida(s) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                        If Not plantillaDetalle.guardar() Then
                            idError = plantillaDetalle.idError
                            descripError &= "Cuenta.Detalle.Estadia: " & plantillaDetalle.descripError & vbCrLf
                        Else
                            totalCargos += plantillaDetalle.monto
                        End If
                    End If
                    '----ESTADIAS

                    idEmpleadoAnt = idEmpleadoAct
                Next

                If Not plantilla Is Nothing Then 'ACTUALIZA LOS DATOS DE LA CUENTA

                    plantilla.monto = totalCargos
                    plantilla.descripccion = Replace(plantilla.descripccion, "*NUM*", numComidasCuenta)

                    If Not plantilla.actualizar() Then
                        idError = plantilla.idError
                        descripError &= "Cuenta.Actualizar: " & plantilla.descripError & vbCrLf
                    End If
                End If

                'GUARDA Y CREA LAS CUENTAS X PAGAR A LA COCINA
                For x As Integer = 0 To cuentaCocina.Count - 1
                    cuentaCocina(x).descripccion = cuentaCocina(x).descripccion.Replace("*NUM*", contadorComidas(x))

                    If Not cuentaCocina(x).guardar() Then
                        idError = cuentaCocina(x).idError
                        descripError &= "Cuenta.Cocina: " & cuentaCocina(x).descripError & vbCrLf
                    Else
                        plantillaDetalle = New CuentaDetalle(Ambiente)
                        plantillaDetalle.idCuenta = cuentaCocina(x).idCuenta
                        plantillaDetalle.idConceptoCuenta = idConceptoCuentaAbono
                        plantillaDetalle.monto = cuentaCocina(x).monto
                        plantillaDetalle.descripccion = "(" & contadorComidas(x) & ") Comida(s) del Periodo: " & nombrePeriodo & " (" & Format(inicioPeriodo, "dd/MM/yyy") & " - " & Format(finPeriodo, "dd/MM/yyy") & ") "

                        If Not plantillaDetalle.guardar() Then
                            idError = plantillaDetalle.idError
                            descripError &= "Cuenta.Detalle.Cocina: " & plantillaDetalle.descripError & vbCrLf
                        End If
                    End If
                Next
            Else
                idError = conex.idError
                descripError &= "DS: " & conex.descripError & vbCrLf
            End If

            If descripError.Length > 0 Then
                Return False
            Else
                esActivo = 0
                If actualizar() Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
    End Function

    Private Sub creaDSDatosRegistrosES(idDepartamento As Integer, busqueda As String, idEmpleado As Integer)
        rptDatos = New Reporte(Ambiente, "Periodo", "Registros" & elementoSistema)
        dsDatos = New DataSet

        conex.numCon = 0

        'Comentar al DescomentarClaustro
        conex.Qry = "EXEC [spGetRegOIncXDia] '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa & ",'" & elementoSistema & "'," & idDepartamento & ",'" & busqueda & "','" & Ambiente.idsDepartamentos & "','N'," & idEmpleado
        dsDatos = conex.ejecutaConsultaDS(False)


        'CLAUSTRO
        'rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        'rptDatos.agregaVaribleRU("vInicioPeriodo", inicioPeriodo, GetType(DateTime))
        'rptDatos.agregaVaribleRU("vFinPeriodo", finPeriodo, GetType(DateTime))
        'rptDatos.agregaVarible("vIDEmpresa", idEmpresa, GetType(Integer))
        'rptDatos.agregaVarible("vIDDep", idDepartamento, GetType(Integer))
        'rptDatos.agregaVarible("vBusquedas", busqueda)
        'rptDatos.agregaVarible("vAccDeps", Ambiente.idsDepartamentos, GetType(String))
        'rptDatos.agregaVarible("vIDEmp", idEmpleado, GetType(Integer))
        '----------------------

        rptDatos.agregaVarible("InicioPerido", Format(inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo)
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("rfcEmpresa", Ambiente.empr.rfcEmpresa)

    End Sub

    Public Sub cargaGridRegistrosESXPeriodo(grid As DataGridView, idEmpleado As Integer)
        dsDatos = New DataSet

        conex.numCon = 0
        conex.Qry = "EXEC [spGetRegOIncXDia] '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa & ",'" & elementoSistema & "',0,'','" & Ambiente.idsDepartamentos & "','N'," & idEmpleado

        dsDatos = conex.ejecutaConsultaDS(False)

        dsDatos.Tables(0).Columns.Remove("nombreDepartamento")
        dsDatos.Tables(0).Columns.Remove("idEmpleado")
        dsDatos.Tables(0).Columns.Remove("Incidencia")
        dsDatos.Tables(0).Columns.Remove("minRetardo")
        dsDatos.Tables(0).Columns.Remove("nEmpleado")
        dsDatos.Tables(0).Columns.Remove("HorasXDia")
        dsDatos.Tables(0).Columns.Remove("MinXDia")
        dsDatos.Tables(0).Columns.Remove("EntradaLaboral")
        dsDatos.Tables(0).Columns.Remove("regsInvalidos")
        dsDatos.Tables(0).Columns.Remove("tipoReg1")
        dsDatos.Tables(0).Columns.Remove("tipoReg2")
        dsDatos.Tables(0).Columns.Remove("tipoReg3")
        dsDatos.Tables(0).Columns.Remove("tipoReg4")
        dsDatos.Tables(0).Columns.Remove("Reg5")
        dsDatos.Tables(0).Columns.Remove("tipoReg5")
        dsDatos.Tables(0).Columns.Remove("Reg6")
        dsDatos.Tables(0).Columns.Remove("tipoReg6")
        dsDatos.Tables(0).Columns.Remove("Reg7")
        dsDatos.Tables(0).Columns.Remove("tipoReg7")
        dsDatos.Tables(0).Columns.Remove("Reg8")
        dsDatos.Tables(0).Columns.Remove("tipoReg8")
        dsDatos.Tables(0).Columns.Remove("TiempoExtra")
        dsDatos.Tables(0).Columns.Remove("TotalHoras2")
        dsDatos.Tables(0).Columns.Remove("TotalHoras")

        grid.DataSource = dsDatos.Tables(0)

        'Bloquear REORDENAR
        For i As Integer = 0 To grid.Columns.Count - 1
            grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub creaDSDatosIncidenciaES(idDepartamento As Integer, busqueda As String)
        rptDatos = New Reporte(Ambiente, "Periodo", "Incidencias" & elementoSistema)
        dsDatos = New DataSet

        'conex.numCon = 0
        'conex.Qry = "EXEC [spGetRegOIncXDia] '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa & ",'" & elementoSistema & "'," & idDepartamento & ",'" & busqueda & "','" & Ambiente.idsDepartamentos & "','Y'"

        'dsDatos = conex.ejecutaConsultaDS(False)

        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)

        rptDatos.agregaVarible("idEmpresa", Ambiente.empr.idEmpresa, GetType(Integer))
        rptDatos.agregaVarible("idUsuario", Ambiente.usuario.idEmpleado, GetType(Integer))
        rptDatos.agregaVarible("razonSocial", Ambiente.empr.razonSocial)
        rptDatos.agregaVarible("idDepartamento", idDepartamento, GetType(Integer))
        rptDatos.agregaVarible("busqueda", busqueda)
        If Ambiente.usuario.tipoUsuarioSistema = "RH" Then
            rptDatos.agregaVaribleRU("InicioPerido", inicioPeriodo, GetType(Date))
            rptDatos.agregaVaribleRU("FinPeriodo", finPeriodo, GetType(Date))
        Else
            rptDatos.agregaVarible("InicioPerido", inicioPeriodo, GetType(Date))
            rptDatos.agregaVarible("FinPeriodo", finPeriodo, GetType(Date))
        End If
        rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo, GetType(Integer))
    End Sub

    Private Sub creaDSDatosIncidenciaEmpleado(idEmpleado As Integer)
        dsDatos = New DataSet
        rptDatos = New Reporte(Ambiente, "Periodo", "IncidenciasEmplado")
        conex.numCon = 0
        'conex.Qry = "EXEC spGetInciXEmplXRango " & idEmpleado & ",'" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'"
        'dsDatos = conex.ejecutaConsultaDS(False)
        rptDatos.agregaVarible("InicioPerido", Format(inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo)
        rptDatos.agregaVarible("idEmpleado", idEmpleado)
    End Sub

    Private Sub creaDSDatosRegistrosCO()
        Dim dr As DataRow

        rptDatos = New Reporte(Ambiente, "Periodo", "Registros" & elementoSistema)
        dsDatos = New DataSet

        'Tabla
        dsDatos.Tables.Add("PeriodoCocina")

        'Columnas
        dsDatos.Tables(0).Columns.Add("ID_Empleado")
        dsDatos.Tables(0).Columns.Add("NombreEmpleado")
        dsDatos.Tables(0).Columns.Add("NombreDepartamento")
        dsDatos.Tables(0).Columns.Add("CocinaAsignada")
        dsDatos.Tables(0).Columns.Add("CocinaRegistro")
        dsDatos.Tables(0).Columns.Add("CostoComida").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Costo").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha1").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha2").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha3").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha4").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha5").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha6").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha7").DataType = Type.GetType("System.Decimal")

        conex.numCon = 0
        conex.Qry = "spGetResultadosSinProcesar"

        Dim obj(,) As Object = New Object(4, 2) {}

        obj(0, 0) = "@fechaInicial"
        obj(0, 1) = Format(inicioPeriodo, "yyyy-MM-dd")

        obj(1, 0) = "@fechaFinal"
        obj(1, 1) = Format(finPeriodo, "yyyy-MM-dd")

        obj(2, 0) = "@idEmpresa"
        obj(2, 1) = idEmpresa

        obj(3, 0) = "@elemento"
        obj(3, 1) = elementoSistema

        If conex.ejecutaSP(obj) Then
            'Registros

            While conex.reader.Read
                dr = dsDatos.Tables(0).NewRow

                dr(0) = conex.reader(0)
                dr(1) = conex.reader(1)
                dr(2) = conex.reader(2)
                dr(3) = conex.reader(3)
                dr(4) = conex.reader(4)
                dr(5) = conex.reader(5)
                dr(6) = conex.reader(6)

                Try
                    dr(7) = conex.reader(7)
                    dr(8) = conex.reader(8)
                    dr(9) = conex.reader(9)
                    dr(10) = conex.reader(10)
                    dr(11) = conex.reader(11)
                    dr(12) = conex.reader(12)
                    dr(13) = conex.reader(13)
                Catch ex As Exception

                End Try

                dsDatos.Tables(0).Rows.Add(dr)
            End While

            rptDatos.agregaVarible("InicioPerido", Format(inicioPeriodo, "dd MMMM yyyy"))
            rptDatos.agregaVarible("FinPeriodo", Format(finPeriodo, "dd MMMM yyyy"))
            rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
            rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo)

            Dim valor As String
            For i As Integer = 1 To 7
                Try
                    valor = conex.reader.GetName(i + 6)
                Catch ex As Exception
                    valor = ""
                End Try
                rptDatos.agregaVarible("Fecha" & i, valor)
            Next

            conex.reader.Close()
        Else
            Mensaje.Mensaje = conex.descripError
            Mensaje.origen = "Periodo.creaDSDatosRegistrosCO"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub RPT_ImprimirDatosRegistros(idDepartamento As Integer, busqueda As String, idEmpleado As Integer)
        If elementoSistema = "ES" Then
            creaDSDatosRegistrosES(idDepartamento, busqueda, idEmpleado)
        Else
            creaDSDatosRegistrosCO()
        End If
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ImprimirDatosIncidencia(idDepartamento As Integer, busqueda As String)
        creaDSDatosIncidenciaES(idDepartamento, busqueda)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ImprimirDatosIncidenciaEmpleado(idEmpleado As Integer)
        creaDSDatosIncidenciaEmpleado(idEmpleado)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatosIncidenciaEmpleado(idEmpleado As Integer)
        creaDSDatosIncidenciaEmpleado(idEmpleado)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatosIncidencia(idDepartamento As Integer, busqueda As String)
        creaDSDatosIncidenciaES(idDepartamento, busqueda)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatosRegistros(idDepartamento As Integer, busqueda As String, idEmpleado As Integer)
        If elementoSistema = "ES" Then
            creaDSDatosRegistrosES(idDepartamento, busqueda, idEmpleado)
        Else
            creaDSDatosRegistrosCO()
        End If
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirDatos(idDepartamento As Integer)
        creaDSDatos(idDepartamento)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatos(idDepartamento As Integer)
        creaDSDatos(idDepartamento)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatosConcentrado()
        creaDSCO(True, False)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirDatosConcentrado()
        creaDSCO(True, False)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDatosConcentradoAgrupado()
        creaDSCO(True, True)
        rptDatos.modificar(dsDatos)
    End Sub

    Public Sub RPT_ImprimirDatosConcentradoAgrupado()
        creaDSCO(True, True)
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ImprimirConciliacion()
        creaDSDatosConciliacion()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarConciliacion()
        creaDSDatosConciliacion()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosConciliacion()
        rptDatos = New Reporte(Ambiente, "Periodo", "ReporteConciliacion")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Sub RPT_ImprimirFaltasXPeriodo()
        creaDSDatosFaltasXPeriodo()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarFaltasXPeriodo()
        creaDSDatosFaltasXPeriodo()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosFaltasXPeriodo()
        rptDatos = New Reporte(Ambiente, "Periodo", "ReporteFaltasXPeriodo")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    'BANCOMER....
    Public Sub RPT_ImprimirLayoutBancomer()
        creaDSDatosLayoutBancomer()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarLayoutBancomer()
        creaDSDatosLayoutBancomer()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosLayoutBancomer()
        rptDatos = New Reporte(Ambiente, "Periodo", "LayoutBancomer")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--FIN BANCOMER

    'BANAMEX....
    Public Sub RPT_ImprimirLayoutBanamex()
        creaDSDatosLayoutBanamex()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarLayoutBanamex()
        creaDSDatosLayoutBanamex()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosLayoutBanamex()
        rptDatos = New Reporte(Ambiente, "Periodo", "LayoutBanamex")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--FIN BANAMEX

    'BANORTE....
    Public Sub RPT_ImprimirLayoutBanorte()
        creaDSDatosLayoutBanorte()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarLayoutBanorte()
        creaDSDatosLayoutBanorte()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosLayoutBanorte()
        rptDatos = New Reporte(Ambiente, "Periodo", "LayoutBanorte")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--FIN BANORTE

    '2%....
    Public Sub RPT_ImprimirDosP()
        creaDSDatosDosP()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarDosP()
        creaDSDatosDosP()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosDosP()
        rptDatos = New Reporte(Ambiente, "Periodo", "DosPorciento")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--FIN 2%

    'NominaXSeg....
    Public Sub RPT_ImprimirNomXSeg()
        creaDSDatosNomXSeg()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarNomXSeg()
        creaDSDatosNomXSeg()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosNomXSeg()
        rptDatos = New Reporte(Ambiente, "Periodo", "NominaXSeg")
        'rptDatos.agregaVarible("idEmpresa", idEmpresa)
        'rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--Fin NominaXSeg

    'POLIZA....
    Public Sub RPT_ImprimirPoliza()
        creaDSDatosPoliza()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPoliza()
        creaDSDatosPoliza()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosPoliza()
        rptDatos = New Reporte(Ambiente, "Periodo", "Poliza")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--FIN POLIZA%

    '--TIKET CO....
    Public Sub RPT_ImprimirTiketCO()
        creaDSDatosTiketCO()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarTiketCO()
        creaDSDatosTiketCO()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosTiketCO()
        rptDatos = New Reporte(Ambiente, "Periodo", "TiketCO")

        rptDatos.agregaVarible("idEmpresa", idEmpresa)
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub
    '--TIKET CO

    Public Sub RPT_ImprimirPercepciones()
        creaDSDatosPercepciones()
        rptDatos.imprimir(dsDatos)
    End Sub

    Public Sub RPT_ModificarPercepciones()
        creaDSDatosPercepciones()
        rptDatos.modificar(dsDatos)
    End Sub

    Private Sub creaDSDatosPercepciones()
        rptDatos = New Reporte(Ambiente, "Periodo", "PercepcionesXPer")

        rptDatos.agregaVarible("idEmpresa", idEmpresa, GetType(Integer))
        rptDatos.modConexSti("Zeus", Ambiente.conex.conexBuild(0).ConnectionString)
    End Sub

    Public Function validaFechaEnRango(fecha As Date) As Boolean
        idError = 0
        descripError = ""

        conex.numCon = 0
        conex.Qry = "Select * From Periodo Where idEmpresa =" & idEmpresa & " And tabla = '" & tabla & "' AND esActivo = 1 AND elementoSistema = '" & elementoSistema & "' and convert(date,'" & Format(fecha, "yyyy-MM-dd") & "') between inicioPeriodo AND finPeriodo"

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                conex.reader.Close()
                Return True
            Else
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub creaDSDatos(idDepartamento As Integer)
        If elementoSistema = "CO" Then
            creaDSCO(False, False)
        Else
            creaDSES(idDepartamento)
        End If
    End Sub

    Private Sub creaDSES(idDepartamento As Integer)
        Dim dr As DataRow

        rptDatos = New Reporte(Ambiente, "Periodo", "Datos" & elementoSistema)
        dsDatos = New DataSet

        'Tabla
        dsDatos.Tables.Add("ResultadoPeriodoES")

        'Columnas
        dsDatos.Tables(0).Columns.Add("ID_Empleado")
        dsDatos.Tables(0).Columns.Add("NombreEmpleado")
        dsDatos.Tables(0).Columns.Add("NombreDepartamento")
        dsDatos.Tables(0).Columns.Add("Horario")
        dsDatos.Tables(0).Columns.Add("A").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("BJL").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("CHET").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("CHR").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("D").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("DF").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("D_PRDO").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("F").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("I").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("PGS").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("PSGS").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("SSI").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("SSR").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("THL").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("VD").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("idResultadoPeriodoES")
        dsDatos.Tables(0).Columns.Add("TE").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("TFN").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("TotalAbonos").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("NumComidas").DataType = Type.GetType("System.Int32")
        dsDatos.Tables(0).Columns.Add("costoXhoraExtra").DataType = Type.GetType("System.Decimal")


        'Tabla
        dsDatos.Tables.Add("ResultadoFormulaES")

        'Columnas
        dsDatos.Tables(1).Columns.Add("idResultadoPeriodoES")
        dsDatos.Tables(1).Columns.Add("elemento")
        dsDatos.Tables(1).Columns.Add("nombreVariable")
        dsDatos.Tables(1).Columns.Add("resultado").DataType = Type.GetType("System.Decimal")

        'RESULTADO ResultadoPeriodoES
        conex.numCon = 0
        conex.accion = "SELECT"

        conex.agregaCampo("R.idEmpleado")
        conex.agregaCampo("R.idResultadoPeriodoES")
        conex.agregaCampo("concat(E.apPatEmpleado,' ',E.apMatEmpleado,' ',E.nombreEmpleado) as nEmpleado")
        conex.agregaCampo("D.nombreDepartamento")
        conex.agregaCampo("H.nombreHorario")
        conex.agregaCampo("R.A")
        conex.agregaCampo("R.BJL")
        conex.agregaCampo("R.CHET")
        conex.agregaCampo("R.CHR")
        conex.agregaCampo("R.D")
        conex.agregaCampo("R.DF")
        conex.agregaCampo("R.D_PRDO")
        conex.agregaCampo("R.F")
        conex.agregaCampo("R.I")
        conex.agregaCampo("R.PGS")
        conex.agregaCampo("R.PSGS")
        conex.agregaCampo("R.SSI")
        conex.agregaCampo("R.SSR")
        conex.agregaCampo("R.THL")
        conex.agregaCampo("R.VD")
        conex.agregaCampo("R.TE")
        conex.agregaCampo("R.TFN")
        conex.agregaCampo("(SELECT sum(monto) FROM Cuenta where estado in ('CO','PR') AND tipoCuenta = 'CxP' AND idEmpleado = E.idEmpleado and fechaCuenta between convert(date,'" & Format(inicioPeriodo, "yyyy-MM-dd") & "') and convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "')) as TotalAbonos")
        conex.agregaCampo("(SELECT sum(CAST(SUBSTRING(descripccion,2,1) as INT)) FROM Cuenta where tipoCuenta='CxC' AND sistemaOrigen = 'Periodo.procesaComidas' AND estado in ('CO','PR') AND idEmpleado = E.idEmpleado and fechaCuenta between convert(date,'" & Format(inicioPeriodo, "yyyy-MM-dd") & "') and convert(date,'" & Format(finPeriodo, "yyyy-MM-dd") & "')) as NumComidas")
        conex.agregaCampo("(SELECT costoXhoraExtra FROM TabuladorVersion tv WHERE tv.idTabulador = E.idTabulador ) As costoXhoraExtra")

        conex.tabla = "ResultadoPeriodoES as R,Departamento as D,Empleado as E,Horario as H"

        conex.condicion = "WHERE "
        conex.condicion &= "E.idEmpleado = R.idEmpleado "
        conex.condicion &= "AND D.idDepartamento = R.idDepartamento "
        If idDepartamento <> Nothing Then
            conex.condicion &= " AND D.idDepartamento = " & idDepartamento & " "
        End If
        conex.condicion &= "AND H.idHorario = R.idHorario "
        conex.condicion &= "AND idPeriodo=" & idPeriodo

        conex.armarQry()
        'InputBox("", "", conex.Qry)
        If conex.ejecutaConsulta() Then
            'Registros

            While conex.reader.Read
                dr = dsDatos.Tables(0).NewRow

                dr(0) = conex.reader("idEmpleado")
                dr(1) = conex.reader("nEmpleado")
                dr(2) = conex.reader("nombreDepartamento")
                dr(3) = conex.reader("nombreHorario")
                dr(4) = conex.reader("A")
                dr(5) = conex.reader("BJL")
                dr(6) = conex.reader("CHET")
                dr(7) = conex.reader("CHR")
                dr(8) = conex.reader("D")
                dr(9) = conex.reader("DF")
                dr(10) = conex.reader("D_PRDO")
                dr(11) = conex.reader("F")
                dr(12) = conex.reader("I")
                dr(13) = conex.reader("PGS")
                dr(14) = conex.reader("PSGS")
                dr(15) = conex.reader("SSI")
                dr(16) = conex.reader("SSR")
                dr(17) = conex.reader("THL")
                dr(18) = conex.reader("VD")
                dr(19) = conex.reader("idResultadoPeriodoES")
                dr(20) = conex.reader("TE")
                dr(21) = conex.reader("TFN")
                dr(22) = conex.reader("TotalAbonos")
                dr(23) = conex.reader("NumComidas")
                dr(24) = conex.reader("costoXhoraExtra")

                dsDatos.Tables(0).Rows.Add(dr)
            End While
            conex.reader.Close()

        Else
            Mensaje.Mensaje = conex.descripError
            Mensaje.origen = "Periodo.creaDSES.ResultadoPeriodoES"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If

        Dim idResultadoPeriodoES As Integer

        For i As Integer = 0 To dsDatos.Tables(0).Rows.Count - 1
            'ResultadoFormulaEs
            idResultadoPeriodoES = dsDatos.Tables(0).Rows(i).Item(19)

            conex.numCon = 0
            conex.accion = "SELECT"

            conex.agregaCampo("R.idResultadoPeriodoES")
            conex.agregaCampo("VF.elemento")
            conex.agregaCampo("VF.nombreVariable")
            conex.agregaCampo("R.resultado")

            conex.tabla = "ResultadoFormulaES as R,Formula as F,VariableFormula as VF"

            conex.condicion = "WHERE "
            conex.condicion &= "R.idFormula = F.idFormula "
            conex.condicion &= "AND VF.idVariableFormula = F.idVariableFormula "
            conex.condicion &= "AND F.esImpreso = 1"
            conex.condicion &= "AND idResultadoPeriodoES=" & idResultadoPeriodoES
            conex.condicion &= " ORDER BY F.ordenEnReporte"

            conex.armarQry()

            If conex.ejecutaConsulta() Then
                'Registros

                While conex.reader.Read
                    dr = dsDatos.Tables(1).NewRow

                    dr(0) = conex.reader("idResultadoPeriodoES")
                    dr(1) = conex.reader("elemento")
                    dr(2) = conex.reader("nombreVariable")
                    dr(3) = conex.reader("resultado")

                    dsDatos.Tables(1).Rows.Add(dr)
                End While
                conex.reader.Close()

            Else
                Mensaje.Mensaje = conex.descripError
                Mensaje.origen = "Periodo.creaDSES.ResultadoFormulaES"
                Mensaje.tipoMsj = TipoMensaje.Error
                Mensaje.ShowDialog()
            End If
        Next


        'VARIABLES
        rptDatos.agregaVarible("InicioPerido", Format(inicioPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("FinPeriodo", Format(finPeriodo, "dd MMMM yyyy"))
        rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
        rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo)
    End Sub

    Public Function eliminarDuplicadosComida()
        idError = 0
        descripError = ""

        conex.numCon = 0
        conex.Qry = "EXEC spVerificarRegComida '" & Format(inicioPeriodo, "yyyy-MM-dd") & "','" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idEmpresa

        If conex.ejecutaQry() Then
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Private Sub creaDSCO(concentrado As Boolean, agrupado As Boolean)
        Dim dr As DataRow

        If concentrado And Not agrupado Then
            rptDatos = New Reporte(Ambiente, "Periodo", "DatosConcentrado" & elementoSistema)
        ElseIf concentrado Then
            rptDatos = New Reporte(Ambiente, "Periodo", "DatosConAgrupado" & elementoSistema)
        Else
            rptDatos = New Reporte(Ambiente, "Periodo", "Datos" & elementoSistema)
        End If

        dsDatos = New DataSet

        'Tabla
        dsDatos.Tables.Add("PeriodoCocina")

        'Columnas
        dsDatos.Tables(0).Columns.Add("ID_Empleado")
        dsDatos.Tables(0).Columns.Add("NombreEmpleado")
        dsDatos.Tables(0).Columns.Add("NombreDepartamento")
        dsDatos.Tables(0).Columns.Add("NombreSucursal")
        dsDatos.Tables(0).Columns.Add("CocinaAsignada")
        dsDatos.Tables(0).Columns.Add("CocinaRegistro")
        dsDatos.Tables(0).Columns.Add("CostoComida").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("csIMSS")
        dsDatos.Tables(0).Columns.Add("numReg")
        dsDatos.Tables(0).Columns.Add("direccionFiscal")
        dsDatos.Tables(0).Columns.Add("correo")
        dsDatos.Tables(0).Columns.Add("Fecha1").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha2").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha3").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha4").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha5").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha6").DataType = Type.GetType("System.Decimal")
        dsDatos.Tables(0).Columns.Add("Fecha7").DataType = Type.GetType("System.Decimal")

        conex.numCon = 0
        conex.Qry = "spGetResultados"

        Dim obj(,) As Object = New Object(2, 2) {}

        obj(0, 0) = "@idPeriod"
        obj(0, 1) = idPeriodo

        obj(1, 0) = "@elemento"
        obj(1, 1) = elementoSistema

        If conex.ejecutaSP(obj) Then
            'Registros

            While conex.reader.Read
                dr = dsDatos.Tables(0).NewRow

                dr(0) = conex.reader(0)
                dr(1) = conex.reader(1)
                dr(2) = conex.reader(2)
                dr(3) = conex.reader(3)
                dr(4) = conex.reader(4)
                dr(5) = conex.reader(5)
                dr(6) = conex.reader(6)
                dr(7) = conex.reader(7)
                dr(8) = conex.reader(8)
                dr(9) = conex.reader(9)
                dr(10) = conex.reader(10)

                Try
                    dr(11) = conex.reader(11)
                    dr(12) = conex.reader(12)
                    dr(13) = conex.reader(13)
                    dr(14) = conex.reader(14)
                    dr(15) = conex.reader(15)
                    dr(16) = conex.reader(16)
                    dr(17) = conex.reader(17)
                Catch ex As Exception

                End Try

                dsDatos.Tables(0).Rows.Add(dr)
            End While

            rptDatos.agregaVarible("InicioPerido", Format(inicioPeriodo, "dd MMMM yyyy"))
            rptDatos.agregaVarible("FinPeriodo", Format(finPeriodo, "dd MMMM yyyy"))
            rptDatos.agregaVarible("nombrePeriodo", nombrePeriodo)
            rptDatos.agregaVarible("numeroPeriodo", numeroPeriodo)

            Dim valor As String
            For i As Integer = 1 To 8
                Try
                    valor = conex.reader.GetName(i + 8)
                Catch ex As Exception
                    valor = ""
                End Try
                rptDatos.agregaVarible("Fecha" & i, valor)
            Next

            conex.reader.Close()
        Else
            Mensaje.Mensaje = conex.descripError
            Mensaje.origen = "Periodo.creaDSDatos"
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function getDiasRango() As List(Of Date)
        diasRango.Clear()
        Dim diasPeriodo As Integer
        diasPeriodo = DateDiff(DateInterval.Day, inicioPeriodo, finPeriodo)

        For i As Integer = 0 To diasPeriodo
            diasRango.Add(inicioPeriodo.AddDays(i))
        Next
        Return diasRango
    End Function

    Public Function getComboTodos(combo As ComboBox, objCombo As List(Of Periodo)) As Boolean
        Dim cCond As String

        idError = 0
        descripError = ""

        objCombo.Clear()
        combo.Items.Clear()

        Dim plantilla As Periodo
        Dim perAnt As String

        If elementoSistema = "ES" Or elementoSistema = "CO" Then
            perAnt = "50,51,52,53"
        Else
            perAnt = "10,11,12"
        End If
        conex.numCon = 0
        cCond = " AND ((ejercicio=" & ejercicio & ") or (ejercicio = " & ejercicio - 1 & " and numeroPeriodo in (" & perAnt & ")) or (ejercicio = " & ejercicio + 1 & " and numeroPeriodo in (1,2,3))) "
        conex.Qry = "SELECT * FROM Periodo WHERE idEmpresa = " & idEmpresa & cCond & " AND elementoSistema = '" & elementoSistema & "' AND tabla ='" & tabla & "'"
        If conex.ejecutaConsulta Then
            While conex.reader.Read
                plantilla = New Periodo(Ambiente)
                plantilla.seteaDatos(conex.reader)

                combo.Items.Add(plantilla.nombrePeriodo & " - (" & Format(plantilla.inicioPeriodo, "dd/MM/yyyy") & " - " & Format(plantilla.finPeriodo, "dd/MM/yyyy") & ")" & If(plantilla.esActivo, "", "PROCESADO"))

                objCombo.Add(plantilla)
            End While
            conex.reader.Close()
            Return True
        Else
            idError = conex.idError
            descripError = conex.descripError
            Return False
        End If
    End Function

    Public Sub cargarGridDiasPeriodoXEmpl(grid As DataGridView, idEmpleado As Integer, objGrid As List(Of Incidencia))
        Dim plantilla As Incidencia
        Dim dtb As New DataTable("Periodo")
        Dim row As DataRow
        Dim indice As Integer = 0

        objGrid.Clear()

        dtb.Columns.Add("Dia", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Incidencia", Type.GetType("System.String"))
        dtb.Columns.Add("Creada Por", Type.GetType("System.String"))

        Dim lista As List(Of Date) = getDiasRango()

        For i As Integer = 0 To lista.Count - 1
            plantilla = New Incidencia(Ambiente)
            plantilla.idEmpleado = idEmpleado
            plantilla.idEmpresa = Ambiente.empr.idEmpresa
            plantilla.fecha = lista(i).Date
            plantilla.calculada = False
            plantilla.buscarXFechaXEmpl()

            row = dtb.NewRow
            row("Dia") = UCase(Format(plantilla.fecha, "dddd"))
            row("Fecha") = Format(plantilla.fecha, "dd/MM/yyyy")
            If plantilla.idIncidencia = Nothing Then
                row("Incidencia") = "Ninguna"
                row("Creada Por") = "N/A"
            Else
                row("Incidencia") = plantilla.getTipoInicidencia.nombreIncidencia
                row("Creada Por") = Format(plantilla.creado, "dd/MM/yyyy") & " (" & plantilla.getActualizadoPor.usuario & ")"
            End If

            objGrid.Add(plantilla)
            dtb.Rows.Add(row)
        Next

        grid.DataSource = dtb

        'Bloquear REORDENAR
        For i As Integer = 0 To grid.Columns.Count - 1
            grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Public Sub cargarGridDiasPeriodoXEmplCalculadas(grid As DataGridView, idEmpleado As Integer, objGrid As List(Of Incidencia))
        Dim plantilla As Incidencia
        Dim dtb As New DataTable("Periodo")
        Dim row As DataRow
        Dim indice As Integer = 0

        objGrid.Clear()

        dtb.Columns.Add("Dia", Type.GetType("System.String"))
        dtb.Columns.Add("Fecha", Type.GetType("System.String"))
        dtb.Columns.Add("Incidencia", Type.GetType("System.String"))
        dtb.Columns.Add("Creada Por", Type.GetType("System.String"))

        Dim lista As List(Of Date) = getDiasRango()
        Dim objIncidencias As New List(Of Incidencia)

        For i As Integer = 0 To lista.Count - 1
            plantilla = New Incidencia(Ambiente)
            plantilla.idEmpleado = idEmpleado
            plantilla.idEmpresa = Ambiente.empr.idEmpresa
            plantilla.fecha = lista(i).Date
            plantilla.calculada = True
            plantilla.buscarXFechaXEmpl(objIncidencias)

            For nInc As Integer = 0 To objIncidencias.Count - 1

                row = dtb.NewRow
                row("Dia") = UCase(Format(objIncidencias(nInc).fecha, "dddd"))
                row("Fecha") = Format(objIncidencias(nInc).fecha, "dd/MM/yyyy")
                row("Incidencia") = objIncidencias(nInc).getTipoInicidencia.nombreIncidencia
                row("Creada Por") = Format(objIncidencias(nInc).creado, "dd/MM/yyyy") & " (" & objIncidencias(nInc).getActualizadoPor.usuario & ")"

                objGrid.Add(objIncidencias(nInc))
                dtb.Rows.Add(row)
            Next
        Next

        grid.DataSource = dtb

        'Bloquear REORDENAR
        For i As Integer = 0 To grid.Columns.Count - 1
            grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub cargarGridGen(grid As DataGridView, condicion As String, objEmp As List(Of Periodo))
        Dim plantilla As Periodo
        Dim dtb As New DataTable("Periodo")
        Dim row As DataRow
        Dim indice As Integer = 0
        Dim cCond As String

        dtb.Columns.Add("Ejercicio", Type.GetType("System.Int32"))
        dtb.Columns.Add("# Periodo", Type.GetType("System.Int32"))
        dtb.Columns.Add("Nombre Periodo", Type.GetType("System.String"))
        dtb.Columns.Add("Es Activo", Type.GetType("System.Boolean"))

        objEmp.Clear()

        Dim perAnt As String

        If elementoSistema = "ES" Or elementoSistema = "CO" Then
            perAnt = "50,51,52,53"
        Else
            perAnt = "10,11,12"
        End If

        cCond = " AND ((ejercicio=" & ejercicio & ") or (ejercicio = " & ejercicio - 1 & " and numeroPeriodo in (" & perAnt & ")) or (ejercicio = " & ejercicio + 1 & " and numeroPeriodo in (1,2,3))) "

        conex.Qry = "SELECT P.* FROM Periodo as P WHERE P.idEmpresa = " & idEmpresa & cCond & " AND tabla = '" & tabla & "' AND elementoSistema = '" & elementoSistema & "'" &
            condicion

        conex.numCon = 0
        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Periodo(Ambiente)
                plantilla.seteaDatos(conex.reader)
                objEmp.Add(plantilla)
                row = dtb.NewRow
                row("Ejercicio") = plantilla.ejercicio
                row("# Periodo") = plantilla.numeroPeriodo
                row("Nombre Periodo") = plantilla.nombrePeriodo
                row("Es Activo") = plantilla.esActivo

                dtb.Rows.Add(row)
                indice += 1
            End While
            conex.reader.Close()

            grid.DataSource = dtb

            'Bloquear REORDENAR
            For i As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Periodo.cargarGridGen"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Sub cargaGridCom(dgvDepartamento As DataGridView, obj As List(Of Periodo))
        cargarGridGen(dgvDepartamento, "", obj)
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idPeriodo = rdr("idPeriodo")
        nombrePeriodo = rdr("nombrePeriodo")
        inicioPeriodo = rdr("inicioPeriodo")
        finPeriodo = rdr("finPeriodo")
        ejercicio = rdr("ejercicio")
        idEmpresa = rdr("idEmpresa")
        idSucursal = rdr("idSucursal")
        creado = rdr("creado")
        creadoPor = rdr("creadoPor")
        actualizado = rdr("actualizado")
        actualizadoPor = rdr("actualizadoPor")
        numeroPeriodo = rdr("numeroPeriodo")
        tabla = rdr("tabla")
        esActivo = rdr("esActivo")
        elementoSistema = rdr("elementoSistema")
        idConceptoCuentaCargo = If(IsDBNull(rdr("idConceptoCuentaCargo")), Nothing, rdr("idConceptoCuentaCargo"))
        idConceptoCuentaAbono = If(IsDBNull(rdr("idConceptoCuentaAbono")), Nothing, rdr("idConceptoCuentaAbono"))
        idVariableFormula = If(IsDBNull(rdr("idVariableFormula")), Nothing, rdr("idVariableFormula"))
        idPeriodoCTPQ = If(IsDBNull(rdr("idPeriodoCTPQ")), Nothing, rdr("idPeriodoCTPQ"))
        desfaceCONTPAQ = rdr("desfaceCONTPAQ")
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Periodo"
            conex.accion = accion

            conex.agregaCampo("nombrePeriodo", nombrePeriodo, False, False)
            conex.agregaCampo("inicioPeriodo", inicioPeriodo, False, False)
            conex.agregaCampo("finPeriodo", finPeriodo, False, False)
            conex.agregaCampo("ejercicio", ejercicio, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("idSucursal", idSucursal, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("numeroPeriodo", numeroPeriodo, False, False)
            conex.agregaCampo("tabla", tabla, False, False)
            conex.agregaCampo("elementoSistema", elementoSistema, False, False)
            conex.agregaCampo("idConceptoCuentaCargo", idConceptoCuentaCargo, True, False)
            conex.agregaCampo("idConceptoCuentaAbono", idConceptoCuentaAbono, True, False)
            conex.agregaCampo("idVariableFormula", idVariableFormula, True, False)
            conex.agregaCampo("idPeriodoCTPQ", idPeriodoCTPQ, True, False)
            conex.agregaCampo("desfaceCONTPAQ", desfaceCONTPAQ, False, False)

            If esInsert Then
                conex.agregaCampo("creado", "CURRENT_TIMESTAMP", False, True)
                conex.agregaCampo("creadoPor", creadoPor, False, False)
            End If
            conex.agregaCampo("actualizado", "CURRENT_TIMESTAMP", False, True)
            conex.agregaCampo("actualizadoPor", actualizadoPor, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idPeriodo = " & idPeriodo

            conex.armarQry()

            If conex.ejecutaQry Then
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

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", False)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", False)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.numCon = 0
        conex.tabla = "Periodo"
        conex.accion = "SELECT"

        conex.agregaCampo("*")
        conex.condicion = "WHERE idPeriodo=" & idPeriodo

        conex.armarQry()

        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()

            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function


    Public Function buscarPFecha(fecha As Date) As Boolean
        conex.numCon = 0
        conex.tabla = "Periodo"
        conex.Qry = "SELECT Top 1 * FROM Periodo  WHERE idEmpresa=" & idEmpresa & " AND  elementoSistema = '" & elementoSistema & "' AND '" & fecha & "' BETWEEN inicioPeriodo AND finPeriodo"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                seteaDatos(conex.reader)
            End If
            conex.reader.Close()
            idError = conex.idError
            descripError = conex.descripError
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        getCreadoPor()
        getActualizadoPor()
        Return "ID: " & idPeriodo & " | Creado: " & getCreadoPor().usuario & " - " & FormatDateTime(creado) & " | Actualizado: " & getActualizadoPor().usuario & " - " & FormatDateTime(actualizado)
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        idError = 0
        If creadoPor = Nothing Then
            creadoPor = Ambiente.usuario.idEmpleado
        End If
        If actualizadoPor = Nothing Then
            actualizadoPor = Ambiente.usuario.idEmpleado
        End If
        If idEmpresa = Nothing Then
            idEmpresa = Ambiente.empr.idEmpresa
        End If
        If idSucursal = Nothing Then
            idSucursal = Ambiente.suc.idSucursal
        End If
        If nombrePeriodo = Nothing Then
            descripError = "El nombre del periodo es un CAMPO obligatorio..."
            idError = 1
            Return False
        ElseIf inicioPeriodo = Nothing Then
            descripError = "La fecha de inicio del periodo es un CAMPO obligatorio..."
            idError = 2
            Return False
        ElseIf finPeriodo = Nothing Then
            descripError = "La fecha de fin del periodo es un CAMPO obligatorio..."
            idError = 3
            Return False
        ElseIf ejercicio = Nothing Then
            descripError = "El ejercicio del periodo es un CAMPO obligatorio..."
            idError = 4
            Return False
        ElseIf numeroPeriodo = Nothing Then
            descripError = "El numero del periodo es un CAMPO obligatorio..."
            idError = 5
            Return False
        ElseIf tabla = Nothing Then
            descripError = "La tabla del periodo no está DEFINIDA..."
            idError = 6
            Return False
        ElseIf elementoSistema = Nothing Then
            descripError = "El elemento del periodo no está DEFINIDO..."
            idError = 7
            Return False
        End If
        Return True
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
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function

    Public Function procesarIncidencias(idEmpleado As Integer)
        If esActivo Then
            conex.Qry = "EXEC spIncidenciasCalculadas '" & Format(inicioPeriodo, "yyyy-MM-dd") & "', '" & Format(finPeriodo, "yyyy-MM-dd") & "'," & Ambiente.empr.idEmpresa & "," & idEmpleado
            'InputBox("", "", conex.Qry)
            If Not conex.ejecutaQry() Then
                idError = 5
                descripError &= "Inc.Manuales: " & conex.descripError
                Return False
            Else
                Return True
            End If
        Else
            descripError = "Periodo Cerrado...!!"
            Return False
        End If
    End Function

    Public Function procesarIncidencias()
        If esActivo Then
            conex.Qry = " EXEC spIncidenciasCalculadasALL '" & Format(inicioPeriodo, "yyyy-MM-dd") & "', '" & Format(finPeriodo, "yyyy-MM-dd") & "'"
            '  InputBox("", "", conex.Qry)
            If Not conex.ejecutaQry() Then
                idError = 5
                descripError &= "SQL: " & conex.descripError
                Return False
            Else
                Return True
            End If
        Else
            descripError = "Periodo Cerrado...!!"
            Return False
        End If
    End Function

    Public Function procesarIncidenciasXDep(idDepatamento As Integer)
        If esActivo Then
            conex.Qry = " EXEC spIncidenciasCalculadasALL '" & Format(inicioPeriodo, "yyyy-MM-dd") & "', '" & Format(finPeriodo, "yyyy-MM-dd") & "'," & idDepatamento
            '  InputBox("", "", conex.Qry)
            If Not conex.ejecutaQry() Then
                idError = 5
                descripError &= "SQL: " & conex.descripError
                Return False
            Else
                Return True
            End If
        Else
            descripError = "Periodo Cerrado...!!"
            Return False
        End If
    End Function
End Class
