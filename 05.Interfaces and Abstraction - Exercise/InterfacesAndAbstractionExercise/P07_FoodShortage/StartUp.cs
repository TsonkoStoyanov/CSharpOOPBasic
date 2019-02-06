using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FoodShortage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            int numbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                if (inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    IBuyer rebel = new Rebel(name, int.Parse(inputInfo[1]), inputInfo[2]);
                    buyers.Add(name, rebel);

                }

                else
                {
                    string name = inputInfo[0];
                    IBuyer citizen = new Citizen(name, int.Parse(inputInfo[1]), inputInfo[2], inputInfo[3]);
                    buyers.Add(name, citizen);

                }
            }

            string inputName = String.Empty;

            while ((inputName = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(x => x.Key == inputName).Value;

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

            }

            int food = buyers.Sum(x => x.Value.Food);

            Console.WriteLine(food);
        }
    }
}
