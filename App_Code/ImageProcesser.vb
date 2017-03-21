Imports Microsoft.VisualBasic
'Option Strict Off
'Option Explicit On

Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text


Public Class ImageProcesser
    Private totalCharaters As Integer
    Private AsciiCharaters As Integer
    Private InstallDir As String
    Private XCR As New A2iAFieldReaderLib.API
    'Private path As New IniClass()
    Private tmpLmage As System.Web.UI.WebControls.Image



    Public Function getvalue() As String

        Dim DocsId As String
        Dim obj = New CalculateCents()


        XCR.ScrInit(AppDomain.CurrentDomain.BaseDirectory + "resources\Parms")
        Dim ChannelId As Integer
        Dim FullAmount As String
        Dim ascii = New AsciiConvertion()

        ChannelId = XCR.ScrOpenChannel()
        Dim TableId As Integer
        TableId = XCR.ScrOpenDocumentTable(AppDomain.CurrentDomain.BaseDirectory + "resources\tbl\AmountSnippets.tbl")
        'TableId = XCR.ScrOpenDocumentTable("C:\Users\gadperera\Desktop\testTBL\testform\CFtestNtb\testNtb.tbl")
        Dim DocId As Integer
        DocId = XCR.ScrGetDefaultDocument(TableId)

        XCR.ScrDefineImage(DocId, "JPEG", "FILE", AppDomain.CurrentDomain.BaseDirectory + "resources\temImage\amount.jpg")
        'XCR.ScrDefineImage(DocId, "JPEG", "FILE", "C:\Users\gadperera\Pictures\Microsoft Clip Organizer\template2.jpg")

        Dim ReqId As Integer
        ReqId = XCR.ScrOpenRequest(ChannelId, DocId)
        Dim ResultId As Integer
        ResultId = XCR.ScrGetResult(ChannelId, ReqId, 10000)
        Dim sz As String
        sz = XCR.ObjectProperty(ResultId, "input.documentType")
        'ascii.cleanList()
        If (sz <> "SingleField") Then
            MsgBox("Wrong Document Type, shoud be Single Field")
        Else
            totalCharaters = XCR.ObjectProperty(ResultId, "documentTypeInfo.CaseSingleField.field.fieldTypeInfo.CaseAmount.result.amount")
        End If
        XCR.ScrCloseRequest((ReqId))
        XCR.ScrCloseDocument((DocId))
        XCR.ScrCloseDocumentTable((TableId))
        XCR.ScrCloseChannel((ChannelId))


        Return obj.convertToAscii(totalCharaters)
    End Function


    Public Function setImageBase64(ByVal filestring As String) As String
        Dim imageBytes As Byte() = Convert.FromBase64String(filestring)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
        Dim tmpLmage As Bitmap = Image.FromStream(ms, True)
        tmpLmage.Save(AppDomain.CurrentDomain.BaseDirectory + "resources\temImage\amount.jpg", ImageFormat.Jpeg)
        Return ""
    End Function
End Class
