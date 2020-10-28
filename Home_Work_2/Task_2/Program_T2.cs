using System;
/*
 *   Задача №2
 *
 *   Написать метод подсчета количества цифр числа.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_2
    {
    class Program_T2
        {
        static void Main(string[] args)
            {
            int number, sum;

            Console.Write("Введите число: ");
            number = Convert.ToInt32(Console.ReadLine());

            //sum = number.ToString().Length; //Лёгкий способ

            sum = HowManyNumbers(number); //Вычесление через метод

            Console.WriteLine($"Колчиество цифр равно - {sum}");

            Console.ReadKey();
            }

        private static int HowManyNumbers(int number)
            {
            int sum = 0;
            while(number > 0)
                {
                sum++;
                number /= 10;
                }
            return sum;
            }
        }
    }
