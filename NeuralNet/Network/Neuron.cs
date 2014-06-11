namespace NeuralNet.Network
{
    using NeuralNet.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Neuron
    {
        private readonly Rand _rand = Rand.Generator;

        private double _totalInput;

        public IList<double> InputWeights { get; set; }

        public double Output
        {
            get
            {
                return sigmoid(_totalInput);
            }
        }

        public Neuron(int numberOfInputs)
        {
            InputWeights = Enumerable.Range(0, numberOfInputs).Select(x => _rand.NextClamped()).ToList();
            // Add an extra weight for the bias
            InputWeights.Add(_rand.NextClamped());
            _totalInput = 0;
        }

        public void Send(IList<double> inputs)
        {
            _totalInput = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                _totalInput += inputs[i] * InputWeights[i];
            }
        }

        private double sigmoid(double input)
        {
            var numberOfResponses = 1;
            return (1 / (1 + Math.Exp(-input / numberOfResponses)));
        }
    }
}
