using ArrayLibrary;
using System;
using System.Collections.Generic;
/*
* Задание №3
* 
* а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, 
*    создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
*    Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив 
*    с измененными знаками у всех элементов массива (старый массив, остается без изменений),  метод Multi, 
*    умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
* б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
* в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
* 
* Панов Алексей
*/
namespace Task_3
    {

    public class ArrayClass
        {
        Dictionary<int, int> diction;
        private int[] array;

        public ArrayClass(int n) //Создание массива из n элементов
            {
            array = new int[n];
            }
        public ArrayClass(ArrayClass arr) //Копирование массива
            {
            ArrayClass tempArr = new ArrayClass(arr.Length);
            for(int i = 0; i < arr.Length; i++)
                {
                tempArr.SetNumb(i, arr.GetNumb(i));
                }
            }
        public ArrayClass(int n, int start, int step) //Создание массива из n элементов, start-число начала отсчёта, step- шаг отсчёта
            {
            array = new int[n];

            for(int i = 0; i < n; i++, start += step)
                {
                array[i] = start;
                }
            }

        public int GetNumb(int n) //Получение элемента по индексу
            {
            return array[n];
            }
        public int SetNumb(int index, int addNum) //Запись элемента в массив по индексу
            {
            return array[index] = addNum;
            }

        public int Add(ArrayClass arr, int n) //Добавления элемента в конец списка массива
            {
            ArrayClass tempArr = new ArrayClass(arr.Length + 1);
            return tempArr.SetNumb(arr.Length + 1, n);
            }

        public Dictionary<int, int> KeyValuePa() //Перевод элементов в коллекцию, подсчитывает частоту вхождения каждого элемента в массив
            {
            diction = new Dictionary<int, int>();

            foreach(int item in array)
                {
                int res;
                if(diction.TryGetValue(item, out res))
                    {
                    diction[item] += 1;
                    }
                else
                    {
                    diction.Add(item, 1);
                    }
                }

            return diction;
            }

        public int Length => array.Length; //Получение длинны массива

        public int Sum //Получение суммы всех элементов массива
            {
            get
                {
                int s = 0;
                foreach(int item in array)
                    {
                    s += item;
                    }
                return s;
                }
            }

        public int MaxCount //Получение количества максимальных элементов массива
            {
            get
                {
                int max = array[0], count = 0;

                foreach(int item in array)
                    if(item > max)
                        max = item;
                foreach(int item in array)
                    if(max == item)
                        count++;

                return count;
                }
            }

        public ArrayClass Multi(int multiNum) //Умножение каждого элемента массива на множитель
            {
            ArrayClass tempArr = new ArrayClass(array.Length);

            for(int i = 0; i < tempArr.Length; i++)
                {
                int x = array[i] * multiNum;
                tempArr.SetNumb(i, x);
                }

            return tempArr;
            }

        public ArrayClass Inverse() //Смена знака элементов массива
            {
            ArrayClass tempArr = new ArrayClass(array.Length);
            for(int i = 0; i < array.Length; i++)
                {
                tempArr.SetNumb(i, -array[i]);
                }
            return tempArr;
            }

        public void Print() //Вывод массива на экран
            {
            foreach(int item in array)
                {
                Console.Write($"{item} ");
                }
            Console.WriteLine();
            }
        }

    class Program
        {
        static void Main(string[] args)
            {
            Dictionary<int, int> diction = new Dictionary<int, int>();
            ArrayClass array = new ArrayClass(15, -5, 4);

            array.Print();
            Console.WriteLine();

            Console.WriteLine($"Количество максимальных = {array.MaxCount}");
            Console.WriteLine($"Сумма всех чисел = {array.Sum}");
            Console.WriteLine();

            ArrayClass array_2 = array.Inverse();
            array_2.Print();

            ArrayClass array_3 = array.Multi(5);
            array_3.Print();

            Console.WriteLine("----------------------");
            diction = array.KeyValuePa();

            foreach(KeyValuePair<int, int> item in diction)
                {
                Console.WriteLine($"Key = {item.Key}, Value = {item.Value}");
                }
            Console.WriteLine("----------------------");

            //Тоже самое, но ссылаясь на библиотеку
            Console.WriteLine(Environment.NewLine + "Методы созданные при помощи библиотеки.");
            ArrayLib arrayLib = new ArrayLib(10, 15, 2);

            arrayLib.Print();
            Console.WriteLine();

            Console.WriteLine($"Количество максимальных = {arrayLib.MaxCount}");
            Console.WriteLine($"Сумма всех чисел = {arrayLib.Sum}");
            Console.WriteLine();

            ArrayLib arrayLib_2 = arrayLib.Inverse();
            arrayLib_2.Print();

            ArrayLib arrayLib_3 = arrayLib.Multi(5);
            arrayLib_3.Print();
            }
        }
    }
