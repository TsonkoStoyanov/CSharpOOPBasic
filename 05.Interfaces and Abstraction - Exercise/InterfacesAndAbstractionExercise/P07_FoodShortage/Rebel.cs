using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodShortage
{
    public class Rebel : IBuyer

    {
        private string name;
        private int age;
        private string group;
        private int food = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Group { get => group; set => group = value; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food +=5;
        }
    }
}
