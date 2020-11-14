using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
* Задание №2
* 
* Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
* а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
* б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
* в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
* возвращает минимум через параметр.
* 
* Панов Алексей
*/
namespace Task_2
    {
    delegate double Fun(double x);
    class Program
        {
        static void Main(string[] args)
            {
            Menu();
            List<double> list = Load("data.bin");

            Console.WriteLine($"Min = {list.Min():F3}");
            foreach(double item in list)
                Console.WriteLine($"{item,6}|");
            }

        public static void SaveFunc(string fileName, Fun F, double a, double b, double h)
            {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;

            while(x <= b)
                {
                bw.Write(F(x));
                x += h;// x=x+h;
                }

            bw.Close();
            fs.Close();
            }
        public static List<double> Load(string fileName)
            {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double d;

            List<double> list = new List<double>();

            for(int i = 0; i < fs.Length / sizeof(double); i++)
                {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                list.Add(d);
                }
            bw.Close();
            fs.Close();

            return list;
            }
        private static void Menu()//Меню консольного запроса
            {
            //Пример из методички a = -100, b = 100, h = 0.5, number = 1

            double a, b, h, number;
            Fun Function = null;
            bool falg;

            List<object> listFun = new List<object>();
            listFun.Add(new Fun(F));
            listFun.Add(new Fun(A));
            listFun.Add(new Fun(H));
            listFun.Add(new Fun(Sin));
            listFun.Add(new Fun(Cos));

            do
                {
                number = Vvod("Выберите метод: \r\n" +
                            "1. x^2 - 50 * x + 10\r\n" +
                            "2. x^2\r\n" +
                            "3. x^3\r\n" +
                            "4. Sin(x)\r\n" +
                            "5. Cos(x)\r\n" +
                            "Введите номер необходимого метода: ");
                falg = number <= 0 || number > 5;
                if(falg) Console.WriteLine("Такой функции в списке нет!" + Environment.NewLine);
                } while(falg);

            a = Vvod("Введите начальное значение: ");
            b = Vvod("Введите конечное значение: ");
            h = Vvod("Введите шаг: ");

            Function = (Fun)listFun[(int)number - 1];

            SaveFunc("data.bin", Function, a, b, h);
            }
        private static double Vvod(string s) //Ввод с проверкой
            {
            string str;
            double y;
            do
                {
                Console.Write(s);
                str = Console.ReadLine();
                if(!double.TryParse(str, out y)) Console.WriteLine("Необходимо ввести число!" + Environment.NewLine);
                } while(!double.TryParse(str, out y));

            return y;
            }

        #region Функции

        public static double F(double x)//x^2 - 50 * x + 10
            {
            return x * x - 50 * x + 10;
            }
        public static double A(double x)//x^2
            {
            return x * x;
            }
        public static double H(double x)//x^3
            {
            return x * x * x;
            }
        public static double Sin(double x)//Функция Sin(x)
            {
            return Math.Sin(x);
            }
        public static double Cos(double x)//Функция Cos(x)
            {
            return Math.Cos(x);
            }

        #endregion

        }

    }
