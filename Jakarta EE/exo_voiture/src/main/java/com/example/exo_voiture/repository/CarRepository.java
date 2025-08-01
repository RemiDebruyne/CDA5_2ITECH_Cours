package com.example.exo_voiture.repository;

import com.example.exo_voiture.model.Car;

import jakarta.enterprise.context.RequestScoped;

import jakarta.inject.Inject;
import org.hibernate.Session;

import java.util.List;
import java.util.UUID;

@RequestScoped
public class CarRepository implements IBaseRepository<Car, UUID> {
    @Inject
    private Session _session;

    @Inject
    public CarRepository(Session _session) {
        this._session = _session;
    }

    @Override
    public Car getById(UUID id) {
        return _session.get(Car.class, id);
    }

    @Override
    public void add(Car entity) {
        _session.persist(entity);
    }

    @Override
    public void update(Car entity) {
        _session.merge(entity);
    }

    @Override
    public void delete(UUID id) {
        _session.remove(getById(id));
    }

    @Override
    public List<Car> getAll() {
        return _session.createQuery("from Car", Car.class).list();
    }
}
