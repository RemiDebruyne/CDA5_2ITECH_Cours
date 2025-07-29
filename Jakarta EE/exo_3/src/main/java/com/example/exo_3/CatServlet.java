package com.example.exo_3;

import com.example.exo_3.models.Cat;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.time.LocalDate;
import java.util.ArrayList;

@WebServlet("/cats")
public class CatServlet extends HttpServlet {
    private ArrayList<Cat> cats = new ArrayList<>();

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setAttribute("cats", cats);
        request.getRequestDispatcher("/cat.jsp").forward(request, response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        var cat = new Cat(request.getParameter("name"),request.getParameter("race"),request.getParameter("favoriteFood"), LocalDate.parse(request.getParameter("birthdate")));
        cats.add(cat);
        System.out.println(cat.name);
        response.sendRedirect(getServletContext().getContextPath() + "/cats");
    }
}
