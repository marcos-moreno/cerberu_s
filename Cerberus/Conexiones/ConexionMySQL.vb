Imports MySql.Data.MySqlClient

Public Class ConexionMySQL
    Public conn As New List(Of MySqlConnection)
    Public idError As Integer
    Public descripError As String

    Public reader As MySqlDataReader
    Public Qry As String

    'Arma Qry
    Public accion As String  'Es un INSERT, UPDATE, SELECT
    Public condicion As String 'WHERE
    Public tabla As String
    Private campos As New List(Of String)
    Private valores As New List(Of Object)
    Private esFuncionSQL As New List(Of Boolean)

    Public numCon As Integer
    Public estadoConn As New List(Of Boolean)

    Private connBuild As New MySqlConnectionStringBuilder
    Private archivoXML As String = ""

    Public Sub agregaCampo(campo As String, valor As Object, puedeSerNulo As Boolean, esFuncionSQL As Boolean) 'PARA INSERT, UPDATE
        Try
            If valor.GetType.Name = "Boolean" Then
                If Convert.ChangeType(valor, valor.GetType()) = True Then
                    valor = 1
                Else
                    valor = 0
                End If
            End If
        Catch ex As Exception

        End Try

        If puedeSerNulo Then
            Try
                If Not Convert.ChangeType(valor, valor.GetType()) = Nothing Then
                    Me.campos.Add(campo)
                    Me.valores.Add(valor)
                    Me.esFuncionSQL.Add(esFuncionSQL)
                Else
                    Me.campos.Add(campo)
                    Me.valores.Add("NULL")
                    Me.esFuncionSQL.Add(True)
                End If
            Catch ex As Exception

            End Try
        Else
            Me.campos.Add(campo)
            Me.valores.Add(valor)
            Me.esFuncionSQL.Add(esFuncionSQL)
        End If

    End Sub

    Public Sub agregaCampo(campo As String) ' PARA SELECT
        campos.Add(campo)
    End Sub

    Public Sub armarQry()
        'INSERT INTO tabla () VALUES ()
        'UPDATE tabla SET campo='valor', campoN='valorN'

        If UCase(Trim(accion)) = "INSERT" Then
            Qry = "INSERT INTO " & tabla & "("

            For i As Integer = 0 To campos.Count - 1
                Qry &= campos.Item(i) & ","
            Next

            Qry &= ") VALUES ("

            For i As Integer = 0 To valores.Count - 1
                If valores.Item(i).GetType.Name = "String" And Not esFuncionSQL.Item(i) Then
                    Qry &= "'" & valores.Item(i) & "',"
                Else
                    If valores.Item(i).GetType.Name = "Date" Then
                        Qry &= "CONVERT(date,'" & Format(valores.Item(i), "yyyy-MM-dd") & "',120),"
                    ElseIf valores.Item(i).GetType.Name = "DateTime" Then
                        Qry &= "CONVERT(datetime,'" & Format(valores.Item(i), "yyyy-MM-dd HH:mm:ss") & "',120),"
                    Else
                        Qry &= Convert.ChangeType(valores.Item(i), valores.Item(i).GetType()) & ","
                    End If
                End If
            Next
            Qry &= ")"

            Qry = Qry.Replace(",)", ")")
        ElseIf UCase(Trim(accion)) = "UPDATE" Then
            Qry = "UPDATE " & tabla & " SET "

            For i As Integer = 0 To valores.Count - 1
                If valores.Item(i).GetType.Name = "String" And Not esFuncionSQL.Item(i) Then
                    Qry &= campos.Item(i) & "='" & valores.Item(i) & "',"
                Else
                    If valores.Item(i).GetType.Name = "Date" Then
                        Qry &= campos.Item(i) & "=" & "'" & Format(valores.Item(i), "yyyy-MM-dd") & "',"
                    ElseIf valores.Item(i).GetType.Name = "DateTime" Then
                        Qry &= campos.Item(i) & "=" & "'" & Format(valores.Item(i), "yyyy-MM-dd HH:mm:ss") & "',"
                    Else
                        Qry &= campos.Item(i) & "=" & Convert.ChangeType(valores.Item(i), valores.Item(i).GetType()) & ","
                    End If
                End If
            Next

            Qry &= "--Final" & condicion

            Qry = Qry.Replace(",--Final", " ")
        ElseIf UCase(Trim(accion)) = "SELECT" Then
            Qry = "SELECT "

            For i As Integer = 0 To campos.Count - 1
                Qry &= campos.Item(i) & ","
            Next

            Qry &= "--Final"
            Qry = Qry.Replace(",--Final", " ")

            Qry &= "FROM " & tabla & " " & condicion
        ElseIf UCase(Trim(accion)) = "DELETE" Then
            Qry = "DELETE FROM " & tabla & " " & condicion
        End If

        campos.Clear()
        valores.Clear()
        esFuncionSQL.Clear()

    End Sub

    Public Sub New(servidor As String, db As String, user As String, pass As String, puerto As String, NConn As Integer)
        Me.archivoXML = archivoXML
        estadoConn.Clear()

        For i As Integer = 0 To NConn - 1
            conn.Add(New MySqlConnection)

            connBuild.Server = servidor
            connBuild.Database = db
            connBuild.UserID = user
            connBuild.Password = pass
            connBuild.Port = puerto

            If abreConn(conn(i), connBuild.ConnectionString) Then
                estadoConn.Add(True)
            Else
                estadoConn.Add(False)
            End If
        Next
    End Sub

    '***********
    Private Function abreConn(nConn As MySqlConnection, cadena As String) As Boolean
        idError = 0
        descripError = ""

        If nConn.State = ConnectionState.Closed Then
            Try
                nConn.ConnectionString = cadena
                nConn.Open()
            Catch e As Exception
                idError = e.HResult
                descripError = e.Message
                Return False
            End Try
        End If
        Return True
    End Function

    Public Sub cerrarTodo()
        For i As Integer = 0 To conn.Count - 1
            cerrarConexiones(conn(i))
        Next
    End Sub


    Private Sub cerrarConexiones(nConn As MySqlConnection)
        If nConn.State = ConnectionState.Open Then
            nConn.Close()
        End If
    End Sub

    Public Function ejecutaConsulta() As Boolean
        idError = 0
        descripError = ""

        Dim reader As MySqlDataReader = Nothing

        Try
            Dim command As New MySqlCommand(Qry, conn(numCon))
            reader = command.ExecuteReader()
            Me.reader = reader
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function

    Public Function ejecutaQry(Datos As Byte()) As Boolean 'Requiere el parametroByte
        idError = 0
        descripError = ""

        Try
            Dim command As New MySqlCommand()
            command.CommandText = Qry
            command.Connection = conn(numCon)
            'command.Parameters.Add("@Datos", Datos)
            command.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function


    Public Function ejecutaConsultaDS(soloLect As Boolean) As DataSet
        idError = 0
        descripError = ""

        Dim dataadapter As MySqlDataAdapter = Nothing
        Dim ds As DataSet = Nothing

        Try
            dataadapter = New MySqlDataAdapter(Qry, conn(numCon))
            ds = New DataSet()
            dataadapter.Fill(ds, "dataTable")

            If soloLect Then
                For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
                    ds.Tables(0).Columns(i).ReadOnly = True
                Next
            End If

        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
        End Try

        Return ds
    End Function

    Function ejecutaQry() As Boolean
        idError = 0
        descripError = ""

        Try
            Dim myCommand As New MySqlCommand(Qry)

            myCommand.Connection = conn(numCon)
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    <Obsolete>
    Public Function ejecutaSP(parametros As Object(,)) As Boolean
        idError = 0
        descripError = ""
        Try
            Dim cmd = New MySqlCommand()
            cmd.CommandText = Qry
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn(numCon)

            For x As Integer = 0 To parametros.GetLength(0) - 2
                cmd.Parameters.Add(parametros(x, 0).ToString(), parametros(x, 1))
            Next

            reader = cmd.ExecuteReader()
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try

        Return True
    End Function

    Public Function ejecutaSP() As Boolean
        idError = 0
        descripError = ""
        Try
            Dim cmd As MySqlCommand = New MySqlCommand()
            cmd.CommandText = Qry
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn(numCon)
            reader = cmd.ExecuteReader()
            Return True
        Catch ex As Exception
            idError = ex.HResult
            descripError = ex.Message
            Return False
        End Try
    End Function
End Class
