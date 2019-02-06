using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodShortage
{
    public class Citizen : IBuyer
    {

        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
