namespace MineSweeper.Application.Specs
{
    using System;
    using System.Collections.Generic;
    using MineSweeper.Application.Creatures;
    using NeuralNet.AppHelpers;
    using NeuralNet.Genetics;

    public interface IMineSweeperSpec : IRunnerSpecification
    {
        event EventHandler NextGenerationEnded;

        event EventHandler TickEnded;

        MineSweeperSettings Settings { get; }

        List<ICreature> Creatures { get; }

        List<Tuple<ObjectType, IList<double>>> Objects { get; }

        Population Population { get; }
    }
}