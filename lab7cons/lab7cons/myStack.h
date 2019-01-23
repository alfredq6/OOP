#pragma once
struct Stack {
	int data;            
	Stack *head;		 
	Stack *next;
};

void push(Stack *st);
void output();
void outcons(Stack *st, Stack *st1, Stack *st2);
void input(Stack *st,Stack *st1, Stack *st2);
void work(Stack *st, Stack *st1, Stack *st2);
void del(Stack *st);
void clear(Stack *st, Stack *st1, Stack *st2);