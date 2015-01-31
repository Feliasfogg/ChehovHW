#include "Reader.h"


Reader::Reader(const string& nameOfFile) :name(nameOfFile), fin(nameOfFile)
{
	/*�. � ������ ����� ������ ��������� ������ ���� ������� ������� ������ � ifstream, �� �� ������ ���
	�� �������� ������� ����� ����� ���-�� � ������ ������ � ����� �����. ����� ������� ������ ������������
	������ ������������� ������ ������� ������� ���������(���������������) ������, � ����� ����� �����, �����
	���� ��������� ��� ������ �����*/
}


Reader::~Reader()
{
}

void Reader::read(){
	string firstName;
	string lastName;
	if (name.find(".csv")==string::npos){//�������� ������������ ���������� �����
		exception ex("file have uncorrectly extension\n");
		throw ex;
	}
	//�.� ����� ����� ��� ������ ��� ������� ������ �� �� ������ ��� ��������� fin.open("string");
	if (!fin.is_open()){//�������� ������� ������ �����
		exception ex("file if not found\n");
		throw ex;
	}
	while (!fin.eof()){
		fin >> firstName;
		fin >> lastName;
		cout << firstName << endl;
		cout << lastName << endl;
	}
	fin.close();
}