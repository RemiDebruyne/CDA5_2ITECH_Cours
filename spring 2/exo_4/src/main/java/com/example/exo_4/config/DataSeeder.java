package com.example.exo_4.config;

import com.example.exo_4.entities.Creature;
import com.example.exo_4.entities.Species;
import com.example.exo_4.services.CreatureService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.stream.IntStream;

@Configuration
public class DataSeeder {
    private final CreatureService creatureService;

    public DataSeeder(CreatureService creatureService) {
        this.creatureService = creatureService;
    }

    @Bean
    CommandLineRunner seedDatabase(CreatureService creatureService) {
        if (!creatureService.getAll().isEmpty()) {
            return args -> {
            };
        }
        return args -> {
            IntStream.rangeClosed(1, 50).forEach(i -> {
                Creature creature = Creature.builder()
                        .age(i)
                        .name("Creature " + i)
                        .isDangerous(i % 2 == 0)
                        .species(Species.random())
                        .weight(i)
                        .build();

                creatureService.add(creature);
            });
        };
    }
}
