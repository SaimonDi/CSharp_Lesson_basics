using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Задание №2.
 * 
 * а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
 * Требуется подсчитать сумму всех нечётных положительных чисел. 
 * Сами числа и сумму вывести на экран, используя tryParse.
 * 
 * Панов Алексей
 */
namespace Task_2
    {
    class Program
        {
        static void Main(string[] args)
            {
            int number, sum = 0;
            bool flagForTry;

            Console.WriteLine("Введите числа: ");

            do
                {
                do
                    {
                    string text = Console.ReadLine();
                    flagForTry = int.TryParse(text, out number);
                    } while(!flagForTry);

                if(number % 2 == 1) sum += number;

                Console.WriteLine($"Сумма нечетных чисел: {sum}. Введенно число: {number}");
                } while(number!=0);

            }
        }
    }
