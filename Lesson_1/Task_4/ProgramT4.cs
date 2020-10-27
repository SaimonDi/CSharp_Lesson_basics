using System;

/*
 * Задача №4
 * 
   Написать программу обмена значениями двух переменных:
    а) с использованием третьей переменной;
	б) *без использования третьей переменной.

   Панов Алексей
 */

namespace Task_4 {
    class ProgramT4 {
        static void Main(string[] args) {

            int a, b;

            Console.Write("Программ обмена двух переменных.\r\nВведите первую переменную: ");
            a = Convert.ToInt32(Console.ReadLine()); //Ввод первой переменной
            Console.Write("Введите вторую переменную: ");
            b = Convert.ToInt32(Console.ReadLine()); //Ввод второй переменной

            Console.WriteLine();
            SwapPlanA(a, b); //обмен значениями с третьей переменной
            SwapPlanB(a, b); //обмен значениями без третьей переменной

            Console.ReadKey();
            }

        static void SwapPlanA(int a, int b) {
            int c = a;
            a = b;
            b = c;

            Console.WriteLine($"а) Результат обмена: Первая = {a}, Вторая = {b}"); //Вывод
            }

        static void SwapPlanB(int a, int b) {
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"б) Результат обмена: Первая = {a}, Вторая = {b}"); //Вывод
            }

        }
    }
