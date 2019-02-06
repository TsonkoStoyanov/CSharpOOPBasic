namespace DefiningClasses
{
    public class Person
    {

        private int age;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }


        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}