#include <iostream>
#include <fstream>
using namespace std;
//                     **Ученики** Ф.И.О., класс (цифра+буква) предметы, оценки, средний балл.
//                     Выбор по среднему баллу. 

struct Subject {
	int mark;
};

struct Pupil {
	Subject math;
	Subject history;
	Subject biology;
	char name[25];
	char clas[5];
	int average_mark;
};

void input_file(Pupil surname) {
	cout << "Input information about pupil: Name, class, mark of math, histoory, biology.\n";
	cin >> surname.name;
	cin >> surname.clas;
	cin >> surname.math.mark;
	cin >> surname.history.mark;
	cin >> surname.biology.mark;
	surname.average_mark = (surname.math.mark + surname.biology.mark + surname.history.mark) / 3;
	ofstream ofile("FILE.txt", ios_base::app);
	ofile << surname.name << " from " << surname.clas << ", math's mark " << surname.math.mark << ", history's mark " << surname.history.mark << ", biology's mark " << surname.biology.mark << ", average mark " << surname.average_mark << ".\n";
	ofile.close();
}

int fullWork() {
	remove("FILE.txt");
	Pupil surnames = {};
	int number_pupils;
	char choice, nochoice;
	cout << "Input a number of pupils ";
	cin >> number_pupils;
	for (int i = 0; i < number_pupils; i++) {
		input_file(surnames);
	}
	char buff[100];
	ifstream ifile("FILE.txt");
	if (!ifile.is_open()) {
		perror("Error");
		system("pause");
		return 0;
	}
	cout << "Input 1 if you need 1-2 average mark" << endl;
	cout << "Input 2 if you need 2-3 average mark" << endl;
	cout << "Input 3 if you need 3-4 average mark" << endl;
	cout << "Input 4 if you need 4-5 average mark" << endl;
	cout << "Input 5 if you need 5-6 average mark" << endl;
	cout << "Input 6 if you need 6-7 average mark" << endl;
	cout << "Input 7 if you need 7-8 average mark" << endl;
	cout << "Input 8 if you need 8-9 average mark" << endl;
	cout << "Input 9 if you need 9-10 average mark" << endl;
	cin >> choice;
	for (int i = 0; i < number_pupils; i++) {
		ifile.getline(buff, 100);
		for (int j = 0; buff[j] != 0; j++) {
			if (buff[j + 1] == '.' && buff[j] == choice) {
				cout << buff << endl;
				ifile.close();
				system("pause");
				return 0;
			}
			if (buff[j + 1] == '.' && buff[j] != choice) {
				cout << "Hasn't the average mark.\n";
			}
		}
	}
	ifile.close();
}

int main() {
	int choice;
	cout << "\n1 - Choice for full work of programm\n" << "0 - Choice for exit\n" << "\nInput a number of operation ";
	cin >> choice;
	switch (choice) {
	case 1: fullWork(); break;
	case 0: exit(0); break;
	}
}