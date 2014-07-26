namespace NeuralNet.AppHelpers
{
    public class Settings : INetSettings, IGeneticsSettings
    {
        // Genetics
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public double MaxPerturbation { get; set; }
        public int EliteCount { get; set; }

        // Net
        public int HiddenLayers { get; set; }
        public int HiddenLayerNeurons { get; set; }

        // Misc
        public int Ticks { get; set; }
    }
}
