namespace NeuralNet.Network
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Genetics;

    /// <summary>
    /// Schematic view of the layers and the Neurons:
    /// I = input neuron
    /// O = output neuron
    /// h = hidden neuron
    /// - / \ X = links (weights)
    ///
    ///  ___     ___     ___
    /// |   |   |   |   |   |
    /// | I |---| h |   |   |
    /// |   |\ /|   |\  |   |
    /// |   | X |   | \ |   |
    /// |   |/ \|   |  \|   |
    /// | I |---| h |---| O |
    /// |   |\ /|   |\ /|   |
    /// |   | X |   | X |   |
    /// |   |/ \|   |/ \|   |
    /// | I |---| h |---| O |
    /// |___|   |___|   |___|
    ///
    ///
    /// Strength of the links between all neurons are determined by weights (doubles).
    /// The weights are stored in a Genome, which has a list of chromosomes. The weights are
    /// the chromosomes, and a fitness is given to the whole set (Genome) of them
    /// </summary>
    public class FeedforwardNetwork : INeuralNet
    {
        private IList<NeuronLayer> _hiddenLayers { get; set; }

        private NeuronLayer _outputLayer { get; set; }

        /// <summary>
        /// The number of neurons in the input layer
        /// </summary>
        public int InputNeuronCount { get; private set; }

        /// <summary>
        /// The number of neurons in the output layer
        /// </summary>
        public int OutputNeuronCount { get; private set; }

        /// <summary>
        /// All chromosomes with fitness.
        /// </summary>
        public Genome Genome { get; private set; }

        /// <summary>
        /// Create a Feedforward Network with the given number of layers and neurons, a random genome will be created
        /// </summary>
        /// <param name="inputs">Number of input neurons</param>
        /// <param name="outputNeurons">Number of output neurons</param>
        /// <param name="hiddenLayers">Number of hidden neuron layers</param>
        /// <param name="neuronsPerHiddenLayer">Number of neurons per hidden layer</param>
        public FeedforwardNetwork(int inputs, int outputNeurons, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            InputNeuronCount = inputs;
            OutputNeuronCount = outputNeurons;
            var lastOutputCount = setHiddenLayers(inputs, hiddenLayers, neuronsPerHiddenLayer);
            _outputLayer = new NeuronLayer(outputNeurons, lastOutputCount);

            var allWeights = new List<double>();
            foreach (var layer in _hiddenLayers)
            {
                allWeights.AddRange(layer.AllWeights);
            }
            allWeights.AddRange(_outputLayer.AllWeights);

            Genome = new Genome(allWeights, 0.0);
        }

        /// <summary>
        /// Create a Feedforward Network with the given number of layers and neurons filled with the given weights from the genome
        /// </summary>
        /// <param name="inputs">Number of input neurons</param>
        /// <param name="outputNeurons">Number of output neurons</param>
        /// <param name="hiddenLayers">Number of hidden neuron layers</param>
        /// <param name="neuronsPerHiddenLayer">Number of neurons per hidden layer</param>
        public FeedforwardNetwork(int inputs, int outputNeurons, int hiddenLayers, int neuronsPerHiddenLayer, Genome genome)
        {
            InputNeuronCount = inputs;
            OutputNeuronCount = outputNeurons;
            Genome = genome;

            var allweights = genome.Chromosome;

            var lastOutputCount = setHiddenLayers(inputs, hiddenLayers, neuronsPerHiddenLayer, allweights);
            var usedWeightCount = _hiddenLayers.Sum(x => x.AllWeights.Count());

            _outputLayer = new NeuronLayer(outputNeurons, lastOutputCount, allweights.Skip(usedWeightCount));
        }

        public void UpdateGenome(Genome genome)
        {
            Genome = genome;

            var allweights = Genome.Chromosome;
            foreach (var layer in _hiddenLayers)
            {
                var weightCount = layer.AllWeights.Count();
                layer.AllWeights = allweights.Take(weightCount).ToList();
                allweights = allweights.Skip(weightCount).ToList();
            }
            _outputLayer.AllWeights = allweights;
        }

        /// <summary>
        /// Feeds inputs to the network and returns the resultant output values.
        /// </summary>
        /// <param name="inputs">List of input values, this is essentially the input layer</param>
        /// <returns>List of resultant signals from the output neurons</returns>
        public IList<double> Observe(IList<double> inputs)
        {
            if (inputs.Count() > InputNeuronCount)
            {
                return null;
            }
            // in case there is no hidden layer (unlikely..) set the result to the inputs
            var result = inputs;
            foreach (var layer in _hiddenLayers)
            {
                result = layer.SendSignalsAndGetOuputSignal(result).ToList();
            }

            return _outputLayer.SendSignalsAndGetOuputSignal(result).ToList();
        }

        /// <summary>
        /// A count of all the weights (chromosomes) used by the network
        /// </summary>
        /// <returns>Total number of weights of the hidden layers and the output layer</returns>
        public int AllWeightsCount()
        {
            var count = _hiddenLayers.Sum(x => x.AllWeights.Count());
            count += _outputLayer.AllWeights.Count();
            return count;
        }

        private int setHiddenLayers(int inputs, int hiddenLayers, int neuronsPerHiddenLayer, IEnumerable<double> allWeights)
        {
            _hiddenLayers = new List<NeuronLayer>();
            var lastOutputCount = inputs;
            var skip = 0;

            for (int layerIndex = 0; layerIndex < hiddenLayers; layerIndex++)
            {
                var numberOfWeights = neuronsPerHiddenLayer * (lastOutputCount + 1);
                _hiddenLayers.Add(new NeuronLayer(neuronsPerHiddenLayer, lastOutputCount, allWeights.Skip(skip).Take(numberOfWeights)));
                lastOutputCount = neuronsPerHiddenLayer;
                skip += numberOfWeights;
            }
            return lastOutputCount;
        }

        private int setHiddenLayers(int inputs, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            _hiddenLayers = new List<NeuronLayer>();
            var lastOutputCount = inputs;
            for (int layerIndex = 0; layerIndex < hiddenLayers; layerIndex++)
            {
                _hiddenLayers.Add(new NeuronLayer(neuronsPerHiddenLayer, lastOutputCount));
                lastOutputCount = neuronsPerHiddenLayer;
            }
            return lastOutputCount;
        }
    }
}