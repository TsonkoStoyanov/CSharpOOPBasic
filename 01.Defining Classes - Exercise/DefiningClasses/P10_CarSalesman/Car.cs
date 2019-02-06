using System.Text;

namespace P10_CarSalesman
{
    public class Car
    {
        //model, engine, weight and color.

        private string model;

        private Engine engine;

        private string weight;

        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.AppendLine($"  {engine.Model}:");
            sb.AppendLine(this.Engine.ToString());
            sb.AppendLine($"  Weight: {this.Weight}");
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}