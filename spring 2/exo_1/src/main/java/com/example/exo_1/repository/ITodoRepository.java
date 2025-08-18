package com.example.exo_1.repository;

import com.example.exo_1.entity.Todo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ITodoRepository extends JpaRepository<Todo, Long> {
    List<Todo> findByIsDone(Boolean isDone);
}
