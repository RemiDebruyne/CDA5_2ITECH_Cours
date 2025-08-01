package com.example.exo_voiture.repository;

import com.example.exo_voiture.model.Car;
import org.hibernate.Session;

import java.util.List;

public interface IBaseRepository<T, TIdType> {
    public T getById(TIdType id);
    public void add(T entity);
    public void update(T entity);
    public void delete(TIdType id);
    public List<T> getAll();
}
