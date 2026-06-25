/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package service;

import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import modelo.Pokemon;

public class PokemonService {

    public Pokemon buscarPokemon(String nombreBuscado) throws Exception {
        String nombre = nombreBuscado.toLowerCase().trim();

        URL url = new URL("https://pokeapi.co/api/v2/pokemon/" + nombre);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");

        int codigo = con.getResponseCode();
        if (codigo != 200) {
            throw new RuntimeException("No encontrado");
        }

        BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream()));
        StringBuilder sb = new StringBuilder();
        String linea;

        while ((linea = br.readLine()) != null) {
            sb.append(linea);
        }

        br.close();

        JsonObject json = JsonParser.parseString(sb.toString()).getAsJsonObject();

        String nombrePokemon = json.get("name").getAsString();
        int tamano = json.get("height").getAsInt();

        JsonArray tipos = json.getAsJsonArray("types");
        String tipo = tipos.get(0).getAsJsonObject()
                .getAsJsonObject("type")
                .get("name").getAsString();

        String imagen = "";
        if (json.getAsJsonObject("sprites").get("front_default") != null
                && !json.getAsJsonObject("sprites").get("front_default").isJsonNull()) {
            imagen = json.getAsJsonObject("sprites")
                    .get("front_default").getAsString();
        }

        return new Pokemon(nombrePokemon, tamano, tipo, "desconocida", imagen);
    }
}