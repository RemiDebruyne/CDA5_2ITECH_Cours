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

@WebServlet("/form")
public class CatFormServlet extends HttpServlet {
    public ArrayList<Cat> cats = new ArrayList<Cat>();
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.setAttribute("cats", cats);
        req.getRequestDispatcher("/form.jsp").forward(req, resp);
    }


}
