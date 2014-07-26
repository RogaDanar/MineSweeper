namespace NeuralNet.AppHelpers
{
    using NeuralNet.Genetics;

    public interface IRunnerSpecification
    {
        IGeneticAlgorithm SetupGenetics();

        void SetupCreatures();

        void SetupPopulation();

        void NextTick();

        void NextGeneration(IGeneticAlgorithm genetics);

        int Ticks { get; }

        void AfterTick();
    }
}
