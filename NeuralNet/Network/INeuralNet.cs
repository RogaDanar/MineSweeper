namespace NeuralNet.Network
{
    using System.Collections.Generic;
    using NeuralNet.Genetics;

    public interface INeuralNet
    {
        Genome Genome { get; set; }
        int MaxInputs { get; }
        int MinOutputs { get; }
        int AllWeightsCount();
        IEnumerable<double> GetAllWeights();
        double[] Observe(double[] inputs);
    }
}
