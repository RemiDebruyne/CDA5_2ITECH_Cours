package com.example.exo_2.controller;

import com.example.exo_2.entity.Director;
import com.example.exo_2.entity.Movie;
import com.example.exo_2.service.DirectorService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/directors")
public class DirectorController {

    private DirectorService _directorService;

    public DirectorController(DirectorService directorService) {
        this._directorService = directorService;
    }

    @GetMapping
    public ResponseEntity<List<Director>> getDirectors(){
        return ResponseEntity.ok(_directorService.getAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Director> getDirectorById(@PathVariable Long id){
        return ResponseEntity.ok(_directorService.getOneById(id));
    }

    @PostMapping
    public ResponseEntity<Director> addDirector(@RequestBody Director director){
        return ResponseEntity.ok(_directorService.add(director));
    }

    @PutMapping
    public ResponseEntity<Director> updateDirector(@RequestBody Director director){
        return ResponseEntity.ok(_directorService.update(director));
    }
}
