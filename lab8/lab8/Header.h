#pragma once

using namespace std;

struct Que {
	int number;
	Que *next;
};

void input(Que *ph[]);
void output(Que *ph[]);
void del(Que *ph[]);
void size(Que *ph[]);
void work(Que *ph[]);