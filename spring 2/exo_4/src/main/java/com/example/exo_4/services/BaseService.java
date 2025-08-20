package com.example.exo_4.services;

import com.example.exo_4.repositories.IBaseRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;


import java.util.List;

public abstract class BaseService<T, TId> implements IBaseService<T, TId>{

    protected  IBaseRepository repository;

    public BaseService(IBaseRepository repository) {
        this.repository = repository;
    }

    @Override
    public T add(T entity) {
        return (T) repository.save(entity);
    }

    @Override
    public void delete(TId id) {
        repository.deleteById(id);
    }

    @Override
    public List<T> getAll() {
        return (List<T>) repository.findAll();
    }

    @Override
    public Page<T> getAll(Pageable pageable) {
        return (Page<T>) repository.findAll(pageable);
    }

    @Override
    public T getOneById(TId tId) throws Throwable {
        return (T) repository.findById(tId).orElseThrow(EntityNotFoundException::new);
    }

    protected abstract T update(T entity) throws Throwable;
}
