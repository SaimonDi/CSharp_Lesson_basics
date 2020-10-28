using System;
/*
 *   Задача №5
 *
 *   а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
 *      нужно ли человеку похудеть, набрать вес или всё в норме.
 *   б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_5
    {
    class Program_T5
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Добро пожаловать.");

            MassIndexCalculation();

            Console.ReadKey();
            }

        private static void MassIndexCalculation() //Расчёт индекса массы тела
            {
            double mass, height, indx;

            Console.Write("Введите массу в килограммах: ");
            mass = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите рост в метрах: ");
            height = Convert.ToDouble(Console.ReadLine());

            indx = mass / Math.Pow(height, 2);
            Console.WriteLine(Environment.NewLine + $"Ваш индекс массы тела равен: {indx:F1}кг/м^2");

            DietCalculation(indx, height); //Рассчёт необходимости диеты относительно индекса и массы по таблице ВОЗ
            }

        private static void DietCalculation(double indx, double height)
            {
            double mass;

            if(indx < 18.5)
                {
                mass = (18.5 - indx) * Math.Pow(height, 2);
                Console.WriteLine(Environment.NewLine + $"У вас дефицит массы.\r\nДо нормы нужно набрать {mass:F3}кг.");
                }
            else if(indx > 25)
                {
                mass = (indx - 25) * Math.Pow(height, 2);
                Console.WriteLine(Environment.NewLine + $"У вас избыток массы.\r\nДо нормы нужно скинуть {mass:F3}кг.");
                }
            else
                {
                Console.WriteLine(Environment.NewLine + $"Ваша масса тела в пределах нормы.");
                }
            }


        }
    }
