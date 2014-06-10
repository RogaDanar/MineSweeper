namespace NeuralNet.Network
{
    using NeuralNet.Genetics;
    using System.Collections.Generic;

    public interface INeuralNet
    {
        Genome Genome { get; set; }
        int MaxInputs { get; }
        int MinOutputs { get; }
        int AllWeightsCount();
        IList<double> GetAllWeights();
        IList<double> Observe(IList<double> inputs);
    }
}
