#pragma once
#include <iostream>

namespace btree
{
	enum CMP
	{
		LESS = -1, EQUAL = 0, GREAT = 1
	};
	struct Node
	{
		Node* parent;
		Node* left;
		Node* right;
		void* data;
		Node(Node* p, Node* l, Node* r, void* d) //Конструктор
		{
			parent = p;
			left = l;
			right = r;
			data = d;
		}
		Node* next(); //Следующий по ключу
		Node* prev(); //Предыдущий по ключу
		Node* min(); //Минимум в поддереве
		Node* max(); //Максимум в поддереве
		void scanDown(void(*f)(void* n)); //Нисходящий обход
		void scanMix(void(*f)(void* n)); //Смешанный обход
		void scan(int(*f)(void* n));
		void scanLevel(void(*f)(void* n), int);
		int getLevel();
		void scanByLevel(void(*f)(void* n));
	};
	struct Object //Интерфейс бинарного дерева
	{
		Node* Root;
		CMP(*compare)(void*, void*); //Функция сравнения
		Object(CMP(*f)(void*, void*))
		{
			Root = NULL;
			compare = f;
		};
		bool isLess(void* x1, void* x2) const
		{
			return compare(x1, x2) == LESS;
		};
		bool isGreat(void* x1, void* x2)const
		{
			return compare(x1, x2) == GREAT;
		};
		bool isEqual(void* x1, void* x2)const
		{
			return compare(x1, x2) == EQUAL;
		};
		bool insert(void* data);
		Node* search(void* d, Node* n);
		Node* search(void* d)
		{
			return search(d, Root);
		};
		bool deleteByNode(Node* e); //Удалить по адресу
		bool deleteByData(void* data) //Удалить по ключу
		{
			return deleteByNode(search(data));
		};
		void isBalanced(Node *Root);
		int count(Node *Root);
		int findHeight(Node *Root);
	};
	Object create(CMP(*f)(void*, void*)); //Создать бинарное дерево
};