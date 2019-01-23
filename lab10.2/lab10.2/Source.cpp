#include <iostream>
using namespace std;

/*		Разработать программу, реали-зующую рекурсивный алгоритм вычисления значений F(m, n)
		для любых целых не отрицательных аргументов m и n.
*/

int myrec(int m, int n) {
	if (!m || !n || m < 0 || n < 0) {
		return 0;
	}
	if ((n + m) % 2 == 0) {
		if (n > m) {
			cout << "Max value: " << n << endl;
			return n;
		}
		if (m > n) {
			cout << "Max value: " << m << endl;
			return m;
		}
	}
	else {
		return myrec((n + m + 1) / 2, n + 1) + myrec(m, (n + m + 1) / 2);
	}
}

void main() {
	int n, m;
	cout << "Enter n: ";
	cin >> n;
	cout << "Enter m: ";
	cin >> m;
	cout << "\nValue of: " << myrec(m, n) << endl;
	system("pause");
}