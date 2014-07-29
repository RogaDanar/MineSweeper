namespace NeuralNet.AppHelpers
{
    public interface IGeneticsSettings
    {
        double CrossoverRate { get; }

        double MaxPerturbation { get; }

        double MutationRate { get; }

        int EliteCount { get; }
    }
}
