#include <iostream>
#include "Time.h"
using namespace std;
/*�������� ����� �����, � ������� ����������� �������� ��������,
���������, ���������, ����� � ����� �� �����. ����������� ����������� �������
�� ������������� ������� am (pm): 10:00 pm = 22:00, 12:00 pm =00:00 */
int main() {
    MyTime A("18:21:14");
    A.getTimeEu();
    A.getTimeUs();
    MyTime B("21:15:14");
    B.getTimeEu();
    B.getTimeUs();
    MyTime C;
    C=A+B;
    cout<<"t1 + t2"<<endl;
    C.getTimeEu();
    C=B-A;
    cout<<"t1 - t2"<<endl;
    C.getTimeEu();
    C=A;
    cout<<"t1=t2"<<endl;
    C.getTimeEu();
    MyTime E(B);
    B.getTimeEu();
    if(C==A) {
        cout<<"=="<<endl;
    }
    MyTime D;
    D.convert("6:12:18 pm");
    D.getTimeEu();
    return 0;
}
