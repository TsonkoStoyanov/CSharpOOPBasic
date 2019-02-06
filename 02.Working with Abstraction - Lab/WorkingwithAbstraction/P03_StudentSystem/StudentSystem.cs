using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private List<Student> students;

        public StudentSystem()
        {
            this.Students = new List<Student>();
        }

        public List<Student> Students
        {
            get { return students; }
            private set { students = value; }
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                Student student = students.FirstOrDefault(x => x.Name == name);

                if (student == null)
                {
                    student = new Student(name, age, grade);
                }

                students.Add(student);
            }
            else if (args[0] == "Show")
            {
                var name = args[1];


                Student student = students.FirstOrDefault(x => x.Name == name);

                if (student != null)
                {
                    string view = $"{student.Name} is {student.Age} years old.";

                    if (student.Grade >= 5.00)
                    {
                        view += " Excellent student.";
                    }
                    else if (student.Grade < 5.00 && student.Grade >= 3.50)
                    {
                        view += " Average student.";
                    }
                    else
                    {
                        view += " Very nice person.";
                    }

                    Console.WriteLine(view);
                }

            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}