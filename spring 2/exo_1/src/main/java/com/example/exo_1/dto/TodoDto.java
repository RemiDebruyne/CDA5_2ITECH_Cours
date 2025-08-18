package com.example.exo_1.dto;

import com.example.exo_1.entity.Todo;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@NoArgsConstructor
@AllArgsConstructor
@Data
@Builder
public class TodoDto {
    private String title;
    private String description;
    private Date dueDate;
    private Boolean isDone;

    static public TodoDto mapFromTodo(Todo todo){
        return TodoDto.builder()
                .title(todo.getTitle())
                .description(todo.getDescription())
                .dueDate(todo.getDueDate())
                .isDone(todo.getIsDone())
                .build();
    }

}
