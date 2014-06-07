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
        private const double mutationRate = 0.2;
        private const double crossoverRate = 0.7;
        private const double perturbationRate = 0.1;

        private readonly Rand _rand = Rand.Generator;

        private IList<double> _goal;

        private GeneticAlgorithm _geneticAlgorithm { get; set; }

        private Genome _genome { get; set; }

        public FeedforwardNetwork Network { get; private set; }

        public bool Mature { get; set; }

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

        public void Setup(IList<double> goal)
        {
            _goal = goal;
        }

        public IList<double> Show(IList<double> inputs)
        {
            var result = Network.Observe(inputs);

            setFitness(result);
            if (!Mature)
            {
                _geneticAlgorithm.Mutate(_genome);
                Network.SetAllWeights(_genome.Chromosome);
            }
            return result;
        }

        private void setFitness(IList<double> result)
        {
            _genome.Fitness = 0;
            for (int i = 0; i < result.Count; i++)
            {
                if (_goal[i] == Math.Round(result[i], 1))
                {
                    _genome.Fitness++;
                }
            }

            Mature = _genome.Fitness == _goal.Count;
        }
    }
}
