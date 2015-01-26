#pragma once
#include <iostream>
#include <string>
using namespace std;

class Gai_tree
{
public:
	Gai_tree();
	virtual ~Gai_tree();
	//��������� ������ �� �������
	struct Offence {
		int speeding;
		int illegal_parking;
		int running_on_red;
	};
	//������ 
	class Car{
	public:
		string number;
		Offence ticket;
		Car* leftCar;
		Car* rightCar;
		Car(const string& index) : leftCar(NULL), rightCar(NULL), number(index), ticket({ 0, 0, 0 }) {}
		virtual ~Car(){
			delete leftCar;
			delete rightCar;
		}
	};
	size_t size_of_tree; //���-�� �����
	Offence& operator[](const string& index);
	void showTree(Car*);
	Car* search(const string&, Car*);
	void searchDiapasone(const string&, const string&, Car*);
	/*������������� ������� ��� ������ � ��������� �������� ����, ����� ���� ������� � ��� ������
	�� � ����� ���������������� � �������������� �������� ���������*/
	friend Car* getRoot(Gai_tree A);
	friend void print(Car*);
private:
	Car* root;//����� ������ ����
};

