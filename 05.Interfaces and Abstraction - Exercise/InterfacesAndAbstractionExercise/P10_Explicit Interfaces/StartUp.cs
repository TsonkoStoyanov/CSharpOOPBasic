using System;

namespace P10_Explicit_Interfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();
                IPerson person = new Citizen(inputArgs[0]);

                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(inputArgs[0]);

                Console.WriteLine(resident.GetName());

            }
        }
    }
}
