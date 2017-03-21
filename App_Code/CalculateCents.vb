Imports Microsoft.VisualBasic

Public Class CalculateCents
    Private totalCharaters As Integer

    Public Function convertToAscii(ByVal charvalue As Integer) As Double
        totalCharaters = charvalue.ToString().Length
        Dim modified As String = (charvalue.ToString()).Insert(totalCharaters - 2, ".")

        Return modified

    End Function
End Class
