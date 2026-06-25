/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package servlet;

import dao.HistorialDAO;
import java.io.IOException;
import java.util.List;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import modelo.Historial;
import modelo.Usuario;

@WebServlet("/HistoricoServlet")
public class HistoricoServlet extends HttpServlet {

    private final HistorialDAO historialDAO = new HistorialDAO();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        HttpSession sesion = request.getSession(false);

        if (sesion == null || sesion.getAttribute("usuarioLogueado") == null) {
            response.sendRedirect("login.jsp");
            return;
        }

        Usuario u = (Usuario) sesion.getAttribute("usuarioLogueado");
        List<Historial> lista;

        if ("ADMIN".equalsIgnoreCase(u.getRol())) {
            lista = historialDAO.obtenerTodos();
        } else {
            lista = historialDAO.obtenerPorUsuario(u.getUsuario());
        }

        request.setAttribute("listaHistorial", lista);
        request.getRequestDispatcher("historico.jsp").forward(request, response);
    }
}