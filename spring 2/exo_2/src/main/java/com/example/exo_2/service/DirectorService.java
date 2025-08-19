package com.example.exo_2.service;

import com.example.exo_2.entity.Director;
import com.example.exo_2.entity.Movie;
import com.example.exo_2.repository.IDirectorRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class DirectorService {
    private IDirectorRepository _directorRepository;

    public DirectorService(IDirectorRepository _directorRepository) {
        this._directorRepository = _directorRepository;
    }
    
    public List<Director> getAll() {
        return _directorRepository.findAll();
    }
    
    public Director getOneById(Long id) {
        return _directorRepository.findById(id).orElseThrow(EntityNotFoundException::new);
    }

    public Director add(Director director) {
        return _directorRepository.save(director);
    }

    public Director update(Director director) {
        var oldDirector = _directorRepository.findById(director.getId()).orElseThrow(EntityNotFoundException::new);
        oldDirector.setFirstName(director.getFirstName());
        oldDirector.setLastName(director.getLastName());
        oldDirector.setNationality(director.getNationality());
        oldDirector.setBirthdate(director.getBirthdate());

        return _directorRepository.save(oldDirector);
    }

    public void delete(Long id) {
        _directorRepository.deleteById(id);
    }
}
