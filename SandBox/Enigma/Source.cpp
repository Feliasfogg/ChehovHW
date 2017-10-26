#include <iostream>
#include <ctime>
#include <stdlib.h>
using namespace std;

int main(){
	unsigned int begin = clock();
	for (unsigned long long int i = 0; i <= 18000000000000000000; ++i){
		printf("%d\r", i);
	}
	unsigned int end = clock();
	cout << "all time= " << end - begin << endl;
	return 0;
}