using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
/*
 * Задание №5
 * 
 *  **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет.
 *  Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
 *  Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
 *  Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. 
 *  Список вопросов ищите во вложении или воспользуйтесь интернетом.
 * 
 * Панов Алексей
 */
namespace Task_5
    {
    class Program
        {
        static void Main(string[] args)
            {
            Dictionary<string, string> questions = ReadingQuestions();
            Dictionary<string, string> fiveQuestion = ReadingQuestions();
            fiveQuestion = TakeRandomQuestion(questions);

            Console.WriteLine("Верю. Не верю.\r\nОтветьте на вопрос(Да/Нет)\r\n");
            TrueOrFalseGame(fiveQuestion);
            }

        private static void TrueOrFalseGame(Dictionary<string, string> fiveQuestion) //Реализация игры по готовой колекции
            {
            int bals = 0;
            foreach(KeyValuePair<string, string> item in fiveQuestion)
                {
                Console.WriteLine($"{item.Key}");
                string value = Console.ReadLine();
                if(value.ToUpper() == item.Value.ToUpper())
                    {
                    Console.WriteLine($"Верно: ответ {item.Value}");
                    bals++;
                    }
                else
                    {
                    Console.WriteLine($"Не верно: ответ {item.Value}");
                    }
                Console.WriteLine();
                }
            Console.WriteLine($"Количество набранных баллов: {bals}");
            }
        static Dictionary<string, string> ReadingQuestions() //Получение вопросов и ответов из файла data.txt
            {
            StreamReader str = new StreamReader("data.txt");
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while(!str.EndOfStream)
                {
                string text = str.ReadLine();
                string[] text2 = text.Split('.');
                dict.Add(text2[0], text2[1]);
                }
            str.Close();

            return dict;
            }
        static Dictionary<string,string> TakeRandomQuestion(Dictionary<string, string> question) //Получение 5ти вопросов
            {
            Random rnd = new Random();
            string[] str = new string[question.Count];
            int i = 0;

            foreach(KeyValuePair<string, string> item in question)
                {
                str[i] = item.Key;
                i++;
                }

            while(question.Count > 5)
                {
                int k = rnd.Next(question.Count);
                string text = str[k];
                question.Remove(text);
                str = RemoveString(str, k);
                }

            return question;
            }
        static string[] RemoveString(string[] str, int k) //Удаление из массива строк элемента с индексом k
            {
            string[] newStr = new string[str.Length - 1];
            for(int i = 0, j = 0; i < str.Length; i++)
                if(i != k)
                    {
                    newStr[j] = str[i]; 
                    j++;
                    }

            return newStr;
            }
        }
    }
