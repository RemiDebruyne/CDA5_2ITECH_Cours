package com.example.exo_4.services;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import java.util.List;

public interface IBaseService<T, TId> {
    public T add(T entity);
    public void delete(TId id);
    public List<T> getAll();
    public Page<T> getAll(Pageable pageable);
    public T getOneById(TId id) throws Throwable;

}
