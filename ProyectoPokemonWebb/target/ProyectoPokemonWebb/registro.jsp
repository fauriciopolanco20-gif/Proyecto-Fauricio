<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Registro - Pokémon Web</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        body {
            min-height: 100vh;
            background: linear-gradient(135deg, #111827, #1d4ed8, #2563eb);
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .contenedor {
            width: 100%;
            max-width: 460px;
            background: rgba(255, 255, 255, 0.12);
            backdrop-filter: blur(12px);
            border-radius: 20px;
            padding: 35px;
            box-shadow: 0 10px 35px rgba(0, 0, 0, 0.35);
            color: white;
        }

        h2 {
            text-align: center;
            margin-bottom: 25px;
            color: #ffde59;
        }

        .grupo {
            margin-bottom: 16px;
        }

        .grupo label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
            font-size: 14px;
        }

        .grupo input {
            width: 100%;
            padding: 12px 14px;
            border: none;
            border-radius: 10px;
            outline: none;
            font-size: 14px;
        }

        .grupo input:focus {
            box-shadow: 0 0 0 3px rgba(255, 222, 89, 0.35);
        }

        .btn {
            width: 100%;
            padding: 13px;
            background: #ffde59;
            color: #1f2937;
            font-weight: bold;
            border: none;
            border-radius: 12px;
            cursor: pointer;
            font-size: 15px;
            transition: 0.3s;
        }

        .btn:hover {
            background: #ffd000;
        }

        .extra {
            text-align: center;
            margin-top: 18px;
            font-size: 14px;
        }

        .extra a {
            color: #ffde59;
            text-decoration: none;
            font-weight: bold;
        }

        .error {
            margin-top: 15px;
            text-align: center;
            color: #fecaca;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div class="contenedor">
        <h2>Crear Cuenta</h2>

        <form action="RegistroServlet" method="post">
            <div class="grupo">
                <label>Usuario</label>
                <input type="text" name="usuario" required>
            </div>

            <div class="grupo">
                <label>Contraseña</label>
                <input type="password" name="password" required>
            </div>

            <div class="grupo">
                <label>Nombre</label>
                <input type="text" name="nombre" required>
            </div>

            <div class="grupo">
                <label>Correo</label>
                <input type="email" name="correo" required>
            </div>

            <button type="submit" class="btn">Registrar</button>
        </form>

        <div class="error">${error}</div>

        <div class="extra">
            ¿Ya tienes cuenta? <a href="login.jsp">Volver al login</a>
        </div>
    </div>
</body>
</html>