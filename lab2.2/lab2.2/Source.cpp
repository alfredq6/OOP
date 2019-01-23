#include <iostream>
#include <stdio.h>
#include <ctime>

int main() {
	setlocale(0, "rus");
	int a[100][100], b[100][100], c[100][100], n;
	std::cout << "Введите n: ";
	std::cin >> n;
	FILE *f1;
	FILE *f2;
	FILE *f3;
	srand((unsigned)time(NULL));
	//////////////////////////////////////////////
	fopen_s(&f1, "A.txt", "w");
	if (f1 == NULL) {
		fprintf(f1,"%s","Невозможно совершить операцию\n");
	}
	else {
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				a[i][j] = rand() % 10;
				a[0][0] = n;
				fprintf(f1, "%d ", a[i][j]);
			}
			fprintf(f1, "\n");
		}
	}
	fclose(f1);
	//////////////////////////////////////////////
	fopen_s(&f2, "B.txt", "w");
	if (f2 == NULL) {
		fprintf(f2, "%s", "Невозможно совершить операцию\n");
	}
	else {
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < 1; j++) {
				b[i][j] = rand() % 10;
				b[0][0] = 1;
				fprintf(f1, "%d ", b[i][j]);
			}
			fprintf(f2, "\n");
		}
	}
	fclose(f2);
	/////////////////////////////////////////////
	fopen_s(&f3, "C.txt", "w");
	if (f3 == NULL) {
		fprintf(f3, "%s", "Невозможно совершить операцию\n");
	}
	else {
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < 1; j++) {
				c[i][j] = 0;
				for (int k = 0; k < n; k++) {
					c[i][j] += a[i][j] * b[k][j];
					fprintf(f3, "%d", c[i][j]);
				}
			}
			fprintf(f3, "\n");
		}
	}
	fclose(f3);
	return 0;
}