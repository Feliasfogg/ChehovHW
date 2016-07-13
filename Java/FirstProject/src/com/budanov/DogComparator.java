package com.budanov;


import java.util.Comparator;

//Сравниватель собак
public class DogComparator implements Comparator<Dog> {

    @Override
    public int compare(Dog o1, Dog o2) {
        if(o1.speed > o2.speed)
            return 1;
        if(o1.speed < o2.speed)
            return -1;
        return o1.owner.compareTo(o2.owner);
    }
}
