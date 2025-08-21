package com.example.exo_1.repository;

import com.example.exo_1.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUserRepository  extends JpaRepository<User, Integer> {
    User findByEmail(String email);
}
