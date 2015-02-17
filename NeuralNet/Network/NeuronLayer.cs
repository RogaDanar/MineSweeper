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

        public IEnumerable<double> SendSignals(double[] inputs)
        {
            foreach (var neuron in Neurons)
            {
                yield return neuron.SendSignals(inputs);
            }
        }

        public IEnumerable<double> AllWeights
        {
            get
            {
                return Neurons.SelectMany(x => x.InputWeights);
            }
            set
            {
                var allweights = value;
                foreach (var neuron in Neurons)
                {
                    neuron.UpdateInputWeights(allweights.Take(neuron.InputWeights.Count()));
                    allweights = allweights.Skip(neuron.InputWeights.Count());
                }
            }
        }
    }
}
