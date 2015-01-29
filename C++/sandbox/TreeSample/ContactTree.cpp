#include "ContactTree.h"

ContactTree::ContactTree() : root(NULL), sizeOfTree(0)
{
}


ContactTree::~ContactTree()
{
}
int& ContactTree::operator[](const int index){
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

ContactTree::Subscriber* ContactTree::searchByName(const int index){
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

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void ContactTree::deleteContact(const int index){
	//����� ������ ��� �� �� ������� ���������� "��������� ����", �� �������������� �������� � ���, �� ��������� �����

	Subscriber* deletedContact = searchByName(index);//��������� �������
	Subscriber* minFromRightBranch = NULL;//���� ��������� �� ������� �� ���������, ����� ������ ��� ����� "�����" ���� � ������ �� ���������� �����
	Subscriber* maxFromLeftBranch = NULL;//���� ���������� �� ������� ����� ���������, ��� ����� ����� "������" ���� � ����� �� ���������� �����

	//������ ���� ������ ����, ���� - ��� ���� � �������� ���� ��  ������ �������
	if (deletedContact){
		if (deletedContact->left == NULL && deletedContact->right == NULL){
			if (deletedContact == deletedContact->parent->left){
				//������������ �������� ��������� �� ������ � ����������� �� ���� � ����� ������� ����� ����
				deletedContact->parent->left = NULL;
				delete deletedContact;
				//�� ������� ��������� �� ���������, �� � ����� ��������� �������� �����, �������������� ������� �� �������
				return;
			}
			else {
				deletedContact->parent->right = NULL;
				delete deletedContact;
				return;
			}
		}
	}

	//������ ���� � ���������� ���� ���� ����� ������, �� �� ����� ���������� ����������� ��������� �� ������� ����, ��� ���� ���� �� ����� ����� �� �� ���������
	if (deletedContact != NULL && deletedContact->right != NULL){
		minFromRightBranch = next(deletedContact);//������� ����� ����� ������� � ������ �����
		//� ���������� ��������� ����� ���� �������� �����, �� ����� ���� ������� ������

		if (minFromRightBranch){
			//���� ������� ������ ������������ �������� �� ���� � ���������
			deletedContact->name = minFromRightBranch->name;
			deletedContact->number = minFromRightBranch->number;

			if (minFromRightBranch->right == NULL){//���� �������� ������ � ������ "������" ����, �.� �� ����, �.� (����� ����� ������ ����)

				if (minFromRightBranch == minFromRightBranch->parent->right){
					minFromRightBranch->parent->right = NULL;
				}
				else {
					minFromRightBranch->parent->left = NULL; //������������ ������ ��������� � �������� �� ������, ����� �� �������;
				}

				delete minFromRightBranch;//������� ����
			}
			else {
				//���� � "������" ���� ������ �����, ������������ ����� ��������� � �������� �� ��� ������ �����
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
	//������ ���� ������ ����� ����, �� ���� ����� �����
	else{
		if (deletedContact != NULL && deletedContact->left != NULL){
			maxFromLeftBranch = prev(deletedContact);//������� ����� "������" ���� � ����� �� ���������� �����

			if (maxFromLeftBranch){
				//���� ������� ������ ������������ �������� �� ���� � ���������
				deletedContact->name = maxFromLeftBranch->name;
				deletedContact->number = maxFromLeftBranch->number;

				if (maxFromLeftBranch->left == NULL){//���� �������� ����� � ������ "�������" ����, �.� �� ����, �.� ������ ������ ����

					if (maxFromLeftBranch == maxFromLeftBranch->parent->left){
						maxFromLeftBranch->parent->left = NULL;
					}
					else {
						maxFromLeftBranch->parent->right = NULL; //������������ ������ ��������� � �������� �� ������, ����� �� �������;
					}

					delete maxFromLeftBranch;//������� ����
				}
				else {
					//���� � "�������" ���� ����� �����,
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
		//���� �� �������� � �������� ������ ���� ��� ��������
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

ContactTree::Subscriber* getRoot(ContactTree* A){
	return A->root;
}
