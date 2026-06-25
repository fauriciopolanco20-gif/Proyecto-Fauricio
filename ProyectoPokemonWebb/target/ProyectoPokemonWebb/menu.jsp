<%@page import="modelo.Usuario"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<%
    Usuario u = (Usuario) session.getAttribute("usuarioLogueado");
    if (u == null) {
        response.sendRedirect("login.jsp");
        return;
    }
%>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Menú Principal</title>

    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        body {
            min-height: 100vh;
            background: linear-gradient(135deg, #0f172a, #1e3a8a, #2563eb);
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .contenedor {
            width: 100%;
            max-width: 700px;
            background: rgba(255, 255, 255, 0.12);
            backdrop-filter: blur(12px);
            border-radius: 20px;
            padding: 40px;
            box-shadow: 0 10px 35px rgba(0, 0, 0, 0.35);
            color: white;
            text-align: center;
        }

        .titulo {
            margin-bottom: 25px;
        }

        .titulo h1 {
            color: #ffde59;
            margin-bottom: 10px;
        }

        .titulo p {
            font-size: 14px;
            color: #e5e7eb;
        }

        .rol {
            margin-bottom: 25px;
            font-size: 13px;
            color: #cbd5f5;
        }

        .botones {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 15px;
        }

        .botones a {
            text-decoration: none;
        }

        .btn {
            padding: 15px;
            border-radius: 12px;
            border: none;
            font-weight: bold;
            cursor: pointer;
            font-size: 14px;
            transition: 0.3s;
        }

        .btn:hover {
            transform: translateY(-2px);
        }

        .consulta {
            background: #22c55e;
            color: white;
        }

        .historico {
            background: #3b82f6;
            color: white;
        }

        .aleatorio {
            background: #f97316;
            color: white;
        }

        .salir {
            background: #ef4444;
            color: white;
            grid-column: span 2;
        }
    </style>
</head>

<body>

<div class="contenedor">

    <div class="titulo">
        <h1>Bienvenido, <%= u.getNombre() %> 👋</h1>
        <p>Sistema de consulta de Pokémon</p>
    </div>

    <div class="rol">
        Usuario: <%= u.getUsuario() %> | Rol: <%= u.getRol() %>
    </div>

    <div class="botones">
        <a href="consultaPokemon.jsp">
            <button class="btn consulta">Consultar Pokémon</button>
        </a>

        <a href="HistoricoServlet">
            <button class="btn historico">Histórico</button>
        </a>

        <a href="aleatorio.jsp">
            <button class="btn aleatorio">Consulta Aleatoria</button>
        </a>

        <a href="LogoutServlet">
            <button class="btn salir">Cerrar Sesión</button>
        </a>
    </div>

</div>

</body>
</html>