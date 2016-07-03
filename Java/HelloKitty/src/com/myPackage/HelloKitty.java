package com.myPackage;

/**
 * Created by pavel on 02-Jul-16.
 */
public class HelloKitty {
    //psvm->tab
    public static void main1(String[] args) {
        //sout->tab
        System.out.println("HelloKitty");
        for (String iterator : args) {
            System.out.println(iterator);
        }
    }

    public static void main2(String[] args) {
        //sout->tab
        //в первом случае сравнение примитивных типов
        int a = 5;
        int b = 5;
        //во втором - сравнение ссылок. Если значение меньше 127 то значение идет в кэш явы и таким образом мы
        //по сути ссылаемься на один и тот  же объект
        //если больше 127 то создается две разных ссылки и if  не отработет
        Integer c = 5;
        Integer d = 5;
        if (c == d) System.out.print("==");
//        метод equals принимает все что угодно, метод принимает object,  и говорит равны значения или нет, и все
//        больше одно значение чем другое мы не знаем equals есть у любого класса
        if (c.equals(d)) {
            System.out.println("c.equals(d)");
//
//         метод compareTo может сравнить объекты только одного класса и сказать равны они больше либо
//         меньше возвращаея соотвественно 0, 1, -1 необходимо описывать КАК!
            if (c.compareTo(d) == 0) {
                System.out.println("c.compareTo(d)");
            }
        }
    }

    public static void main(String args[]) {
        Cat cat1 = new Cat(14, "linux");
        Cat cat2 = new Cat(14, "linux");
        System.out.println(cat1 instanceof Object);
        System.out.println(cat1.equals(cat2));
    }
}
