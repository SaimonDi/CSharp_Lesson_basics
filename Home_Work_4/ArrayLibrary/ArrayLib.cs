using System;
/*
* Задание №3
* 
* б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
* 
* Панов Алексей
*/
namespace ArrayLibrary
    {
    public class ArrayLib
        {
        private int[] array;

        public ArrayLib(int n) //Создание массива из n элементов
            {
            array = new int[n];
            }
        public ArrayLib(ArrayLib arr) //Копирование массива 
            {
            ArrayLib tempArr = new ArrayLib(arr.Length);
            for(int i = 0; i < arr.Length; i++)
                {
                tempArr.SetNumb(i, arr.GetNumb(i));
                }
            }
        public ArrayLib(int n, int start, int step) //Создание массива из n элементов, start-число начала отсчёта, step- шаг отсчёта
            {
            array = new int[n];

            for(int i = 0; i < n; i++, start += step)
                {
                array[i] = start;
                }
            }

        public int GetNumb(int index) //Получение элемента по индексу
            {
            return array[index];
            }
        public int SetNumb(int index, int addNum) //Запись элемента в массив по индексу
            {
            return array[index] = addNum;
            }
        public int Add(ArrayLib arr, int n) //Добавления элемента в конец списка массива
            {
            ArrayLib tempArr = new ArrayLib(arr.Length + 1);
            return tempArr.SetNumb(arr.Length + 1, n);
            }

        public void Print() //Вывод массива на экран
            {
            foreach(int item in array)
                {
                Console.Write($"{item} ");
                }
            Console.WriteLine();
            }

        public ArrayLib Multi(int multiNum) //Умножение каждого элемента массива на множитель
            {
            ArrayLib tempArr = new ArrayLib(array.Length);

            for(int i = 0; i < tempArr.Length; i++)
                {
                int x = array[i] * multiNum;
                tempArr.SetNumb(i, x);
                }

            return tempArr;
            }
        public ArrayLib Inverse() //Смена знака элементов массива
            {
            ArrayLib tempArr = new ArrayLib(array.Length);
            for(int i = 0; i < array.Length; i++)
                {
                tempArr.SetNumb(i, -array[i]);
                }
            return tempArr;
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
        }
    }
