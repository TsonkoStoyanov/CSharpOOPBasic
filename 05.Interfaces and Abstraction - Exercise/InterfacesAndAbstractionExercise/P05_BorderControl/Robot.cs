namespace P05_BorderControl
{
    internal class Robot:ICreature
    {
        private string id;
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
    }
}