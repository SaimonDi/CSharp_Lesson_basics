using System;

/*
 * Задача №1.
 * 
   Написать программу «Анкета». 
   Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
   Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
   В результате вся информация выводится в одну строчку:
        а) используя  склеивание;
	    б) используя форматированный вывод;
	    в) используя вывод со знаком $.

    Панов Алексей

 */

namespace Task_1 {
    class ProgramT1 {
        static void Main(string[] args) {
            Console.WriteLine("Доброго времени суток!\n\r\n\rПожалуйста введите ваши данные...");

            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine(); //Ввод имени
            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine(); //Ввод фамилии

            Console.Write("Введите ваш возраст: ");
            int age = Convert.ToInt32(Console.ReadLine()); //Ввод возраста

            Console.Write("Введите ваш рост в метрах: ");
            double height = Convert.ToDouble(Console.ReadLine()); //Ввод роста

            Console.Write("Введите ваш вес в килограммах: ");
            double weight = Convert.ToDouble(Console.ReadLine()); //Ввод веса
            Console.WriteLine();

            Console.Write("Здравствуйте " + name + " " + surname + ". ");//Склеивание
            Console.Write($"Вам {age} лет. ");//Вывод со знаком $
            Console.Write("Ваш рост = {0:F2}м, а вес = {1:F3}кг", height, weight);//форматированый вывод

            Console.ReadKey();

            }
        }
    }
