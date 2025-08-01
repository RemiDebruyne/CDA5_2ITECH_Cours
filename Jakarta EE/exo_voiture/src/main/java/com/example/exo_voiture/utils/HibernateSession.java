package com.example.exo_voiture.utils;


import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

//public class HibernateSession {
//    private static StandardServiceRegistry serviceRegistry;
//    private static SessionFactory sessionFactory;
//    private static Session session;
//
//    public static SessionFactory getSessionFactory() {
//        serviceRegistry = new StandardServiceRegistryBuilder().configure().build();
//        sessionFactory = new MetadataSources(serviceRegistry).buildMetadata().buildSessionFactory();
//        return sessionFactory;
//    }
//
//    public static Session getSession() {
//        return getSessionFactory().openSession();
//    }
//
//
//}

public class HibernateSession {
    private static StandardServiceRegistry serviceRegistry;
    private static SessionFactory sessionFactory;

    static {
        try {
            serviceRegistry = new StandardServiceRegistryBuilder().configure().build();
            sessionFactory = new MetadataSources(serviceRegistry).buildMetadata().buildSessionFactory();
        } catch (Throwable ex) {
            System.out.println("------------------------ ERROR -------------------------------");
            System.err.println("Initial SessionFactory creation failed." + ex);
            throw new ExceptionInInitializerError(ex);
        }
    }

    public static SessionFactory getSessionFactory() {
        return sessionFactory;
    }

    public static Session getSession() {
        return sessionFactory.openSession();
    }
}