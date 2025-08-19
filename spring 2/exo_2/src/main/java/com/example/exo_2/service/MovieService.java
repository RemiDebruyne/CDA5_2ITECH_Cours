package com.example.exo_2.service;

import com.example.exo_2.entity.Director;
import com.example.exo_2.entity.Movie;
import com.example.exo_2.exception.NotFoundException;
import com.example.exo_2.repository.IDirectorRepository;
import com.example.exo_2.repository.IMovieRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.lang.reflect.Type;
import java.util.List;

@Service
public class MovieService {
    private final IMovieRepository _movieRepository;
    private final IDirectorRepository _directorRepository;

    public MovieService(IMovieRepository movieRepository, IDirectorRepository directorRepository) {
        _movieRepository = movieRepository;
        _directorRepository = directorRepository;
    }

    public Movie getOneById(Long id) {
        return _movieRepository.findById(id).orElseThrow(EntityNotFoundException::new);
    }

    public List<Movie> getAll() {
        return _movieRepository.findAll();
    }

    public List<Movie> getAllByDirector(Long id) {
        var director =  _directorRepository.findById(id).orElseThrow(() -> new NotFoundException("Director was not found with Id :" + id, "Director_Notfound"));

        return _movieRepository.findByDirectorId(id);
    }

    public void  delete(Movie movie) {
        _movieRepository.delete(movie);
    }

    public Movie add(Movie movie) {
        return _movieRepository.save(movie);
    }

    public Movie update(Movie movie) {

        var oldMovie  = _movieRepository.findById(movie.getId()).orElseThrow(() ->  new NotFoundException("Movie was not found with Id : " + movie.getId(), "Movie_NotFound"));

        var director = _directorRepository.findById(movie.getDirector().getId()).orElseThrow(() -> new NotFoundException("Director was not found with Id :" + movie.getDirector().getId(), "Director_NotFound"));

        oldMovie.setDescription(movie.getDescription());
        oldMovie.setTitle(movie.getTitle());
        oldMovie.setReleaseDate(movie.getReleaseDate());
        oldMovie.setGenre(movie.getGenre());
        oldMovie.setDirector(movie.getDirector());
        return _movieRepository.save(oldMovie);
    }
}
