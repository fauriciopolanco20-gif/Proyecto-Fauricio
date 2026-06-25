/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dao;

import dao.UsuarioDAO;
import modelo.Usuario;

public class TestUsuario {

    public static void main(String[] args) {

        UsuarioDAO dao = new UsuarioDAO();

        Usuario u = new Usuario(
                "Alejandro",
                "12345",
                "Ale",
                "",
                "USER"
        );

        boolean resultado = dao.registrarUsuario(u);

        if (resultado) {
            System.out.println("Usuario guardado correctamente");
        } else {
            System.out.println("El usuario ya existe");
        }
    }
}