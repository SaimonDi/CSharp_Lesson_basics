using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
namespace Task_1.Helper
    {
    class HelperClass
        {
        public bool IsLogin(string login) //Проверка логина без регулярных выражений
            {
            if(login == "")
                {
                Console.WriteLine("Выход");
                return false;
                }

            char[] chLogin = login.ToCharArray();
            bool flag = false;

            if(chLogin[0] >= '0' && chLogin[0] <= '9')
                {
                Console.WriteLine("Логин не может начинаться с цифры");
                return false;
                }
            for(int i = 0; i < chLogin.Length; i++)
                {
                if((chLogin.Length >= 2 && chLogin.Length <= 10)
                    && ((chLogin[i] >= 'A' && chLogin[i] <= 'Z')
                    || (chLogin[i] >= 'a' && chLogin[i] <= 'z')
                    || (chLogin[i] >= '0' && chLogin[i] <= '9')))
                    {
                    flag = true;
                    }
                else
                    {
                    Console.WriteLine($"Введённый логин некорректен.\r\nЛогин может содержать от 2 до 10 символов, буквы латинского алфавита и цифры");
                    return false;
                    }
                }

            return flag;
            }

        public bool IsLoginRegular(string login) //Проверка логина с регулярными выражениями
            {
            Regex tryLogin = new Regex(@"^[^\d\s][A-Za-z0-9]{1,9}$");

            return tryLogin.IsMatch(login);
            }

        }
    }
