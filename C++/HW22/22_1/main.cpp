#include "main.h"
#include "date.h"
/*1. Создайте класс Date, который будет содержать информацию о дате (день,
месяц, год). С помощью механизма перегрузки операторов, определите
операцию разности двух дат (результат в виде количества дней между
датами), а также операцию увеличения даты на определенное количество
дней.*/
int main() {
    char opt;
    Date A, B;
    cout<<"\tЧто будем делать с датами?\n";
    cout<<"\t1-вычитать 2-прибавить к дате некоторое количество дней\n";
    cin>>opt;
    switch(opt) {
    case '1':
        diff();
        break;
    case '2':
        summ();
        break;
    default:
        cout<<"\nНеверная опция\t";
        break;
    }
    return 0;
}
