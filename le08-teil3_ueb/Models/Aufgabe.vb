Imports System.ComponentModel.DataAnnotations

Public Class Aufgabe

    Private mintId As Integer
    Private mstrTitel As String
    Private mstrBeschreibung As String
    Private mdatFaellig As Date
    Private mbolErledigt As Boolean
    Private mKategorie As Kategorie

    Public Sub New()
        mintId = -1
        mstrTitel = String.Empty
        mstrBeschreibung = String.Empty
        mdatFaellig = Date.MaxValue
        mbolErledigt = False
    End Sub

    Public Sub New(pintId As Integer, pstrTitel As String, pstrBeschreibung As String,
                pdatFaellig As Date, pbolErledigt As Boolean)

        mintId = pintId
        mstrTitel = pstrTitel
        mstrBeschreibung = pstrBeschreibung
        mdatFaellig = pdatFaellig
        mbolErledigt = pbolErledigt

    End Sub

    Public Property Kategorie() As Kategorie
        Get
            Return mKategorie
        End Get
        Set(value As Kategorie)
            mKategorie = value
        End Set
    End Property

    Public Property Erledigt() As Boolean
        Get
            Return mbolErledigt
        End Get
        Set(ByVal value As Boolean)
            mbolErledigt = value
        End Set
    End Property

    Public Property Faellig() As Date
        Get
            Return mdatFaellig
        End Get
        Set(ByVal value As Date)
            mdatFaellig = value
        End Set
    End Property

    Public Property Beschreibung() As String
        Get
            Return mstrBeschreibung
        End Get
        Set(ByVal value As String)
            mstrBeschreibung = value
        End Set
    End Property

    <Required(ErrorMessage:="Titel ist eine Pflichtangabe")>
    Public Property Titel() As String
        Get
            Return mstrTitel
        End Get
        Set(ByVal value As String)
            mstrTitel = value
        End Set
    End Property

    Public Property Id() As Integer
        Get
            Return mintId
        End Get
        Set(ByVal value As Integer)
            mintId = value
        End Set
    End Property


End Class
