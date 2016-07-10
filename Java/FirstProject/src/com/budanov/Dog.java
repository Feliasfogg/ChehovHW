package com.budanov;


public class Dog {
    String owner;
    int speed;

    public Dog(String owner, int speed) {
        this.owner = owner;
        this.speed = speed;
    }

    @Override
    public String toString() {
        return "Dog{" +
                "owner='" + owner + '\'' +
                ", speed=" + speed +
                '}';
    }
}
