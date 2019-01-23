#include "stdafx.h"
#include "Hash.h"
#include <iostream>
#include <ctime>

using namespace std;
struct AAA
{
	char *key;
	char *mas;
	AAA(char*k, char*z)
	{
		key = k;  mas = z;
	} AAA() {}
};
//-------------------------------
char *key(void* d)
{
	AAA* f = (AAA*)d;   return f->key;
}
//-------------------------------
void AAA_print(void* d)
{
	cout << " ключ " << ((AAA*)d)->key << " - " << ((AAA*)d)->mas << endl;
}
//-------------------------------
int main(int argc, char* argv[])
{
	setlocale(0, "rus");
	AAA a1("a", "one"), a2("b", "two"), a3("c", "three"), a4("d", "four");
	int siz = 10, choice;
	char *k = new char;
	clock_t t1, t2;
	cout << "Введите размер хеш-таблицы" << endl; 	cin >> siz;
	Object H = create(siz, key);
	for (;;)
	{
		cout << "1 - вывод хеш-таблицы" << endl;
		cout << "2 - добавление элемента" << endl;
		cout << "3 - удаление элемента" << endl;
		cout << "4 - поиск элемента" << endl;
		cout << "0 - выход" << endl;
		cout << "сделайте выбор" << endl;   cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1: H.scan(AAA_print);  break;
		case 2: { AAA *a = new AAA;
			k = new char;
			char *str = new char[20];
			cout << "введите ключ" << endl;	cin >> k;
			a->key = k;
			cout << "введите строку" << endl; cin >> str;
			a->mas = str;
			if (H.N == H.size)
				cout << "Таблица заполнена" << endl;
			else
				H.insert(a);
		} break;
		case 3: {  cout << "введите ключ для удаления" << endl;
			cin >> k;
			H.deleteByKey(k);
		}  break;
		case 4: {  cout << "введите ключ для поиска" << endl;
			cin >> k;
			t1 = clock();
			if (H.search(k) == NULL)
				cout << "Элемент не найден" << endl;
			else 
				AAA_print(H.search(k));
			t2 = clock();
			cout << "Прошло " << t2 - t1 << " тактов времени" << endl;
		}  break;
		}
	}
	return 0;
}
