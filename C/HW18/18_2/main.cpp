/*2. Написать "Морской бой" для игры человека против компьютера.
Предусмотреть за человека возможность автоматической (расстановку
осуществляет кораблей компьютер случайным образом) и ручной расстановки
своих кораблей. Стоимость задания существенно повышается, если
компьютер при стрельбе будет обладать логикой (т. е. не производить
выстрелы "рандомайзом").*/
#include "main.h"
int main() {
    char select;
    cout << "\tморской бой\n";
    cout<<"\tВы желаете сами установить положение кораблей или\n\tих выберет компьютер y/n\n";
    cin>>select;
    switch(select) {
    case 'y':
        shipSetup();
        break;
    case 'n':
        shipAutoSetup();
        break;
	default :
        cout<<"\tВыберите верную поцию\n";
        break;
    }
    return 0;
}
