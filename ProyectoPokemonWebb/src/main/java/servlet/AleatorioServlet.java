/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package servlet;

import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import modelo.Pokemon;

@WebServlet("/AleatorioServlet")
public class AleatorioServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        String tipo = request.getParameter("tipoPokemon");

        if (tipo == null || tipo.trim().isEmpty()) {
            request.setAttribute("error", "Debe seleccionar un tipo.");
            request.getRequestDispatcher("aleatorio.jsp").forward(request, response);
            return;
        }

        try {
            JsonObject typeJson = leerJson("https://pokeapi.co/api/v2/type/" + tipo.toLowerCase().trim());
            JsonArray pokemonArray = typeJson.getAsJsonArray("pokemon");

            List<String> nombres = new ArrayList<>();

            for (int i = 0; i < pokemonArray.size(); i++) {
                JsonObject item = pokemonArray.get(i).getAsJsonObject();
                JsonObject pokeObj = item.getAsJsonObject("pokemon");
                String nombre = pokeObj.get("name").getAsString();
                nombres.add(nombre);
            }

            Collections.shuffle(nombres);

            List<Pokemon> resultado = new ArrayList<>();
            int limite = Math.min(10, nombres.size());

            for (int i = 0; i < limite; i++) {
                String nombre = nombres.get(i);

                JsonObject pokeJson = leerJson("https://pokeapi.co/api/v2/pokemon/" + nombre);

                String imagen = "";
                JsonObject sprites = pokeJson.getAsJsonObject("sprites");
                if (sprites != null && sprites.get("front_default") != null && !sprites.get("front_default").isJsonNull()) {
                    imagen = sprites.get("front_default").getAsString();
                }

                resultado.add(new Pokemon(nombre, 0, tipo, "desconocida", imagen));
            }

            request.setAttribute("listaAleatoria", resultado);
            request.getRequestDispatcher("resultadoAleatorio.jsp").forward(request, response);

        } catch (Exception e) {
            e.printStackTrace();
            request.setAttribute("error", "No se pudo generar la consulta aleatoria.");
            request.getRequestDispatcher("aleatorio.jsp").forward(request, response);
        }
    }

    private JsonObject leerJson(String urlTexto) throws Exception {
        URL url = new URL(urlTexto);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        con.setRequestProperty("Accept", "application/json");

        int codigo = con.getResponseCode();
        if (codigo != 200) {
            throw new RuntimeException("Error HTTP: " + codigo + " en " + urlTexto);
        }

        BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
        StringBuilder sb = new StringBuilder();
        String linea;

        while ((linea = br.readLine()) != null) {
            sb.append(linea);
        }

        br.close();
        return JsonParser.parseString(sb.toString()).getAsJsonObject();
    }
}