#include <iostream>
#include <fstream>
using namespace std;

//	Создать список, содержащий элементы целого типа. Найти сумму отрицательных элементов,
//	кратных 2, или выдать сообщение, что таких элементов нет.

/*	Программа должна содержать меню с пунктами: добавление элемента, удаление элемента, поиск элемента,
	вывод списка в консольное окно, запись списка в файл, считывание списка из файла. */

struct list {
	int value;
	list *next;
};

void insert(list *&p) {
	list *newP = new list;
	int val;
	if (newP != NULL) {
		cout << "Input integer value: ";
		cin >> val;
		newP->value = val;
		newP->next = p;
		p = newP;
	}
	else
		cout << "Oooups...\n";
}

void outputConsole(list *&p) {
	list *newP = new list;
	newP = p;
	while (p != NULL) {
		cout << " " << p->value;
		p = p->next;
	}
	p = newP;
}

void inFile(list *&p) {
	list *newP = new list;
	newP = p;
	ofstream ifile("FILE.txt");
	while (p != NULL) {
		ifile << p->value << " ";
		p = p->next;
	}
	ifile.close();
	p = newP;
}

void outFile(list *&p) {
	char buff[50];
	ifstream ofile("FILE.txt");
	if (!ofile.is_open())
		cout << "Ooooups...";
	ofile.getline(buff, 50);
	cout << "List: " << buff;
	ofile.close();
}

void find(list *&p) {
	list *newP = new list;
	newP = p;
	float sum = 0;
	while (p != NULL) {
		if ((p->value < 0) && (p->value % 2 == 0)) {
			sum += p->value;
		}
		p = p->next;
	}
	if (sum == 0)
		cout << "Ooooups again... List hasn't that elements";
	else
		cout << "Sum of finding element's = " << sum;
	p = newP;
}

void deleting(list *&p) {
	list *previous, *current, *temp;
	int del;
	cout << "Input element to deleting: ";
	cin >> del;
	if (del == p->value) {
		temp = p;
		p = p->next;
		delete temp;
	}
	else {
		previous = p;
		current = p->next;
		while (current != NULL && current->value != del) {
			previous = current;
			current = current->next;
		}
		if (current != NULL) {
			temp = current;
			previous->next = current->next;
			free(temp);
		}
	}
}

void main() {
	list *first = NULL;
	int choice;
	do {
		cout << "\n1 - Insert element into list";
		cout << "\n2 - Output in console";
		cout << "\n3 - Input in file";
		cout << "\n4 - Output from file in console";
		cout << "\n5 - Find sum of nessesary elements";
		cout << "\n6 - Delete element";
		cout << "\n0 - Exit\n";
		cin >> choice;
		switch (choice) {
		case 1: insert(first); break;
		case 2: outputConsole(first); break;
		case 3: inFile(first); break;
		case 4: outFile(first); break;
		case 5: find(first); break;
		case 6: deleting(first); break;
		}
	} while (choice != 0);
}