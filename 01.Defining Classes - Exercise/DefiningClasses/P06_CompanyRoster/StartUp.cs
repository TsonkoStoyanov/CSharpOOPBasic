using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_CompanyRoster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numbers; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = "n/a";
                int age = -1;


                if (input.Length == 5)
                {
                    if (!int.TryParse(input[4], out age))
                    {
                        email = input[4];
                        age = -1;
                    }

                }

                else if (input.Length == 6)
                {
                    email = input[4];
                    age = int.Parse(input[5]);
                }

                Employee employee = new Employee(name, salary, position, department, email, age);

                employees.Add(employee);

            }

            var dep = employees.GroupBy(x => x.Department)
                .OrderByDescending(x => x.Average(s => s.Salary)).FirstOrDefault();               

            Console.WriteLine($"Highest Average Salary: {dep.Key}");

            foreach (var d in dep.OrderByDescending(s=>s.Salary))
            {
                Console.WriteLine(d);
            }

        }
    }
}
