#include <iostream>
using namespace std;

/*	Авиарейсы. Номер рейса, пункт назначения, время вылета, дата вылета, стоимость билета, количество мест.
Выбор по дате вылета. Дату вылета реализовать с помощью битового поля, пункт назначения  с помощью перечисления.*/

struct date {
	int month : 10;
	int day : 10;
};

enum Destination {
	Kiev = 1, Moskow, Minsk, Riga, Paris, Berlin, Madrid
};

union Flight {
	int FlightNumber;
	int hour;
	int minute;
	int TicketPrice;
	int NumberOfSeats;
	char *city[10];
	date full;
};

Destination City;
Flight personal[10];
Flight del;
int FlightQuantity = 0;

void input() {
	int choice;
	for (int i = 0; i < FlightQuantity; i++) {
		cout << "Input a flight's number: ";
		cin >> personal[i].FlightNumber;
		cout << "Choice a destination(Kiev - 1, Moskow - 2, Minsk - 3, Riga - 4, Paris - 5, Berlin - 6, Madrid - 7):";
		cin >> choice;
		if (choice == 1 && City == 1) personal[i].city[10] = "Kiev";
		if (choice == 2 && City == 2) personal[i].city[10] = "Moskow";
		if (choice == 3 && City == 3) personal[i].city[10] = "Minsk";
		if (choice == 4 && City == 4) personal[i].city[10] = "Riga";
		if (choice == 5 && City == 5) personal[i].city[10] = "Paris";
		if (choice == 6 && City == 6) personal[i].city[10] = "Berlin";
		if (choice == 7 && City == 7) personal[i].city[10] = "Madrid";
		cout << "Input an month of departure: ";
		int lmonth;
		cin >> lmonth;
		personal[i].full.month = lmonth;
		cout << "Day: ";
		int lday;
		cin >> lday;
		personal[i].full.day = lday;
		cout << "Input an hour of departure: ";
		cin >> personal[i].hour;
		cout << "Minutes: ";
		cin >> personal[i].minute;
		cout << "Input a ticket's price: ";
		cin >> personal[i].TicketPrice;
		cout << "Input a number of seats: ";
		cin >> personal[i].NumberOfSeats;
	}
}

void output() {
	for (int i = 0; i < FlightQuantity; i++) {
		cout << "\nInfo about the " << (i + 1) << "'th flights: " << "\nDestination: " << personal[i].city << "\nDate: " << personal[i].full.day << "." << personal[i].full.month << ".18\nTime of departure: " << personal[i].hour << ":" << personal[i].minute << "\nTicket's price: " << personal[i].TicketPrice << "\nNumber of seats: " << personal[i].NumberOfSeats << endl;
	}
}

void find() {
	int necmonth, necday;
	cout << "Input necessary date(month): ";
	cin >> necmonth;
	cout << "Day: ";
	cin >> necday;
	for (int i = 0; i < FlightQuantity; i++) {
		if (personal[i].full.month == necmonth && personal[i].full.day == necday)
			cout << "\nInformation about necessary flight: \n" << "Destination: " << personal[i].city << "\nDate: " << personal[i].full.day << "." << personal[i].full.month << ".18\nTime of departure: " << personal[i].hour << ":" << personal[i].minute << "\nTicket's price: " << personal[i].TicketPrice << "\nNumber of seats: " << personal[i].NumberOfSeats << endl;
	}
}

void deleting() {
	int choice;
	cout << "Input a flight's number for delete(input 123 for delet all elements): ";
	cin >> choice;
	if (choice != 123) {
		for (int i = (choice - 1); i < FlightQuantity; i++)
			personal[i] = personal[i + 1];
		FlightQuantity--;
	}
	if (choice == 123) {
		for (int i = 0; i < FlightQuantity; i++) {
			personal[i] = del;
			FlightQuantity--;
		}
	}
}

void main() {
	int choice;
	cout << "Input a flight's quantity: ";
	cin >> FlightQuantity;
	do {
		cout << "\n1 - Entering data by the keyboard\n";
		cout << "2 - Output data in console\n";
		cout << "3 - Choice by date of departure\n";
		cout << "4 - Delete element\n";
		cout << "0 - Exit programm\n";
		cin >> choice;
		switch (choice) {
		case 1: input(); break;
		case 2: output(); break;
		case 3: find(); break;
		case 4: deleting(); break;
		case 0: exit(1);
		}
	} while (choice != 0);
}