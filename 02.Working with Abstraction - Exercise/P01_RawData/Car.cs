using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {

        public Car(string model, )
        {
            this.Model = model;
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
          
        }
        private string model;
        public int engineSpeed;
        public int enginePower;
        public int cargoWeight;
        public string cargoType;
        public KeyValuePair<double, int>[] tires;

        public string Model { get => model; set => model = value; }
    }
}
