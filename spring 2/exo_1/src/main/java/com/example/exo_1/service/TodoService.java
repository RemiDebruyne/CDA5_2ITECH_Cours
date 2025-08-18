package com.example.exo_1.service;

import com.example.exo_1.entity.Todo;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;
import com.example.exo_1.repository.ITodoRepository;

import java.util.List;

@Service
public class TodoService {
private final ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository) {
        this._todoRepository = todoRepository;
    }

    public Todo getOneById(Long id) {
        return _todoRepository.findById(id).orElse(null);
    }

    public Todo add(Todo todo){
        return _todoRepository.save(todo);
    }

    public void delete(Long id) {
        _todoRepository.deleteById(id);
    }

    public Todo update(Long id, Todo todo) {
        Todo oldTodo = _todoRepository.findById(id).orElseThrow(EntityNotFoundException::new);
        oldTodo.setDescription(todo.getDescription());
        oldTodo.setTitle(todo.getTitle());
        oldTodo.setIsDone(todo.getIsDone());
        oldTodo.setDueDate(todo.getDueDate());
        return _todoRepository.save(oldTodo);
    }

    public List<Todo> getAllByIsDone(boolean isDone) {
       return _todoRepository.findByIsDone(isDone);
    }

    public List<Todo> getAll() {
        return _todoRepository.findAll();
    }
}
