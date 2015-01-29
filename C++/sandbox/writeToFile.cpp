
/* режимы открытия файлов manual
Константа  Описание
ios_base::in    открыть файл для чтения
ios_base::out   открыть файл для записи
ios_base::ate   при открытии переместить указатель в конец файла
ios_base::app   открыть файл для записи в конец файла
ios_base::trunc удалить содержимое файла, если он существует
ios_base::binary    открытие файла в двоичном режиме
Режимы открытия файлов можно устанавливать непосредственно при создании объекта или при вызове функции open().
ofstream fout("cppstudio.txt", ios_base::app); // открываем файл для добавления информации к концу файла
fout.open("cppstudio.txt", ios_base::app); // открываем файл для добавления информации к концу файла
вместо ios_base можно также использовать синатксис ofstream::out или ofstream::app
Режимы открытия файлов можно комбинировать с помощью поразрядной логической операции или |, например: ios_base::out | ios_base::trunc - открытие файла для записи,
предварительно очистив его.
Объекты класса ofstream, при связке с файлами по умолчанию содержат режимы открытия файлов  ios_base::out | ios_base::trunc. То есть файл будет создан, если не существует.
Если же файл существует, то его содержимое будет удалено, а сам файл будет готов к записи. Объекты класса ifstream связываясь с файлом,
имеют по умолчанию режим открытия файла   ios_base::in  - файл открыт только для чтения. Режим открытия файла ещё называют — флаг,
для удобочитаемости в дальнейшем будем использовать именно этот термин.
Обратите внимание на то, что флаги ate и app по описанию очень похожи, они оба перемещают указатель в конец файла,
но флаг app позволяет производить запись, только в конец файла, а флаг ate просто переставляет флаг в конец файла и не ограничивает места записи.
*/
например
void saveR()
{

    ofstream fout;
    fout(fileName, ofstream::binary | ofstream::app);//ключ app говорит что мы открываем файл для записи в конец файла
    fout << "name " << node->name << endl;
    fout << "number " << node->number << endl << endl;
}

void readFromFile(const string &fileName)
{
    ifstream fin(fileName);
    char buff[100];

    if (!fin.is_open()) //если файл не открыт
    {
        cout << "error read file!" << endl;
    }
    else
    {
        while (!fin.eof()) //выполнять взятие строки в буфер, пока не конец файла
        {
            fin.getline(buff, 100);
            cout << buff << endl;
        }
        fin.close();
    }
}
//есть еще один метод
readFromFile(const string &fileName)
{
    ifstream fin(fileName);
    string string1;
    string string2;
    if (!fin.is_open()) //если файл не открыт
    {
        cout << "error read file!" << endl;
    }
    else
    {
        while (!fin.eof())
        {
        	//считываем построчно одну строку задругой
        	//можно еще было использовать getline(fin, name)
            fin >> string1;//сюда ложится первая счтанная строка
            fin >> string2;//сюда вторая, символы новой строки игнорируются т.е ложаться строки в которых есть буквы
        }
        fin.close();
    }
}