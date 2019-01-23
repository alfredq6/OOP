#include <iostream>
using namespace std;

struct stack
{
	int data;
	stack *next;
};

int pop(stack* &st); // ���������� ��������
void push(stack* &st, int d); // ���������� ��������

int main()
{
	stack *p = nullptr;
	push(p, 100);    //����� 100 � � ����
	push(p, 200);    //����� 200 � � ����
	pop(p);          //����� �������� �������� = 200
	pop(p);          // ����� �������� �������� = 100  
	system("pause");
}
int pop(stack* &st) // ���������� ��������
{
	int tmp = st->data; 	stack *pv = st;
	st = st->next;       // �������� ���������� �������������� �������
	delete pv;           // ������������� ������ 
	cout << tmp << endl; //����� �������� �������� 
	return tmp;
}
void push(stack* &st, int d) // ���������� ��������
{
	stack *pv = new stack;
	pv->data = d;   // �������� ���������� � ����     
	pv->next = st;
	st = pv;
}
