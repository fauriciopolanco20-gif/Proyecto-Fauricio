<%@page import="java.util.List"%>
<%@page import="modelo.Historial"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<%
    List<Historial> lista = (List<Historial>) request.getAttribute("listaHistorial");
%>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Histórico</title>
</head>
<body>
    <h2>Histórico de consultas</h2>

    <table border="1">
        <tr>
            <th>Usuario</th>
            <th>Fecha</th>
            <th>Hora</th>
            <th>Nombre</th>
            <th>Tamaño</th>
            <th>Tipo</th>
            <th>Región</th>
            <th>Imagen</th>
        </tr>

        <%
            if (lista != null) {
                for (Historial h : lista) {
        %>
        <tr>
            <td><%= h.getUsuario() %></td>
            <td><%= h.getFecha() %></td>
            <td><%= h.getHora() %></td>
            <td><%= h.getNombrePokemon() %></td>
            <td><%= h.getTamano() %></td>
            <td><%= h.getTipo() %></td>
            <td><%= h.getRegion() %></td>
            <td><img src="<%= h.getImagen() %>" width="80"></td>
        </tr>
        <%
                }
            }
        %>
    </table>

    <br>
    <a href="menu.jsp">Volver</a>
</body>
</html>