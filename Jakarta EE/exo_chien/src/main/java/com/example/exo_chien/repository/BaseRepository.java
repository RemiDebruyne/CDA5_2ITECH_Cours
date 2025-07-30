package com.example.exo_chien.repository;

import org.hibernate.Session;

import java.util.List;
import java.util.function.Consumer;

public abstract class BaseRepository<T> implements IBaseRepository<T> {
    protected Session _session;
    protected Class<T> repositoryType;


    public BaseRepository(Session session) {
        _session = session;
        repositoryType = defineRepositoryType();
    }

    @Override
    public void add(T entity) {
        _session.persist(entity);
    }

    @Override
    public void update(T entity) {
        _session.merge(entity);
    }

    @Override
    public void delete(int id) {
        T entity = findById(id);
        _session.remove(entity);
    }

    @Override
    public T findById(int id) {
        return _session.get(repositoryType, id);
    }

    @Override
    public List<T> findAll() {
        var result = _session.createQuery("FROM " + repositoryType.getSimpleName(), repositoryType).list();
        return result;
    }

    protected abstract Class<T> defineRepositoryType();
}
