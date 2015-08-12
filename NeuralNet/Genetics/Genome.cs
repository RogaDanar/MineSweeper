namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class Genome : IGenome<double>
    {
        private readonly Rand _rand = Rand.Generator;

        private const double _defaultFitness = 0;

        public IList<double> Chromosome { get; private set; }

        public double Fitness { get; private set; }

        public Genome()
        {
        }

        private Genome(double fitness)
        {
            Fitness = fitness;
        }

        public Genome(int chromosomeSize, double fitness = _defaultFitness)
            : this(fitness)
        {
            Chromosome = Enumerable.Range(0, chromosomeSize).Select(x => _rand.NextClamped()).ToArray();
        }

        public Genome(IEnumerable<double> chromosome, double fitness = _defaultFitness)
            : this(fitness)
        {
            Chromosome = chromosome.ToArray();
        }

        public void ResetFitness()
        {
            Fitness = _defaultFitness;
        }

        public void IncreaseFitness(int fitnessIncrease)
        {
            Fitness += fitnessIncrease;
        }

        public void DecreaseFitness(int fitnessDecrease)
        {
            Fitness -= fitnessDecrease;
        }

        public void MutateGeneAt(int index, double mutationRate)
        {
            Chromosome[index] += mutationRate;
        }
    }
}