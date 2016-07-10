package com.budanov;
/*
*  Создать свой класс
*  Поля + конструктор
*  Геттеры+сеттеры (alt+insert)
*  equals и compareTo (все, как у кота)
*  реализовать самим toString() (прочитайте в гугле инфы море)
*
*  *сделать hashCode - прочитать зачем и реализовать
*
*  **Будем говорить про TreeMap(коллекция, упорядоченная, в виде дерева)-- добавьте пару объектов
*  и покажите их в отсортированном виде
*
* */


import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;

import java.util.Arrays;

public class HelloWorld {

    private static final Logger _logger = LogManager.getLogger(HelloWorld.class);

    public static void main(String[] args) {
        Dog dogArray[] = new Dog[3];
        dogArray[0] = new Dog("Karavan", 100);
        dogArray[1] = new Dog("KOTT", 20);
        dogArray[2] = new Dog("Sharik", 15);
        Arrays.sort(dogArray, new DogComparator());
        _logger.trace("trace");
        _logger.trace("error");
        _logger.trace("debug");

        Arrays.sort(dogArray, (o1,o2)->
        {if(o1.speed > o2.speed)
            return 1;
            if(o1.speed < o2.speed)
                return -1;
            return o1.owner.compareTo(o2.owner);
        });


        for(Dog dog: dogArray){
            System.out.println(dog);
        }
    }



    public static void main23424(String[] args) {
        Cat catArray[] = new Cat[3];

        catArray[0] = new Cat(10, "KOTT");
        catArray[1] = new Cat(8, "Vasy");
        catArray[2] = new Cat(2, "Masha");

        Arrays.sort(catArray);

        for(Cat cat : catArray){
            System.out.println(cat);
        }


    }

    public static void maintertertr(String[] args) {
        Cat cat = new Cat(3, "a");
        Cat secondCat = new Cat(3, "a");

        // равны ли коты?
        if(cat.equals(secondCat))
            System.out.println("Ok!");

        //какой кот больше??
        System.out.println(cat.compareTo(secondCat));


        if(cat==secondCat)//не сравнимаем объекты вот так
            System.out.println("lalala");
    }


    public static void main56456456(String[] args) {
        System.out.println(Integer.MAX_VALUE);
        int a = 45768;
        int b = 45768;
        Integer x = 5656;
        Integer y = 5656;
        if(a==b)
            System.out.println("int");
        if(x==y)
            System.out.println("Integer");
        if(x.intValue() == y.intValue())
            System.out.println("Integer int");
        //equals
        //Принимает object
        //говорит только ДА-НЕТ
        //есть у ЛЮБОГО класса (!!!)
        if(x.equals(y))
            System.out.println("Integer equals");

        //compareTo принимает объект того же класса
        //Возвращает int -1 0 1 (меньше равно больше)
        //этого метода нет, если не описать отдельно (!!! КАК??)
        if(x.compareTo(y) == 0)
            System.out.println("Integer compareTo");
    }



    public static void cat(Integer i){
        i = 545;
    }

    public static void main45645645(String[] args) {
        Integer a = 45; //wrapper class (класс обертка) над примитивом
        int b = 23; //Примитивный тип данных, не класс, только значение
        cat(a);
        System.out.println(a);
        for (int i = 0; i < 10; i++) {
            System.out.println(i);
        }
        for (Integer i = 0; i <10 ; i=i+1) {
            System.out.println(i);
        }
        System.out.println(Integer.MAX_VALUE);
    }

    













    //psvm -> tab
    public static void main456456456456(String[] args) {
        //sout -> tab
        System.out.println("Hello!");
        System.out.println(args[0]);
    }
// C:\Users\st.ITSTEP.000\IdeaProjects\FirstProject\src\com\budanov
//C:\Program Files (x86)\Java\jdk1.8.0_72\bin
}

