Imports System.IO

' NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config and in the associated .svc file.
Public Class Service
    Implements IService
    Private obj As New ImageProcesser()

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService.GetData
        Return String.Format("testing stage sucesses: {0}", value)
    End Function

    Public Function getrestName(ByVal ValueType As String) As String Implements IService.getrestName
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter(AppDomain.CurrentDomain.BaseDirectory + "resources\text.txt", True)
        'file.WriteLine("Here is the first string.")
        'file.Close()


        'Dim fileReader As String
        ' fileReader = My.Computer.FileSystem.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "resources\text.txt", System.Text.Encoding.UTF32)
        'fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\gadperera\Documents\resources\text.txt", System.Text.Encoding.UTF32)


        obj.setImageBase64(ValueType)
        Return obj.getvalue()
        'Return fileReader
    End Function

End Class
