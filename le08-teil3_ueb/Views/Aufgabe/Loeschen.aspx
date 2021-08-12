<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of le08_teil3_ueb.AufgabeViewModel)" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Aufgabe "<%=Model.Aufgabe.Titel%>" löschen</title>
</head>
<body>
    <div>
        <h1>Aufgabe "<%=Model.Aufgabe.Titel%>" löschen</h1>
        <p>Möchten Sie die Aufgabe "<%=Model.Aufgabe.Titel%>" wirklich löschen?</p>

        <%Using Html.BeginForm()%>

            <p>
                <%=Html.HiddenFor(Function(m) Model.Aufgabe.Id) %>
            </p>
            <p><%=Html.ActionLink("Abbrechen", "Index")%> <input type="submit" value="Löschen"/></p>
        <%End Using%>
        
    </div>
</body>
</html>
