﻿namespace Brainspace.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class NeuronLayer
    {
        public IList<Neuron> Neurons { get; private set; }

        public NeuronLayer(int numberOfNeurons)
        {
            Neurons = Enumerable.Range(0, numberOfNeurons)
                .Select(x => new Neuron(x))
                .ToList();
        }

        public void Input(Dictionary<int, int> inputs)
        {
            foreach (var neuron in Neurons)
            {
                neuron.ActivateReceptor(NeuroTransmitter.Dopamine, inputs.Values.Sum());
            }
        }

        public Dictionary<int, int> Output()
        {
            return Neurons.ToDictionary(x => x.Id, x => x.Output);
        }
    }
}
