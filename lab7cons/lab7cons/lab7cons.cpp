// lab7cons.cpp: определяет точку входа для консольного приложения.
//
#include "stdafx.h"
#include <iostream>
#include "myStack.h"
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	int choice;
	Stack *stk = new Stack; 
	stk->head = NULL; 
	Stack *stk1 = new Stack;
	stk1->head = NULL;
	Stack *stk2 = new Stack;
	stk2->head = NULL;
	do {
		cout << "What do we do?\n";
		cout << "1 - Push an element in stack\n";
		cout << "2 - Divide stack\n";
		cout << "3 - Output stack in console\n";
		cout << "4 - Input stack in file\n";
		cout << "5 - Output info from file\n";
		cout << "6 - Delete element from stack\n";
		cout << "7 - Clear stack\n";
		cout << "0 - Exit\n";
		cin >> choice;
		switch (choice) {
		case 1: push(stk); break;
		case 2: work(stk, stk1, stk2); break;
		case 3: outcons(stk, stk1, stk2); break;
		case 4: input(stk, stk1, stk2); break;
		case 5: output(); break;
		case 6: del(stk2); break;
		case 7: clear(stk, stk1, stk2); break;
		}
	} while (choice != 0);
	return 0;
}