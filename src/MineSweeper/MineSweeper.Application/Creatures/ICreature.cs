namespace MineSweeper.Application.Creatures
{
    using NeuralNet.Network;

    public interface ICreature
    {
        INeuralNet Brain { get; }
        double Fitness { get; }
        Motion Motion { get; }

        void IncreaseFitness(int fitnessIncrease);

        void DecreaseFitness(int fitnessDecrease);
    }
}