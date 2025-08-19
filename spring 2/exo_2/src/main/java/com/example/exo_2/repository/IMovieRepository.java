package com.example.exo_2.repository;

import com.example.exo_2.entity.Director;
import com.example.exo_2.entity.Movie;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface IMovieRepository extends JpaRepository<Movie, Long> {
    public List<Movie> findByDirectorId(Long id);
}
