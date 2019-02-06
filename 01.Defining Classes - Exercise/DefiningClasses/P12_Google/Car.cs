using System;

namespace P12_Google
{
    public class Car
    {
        public Car(string carModel, int carSpeed)
        {
            CarModel = carModel;
            CarSpeed = carSpeed;
        }

        public string CarModel { get; set; } = String.Empty;

        public int CarSpeed { get; set; } = 0;

        public override string ToString()
        {
            return $"{CarModel} {CarSpeed}";
        }
    }
}