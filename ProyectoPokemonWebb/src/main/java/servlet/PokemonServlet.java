/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package servlet;

import java.io.IOException;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import modelo.Pokemon;
import service.PokemonService;

@WebServlet("/PokemonServlet")
public class PokemonServlet extends HttpServlet {

    private final PokemonService service = new PokemonService();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        HttpSession sesion = request.getSession(false);

        if (sesion == null || sesion.getAttribute("usuarioLogueado") == null) {
            response.sendRedirect("login.jsp");
            return;
        }

        String nombre = request.getParameter("nombrePokemon");

        if (nombre == null || nombre.trim().isEmpty()) {
            request.setAttribute("error", "Debe ingresar un nombre de Pokémon.");
            request.getRequestDispatcher("consultaPokemon.jsp").forward(request, response);
            return;
        }

        try {
            Pokemon p = service.buscarPokemon(nombre);

            request.setAttribute("pokemon", p);
            request.getRequestDispatcher("resultadoPokemon.jsp").forward(request, response);

        } catch (Exception e) {
            e.printStackTrace();
            request.setAttribute("error", "No se pudo consultar el Pokémon.");
            request.getRequestDispatcher("consultaPokemon.jsp").forward(request, response);
        }
    }
}