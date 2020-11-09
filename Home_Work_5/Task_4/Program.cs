using System;
using System.IO;

/*
* Задание №4
* 
*  *Задача ЕГЭ.
* На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
* В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
* каждая из следующих N строк имеет следующий формат:
* 
* <Фамилия> <Имя> <оценки>,
* 
* где <Фамилия> — строка, состоящая не более чем из 20 символов, 
* <Имя> — строка, состоящая не более чем из 15 символов, 
* <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
* <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
* 
* Иванов Петр 4 5 3
* 
* Требуется написать как можно более эффективную программу, 
* которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
* Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, 
* следует вывести и их фамилии и имена.
* 
* Панов Алексей
*/
namespace Task_4
    {
    class Program
        {
        static void Main(string[] args)
            {
            Students[] students = StudentList();
            students = BadStudents(students);
            Print(students);
            }

        struct Students
            {
            public string FIO;
            public int rat1, rat2, rat3;
            }
        private static Students[] StudentList() //Генерирует список учеников из файла data.txt
            {
            StreamReader str = new StreamReader("data.txt");
            int howManyStudents = Convert.ToInt32(str.ReadLine());
            Console.WriteLine($"Количество учеников: {howManyStudents}");
            Students[] students = new Students[howManyStudents];

            for(int i = 0; i < howManyStudents; i++)
                {
                string txt = str.ReadLine();
                string[] tempText = txt.Split(' ');

                students[i].FIO = $"{tempText[0]} {tempText[1]}";
                students[i].rat1 = Convert.ToInt32(tempText[2]);
                students[i].rat2 = Convert.ToInt32(tempText[3]);
                students[i].rat3 = Convert.ToInt32(tempText[4]);
                }
            str.Close();

            return students;
            }
        private static Students[] BadStudents(Students[] students)//Ищем "плохих" учеников
            {
            Students[] badStudents;
            double min = (students[0].rat1 + students[0].rat2 + students[0].rat3) / 3;
            for(int i = 0; i < students.Length; i++)
                {
                double middle = (students[i].rat1 + students[i].rat2 + students[i].rat3) / 3;
                if(min > middle)
                    min = middle;
                }

            int k = 0, j=-1;
            do
                {
                j++;
                k += HowManyBad(students, min + j);
                } while(k < 3); //Пока количество плохих не будет больше или равно 3

            badStudents = new Students[k];
            badStudents = RecodBadStudents(students, badStudents, min, j);

            return badStudents;
            }

        private static int HowManyBad(Students[] students, double min)//Выясняем как много плохих учеников
            {
            int k = 0;

            foreach(Students item in students)
                if(min == ((item.rat1 + item.rat2 + item.rat3) / 3))
                    k++;
            return k;
            }
        private static Students[] RecodBadStudents(Students[] students, Students[] badStudents, double min, int howManyNeed)//Записываем плохих учеником в список
            {
            int j = 0, k=0;
            while(k<=howManyNeed) 
                {
                for(int i = 0; i < students.Length; i++)
                    {
                    double middle = (students[i].rat1 + students[i].rat2 + students[i].rat3) / 3;
                    if(min+k == middle)
                        {
                        badStudents[j] = students[i];
                        j++;
                        }
                    }
                k++;
                }

            return badStudents;
            }
        private static void Print(Students[] students) //Вывод на экран списка
            {
            for(int i = 0; i < students.Length; i++)
                {
                double middle = (students[i].rat1 + students[i].rat2 + students[i].rat3) / 3;
                Console.WriteLine($"{students[i].FIO} {students[i].rat1} {students[i].rat2} {students[i].rat3} Средняя оценка {middle}");
                }
            }
        }
    }
