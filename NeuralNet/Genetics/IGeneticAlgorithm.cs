namespace NeuralNet.Genetics
{
    public interface IGeneticAlgorithm
    {
        void Crossover(Genome mother, Genome father, Genome son, Genome daughter);

        void Mutate(Genome genome);

        Population NextGeneration(Population population);
    }
}
