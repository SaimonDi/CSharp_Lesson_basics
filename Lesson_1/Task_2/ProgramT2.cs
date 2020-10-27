using System;

/*
 * Задача №2
 * 
   Ввести вес и рост человека. 
   Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
   где m — масса тела в килограммах, h — рост в метрах.

   Панов Алексей
 */

namespace Task_2 {
    class ProgramT2 {
        static void Main(string[] args) {

            Console.Write("Приветствую вас в короткой программе для расчёта индекса массы тела.\r\nВведите вес в килограммах: ");
            double m=Convert.ToDouble(Console.ReadLine()); //Ввод веса в килограммах

            Console.Write("А теперь введите необходимый рост в метрах: ");
            double h=Convert.ToDouble(Console.ReadLine()); //Ввод высоты в метрах

            double i = m / (h * h); //Расчёт индекса

            Console.WriteLine($"Индекс массы тела равен: {i} кг/м^2"); //Вывод
            Console.ReadKey();
            }
        }
    }
