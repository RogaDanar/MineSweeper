namespace MineSweeper.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;

    public class RecurrentSpec : IMineSweeperSpec
    {
        private List<SimpleSweeper> _sweepers;

        public event EventHandler NextGenerationEnded = delegate { };

        public event EventHandler TickEnded = delegate { };

        public int Ticks { get { return Settings.Ticks; } }
        public MineSweeperSettings Settings { get; protected set; }

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public Population Population { get; private set; }

        private List<IList<double>> _mines { get; set; }

        public List<Tuple<ObjectType, IList<double>>> Objects
        {
            get
            {
                return _mines.Select(x => Tuple.Create(ObjectType.Mine, x)).ToList();
            }
        }

        public RecurrentSpec()
            : this(MineSweeperSettings.Sweeper())
        {
        }

        public RecurrentSpec(MineSweeperSettings settings)
        {
            Settings = settings;
            _mines = new List<IList<double>>();
        }

        public void Setup()
        {
            var weightCount = getNewBrain(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs).AllWeightsCount();

            Population = new Population(new GeneticAlgorithm(Settings));
            Population.Populate(Settings.SweeperCount, weightCount);

            _sweepers = createSweepers(Settings.SweeperCount).ToList();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.UpdateGenome(Population.Genomes[i]);
            }

            _mines.AddRange(getMines(Settings.MineCount));
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];
                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, _mines);
                sweeper.Update(closestMine);

                if (_mines.Count > 0)
                {
                    var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, Settings.TouchDistance);
                    if (mineCollision)
                    {
                        var mine = _mines.Single(x => x.VectorEquals(closestMine));
                        _mines.Remove(mine);
                        if (Settings.ReplaceMine)
                        {
                            _mines.AddRange(getMines(1));
                        }
                        sweeper.IncreaseFitness(1);
                    }
                }
            }
            Population.UpdateFitnessStats();
        }

        public void NextGeneration()
        {
            Population.NextGeneration();

            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.UpdateGenome(Population.Genomes[i]);
                _sweepers[i].SetRandomMotion();
            }
            _mines.Clear();
            _mines.AddRange(getMines(Settings.MineCount));

            RaiseNextGenerationEnded();
        }

        public void AfterTick()
        {
            RaiseTickEnded();
        }

        public bool IsFinished()
        {
            return false;
        }

        private IEnumerable<SimpleSweeper> createSweepers(int count)
        {
            // Convenient way to see how many weights are needed for a sweeper, by creating a sweeper
            // who will create its own random genome
            var sweeperWeightCount = getNewBrain(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs).AllWeightsCount();

            for (int i = 0; i < count; i++)
            {
                var brain = getNewBrain(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs);
                yield return new SimpleSweeper(Settings.DrawWidth, Settings.DrawHeight, Settings.MaxSpeed, Settings.MaxRotation, brain);
            }
        }

        private IEnumerable<IList<double>> getMines(int count)
        {
            return GetObjects(ObjectType.Mine, count).Select(x => x.Item2);
        }

        protected IEnumerable<Tuple<ObjectType, IList<double>>> GetObjects(ObjectType objectType, int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var newObject = Vector.RandomVector2D(Settings.DrawWidth, Settings.DrawHeight);
                yield return new Tuple<ObjectType, IList<double>>(objectType, newObject);
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

        private INeuralNet getNewBrain(int inputs, int outputs)
        {
            return new RecurrentNeuralNetwork(inputs, outputs, Settings.HiddenLayers, Settings.HiddenLayerNeurons);
        }
    }
}