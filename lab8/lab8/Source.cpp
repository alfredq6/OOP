#include "stdafx.h"
#include <iostream>
#include "Header.h"

void input(Que *ph[]) {
	int value;
	cout << "Input element of queue: ";
	cin >> value;
	cout << endl;
	Que *t = new Que;
	t->next = NULL;
	if (ph[0] == NULL)
		ph[0] = ph[1] = t;
	else {
		t->number = value;
		ph[1]->next = t;
		ph[1] = t;
	}
}

void output(Que *ph[]) {
	Que *t = ph[0];
	if (t == NULL) {
		cout << "Que is empty\n";
	}
	else {
		cout << "Queue: ";
		while (t != NULL) {
			cout << t->number << " ";
			t = t->next;
		}
		cout << endl;
	}
}

void size(Que *ph[]) {
	int n = 0;
	Que *t = ph[0];
	if (t == NULL) {
		cout << "Que is empty\n";
	}
	else {
		cout << "Size of queue: ";
		while (t != NULL) {
			n++;
			t = t->next;
		}
		cout << n;
	}
}

void del(Que *ph[]) {
	Que *t = ph[0];
	if (t == NULL) {
		cout << "Que is empty\n";
	}
	else {
		ph[0] = ph[0]->next;
		delete t;
	}
}

void work(Que *ph[]) {
	int n = 0;
	Que *t = ph[0];
	if (t == NULL) {
		cout << "Queue is empty\n";
	}
	else {
		while (n == 0) {
			if (t->next->number < 0) {
				Que *b = t->next;
				t->next = t->next->next;
				delete b;
				n++;
			}
			else {
				t = t->next;
			}
		}
	}
}