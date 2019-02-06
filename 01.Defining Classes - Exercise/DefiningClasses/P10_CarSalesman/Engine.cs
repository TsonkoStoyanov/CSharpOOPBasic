using System.Text;

namespace P10_CarSalesman
{
    public class Engine
    {
        //model, power, displacement and an efficiency

        private string model;

        private string power;

        private string displacement;

        public string Efficiency { get; set; }

        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }


        public string Power
        {
            get { return power; }
            set { power = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {this.Displacement}");
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}