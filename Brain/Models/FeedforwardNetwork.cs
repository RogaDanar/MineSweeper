namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FeedforwardNetwork : INeuralNet
    {
        public NeuronLayer Input { get; set; }
        public NeuronLayer Output { get; set; }
        public IEnumerable<NeuronLayer> Hidden { get; set; }

        public IEnumerable<Neuron> Neurons { get; private set; }

        public FeedforwardNetwork(int numberOfNeurons)
        {
            Neurons = Enumerable.Repeat(new Neuron(this), numberOfNeurons);
        }
    }
}
