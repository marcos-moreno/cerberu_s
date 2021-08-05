Public Class EstadoDocumentos
    Public Function getNombreEstado(estado As String) As String
        Dim estadoR As String

        Select Case estado
            Case "BO"
                estadoR = "BORRADOR"
            Case "PA"
                estadoR = "PENDIENTE DE AUTORIZAR"
            Case "CO"
                estadoR = "COMPLETO"
            Case "CA"
                estadoR = "CANCELADO"
            Case "PR"
                estadoR = "PROCESADO"
            Case "CB"
                estadoR = "COBRADO"
            Case "SC"
                estadoR = "SIN COBRO"
            Case "NC"
                estadoR = "NO COBRADO"
            Case Else
                estadoR = "NUEVO"
        End Select

        Return estadoR
    End Function
    Public Function getColor(estado As String) As Color

        Select Case estado
            Case "BO"
                Return Color.Aquamarine
            Case "PA"
                Return Color.LightYellow
            Case "CO"
                Return Color.GreenYellow
            Case "CA"
                Return Color.LightSalmon
            Case "PR"
                Return Color.LightSkyBlue
            Case "CB"
                Return Color.LightGreen
            Case "SC"
                Return Color.LightGreen
            Case "NC"
                Return Color.LightCoral
            Case Else
                Return Color.Aquamarine
        End Select


    End Function

    Public Function getContaccion(estado As String) As String
        Dim estadoC As String

        Select Case estado
            Case "BORRADOR"
                estadoC = "BO"
            Case "PENDIENTE DE AUTORIZAR"
                estadoC = "PA"
            Case "COMPLETO"
                estadoC = "CO"
            Case "CANCELADO"
                estadoC = "CA"
            Case Else
                estadoC = ""
        End Select
        Return estadoC
    End Function
End Class
