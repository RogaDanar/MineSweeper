namespace NeuralNet.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NeuronLayer
    {
        public IList<Neuron> Neurons { get; private set; }

        public NeuronLayer(int numberOfNeurons, int inputsPerNeuron, bool randomInputWeights = true, bool randomBias = true)
        {
            Neurons = Enumerable.Range(0, numberOfNeurons).Select(x => new Neuron(inputsPerNeuron, randomInputWeights, randomBias)).ToList();
        }

        public NeuronLayer(int numberOfNeurons, int inputsPerNeuron, IEnumerable<double> weights)
        {
            var weightsPerNeuron = inputsPerNeuron + 1; // Add 1 for the bias
            if (weights.Count() != numberOfNeurons * weightsPerNeuron)
            {
                throw new ArgumentException("Incorrect amount of weights given", "weights");
            }
            Neurons = new List<Neuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new Neuron(weights.Skip(i * weightsPerNeuron).Take(weightsPerNeuron)));
            }
        }

        public IEnumerable<double> SendSignalsAndGetOuputSignal(IList<double> inputs)
        {
            foreach (var neuron in Neurons)
            {
                neuron.SendSignals(inputs);
                yield return neuron.GetOutputSignal();
            }
        }

        public void SendSignals(IList<double> inputs)
        {
            foreach (var neuron in Neurons)
            {
                neuron.SendSignals(inputs);
            }
        }

        public IEnumerable<double> GetOutputSignals()
        {
            foreach (var neuron in Neurons)
            {
                yield return neuron.GetOutputSignal();
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
