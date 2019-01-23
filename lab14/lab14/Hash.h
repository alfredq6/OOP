#pragma once
#define HASHDEL (void*) -1
struct Object
{
	void** data;
	Object(int, char*(*)(void*));
	int size;  int N;
	char*(*getKey)(void*);
	bool insert(void*);
	int searchInd(char *key);
	void* search(char *key);
	void* deleteByKey(char *key);
	bool deleteByValue(void*);
	void scan(void(*f)(void*));
};
static void* DEL = (void*)HASHDEL;
Object create(int size, char*(*getkey)(void*));
#undef HASHDEL
