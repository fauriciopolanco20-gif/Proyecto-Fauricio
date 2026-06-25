/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package util;

import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoDatabase;

public class MongoConexion {

    private static final String URI = "mongodb+srv://alejandropicado38_db_user:5ENvwsSRe5O5UWac@prograii.flsbvql.mongodb.net/?appName=PrograII";

    private static final MongoClient client = MongoClients.create(URI);

    public static MongoDatabase conectar() {
        return client.getDatabase("ProyectoPrograII");
    }
}