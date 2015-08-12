namespace NeuralNet.Genetics
{
    using System.Collections.Generic;

    public interface IGeneticAlgorithm
    {
        /// <summary>
        /// Chance of for each chromosome of a genome to mutate
        /// </summary>
        double MutationRate { get; set; }

        /// <summary>
        /// Chance of 2 parent genomes crossing over part of their chromosomes
        /// </summary>
        double CrossoverRate { get; set; }

        /// <summary>
        /// When mutating the maximum value a chromosome can change
        /// </summary>
        double PerturbationRate { get; set; }

        /// <summary>
        /// Number of Genomes with highest fitness which are automatically taken into the next generation
        /// </summary>
        int EliteCount { get; set; }

        IEnumerable<Genome> Crossover(Genome mother, Genome father);

        void Mutate(Genome genome);
    }
}