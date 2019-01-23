#include <iostream>
using namespace std;

/*	Разработать программу, реали-зующую рекурсивный алгоритм вычисления значений F(n)
	для лю-бых целых не отрицательных ар-гументов n.
*/

int myrec(int n, int m) {
	if (!n && n < 0)
		return 0;
	if (n == 0)
		return 1;
	if (n < m)
		return -1;
	else {
		if (n != 0 && n > m) {
			return (2 * myrec(n - 1, m));
		}
	}
}

void main() {
	int n, m, value;
	cout << "Enter n: ";
	cin >> n;
	cout << "Enter m: ";
	cin >> m;
	value = myrec(n, m);
	cout << "Value of: " << value << endl;
	system("pause");
}