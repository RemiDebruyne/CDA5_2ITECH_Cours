package com.example.exo_1.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    private String name;

    @Column(unique = true)
    private String email;
    private String phone;

    private String password;

    private Role role;

    public User(String name, String email, String phone, String password, int role) {

        this.email = email;
        this.phone = phone;
        this.password = password;
        this.role = role == 0 ? Role.ROLE_USER : Role.ROLE_ADMIN;
    }
}
