﻿namespace P02_PointInRectangle
{

    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get => x; set => x = value; }

        public int Y { get => y; set => y = value; }
    }
}
