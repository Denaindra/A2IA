Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class AsciiConvertion
    Private builder As New StringBuilder
    Private fullname As String
    Private charaters As New List(Of Char)
    Dim va As Char

    Public Function convertToAscii(ByVal charvalue As Integer)
        va = Chr(charvalue)
        charaters.Add(Chr(charvalue))
    End Function

    Public Function cleanList()
        charaters.Clear()
        builder.Length = 0
    End Function

    Public Function readString() As String
        For Each fern As String In charaters
            builder.Append(fern)
        Next
        fullname = builder.ToString()
        Return fullname
    End Function

End Class
