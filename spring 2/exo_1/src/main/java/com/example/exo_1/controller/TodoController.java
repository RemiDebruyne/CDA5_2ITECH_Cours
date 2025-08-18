package com.example.exo_1.controller;

import com.example.exo_1.dto.TodoDto;
import com.example.exo_1.entity.Todo;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import com.example.exo_1.service.TodoService;

import java.util.List;

@RestController
@RequestMapping("api/todos")
public class TodoController {

    private final TodoService _todoService;

    public TodoController(TodoService _todoService) {
        this._todoService = _todoService;
    }

    @GetMapping
    public ResponseEntity<List<TodoDto>> getAllTodos() {
        return ResponseEntity.ok(_todoService.getAll().stream().map(TodoDto::mapFromTodo).toList());
    }

    @GetMapping("/{id}")
    public ResponseEntity<TodoDto> getTodoById(@PathVariable Long id) {
        TodoDto todoDto = TodoDto.mapFromTodo(_todoService.getOneById(id));
        return ResponseEntity.ok(todoDto);
    }

    @PostMapping
    public ResponseEntity<TodoDto> createTodo(@RequestBody Todo todo) {
        TodoDto todoDto = TodoDto.mapFromTodo(_todoService.add(todo));
        return ResponseEntity.ok(todoDto);
    }

    @PutMapping("/{id}")
    public ResponseEntity<TodoDto> updateTodo(@PathVariable Long id, @RequestBody Todo todo) {
       TodoDto todoDto = TodoDto.mapFromTodo(_todoService.update(id, todo)) ;

       return ResponseEntity.ok(todoDto);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteTodo(@PathVariable Long id) {
        _todoService.delete(id);
        return ResponseEntity.noContent().build();
    }
}
