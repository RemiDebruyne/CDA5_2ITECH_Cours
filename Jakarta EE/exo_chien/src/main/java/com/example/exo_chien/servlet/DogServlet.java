package com.example.exo_chien.servlet;

import com.example.exo_chien.model.Dog;
import com.example.exo_chien.service.DogService;
import com.example.exo_chien.service.IDogService;
import com.example.exo_chien.utils.HibernateSession;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.time.LocalDate;

@WebServlet(name = "dogServlet", value = {"/dogs/*"})
public class DogServlet extends HttpServlet {

    private IDogService dogService;

    public void init() {
        dogService = new DogService(HibernateSession.getSessionFactory());
    }

    public void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        String pathInfo = (req.getPathInfo() != null && !req.getPathInfo().isEmpty()) ? req.getPathInfo() : "";
        System.out.println("-------------------------- PATH INFO --------------------------------");
        System.out.println("Mon path : " + pathInfo);
        System.out.println("Mon path est vide ? : " + pathInfo.isEmpty());
        if (pathInfo.isEmpty()) {
            req.setAttribute("dogs", dogService.findAll());
            req.getRequestDispatcher("/dog-list.jsp").forward(req, resp);
        } else if (pathInfo.contains("form")) {
            req.getRequestDispatcher("/dog-form.jsp").forward(req, resp);
        } else {
            int id = Integer.parseInt(pathInfo.substring(1));
            System.out.println("----------------- ID ------------------------");
            System.out.println(id);
            req.setAttribute("dog", dogService.getById(id));
            req.getRequestDispatcher("/dog-details.jsp").forward(req, resp);
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String name = req.getParameter("name");
        String race = req.getParameter("race");
        LocalDate birthdate = LocalDate.parse(req.getParameter("birthdate"));
        Dog dog = new Dog(name, race, birthdate);
        dogService.add(dog);
        resp.sendRedirect(getServletContext().getContextPath()+"/dogs");
    }
}
