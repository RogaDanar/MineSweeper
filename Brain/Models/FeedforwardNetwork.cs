namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FeedforwardNetwork : INeuralNet
    {
        public InputLayer InputLayer { get; private set; }
        public NeuronLayer OutputLayer { get; private set; }
        public IEnumerable<NeuronLayer> HiddenLayers { get; private set; }

        public FeedforwardNetwork(int inputNeurons, int outputNeurons, int hiddenLayers, int hiddenNeuronsPerLayer)
        {
            InputLayer = new InputLayer(inputNeurons);
            OutputLayer = new NeuronLayer(outputNeurons);
            HiddenLayers = Enumerable.Repeat(new NeuronLayer(hiddenNeuronsPerLayer), hiddenLayers);            
        }

        public Dictionary<int, int> Show(Dictionary<int, int> inputs)
        {
            if (inputs.Keys.OrderBy(x => x).Last() > InputLayer.Neurons.Count)
            {
                return null;
            }

            InputLayer.Observe(inputs);
            var result = InputLayer.Output();
            foreach (var layer in HiddenLayers)
            {
                layer.Input(result);
                result = layer.Output();
            }
            OutputLayer.Input(result);
            return OutputLayer.Output();
        }
    }
}
