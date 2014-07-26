namespace MineSweeper.Specs
{
    using NeuralNet.AppHelpers;
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;

    public interface IMineSweeperSpec : IRunnerSpecification
    {
        event EventHandler NextGenerationEnded;
        event EventHandler TickEnded;

        List<Sweeper> Sweepers { get; }
        List<List<double>> Mines { get; }
        List<List<double>> Holes { get; }
        Population Population { get; }
    }
}
