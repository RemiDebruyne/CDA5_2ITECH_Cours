package com.example.exo_chien.repository;

import org.hibernate.Session;

import java.util.List;
import java.util.function.Consumer;

public interface IBaseRepository<T> {
    public void add(T entity);
    public void update(T entity);
    public void delete(int id);
    public T findById(int id);
    public List<T> findAll();

}
