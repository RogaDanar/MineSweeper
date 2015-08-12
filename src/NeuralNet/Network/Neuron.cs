namespace NeuralNet.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class Neuron
    {
        private readonly Rand _rand = Rand.Generator;

        private readonly int _defaultWeight = 1;

        private double _totalInput;

        private IList<double> _inputWeights;

        public IEnumerable<double> InputWeights { get { return _inputWeights; } }

        /// <summary>
        /// Create a Neuron with predefined weights,
        /// </summary>
        /// <param name="weights">total of inputs + 1 bias</param>
        public Neuron(IEnumerable<double> weights)
        {
            resetTotalInput();
            _inputWeights = weights.ToArray();
        }

        /// <summary>
        /// Create a Neuron with the given number of inputs
        /// </summary>
        /// <param name="numberOfInputs">total inputs</param>
        /// <param name="randomInputWeights">if not random all weights will be 1</param>
        /// <param name="randomBias">if not random the bias will be 1</param>
        public Neuron(int numberOfInputs, bool randomInputWeights = true, bool randomBias = true)
        {
            resetTotalInput();
            _inputWeights = getInputWeights(numberOfInputs, randomInputWeights);
            // Add an extra weight for the bias
            _inputWeights.Add(getBias(randomBias));
        }

        public void UpdateInputWeights(IEnumerable<double> newInputWeights)
        {
            _inputWeights = newInputWeights.ToList();
        }

        public void SendSignals(IList<double> inputs)
        {
            for (int i = 0; i < inputs.Count(); i++)
            {
                _totalInput += inputs[i] * _inputWeights[i];
            }
        }

        public void SendSignals(params double[] inputs)
        {
            for (int i = 0; i < inputs.Count(); i++)
            {
                _totalInput += inputs[i] * _inputWeights[i];
            }
        }

        public double GetOutputSignal()
        {
            var output = sigmoid(_totalInput);
            resetTotalInput();
            return output;
        }

        private IList<double> getInputWeights(int numberOfInputs, bool randomInputWeights)
        {
            return Enumerable.Range(0, numberOfInputs)
                .Select(x => getInputWeight(randomInputWeights))
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

        private double getBias(bool random)
        {
            return getWeight(random);
        }

        private double getInputWeight(bool random)
        {
            return getWeight(random);
        }

        private double getWeight(bool random)
        {
            double weight;
            if (random)
            {
                weight = _rand.NextClamped();
            }
            else
            {
                weight = _defaultWeight;
            }
            return weight;
        }
    }
}