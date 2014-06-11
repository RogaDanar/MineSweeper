namespace NeuralNet.Network
{
    using System.Collections.Generic;
    using System.Linq;

    public class NeuronLayer
    {
        public IList<Neuron> Neurons { get; private set; }

        public NeuronLayer(int numberOfNeurons, int inputsPerNeuron)
        {
            Neurons = Enumerable.Range(0, numberOfNeurons).Select(x => new Neuron(inputsPerNeuron)).ToList();
        }

        public void Input(IList<double> inputs)
        {
            foreach (var neuron in Neurons)
            {
                neuron.Send(inputs);
            }
        }

        public IList<double> Output()
        {
            return Neurons.Select(x => x.Output).ToList();
        }

        public IList<double> AllWeights
        {
            get
            {
                return Neurons.SelectMany(x => x.InputWeights).ToList();
            }
            set
            {
                var allweights = value;
                foreach (var neuron in Neurons)
                {
                    neuron.InputWeights = allweights.Take(neuron.InputWeights.Count).ToList();
                    allweights = allweights.Skip(neuron.InputWeights.Count).ToList();
                }
            }
        }
    }
}
