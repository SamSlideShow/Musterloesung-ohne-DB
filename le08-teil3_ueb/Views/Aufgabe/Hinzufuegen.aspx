<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of le08_teil3_ueb.AufgabeViewModel)" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Neue Aufgabe</title>
</head>
<body>
    <div>
        <h1>Neue Aufgabe hinzufügen</h1>
        <p>Sie können eine neue Aufgabe hinzfügen.</p>

        <%Using Html.BeginForm()%>

            <p>
                <%=Html.HiddenFor(Function(m) Model.Aufgabe.Id) %>
            </p>
            <p>
                <%=Html.LabelFor(Function(m) Model.Aufgabe.Titel) %>
                <%=Html.TextBoxFor(Function(m) Model.Aufgabe.Titel) %>
                <%=Html.ValidationMessageFor(Function(m) Model.Aufgabe.Titel)  %>
            </p>
            <p>
                <%=Html.LabelFor(Function(m) Model.Aufgabe.Beschreibung)%>
                <%=Html.TextAreaFor(Function(m) Model.Aufgabe.Beschreibung)%>
                <%=Html.ValidationMessageFor(Function(m) Model.Aufgabe.Beschreibung)  %>
            </p>
            <p>
                <%=Html.LabelFor(Function(m) Model.Aufgabe.Faellig)%>
                <%=Html.TextBoxFor(Function(m) Model.Aufgabe.Faellig, "{0:dd.MM.yyyy}")%>
                <%=Html.ValidationMessageFor(Function(m) Model.Aufgabe.Faellig)  %>
            </p>
            <p>
                <%=Html.LabelFor(Function(m) Model.Aufgabe.Erledigt)%>
                <%=Html.CheckBoxFor(Function(m) Model.Aufgabe.Erledigt)%>
                <%=Html.ValidationMessageFor(Function(m) Model.Aufgabe.Erledigt)  %>
            </p>
            <p>
                <%=Html.LabelFor(Function(m) Model.Aufgabe.Kategorie.Bezeichnung)%>
                <%=Html.DropDownListFor(Function(m) Model.Aufgabe.Kategorie.Id, New SelectList(Model.KategorienAlle, "ID", "Bezeichnung"))%>
                <%=Html.ValidationMessageFor(Function(m) Model.Aufgabe.Kategorie.Bezeichnung )  %>
            </p>

            <p><%=Html.ActionLink("Abbrechen", "Index")%> <input type="submit" value="Speichern"/></p>
        <%End Using%>
        
    </div>
</body>
</html>
