using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace P05_DateModifier
{
    public class DateModifier
    {
        public static int CalculateDateDifference(string firstDate, string secondDate)
        {
            var difference = DateTime.Parse(firstDate) - DateTime.Parse(secondDate);
            return Math.Abs(difference.Days);
        }
    }
}