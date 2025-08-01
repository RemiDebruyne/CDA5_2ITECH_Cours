package com.example.exo_voiture.controller;

import com.example.exo_voiture.model.Car;
import com.example.exo_voiture.service.CarService;
import jakarta.inject.Inject;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;


import java.util.ArrayList;
import java.util.List;

@Path("/cars")
public class CarRessource {

    private CarService carService;

    @Inject
    public CarRessource(CarService carService) {
        this.carService = carService;
    }

    @Produces(MediaType.APPLICATION_JSON)
    @GET
    public List<Car> get() {
        List<Car> cars = new ArrayList<>();
        cars.add(new Car("red", "toyota"));
        cars.add(new Car("yellow", "ford"));
        cars.add(new Car("white", "renault"));
        return cars;
//        return  carService.getAll();
    }

    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
    @POST
    public void create(Car car) {
//        return new Car("red", "ford");
        carService.add(car);
    }
}