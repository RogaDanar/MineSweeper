namespace Brainspace.Models.Neural
{
    using Brainspace.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Neuron
    {
        private readonly Rand _rand = Rand.Generator;

        public IList<double> InputWeights { get; set; }

        public double Output
        {
            get
            {
                return sigmoid(NeuroTransmitterLevels[NeuroTransmitter.Dopamine]);
            }
        }

        public Dictionary<NeuroTransmitter, double> NeuroTransmitterLevels { get; private set; }

        public Neuron(int numberOfInputs)
        {
            InputWeights = Enumerable.Range(0, numberOfInputs).Select(x => _rand.NextClamped()).ToList();
            initializeNeuroTransmitters();
        }

        /// <summary>
        /// Call this method to activate the receptor, which may fire if a threshold is reached
        /// </summary>
        public void ActivateReceptor(IList<double> inputs)
        {
            NeuroTransmitterLevels[NeuroTransmitter.Dopamine] = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                NeuroTransmitterLevels[NeuroTransmitter.Dopamine] += inputs[i] * InputWeights[i];
            }
        }

        private void initializeNeuroTransmitters()
        {
            NeuroTransmitterLevels = new Dictionary<NeuroTransmitter, double>();

            foreach (NeuroTransmitter transmitter in Enum.GetValues(typeof(NeuroTransmitter)))
            {
                NeuroTransmitterLevels.Add(transmitter, 0);
            }
        }

        private void declineTransmitterLevels()
        {
            foreach (NeuroTransmitter transmitter in Enum.GetValues(typeof(NeuroTransmitter)))
            {
                if (NeuroTransmitterLevels[transmitter] > 0)
                {
                    NeuroTransmitterLevels[transmitter]--;
                }
            }
        }

        private double sigmoid(double input)
        {
            var numberOfResponses = 1;
            return (1 / (1 + Math.Exp(-input / numberOfResponses)));
        }
    }
}
