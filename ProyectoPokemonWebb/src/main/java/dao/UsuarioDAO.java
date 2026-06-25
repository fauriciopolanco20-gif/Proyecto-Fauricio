/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dao;

import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import modelo.Usuario;
import org.bson.Document;
import util.MongoConexion;
import static com.mongodb.client.model.Filters.eq;

public class UsuarioDAO {

    private MongoDatabase db = MongoConexion.conectar();
    private MongoCollection<Document> coleccion = db.getCollection("usuarios");

    public boolean registrarUsuario(Usuario u) {
        Document existe = coleccion.find(eq("usuario", u.getUsuario())).first();

        if (existe != null) {
            return false;
        }

        Document doc = new Document("usuario", u.getUsuario())
                .append("password", u.getPassword())
                .append("nombre", u.getNombre())
                .append("correo", u.getCorreo())
                .append("rol", u.getRol());

        coleccion.insertOne(doc);
        return true;
    }

    public Usuario autenticar(String usuario, String password) {
        Document doc = coleccion.find(eq("usuario", usuario)).first();

        if (doc != null && password.equals(doc.getString("password"))) {
            return new Usuario(
                    doc.getString("usuario"),
                    doc.getString("password"),
                    doc.getString("nombre"),
                    doc.getString("correo"),
                    doc.getString("rol")
            );
        }

        return null;
    }

    public void crearAdminSiNoExiste() {
        Document admin = coleccion.find(eq("usuario", "admin")).first();

        if (admin == null) {
            Document doc = new Document("usuario", "admin")
                    .append("password", "admin123")
                    .append("nombre", "Administrador")
                    .append("correo", "admin@pokemon.com")
                    .append("rol", "ADMIN");

            coleccion.insertOne(doc);
        }
    }
}