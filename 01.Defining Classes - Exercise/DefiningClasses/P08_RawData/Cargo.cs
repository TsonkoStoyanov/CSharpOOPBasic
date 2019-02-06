namespace P08_RawData
{
    public class Cargo
    {
        private int cargoWeight;

        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            cargoWeight = cargoWeight;
            CargoType = cargoType;
        }

     
        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

    }
}