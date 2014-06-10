namespace NeuralNet.Network
{
    using NeuralNet.Genetics;
    using System.Collections.Generic;
    using System.Linq;

    public class FeedforwardNetwork : INeuralNet
    {
        public int MaxInputs { get; private set; }

        public int MinOutputs { get; private set; }

        public NeuronLayer OutputLayer { get; private set; }

        public IList<NeuronLayer> HiddenLayers { get; private set; }

        private Genome _genome;
        public Genome Genome
        {
            get
            {
                if (_genome == null)
                {
                    _genome = new Genome(GetAllWeights(), 0.0);
                }
                return _genome;
            }
            set
            {
                _genome = value;
                var allweights = _genome.Chromosome;
                foreach (var layer in HiddenLayers)
                {
                    var weightCount = layer.AllWeights.Count();
                    layer.AllWeights = allweights.Take(weightCount).ToList();
                    allweights = allweights.Skip(weightCount).ToList();
                }
                OutputLayer.AllWeights = allweights;
            }
        }

        public FeedforwardNetwork(int inputs, int outputNeurons, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            MaxInputs = inputs;
            MinOutputs = outputNeurons;

            HiddenLayers = new List<NeuronLayer>();
            var lastOutputCount = inputs;
            for (int layerIndex = 0; layerIndex < hiddenLayers; layerIndex++)
            {
                HiddenLayers.Add(new NeuronLayer(neuronsPerHiddenLayer, lastOutputCount));
                lastOutputCount = neuronsPerHiddenLayer;
            }

            OutputLayer = new NeuronLayer(outputNeurons, lastOutputCount);
        }

        public IList<double> Observe(IList<double> inputs)
        {
            if (inputs.Count > MaxInputs)
            {
                return null;
            }

            var result = inputs;
            foreach (var layer in HiddenLayers)
            {
                layer.Input(result);
                result = layer.Output();
            }

            OutputLayer.Input(result);
            return OutputLayer.Output();
        }

        public int AllWeightsCount()
        {
            var count = HiddenLayers.Sum(x => x.AllWeights.Count);
            count += OutputLayer.AllWeights.Count;
            return count;
        }

        public IList<double> GetAllWeights()
        {
            var allWeights = new List<double>();
            foreach (var layer in HiddenLayers)
            {
                allWeights.AddRange(layer.AllWeights);
            }
            allWeights.AddRange(OutputLayer.AllWeights);
            return allWeights;
        }
    }
}
