Imports System.Data.SqlClient
Imports Cerberus

Public Class ResultadoPeriodoES
    Implements InterfaceTablas

    Private conex As ConexionSQL
    Private Ambiente As AmbienteCls

    Public idError As Integer
    Public descripError As String

    Public idResultadoPeriodoES As Integer
    Public idPeriodo As Integer
    Public idHorario As Integer
    Public idEmpleado As Integer
    Public idDepartamento As Integer
    Public A As Integer
    Public BJL As Decimal
    Public CHET As Decimal
    Public CHR As Decimal
    Public D As Decimal
    Public DF As Integer
    Public D_PRDO As Integer
    Public F As Integer
    Public I As Integer
    Public PGS As Integer
    Public PSGS As Integer
    Public SSI As Decimal
    Public SSR As Decimal
    Public THL As Decimal
    Public VD As Integer
    Public TE As Decimal
    Public excedente As Decimal
    Public TFN As Decimal
    Public idRegistroPatronal As Integer

    Public Sub New(Ambiente As AmbienteCls)
        Me.Ambiente = Ambiente
        Me.conex = Ambiente.conex
    End Sub

    Public Sub seteaDatos(rdr As SqlDataReader) Implements InterfaceTablas.seteaDatos
        idResultadoPeriodoES = rdr("idResultadoPeriodoES")
        idPeriodo = rdr("idPeriodo")
        idHorario = rdr("idHorario")
        idEmpleado = rdr("idEmpleado")
        idDepartamento = rdr("idDepartamento")
        A = rdr("A")
        BJL = rdr("BJL")
        CHET = rdr("CHET")
        CHR = rdr("CHR")
        D = rdr("D")
        DF = rdr("DF")
        D_PRDO = rdr("D_PRDO")
        F = rdr("F")
        I = rdr("I")
        PGS = rdr("PGS")
        PSGS = rdr("PSGS")
        SSI = rdr("SSI")
        SSR = rdr("SSR")
        THL = rdr("THL")
        VD = rdr("VD")
        TE = rdr("TE")
        excedente = rdr("excedente")
        TFN = If(IsDBNull(rdr("TFN")), Nothing, rdr("TFN"))
        idRegistroPatronal = If(IsDBNull(rdr("idRegistroPatronal")), Nothing, rdr("idRegistroPatronal"))
    End Sub

    Private Function armaQry(accion As String, esInsert As Boolean) As Boolean Implements InterfaceTablas.armaQry
        If validaDatos(esInsert) Then
            conex.numCon = 0
            conex.tabla = "ResultadoPeriodoES"
            conex.accion = accion

            conex.agregaCampo("idPeriodo", idPeriodo, False, False)
            conex.agregaCampo("idHorario", idHorario, False, False)
            conex.agregaCampo("idEmpleado", idEmpleado, False, False)
            conex.agregaCampo("idDepartamento", idDepartamento, False, False)
            conex.agregaCampo("A", A, False, False)
            conex.agregaCampo("BJL", BJL, False, False)
            conex.agregaCampo("CHET", CHET, False, False)
            conex.agregaCampo("CHR", CHR, False, False)
            conex.agregaCampo("D", D, False, False)
            conex.agregaCampo("DF", DF, False, False)
            conex.agregaCampo("D_PRDO", D_PRDO, False, False)
            conex.agregaCampo("F", F, False, False)
            conex.agregaCampo("I", I, False, False)
            conex.agregaCampo("PGS", PGS, False, False)
            conex.agregaCampo("PSGS", PSGS, False, False)
            conex.agregaCampo("SSI", SSI, False, False)
            conex.agregaCampo("SSR", SSR, False, False)
            conex.agregaCampo("THL", THL, False, False)
            conex.agregaCampo("VD", VD, False, False)
            conex.agregaCampo("TE", TE, False, False)
            conex.agregaCampo("TFN", TFN, True, False)
            conex.agregaCampo("idRegistroPatronal", idRegistroPatronal, False, False)

            'SI ES INSERT NO SE CONCATENA, no importa ponerlo o no...
            conex.condicion = "WHERE idResultadoPeriodoES = " & idResultadoPeriodoES

            conex.armarQry()

            If conex.ejecutaQry Then
                If accion = "INSERT" Then
                    Return obtenerID()
                Else
                    Return True
                End If
            Else
                idError = conex.idError
                descripError = conex.descripError
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function obtenerID() As Boolean
        conex.numCon = 0
        conex.Qry = "SELECT @@IDENTITY as ID"
        If conex.ejecutaConsulta() Then
            If conex.reader.Read Then
                idResultadoPeriodoES = conex.reader("ID")
                conex.reader.Close()
                Return True
            Else
                idError = 1
                descripError = "No se pudo Obtener el ID"
                conex.reader.Close()
                Return False
            End If
        Else
            idError = conex.idError
            descripError = conex.descripError
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
        Throw New NotImplementedException()
    End Function

    Public Function buscarPID() As Boolean Implements InterfaceTablas.buscarPID
        conex.Qry = "SELECT * FROM ResultadoPeriodoES WHERE idResultadoPeriodoES = " & idResultadoPeriodoES
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
            Mensaje.origen = "ResultadoPeriodoES.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function buscarCalculo() As Boolean
        conex.Qry = "SELECT * FROM ResultadoPeriodoES WHERE idPeriodo= " & idPeriodo & " AND idEmpleado = " & idEmpleado
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
            Mensaje.origen = "ResultadoPeriodoES.buscarPID: "
            Mensaje.Mensaje = conex.descripError
            Mensaje.ShowDialog()
            Return False
        End If
    End Function

    Public Function getDetalleMod() As String Implements InterfaceTablas.getDetalleMod
        Throw New NotImplementedException()
    End Function

    Public Function validaDatos(nuevo As Boolean) As Boolean Implements InterfaceTablas.validaDatos
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
End Class
