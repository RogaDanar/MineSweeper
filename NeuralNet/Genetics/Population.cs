﻿namespace NeuralNet.Genetics
{
    using NeuralNet.Helpers;
    using System.Collections.Generic;
    using System.Linq;

    public class Population
    {
        private readonly Rand _rand = Rand.Generator;

        public int Generation { get; set; }

        public IList<Genome> Genomes { get; set; }

        public double Fitness { get; set; }
        public double BestFitness { get; set; }
        public double WorstFitness { get; set; }
        public double AverageFitness { get; set; }

        public List<double> PreviousGenerationFitness { get; set; }
        public List<double> PreviousGenerationBestFitness { get; set; }
        public List<double> PreviousGenerationWorstFitness { get; set; }
        public List<double> PreviousGenerationAverageFitness { get; set; }

        public Population()
        {
            PreviousGenerationFitness = new List<double>();
            PreviousGenerationBestFitness = new List<double>();
            PreviousGenerationWorstFitness = new List<double>();
            PreviousGenerationAverageFitness = new List<double>();
        }

        public Population(int populationSize, int chromosomeSize)
            : this()
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

        public void UpdateStats()
        {
            Fitness = Genomes.Sum(x => x.Fitness);
            BestFitness = Genomes.Max(x => x.Fitness);
            WorstFitness = Genomes.Min(x => x.Fitness);
            AverageFitness = Genomes.Average(x => x.Fitness);
        }

        public void SaveLastGenerationStats()
        {
            PreviousGenerationFitness.Add(Fitness);
            PreviousGenerationBestFitness.Add(BestFitness);
            PreviousGenerationWorstFitness.Add(WorstFitness);
            PreviousGenerationAverageFitness.Add(AverageFitness);

        }
    }
}