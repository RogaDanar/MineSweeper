namespace Brainspace.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class NeuronLayer
    {
        public IEnumerable<Neuron> Neurons { get; private set; }

        public NeuronLayer(int numberOfNeurons)
        {
            Neurons = Enumerable.Repeat(new Neuron(), numberOfNeurons);
        }
    }

}
