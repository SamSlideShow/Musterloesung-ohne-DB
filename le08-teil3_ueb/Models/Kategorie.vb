Public Class Kategorie

    Private mintId As Integer
    Private mstrBezeichnung As String

    Public Sub New()
        mstrBezeichnung = String.Empty
    End Sub

    Public Sub New(pintId As Integer, pstrBezeichnung As String)
        mintId = pintId
        mstrBezeichnung = pstrBezeichnung
    End Sub

    Public Property Id() As Integer
        Get
            Return mintId
        End Get
        Set(value As Integer)
            mintId = value
        End Set
    End Property


    Public Property Bezeichnung() As String
        Get
            Return mstrBezeichnung
        End Get
        Set(ByVal value As String)
            mstrBezeichnung = value
        End Set
    End Property

End Class
