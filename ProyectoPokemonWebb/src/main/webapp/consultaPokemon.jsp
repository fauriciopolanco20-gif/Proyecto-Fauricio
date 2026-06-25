<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Consultar Pokémon</title>

    <style>
        body {
            min-height: 100vh;
            background: linear-gradient(135deg, #0f172a, #1e3a8a, #2563eb);
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: Arial, sans-serif;
            margin: 0;
        }

        .contenedor {
            width: 100%;
            max-width: 600px;
            background: rgba(255,255,255,0.12);
            padding: 30px;
            border-radius: 15px;
            text-align: center;
            color: white;
            box-shadow: 0 10px 35px rgba(0,0,0,0.35);
        }

        h2 {
            color: #ffde59;
            margin-bottom: 20px;
        }

        input {
            width: 90%;
            padding: 12px;
            margin: 10px 0;
            border-radius: 8px;
            border: none;
        }

        button {
            padding: 10px 20px;
            border-radius: 8px;
            border: none;
            background: #ffde59;
            font-weight: bold;
            cursor: pointer;
        }

        button:hover {
            background: #ffd000;
        }

        a {
            color: #ffde59;
            text-decoration: none;
        }

        a:hover {
            text-decoration: underline;
        }

        .error {
            color: #fecaca;
            margin-top: 10px;
        }
    </style>
</head>

<body>
    <div class="contenedor">
        <h2>Consultar Pokémon</h2>

        <form action="PokemonServlet" method="post">
            <input type="text" name="nombrePokemon" placeholder="Ej: pikachu" required>
            <br><br>
            <button type="submit">Buscar</button>
        </form>

        <p class="error">${error}</p>

        <br>
        <a href="menu.jsp">Volver al menú</a>
    </div>
</body>
</html>