#include <iostream>
using namespace std;

/*Вершина бинарного дерева содержит ключ,  2 целых числа и два указателя на потомков. Написать функцию удаления вершины с максимальной суммой 2 целых значений узла.*/

struct Tree {
	int key;
	int firstValue;
	int secondValue;
	Tree *left, *right;
};

int arr[10], maxValue = 0, maxKey;
Tree *root = NULL;

Tree* list(int k, int first, int second) {
	Tree *t = new Tree;
	t->key = k;
	t->firstValue = first;
	t->secondValue = second;
	t->left = t->right = NULL;
	return t;
}

Tree* insert(Tree *t, int k, int first, int second) {
	Tree *prev = new Tree;
	int num = 0;
	while (t && !num) {
		prev = t;
		if (k == t->key)
			num = 1;
		else
			if (k < t->key)
				t = t->left;
			else
				t = t->right;
	}
	if (!num) {
		t = list(k, first, second);
		if (k < prev->key)
			prev->left = t;
		else
			prev->right = t;
	}
	return t;
}

Tree* delet(Tree *root, int k) {
	Tree *del, *prevDel, *rep, *prevRep;
	del = root;
	prevDel = NULL;
	while (del != NULL && del->key != k) {
		prevDel = del;
		if (del->key > k)
			del = del->left;
		else
			del = del->right;
	}
	if (del == NULL) {
		cout << "This key is not...\n";
		return root;
	}
	if (del->right == NULL)
		rep = del->left;
	else {
		if (del->left == NULL)
			rep = del->right;
		else {
			prevRep = del;
			rep = del->right;
			while (rep->right != NULL) {
				prevRep = rep;
				rep = rep->right;
			}
			if (prevRep == del)
				rep->right = del->right;
			else {
				rep->right = del->right;
				prevRep->right = rep->left;
				rep->left = prevRep;
			}
		}
	}
	if (del == root)
		root = rep;
	else
		if (del->key < prevDel->key)
			prevDel->left = rep;
		else
			prevDel->right = rep;
	int temp = del->key;
	cout << "The element with the key = " << temp << " is deleted\n";
	delete del;
	return root;
}

Tree* search(Tree* t, int k) {
	Tree* rc = t;
	if (rc != NULL) {
		if (k < (k, t->key))
			rc = search(t->left, k);
		else
			if (k > (k, t->key))
				rc = search(t->right, k);
	}
	else
		cout << "This element is not\n";
	return rc;
}

void view(Tree *t, int lvl) {
	if (t) {
		view(t->right, lvl + 1);
		for (int i = 0; i < lvl; i++)
			cout << "	";
		int tm = t->key;
		cout << tm << " ";
		cout << t->firstValue << ":" << t->secondValue << endl;
		arr[lvl] = t->firstValue + t->secondValue;
		if (maxValue < arr[lvl]) {
			maxValue = arr[lvl];
			maxKey = t->key;
		}
		view(t->left, lvl + 1);
	}
}

void deleteTree(Tree *t) {
	if (t != NULL) {
		deleteTree(t->left);
		deleteTree(t->right);
		delete t;
	}
}

Tree* makeTree(Tree *root) {
	int key, first, second;
	if (root == NULL) {
		cout << "Input a key of the root: ";
		cin >> key;
		cout << "Input first value of the root: ";
		cin >> first;
		cout << "Input second value of the root: ";
		cin >> second;
		root = list(key, first, second);
	}
	else {
		cout << "Enter a key: ";
		cin >> key;
		cout << "Enter the first value: ";
		cin >> first;
		cout << "Enter the second value: ";
		cin >> second;
		insert(root, key, first, second);
	}
	return root;
}

void main() {
	int key, choice, first, second;
	Tree *rc;
	for (;;) {
		cout << "\nYour choice: \n";
		cout << "1 - \nCreating a tree\n";
		cout << "2 - Insert an element\n";
		cout << "3 - Search by a key\n";
		cout << "4 - Deleting an element\n";
		cout << "5 - View the tree\n";
		cout << "6 - Do task's work\n";
		cout << "7 - Deleting the tree\n";
		cout << "0 - Exit\n	?: ";
		cin >> choice;
		switch (choice) {
		case 1: root = makeTree(root); break;
		case 2: { cout << "Enter a key: "; cin >> key;
			cout << "Enter the first value: "; cin >> first;
			cout << "Enter the second value: "; cin >> second;
			insert(root, key, first, second); } break;
		case 3: cout << "Enter a key: "; cin >> key;
			rc = search(root, key);
			cout << "Finding info: " << rc->key << " " << rc->firstValue << ":" << rc->secondValue << endl; break;
		case 4: cout << "Enter an deleting key: "; cin >> key;
			root = delet(root, key); break;
		case 5: if (root->key >= 0)
			view(root, 0);
				else
					cout << "The tree is empty...\n"; break;
		case 6: root = delet(root, maxKey); break;
		case 7: deleteTree(root); break;
		case 0: exit(0);
		}
	}
}