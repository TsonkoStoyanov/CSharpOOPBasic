using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string codeName;

        private State state;

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName
        {
            get { return codeName; }

            private set
            {
                codeName = value;
            }
        }

        public State State { get => state; private set => state = value; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.state}";
        }
    }
}