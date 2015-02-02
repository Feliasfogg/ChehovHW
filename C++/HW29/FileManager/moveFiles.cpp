#include "FileManager.h"
void moveAllFiles(string source, string destination){
	_finddata_t *fileinfo = new _finddata_t;//��������� �� ������ ������ ��������� � ����� � ������ ��������� �����
	_finddata_t *same_fileinfo = new _finddata_t;
	int done, checker, indicatorOfSameFile;
	string mask = source + "*.*";
	done = _findfirst(mask.c_str(), fileinfo);
	if (done == -1){
		throw exception("source directory is not found!\n");
	}
	//������ ����� ������� findfirst, � ����� ������ findnext??? ����� ������� ������� � ������� ����� � ����������, ���
	//�� ����� ������ . � ".."???
	checker = _findnext(done, fileinfo);
	checker = _findnext(done, fileinfo);
	string oldName = source;
	string newName = destination;
	while (checker != -1){
		while (fileinfo->attrib &_A_SUBDIR && checker != -1){
			string src = source + fileinfo->name + "\\";
			string dst = destination + fileinfo->name;
			if (_findfirst(dst.c_str(), same_fileinfo) != -1){ //���� ��� ����������� ������������� � ����� �� ���������, ��� � ��������� - ���������� �� ������
				if (answer(same_fileinfo)){//���� ������� �������� ��������� � ������ ��� // ����� �������� ���� � �����, � ��������� ��������
					dst += "\\";
					mkdir(dst.c_str());
					moveAllFiles(src, dst);
					rmdir(src.c_str());
				}
			}
			else { //���� ���������� ������������� �� ����������� - ������� �����
				dst += "\\";
				mkdir(dst.c_str());
				moveAllFiles(src, dst);
				rmdir(src.c_str());
			}
			checker = _findnext(done, fileinfo);

			/*mkdir(dst.c_str());
			moveAllFiles(src, dst);
			rmdir(src.c_str());
			checker = _findnext(done, fileinfo);*/
		}
		if (checker != -1){
			indicatorOfSameFile = 1;
			oldName += fileinfo->name;
			newName += fileinfo->name;
			if (_findfirst(newName.c_str(), same_fileinfo) != -1){ //���� ��� �� ������ � ����� � ����� ����������
				indicatorOfSameFile = answer(same_fileinfo);//���������� �� � ��� ������
			}
			if (indicatorOfSameFile){//���� ����� ����������� �����
				if (indicatorOfSameFile != 0 && _findfirst(newName.c_str(), same_fileinfo) != -1){ //���� ����� �� ���� ����������� � ���������� - �������
					if (remove(newName.c_str()) != 0){//���� ���� ������ � �������� �� �������
						throw exception("file is open!\n");
					}
				}
				if (rename(oldName.c_str(), newName.c_str()) != 0){//���� �� �����-�� �������� �� ������� �����������/�������������
					throw exception("cant rename or move file!\n");
				}
				newName = destination;
				oldName = source;
			}
			checker = _findnext(done, fileinfo);
		}
	}
	_findclose(done);
	delete fileinfo;
}