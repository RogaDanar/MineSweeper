namespace Brainspace.Models
{
    using Brainspace.Helpers;
    using Brainspace.Models.Genetics;
    using Brainspace.Models.Neural;
    using System;
    using System.Collections.Generic;

    public class Brain
    {
        private const int inputs = 56;
        private const int outputNeurons = 3;
        private const int hiddenLayers = 10;
        private const int neuronsPerHiddenLayer = 50;
        private const double mutationRate = 0.1;
        private const double crossoverRate = 0.7;
        private const double perturbationRate = 0.3;

        private readonly Rand _rand = Rand.Generator;

        private GeneticAlgorithm _geneticAlgorithm { get; set; }

        private Genome _genome { get; set; }

        public FeedforwardNetwork Network { get; private set; }

        public double Fitness { get { return _genome.Fitness; } }

        public Brain()
            : this(new FeedforwardNetwork(inputs, outputNeurons, hiddenLayers, neuronsPerHiddenLayer))
        { }

        public Brain(FeedforwardNetwork network)
        {
            Network = network;
            _genome = new Genome(network.GetAllWeights(), 0);
            _geneticAlgorithm = new GeneticAlgorithm(mutationRate, crossoverRate, perturbationRate);
        }

        public IList<double> Show(InputGoal input)
        {
            _genome.Fitness = 0;
            var result = Network.Observe(input.Input);
            setFitness(result, input.Goal);
            return result;
        }

        public IEnumerable<IList<double>> Show(List<InputGoal> inputs)
        {
            _genome.Fitness = 0;
            foreach (var input in inputs)
            {
                var result = Network.Observe(input.Input);
                setFitness(result, input.Goal);
                yield return result;
            }
        }

        public void Tick()
        {
            _geneticAlgorithm.Mutate(_genome);
            Network.SetAllWeights(_genome.Chromosome);
        }

        private void setFitness(IList<double> result, IList<double> goal)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (goal[i] == Math.Round(result[i], 1))
                {
                    _genome.Fitness++;
                }
            }
        }
    }
}
