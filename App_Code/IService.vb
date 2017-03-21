Imports System.ServiceModel.Web

' NOTE: If you change the interface name "IService" here, you must also update the reference to "IService" in Web.config.
<ServiceContract()> _
Public Interface IService

    <OperationContract()> _
    Function GetData(ByVal value As Integer) As String


    <OperationContract()> _
    <WebInvoke(Method:="POST", UriTemplate:="FormPicString64", RequestFormat:=WebMessageFormat.Json, ResponseFormat:=WebMessageFormat.Json, BodyStyle:=WebMessageBodyStyle.Wrapped)> _
    Function getrestName(ByVal ValueType As String) As String


End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.
<DataContract()> _
Public Class CompositeType

    Private boolValueField As Boolean
    Private stringValueField As String

    <DataMember()> _
    Public Property BoolValue() As Boolean
        Get
            Return Me.boolValueField
        End Get
        Set(ByVal value As Boolean)
            Me.boolValueField = value
        End Set
    End Property

    <DataMember()> _
    Public Property StringValue() As String
        Get
            Return Me.stringValueField
        End Get
        Set(ByVal value As String)
            Me.stringValueField = value
        End Set
    End Property

End Class
