using System;
/*
*   Задача №6
*
*   *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
*   «Хорошим» называется число, которое делится на сумму своих цифр. 
*   Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
*   
*   Панов Алексей
*   
*/
namespace Task_6
    {
    class Program_T6
        {
        static void Main(string[] args)
            {
            DateTime start = DateTime.Now;

            GoodNumber();

            Console.WriteLine(DateTime.Now - start);
            Console.ReadKey();
            }

        private static void GoodNumber()
            {
            int num = 0, sum, tempNum;

            for(int i = 1; i < 1000000000; i++)
                {
                sum = 0;
                tempNum = i;

                while(tempNum != 0) //Вычесление суммы чисел
                    {
                    sum += tempNum % 10;
                    tempNum /= 10;
                    }

                if(i % sum == 0) //Проверка на то "хорошое" ли число
                    num++;
                }
            //Console.WriteLine($"{num} {i}");

            Console.WriteLine($"\"Хороших\" чисел: {num}");
            }
        }
    }
