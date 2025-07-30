package com.example.exo_chien.repository;

import com.example.exo_chien.model.Dog;
import org.hibernate.Session;

public class DogRepository extends BaseRepository<Dog> {

    public DogRepository(Session session) {
        super(session);
    }

    @Override
    protected Class<Dog> defineRepositoryType() {
        return Dog.class;
    }
}
