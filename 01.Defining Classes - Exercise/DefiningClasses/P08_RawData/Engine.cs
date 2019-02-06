namespace P08_RawData
{
    public class Engine
    {
        //<EngineSpeed> <EnginePower> 

        private int engineSpeed;

        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }

    }
}