#include <iostream>
#include <fstream>
using namespace std;

struct Subject {
	int mark;
};

struct Pupil {
	Subject math;
	Subject history;
	Subject biology;
	char name[30];
	char clas[5];
};

Pupil list_of_pupils[10];
Pupil deleting;

float averageMark[10];
int number_of_pupils = 0;

void inKeyb() { 
	cout << "input a number of pupils: ";
	cin >> number_of_pupils;
	ofstream ofile("FILE.txt");
	for (int i = 0; i < number_of_pupils; i++) {
		cout << "Input pupil's name: ";
		cin >> list_of_pupils[i].name;
		cout << "\nClass: ";
		cin >> list_of_pupils[i].clas;
		cout << "\nMath's mark: ";
		cin >> list_of_pupils[i].math.mark;
		cout << "\nHistory's mark: ";
		cin >> list_of_pupils[i].history.mark;
		cout << "\nBiology's mark: ";
		cin >> list_of_pupils[i].biology.mark;
		averageMark[i] = (list_of_pupils[i].math.mark + list_of_pupils[i].biology.mark + list_of_pupils[i].history.mark) / 3;
		ofile << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
	}
	ofile.close();
}

void find() {
	int choice;
	cout << "Input 1 to choice average mark 1-2\n";
	cout << "Input 2 to choice average mark 2-3\n";
	cout << "Input 3 to choice average mark 3-4\n";
	cout << "Input 4 to choice average mark 4-5\n";
	cout << "Input 5 to choice average mark 5-6\n";
	cout << "Input 6 to choice average mark 6-7\n";
	cout << "Input 7 to choice average mark 7-8\n";
	cout << "Input 8 to choice average mark 8-9\n";
	cout << "Input 9 to choice average mark 9-10\n";
	cin >> choice;
	ifstream ifile("FILE.txt");
	if (!ifile.is_open()) {
		perror("Error: ");
	}
	for (int i = 0; i < number_of_pupils; i++) {
		if (choice == 1 && (averageMark[i] <= 2 && averageMark[i] >= 1))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 2 && (averageMark[i] <= 3 && averageMark[i] >= 2))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 3 && (averageMark[i] <= 4 && averageMark[i] >= 3))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 4 && (averageMark[i] <= 5 && averageMark[i] >= 4))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 5 && (averageMark[i] <= 6 && averageMark[i] >= 5))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 6 && (averageMark[i] <= 7 && averageMark[i] >= 6))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 7 && (averageMark[i] <= 8 && averageMark[i] >= 7))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 8 && (averageMark[i] <= 9 && averageMark[i] >= 8))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
		if (choice == 9 && (averageMark[i] <= 10 && averageMark[i] >= 9))
			cout << "Info about the pupil: " << list_of_pupils[i].name << ", " << list_of_pupils[i].clas << ", Math's mark: " << list_of_pupils[i].math.mark << ", History's mark: " << list_of_pupils[i].history.mark << ", Biology's mark: " << list_of_pupils[i].biology.mark << ", Average mark: " << averageMark[i] << "\n";
	}
	ifile.close();
}

void outputFile() {
	char buff[100];
	ifstream ifile("FILE.txt");
	if (!ifile.is_open()) {
		perror("Error: ");
	}
	for (int i = 0; i < number_of_pupils; i++) {
		ifile.getline(buff, 100);
		cout << buff << endl;
	}
	ifile.close();
}

void del() {
	int st;
	cout << "Intput a number of element which will be deleted: ";
	cin >> st;
	if (st != 123) {
		for (int i = (st - 1); i < number_of_pupils; i++)
			list_of_pupils[i] = list_of_pupils[i + 1];
		number_of_pupils--;
	}
}

void main() {
	int k;
	do {
	cout << "\n1 - Entering data by the keyboard and writing in file\n";
	cout << "2 - Reading of file and output data in console\n";
	cout << "3 - Choice by average mark\n";
	cout << "4 - Delete element\n";
	cout << "0 - Exit programm\n";
	cin >> k;
		switch (k) {
		case 1: inKeyb(); break;
		case 2: outputFile(); break;
		case 3: find(); break;
		case 4: del(); break;
		case 0: exit(1); break;
		}
	} while (k != 0);
}
