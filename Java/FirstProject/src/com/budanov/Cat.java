package com.budanov;
//Для того чтобы котов можно было сравнивать
//мы ему добавляем интерфейс Comparable<Cat>
//интерфейсфы добавляются через implements





//alt+insert -- насоздавай мне сама кода

public class Cat implements  Comparable<Cat>{
    int age;
    String name;

    public Cat(int age, String name) {
        this.age = age;
        this.name = name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Cat cat = (Cat) o;

        if (age != cat.age) return false;
        return name.equals(cat.name);

    }

    @Override
    public int hashCode() {
        int result = age;
        result = 31 * result + name.hashCode();
        return result;
    }

    @Override
    public int compareTo(Cat o) {
        if(this.age < o.age)
            return -1;
        if(this.age > o.age)
            return 1;
        return this.name.compareTo(o.name);
    }

    @Override
    public String toString() {
        return "Cat{" +
                "age=" + age +
                ", name='" + name + '\'' +
                '}';
    }
}
