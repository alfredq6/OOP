#include "stdafx.h"
#include "Hash_Twin_Chain.h"
#include "Lists.h"
#include <iostream>
#include <ctime>

int q = 0;
struct AAA
{
	int key;
	char *mas;
	AAA(int k, char*z)
	{
		key = k;
		mas = z;
	}
};
namespace hashTC
{
	Object create(int size, int(*f)(void*))
	{
		srand((unsigned)time(NULL));
		q = rand() % 99;
		return *(new Object(size, f));
	}
	int Object::hashFunction(void* data)
	{
		return ((FunKey(data) + 3 * q + 7 * q * q) % size);
	};
	bool Object::insert(void* data)
	{
		return (Hash[hashFunction(data)].insert(data));
	};
	bool Object::deleteByData(void* data)
	{
		return (Hash[hashFunction(data)].deleteByData(data));
	};
	listx::Element* Object::search(void* data)
	{
		return Hash[hashFunction(data)].search(data);
	};
	void Object::Scan()
	{
		for (int i = 0; i < size; i++)
		{
			Hash[i].scan();
			std::cout << '\n';
		}
	};
}
