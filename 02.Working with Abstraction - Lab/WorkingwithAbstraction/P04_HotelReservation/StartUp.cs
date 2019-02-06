using System;

namespace P04_HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //50.25 5 Summer VIP

            string[] input = Console.ReadLine().Split();

            decimal pricePerNigth = decimal.Parse(input[0]);

            int nigth = int.Parse(input[1]);

            Enum.TryParse(input[2], out Season season);

            Discount discount = Discount.None;

            if (input.Length > 3)
            {
                Enum.TryParse(input[3], out discount);
            }
            


            Console.WriteLine(PriceCalculator.Calculate(pricePerNigth, nigth, season, discount).ToString("F2"));
        }
    }
}
