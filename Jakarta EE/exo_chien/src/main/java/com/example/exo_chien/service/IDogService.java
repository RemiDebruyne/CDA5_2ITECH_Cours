package com.example.exo_chien.service;

import com.example.exo_chien.model.Dog;

import java.util.List;

public interface IDogService {
    public void add(Dog dog);
    public void update(Dog dog);
    public void delete(Dog dog);
    public Dog getById(int id);
    public List<Dog> findAll();
}
