using System;
using System.Collections.Generic;
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
    class Program
        {
        static void Main(string[] args)
            {
            string word = "Утром трава зеленее, хотя кажется что синяя";
            string word_2 = "Если месяц буквой \"С\", Значит, старый месяц; Если палочку в довес ты к нему привесишь и получишь букву \"Р\", Значит, он растущий, Значит, скоро, верь-не верь, Станет он толстущий.";
            string[] manyWords = { "Значит", "Если", "месяц", "человек", "скоро" };
            Console.WriteLine();
            Message.WordLength(word, 5);
            Console.WriteLine(Environment.NewLine + "----------------------");
            Message.DeleteWordsEndWhithChar(word, 'я');
            Console.WriteLine(Environment.NewLine + "----------------------");
            Message.LongestWord(word);
            Console.WriteLine(Environment.NewLine + "----------------------");

            Dictionary<string, int> list = new Dictionary<string, int>();
            list = Message.TextFrequency(manyWords, word_2);

            foreach(KeyValuePair<string, int> item in list)
                Console.WriteLine($"Слово: {item.Key}. Совпадений: {item.Value}");

            }
        }

    }
