public class AggressiveDriver:Driver
    {
        private const double agresiveFuelConsumptionPerKm = 2.7;
        private const double agresiveSpeed = 1.3;

        public AggressiveDriver(string name, Car car) : base(name, car)
        {
            this.FuelConsumptionPerKm = agresiveFuelConsumptionPerKm;
        }

        protected override double Speed => base.Speed * agresiveSpeed;
    }
