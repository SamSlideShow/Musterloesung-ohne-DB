Public Class AufgabeViewModel

    Private mAufgabe As Aufgabe
    Private mKategorienAlle As List(Of Kategorie)


    Public Property KategorienAlle() As List(Of Kategorie)
        Get
            Return mKategorienAlle
        End Get
        Set(ByVal value As List(Of Kategorie))
            mKategorienAlle = value
        End Set
    End Property

    Public Property Aufgabe() As Aufgabe
        Get
            Return mAufgabe
        End Get
        Set(ByVal value As Aufgabe)
            mAufgabe = value
        End Set
    End Property


End Class
