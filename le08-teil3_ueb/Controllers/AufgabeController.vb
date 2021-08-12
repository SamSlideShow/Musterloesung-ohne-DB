Public Class AufgabeController
    Inherits System.Web.Mvc.Controller

    ' Beispieldaten als Liste (solange wir noch keine Datenbank haben)
    Private Shared mlstAufgaben As List(Of Aufgabe)
    Private Shared mlstKategorien As List(Of Kategorie)

    Public Sub New()
        MyBase.New()

        If mlstAufgaben Is Nothing Then
            erzeugeBeispieldaten()
        End If
    End Sub

    '
    ' GET: /Aufgabe
    <HttpGet>
    Function Index() As ActionResult

        Dim vmAufgabenListe As AufgabenListe


        vmAufgabenListe = New AufgabenListe(mlstAufgaben)

        Return View(vmAufgabenListe)
    End Function

    <HttpGet>
    Function Bearbeiten(ID As Integer) As ActionResult

        Dim auf As Aufgabe
        Dim vmAuf As AufgabeViewModel

        auf = mlstAufgaben.Find(Function(m) m.Id = ID)

        If auf Is Nothing Then
            Return New HttpNotFoundResult("Aufgabe mit ID='" & ID & "' nicht gefunden")
        End If

        vmAuf = New AufgabeViewModel
        vmAuf.Aufgabe = auf
        vmAuf.KategorienAlle = mlstKategorien

        Return View(vmAuf)

    End Function

    <HttpPost>
    Function Bearbeiten(pvmAuf As AufgabeViewModel)

        Dim auf As Aufgabe
        Dim katAusgew As Kategorie
        Dim intAufId As Integer
        Dim intKatId As Integer

        If Not ModelState.IsValid Then
            pvmAuf.KategorienAlle = mlstKategorien
            Return View(pvmAuf)
        End If

        intAufId = pvmAuf.Aufgabe.Id
        intKatId = pvmAuf.Aufgabe.Kategorie.Id

        auf = mlstAufgaben.Find(Function(a) a.Id = intAufId)

        auf.Titel = pvmAuf.Aufgabe.Titel
        auf.Beschreibung = pvmAuf.Aufgabe.Beschreibung
        auf.Faellig = pvmAuf.Aufgabe.Faellig
        auf.Erledigt = pvmAuf.Aufgabe.Erledigt

        katAusgew = mlstKategorien.Find(Function(k) k.Id = intKatId)
        auf.Kategorie = katAusgew

        Return RedirectToAction("Index")
    End Function

    <HttpGet>
    Function Loeschen(ID As Integer) As ActionResult

        Dim auf As Aufgabe
        Dim vmAuf As AufgabeViewModel

        auf = mlstAufgaben.Find(Function(m) m.Id = ID)

        If auf Is Nothing Then
            Return New HttpNotFoundResult("Aufgabe mit ID='" & ID & "' nicht gefunden")
        End If

        vmAuf = New AufgabeViewModel
        vmAuf.Aufgabe = auf
        vmAuf.KategorienAlle = mlstKategorien

        Return View(vmAuf)

    End Function

    <HttpPost>
    <ActionName("Loeschen")>
    Function LoeschenBestaetigt(ID As Integer)

        Dim auf As Aufgabe

        auf = mlstAufgaben.Find(Function(m) m.Id = ID)

        If auf Is Nothing Then
            Return New HttpNotFoundResult("Aufgabe mit ID='" & ID & "' nicht gefunden")
        End If

        mlstAufgaben.Remove(auf)

        Return RedirectToAction("Index")
    End Function

    <HttpGet>
    Function Hinzufuegen() As ActionResult

        Dim auf As Aufgabe
        Dim vmAuf As AufgabeViewModel

        auf = New Aufgabe()

        vmAuf = New AufgabeViewModel
        vmAuf.Aufgabe = auf
        vmAuf.KategorienAlle = mlstKategorien

        Return View(vmAuf)

    End Function

    <HttpPost>
    Function Hinzufuegen(pvmAuf As AufgabeViewModel)

        Dim aufNeu As Aufgabe
        Dim katAusgew As Kategorie
        Dim intAufId As Integer
        Dim intKatId As Integer

        intAufId = pvmAuf.Aufgabe.Id
        intKatId = pvmAuf.Aufgabe.Kategorie.Id

        aufNeu = New Aufgabe()

        aufNeu.Id = gibNaechsteAufgabenId()
        aufNeu.Titel = pvmAuf.Aufgabe.Titel
        aufNeu.Beschreibung = pvmAuf.Aufgabe.Beschreibung
        aufNeu.Faellig = pvmAuf.Aufgabe.Faellig
        aufNeu.Erledigt = pvmAuf.Aufgabe.Erledigt

        katAusgew = mlstKategorien.Find(Function(k) k.Id = intKatId)
        aufNeu.Kategorie = katAusgew

        mlstAufgaben.Add(aufNeu)

        Return RedirectToAction("Index")
    End Function

    Private Shared Function gibNaechsteAufgabenId() As Integer
        Dim intAufId As Integer

        ' Nächste freie ID finden
        For Each auf In mlstAufgaben
            If auf.Id > intAufId Then
                intAufId = auf.Id
            End If
        Next
        intAufId = intAufId + 1

        Return intAufId
    End Function

    Private Shared Sub erzeugeBeispieldaten()
        Dim katPrivat, katUni, katFreizeit As Kategorie
        Dim aufMilch, aufAuto, aufLernen, aufUrlaub As Aufgabe

        katPrivat = New Kategorie(1, "Privat")
        katUni = New Kategorie(2, "Studium")
        katFreizeit = New Kategorie(3, "Freizeit")

        mlstKategorien = New List(Of Kategorie)
        mlstKategorien.Add(katPrivat)
        mlstKategorien.Add(katUni)
        mlstKategorien.Add(katFreizeit)

        aufMilch = New Aufgabe(1, "Milch kaufen", "12 Pakete, 3,5%", #5/28/2018#, False)
        aufAuto = New Aufgabe(2, "Auto waschen", "inkl. Unterbodenwäsche und Wachspflege", #6/1/2018#, False)
        aufLernen = New Aufgabe(3, "Für Klausuren lernen", "Mathe und Info", #6/21/2018#, False)
        aufUrlaub = New Aufgabe(4, "Flug nach Barcelona", "easyjet für 35 EUR", #7/13/2018#, True)

        aufMilch.Kategorie = katPrivat
        aufAuto.Kategorie = katPrivat
        aufLernen.Kategorie = katUni
        aufUrlaub.Kategorie = katFreizeit

        mlstAufgaben = New List(Of Aufgabe)
        mlstAufgaben.Add(aufMilch)
        mlstAufgaben.Add(aufAuto)
        mlstAufgaben.Add(aufLernen)
        mlstAufgaben.Add(aufUrlaub)

    End Sub

End Class