namespace NeuralNet.Genetics
{
    public interface IGeneticsSettings
    {
        double CrossoverRate { get; }

        double MaxPerturbation { get; }

        double MutationRate { get; }

        int EliteCount { get; }
    }
}