<body>
<div class="contenedor">
    <h2>Consulta Aleatoria</h2>

    <form action="AleatorioServlet" method="post">
        <select name="tipoPokemon" required>
            <option value="">Seleccione</option>
            <option value="water">water</option>
            <option value="fire">fire</option>
            <option value="grass">grass</option>
        </select>

        <button type="submit">Generar</button>
    </form>

    <p class="error">${error}</p>

    <br>
    <a href="menu.jsp">Volver</a>
</div>
</body>