#include "stdafx.h"
#include "Hash.h"
#include <iostream>
int HashFunction(char *key, int m)    //Хеш-функция
{
	int s = 0;
	while (*key)
		s += *key++;
	return s % m;
}
//-------------------------------
int Next_hash(int hash, int size, int p)
{
	return (hash + 5 * p + 3 * p * p) % size;
}
//-------------------------------
Object create(int size, char*(*getkey)(void*))
{
	return *(new Object(size, getkey));
}
//-------------------------------
Object::Object(int size, char*(*getkey)(void*))
{
	N = 0;
	this->size = size;
	this->getKey = getkey;
	this->data = new void*[size];
	for (int i = 0; i < size; ++i)
		data[i] = NULL;
}
//-------------------------------
bool Object::insert(void* d)
{
	bool b = false;
	char *t = getKey(d);
	if (N != size)
		for (int i = 0, j = HashFunction(t, size);
			i != size && !b;  j = Next_hash(j, size, ++i))
			if (data[j] == NULL || data[j] == DEL)
			{
				data[j] = d;
				N++;
				b = true;
			}
	return b;
}
//-------------------------------
int Object::searchInd(char *key)
{
	int t = -1;
	bool b = false;
	if (N != 0)
		for (int i = 0, j = HashFunction(key, size); data[j] != NULL && i != size && !b; j = HashFunction(key, size))
			if (data[j] != DEL)
				if (strcmp(getKey(data[j]),key) == 0)
				{
					t = j; b = true;
				}
	return t;
}
//-------------------------------
void* Object::search(char *key)
{
	int t = searchInd(key);
	return(t >= 0) ? (data[t]) : (NULL);
}
//-------------------------------
void* Object::deleteByKey(char *key)
{
	int i = searchInd(key);
	void* t = data[i];
	if (t != NULL)
	{
		data[i] = DEL;
		N--;
	}
	return t;
}
//-------------------------------
bool Object::deleteByValue(void* d)
{
	return(deleteByKey(getKey(d)) != NULL);
}
//-------------------------------
void Object::scan(void(*f)(void*))
{
	for (int i = 0; i < this->size; i++)
	{
		std::cout << " Element " << i;
		if ((this->data)[i] == NULL)
			std::cout << "  Empty " << std::endl;
		else
			if ((this->data)[i] == DEL)
				std::cout << "  Deleted " << std::endl;
			else
				f((this->data)[i]);
	}
}
