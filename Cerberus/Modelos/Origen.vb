Imports System.Data.SqlClient
Imports Cerberus

Public Class Origen
    Implements InterfaceTablas

    Private Ambiente As AmbienteCls
    Private conex As ConexionSQL

    Public origen As String
    Public nombreBD As String
    Public usuario As String
    Public contrasena As String
    Public tipoBD As String
    Public puerto As Integer
    Public esquema As String
    Public instancia As String
    Public direccionIP As String
    Public esActivo As Boolean
    Public idEmpresa As Integer
    Public omitirCodigo As String
    Public elemento As String

    Public idError As Integer
    Public descripError As String

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        conex = Ambiente.conex
    End Sub

    'Clase especifica de Horario Activas >>>
    Public Sub getComboActivo(combo As ComboBox, idCombos As List(Of Origen))
        Dim filtro As String
        filtro = " AND esActivo=1 AND elemento='" & elemento & "'"

        getCombo(combo, idCombos, filtro)
    End Sub

    'Funcion General de COMBOS
    Private Sub getCombo(combo As ComboBox, idCombos As List(Of Origen), filtro As String)
        Dim plantilla As Origen
        combo.Items.Clear()
        idCombos.Clear()

        conex.Qry = "SELECT * FROM Origen WHERE idEmpresa= " & idEmpresa & " " & filtro
        conex.numCon = 0

        If conex.ejecutaConsulta() Then
            While conex.reader.Read
                plantilla = New Origen(Ambiente)
                plantilla.seteaDatos(conex.reader)
                idCombos.Add(plantilla)
                combo.Items.Add(plantilla.origen)
            End While
            conex.reader.Close()
        Else
            Mensaje.tipoMsj = TipoMensaje.Error
            Mensaje.origen = "Origen.getCombo:"
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
        End If
    End Sub

    Public Function sincronizar() As Boolean
        idError = 0
        descripError = ""

        If tipoBD = "MySQL" Then
            Dim NConex As New ConexionMySQL(direccionIP, nombreBD, usuario, contrasena, puerto, 1)
            Dim empl As Empleado
            Dim etap As Etapa

            Dim relacion As New DestajoUnionEmpleado(Ambiente)
            relacion.idEmpresa = idEmpresa
            relacion.origen = origen

            Dim destaj As Destajo
            destaj = New Destajo(Ambiente)
            destaj.idEmpresa = idEmpresa
            destaj.origen = origen

            Dim codigoEmpleado As String

            NConex.numCon = 0
            If NConex.estadoConn(0) Then

                NConex.Qry = "SELECT
                                e.etiqueta,
                                e.empleado,
                                p.fecha,
                                manoobra,
                                e.etapa,
                                e.burbujas,
                                e.foliopago
                              FROM pagoDestajo as p
                              inner join etiquetasprod as e
                              where p.id = e.foliopago
                              AND manoobra <> 0
                              AND e.empleado not in (" & omitirCodigo & ")
                              AND folioPago > '" & destaj.buscarUltimoID & "'
                              order by folioPago"

                If NConex.ejecutaConsulta Then
                    While NConex.reader.Read
                        codigoEmpleado = Trim(NConex.reader("empleado"))
                        relacion.referenciaExterna = codigoEmpleado

                        If relacion.buscarPREF() Then
                            empl = New Empleado(Ambiente)
                            empl.idEmpleado = relacion.idEmpleado
                            empl.buscarPID()

                            etap = New Etapa(Ambiente)
                            etap.codigoEtapa = NConex.reader("etapa")
                            etap.idEmpresa = idEmpresa
                            etap.buscarPCodigo()

                            destaj = New Destajo(Ambiente)
                            destaj.idEmpresa = idEmpresa
                            destaj.idEmpleado = empl.idEmpleado
                            destaj.idEtapa = etap.idEtapa
                            destaj.idSucursal = empl.idSucursal
                            destaj.esActivo = True
                            destaj.etiqueta = Trim(NConex.reader("etiqueta"))
                            destaj.fechaDestajo = NConex.reader("fecha")
                            destaj.esPagado = False
                            destaj.numBurbujasXMolde = 0
                            destaj.numBurbujasXEmpleado = If(IsDBNull(NConex.reader("burbujas")), Nothing, NConex.reader("burbujas"))
                            destaj.montoDestajo = NConex.reader("manoobra")
                            destaj.referenciaExterna = NConex.reader("foliopago")
                            destaj.numPuntos = 0
                            destaj.origen = origen

                            If Not destaj.guardar() Then
                                If destaj.idError <> -2146232060 Then
                                    idError = 10
                                    descripError &= " (" & destaj.referenciaExterna & ") NO SE GUARDO.!! >> " & destaj.descripError & vbCrLf
                                    Return False
                                End If
                            End If
                        Else
                            idError = 10
                            descripError &= " (" & NConex.reader("foliopago") & ") NO SE GUARDO.!! >> " & relacion.descripError & vbCrLf
                            Return False
                        End If
                    End While
                    NConex.reader.Close()
                End If
            Else
                idError = NConex.idError
                descripError &= "Origen.Sincronizar: " & NConex.descripError & vbCrLf
            End If
        Else
            idError = 1
            descripError = "No se encontro Conexion..."
        End If

        If idError = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        origen = rdr("origen")
        nombreBD = rdr("nombreBD")
        usuario = rdr("usuario")
        contrasena = rdr("contrasena")
        tipoBD = rdr("tipoBD")
        puerto = rdr("puerto")
        esquema = If(IsDBNull(rdr("esquema")), Nothing, rdr("esquema"))
        instancia = If(IsDBNull(rdr("instancia")), Nothing, rdr("instancia"))
        direccionIP = rdr("direccionIP")
        esActivo = rdr("esActivo")
        idEmpresa = rdr("idEmpresa")
        omitirCodigo = If(IsDBNull(rdr("omitirCodigo")), "'0'", rdr("omitirCodigo"))
        elemento = rdr("elemento")
    End Sub

    Public Function guardar() As Boolean Implements InterfaceTablas.guardar
        Return armaQry("INSERT", True)
    End Function

    Public Function actualizar() As Boolean Implements InterfaceTablas.actualizar
        Return armaQry("UPDATE", True)
    End Function

    Public Function eliminar() As Boolean Implements InterfaceTablas.eliminar
        Return armaQry("DELETE", True)
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.Qry = "SELECT * FROM Origen WHERE origen = '" & origen & "' AND idEmpresa = " & idEmpresa
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
            Mensaje.origen = "Origen.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
        If idEmpresa = Nothing Then
            idEmpresa = Ambiente.empr.idEmpresa
        End If

        If omitirCodigo = "'0'" Then
            omitirCodigo = Nothing
        End If

        Return True
    End Function

    Public Function getCreadoPor() As Empleado Implements InterfaceTablas.getCreadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getActualizadoPor() As Empleado Implements InterfaceTablas.getActualizadoPor
        Throw New NotImplementedException()
    End Function

    Public Function getEmpresa() As Empresa Implements InterfaceTablas.getEmpresa
        Throw New NotImplementedException()
    End Function

    Public Function getSucursal() As Sucursal Implements InterfaceTablas.getSucursal
        Throw New NotImplementedException()
    End Function

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "Origen"
            conex.accion = accion

            conex.agregaCampo("origen", origen, False, False)
            conex.agregaCampo("nombreBD", nombreBD, False, False)
            conex.agregaCampo("usuario", usuario, False, False)
            conex.agregaCampo("contrasena", contrasena, False, False)
            conex.agregaCampo("tipoBD", tipoBD, False, False)
            conex.agregaCampo("puerto", puerto, False, False)
            conex.agregaCampo("esquema", esquema, True, False)
            conex.agregaCampo("instancia", instancia, True, False)
            conex.agregaCampo("direccionIP", direccionIP, False, False)
            conex.agregaCampo("esActivo", esActivo, False, False)
            conex.agregaCampo("idEmpresa", idEmpresa, False, False)
            conex.agregaCampo("omitirCodigo", omitirCodigo, True, False)
            conex.agregaCampo("elemento", elemento, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE origen = '" & origen & "' AND idEmpresa=" & idEmpresa

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

End Class
