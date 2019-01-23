//  Скопировать из файла FILE1 в файл FILE2 все строки, кроме той строки,
//  в которой больше всего гласных букв. Напечатать номер этой строки.

#include <fstream>
#include <iostream>
using namespace std;

void main() {
	setlocale(0, "rus");
	const char *letters = "eyuioa";
	char buff[100], str[100];
	int valueOfLetters = 0, maxValueOfLetters = 0, number;
	ofstream ofile_1("FILE_1.txt");
	ofile_1 << "eowweot oweto toiweigsdlgj sdjgkwp jwpogjoiw\n";
	ofile_1 << "laekbfweboogog ginosgisdg\n";
	ofile_1 << "foeiajfoefoi eiogsoi dig oiewaois iaoiiwoeffauo euoausuo ouasouausouao\n";
	ofile_1 << "foi3foognoegoiwn3go wogh 3io gjwje oi 3oi oijeskbgkdbgkbgsd kbgksdbg kjbeugb ue\n";
	ofile_1.close();
	ifstream ifile_1("FILE_1.txt");
	if (!ifile_1.is_open())
		cout << "Ошибка при открытии файла\n";
	else {
		for (int k = 0; k < 4; k++) {
			ifile_1.getline(buff, 100);
			for (int i = 0; buff[i] != 0; i++) {
				for (int j = 0; letters[j] != 0; j++) {
					if (buff[i] == letters[j])
						valueOfLetters++;
				}
			}
			if (valueOfLetters > maxValueOfLetters) {
				maxValueOfLetters = valueOfLetters;
				number = k + 1;
			}
			valueOfLetters = 0;
		}
		ifile_1.close();
	}
	ofstream ofile_2("FILE_2.txt");
	ifstream ifile_1_2("FILE_1.txt");
	if (!ifile_1_2.is_open())
		cout << "Ошибка при открытии файла\n";
	else {
		for (int k = 0; k < 4; k++) {
			ifile_1_2.getline(str, 100);
			if (k != number - 1)
				ofile_2 << str << endl;
			else ofile_2 << "Вырезанная строка, её номер = " << number << endl;
		}
		ifile_1_2.close();
		ofile_2.close();
	}
}
