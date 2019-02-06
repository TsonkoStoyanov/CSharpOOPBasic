using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var age = int.Parse(input[1]);

                Person person = new Person(age, name);

                Family.AddMember(person);
               
            }

            Person oldestMember = Family.GetOldestMember();

            Console.WriteLine(oldestMember);
        }
    }
}