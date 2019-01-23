#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;

bool gameover;
const int width = 70;
const int height = 25;
int x, y, fruit_x, fruit_y, score;
int tail_x[100], tail_y[100];
int n_tail;
enum e_direction { stop = 0, pravo, levo, up, down };
e_direction dir;


void setup() {
	gameover = false;
	dir = stop;
	x = width / 2 - 1;
	y = height / 2 - 1;
	fruit_x = rand() % width;
	fruit_y = rand() % height;
	score = 0;
}

void draw() {
	system("cls");
	for (int i = 0; i < width + 1; i++)
		cout << "_";
	cout << endl;

	for (int i = 0; i < height; i++) {
		for (int j = 0; j < width; j++) {
			if (j == 0 || j == width - 1)
				cout << "|";
			if (i == y && j == x)
				cout << "O";
			else if (i == fruit_y && j == fruit_x)
				cout << "#";
			else {
				bool print = false;
				for (int k = 0; k < n_tail; k++) {
					if (tail_x[k] == j && tail_y[k] == i) {
						print = true;
						cout << "o";
					}
				}
				if (!print)
				cout << " ";
			}
		}
		cout << endl;
	}

	for (int i = 0; i < width + 1; i++)
		cout << "_";
	cout << endl;
	cout << "score: " << score << endl;
}

void input() {
	if (_kbhit()) {
		switch (_getch()) {
		case 'a':
			dir = levo;
			break;
		case 'd':
			dir = pravo;
			break;
		case 'w':
			dir = up;
			break;
		case 's':
			dir = down;
			break;
		case 'q':
			gameover = true;
			break;
		}
	}
}
 
void logic() {
	int prev_x = tail_x[0];
	int prev_y = tail_y[0];
	int prev_2x, prev_2y;
	tail_x[0] = x;
	tail_y[0] = y;
	for (int i = 1; i < n_tail; i++) {
		prev_2x = tail_x[i];
		prev_2y = tail_y[i];
		tail_x[i] = prev_x;
		tail_y[i] = prev_y;
		prev_x = prev_2x;
		prev_y = prev_2y;
	}
	switch (dir)
	{
	case levo:
			x--;
			break;
		case pravo:
			x++;
			break;
		case up:
			y--;
			break;
		case down:
			y++;
			break;
	}
//	if (x > width || x < 0 || y > height || y < 0)
//	gameover = true;
	if (x >= width - 1)
		x = 0;
	else if (x < 0)
		x = width - 2;
	if (y >= height)
		y = 0;
	else if (y < 0)
		y = height - 2;
	for (int i = 0; i < n_tail; i++) {
		if (tail_x[i] == x && tail_y[i] == y)
			gameover = true;
	}
	if (x == fruit_x && y == fruit_y) {
		score += 100;
		fruit_x = rand() % width;
		fruit_y = rand() % height;
		n_tail++;
	}
}

int main()
{
	system("color 2");
	setup();
	while (!gameover) {
		draw();
		input();
		logic();
		Sleep(40);
}
	return 0;
}