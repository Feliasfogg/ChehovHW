#include <iostream>
#include <vector>
#include <string>
#include <stdlib.h>
#include <time.h>
using namespace std;
//9. ����� ������ ���� � ������� ����, �������� �� ������.
//�� ������ ���� ����� �������� ������ �� ������� �� ���������, ����� ����� � ������ ������������ ����������� �� + -90 �������� 
//���� �������� ������� �����������.����� ����� �� ������ ��� ����� �� ���� ������, � �������� ��� ������.
//������� ����� ������� ����� ���� �� ����� �� ����� ���������� ������ ?

class Player;
class Cell{
public:
	Cell() :wasHere(false) {};
	~Cell(){};
	void show(){
		if (wasHere == true) cout << "*";
		else cout << ".";
	}
	friend Player;
private:
	bool wasHere;
};
class Field{
public:
	Field(){};
	Field(pair<int, int> size, Cell copy) {
		vector<vector<Cell>> f(size.first, vector<Cell>(size.second, copy));
		field = f;
		beg.first = field.begin();
		beg.second = (*field.begin()).begin();
	};
	~Field(){};

	void out() {
		for (vector<vector<Cell>>::iterator it = field.begin(); it != field.end(); ++it){
			for (vector<Cell>::iterator it2 = (*it).begin(); it2 != (*it).end(); ++it2){
				(*it2).show();
			}
			cout << endl;
		}
		cout << endl;
	}

	friend Player;
	vector<vector<Cell>> field;
	pair<vector<vector<Cell>>::iterator, vector<Cell>::iterator> beg;

};

class Player{
public:
	Player(){};
	Player(pair<vector<vector<Cell>>::iterator, vector<Cell>::iterator> pos) : currentPosition(pos), prevPosition(pos){};
	~Player(){};
	void mark(){
		if ((*currentPosition.second).wasHere == false){
			(*currentPosition.second).wasHere = true;
		}
		else {
			cout << "Player was here" << endl;
		}
	}

	void switcher(int t, Field &field){
		switch (t)
		{
		case 1: goRight(field);
			mark();
			break;
		case 2: goLeft(field);
			mark();
			break;
		case 3: goForward(field);
			mark();
			break;
		default:
			break;
		}
	}

	void goRight(Field &field){
		ptrdiff_t dist_row = distance(vector<vector<Cell>>::iterator(field.field.begin()), vector<vector<Cell>>::iterator(currentPosition.first));

		ptrdiff_t dist_col = distance(vector<Cell>::iterator((*currentPosition.first).begin()), vector<Cell>::iterator(currentPosition.second));//��� prevPosition.second

		if (currentPosition.first != prevPosition.first){//���������� ������ �� �� ������ � �����/����� ��� �����

			if (currentPosition.first > prevPosition.first){//������� ������ �� ����� ��� ������
				if (currentPosition.second != (*currentPosition.first).begin()){
					prevPosition = currentPosition;
					currentPosition.second = --currentPosition.second;
				}
			}
			else {
				if (currentPosition.second != (*currentPosition.first).end()){//������ ������
					prevPosition = currentPosition;
					currentPosition.second = ++currentPosition.second;
				}
			}

		}
		else {//�� ������ �����
			if (currentPosition.second > prevPosition.second){//������ ������
				if (currentPosition.first != field.field.end()){
					prevPosition = currentPosition;
					currentPosition.first = ++currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}
			else {//�����
				if (currentPosition.first != field.field.begin()){
					prevPosition = currentPosition;
					currentPosition.first = --currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}

		}
	}

	void goLeft(Field &field){
		ptrdiff_t dist_row = distance(vector<vector<Cell>>::iterator(field.field.begin()), vector<vector<Cell>>::iterator(currentPosition.first));
		ptrdiff_t dist_col = distance(vector<Cell>::iterator((*currentPosition.first).begin()), vector<Cell>::iterator(currentPosition.second));

		if (currentPosition.first != prevPosition.first){//���������� ������ �� �� ������ � �����/����� ��� �����

			if (currentPosition.first > prevPosition.first){//������� ������ �� ����� ��� ������
				if (currentPosition.second != (*currentPosition.first).end()){
					prevPosition = currentPosition;
					currentPosition.second = ++currentPosition.second;
				}
			}
			else {
				if (currentPosition.second != (*currentPosition.first).begin()){//������ ������
					prevPosition = currentPosition;
					currentPosition.second = --currentPosition.second;
				}
			}

		}
		else {//�� ������ �����
			if (currentPosition.second > prevPosition.second){//������ �����
				if (currentPosition.first != field.field.begin()){
					prevPosition = currentPosition;
					currentPosition.first = --currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}
			else {//������
				if (currentPosition.first != field.field.end()){
					prevPosition = currentPosition;
					currentPosition.first = ++currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}

		}
	}
	void goForward(Field &field){
		ptrdiff_t dist_row = distance(vector<vector<Cell>>::iterator(field.field.begin()), vector<vector<Cell>>::iterator(currentPosition.first));
		ptrdiff_t dist_col = distance(vector<Cell>::iterator((*currentPosition.first).begin()), vector<Cell>::iterator(currentPosition.second));

		if (currentPosition.first != prevPosition.first){
			if (currentPosition.first > prevPosition.first){
				if (currentPosition.first != field.field.end()){
					prevPosition = currentPosition;
					currentPosition.first = ++currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}
			else {
				if (currentPosition.first != field.field.begin()){
					prevPosition = currentPosition;
					currentPosition.first = --currentPosition.first;
					currentPosition.second = (*currentPosition.first).begin() + dist_col;
				}
			}
		}
		else {
			if (currentPosition.second > prevPosition.second){
				if (currentPosition.second != (*currentPosition.first).end()){
					prevPosition = currentPosition;
					currentPosition.second = ++currentPosition.second;
				}
			}
			else {
				if (currentPosition.second != (*currentPosition.first).begin()){
					prevPosition = currentPosition;
					currentPosition.second = --currentPosition.second;
				}
			}
		}
	}

private:
	pair<vector<vector<Cell>>::iterator, vector<Cell>::iterator> prevPosition;
	pair<vector<vector<Cell>>::iterator, vector<Cell>::iterator> currentPosition;
};

int main(){
	srand(time(NULL));
	Cell copy;

	Field F(pair<int, int>(20, 30), copy);//�������� ���� 5*5
	Player P(pair<vector<vector<Cell>>::iterator, vector<Cell>::iterator>(F.beg));//�������� � ������������� ������� ������ 0*0
	for (int i = 0; i < 50; ++i){
		P.switcher(rand() % 3 + 1, F);
		F.out();
		int s = time(0);
		while (s == time(0));
		system("cls");
	}

	return 0;
}