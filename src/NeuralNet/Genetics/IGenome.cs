namespace NeuralNet.Genetics
{
    using System.Collections.Generic;

    internal interface IGenome<T> where T : struct
    {
        /// <summary>
        /// A list of genes, on which a genetic selection process can be applied
        /// </summary>
        IList<T> Chromosome { get; }

        /// <summary>
        /// The fitness of the genome. The fitness only has meaning with respect to other fitnesses.
        /// </summary>
        double Fitness { get; }

        /// <summary>
        /// Set the Fitness to its default value
        /// </summary>
        void ResetFitness();

        /// <summary>
        /// Increase the Fitness by the given number
        /// </summary>
        void IncreaseFitness(int fitnessIncrease);

        /// <summary>
        /// Decrease the Fitness by the given number
        /// </summary>
        void DecreaseFitness(int fitnessDecrease);
    }
}