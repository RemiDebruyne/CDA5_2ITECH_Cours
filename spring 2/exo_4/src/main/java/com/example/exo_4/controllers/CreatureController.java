package com.example.exo_4.controllers;

import com.example.exo_4.entities.Creature;
import com.example.exo_4.services.CreatureService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.web.bind.annotation.*;
import org.springframework.data.domain.Page;

import java.util.List;
import java.util.Objects;

@RestController
@RequestMapping("/api/creatures")
public class CreatureController {

    private final CreatureService creatureService;

    public CreatureController(CreatureService creatureService) {
        this.creatureService = creatureService;
    }

    @PostMapping
    public Creature create(@RequestBody Creature creature) {
        return creatureService.add(creature);
    }

    @GetMapping
    public List<Creature> getAll() {
        return creatureService.getAll();
    }

    @GetMapping("/paged")
    public Page<Creature> getAll(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "id") String sortBy,
            @RequestParam(defaultValue = "asc") String direction) {
//        return creatureService.getAll(PageRequest.of(page, pageSize, Sort.by(direction, sortBy)));
        Sort sort = Objects.equals(direction, "asc") ? Sort.by(sortBy).ascending() : Sort.by(sortBy).descending();
        return creatureService.getAll(PageRequest.of(page, pageSize, sort));
    }

    @GetMapping("/{id}")
    public Creature getOne(@PathVariable long id) throws Throwable {
        return creatureService.getOneById(id);
    }

    @PutMapping
    public Creature update(@RequestBody Creature creature) throws Throwable {
        return creatureService.update(creature);
    }

    @DeleteMapping void delete(@RequestParam long id) throws Throwable {
        creatureService.delete(id);
    }
}
