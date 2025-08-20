package com.example.exo_4.entities;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Random;

public enum Species {
    Dragon,
    Elf,
    Orc,
    Human,
    Hobbit,
    Dwarf;

    private static final List<Species> VALUES = Collections.unmodifiableList(Arrays.asList(values()));
    private static final int SIZE = VALUES.size();
    private static final Random RANDOM = new Random();

    public static Species random() {
        return VALUES.get(RANDOM.nextInt(SIZE));
    }
}