using ArrayLibTwo;
using System;
/*
 * Задание №5
 * 
 * *а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, 
 *     заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, 
 *     сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
 *     возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива 
 *     (через параметры, используя модификатор ref или out).
 * **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
 * **в) Обработать возможные исключительные ситуации при работе с файлами.
 * 
 * Панов Алексей
 */
namespace Task_5
    {
    class Program
        {
        static void Main(string[] args)
            {
            string file = "data.txt", file2 = "data2.txt";
            int row = 5, cols = 5, x, y;
            ArrayLibTwoDim array_1 = new ArrayLibTwoDim(row, cols, 100);
            array_1.Print();

            array_1.Maxmimum(out x, out y);
            Console.WriteLine($"Максимальное значение: Строка {x + 1} Колонка{y + 1}" + Environment.NewLine);

            ArrayLibTwoDim array_2 = new ArrayLibTwoDim(row, cols, "123", file);
            array_2.Print();

            ArrayLibTwoDim array_3 = new ArrayLibTwoDim(row, cols);

            for(int i = 0; i < row; i++)
                for(int j = 0; j < cols; j++)
                    array_3.TextInFile($"{i}{j}", file2);

            array_3.FileInArray(row, cols, file2);
            array_3.Print();

            }
        }
    }
