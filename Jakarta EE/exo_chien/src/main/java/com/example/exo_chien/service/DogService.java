package com.example.exo_chien.service;

import com.example.exo_chien.model.Dog;
import com.example.exo_chien.repository.DogRepository;
import org.hibernate.Session;
import org.hibernate.SessionFactory;

import java.util.List;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Supplier;

public class DogService implements IDogService {

    private SessionFactory sessionFactory;
    private Session session;
    private DogRepository dogRepository;

    public DogService(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }

    @Override
    public void add(Dog dog) {
        try {
            session = sessionFactory.openSession();
            session.beginTransaction();
            dogRepository = new DogRepository(session);
            dogRepository.add(dog);
            session.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            session.close();
        }
    }

    @Override
    public void update(Dog dog) {
        try {
            session = sessionFactory.openSession();
            session.beginTransaction();
            dogRepository = new DogRepository(session);
            dogRepository.update(dog);
            session.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            session.close();
        }
    }

    @Override
    public void delete(Dog dog) {
        try {
            session = sessionFactory.openSession();
            session.beginTransaction();
            dogRepository = new DogRepository(session);
            dogRepository.delete(dog.getId());
            session.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            session.close();
        }
    }

    @Override
    public Dog getById(int id) {
        try {
            session = sessionFactory.openSession();
            dogRepository = new DogRepository(session);
            return dogRepository.findById(id);
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            session.close();
        }
        return null;
    }

    @Override
    public List<Dog> findAll() {
        try {
            session = sessionFactory.openSession();
            dogRepository = new DogRepository(session);
            return dogRepository.findAll();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            session.close();
        }
        return null;
    }
}
