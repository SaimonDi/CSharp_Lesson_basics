using System;
/*
 *   Задача №7
 *
 *   a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
 *   б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_7
    {
    class Program_T7
        {
        static void Main(string[] args)
            {
            int sum = 0;

            Console.Write("Введите меньшее число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите большее число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            //Запускаем метод который выводит на экран числа от {а} до {b},
            //Заодно забираем от туда сумму этих чисел
            sum = DisplayingNumbers(a, b, sum);

            Console.Write(Environment.NewLine + $"Сумма чисел от а до b равна: {sum}");

            Console.ReadKey();
            }

        private static int DisplayingNumbers(int a, int b, int sum)
            {
            Console.Write($"{a} ");

            if(a < b) sum = DisplayingNumbers(a + 1, b, sum);

            //При "закрытии" рекурсии возвращаем сумму чисел и прибавляем к ней уменьшающийся знаменатель {а}.
            //Таким образом при "закрытии" сумма не будет обуняляться, а ей будет присваиваться значение закрытого метода.
            return sum + a;
            }
        }
    }
