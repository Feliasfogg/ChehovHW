#include "StringParser.h"
bool Stack::isFull(){
	if (counter < size){
		return false;
	}
	else {
		if (counter == size){
			return true;
		}
		else throw exception("stack overflow\n");
	}
}
bool Stack::isEmpty(){
	if (counter == 0){
		return true;
	}
	else{
		if (counter > size){
			throw exception("stack overflow\n");
		}
		else return false;
	}
}
void Stack::pushFront(char c){
	if (!isFull() && c != ')'){
		stck[counter] = c;
		++counter;
	}
}

void Stack::show(){
	for (int i = 0; i < counter; ++i){
		cout << stck[i] << endl;
	}
}
void Stack::compare(int p, string& output){
	int temp;
	if (p == 0){//���� ������ ����������� ����� - ���������� ��� �� �����
		for (int j = counter - 1; j >= 0; --j){
			if (stck[j] != '('){
				output += stck[j];
				stck[j] = '\0';
				--counter;
			}
			else {
				if (stck[j] == '('){
					stck[j] = '\0';
					--counter;
					break;
				}
			}
		}
		return;
	}

	for (int i = counter - 1; i > 0; --i){
		temp = prior(stck[i]);
		if (stck[i] == '(') break;
		if (temp >= p && p != 1){//���� ����������� ������� �� (
			output += stck[i];
			stck[i] = '\0';
			--counter;
		}
	}
}