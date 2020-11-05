using System;
using System.Collections.Generic;
using System.IO;
/*
 * Задание №4
 * 
 * Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
 * Создайте структуру Account, содержащую Login и Password.
 * 
 * Задача из 2-го урока
 * 
 * Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
 * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
 * Используя метод проверки логина и пароля, написать программу: 
 * пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
 * С помощью цикла do while ограничить ввод пароля тремя попытками.
 * 
 * Панов Алексей
 */
namespace Task_4
    {
    class Program
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Добро пожаловать.\r\n");
            Account.AttemptsToLogin();
            Console.ReadKey();
            }
        }

    struct Account
        {
        private static Dictionary<string, string> accountList;
        private static Dictionary<string, string> FileReader() //Считывание логина и пароля
            {
            accountList = new Dictionary<string, string>();

            StreamReader sr = new StreamReader("data.txt");
            while(!sr.EndOfStream)
                {
                string s = sr.ReadLine();
                string[] split = s.Split(' ');
                accountList.Add(split[0], split[1]);
                }

            sr.Close();

            return accountList;
            }

        private static bool Authorization() //Ввод логина и пароля
            {
            accountList = FileReader();
            string login, password;

            Console.Write("Введите логин: ");
            login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            password = Console.ReadLine();

            return accountList.ContainsKey(login) && accountList.ContainsValue(password);
            }
        public static void AttemptsToLogin() //Метод повторяющий попытки ввести логин и пароль
            {
            int Attempts = 3;
            do
                {
                if(Authorization())
                    {
                    Console.WriteLine("Вход выполнен успешно.");
                    break;
                    }
                else
                    {
                    Attempts--;
                    Console.WriteLine($"Не верный логин или пароль.\r\nОсталось попыток: {Attempts}" + Environment.NewLine);
                    }
                } while(Attempts != 0);

            if(Attempts == 0) { Console.WriteLine("Вход заблокирован!"); } //Если логин и пароль введут три раза не верно, вылезет это сообщение.
            }
        }
    }
