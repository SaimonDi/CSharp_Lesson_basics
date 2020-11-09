using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Задание №2
 * 
 * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
 *  а) Вывести только те слова сообщения,  которые содержат не более n букв.
 *  б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
 *  в) Найти самое длинное слово сообщения.
 *  г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
 *  д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него 
 *     передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое 
 *     из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
 * 
 * Панов Алексей
 */
namespace Task_2
    {
    static class Message
        {
        public static void WordLength(string word, int n) //Вывести только те слова сообщения, которые содержат не более n букв
            {
            Console.WriteLine($"Исходный текст: {word}");
            string[] tempString = GettingWords(word);

            Console.Write($"Удаялены слова содержащие больше \"{n}\" букв: ");

            for(int i = 0; i < tempString.Length; i++)
                if(tempString[i].Length <= n)
                    Console.Write($"{tempString[i]} ");
            }
        public static void DeleteWordsEndWhithChar(string word, char n) //Удалить из сообщения все слова, которые заканчиваются на заданный символ
            {
            Console.WriteLine($"Исходный текст: {word}");
            string[] tempString = GettingWords(word);

            Console.Write($"Удалены слова которые заканчиваются на символ \"{n}\": ");
            for(int i = 0; i < tempString.Length; i++)
                if(tempString[i][tempString[i].Length - 1] != n)
                    Console.Write($"{tempString[i]} ");
            }
        public static void LongestWord(string word) //Найти самое длинное слово сообщения
            {
            Console.WriteLine($"Исходный текст: {word}");
            string[] tempString = GettingWords(word);
            int max = tempString[0].Length;

            Console.Write($"Самые длинные слова: ");
            for(int i = 0; i < tempString.Length; i++)
                if(tempString[i].Length >= max)
                    max = tempString[i].Length;

            StringBuilder str = new StringBuilder(); //Сформировать строку с помощью StringBuilder из самых длинных слов сообщения
            for(int i = 0; i < tempString.Length; i++)
                if(tempString[i].Length == max)
                    str.Append(tempString[i] + " ");

            Console.Write($"{str}");
            }

        public static Dictionary<string, int> TextFrequency(string[] str, string word) //Производит частотный анализ текста
            {
            Dictionary<string, int> list = new Dictionary<string, int>();

            Console.WriteLine($"Исходный текст: {word}");
            string[] tempString = GettingWords(word);

            foreach(string item in str)
                list.Add(item, 0);

            foreach(string item in tempString)
                if(list.ContainsKey(item))
                    list[item] += 1;

            return list;
            }

        private static string[] GettingWords(string word)  //Убирает знаки препинания и возвращает массив строк из слов
            {
            StringBuilder tempWord = new StringBuilder(word);

            for(int i = 0; i < tempWord.Length;)
                if(char.IsPunctuation(tempWord[i]))
                    tempWord.Remove(i, 1);
                else i++;

            string str = tempWord.ToString();
            string[] tempString = str.Split(' ');
            return tempString;
            }
        }
    }
