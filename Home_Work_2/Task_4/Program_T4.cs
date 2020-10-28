using System;
/*
 *   Задача №4
 *
 *   Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
 *   На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
 *   Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
 *   программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
 *   
 *   Панов Алексей
 *   
*/
namespace Task_4
    {
    class Program_T4
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Добро пожаловать.\r\n");

            AttemptsToLogin();

            Console.ReadKey();
            }

        private static void AttemptsToLogin() //Метод повторяющий попытки ввести логин и пароль
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

        private static bool Authorization() //Ввод логина и пароля
            {
            string login, password;

            Console.Write("Введите логин: ");
            login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            password = Console.ReadLine();

            return login == "root" && password == "GeekBrains";
            }
        }
    }
