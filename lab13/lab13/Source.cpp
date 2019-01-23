#include "stdafx.h"
#include "Heap.h"
#include <iostream>
using namespace std;
heap::CMP cmpAAA(void*  a1, void* a2)  //Функция сравнения
{
#define A1 ((AAA*)a1)
#define A2 ((AAA*)a2)
	heap::CMP
		rc = heap::EQUAL;
	if (A1->x  >  A2->x)
		rc = heap::GREAT;
	else
		if (A2->x  > A1->x)
			rc = heap::LESS;
	return rc;
#undef A2
#undef A1 
}
//-------------------------------
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	int k, choice, ch;
	heap::Heap h1 = heap::create(30, cmpAAA);
	heap::Heap h2 = heap::create(30, cmpAAA);
	heap::Heap h3 = heap::create(30, cmpAAA);
	for (;;)
	{
		cout << "1 - вывод кучи на экран" << endl;
		cout << "2 - добавить элемент" << endl;
		cout << "3 - удалить максимальный элемент" << endl;
		cout << "4 - удалить минимальный элемент" << endl;
		cout << "5 - удалить элемент по ключу" << endl;
		cout << "6 - создать второю кучу" << endl;
		cout << "7 - объединить 2 кучи в одну" << endl;
		cout << "0 - выход" << endl;
		cout << "сделайте выбор" << endl;  cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1: { cout << "первой, второй или третьей?" << endl;
			cin >> ch;
			if (ch == 1)
				h1.scan(0);
			if (ch == 2)
				h2.scan(0);
			if (ch == 3)
				h3.scan(0);
			if (ch != 1 && ch != 2 && ch != 3)
				cout << "неверный номер кучи" << endl;
		}
			break;
		case 2: {	AAA *a = new AAA;
			cout << "введите ключ" << endl; 	cin >> k;
			a->x = k;
			h1.insert(a);
		}
				break;
		case 3:   h1.extractMax();
			break;
		case 4: h1.extractMin();
			break;
		case 5: h1.extractI();
		case 6: { for (int i = 4; i < 20; i += 3) {
			AAA *b = new AAA;
			b->x = i;
			h2.insert(b);
		}
		}
			break;
		case 7: h3.unionHeap(h1.storage, h2.storage, h1.size, h2.size);
		default:  cout << endl << "Введена неверная команда!" << endl;
		}
	} return 0;
}
