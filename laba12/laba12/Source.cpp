#include "stdafx.h"
#include "Header.h"
#include <fstream>
#include <iostream>

using namespace std;

int c;

struct NodeTree {
	int key;
};

btree::CMP cmpfnc(void* x, void* y) //Сравнение
{
	btree::CMP rc = btree::EQUAL;
	if (((NodeTree*)x)->key < ((NodeTree*)y)->key)
		rc = btree::LESS;
	else
		if (((NodeTree*)x)->key >((NodeTree*)y)->key)
			rc = btree::GREAT;
	return rc;
}

void printNode(void* x) //Вывод при обходе
{
	cout << ((NodeTree*)x)->key << ends;
}

bool buildTree(char *FileName, btree::Object& tree) //Построение дерева из файла
{
	bool rc = true;
	FILE *inFile;
	fopen_s(&inFile, FileName, "r");
	if (inFile == NULL)
	{
		cout << "Ошибка открытия входного файла" << endl;
		rc = false; return rc;
	}
	while (!feof(inFile))
	{
		int num;
		fscanf_s(inFile, "%d", &num, 1);
		NodeTree *a = new NodeTree();
		a->key = num;
		tree.insert(a);
	}
	fclose(inFile);
	return rc;
}

FILE *outFile;

void saveToFile(void* x) //Запись одного элемента в файл
{
	NodeTree *a = (NodeTree*)x;
	int q = a->key;
	fprintf(outFile, "%d\n", q);
}

void saveTree(btree::Object &tree, char *FileName) //Сохранение в файл
{
	fopen_s(&outFile, FileName, "w");
	if (outFile == NULL)
	{
		cout << "Ошибка открытия выходного файла" << endl;
		return;
	}
	tree.Root->scanDown(saveToFile);
	fclose(outFile);
}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_CTYPE, "Russian");
	btree::Object demoTree = btree::create(cmpfnc);
	int k, choice;
	NodeTree a1 = { 1 }, a2 = { 2 }, a3 = { 3 }, a4 = { 4 }, a5 = { 5 }, a6 = { 6 };
	bool rc = demoTree.insert(&a4);
	rc = demoTree.insert(&a1);
	rc = demoTree.insert(&a6);
	rc = demoTree.insert(&a2);
	rc = demoTree.insert(&a3);
	rc = demoTree.insert(&a5);
	for (;;)
	{
		NodeTree *a = new NodeTree;
		cout << "1 - displaying the tree on the screen" << endl;
		cout << "2 - adding an element" << endl;
		cout << "3 - delete element" << endl;
		cout << "4 - save in filw" << endl;
		cout << "5 - load from file" << endl;
		cout << "6 - delete all tree" << endl;
		cout << "7 - Mix" << endl;
		cout << "8 - Down" << endl;
		cout << "9 - List" << endl;
		cout << "10 - isBalanced?" << endl;
		cout << "0 - exit" << endl;
		cout << "choice:" << endl; cin >> choice;
		switch (choice)
		{
		case 0:exit(0);
		case 1:
			if (demoTree.Root)
				demoTree.Root->scanByLevel(printNode);
			else
				cout << "tree is empty" << endl;
			break;
		case 2:
			cout << "enter key" << endl; cin >> k;
			a->key = k;
			demoTree.insert(a);
			break;
		case 3:
			cout << "enter key" << endl; cin >> k;
			a->key = k;
			demoTree.deleteByData(a);
		case 4: saveTree(demoTree, "G.txt");
			break;
		case 5:buildTree("G.txt", demoTree);
			break;
		case 6:
			while (demoTree.Root)
				demoTree.deleteByNode(demoTree.Root);
			break;
		case 7:
			if (demoTree.Root)
			{
				demoTree.Root->scanMix(printNode);
				cout << endl << endl;
			}
			else
				cout << "tree is empty" << endl;
			break;
		case 8:
			if (demoTree.Root)
			{
				demoTree.Root->scanDown(printNode);
				cout << endl << endl;

			}
			else
				cout << "tree is empty" << endl;
			break;
		case 9:
			demoTree.count(demoTree.Root->left);
			cout << "Number of list=" << demoTree.count(demoTree.Root->right) << endl;
			break;
		case 10:
			demoTree.isBalanced(demoTree.Root);
			break;
		}
	}
	return 0;
}