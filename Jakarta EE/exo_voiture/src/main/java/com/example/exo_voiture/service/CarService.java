package com.example.exo_voiture.service;

import com.example.exo_voiture.model.Car;
import com.example.exo_voiture.repository.CarRepository;
import jakarta.enterprise.context.RequestScoped;
import jakarta.inject.Inject;
import org.hibernate.Session;


import java.util.List;
import java.util.UUID;

@RequestScoped
public class CarService implements ICarService {

    private Session session;

    private CarRepository carRepository;

    @Inject
    public CarService(CarRepository carRepository, Session session) {
        this.carRepository = carRepository;
        this.session = session;
    }

    @Override
    public List<Car> getAll() {
        try {
            return carRepository.getAll();
        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
            session.close();
        }
        return null;
    }

    @Override
    public Car getById(UUID id) {
        try {
            return carRepository.getById(id);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return null;
    }

    @Override
    public void add(Car car) {
        try {
            session.beginTransaction();
            carRepository.add(car);
            session.getTransaction().commit();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    @Override
    public void update(Car car) {
        try {
            session.beginTransaction();
            carRepository.update(car);
            session.getTransaction().commit();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    @Override
    public void delete(UUID id) {
        try {
            session.beginTransaction();
            carRepository.delete(id);
            session.getTransaction().commit();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
