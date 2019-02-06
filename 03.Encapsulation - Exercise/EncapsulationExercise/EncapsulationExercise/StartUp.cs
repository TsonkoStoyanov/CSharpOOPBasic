using System;
using System.Linq.Expressions;

namespace EncapsulationExercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());

            double width = double.Parse(Console.ReadLine());

            double height = double.Parse(Console.ReadLine());
            try
            {

                Box box = new Box(length, width, height);

                double resultSurface = box.GetSurface();
                double resultLatSurface = box.GetLatSurface();
                double resultVolume = box.GetVolume();
                Console.WriteLine($"Surface Area - {resultSurface:f2}");
                Console.WriteLine($"Lateral Surface Area - {resultLatSurface:f2}");
                Console.WriteLine($"Volume - {resultVolume:f2}");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
