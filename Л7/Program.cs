using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Serialization;
using Л7;

namespace Л7
{
    internal class Program
    {
        private static Conference conference = new Conference();
        private static Schoolchild schoolchild = new Schoolchild();
        private static  Student student = new Student();

        static void Main(string[] args)
        {
            string read;
            while (true)
            {
                Console.Write("\nВвести школьника: sсh, ввести студента: std, вывести количество учащихся: num, прекратить ввод: stop ");
                read = Console.ReadLine().Trim();
                if (read == "sch")
                {
                    schoolchild.WriteSchoolchild(schoolchild);
                    Console.WriteLine($"\n{schoolchild.ToString(schoolchild)}");
                    conference.AddLearner(schoolchild);

                }
                else if (read == "std")
                {

                    student.WriteStudent(student);
                    Console.WriteLine($"\n{student.ToString(student)}");
                    conference.AddLearner(student);
                }
                else if (read == "num")
                {
                    conference.Schet();

                } else if(read == "stop")
                {
                    break;

                }
                else { Console.WriteLine("Введите что-то из предложенного"); }

               

            }
        }

    }


        class Learner { 
        
           protected string Family { get;set; }
            protected string Name { get;set; }
            protected int Age { get;set; }
        private void AgeL(Learner learner) => learner.Age = Convert.ToInt32(Console.ReadLine().Trim());
        protected void WriteLearner(Learner learner) {
            Console.Write($"Фамилия: ");
            learner.Family = Console.ReadLine().Trim();
            Console.Write($"Имя: ");
            learner.Name = Console.ReadLine().Trim();
            Console.Write($"Возраст: ");
            try { AgeL(learner); }
            catch 
            {
                Console.Write("Введите возраcт корректно ");
                
            }
           
            
                
                       
        }

        public string ToString()
            {
                string str = $"Фамилия: {Family}, имя: {Name}, возраст: {Age}";

                return str;
            }
        
        
        }


        class Schoolchild : Learner { 
        
           private string School { get; set; }
            private string SchoolClass { get; set; }
            private int NumControlWork { get; set; }

            internal void WriteSchoolchild(Schoolchild schoolchild) {

                WriteLearner(schoolchild);
                Console.Write($"Школа: ");
                schoolchild.School = Console.ReadLine();
                Console.Write($"Класс: ");
                schoolchild.SchoolClass = Console.ReadLine().Trim();
                Console.Write($"Количество контрольных в полугодии: ");
                schoolchild.NumControlWork = Console.Read();
            }

            public string ToString(Schoolchild schoolchild)
            {
                string str = $"Фамилия: {schoolchild.Family}, имя: {schoolchild.Name}, возраст: {schoolchild.Age}, школа: {schoolchild.School}, класс: {schoolchild.SchoolClass}, количество контрольных в полугодии: {schoolchild.NumControlWork}";

                return str;
            }


        }

        class Student : Learner
        {
            private string University { get; set; }
            private string UniversityGroup { get; set; }
            private int NumExame { get; set; }

        internal void WriteStudent(Student student)
        {
            WriteLearner(student);
            student.Age = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write($"Университет: ");
            student.University = Console.ReadLine().Trim();
            Console.Write($"Группа: ");
            student.UniversityGroup = Console.ReadLine().Trim();
            Console.Write($"Количество экзаменов в семестре: ");
            student.NumExame = Console.Read();
        }


        public string ToString(Student student)
            {
                string std = $"Фамилия: {student.Family}, имя: {student.Name}, возраст: {student.Age}, университет: {student.University}, группа: {student.UniversityGroup}, количество экзаменов: {student.NumExame}";
                return std;
            }

        }

        class Conference
        {
           
         private  List <Schoolchild> schoolchilds = new List<Schoolchild>();
         private  List<Student> students = new List<Student>();

           internal void AddLearner(Schoolchild schoolchild) =>  schoolchilds.Add(schoolchild);
        
           internal void AddLearner(Student student) =>  students.Add(student);

         
           internal void Schet() => Console.WriteLine($"Количество школьников: {schoolchilds.Count()}\nКоличество студентов: {students.Count()}");
           

            
        }
    

}