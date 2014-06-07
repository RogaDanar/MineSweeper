namespace Brainspace.Models.Neural
{
    using System.Collections.Generic;
    using System.Linq;

    public class FeedforwardNetwork
    {
        public int MaxInputs { get; private set; }

        public NeuronLayer OutputLayer { get; private set; }

        public IList<NeuronLayer> HiddenLayers { get; private set; }

        public FeedforwardNetwork(int inputs, int outputNeurons, int hiddenLayers, int neuronsPerHiddenLayer)
        {
            MaxInputs = inputs;

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

        public void SetAllWeights(IList<double> weights)
        {
            var allweights = weights;
            foreach (var layer in HiddenLayers)
            {
                var weightCount = layer.AllWeights.Count();
                layer.AllWeights = allweights.Take(weightCount).ToList();
                allweights = allweights.Skip(weightCount).ToList();
            }
            OutputLayer.AllWeights = allweights;
        }
    }
}
