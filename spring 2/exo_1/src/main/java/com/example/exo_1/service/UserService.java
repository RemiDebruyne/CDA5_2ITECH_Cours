package com.example.exo_1.service;

import com.example.exo_1.dto.RegisterRequestDto;
import com.example.exo_1.entity.User;
import com.example.exo_1.repository.IUserRepository;

import java.util.Optional;

public class UserService {
    private final IUserRepository userRepository;

    public UserService(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public User enregistrerUtilisateur(RegisterRequestDto registerRequestDto)  {
        User user = userRepository.findByEmail(registerRequestDto.getEmail());
        if(user != null){
            user = new User(
                    registerRequestDto.getFirstName(),
                    registerRequestDto.getEmail(),
                    registerRequestDto.getPhone(),
                    registerRequestDto.getPassword(),
                    registerRequestDto.getRole());
            return userRepository.save(user);
        }
        return  null;
    }
}
