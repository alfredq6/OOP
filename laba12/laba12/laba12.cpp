#include "stdafx.h"
#include "Header.h"
#include <iostream>

namespace btree
{
	int c = 0;
	int p = 0;
	Object create(CMP(*f)(void*, void*))
	{
		return *(new Object(f));
	}
	Node* Node::min()
	{
		Node* rc = this;
		if (rc->left != NULL)
			rc = rc->left->min();
		return rc;
	}
	Node* Node::max()
	{
		Node* rc = this;
		if (rc->right != NULL)
			rc = rc->right->max();
		return rc;
	}
	Node* Node::next()
	{
		Node* rc = this, *x = this;
		if (rc->right != NULL)
			rc = rc->right->min();
		else
		{
			rc = this->parent;
			while (rc != NULL && x == rc->right)
			{
				x = rc;
				rc = rc->parent;
			}
		}
		return rc;
	}
	Node* Node::prev()
	{
		Node* rc = this, *x = this;
		if (rc->left != NULL)
			rc = rc->left->max();
		else
		{
			rc = this->parent;
			while (rc != NULL && x == rc->left)
			{
				x = rc;
				rc = rc->parent;
			}
		}
		return rc;
	}
	void Node::scanDown(void(*f)(void* n))
	{
		f(this->data);
		if (this->left != NULL)
			this->left->scanDown(f);
		if (this->right != NULL)
			this->right->scanDown(f);
	}
	void Node::scanMix(void(*f)(void* n))
	{
		if (this->left != NULL)
			this->left->scanMix(f);
		f(this->data);
		if (this->right != NULL)
			this->right->scanMix(f);
	}
	Node* Object::search(void* d, Node* n)
	{
		Node* rc = n;
		if (rc != NULL)
		{
			if (isLess(d, n->data))
				rc = search(d, n->left);
			else
				if (isGreat(d, n->left))
					rc = search(d, n->right);
		}
		return rc;
	}
	bool Object::insert(void *d)
	{
		Node* x = this->Root, *n = NULL;
		bool rc = true;
		while (rc == true && x != NULL)
		{
			n = x;
			if (isLess(d, x->data))
				x = x->left;
			else
				if (isGreat(d, x->data))
					x = x->right;
				else
					rc = false;
		}
		if (rc == true && n == NULL)
			this->Root = new Node(NULL, NULL, NULL, d);
		else
			if (rc == true && isLess(d, n->data))
				n->left = new Node(n, NULL, NULL, d);
			else
				if (rc == true && isGreat(d, n->data))
					n->right = new Node(n, NULL, NULL, d);
		return rc;
	}
	bool Object::deleteByNode(Node* n)
	{
		bool rc = true;
		if (rc = (n != NULL))
		{
			if (n->left == NULL && n->right == NULL) //если потомков нет
			{
				if (n->parent == NULL)
					this->Root = NULL; //обнуление корня
				else
					if (n->parent->left == n)
						n->parent->left = NULL;
					else
						n->parent->right = NULL;
				delete n;
			}
			else
				if (n->left == NULL && n->right != NULL) //только правый потомок
				{
					if (n->parent == NULL)
						this->Root = n->right;
					else
						if (n->parent->left == n)
							n->parent->left = n->right;
						else
							n->parent->right = n->right;
					n->right->parent = n->parent;
					delete n;
				}
				else
					if (n->left != NULL &&n->right == NULL) //только левый пото-мок
					{
						if (n->parent == NULL)
							this->Root = n->left;
						else
							if (n->parent->right == n)
								n->parent->left = n->left;
							else
								n->parent->right = n->left;
						n->left->parent = n->parent;
						delete n;
					}
					else //если есть оба потомка
						if (n->left != NULL && n->right != NULL) {
							Node* x = n->next();
							n->data = x->data;
							rc = deleteByNode(x);
						}
		} return rc;
	}
	void Node::scanLevel(void(*f)(void* n), int i) //Вывести вершины уровня
	{
		if (this->left != NULL)
			this->left->scanLevel(f, i);
		if (this->getLevel() == i)
			f(this->data);
		if (this->right != NULL)
			this->right->scanLevel(f, i);
	}
	int Node::getLevel()
	{
		Node *rc = this;
		int q = 0;
		while (rc->parent != NULL)
		{
			rc = rc->parent;
			q++;
		}
		return q;
	}
	void Node::scanByLevel(void(*f)(void* n))
	{
		for (int i = 0; i < 10; i++)
		{
			std::cout << '\t';
			this->scanLevel(f, i);
			std::cout << '\n';
		}
	}
	int Object::count(Node* root)
	{
		if (root != NULL)
		{
			if (root->left == NULL && root->right == NULL)
			{
				c++;
			}
			count(root->left);
			count(root->right);
		}
		return c;
	}
	void Object::isBalanced(Node *root)
	{
		if (root == NULL) {
			std::cout << "Balanced";
		}
		int left = findHeight(root->left);
		int right = findHeight(root->right);
		if (abs(left - right) <= 1)
			std::cout << "Balanced" << std::endl;
		else
			std::cout << "Unbalanced" << std::endl;
	}
	int Object::findHeight(Node* root) {
		if (root == NULL) {
			return -1;
		}
		int lefth = findHeight(root->left);
		int righth = findHeight(root->right);
		if (lefth > righth) {
			return lefth + 1;
		}
		else {
			return righth + 1;
		}
	}
}