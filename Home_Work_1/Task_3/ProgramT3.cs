using System;

/*
 * Задача №3
 * 
   а) Написать программу, которая подсчитывает расстояние между точками
      с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
      Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
   б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.

   Панов Алексей
 */

namespace Task_3 {
    class ProgramT3 {
        static void Main(string[] args) {
            double x1, y1, x2, y2, r1, r2;

            //Ввод координат x1 и y1
            Console.Write("Введие координату x1: ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введие координату y1: ");
            y1 = Convert.ToDouble(Console.ReadLine());

            //Ввод координат x2 и y2
            Console.Write("Введие координату x2: ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введие координату y2: ");
            y2 = Convert.ToDouble(Console.ReadLine());

            r1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); //Первый способ вычесления расстояния
            r2 = Distance(x1,y1,x2,y2); //Второй способ вычесления растояния

            Console.Write(Environment.NewLine+$"Растояние между точками равно:\r\nа)по формуле: {r1:F2}\r\nб)через метод: {r2:f2}"); //Вывод

            Console.ReadKey();
            }

        static double Distance(double x1, double y1, double x2, double y2) {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
        }
    }
