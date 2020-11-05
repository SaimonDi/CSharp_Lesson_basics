using System;
using System.IO;
/*
* Задание №2
* 
* Реализуйте задачу 1 в виде статического класса StaticClass;
* а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
* б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
* в)**Добавьте обработку ситуации отсутствия файла на диске.
* 
* Панов Алексей
*/
namespace Task_2
    {
    static class StaticClass
        {

        public static int FindForThree(int[] array) //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            {
            int count = 0;

            for(int i = 0; i < array.Length - 1; i++) //Поиск пар чисел
                {
                if((array[i] % 3 != 0) && (array[i + 1] % 3 == 0) || (array[i] % 3 == 0) && (array[i + 1] % 3 != 0))
                    {
                    count++;
                    }
                }

            return count;
            }

        public static int[] FileReader(string file) //б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
            {
            StreamReader sr = new StreamReader(file);
            int n = 0;
            while(!sr.EndOfStream)
                {
                string s = sr.ReadLine();
                n++;
                }
            int[] array = new int[n];

            sr.Close();

            sr = new StreamReader("data.txt");
            for(int i = 0; !sr.EndOfStream; i++)
                {
                array[i] = int.Parse(sr.ReadLine());
                }

            sr.Close();

            return array;
            }

        public static void Print(int[] array)
            {
            for(int i = 0; i < array.Length; i++) //Вывод списка
                {
                Console.Write($"{array[i],4}");
                }
            Console.WriteLine();
            }

        public static int[] InputRandom(int[] array)
            {
            Random rnd = new Random();
            for(int i = 0; i < array.Length; i++) //Запись случайных чисел
                {
                array[i] = rnd.Next(-10, 11);
                }
            return array;
            }


        }
    class Program
        {
        static void Main(string[] args)
            {
            int cols = 20, count;
            int[] array = new int[cols];

            array = StaticClass.InputRandom(array);
            count = StaticClass.FindForThree(array);

            int[] arrayStrim;
            string file = "data.txt";

            try
                {
                arrayStrim = StaticClass.FileReader(file);
                }
            catch(FileNotFoundException)
                {
                Console.WriteLine($"Файл {file} не найден или повреждён!");
                Console.WriteLine();
                throw;
                }

            StaticClass.Print(array);
            Console.WriteLine($"Количество пар делимых на 3 равно: {count}");
            Console.WriteLine();

            StaticClass.Print(arrayStrim);
            }
        }
    }
