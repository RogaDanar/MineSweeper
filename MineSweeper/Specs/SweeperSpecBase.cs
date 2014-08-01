namespace MineSweeper.Specs
{
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;

    public class SweeperSpecBase
    {
        protected IGeneticAlgorithm Genetics;

        public event EventHandler NextGenerationEnded = delegate { };
        public event EventHandler TickEnded = delegate { };

        public int Ticks { get { return Settings.Ticks; } }
        public MineSweeperSettings Settings { get; protected set; }

        public SweeperSpecBase(MineSweeperSettings settings)
        {
            Settings = settings;
        }

        protected IEnumerable<Tuple<ObjectType, List<double>>> GetObjects(ObjectType objectType, int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var newObject = Vector.RandomVector2D(Settings.DrawWidth, Settings.DrawHeight);
                yield return new Tuple<ObjectType, List<double>>(objectType, newObject);
            }
        }

        protected void RaiseNextGenerationEnded()
        {
            NextGenerationEnded.Raise(this, EventArgs.Empty);
        }

        protected void RaiseTickEnded()
        {
            TickEnded.Raise(this, EventArgs.Empty);
        }
    }
}
