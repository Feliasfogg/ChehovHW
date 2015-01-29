#include "ContactTree.h"

ContactTree::ContactTree() : root(NULL), sizeOfTree(0)
{
}


ContactTree::~ContactTree()
{
}
string& ContactTree::operator[](const string& index){
	Subscriber** current = &root;
	Subscriber* pr = NULL;
	while ((*current) != NULL){
		pr = (*current);
		if ((*current)->name == index){
			return (*current)->number;
		}
		if (index < (*current)->name){
			current = &((*current)->left);
		}
		else {
			current = &((*current)->right);
		}
	}
	(*current) = new Subscriber(index);
	(*current)->parent = pr;
	++sizeOfTree;
	return (*current)->number;
}
void ContactTree::insert(const string& index, const string& number) {
	Subscriber** current = &root;
	Subscriber* pr = NULL;
	while ((*current) != NULL){
		pr = (*current);
		if ((*current)->name == index){
			(*current)->number = number;
		}
		if (index < (*current)->name){
			current = &((*current)->left);
		}
		else {
			current = &((*current)->right);
		}
	}
	(*current) = new Subscriber(index);
	(*current)->parent = pr;
	(*current)->number = number;
	(*current)->name = index;
	++sizeOfTree;
}
//изменение номера рекурсивное
void ContactTree::editNumber(const string& index, const string& newNumber, Subscriber* node){
	if (node != NULL){
		editNumber(index, newNumber, node->left);
		if (node->name == index){
			node->number = newNumber;
		}
		editNumber(index, newNumber, node->right);
	}
}

//изменение имени рекурсивное
void ContactTree::editName(const string& index, const string& newName, Subscriber* node){
	if (node != NULL){
		editName(index, newName, node->left);
		if (node->name == index){
			node->name = newName;
		}
		editName(index, newName, node->right);
	}
}
//надо придумать как сделать поиск по имени рекурсивным, это избавит нас от сложноcтей в случае если имена изменены
//поиск по имени бинарный,
ContactTree::Subscriber* ContactTree::searchByName(const string& index){
	Subscriber** current = &root;
	int checker = 0;
	while ((*current) != NULL){
		if ((*current)->name == index){
			cout << "found!" << endl;
			print(*current);
			checker = 1;
			return *current;
		}
		if (index < (*current)->name){
			current = &((*current)->left);
		}
		else {
			current = &((*current)->right);
		}
	}
	if (!checker) {
		cout << "nothing found" << endl;
		return NULL;
	}
	else return *current;
}
//поиск по номеру рекурсивный
void ContactTree::searchByNumber(const string& num, Subscriber* node){
	if (node != NULL){
		searchByNumber(num, node->left);
		if (node->number == num){
			cout << "found!" << endl;
			print(node);
		}
		searchByNumber(num, node->right);
	}
}

void ContactTree::showFromLeft(Subscriber* node){
	if (node != NULL){
		if (node->left){
			showFromLeft(node->left);
		}
		print(node);
		if (node->right){
			showFromLeft(node->right);
		}
	}
}
void ContactTree::showFromRight(Subscriber* node){
	if (node != NULL){
		showFromRight(node->right);
		print(node);
		showFromRight(node->left);
	}
}

ContactTree::Subscriber* ContactTree::max(Subscriber* node){
	if (node != NULL){
		while (node->right != NULL){
			node = node->right;
		}
		return node;
	}
	else return NULL;
}
ContactTree::Subscriber* ContactTree::min(Subscriber* node){
	if (node != NULL){
		while (node->left != NULL){
			node = node->left;
		}
		return node;
	}
	else return NULL;
}
ContactTree::Subscriber* ContactTree::next(Subscriber* node){
	if (node != NULL && node->right != NULL){
		return min(node->right);
	}
	else return NULL;
}
ContactTree::Subscriber* ContactTree::prev(Subscriber* node){
	if (node != NULL&&node->left != NULL){
		return max(node->left);
	}
	else return NULL;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void ContactTree::deleteContact(const string& index){
	//Важно понять что мы не удаляем структурно "удаляемый узел", мы перезаписываем значения в нем, но сохраняем связи

	Subscriber* deletedContact = searchByName(index);//удаляемый контакт
	Subscriber* minFromRightBranch = NULL;//узел следующий по индексу за удаляемым, проще говоря это самый "левый" узел в правой от удаляемого ветки
	Subscriber* maxFromLeftBranch = NULL;//узел предыдущий по индексу перед удаляемым, это будет самый "правый" узел в левой от удаляемого ветке

	//случай если просто лист, лист - это узел у которого нету ни  одного потомка
	if (deletedContact){
		if (deletedContact->left == NULL && deletedContact->right == NULL){
			if (deletedContact == deletedContact->parent->left){
				//переписываем родителю указатели на путсые в зависимости от того с какой стороны стоял лист
				deletedContact->parent->left = NULL;
				delete deletedContact;
				//мы удалили структуру по указателю, но в самом указателе оказался мусор, принулдительно Выходим из функции
				return;
			}
			else {
				deletedContact->parent->right = NULL;
				delete deletedContact;
				return;
			}
		}
	}

	//случай если у удаляемого узла есть ветка справа, то на место удаляемого подставляем следующий по индексу узел, при этом есть ли слева ветка мы не учитываем
	if (deletedContact != NULL && deletedContact->right != NULL){
		minFromRightBranch = next(deletedContact);//находим самый левый элемент в правой ветке
		//у найденного эелемента точно нету потомков слева, но могут быть потомки справа

		if (minFromRightBranch){
			//если элемент найден переписываем значения из него в удаляемый
			deletedContact->name = minFromRightBranch->name;
			deletedContact->number = minFromRightBranch->number;

			if (minFromRightBranch->right == NULL){//если потомков справа у нашего "левого" нету, т.е он лист, т.к (слева точно ничего нету)

				if (minFromRightBranch == minFromRightBranch->parent->right){
					minFromRightBranch->parent->right = NULL;
				}
				else {
					minFromRightBranch->parent->left = NULL; //переписываем правый указатель у родителя на пустой, левый не трогаем;
				}

				delete minFromRightBranch;//удаляем лист
			}
			else {
				//если у "левого" есть правая ветка, переписываем левый указатель у родителя на эту правую ветку
				if (minFromRightBranch == minFromRightBranch->parent->right){
					minFromRightBranch->parent->right = minFromRightBranch->right;
					minFromRightBranch->right->parent = minFromRightBranch->parent;
				}
				else {
					minFromRightBranch->parent->left = minFromRightBranch->right;
					minFromRightBranch->right->parent = minFromRightBranch->parent;
				}
				delete minFromRightBranch;
			}

		}
	}
	//случай если справа ветки нету, но есть ветка слева
	else{
		if (deletedContact != NULL && deletedContact->left != NULL){
			maxFromLeftBranch = prev(deletedContact);//находим самый "правый" узел в левой от удаляемого ветке

			if (maxFromLeftBranch){
				//если элемент найден переписываем значения из него в удаляемый
				deletedContact->name = maxFromLeftBranch->name;
				deletedContact->number = maxFromLeftBranch->number;

				if (maxFromLeftBranch->left == NULL){//если потомков слева у нашего "правого" нету, т.е он лист, т.к справа ничего нету			

					if (maxFromLeftBranch == maxFromLeftBranch->parent->left){
						maxFromLeftBranch->parent->left = NULL;
					}
					else {
						maxFromLeftBranch->parent->right = NULL; //переписываем правый указатель у родителя на пустой, левый не трогаем;
					}

					delete maxFromLeftBranch;//удаляем лист
				}
				else {
					//Если у "правого" есть левая ветка,
					if (maxFromLeftBranch == maxFromLeftBranch->parent->left){
						maxFromLeftBranch->parent->left = maxFromLeftBranch->left;
						maxFromLeftBranch->left->parent = maxFromLeftBranch->parent;
					}
					else {
						maxFromLeftBranch->parent->right = maxFromLeftBranch->left;
						maxFromLeftBranch->left->parent = maxFromLeftBranch->parent;
					}
					delete maxFromLeftBranch;
				}
			}
		}
	}
	if (deletedContact == NULL){
		//если мы ошиблись и передали пустую ноду для удаления
		cout << "delete error" << endl;
	}

}

void ContactTree::print(Subscriber* node){
	if (node->parent){
		cout << "parent " << node->parent->name << endl;
	}
	cout << "name " << node->name << endl;
	cout << "number " << node->number << endl << endl;
}

ContactTree::Subscriber* getRoot(const ContactTree& A){
	return A.root;
}
void ContactTree::saveAtFile(const string& fileName, const string& mode){
	/*тут костыль т.к функция самой записи в файл рекурсивная, значит мы будем файл постоянно переоткрыввать, а значит нам нужно использовать флаг ofstream::app
	для записи в конец файла, иначе мы увидим лишь последюю строчку в базе, а т.к мы испотльзуем для записи флажок app возникает необходимость
	перед запуском рекурсивной записи очистить прыдыдущий файл, если он существует*/
	ofstream fout(fileName, ofstream::trunc);
	saveR(root, fileName, mode);
}
void ContactTree::saveR(Subscriber* node, const string& fileName, const string& mode){//рекурсивный обход дерева и запись в файл
	if (node){
		saveR(node->left, fileName, mode);
		if (mode == "t" || mode == "T"){
			ofstream fout(fileName, ofstream::out | ofstream::app);//ключ app говорит что мы открываем файл для записи в конец файла
			fout << "name " << node->name << endl;
			fout << "number " << node->number << endl << endl;
		}
		else {
			if (mode == "b" || mode == "B"){
				ofstream fout(fileName, ofstream::binary | ofstream::app);//ключ app говорит что мы открываем файл для записи в конец файла
				fout << node->name << endl;
				fout << node->number << endl;
			}
		}
		saveR(node->right, fileName, mode);
	}
}
void ContactTree::readFromFile(const string& fileName){
	ifstream fin(fileName);
	string name;
	string number;
	if (!fin.is_open()){//если файл не открыт
		cout << "error read file!" << endl;
	}
	else{
		while (!fin.eof()){
			//можно еще было использовать getline(fin, name)
			fin >> name;
			fin>>number;
			insert(name, number);
		}
		fin.close();
	}
}