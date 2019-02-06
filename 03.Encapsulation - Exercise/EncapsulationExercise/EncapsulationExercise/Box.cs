using System;

namespace EncapsulationExercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height { 
            get => height; 

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                height = value;
            }}

        public double Width
        {
            get => width;
            
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Length
        {
            get => length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        public double GetSurface()
        {
            return 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        }

        internal double GetLatSurface()
        {
            return 2 * (length * height) + 2 * (width * height);
        }

        internal double GetVolume()
        {
            return length * width * height;
        }
    }
}