package com.example.exo_voiture.service;

import com.example.exo_voiture.model.Car;

import java.util.List;
import java.util.UUID;

public interface ICarService {
    public List<Car> getAll();
    public Car getById(UUID id);
    public void add(Car car);
    public void update(Car car);
    public void delete(UUID id);
}
