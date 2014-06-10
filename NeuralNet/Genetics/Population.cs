namespace NeuralNet.Genetics
{
    using NeuralNet.Helpers;
    using System.Collections.Generic;
    using System.Linq;

    public class Population
    {
        private readonly Rand _rand = Rand.Generator;

        public int Generation { get; set; }

        public IList<Genome> Genomes { get; set; }

        public double Fitness { get { return Genomes.Sum(x => x.Fitness); } }

        public double BestFitness { get { return Genomes.Max(x => x.Fitness); } }

        public double WorstFitness { get { return Genomes.Min(x => x.Fitness); } }

        public double AverageFitness { get { return Genomes.Average(x => x.Fitness); } }

        public Genome Fittest { get { return Genomes.OrderByDescending(x => x.Fitness).FirstOrDefault(); } }

        public Population()
        {
        }

        public Population(int populationSize, int chromosomeSize)
        {
            Genomes = Enumerable.Range(1, populationSize).Select(x => new Genome(chromosomeSize, 0)).ToList();
        }

        public Genome GetGenomeByRoulette()
        {
            var chosen = default(Genome);

            var slice = _rand.NextDouble() * Fitness;
            var cumulativeFitness = 0.0;
            foreach (var genome in Genomes)
            {
                cumulativeFitness += genome.Fitness;
                if (cumulativeFitness >= slice)
                {
                    chosen = genome;
                    break;
                }
            }

            return chosen;
        }
    }
}
