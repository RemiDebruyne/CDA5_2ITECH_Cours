package com.example.exo_3.models;

import java.time.LocalDate;
import java.util.Date;

public class Cat {
    public String getName() {
        return name;
    }

    public String getRace() {
        return race;
    }

    public String getFavoriteFood() {
        return favoriteFood;
    }

    public LocalDate getBirthdate() {
        return birthdate;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setRace(String race) {
        this.race = race;
    }

    public void setFavoriteFood(String favoriteFood) {
        this.favoriteFood = favoriteFood;
    }

    public void setBirthdate(LocalDate birthdate) {
        this.birthdate = birthdate;
    }

    public String name;
    public String race;
    public String favoriteFood;
    public LocalDate birthdate;

    public Cat(String name, String race, String favoriteFood, LocalDate birthdate) {
        this.name = name;
        this.race = race;
        this.favoriteFood = favoriteFood;
        this.birthdate = birthdate;
    }
}
