namespace NeuralNet.Genetics
{
    using System.Collections.Generic;

    interface IGenome<T> where T : struct
    {
        IList<T> Chromosome { get; set; }
        double Fitness { get; }
    }
}
