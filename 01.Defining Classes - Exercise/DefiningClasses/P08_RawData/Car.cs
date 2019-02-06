using System.Collections.Generic;

namespace P08_RawData
{
    public class Car
    {
        //Car that holds an information about model, engine, cargo and a collection of exactly 4 tires. 

        private string model;

        private Engine engine;

        private Cargo cargo;

        private List<Tire> tires = new List<Tire>();

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

    }
}