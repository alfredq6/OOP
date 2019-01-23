// lab8.cpp: определяет точку входа для консольного приложения.
// 
#include "stdafx.h"
#include <iostream>
#include "Header.h"


int main()
{
	int choice;
	Que *t, *ph[1];
	t = new Que;
	ph[0] = NULL;
	do {
		cout << "\nWhat do we do?\n";
		cout << "1 - Push an element in the queue\n";
		cout << "2 - Output the queue\n";
		cout << "3 - Delete an element of the queue\n";
		cout << "4 - Determine size of the queue\n";
		cout << "5 - Do task's work\n";
		cout << "0 - Exit\n";
		cin >> choice;
		switch (choice) {
		case 1: input(ph); break;
		case 2: output(ph); break;
		case 3: del(ph); break;
		case 4: size(ph); break;
		case 5: work(ph); break;
		}
	} while (choice != 0);
    return 0;
}

