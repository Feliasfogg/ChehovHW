package com.homework;

/**
 * Created by pavel on 04-Jul-16.
 */
public class Human implements Comparable<Human> {
    int _Age;
    String _Name;
    Sex _Sex;

    public Human(int age, String name, Sex sex){
        this._Age = age;
        this._Name=name;
        this._Sex=sex;
    }

    public Sex get_Sex() {
        return _Sex;
    }

    public void set_Sex(Sex _Sex) {
        this._Sex = _Sex;
    }

    public String get_Name() {

        return _Name;
    }

    public void set_Name(String _Name) {
        this._Name = _Name;
    }

    public int get_Age() {

        return _Age;
    }

    public void set_Age(int _Age) {
        this._Age = _Age;
    }

    //переписал метод после автогенерации чтобы было понятнее
    @Override
    public boolean equals(Object o) {
        //проверка на равенство ссылок
        if (this == o) return true;
        //проверка на тождество класса
        if (o == null || getClass() != o.getClass()) return false;

        Human human = (Human) o;

        if (_Age != human._Age) return false;

        if(_Name==null) return false;
        if(!_Name.equals(human._Name)) return false;

        if(_Sex!=human._Sex) return false;

        return true;

    }

    @Override
    public int hashCode() {
        int result = _Age;
        result = 31 * result + (_Name != null ? _Name.hashCode() : 0);
        result = 31 * result + (_Sex != null ? _Sex.hashCode() : 0);
        return result;
    }

    @Override
    public String toString() {
        return "Human: Age "+_Age+" Name: "+_Name+" Sex: "+_Sex;
    }

    //сравнивать людей довольно бредовая задача, поэтому решил сравнивать их просто по возрасту
    @Override
    public int compareTo(Human o) {
        if(o._Age < this._Age ) return -1;
        if(o._Age == this._Age) return 0;
        return 1;
    }
}
