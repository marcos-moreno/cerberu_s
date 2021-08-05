Public Class frmNuevoEstado
    Dim edoDocs As New EstadoDocumentos
    Public Function getEstadoDB() As String
        Select Case cbEstado.SelectedIndex
            Case -1
                Return Nothing
            Case 0
                Return "BO"
            Case 1
                Return "CO"
            Case Else
                Return Nothing
        End Select

    End Function

    Public Sub setEstadoBD(estado As String)
        cbEstado.SelectedItem = edoDocs.getNombreEstado(estado)
    End Sub
End Class