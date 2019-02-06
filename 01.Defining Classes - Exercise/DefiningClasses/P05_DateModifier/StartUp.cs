using System;

namespace P05_DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
          
            string secondDate = Console.ReadLine();

           
            Console.WriteLine(DateModifier.CalculateDateDifference(firstDate, secondDate));
        }

    }
}
