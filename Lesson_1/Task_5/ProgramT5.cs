using System;

/*
 * Задача №5
 * 
   а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
   б) *Сделать задание, только вывод организовать в центре экрана.
   в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y)

   Панов Алексей
 */

namespace Task_5 {
    class ProgramT5 {
        static void Main(string[] args) {
            string name, surname, place,fullWord;

            #region
            name = "Алексей";
            surname = "Панов";
            place = "Москва";
            #endregion

            fullWord = $"{name} {surname}, город {place}";

            Console.WriteLine("Расположите экран консоли в любом положении и нажмите на любую клавишу...");
            Console.ReadKey();

            DataPrint(fullWord); //Вывод текста в центре экрана
            DataPrintInPosition(fullWord, 10, 20); //Вывод текста по координатам
            }

        static void DataPrint(string fullWords) {
            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2 - fullWords.Length / 2, Console.WindowHeight / 2); //Расчёт положения курсора относительно окна и длины строки
            Console.WriteLine(fullWords); //Вывод

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Чтобы перейти к следющей части нажмите любую клавишу...");

            Console.ReadKey();
            }
        
        static void DataPrintInPosition(string fullWords, int x, int y) {
            Console.Clear();

            Console.WriteLine($"Положение текста при x = {x}, а y = {y}");

            Console.SetCursorPosition(x, y);
            Console.WriteLine(fullWords); //Вывод

            Console.ReadKey();
            }
        }
        }
