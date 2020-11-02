using System;

/*
 * Задание №1
 * 
 * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
 * б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
 * в) Добавить диалог с использованием switch демонстрирующий работу класса.
 * 
 * Панов Алексей
 */

namespace Task_1
    {

    class ComplexClass
        {

        public double im;
        public double re;

        public ComplexClass Plus(ComplexClass x2)
            {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + this.im;
            x3.re = x2.re + this.re;
            return x3;
            }

        public ComplexClass Minus(ComplexClass x2) //б) Разница комплексных чисел
            {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im - this.im;
            x3.re = x2.re - this.re;
            return x3;
            }

        public ComplexClass Multi(ComplexClass x2) //б) Произведение комплексных чисел 
            {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im * this.im;
            x3.re = x2.re * this.re;
            return x3;
            }

        public string ToString()
            {
            return re + "+" + im + "i";
            }
        }

    struct ComplexStruct
        {

        public double im;
        public double re;

        public ComplexStruct Plus(ComplexStruct x)
            {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
            }

        public ComplexStruct Minus(ComplexStruct x) //а) Вычитание комплексных чисел
            {
            ComplexStruct y;
            y.im = x.im - im;
            y.re = x.re - re;
            return y;
            }

        public ComplexStruct Multi(ComplexStruct x)
            {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
            }

        public string ToString()
            {
            return re + "+" + im + "i";
            }

        }

    class Program
        {
        static void Main(string[] args)
            {
            int exitnumb;


            try
                {
                Console.Write("Какую операцию произвести? \r\n" +
                    "\r\n" +
                    "1- Plus(Структура)\r\n" +
                    "2- Minus(Структура)\r\n" +
                    "3- Multi(Структура)\r\n" +
                    "4- Plus(Класс)\r\n" +
                    "5- Minus(Класс)\r\n" +
                    "6- Multi(класс)\r\n" +
                    "11- Изменить числа для переменных структуры\r\n" +
                    "12- Изменить числа для переменных класса\r\n" +
                    "0- Выйти\r\n" +
                    "\r\n" +
                    "Введите номер операции:\r\n");

                do
                    {
                    exitnumb = SwitchMetod();
                    } while(exitnumb != 0);

                }
            catch
                {
                Console.WriteLine("Необходимо ввести число!");
                }

            }

        private static int SwitchMetod()
            {

            #region Объявление переменных

            ComplexStruct resultStr;
            ComplexClass resultCl;

            ComplexStruct complexStr1;
            complexStr1.re = 1;
            complexStr1.im = 1;

            ComplexStruct complexStr2;
            complexStr2.re = 2;
            complexStr2.im = 2;

            ComplexClass complexCl1 = new ComplexClass();
            complexCl1.re = 1;
            complexCl1.im = 1;

            ComplexClass complexCl2 = new ComplexClass();
            complexCl2.re = 2;
            complexCl2.im = 2;

            #endregion

            int numberSwitch = Convert.ToInt32(Console.ReadLine());

            switch(numberSwitch)
                {
                case 1:
                //Сложение комплексных чисел
                resultStr = complexStr1.Plus(complexStr2);
                Console.WriteLine(resultStr.ToString());

                break;

                case 2:
                //Разница комплексных чисел
                resultStr = complexStr1.Minus(complexStr2); //а) Демонстрация вычитания комплексных чисел
                Console.WriteLine(resultStr.ToString());

                break;

                case 3:
                //Произведение комплексных чисел(из методички)
                resultStr = complexStr1.Multi(complexStr2);
                Console.WriteLine(resultStr.ToString());

                break;

                case 4:
                //Сложение комплексных чисел
                resultCl = complexCl1.Plus(complexCl2);
                Console.WriteLine(resultCl.ToString());

                break;

                case 5:
                //Разница комплексных чисел
                resultCl = complexCl1.Minus(complexCl2); //б) Разница комплексных чисел
                Console.WriteLine(resultCl.ToString());

                break;

                case 6:
                //Произведение комплексных чисел
                resultCl = complexCl1.Multi(complexCl2); //б) Произведение комплексных чисел 
                Console.WriteLine(resultCl.ToString());

                break;

                case 11:

                //Изменить числа для переменных структуры
                Console.Write("Первое комплексное число первой пары: ");
                complexStr1.re = Convert.ToInt32(Console.ReadLine());
                Console.Write("Второе комплексное число первой пары: ");
                complexStr1.im = Convert.ToInt32(Console.ReadLine());

                Console.Write("Первое комплексное число второй пары: ");
                complexStr1.re = Convert.ToInt32(Console.ReadLine());
                Console.Write("Второе комплексное число второй пары: ");
                complexStr1.im = Convert.ToInt32(Console.ReadLine());

                break;

                case 12:
                //Изменить числа для переменных класса
                Console.Write("Первое комплексное число первой пары: ");
                complexCl1.re = Convert.ToInt32(Console.ReadLine());
                Console.Write("Второе комплексное число первой пары: ");
                complexCl1.im = Convert.ToInt32(Console.ReadLine());

                Console.Write("Первое комплексное число первой пары: ");
                complexCl2.re = Convert.ToInt32(Console.ReadLine());
                Console.Write("Второе комплексное число первой пары: ");
                complexCl2.im = Convert.ToInt32(Console.ReadLine());

                break;

                case 0:

                Console.WriteLine("До Свидания!");
                break;

                default:

                Console.WriteLine("Неизвестное число.");
                break;
                }

            return numberSwitch;
            }
        }

    }
