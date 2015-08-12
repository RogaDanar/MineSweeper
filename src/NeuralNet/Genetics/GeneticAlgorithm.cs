namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private readonly Rand _rand = Rand.Generator;

        public double MutationRate { get; set; }

        public double CrossoverRate { get; set; }

        public double PerturbationRate { get; set; }

        public int EliteCount { get; set; }

        public GeneticAlgorithm(IGeneticsSettings settings)
        {
            MutationRate = settings.MutationRate;
            CrossoverRate = settings.CrossoverRate;
            PerturbationRate = settings.MaxPerturbation;
            EliteCount = settings.EliteCount;
        }

        public void Mutate(Genome genome)
        {
            for (int i = 0; i < genome.Chromosome.Count(); i++)
            {
                if (_rand.NextDouble() <= MutationRate)
                {
                    genome.MutateGeneAt(i, _rand.NextClamped() * PerturbationRate);
                }
            }
        }

        public IEnumerable<Genome> Crossover(Genome mother, Genome father)
        {
            if (_rand.NextDouble() <= CrossoverRate && !mother.Equals(father))
            {
                var crossoverPoint = _rand.Next(mother.Chromosome.Count());

                yield return new Genome(mother.Chromosome.Take(crossoverPoint).Concat(father.Chromosome.Skip(crossoverPoint)));
                yield return new Genome(father.Chromosome.Take(crossoverPoint).Concat(mother.Chromosome.Skip(crossoverPoint)));
            }
            else
            {
                yield return new Genome(father.Chromosome);
                yield return new Genome(mother.Chromosome);
            }
        }
    }
}