#include <iostream>
#include <ctime>
using namespace std;

void selectSort(int arr[], int size) {
	int k, i, j;
	for (i = 0; i < size - 1; i++) {
		for (j = i + 1, k = i; j < size; j++)
			if (arr[j] < arr[k])
				k = j;
		int c = arr[k];
		arr[k] = arr[i];
		arr[i] = c;
	}
}

void ShellSort(int arr[], int size) {
	int d = (size / 2), i, j;
	while (d > 0) {
		for (i = 0; i < (size - d); i++) {
			j = i;
			while (j >= 0 && arr[j] > arr[j + d]) {
				int c = arr[j];
				arr[j] = arr[j + d];
				arr[j + d] = c;
				j--;
			}
		}
		d = d / 2;
	}
}

void main() {
	int sizeA, sizeB, sizeC = 0;
	clock_t x, y;
	int C[10];
	srand((unsigned)time(NULL));
	cout << "Enter size of array A: "; cin >> sizeA;
	int A[10];
	for (int i = 0; i < sizeA; i++) {
		A[i] = rand() % 100;
		if (A[i] % 2 == 1) {
			C[sizeC] = A[i];
			sizeC++;
		}
	}
	cout << "Enter size of array B: "; cin >> sizeB;
	int B[10];
	for (int i = 0; i < sizeB; i++) {
		B[i] = rand() % 100;
		if (B[i] % 2 == 1) {
			C[sizeC] = B[i];
			sizeC++;
		}
	}
	cout << "Array A: ";
	for (int i = 0; i < sizeA; i++)
		cout << A[i] << " ";
	cout << endl;
	cout << "Array B: ";
	for (int i = 0; i < sizeB; i++)
		cout << B[i] << " ";
	cout << endl;
	cout << "Array C: ";
	for (int i = 0; i < sizeC; i++)
		cout << C[i] << " ";
	cout << endl;
	x = clock();
	ShellSort(A, sizeA);
	y = clock();
	cout << "Function time:" << y - x << endl;
	cout << "Sorted array C: ";
	for (int i = 0; i < sizeC; i++)
		cout << C[i] << " ";
	cout << endl;
	x = clock();
	selectSort(A, sizeA);
	y = clock();
	cout << "Function time:" << y - x << endl;
	cout << "Sorted array A: ";
	for (int i = 0; i < sizeA; i++)
		cout << A[i] << " ";
	cout << endl;
	system("pause");
}