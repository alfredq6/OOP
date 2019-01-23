//  Ввести с клавиатуры строку символов, состоящую из цифр и слов, разделенных пробелами,
//  и записать ее в файл. Прочитать из файла данные и вывести на экран номер слова,
//  содержащего k-й по счету с начала символ. Если в k-й позиции пробел, то вывести номер предыдущего слова.

#include <iostream>
#include <fstream>
#include <stdio.h>
using namespace std;

void InputFile(ofstream &file, char buff[60]) {
	char str[40];
	file.open(buff);
	if (file.fail())
		cout << "\n Ошибка при открытии файла";
	cout << "Введите строку символов, состоящую из цифр и слов, разделенных пробелами\n";
	for (int i = 0; i < 3; i++) {
		cin >> str;
		file << str << " ";
	}
	file.close();
}

int OutputFile(ifstream &file, char str[60], int numberof) {
	char symbols, space = ' ';
	int number = 1;
	file.open(str);
	if (file.fail())
		cout << "\n Ошибка при открытии файла";
	symbols = file.peek();
	for (int i = 0; i < numberof; i++) {
		file.get(symbols);
		if (symbols == space)
			number++;
	}
	file.close();
	return number;
}

void main() {
	setlocale(0, "rus");
	char NameOfFile[60];
	int NumberOfSymbol;
	ifstream ifile;
	ofstream ofile;
	cout << "Введите имя файла" << endl;
	cin >> NameOfFile;
	cout << "Введите номер символа: ";
	cin >> NumberOfSymbol;
	InputFile(ofile, NameOfFile);
	cout << "Номер слова который содержит " << NumberOfSymbol << "-ый символ = " << OutputFile(ifile, NameOfFile, NumberOfSymbol) << endl;
	system("pause");
}