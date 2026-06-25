<%@page import="java.util.List"%>
<%@page import="modelo.Pokemon"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    List<Pokemon> lista = (List<Pokemon>) request.getAttribute("listaAleatoria");
%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Resultado Aleatorio</title>
</head>
<body>
    <h2>10 Pokémon aleatorios</h2>

    <table border="1">
        <tr>
            <th>Nombre</th>
            <th>Región</th>
            <th>Imagen</th>
        </tr>

        <%
            if (lista != null) {
                for (Pokemon p : lista) {
        %>
        <tr>
            <td><%= p.getNombre() %></td>
            <td><%= p.getRegion() %></td>
            <td>
                <% if (p.getImagen() != null && !p.getImagen().isEmpty()) { %>
                    <img src="<%= p.getImagen() %>" width="80" alt="pokemon">
                <% } else { %>
                    Sin imagen
                <% } %>
            </td>
        </tr>
        <%
                }
            }
        %>
    </table>

    <br>
    <a href="aleatorio.jsp">Volver</a>
    <br>
    <a href="menu.jsp">Volver al menú</a>
</body>
</html>