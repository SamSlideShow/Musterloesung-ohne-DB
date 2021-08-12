<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of le08_teil3_ueb.AufgabenListe)" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Alle Aufgaben</title>
</head>
<body>
    <div>
        <%="" %>
        <h1>Aufgabenübersicht</h1>
        <p>Hier sehen Sie alle Aufgaben in einer Übersicht.</p>

        <table>
            <tr>
                <th>ID</th>
                <th>Titel</th>
                <th>Fällig</th>
                <th>Erledigt</th>
                <th>Aktion</th>
            </tr>

            <%For Each auf In Model.Aufgaben%>
            <tr>
                <td><%=auf.Id%></td>
                <td><%=auf.Titel%></td>
                <td><%=auf.Faellig%></td>
                <td><%=auf.Erledigt%></td>
                <td>
                    <%=Html.ActionLink("Bearbeiten", "Bearbeiten", New With{.ID=auf.Id}) %>
                    <%=Html.ActionLink("Löschen", "Loeschen", New With {.ID = auf.Id})%>
                </td>
            </tr>
            <%Next %>
       </table>
        <%=Html.ActionLink("Hinzufügen", "Hinzufuegen") %>
    </div>
</body>
</html>
