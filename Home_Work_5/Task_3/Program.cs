using System;
using System.Linq;
/*
 * Задание №3
 * 
 * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
 * а) с использованием методов C#;
 * б) *разработав собственный алгоритм.
 * Например:
 * badc являются перестановкой abcd.
 * 
 * Панов Алексей
 */
namespace Task_3
    {
    class Program
        {
        static void Main(string[] args)
            {
            string word_1 = "badc";
            string word_2 = "abcd";

            Console.WriteLine(word_1.ToUpper().OrderBy(x => x).SequenceEqual(word_2.ToUpper().OrderBy(x => x))); //а) с использованием методов C#

            Console.WriteLine(IsPermutation_1(word_1, word_2));
            Console.WriteLine(IsPermutation_2(word_1, word_2));

            }

        private static bool IsPermutation_1(string word1, string word2)
            {
            if(word1.Length != word2.Length)
                return false;

            word1 = word1.ToUpper();
            word2 = word2.ToUpper();

            char[] charWord_2 = word2.ToCharArray();

            for(int i = 0; i < charWord_2.Length; i++)
                if(word1.IndexOf(charWord_2[i]) == -1)
                    return false;

            return true;
            }

        private static bool IsPermutation_2(string word1, string word2)
            {
            word1 = word1.ToLower();
            word2 = word2.ToLower();

            char[] wording1 = word1.ToCharArray();
            char[] wording2 = word2.ToCharArray();
            int k = 0;

            foreach(char i in wording1)
                foreach(char j in wording2)
                    if(i == j) k++;

            return k == word1.Length && k == word2.Length;
            }
        }
    }
