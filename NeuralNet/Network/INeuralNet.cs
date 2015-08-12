namespace NeuralNet.Network
{
    using System.Collections.Generic;
    using NeuralNet.Genetics;

    public interface INeuralNet
    {
        Genome Genome { get; set; }
        int InputNeuronCount { get; }
        int OutputNeuronCount { get; }
        int AllWeightsCount();
        IList<double> Observe(IList<double> inputs);
    }
}
