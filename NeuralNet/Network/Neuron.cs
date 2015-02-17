namespace NeuralNet.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class Neuron
    {
        private readonly Rand _rand = Rand.Generator;
        private double _totalInput;
        private IList<double> _inputWeights;

        public IEnumerable<double> InputWeights { get { return _inputWeights.ToArray(); } }

        public Neuron(int numberOfInputs)
        {
            resetTotalInput();
            _inputWeights = getRandomInputWeights(numberOfInputs);
            // Add an extra weight for the bias
            _inputWeights.Add(getRandomBias());
        }

        public void UpdateInputWeights(IEnumerable<double> newInputWeights)
        {
            _inputWeights = newInputWeights.ToList();
        }

        public double SendSignals(double[] inputs)
        {
            resetTotalInput();
            for (int i = 0; i < inputs.Length; i++)
            {
                _totalInput += inputs[i] * _inputWeights[i];
            }
            return sigmoid(_totalInput);
        }

        private IList<double> getRandomInputWeights(int numberOfInputs)
        {
            return Enumerable.Range(0, numberOfInputs)
                .Select(x => getRandomInputWeight())
                .ToList();
        }

        private void resetTotalInput()
        {
            _totalInput = 0;
        }

        private double sigmoid(double input)
        {
            var numberOfResponses = 1;
            return (1 / (1 + Math.Exp(-input / numberOfResponses)));
        }

        private double getRandomBias()
        {
            return _rand.NextClamped();
        }

        private double getRandomInputWeight()
        {
            return _rand.NextClamped();
        }
    }
}
