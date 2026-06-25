/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dao;

import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Sorts;
import java.util.ArrayList;
import java.util.List;
import modelo.Historial;
import org.bson.Document;
import util.MongoConexion;
import static com.mongodb.client.model.Filters.eq;

public class HistorialDAO {

    private MongoDatabase db = MongoConexion.conectar();
    private MongoCollection<Document> coleccion = db.getCollection("historial");

    public void guardarHistorial(Historial h) {
        Document doc = new Document("usuario", h.getUsuario())
                .append("fecha", h.getFecha())
                .append("hora", h.getHora())
                .append("nombrePokemon", h.getNombrePokemon())
                .append("tamano", h.getTamano())
                .append("tipo", h.getTipo())
                .append("region", h.getRegion())
                .append("imagen", h.getImagen());

        coleccion.insertOne(doc);
    }

    public List<Historial> obtenerPorUsuario(String usuario) {
        List<Historial> lista = new ArrayList<>();

        FindIterable<Document> docs = coleccion.find(eq("usuario", usuario))
                .sort(Sorts.ascending("fecha", "hora"));

        for (Document doc : docs) {
            lista.add(new Historial(
                    doc.getString("usuario"),
                    doc.getString("fecha"),
                    doc.getString("hora"),
                    doc.getString("nombrePokemon"),
                    doc.getInteger("tamano", 0),
                    doc.getString("tipo"),
                    doc.getString("region"),
                    doc.getString("imagen")
            ));
        }

        return lista;
    }

    public List<Historial> obtenerTodos() {
        List<Historial> lista = new ArrayList<>();

        FindIterable<Document> docs = coleccion.find()
                .sort(Sorts.ascending("fecha", "hora"));

        for (Document doc : docs) {
            lista.add(new Historial(
                    doc.getString("usuario"),
                    doc.getString("fecha"),
                    doc.getString("hora"),
                    doc.getString("nombrePokemon"),
                    doc.getInteger("tamano", 0),
                    doc.getString("tipo"),
                    doc.getString("region"),
                    doc.getString("imagen")
            ));
        }

        return lista;
    }
}