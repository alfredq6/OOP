#include <ctime>
#include <stdlib.h>
#include <iostream>
using namespace std;

int getHoarBorder(int A[], int sm, int em)
{
	int i = sm - 1, j = em + 1;
	int brd = A[sm];
	int buf;
	while (i < j)
	{
		while (A[--j]> brd);
		while (A[++i]< brd);
		if (i < j)
		{
			buf = A[j];
			A[j] = A[i];
			A[i] = buf;
		};
	}
	return j;
}

int* sortHoar(int A[], int sm, int em)
{
	if (sm < em)
	{
		int hb = getHoarBorder(A, sm, em);
		sortHoar(A, sm, hb);
		sortHoar(A, hb + 1, em);
	}
	return A;
};

//------------------------------

void heapify(int A[], int pos, int n)
{
	int t, tm;
	while (2 * pos + 1 <  n)
	{
		t = 2 * pos + 1;
		if (2 * pos + 2 < n  &&  A[2 * pos + 2] >= A[t])
			t = 2 * pos + 2;
		if (A[pos] < A[t])
		{
			tm = A[pos];
			A[pos] = A[t];
			A[t] = tm;
			pos = t;
		}
		else break;
	}
}
void piramSort(int A[], int n)
{
	for (int i = n - 1; i >= 0; i--)
		heapify(A, i, n);
	while (n > 0)
	{
		int tm = A[0];
		A[0] = A[n - 1];
		A[n - 1] = tm;
		n--;
		heapify(A, 0, n);
	}
}


//------------------------------

int getRandKey(int reg = 0)
{
	if (reg > 0)
		srand((unsigned)time(NULL));
	int rmin = 0;
	int rmax = 100000;
	return (int)(((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin);
}

//------------------------------

void sortSheiker(int *a, const int n)
{
	int l, r, i, k, buf;
	k = l = 0;
	r = n - 2;
	while (l <= r)
	{
		for (i = l; i <= r; i++)
			if (a[i] > a[i + 1])
			{
				buf = a[i];
				a[i] = a[i + 1];
				a[i + 1] = buf;
				k = i;
			}
		r = k - 1;
		for (i = r; i >= l; i--)
			if (a[i] > a[i + 1])
			{
				buf = a[i];
				a[i] = a[i + 1];
				a[i + 1] = buf;
				k = i;
			}
		l = k + 1;
	}
}

int main()
{
	setlocale(LC_CTYPE, "Russian");
	const int N = 50000;
	int k[N], f[N];
	clock_t t1, t2;
	getRandKey(1);
	for (int n = 10000; n <= N; n += 10000)
	{
		for (int i = 0; i < N; i++)
			f[i] = getRandKey(0);
		cout << "n = " << n << endl;
		cout << "SortHoar ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		sortHoar(k, n, N);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl;
		for (int i = 0; i < N; i++)
			f[i] = getRandKey(0);
		cout << "PyramidSord ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		piramSort(k, n);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl;
		for (int i = 0; i < N; i++)
			f[i] = getRandKey(0);
		cout << "SortSheiker ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		sortSheiker(k, n);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl << endl << endl;
	}
	system("pause");
	return 0;
}