#include <stdio.h> 
#define _USE_MATH_DEFINES
#include <math.h>
#include <iostream>
int main() {
	setlocale(LC_CTYPE, "rus");
	float R, L, S;
	printf("Введите значение R = ");
# define M_PI 3.14 /* pi */
	scanf_s("%f", &R);
	L = 2 * M_PI * R;
	S = M_PI * (R * R);
	printf("\n Длина окружности = %f Площадь круга= %f ", L, S);
	system("pause");
	return 0;

}