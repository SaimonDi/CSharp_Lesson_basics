using System;

/*
 * Задача №6
 * 
   *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
    
   Панов Алексей
 */

namespace Task_6 {
    class ProgramT6 {
        static void Main(string[] args) {
            }

        #region Вывод текста на экран консоли
        static void Print() /*Пустая строка*/{
            Console.WriteLine();
            }
        static void Print(string msg) /*Вывод текста*/ {
            Console.WriteLine(msg);
            }
        static void Print(string word_1, string word_2) /*Вывод двух сообщений*/ {
            Console.WriteLine($"{word_1} {word_2}");
            }
        static void Print(string msg, int number) /*Вывод сообщения и целого числа*/ {
            Console.WriteLine($"{msg} {number}");
            }
        static void Print(string msg, double number) /*Вывод сообщения и числа с плавающей запятой*/ {
            Console.WriteLine($"{msg} {number}");
            }
        #endregion

        #region Вывод сообщений по центру экрана
        static void PrintCenterScreen(string someWords) /*Вывод сообщения в центре окна консоли*/ {
            Console.SetCursorPosition(Console.WindowWidth / 2 - someWords.Length / 2, Console.WindowHeight / 2);
            Console.WriteLine(someWords);
            }
        static void PrintCenterTop(string someWords) /*Вывод сообщения в центре текущей строки*/ {
            Console.CursorLeft = Console.WindowWidth / 2 - someWords.Length / 2;
            Console.WriteLine(someWords);
            }
        #endregion

        #region Пауза
        static void Pause() /*Пауза до нажатия любой клавиши*/ {
            Console.ReadKey();
            }
        static void Pause(string msg) /*Пауза до нажатия любой клавиши с сообщением*/ {
            Console.WriteLine(msg);
            Console.ReadKey();
            }
        #endregion

        #region Ввод текстов ицифр
        static string InputWord() {
            return Console.ReadLine();
            }
        static int InputInt() {
            return Convert.ToInt32(Console.ReadLine());
            }
        static double InputDouble() {
            return Convert.ToDouble(Console.ReadLine());
            }
        #endregion

        #region Ввод текстов и цифр с сообщением
        static void InputPrintString(string msg) {
            string someInput = Console.ReadLine();
            Console.WriteLine($"{msg} {someInput}");
            }
        static void InputPrintInt(string msg) {
            int someInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{msg} {someInput}");
            }
        static void InputPrintDouble(string msg) {
            double someInput = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"{msg} {someInput}");
            }
        #endregion
        }
    }
