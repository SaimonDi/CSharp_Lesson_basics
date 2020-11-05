using System;
using System.IO;
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
namespace ArrayLibTwo
    {
    public class ArrayLibTwoDim
        {
        private int[,] array;
        private Random rnd;

        public ArrayLibTwoDim(int row, int cols) //Создание пустого двумерного массива
            {
            array = new int[row, cols];
            }
        public ArrayLibTwoDim(int row, int cols, int howMany) //Создание массива из случайных чисел
            {
            rnd = new Random();
            array = new int[row, cols];

            for(int i = 0; i < row; i++)
                for(int j = 0; j < cols; j++)
                    array[i, j] = rnd.Next(howMany);
            }
        public ArrayLibTwoDim(int row, int cols, string txt, string file) //Создание массива и запись текста в файл
            {
            array = new int[row, cols];
            TextInFile(txt, file);
            FileInArray(row, cols, file);
            }

        public void Print() //Вывод двумерного массива
            {
            for(int i = 0; i < array.GetLength(0); i++)
                {
                for(int j = 0; j < array.GetLength(1); j++)
                    {
                    Console.Write($"{array[i, j]}\t");
                    }
                Console.WriteLine();
                }
            Console.WriteLine();
            }
        public void TextInFile(string txt, string file) //Запись текста в файл
            {
            StreamWriter sw;

            try
                {
                sw = new StreamWriter(file, true);
                }
            catch(FileNotFoundException)
                {
                Console.WriteLine($"Файл {file} не найден");
                throw;
                }

            sw.Write($"{txt}.");
            sw.Close();
            }
        public void FileInArray(int row, int cols, string file) //Запись чисел в двумерный массив
            {
            string[] text = FileOut(file);
            int k = 0, res;
            try
                {
                for(int i = 0; i < row && k < text.Length; i++)
                    for(int j = 0; j < cols && k < text.Length; j++, k++)
                        {
                        while(!int.TryParse(text[k], out res)) { k++; if(k >= text.Length) break; }

                        if(k != text.Length)
                            array[i, j] = Convert.ToInt32(text[k]);
                        }
                }
            catch(FormatException)
                {
                Console.WriteLine("Неверный формат");
                throw;
                }
            }
        public string[] FileOut(string file) //Чтение файла
            {
            StreamReader sr;

            try
                {
                sr = new StreamReader(file);
                }
            catch(FileNotFoundException)
                {
                Console.WriteLine($"Файл {file} не найден");
                throw;
                }

            string txt = "";
            while(!sr.EndOfStream)
                {
                txt += sr.ReadLine();
                }
            string[] text = txt.Split('.');
            return text;
            }

        public int Sum() //Получение суммы всех чисел в двумерном массиве
            {
            int sum = 0;
            for(int i = 0; i < array.GetLength(0); i++)
                for(int j = 0; j < array.GetLength(1); j++)
                    sum += array[i, j];

            return sum;
            }
        public int SumForMin(ref int min) //Получение суммы всех чисел в двумерном массиве не меньше минимального числа
            {
            int sum = 0;
            for(int i = 0; i < array.GetLength(0); i++)
                for(int j = 0; j < array.GetLength(1); j++)
                    if(array[i, j] > min)
                        sum += array[i, j];


            return sum;
            }
        public int Maxmimum(out int row, out int col) //Получение номера максимального массива
            {
            int max = Max;
            row = 0;
            col = 0;

            for(int i = 0; i < array.GetLength(0); i++)
                for(int j = 0; j < array.GetLength(1); j++)
                    if(array[i, j] == max)
                        {
                        max = Convert.ToInt32(i.ToString() + j.ToString());
                        row = i; col = j;
                        }

            return max;
            }

        public int Min //Минимальное число в двумерном массиве
            {
            get
                {
                int min = array[0, 0];
                for(int i = 0; i < array.GetLength(0); i++)
                    for(int j = 0; j < array.GetLength(1); j++)
                        if(array[i, j] < min)
                            min = array[i, j];

                return min;
                }
            }
        public int Max //Максимальное число в двумерном массиве
            {
            get
                {
                int max = array[0, 0];
                for(int i = 0; i < array.GetLength(0); i++)
                    for(int j = 0; j < array.GetLength(1); j++)
                        if(array[i, j] > max)
                            max = array[i, j];

                return max;
                }
            }
        public int GetLength(int x)
            {
            return array.GetLength(x);
            }
        }
    }
