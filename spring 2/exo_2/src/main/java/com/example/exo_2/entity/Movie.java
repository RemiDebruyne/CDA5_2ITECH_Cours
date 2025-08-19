package com.example.exo_2.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalTime;
import java.util.Date;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Movie {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private String title;
    private String description;
    private Date releaseDate;
    private LocalTime duration;
    @Enumerated(EnumType.ORDINAL)
    private Genre genre;
    @ManyToOne
    @JoinColumn(name = "director_id")
    private Director director;
}

