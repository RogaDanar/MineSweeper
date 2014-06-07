namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InputLayer
    {
        public IList<Neuron> Neurons { get; private set; }

        public InputLayer(int numberOfNeurons)
        {
            Neurons = Enumerable.Range(0, numberOfNeurons)
                .Select(x => new Neuron(x))
                .ToList();
        }

        public void Observe(Dictionary<int, int> inputs)
        {
            foreach (var input in inputs)
            {
                if (input.Value > 0)
                {
                    Neurons.Single(x => x.Id == input.Key).ActivateReceptor(NeuroTransmitter.Dopamine, 1);
                }
            }
        }

        public Dictionary<int, int> Output()
        {
            return Neurons.ToDictionary(x => x.Id, x => x.Output);
        }
    }
}
