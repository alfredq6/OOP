#include <iostream>
#include <fstream>
using namespace std;

int inputFile(char str[50]) {
	ofstream ifile_1("FILE_1.txt");
	ifile_1 << str;
	ifile_1.close();
	return 1;
}

int outputFile() {
	const char *numerics = "1234567890";
	char dot = '.', buff[50], value = 0;
	int numberNumericsBeforeDot = 0, numberNumericsAfterDot = 1;
	ifstream ofile_1("FILE_1.txt");
	if (!ofile_1.is_open()) {
		cout << "Ошибка при открытии файла\n";
	}
	else {
		ofile_1.getline(buff, 50);
		for (int i = 0; buff[i] != 0; i++) {
			for (int j = 0; numerics[j] != 0; j++) {
				while (buff[i] != dot && buff[i - 1] != numerics[j]) {
					if (buff[i] == numerics[j])
						numberNumericsBeforeDot++;
					if (buff[i] != numerics[j] && buff[i] != dot)
						numberNumericsBeforeDot = 0;
				}
				if (buff[i] == numerics[j] && buff[i - numberNumericsAfterDot] == dot && buff[i - 1 - numberNumericsAfterDot] == numerics[j])
					numberNumericsAfterDot++;
			}
		}
		for (int i = 0; buff[i] != 0; i++)
			for (int j = 0; numerics[j] != 0; i++)
				if (buff[i] == dot && buff[i - 1] == numerics[j]) {
					int k = i;
					while (numberNumericsBeforeDot != 0) {
						value += buff[k - numberNumericsBeforeDot];
						numberNumericsBeforeDot--;
					}
				}
		value += dot;
		for (int i = 0; buff[i] != 0; i++)
			for (int j = 0; numerics[j] != 0; j++)
				if (buff[i] == dot && buff[i - 1] == numerics[j]) {
					int k = i;
					while (buff[k + 1] != buff[numberNumericsAfterDot + 1])
						value += buff[k + 1];
				} 
		ofstream ifile_2("FILE_2.txt");
		ifile_2 << value;
		ofile_1.close();
		ifile_2.close();
	}
	return 0;
}

int main() {
	setlocale(0, "rus");
	char str[50];
	cout << "Введите строку символов, состоящую из букв, цифр, запятых, точек, знаков + и -\n";
	cin >> str;
	inputFile(str);
	outputFile();
}