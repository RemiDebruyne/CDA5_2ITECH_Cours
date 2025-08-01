package com.example.exo_voiture.producer;


import com.example.exo_voiture.utils.HibernateSession;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.enterprise.context.RequestScoped;
import jakarta.enterprise.inject.Disposes;

import jakarta.enterprise.inject.Produces;
import jakarta.ws.rs.core.MediaType;
import org.hibernate.Session;

@ApplicationScoped
public class SessionProducer {

    @Produces()
    @RequestScoped
    public Session createSession() {
        return HibernateSession.getSession();
    }

    public void closeSession(@Disposes Session session) {
        if (session != null && session.isOpen()) {
            session.close();
        }
    }
}