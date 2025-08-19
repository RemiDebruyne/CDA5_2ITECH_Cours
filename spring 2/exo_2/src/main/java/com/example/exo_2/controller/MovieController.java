package com.example.exo_2.controller;

import com.example.exo_2.entity.Movie;
import com.example.exo_2.service.MovieService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/movies")
public class MovieController {

    private MovieService _movieService;
    public MovieController(MovieService movieService) {
        this._movieService = movieService;
    }

    @GetMapping
    public ResponseEntity<List<Movie>> getAll(@RequestParam(required = false) Long directorId) {


        List<Movie> movies = directorId == null ?_movieService.getAll() : _movieService.getAllByDirector(directorId);
//        List<Movie> movies = _movieService.getAllByDirector(directorId);

        return ResponseEntity.ok(movies);
    }

    @GetMapping("/{id}")
    public ResponseEntity<Movie> getById(@PathVariable Long id) {
        return ResponseEntity.ok(_movieService.getOneById(id));
    }

    @PostMapping
    public ResponseEntity<Movie> create(@RequestBody Movie movie){
        return ResponseEntity.ok(_movieService.add(movie));
    }

    @PutMapping
    public ResponseEntity<Movie> update(@RequestBody Movie movie){
        return ResponseEntity.ok(_movieService.update(movie));
    }
}
