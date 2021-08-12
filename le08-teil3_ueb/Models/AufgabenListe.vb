Public Class AufgabenListe

    Private mlstAufgaben As List(Of Aufgabe)

    Public Sub New()
        mlstAufgaben = New List(Of Aufgabe)
    End Sub

    Public Sub New(plstAufgaben As List(Of Aufgabe))
        mlstAufgaben = plstAufgaben
    End Sub


    Public Property Aufgaben As List(Of Aufgabe)
        Get
            Return mlstAufgaben
        End Get
        Set(value As List(Of Aufgabe))
            mlstAufgaben = value
        End Set
    End Property

End Class
