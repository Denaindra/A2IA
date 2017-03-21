Imports Microsoft.VisualBasic

Public Class IniClass
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, _
      ByVal lpKeyName As String, _
      ByVal lpDefault As String, _
      ByVal lpReturnedString As StringBuilder, _
      ByVal nSize As Integer, _
      ByVal lpFileName As String) As Integer

    Public Function getparam() As String
        Dim res As Integer
        Dim name1 As String
        Dim name2 As String
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        res = GetPrivateProfileString("A2iA_param", "Path", "", sb, sb.Capacity, "C:\Users\gadperera\Desktop\test.ini")
        Return sb.ToString()
    End Function

    Public Function getTbl() As String
        Dim res As Integer
        Dim name1 As String
        Dim name2 As String
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        res = GetPrivateProfileString("A2iA_tbl", "Path", "", sb, sb.Capacity, "C:\Users\gadperera\Desktop\test.ini")
        Return sb.ToString()
    End Function

    Public Function getimagePath() As String
        Dim res As Integer
        Dim name1 As String
        Dim name2 As String
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        res = GetPrivateProfileString("A2iA_imagePath", "Path", "", sb, sb.Capacity, "C:\Users\gadperera\Desktop\test.ini")
        Return sb.ToString()
    End Function
End Class
