package com.example.exo_4.services;

import com.example.exo_4.entities.Creature;
import com.example.exo_4.repositories.ICreatureRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CreatureService extends BaseService<Creature, Long>{

    public CreatureService(ICreatureRepository repository) {
        super(repository);
    }

    @Override
    public Creature update(Creature creature) throws Throwable {
        var oldCreature = (Creature) repository.findById(creature.getId()).orElseThrow(EntityNotFoundException::new);
        oldCreature.setName(creature.getName());
        oldCreature.setAge(creature.getAge());
        oldCreature.setWeight(creature.getWeight());
        oldCreature.setDangerous(creature.isDangerous());
        oldCreature.setSpecies(creature.getSpecies());
        var newCreature = (Creature) repository.save(oldCreature);
        return  newCreature;
    }
}
