package com.example.exo_2;

import com.example.exo_2.model.Person;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.util.ArrayList;


@WebServlet("/jsp")
public class JspServlet extends HttpServlet {
    private ArrayList<Person> personnes;

    public void init(){
        personnes = new ArrayList<>();

        personnes.add(new Person("John", "Doe", 18));
        personnes.add(new Person("Jane", "Doe", 19));
        personnes.add(new Person("Jack", "Doe", 20));
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setAttribute("personnes", personnes);

        request.getRequestDispatcher("/personnes.jsp").forward(request, response);
    }
}
