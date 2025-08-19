package com.example.exo_2.repository;

import com.example.exo_2.entity.Director;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IDirectorRepository extends JpaRepository<Director,Long> {
}
