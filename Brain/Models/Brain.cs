namespace Brainspace.Models
{
    using Brainspace.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Brain
    {
        public INeuralNet Network { get; private set; }

        public event EventHandler Tick;
        protected virtual void OnTick(EventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, e);
            }
        }

        public Rand RandomGenerator { get; private set; }

        public Brain(INeuralNet network)
            : this(network, null)
        { }

        public Brain(INeuralNet network, Rand randomGenerator)
        {
            Network = network;
            RandomGenerator = randomGenerator ?? Rand.Generator;
        }


        public void Awaken()
        {
            var neighbours = new List<int>();
            foreach (var neuron in Network.Neurons)
            {
                neuron.ActivateReceptor(NeuroTransmitter.Dopamine, RandomGenerator.Next(8));
            }
        }

        public void Sleep()
        {
        }
    }
}
