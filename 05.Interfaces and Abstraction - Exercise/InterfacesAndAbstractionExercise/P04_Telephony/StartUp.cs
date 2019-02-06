using System;

namespace P04_Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //0882134215 0882134333 08992134215 0558123 3333 1
            // http://softuni.bg http://youtube.com http://www.g00gle.com


            string[] numbers = Console.ReadLine().Split();

            string[] sites = Console.ReadLine().Split();


            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(smartphone.Call(numbers[i]));
            }

            for (int i = 0; i < sites.Length; i++)
            {
                Console.WriteLine(smartphone.Browse(sites[i]));
            }
        }
    }
}
