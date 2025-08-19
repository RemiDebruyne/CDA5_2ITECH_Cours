package com.example.exo_2.exception;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

import java.util.function.Supplier;

@Getter
@Setter
public class NotFoundException extends RuntimeException {
    private String error;

    public NotFoundException(String message, String error) {
        super(message);
        this.error = error;
    }
}
