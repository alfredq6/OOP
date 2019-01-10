using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            // 1 a
            /** Примитивные типы
             * 13 примитивных типов
             * 
             * Подробнее:
             * https://docs.microsoft.com/ru-ru/dotnet/csharp/tour-of-csharp/types-and-variables
             * https://metanit.com/sharp/tutorial/2.1.php
             */
            bool    varBool    = true;
            byte    varByte    = 1;
            char    varChar    = 'a';
            short   varShort   = 123;
            int     varInt     = -1234;
            uint    varUInt    = 1234;
            long    varLong    = -12345;
            ulong   varULong   = 12345;
            ushort  varUShort  = 123;
            float   varFloat   = 1.1F;
            double  varDouble  = 1.31;
            decimal varDecimal = 123.1M;
            sbyte   varSbyte   = 5;

            // 1 b 
            /** Явное и неявное приведение
             * Подробнее: 
             * https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/casting-and-type-conversions
             * https://metanit.com/sharp/tutorial/3.11.php
             */
            int     valueInt = 5;
            sbyte   valueSbyte = (sbyte)valueInt; // явное приведение

            short   valueShort = 23;              
            valueInt = valueShort;              // неявное приведение

            // 1 c 
            /** Упаковка и распаковка
             * Подробнее:
             * http://crypto.pp.ua/2011/02/upakovka-i-raspakovka-v-c/
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
             */
            object  valueIntInBox     = valueInt;
            int     valueIntFromBox   = (int)valueIntInBox;
            object  valueSbyteInBox   = valueSbyte;
            sbyte   valueSbyteFromBox = (sbyte)valueSbyteInBox;

            // 1 d 
            /** Неявное типизирование    
             * Полезное:
             * https://habr.com/post/113586/
             */
            var Name = "Petar";
            var Age  = 25;
            WriteLine("\nЗадание 1d: \n");
            WriteLine("Тип Name: " + Name.GetType());
            WriteLine("Тип Age: " + Age.GetType());

            // 1 e 
            /** Nullable
             * Подробнее: 
             * https://metanit.com/sharp/tutorial/2.17.php
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/nullable-types/
             */
            WriteLine("\nЗадание 1е ----------------------------------------------------------\n");
            int? valNull = null;
            if (valNull.HasValue)
            {
                WriteLine(valNull.Value);
            }
            else
            {
                WriteLine("valNull is equal to null");
            }
            
            // 2 a ###########################################################################################
            WriteLine("\nЗадание 2a ----------------------------------------------------------\n");
            string str1 = "ASDF";
            string str2 = "asdf";
            if (String.Compare(str1, str2) != 0)
            {
                WriteLine($"Строки {str1} и {str2} не равны");
            }
            else
            {
                WriteLine($"Строки {str1} и {str2} равны");
            }
            
            // 2 b ###########################################################################################
            WriteLine("\nЗадание 2b ----------------------------------------------------------\n");
            string FirstString = "First String";
            string SecondString = "Second String";
            string ThirdString = "Third String";
            WriteLine($"Сцепление трёх строк: {String.Concat(FirstString, SecondString, ThirdString)}");
            WriteLine($"Скопированная строка: {String.Copy(FirstString)}");
            char charSeporator = ' ';
            string[] s1 = SecondString.Split(charSeporator);
            WriteLine($"Разделённая строка: {s1[1]} {s1[0]}");
            WriteLine($"Подстрока 3-й строки: {ThirdString.Substring(7)}");
            WriteLine($"Удаление подстроки: {ThirdString.Remove(3)}");
            WriteLine($"Вставка подстроки: {ThirdString.Insert(2, ThirdString.Substring(7))}");
            
            // 2 c ###########################################################################################
            WriteLine("\nЗадание 2c ----------------------------------------------------------\n");
            string EmptyString = "";
            string NullString = null;
            if (String.Compare(EmptyString, NullString) != 0)
            {
                WriteLine($"Строки {EmptyString} и {NullString} не равны");
            }
            else
            {
                WriteLine($"Строки {EmptyString} и {NullString} равны");
            }
            
            // 2 d ###########################################################################################
            WriteLine("\nЗадание 2d ----------------------------------------------------------\n");
            WriteLine($"Кол=во элементов в пустой строке: {EmptyString.Length} и в нулл строке: "); //{EmptyString.Length}
            StringBuilder BuildedString = new StringBuilder("A new string that is equivalent to this instance", 50);
            BuildedString.Remove(20, 5);
            WriteLine($"Строка после удаления: {BuildedString}");
            BuildedString.Append("Appended text to the end");
            WriteLine($"Строка после добавления текста в конец: {BuildedString}");
            BuildedString.Insert(0, "Inserted text to the start");
            WriteLine($"Строка после добавления текста в начало: {BuildedString}");
            
            // 3 a ###########################################################################################
            WriteLine("\nЗадание 3a ----------------------------------------------------------\n");
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Write(matrix[i, j] + " ");
                }
                WriteLine();
            }
            
            // 3 b ###########################################################################################
            WriteLine("\nЗадание 3b ----------------------------------------------------------\n");
            string[] ArrayOfStrings = { "some", "interest", "text", "or", "not" };
            Write("Содержимое массива строк: ");
            for (int i = 0; i < ArrayOfStrings.Length; i++)
            {
                Write(ArrayOfStrings[i]);
            }
            WriteLine($" и его длина: {ArrayOfStrings.Length}");
            int indexOfElement;
            Write("Введите индекс строки: ");
            indexOfElement = Int32.Parse(ReadLine()) - 1;
            Write("Введите строку, которой замените текущую в массиве: ");
            ArrayOfStrings[indexOfElement] = ReadLine();
            Write("Изменённый массив: ");
            for (int i = 0; i < ArrayOfStrings.Length; i++)
            {
                Write(ArrayOfStrings[i] + " ");
            }
            WriteLine();
            
            // 3 c ###########################################################################################
            WriteLine("\nЗадание 3c ----------------------------------------------------------\n");
            double[][] jaggedArray = { new double[2], new double[3], new double[4] };
            WriteLine("Введите зубчатый массив: ");
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        jaggedArray[i][j] = Double.Parse(ReadLine());
                    }
                }
                else if (i == 1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        jaggedArray[i][j] = Double.Parse(ReadLine());
                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        jaggedArray[i][j] = Double.Parse(ReadLine());
                    }
                }
            }
            WriteLine("Ваш массив: ");
            foreach (double[] x in jaggedArray)
            {
                foreach (double b in x)
                    Write("\t" + b);
                WriteLine();
            }
            
            // 3 d ###########################################################################################
            WriteLine("\nЗадание 3d ----------------------------------------------------------\n");
            object[] arrOfStr = { "array", "of", "strings" };
            WriteLine($"Массив строка типизированный неявно: {arrOfStr[0]} {arrOfStr[1]} {arrOfStr[2]}");
            
            // 4 a b c d ###########################################################################################
            WriteLine("\nЗадание 4 a b c d ----------------------------------------------------------\n");
            (int IntValueOfTuple, string FirstStringValueOfTuple, char CharValueOFTuple, string SecondValueOfTuple, ulong UlongValueOfTuple) FirstTuple = (15, "Name", 'x', "Age", 23456);
            WriteLine($"Кортеж целиком: {FirstTuple}");
            WriteLine($"1, 3, 4 элементы кортежа: {FirstTuple.Item1}, {FirstTuple.Item3}, {FirstTuple.Item4}");
            // распаковка
            int IntValueOfTupleFromBox = FirstTuple.IntValueOfTuple;
            string FirstStringValueOfTupleFromBox = FirstTuple.FirstStringValueOfTuple;
            char CharValueOFTupleFromBox = FirstTuple.CharValueOFTuple;
            string SecondValueOfTupleFromBox = FirstTuple.SecondValueOfTuple;
            ulong UlongValueOfTupleFromBox = FirstTuple.UlongValueOfTuple;
            (int, string, char, string, ulong) SecondTuple = (245, "Age", 'x', "Sub", 87654);
            if (FirstTuple.CompareTo(SecondTuple) == 0)  // сравнение 2-х кортежей с разным кол-вом и разными типами полей невозможно
            {
                WriteLine($"Кортежи {FirstTuple} и {SecondTuple} равны");
            }
            else
            {
                WriteLine($"Кортежи {FirstTuple} и {SecondTuple} не равны");
            }
            
            // 5 ###########################################################################################
            WriteLine("\nЗадание 5 ----------------------------------------------------------\n");
            int[] ArrayForMethod = { 2, 7, 214, 26, 12, 40};
            object MyLocalMethod(int[] LocalArr, string LocalStr)
            {
                (int maxElement, int minElement, int sumOfElements, char FirstCharOfString) LocalTuple;
                LocalTuple.maxElement = LocalArr[0];
                LocalTuple.minElement = LocalArr[0];
                LocalTuple.sumOfElements = 0;
                for (int i = 0; i < LocalArr.Length; i++)
                {
                    if (LocalTuple.maxElement < LocalArr[i])
                    {
                        LocalTuple.maxElement = LocalArr[i];
                    }
                    if (LocalTuple.minElement > LocalArr[i])
                    {
                        LocalTuple.minElement = LocalArr[i];
                    }
                    LocalTuple.sumOfElements += LocalArr[i];
                }
                LocalTuple.FirstCharOfString = LocalStr[0];
                return LocalTuple;
            }
            WriteLine($"Созданный локальный метод и его значение: {MyLocalMethod(ArrayForMethod, "afgshtrhkskdgo")}");
        }
    }
}