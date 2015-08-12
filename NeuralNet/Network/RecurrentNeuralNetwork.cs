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
    /// S = state neuron
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
    ///           ↑
    ///          _↓_
    ///         |   |
    ///         | S |
    ///         |   |
    ///         | S |
    ///         |___|
    /// 
    /// Strength of the links between all neurons are determined by weights (doubles).
    /// The weights are stored in a Genome, which has a list of chromosomes. The weights are
    /// the chromosomes, and a fitness is given to the whole set (Genome) of them
    /// </summary>
    public class RecurrentNeuralNetwork : INeuralNet
    {
        private IList<NeuronLayer> _hiddenLayers { get; set; }
        private IList<NeuronLayer> _stateLayers { get; set; }
        private NeuronLayer _outputLayer { get; set; }
        private Genome _genome;

        /// <summary>
        /// A list of all the weights (chromosomes) in the network.
        /// </summary>
        private IEnumerable<double> AllWeights
        {
            get
            {
                var allWeights = new List<double>();
                foreach (var layer in _hiddenLayers)
                {
                    allWeights.AddRange(layer.AllWeights);
                }
                allWeights.AddRange(_outputLayer.AllWeights);
                return allWeights;
            }
        }

        public int InputNeuronCount { get; private set; }

        public int OutputNeuronCount { get; private set; }

        /// <summary>
        /// All chromosomes with fitness.
        /// </summary>
        public Genome Genome
        {
            get
            {
                if (_genome == null)
                {
                    _genome = new Genome(AllWeights, 0.0);
                }
                return _genome;
            }
            set
            {
                _genome = value;
                var allweights = _genome.Chromosome;
                foreach (var layer in _hiddenLayers)
                {
                    var weightCount = layer.AllWeights.Count();
                    layer.AllWeights = allweights.Take(weightCount).ToList();
                    allweights = allweights.Skip(weightCount).ToList();
                }
                _outputLayer.AllWeights = allweights;
            }
        }

        /// <summary>
        /// Create a Feedforward Network with the given number of layers and neurons
        /// </summary>
        /// <param name="inputs">Number of input neurons</param>
        /// <param name="outputNeurons">Number of output neurons</param>
        /// <param name="hiddenLayers">Number of hidden neuron layers</param>
        /// <param name="neuronsPerHiddenLayer">Number of neurons per hidden layer</param>
        public RecurrentNeuralNetwork(int inputs, int outputNeurons, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            InputNeuronCount = inputs;
            OutputNeuronCount = outputNeurons;
            var lastOutputCount = setHiddenLayers(inputs, hiddenLayers, neuronsPerHiddenLayer);
            _outputLayer = new NeuronLayer(outputNeurons, lastOutputCount);
        }

        public int AllWeightsCount()
        {
            var count = _hiddenLayers.Sum(x => x.AllWeights.Count());
            count += _outputLayer.AllWeights.Count();
            return count;
        }

        public IList<double> Observe(IList<double> inputs)
        {
            if (inputs.Count() > InputNeuronCount)
            {
                return null;
            }
            // in case there is no hidden layer (unlikely..) set the result to the inputs
            var result = inputs;

            for (int layerIndex = 0; layerIndex < _hiddenLayers.Count(); layerIndex++)
            {
                var hiddenLayer = _hiddenLayers[layerIndex];
                var stateLayer = _stateLayers[layerIndex];

                var nextInput = result.Concat(stateLayer.GetOutputSignals()).ToList();
                result = hiddenLayer.SendSignalsAndGetOuputSignal(nextInput).ToList();

                // Store the outputs of the hidden layer in its state layer for use in the next iteration
                for (int neuronIndex = 0; neuronIndex < result.Count(); neuronIndex++)
                {
                    var stateNeuron = stateLayer.Neurons[neuronIndex];
                    stateNeuron.SendSignals(result[neuronIndex]);
                }
            }

            return _outputLayer.SendSignalsAndGetOuputSignal(result).ToList();
        }

        private int setHiddenLayers(int inputs, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            _hiddenLayers = new List<NeuronLayer>();
            _stateLayers = new List<NeuronLayer>();
            var lastOutputCount = inputs;
            for (int layerIndex = 0; layerIndex < hiddenLayers; layerIndex++)
            {
                var stateLayer = new NeuronLayer(neuronsPerHiddenLayer, inputsPerNeuron: 1, randomInputWeights: false);
                _stateLayers.Add(stateLayer);

                var inputForHiddenLayer = lastOutputCount + neuronsPerHiddenLayer;
                var hiddenLayer = new NeuronLayer(neuronsPerHiddenLayer, inputForHiddenLayer);
                _hiddenLayers.Add(hiddenLayer);

                lastOutputCount = neuronsPerHiddenLayer;
            }
            return lastOutputCount;
        }
    }
}
