<body>
<div class="contenedor">
    <h2>Resultado</h2>

    <p><strong>Nombre:</strong> <%= p.getNombre() %></p>
    <p><strong>Tamaño:</strong> <%= p.getTamano() %></p>
    <p><strong>Tipo:</strong> <%= p.getTipo() %></p>
    <p><strong>Región:</strong> <%= p.getRegion() %></p>

    <img src="<%= p.getImagen() %>" width="150">

    <br><br>
    <a href="consultaPokemon.jsp">Volver</a>
    <br>
    <a href="menu.jsp">Menú</a>
</div>
</body>