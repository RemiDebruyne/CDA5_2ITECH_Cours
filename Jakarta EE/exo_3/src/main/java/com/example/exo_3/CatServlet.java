package com.example.exo_3;

import com.example.exo_3.models.Cat;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.hibernate.Session;

import java.io.IOException;
import java.time.LocalDate;
import java.util.ArrayList;

@WebServlet("/cats")
public class CatServlet extends HttpServlet {
    private Session session = factory.
    private ArrayList<Cat> cats = sess;

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setAttribute("cats", cats);
        request.getRequestDispatcher("/cat.jsp").forward(request, response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        var cat = new Cat(request.getParameter("name"),request.getParameter("race"),request.getParameter("favoriteFood"), LocalDate.parse(request.getParameter("birthdate")));
        cats.add(cat);
        response.sendRedirect(getServletContext().getContextPath() + "/cats");
    }
}
