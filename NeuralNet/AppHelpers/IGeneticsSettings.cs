namespace NeuralNet.AppHelpers
{
    public interface IGeneticsSettings
    {
        double CrossoverRate { get; }
        int EliteCount { get; }
        double MaxPerturbation { get; }
        double MutationRate { get; }
    }
}
