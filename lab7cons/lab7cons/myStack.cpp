#include "stdafx.h"
#include <iostream>
#include "myStack.h"
#include "fstream"
using namespace std;

void push(Stack *st) {
	int value;
	cout << "Input a value ";
	cin >> value;
	Stack *up = new Stack;
	up->data = value;
	up->next = st->head;
	st->head = up;
}

void work(Stack *st, Stack *st1, Stack *st2) {
	Stack *up = st->head;
	if (up == NULL)
		cout << "Stack is empty...\n";
	else {
		while (up != NULL) {
			if (up->data > 50) {
				Stack *up1 = new Stack;
				up1->data = up->data;
				up1->next = st1->head;
				st1->head = up1;
			}
			if (up->data <= 50) {
				Stack *up2 = new Stack;
				up2->data = up->data;
				up2->next = st2->head;
				st2->head = up2;
			}
			up = up->next;
		}
	}
}

void fun1(Stack *st) {
	if (st == NULL)
		cout << "Stack is empty...\n";
	else {
		cout << "Stack: ";
		while (st != NULL) {
			cout << st->data << " ";
			st = st->next;
		}
		cout << endl;
	}
}

void outcons(Stack *st, Stack *st1, Stack *st2) {
	Stack *up = st->head;
	Stack *up1 = st1->head;
	Stack *up2 = st2->head;
	int choic;
	cout << "Which stack output in console?\n0 - Stack\n1 - Stack1\n2 - Stack2\n";
	cin >> choic;
	if (choic == 0) {
		fun1(up);
	}
	if (choic == 1) {
		fun1(up1);
	}
	if (choic == 2) {
		fun1(up2);
	}
}

void fun2(Stack *st) {
	ofstream ifile("FILE.txt");
	if (st == NULL)
		ifile << "Stack is empty...\n";
	else {
		ifile << "Stack: ";
		while (st != NULL) {
			ifile << st->data << " ";
			st = st->next;
		}
		ifile << "\n";
	}
	ifile.close();
}

void input(Stack *st, Stack *st1, Stack *st2) {
	Stack *up = st->head;
	Stack *up1 = st1->head;
	Stack *up2 = st2->head;
	int ch;
	cout << "Which stack will be inputted?\n0 - Stack\n1 - Stack1\n2 - Stack2\n";
	cin >> ch;
	if (ch == 0) {
		fun2(up);
	}
	if (ch == 1) {
		fun2(up1);
	}
	if (ch == 2) {
		fun2(up2);
	}
}

void output() {
	char buff[50];
	ifstream ofile("FILE.txt");
	while (ofile.getline(buff, 50)) {
		cout << buff << endl;
	}
}

void delet(Stack *st) {
	if (st->head == NULL)
		cout << "Stack is empty...\n";
	else {
		Stack *d = st->head;
		st->head = st->head->next;
		delete d;
	}
}

void del(Stack *st) {
	int cho;
	cout << "From which stack delete element?\n0 - Stack\n1 - Stack1\n2 - Stack2\n";
	cin >> cho;
		delet(st);
	
}

void fun3(Stack *st) {
	if (st->head == NULL)
		cout << "Stack is empty...\n";
	else {
		while (st->head != NULL) {
			delet(st);
		}
	}
}

void clear(Stack *st, Stack *st1, Stack *st2) {
	int choi;
	cout << "Which stack delete?\n0 - Stack\n1 - Stack1\n2 - Stack2\n";
	cin >> choi;
	if (choi == 0) {
		fun3(st);
	}
	if (choi == 1) {
		fun3(st1);
	}
	if (choi == 2) {
		fun3(st2);
	}
}