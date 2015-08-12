namespace NeuralNet.Network
{
    using System.Collections.Generic;
    using NeuralNet.Genetics;

    public interface INeuralNet
    {
        /// <summary>
        /// The neural network weights represented as a Genome. 
        /// It has a Chromosome which contains all the weights as a list.
        /// </summary>
        Genome Genome { get; }

        void UpdateGenome(Genome genome);

        /// <summary>
        /// Number of neurons in the input layer
        /// </summary>
        int InputNeuronCount { get; }

        /// <summary>
        /// Number of neurons in the output layer
        /// </summary>
        int OutputNeuronCount { get; }

        int AllWeightsCount();

        IList<double> Observe(IList<double> inputs);
    }
}
