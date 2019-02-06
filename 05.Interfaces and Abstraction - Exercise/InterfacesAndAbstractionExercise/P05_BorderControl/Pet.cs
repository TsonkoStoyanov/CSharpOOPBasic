namespace P05_BorderControl
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get => name; set => name = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}