using System;
/*
* Задание №1
* 
* Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
* Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
* 
* Панов Алексей
*/
namespace Task_1
    {
    public delegate double Fun(double a, double x);
    class Program
        {

        public static void Table(Fun F, double a, double x, double b)
            {
            Console.WriteLine("----- X ----- Y -----");
            while(x <= b)
                {
                Console.WriteLine($"| {x,8:F3} | {F(a, x),8:F3} |");
                a += 2;
                x += 1;
                }
            Console.WriteLine("---------------------");
            }

        public static double FuncA(double a, double x) //функция a*x^2
            {
            return a * Math.Pow(x, 2);
            }
        public static double FuncSin(double a, double x) //функция a*sin(x)
            {
            return a * Math.Sin(x);
            }

        static void Main(string[] args)
            {
            Console.WriteLine("Таблица функции FuncA:");

            Table(FuncA, -6, -3, 3);
            Console.WriteLine("Таблица функции Sin:");
            Table(FuncSin, -6, -3, 3);
            }
        }
    }
