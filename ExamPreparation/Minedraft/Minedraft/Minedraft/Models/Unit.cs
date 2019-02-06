namespace Minedraft.Models
{
    public abstract class Unit
    {
        protected Unit(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}