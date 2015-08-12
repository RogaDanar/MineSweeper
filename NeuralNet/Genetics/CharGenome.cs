namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class CharGenome : IGenome<char>
    {
        private readonly Rand _rand = Rand.Generator;

        private const double _defaultFitness = 0;

        private char[] _nucleotideTypes = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public IList<char> Chromosome { get; set; }

        public double Fitness { get; set; }

        public CharGenome()
        {
        }

        public CharGenome(double fitness)
        {
            Fitness = fitness;
        }

        public CharGenome(int chromosomeSize, double fitness)
            : this(fitness)
        {
            Chromosome = Enumerable.Range(0, chromosomeSize).Select(x => _nucleotideTypes[_rand.Next(_nucleotideTypes.Length)]).ToArray();
        }

        public CharGenome(IEnumerable<char> chromosome, double fitness)
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
    }
}