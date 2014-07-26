namespace NeuralNet.AppHelpers
{
    public class GeneticsSettings : IGeneticsSettings
    {
        public double CrossoverRate { get; set; }
        public double MaxPerturbation { get; set; }
        public double MutationRate { get; set; }
        public int EliteCount { get; set; }

        public GeneticsSettings()
        {
            CrossoverRate = 0.7;
            MaxPerturbation = 0.3;
            MutationRate = 0.1;
            EliteCount = 4;
        }
    }
}
