using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_OpinionPoll
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int numbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

               
                    Person person = new Person(name, age);
                    people.Add(person);
                
               
            }


            foreach (var person in people.Where(x=>x.Age>30).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
