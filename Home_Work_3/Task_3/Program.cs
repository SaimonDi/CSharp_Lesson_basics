using System;
/*
* Задание №3.
* 
* *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
*  Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
*  Написать программу, демонстрирующую все разработанные элементы класса.
* * Добавить свойства типа int для доступа к числителю и знаменателю;
* * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
* ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
* *** Добавить упрощение дробей.
* 
* Панов Алексей
*/
namespace Task_3
    {
    class Rational
        {
        int numerator, denominator;
        public double doubNumber => (double)numerator / (double)denominator; //Идендификатор только для чтения

        Rational firstRatio;

        public Rational(int x, int y)
            {
            this.numerator = x;
            this.denominator = y;
            }

        public Rational(Rational temp)
            {
            this.numerator = temp.numerator;
            this.denominator = temp.denominator;
            }

        public Rational() { }

        //public void PrintRatio() //Выводит показателей
        //    {
        //    Console.WriteLine($"{numerator}/{denominator} = {doubNumber:F2}");
        //    }

        public Rational Plus(Rational otherRatio) //Сложение
            {
            Rational tempRatio = new Rational(otherRatio);
            Rational temp = NOK(tempRatio);

            temp.numerator += tempRatio.numerator;

            return EazyRatio(temp);
            }

        public Rational Minus(Rational otherRatio) //Разность
            {
            Rational tempRatio = new Rational(otherRatio);
            Rational temp = NOK(tempRatio);

            temp.numerator -= tempRatio.numerator;

            return EazyRatio(temp);
            }

        public Rational Multi(Rational otherRatio) //Произведение
            {
            Rational temp = new Rational();

            temp.numerator = numerator * otherRatio.numerator;
            temp.denominator = denominator * otherRatio.denominator;

            return EazyRatio(temp);
            }

        public Rational Divis(Rational otherRatio) //Деление
            {
            Rational temp = new Rational();

            temp.numerator = numerator * otherRatio.denominator;
            temp.denominator = denominator * otherRatio.numerator;

            return EazyRatio(temp);
            }

        private Rational NOK(Rational secondRatio) //Приведение дробей к общему знаменателю 
            {
            firstRatio = new Rational(numerator, denominator);
            int tempDen1 = firstRatio.denominator, tempDen2 = secondRatio.denominator, k = 1, j = 1;

            while(firstRatio.denominator != secondRatio.denominator) //Поиск наименьшего общего кратного(НОК)
                {
                if(firstRatio.denominator > secondRatio.denominator)
                    {
                    secondRatio.denominator += tempDen2;
                    k++;
                    }
                else if(firstRatio.denominator < secondRatio.denominator)
                    {
                    firstRatio.denominator += tempDen1;
                    j++;
                    }
                }

            //Привидение числетелей к общему знаменателю
            firstRatio.numerator *= j;
            secondRatio.numerator *= k;

            return firstRatio;
            }

        private Rational EazyRatio(Rational ratio) //Упрощение дроби
            {
            int k = 1, j = 1;
            Rational temp = new Rational(ratio);

            while((k <= temp.numerator) && (k <= temp.denominator))
                {
                if((temp.numerator % k == 0) && (temp.denominator % k == 0)) j = k;
                k++;
                }

            if(temp.numerator % j == 0 && temp.denominator % j == 0)
                {
                temp.numerator /= j;
                temp.denominator /= j;
                }

            return temp;
            }

        public string ToString()
            {
            return $"{numerator}/{denominator} = {doubNumber:F2}";
            }

        }


    class Program
        {
        static void Main(string[] args)
            {

            Console.WriteLine("Ввод первого числа.");
            Rational rational_1 = InputNumber();
            Console.WriteLine("Ввод второго числа.");
            Rational rational_2 = InputNumber();

            //Rational rational_1 = new Rational(20, 15);
            //Rational rational_2 = new Rational(5, 9);

            //rational_1.PrintRatio();
            //rational_2.PrintRatio();
            Console.WriteLine("Сложение: " + rational_1.Plus(rational_2).ToString());
            Console.WriteLine("Вычитание: " + rational_1.Minus(rational_2).ToString());
            Console.WriteLine("Умножение: " + rational_1.Multi(rational_2).ToString());
            Console.WriteLine("Деление: " + rational_1.Divis(rational_2).ToString());

            }

        private static Rational InputNumber()
            {
            int x, y;

            Console.Write("Введите числитель: ");
            x = Convert.ToInt32(Console.ReadLine());

            do //Цикличная проверка знаменателя
                {
                Console.Write("Введите знаменатель: ");
                y = Convert.ToInt32(Console.ReadLine());
                if(y == 0)
                    Console.WriteLine("Знаменатель не может равнятся нулю");
                } while(y == 0);


            Rational temp = new Rational(x, y);
            return temp;
            }
        }
    }
