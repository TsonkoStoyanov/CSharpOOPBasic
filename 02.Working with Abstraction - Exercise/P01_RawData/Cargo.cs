namespace P01_RawData
{
    public class Cargo
    {
        private int cargoWeigth;

        public Cargo(int cargoWeigth, string cargoType)
        {
            CargoWeigth = cargoWeigth;
            CargoType = cargoType;
        }

        public string CargoType { get; set; }

        public int CargoWeigth
        {
            get { return cargoWeigth; }
            set { cargoWeigth = value; }
        }
    }
}