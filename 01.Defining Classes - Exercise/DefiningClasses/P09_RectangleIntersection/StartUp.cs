using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace P09_RectangleIntersection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Rectangle> rectangles = new List<Rectangle>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers[0]; i++)
            {
                string[] input = Console.ReadLine().Split();

                string id = input[0];
                double heigth = double.Parse(input[1]);
                double weigth = double.Parse(input[2]);


                double coordinatesTopLeftX = double.Parse(input[3]);
                double coordinatesTopLeftY = double.Parse(input[4]);

                Rectangle rectangle = new Rectangle(id, heigth, weigth, coordinatesTopLeftX, coordinatesTopLeftY);

                rectangles.Add(rectangle);

            }

            for (int i = 0; i < numbers[1]; i++)
            {
                string[] input = Console.ReadLine().Split();

                Rectangle firstFectangle = rectangles.FirstOrDefault(x => x.Id == input[0]);

                Rectangle secondFectangle = rectangles.FirstOrDefault(x => x.Id == input[1]);

                if (firstFectangle.Intersection(secondFectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

            }


        }
    }
}
