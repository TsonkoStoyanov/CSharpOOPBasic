using System;
using System.Text;

namespace P06_Animals
{
    public abstract class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string sex;

        public Animal(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => age;

            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) ||
                    value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Sex
        {
            get => sex;
            
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.sex = value;
            }
        }

        public virtual string ProduceSound()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder()
                .AppendLine(this.GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Sex}")
                .AppendLine(this.ProduceSound());

            return sb.ToString();
        }
    }
}