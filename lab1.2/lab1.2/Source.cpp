#include <iostream>
using namespace std;

int mn(int m, ...) {
	int min = 0;
	int *p = &m;
	
	for (int i = 0; i <= m; i++) {
		if (*(++p) < min) {
			min = *p;
		}
		return min;
	}

}
void main() {
	cout << mn(2, 6, 1, 7, 5, 0) << endl;
	system("pause");
}