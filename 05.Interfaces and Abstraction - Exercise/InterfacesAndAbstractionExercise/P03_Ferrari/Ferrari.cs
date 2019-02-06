namespace P03_Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
    
        public string Driver { get; }

        public  string UseBrakes()
        {
            return $"Brakes!";
        }

        public string PushGas()
        {
            return $"Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"488-Spider/{UseBrakes()}/{PushGas()}/{this.Driver}";
        }
    }
}