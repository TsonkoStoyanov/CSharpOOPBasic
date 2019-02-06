using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P05_BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<IBirthable> creatures = new List<IBirthable>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                string type = inputArgs[0];

                switch (type)
                {
                    case "Citizen":
                        IBirthable citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                        creatures.Add(citizen);
                        break;

                    case "Pet":
                        IBirthable pet = new Pet(inputArgs[1], inputArgs[2]);
                        creatures.Add(pet);
                        break;
                }

            }

            string year = Console.ReadLine();

            foreach (var creature in creatures.Where(x=>x.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(creature.Birthdate);
            }


        }
    }
}
