namespace MineSweeper.Creatures
{
    using NeuralNet.Network;

    public interface ICreature
    {
        INeuralNet Brain { get; }

        double Fitness { get; set; }

        Motion Motion { get; }
    }
}
