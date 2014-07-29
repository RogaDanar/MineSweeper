namespace NeuralNet.Genetics
{
    using NeuralNet.AppHelpers;
    using NeuralNet.Helpers;
    using System.Collections.Generic;
    using System.Linq;

    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private readonly Rand _rand = Rand.Generator;

        /// <summary>
        /// Chance of for each chromosome of a genome to mutate
        /// </summary>
        public double MutationRate { get; set; }

        /// <summary>
        /// Chance of 2 parent genomes crossing over part of their chromosomes
        /// </summary>
        public double CrossoverRate { get; set; }

        /// <summary>
        /// When mutating the maximum value a chromosome can change
        /// </summary>
        public double PerturbationRate { get; set; }

        /// <summary>
        /// Number of Genomes with highest fitness which are automatically taken into the next generation 
        /// </summary>
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
                    genome.Chromosome[i] += _rand.NextClamped() * PerturbationRate;
                }
            }
        }

        public void Crossover(Genome mother, Genome father, Genome son, Genome daughter)
        {
            if (_rand.NextDouble() <= CrossoverRate && !mother.Equals(father))
            {
                var crossoverPoint = _rand.Next(mother.Chromosome.Count());

                son.Chromosome = mother.Chromosome.Take(crossoverPoint).Concat(father.Chromosome.Skip(crossoverPoint)).ToList();
                daughter.Chromosome = father.Chromosome.Take(crossoverPoint).Concat(mother.Chromosome.Skip(crossoverPoint)).ToList();
            }
            else
            {
                son.Chromosome = father.Chromosome.ToList();
                daughter.Chromosome = mother.Chromosome.ToList();
            }
        }

        public Population NextGeneration(Population population)
        {
            population.SaveLastGenerationStats();
            population.Generation++;

            var newGenomes = new List<Genome>();

            if (EliteCount > 0)
            {
                var elites = population.Genomes.OrderByDescending(x => x.Fitness).Take(EliteCount);
                newGenomes.AddRange(elites);
            }

            while (newGenomes.Count < population.Genomes.Count())
            {
                var mother = population.GetGenomeByRoulette();
                var father = population.GetGenomeByRoulette();

                var son = new Genome();
                var daughter = new Genome();

                Crossover(mother, father, son, daughter);
                Mutate(son);
                Mutate(daughter);
                newGenomes.Add(son);
                newGenomes.Add(daughter);
            }
            newGenomes.ForEach(x => x.Fitness = 0);
            population.Genomes = newGenomes.Take(population.Genomes.Count()).ToList();
            return population;
        }
    }
}
