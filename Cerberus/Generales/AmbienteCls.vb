Public Class AmbienteCls
    Public conex As ConexionSQL
    Public usuario As Empleado
    Public empr As Empresa
    Public suc As Sucursal
    Public accesoBotones As AccesoEmpleado

    Public idsDepartamentos As String
    Public util As Utilerias
    Public fechaServidor As DateTime

    Public estacion As String

    Public Sub New(conex As ConexionSQL)
        Me.conex = conex

        conex.numCon = 0
        conex.Qry = "SET LANGUAGE Español;"
        conex.ejecutaQry()

        util = New Utilerias

        conex.Qry = "SELECT CURRENT_TIMESTAMP as hoy"
        If conex.ejecutaConsulta Then
            If conex.reader.Read Then
                fechaServidor = conex.reader("hoy")
            End If
            conex.reader.Close()
        End If
    End Sub

    Public Sub respaldarBB()
        Dim ruta As String
        ruta = "C:\KAIROS\" & Microsoft.VisualBasic.Strings.Format(Now, "yyyyMMdd-HHmmss") & "-" & conex.conexBuild(0).InitialCatalog & ".bak"

        Mensaje.tipoMsj = TipoMensaje.Informacion

        conex.Qry = "BACKUP DATABASE " & conex.conexBuild(0).InitialCatalog & " TO DISK = '" & ruta & "'"
        If conex.ejecutaQry Then
            Mensaje.Mensaje = "Respaldo generado correctamente en la ruta: " & ruta
        Else
            Mensaje.Mensaje = conex.descripError
        End If

        Mensaje.ShowDialog()
    End Sub
End Class
