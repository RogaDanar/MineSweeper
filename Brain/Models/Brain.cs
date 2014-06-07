namespace Brainspace.Models
{
    using Brainspace.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Brain
    {
        public INeuralNet Network { get; private set; }

        public Rand RandomGenerator { get; private set; }

        public Brain(INeuralNet network)
            : this(network, null)
        { }

        public Brain(INeuralNet network, Rand randomGenerator)
        {
            Network = network;
            RandomGenerator = randomGenerator ?? Rand.Generator;
        }

        public Dictionary<int, int> Show(Dictionary<int, int> inputs)
        {
            return Network.Show(inputs);
        }

        public void Sleep()
        {
        }
    }
}
