package com.example.exo_4.repositories;

import org.springframework.context.annotation.Bean;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.NoRepositoryBean;


@NoRepositoryBean
public interface IBaseRepository<T, TId> extends JpaRepository<T,TId> {
}
