using System;
/*
 *   Задача №3
 *
 *   С клавиатуры вводятся числа, пока не будет введен 0. 
 *   Подсчитать сумму всех нечетных положительных чисел.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_3
    {
    class Program_T3
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Введите числа: ");
            CountingOddNumbers();
            Console.ReadKey();
            }

        private static void CountingOddNumbers()
            {
            int number, sum = 0;

            do //Цикл Do/While для того, чтобы хотябы раз запросил ввод, а потом уже проверял необходимые условия
                {
                number = Convert.ToInt32(Console.ReadLine());

                if(number % 2 == 1 && number > 0)
                    sum += number;

                } while(number != 0);

            Console.WriteLine($"Сумма нечётных чисел равна - {sum}");
            }
        }
    }
