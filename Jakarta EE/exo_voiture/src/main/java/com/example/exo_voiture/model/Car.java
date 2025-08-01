package com.example.exo_voiture.model;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

import java.time.LocalDateTime;
import java.util.UUID;

@Entity
public class Car {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private UUID id;
    private String brand;
    private LocalDateTime fabricationDate;
    private String color;




    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public LocalDateTime getFabricationDate() {
        return fabricationDate;
    }

    public void setFabricationDate(LocalDateTime fabricationDate) {
        this.fabricationDate = fabricationDate;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public Car() {
    }

    public Car(String brand, String color) {
        this.brand = brand;
        this.color = color;
    }

    public Car(UUID id, String brand, LocalDateTime fabricationDate, String color) {
        this.id = id;
        this.brand = brand;
        this.fabricationDate = fabricationDate;
        this.color = color;
    }
}
