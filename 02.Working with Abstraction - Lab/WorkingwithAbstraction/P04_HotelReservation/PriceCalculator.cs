using System;

namespace P04_HotelReservation
{
    public class PriceCalculator
    {
        internal static decimal Calculate(decimal pricePerNigth, int nigth, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal priceBeforeDiscount = nigth * pricePerNigth * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;

        }
    }
}