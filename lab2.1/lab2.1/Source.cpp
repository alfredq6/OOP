#include <iostream>
#include <stdio.h>

int main() {
	setlocale(0, "rus");
	int n = 40;
	FILE *f1;
	FILE *f2;
	fopen_s(&f1, "lab2(1).txt", "w");
	if (f1 == NULL) {
		fprintf(f1, "%s", "Невозможно совершить операцию\n");
		return EXIT_FAILURE;
	}
	else {
		for (int i = 0; i < (n + 1); i++) {
			fprintf(f1,"%d ", i);
		}
		fprintf(f1, "\n");
	}
	fclose(f1);
	///////////////////////////////////////////////////////
	fopen_s(&f2, "lab2(1).txt", "w");
	if (f2 == NULL) {
		fprintf(f2, "%s", "Невозможно совершить операцию\n");
		return EXIT_FAILURE;
	}
	else {
		for (int i = 0; i < (n + 1); i++) {
			fprintf(f2, "%d ", i);
			fprintf(f2, "%d ", (n - i));
		}
		fprintf(f2, "\n");
	}
	fclose(f2);
	return 0;
}
