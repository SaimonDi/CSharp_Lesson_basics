using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
/*
* Задание №3
* 
* Переделать программу «Пример использования коллекций» для решения следующих задач:
* а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
* б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
* в) отсортировать список по возрасту студента;
* г) *отсортировать список по курсу и возрасту студента;
* д) разработать единый метод подсчета количества студентов по различным параметрам
* выбора с помощью делегата и методов предикатов.
* 
* Панов Алексей
*/
namespace Task_3
    {
    delegate List<Student> Sorting(List<Student> students);
    delegate void Find(List<Student> students, string str, int number);
    class Student
        {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;

        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
            {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
            }
        }
    class Program
        {
        static void Main(string[] args)
            {
            DateTime dt = DateTime.Now;
            List<Student> list = ReadStudents();
            Console.WriteLine("Всего студентов:" + list.Count);

            Finder(list, DelegFindCourse, null, 5);
            Finder(list, DelegFindCourse, null, 6);

            Finder(list, DelegFindAgeCourse, null, 18);
            Finder(list, DelegFindAgeCourse, null, 19);
            Finder(list, DelegFindAgeCourse, null, 20);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Список студнетов: ");
            list = Sorting(list, DelegateAgeCourse);
            foreach(var item in list)
                Console.WriteLine(item.firstName);

            Console.WriteLine(DateTime.Now - dt);
            }

        public static List<Student> ReadStudents()
            {
            List<Student> list = new List<Student>();// Создаем список студентов
            StreamReader sr = new StreamReader("students_6.csv", Encoding.GetEncoding(1251));

            while(!sr.EndOfStream)
                {
                try
                    {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    }
                catch(Exception e)
                    {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");

                    // Выход из Main
                    if(Console.ReadKey().Key == ConsoleKey.Escape) return null;
                    }
                }
            sr.Close();
            return list;
            }

        #region Сбор данных
        public static void Finder(List<Student> students, Find find, string findString, int findNumreic)
            {
            find(students, findString, findNumreic);
            }

        public static void DelegFindAgeCourse(List<Student> students, string find, int age)
            {
            List<int> studAge = new List<int>();
            
            foreach(var item in students)
                if(item.age == age && !studAge.Contains(item.course)) studAge.Add(item.course);

            Console.Write($"\r\nВ возрасте {age} учатся на курсах: ");
            for(int i = 0; i < studAge.Count; i++)
                Console.Write($"{studAge[i]}");
            }
        public static void DelegFindAge(List<Student> students, string find, int age)
            {
            find = null;
            int numeric = 0;
            foreach(var item in students)
                if(item.age == age)
                    numeric++;
            Console.WriteLine($"Студентов в возрасте {age}: {numeric}");
            }
        public static void DelegFindCourse(List<Student> students, string find, int course)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.course == course)
                    numeric++;
            Console.WriteLine($"Студентов на курсе {course} учится: {numeric}");
            }
        public static void DelegFindGroupe(List<Student> students, string find, int groupe)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.group == groupe)
                    numeric++;
            Console.WriteLine($"Студентов в {groupe} группе учится: {numeric}");
            }
        public static void DelegFindUniversity(List<Student> students, string univers, int find)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.university == univers)
                    numeric++;
            Console.WriteLine($"Студентов в {univers} учится: {numeric}");
            }
        public static void DelegFindFacult(List<Student> students, string facul, int find)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.faculty == facul)
                    numeric++;
            Console.WriteLine($"Студентов в {facul} учится: {numeric}");
            }
        public static void DelegFindDepartam(List<Student> students, string departam, int find)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.department == departam)
                    numeric++;
            Console.WriteLine($"Студентов в {departam} учится: {numeric}");
            }
        public static void DelegFindCity(List<Student> students, string city, int find)
            {
            int numeric = 0;
            foreach(var item in students)
                if(item.city == city)
                    numeric++;
            Console.WriteLine($"Студентов в {city} учится: {numeric}");
            }
        #endregion

        #region Сортировки
        static List<Student> Sorting(List<Student> students, Sorting sort)
            {
            return sort(students);
            }

        static List<Student> DelegFirstName(List<Student> students)
            {
            return students.OrderBy(x => x.firstName).ToList();
            }
        static List<Student> DelegLastName(List<Student> students)
            {
            return students.OrderBy(x => x.lastName).ToList();
            }
        static List<Student> DelegCity(List<Student> students)
            {
            return students.OrderBy(x => x.city).ToList();
            }
        static List<Student> DelegCourse(List<Student> students)
            {
            return students.OrderBy(x => x.course).ToList();
            }
        static List<Student> DelegateAgeCourse(List<Student> students)
            {
            return students.OrderBy(x => x.age).ThenBy(x => x.course).ToList();
            }
        #endregion
        }

    }
