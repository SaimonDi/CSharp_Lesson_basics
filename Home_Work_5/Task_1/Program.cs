using System;
using Task_1.Helper;
/*
* Задание №1
* 
* Создать программу, которая будет проверять корректность ввода логина. 
* Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
* при этом цифра не может быть первой:
* а) без использования регулярных выражений;
* б) **с использованием регулярных выражений.
* 
* Панов Алексей
*/
namespace Task_1
    {
    class Program
        {
        static void Main(string[] args)
            {
            string login;

            do
                {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                HelperClass helper = new HelperClass();

                //Console.WriteLine($"Simple: {login} - {helper.IsLogin(login)}" + Environment.NewLine);
                Console.WriteLine($"Regular: {login} - {helper.IsLoginRegular(login)}" + Environment.NewLine);

                } while(login != "");

            }
        }
    }
