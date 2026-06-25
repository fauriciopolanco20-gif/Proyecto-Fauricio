package servlet;

import dao.UsuarioDAO;
import java.io.IOException;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import modelo.Usuario;

@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet {

    private final UsuarioDAO usuarioDAO = new UsuarioDAO();

    @Override
    public void init() throws ServletException {
        usuarioDAO.crearAdminSiNoExiste();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        String usuario = request.getParameter("usuario");
        String password = request.getParameter("password");

        if (usuario == null || usuario.isBlank() || password == null || password.isBlank()) {
            request.setAttribute("error", "Usuario y contraseña son obligatorios.");
            request.getRequestDispatcher("login.jsp").forward(request, response);
            return;
        }

        Usuario u = usuarioDAO.autenticar(usuario, password);

        if (u != null) {
            HttpSession sesion = request.getSession();
            sesion.setAttribute("usuarioLogueado", u);
            response.sendRedirect("menu.jsp");
        } else {
            request.setAttribute("error", "Credenciales inválidas.");
            request.getRequestDispatcher("login.jsp").forward(request, response);
        }
    }
}