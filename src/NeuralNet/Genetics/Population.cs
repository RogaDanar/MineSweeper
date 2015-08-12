namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    /// <summary>
    /// A population of Genomes
    /// </summary>
    public class Population
    {
        private readonly Rand _rand = Rand.Generator;

        private IGeneticAlgorithm _genetics;

        public int Generation { get; private set; }

        public IList<Genome> Genomes { get; private set; }

        public FitnessStats FitnessStats { get; private set; }

        public Population(IGeneticAlgorithm genetics)
        {
            _genetics = genetics;
            FitnessStats = new FitnessStats();
        }

        public void Populate(int populationSize, int chromosomeSize)
        {
            Genomes = Enumerable.Range(1, populationSize).Select(x => new Genome(chromosomeSize, 0)).ToList();
        }

        public void Populate(IEnumerable<Genome> genomes)
        {
            Genomes = genomes.ToList();
        }

        public void UpdateFitnessStats()
        {
            FitnessStats.Update(Genomes);
        }

        public void NextGeneration()
        {
            FitnessStats.SaveCurrentToHistory();
            Generation++;

            var newGenomes = new List<Genome>();

            if (_genetics.EliteCount > 0)
            {
                var elites = Genomes.OrderByDescending(x => x.Fitness).Take(_genetics.EliteCount);
                newGenomes.AddRange(elites);
            }

            while (newGenomes.Count < Genomes.Count())
            {
                var mother = getGenomeByRoulette();
                var father = getGenomeByRoulette();

                var children = _genetics.Crossover(mother, father);
                foreach (var child in children)
                {
                    _genetics.Mutate(child);
                    newGenomes.Add(child);
                }
            }
            newGenomes.ForEach(x => x.ResetFitness());
            Genomes = newGenomes.Take(Genomes.Count()).ToList();
        }

        private Genome getGenomeByRoulette()
        {
            var chosen = default(Genome);

            var slice = _rand.NextDouble() * FitnessStats.Total;
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
            chosen = chosen ?? Genomes.OrderBy(x => _rand.Next()).First();
            return chosen;
        }
    }
}