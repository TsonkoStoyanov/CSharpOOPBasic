namespace Minedraft.Models.Harvesters
{
    public class SonicHarvester:Harvester
    {
        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
            : base(id, oreOutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            this.EnergyRequirement /= SonicFactor;
        }

        public int SonicFactor { get;}

    }
}