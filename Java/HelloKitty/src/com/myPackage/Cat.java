package com.myPackage;

//
// *для того чтобы сравнивать котов, нжно отнаследоваться от интерфейса
// *Comparable<Cat>
// * интерфейсы добавляются через implements

public class Cat implements Comparable<Cat> {
    int _age;
    String _name;


    public Cat (int age, String name){
        this._age =age;
        this._name =name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Cat cat = (Cat) o;

        if (_age != cat._age) return false;
        return _name.equals(cat._name);
    }

    @Override
    public int hashCode() {
        int result = _age;
        result = 31 * result + _name.hashCode();
        return result;
    }

    @Override
    public int compareTo(Cat o) {
        if(this._age<o._age) return -1;
        if(this._age==o._age) return 0;
        if(this._age>o._age) return 1;
        return 0;
    }
}
