package com.homework;

import java.util.Map;
import java.util.Objects;
import java.util.TreeMap;

/**
 * Created by pavel on 04-Jul-16.
 */
public class Program {

    public static void main(String[] args) {
        Human pavel = new Human(25, "Pavel", Sex.Man);
        Human kostya = new Human(25, "Kostya", Sex.Man);
        Human ilya = new Human(25, "Ilya", Sex.Man);

        System.out.println(pavel.toString());
        System.out.println(pavel.equals(kostya));
        System.out.println(pavel.compareTo(kostya));

        TreeMap treeMap = new TreeMap();
        treeMap.put("Pavel", pavel);
        treeMap.put("Kostya", kostya);
        treeMap.put("Ilya", ilya);

        for (Object o: treeMap.entrySet()) {
            Map.Entry k = (Map.Entry)o;
            System.out.println(k.getKey()+" "+ k.getValue());
        }

    }
}
