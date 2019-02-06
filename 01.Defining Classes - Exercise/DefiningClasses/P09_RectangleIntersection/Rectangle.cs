using System;

namespace P09_RectangleIntersection
{
    public class Rectangle
    {
        //an id, width, height
        //coordinates of its top left corner 

        private string id;

        private double width;

        private double heigth;

        private double coordinatesTopLeftX;

        private double coordinatesTopLeftY;

        public Rectangle(string id, double width, double heigth, double coordinatesTopLeftX, double coordinatesTopLeftY)
        {
            this.id = id;
            this.width = width;
            this.heigth = heigth;
            this.coordinatesTopLeftX = coordinatesTopLeftX;
            this.coordinatesTopLeftY = coordinatesTopLeftY;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        internal bool Intersection(Rectangle secondRectangle)
        {
            if (this.coordinatesTopLeftX + this.width < secondRectangle.coordinatesTopLeftX || secondRectangle.coordinatesTopLeftX + secondRectangle.width < this.coordinatesTopLeftX ||
                this.coordinatesTopLeftY + this.heigth < secondRectangle.coordinatesTopLeftY ||
                secondRectangle.coordinatesTopLeftY + secondRectangle.heigth < this.coordinatesTopLeftY
                )
            {
                return false;
            }

            return true;
        }
    }
}