namespace MineSweeper.Specs
{
    using MineSweeper.Creatures;
    using NeuralNet.AppHelpers;
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;

    public interface IMineSweeperSpec : IRunnerSpecification
    {
        event EventHandler NextGenerationEnded;
        event EventHandler TickEnded;

        MineSweeperSettings Settings { get; }
        List<ICreature> Creatures { get; }
        List<Tuple<ObjectType, List<double>>> Objects { get; }
        Population Population { get; }
    }
}
