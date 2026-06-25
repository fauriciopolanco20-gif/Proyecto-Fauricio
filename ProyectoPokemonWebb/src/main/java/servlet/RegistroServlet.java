package servlet;

import dao.UsuarioDAO;
import java.io.IOException;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import modelo.Usuario;

@WebServlet("/RegistroServlet")
public class RegistroServlet extends HttpServlet {

    private final UsuarioDAO usuarioDAO = new UsuarioDAO();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        String usuario = request.getParameter("usuario");
        String password = request.getParameter("password");
        String nombre = request.getParameter("nombre");
        String correo = request.getParameter("correo");

        if (usuario == null || usuario.isBlank()
                || password == null || password.isBlank()
                || nombre == null || nombre.isBlank()
                || correo == null || correo.isBlank()) {

            request.setAttribute("error", "Todos los campos son obligatorios.");
            request.getRequestDispatcher("registro.jsp").forward(request, response);
            return;
        }

        Usuario u = new Usuario(usuario, password, nombre, correo, "USER");
        boolean registrado = usuarioDAO.registrarUsuario(u);

        if (registrado) {
            request.setAttribute("mensaje", "Usuario registrado correctamente.");
            request.getRequestDispatcher("login.jsp").forward(request, response);
        } else {
            request.setAttribute("error", "El usuario ya existe.");
            request.getRequestDispatcher("registro.jsp").forward(request, response);
        }
    }
}