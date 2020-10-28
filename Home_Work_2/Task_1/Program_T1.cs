using System;
/*
 *   Задача №1
 *
 *   Написать метод, возвращающий минимальное из трёх чисел.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_1
    {
    class Program_T1
        {
        static void Main(string[] args)
            {
            int a, b, c;
            Console.Write("Введите первое число: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите третье число: ");
            c = Convert.ToInt32(Console.ReadLine());

            Minimum(a, b, c);

            Console.ReadKey();
            }

        private static void Minimum(int a, int b, int c)
            {
            int min;

            if(a != b && a != c && b != c)
                {
                if(a < b && a < c)
                    min = a;
                else if(b < a && b < c)
                    min = b;
                else
                    min = c;
                Console.WriteLine($"Минимальное значение равно - {min}");
                }
            else
                Console.WriteLine("Есть равные числа!");
            }
        }
    }
