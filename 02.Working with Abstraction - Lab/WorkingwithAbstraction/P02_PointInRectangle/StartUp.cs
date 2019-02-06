using System;
using System.Linq;


namespace P02_PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Point topPoint = new Point(input[0], input[1]);
            Point botomPoint  = new Point(input[2], input[3]);

            Rectangle rectangle = new Rectangle(topPoint, botomPoint);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Point point = new Point(input[0], input[1]);

                Console.WriteLine(rectangle.Contains(point));
            }

        }
    }
}
