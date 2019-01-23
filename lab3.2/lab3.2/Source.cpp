//  ������ � ���������� ������ ��������, ��������� �� ���� � ����, ����������� ���������,
//  � �������� �� � ����. ��������� �� ����� ������ � ������� �� ����� ����� �����,
//  ����������� k-� �� ����� � ������ ������. ���� � k-� ������� ������, �� ������� ����� ����������� �����.

#include <iostream>
#include <fstream>
#include <stdio.h>
using namespace std;

void InputFile(ofstream &file, char buff[60]) {
	char str[40];
	file.open(buff);
	if (file.fail())
		cout << "\n ������ ��� �������� �����";
	cout << "������� ������ ��������, ��������� �� ���� � ����, ����������� ���������\n";
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
		cout << "\n ������ ��� �������� �����";
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
	cout << "������� ��� �����" << endl;
	cin >> NameOfFile;
	cout << "������� ����� �������: ";
	cin >> NumberOfSymbol;
	InputFile(ofile, NameOfFile);
	cout << "����� ����� ������� �������� " << NumberOfSymbol << "-�� ������ = " << OutputFile(ifile, NameOfFile, NumberOfSymbol) << endl;
	system("pause");
}