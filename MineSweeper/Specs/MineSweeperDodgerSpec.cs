namespace MineSweeper.Specs
{
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeperDodgerSpec : IMineSweeperSpec
    {
        private MineSweeperSettings _settings;
        private IGeneticAlgorithm _genetics;
        private List<SweeperDodger> _sweeperDodgers;

        public event EventHandler NextGenerationEnded = delegate { };
        public event EventHandler TickEnded = delegate { };

        public List<ICreature> Creatures { get { return _sweeperDodgers.Cast<ICreature>().ToList(); } }
        public List<Tuple<ObjectType, List<double>>> Objects { get; private set; }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public MineSweeperDodgerSpec(MineSweeperSettings settings)
        {
            _settings = settings;
            Objects = new List<Tuple<ObjectType, List<double>>>();
        }

        public void Setup()
        {
            _genetics = new GeneticAlgorithm(_settings);

            var sweeperWeightCount = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons).AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);

            _sweeperDodgers = createSweeperDodgers().ToList();
            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                _sweeperDodgers[i].Brain.Genome = Population.Genomes[i];
            }
            Objects.AddRange(getObjects(ObjectType.Mine, _settings.MineCount));
            Objects.AddRange(getObjects(ObjectType.Hole, _settings.MineCount));
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                var sweeper = _sweeperDodgers[i];

                var mines = Objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2).ToList();
                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, mines);

                var holes = Objects.Where(x => x.Item1 == ObjectType.Hole).Select(x => x.Item2).ToList();
                var closestHole = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, holes);

                sweeper.Update(closestMine, closestHole);

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, _settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Objects.Where(x => x.Item1 == ObjectType.Mine).Single(x => x.Item2.VectorEquals(closestMine));
                    Objects.Remove(mine);
                    Objects.AddRange(getObjects(ObjectType.Mine, 1));
                    sweeper.Fitness += 2;
                }

                var holeCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestHole, _settings.TouchDistance);
                if (holeCollision)
                {
                    var hole = Objects.Where(x => x.Item1 == ObjectType.Hole).Single(x => x.Item2.VectorEquals(closestHole));
                    Objects.Remove(hole);
                    Objects.AddRange(getObjects(ObjectType.Hole, 1));
                    sweeper.Fitness -= 3;
                }
            }
            Population.UpdateStats();
        }

        public void NextGeneration()
        {
            Population = _genetics.NextGeneration(Population);

            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                _sweeperDodgers[i].Brain.Genome = Population.Genomes[i];
                _sweeperDodgers[i].SetRandomMotion();
            }
            Objects.Clear();
            Objects.AddRange(getObjects(ObjectType.Mine, _settings.MineCount));
            Objects.AddRange(getObjects(ObjectType.Hole, _settings.MineCount));

            NextGenerationEnded.Raise(this, EventArgs.Empty);
        }

        public void AfterTick()
        {
            TickEnded.Raise(this, EventArgs.Empty);
        }

        public bool Continue()
        {
            return true;
        }

        private IEnumerable<SweeperDodger> createSweeperDodgers()
        {
            for (int i = 0; i < _settings.SweeperCount; i++)
            {
                var brain = new FeedforwardNetwork(SweeperDodger.BrainInputs, SweeperDodger.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new SweeperDodger(_settings.DrawWidth, _settings.DrawHeight, brain);
            }
        }

        private IEnumerable<Tuple<ObjectType, List<double>>> getObjects(ObjectType objectType, int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var newObject = Vector.RandomVector2D(_settings.DrawWidth, _settings.DrawHeight);
                yield return new Tuple<ObjectType, List<double>>(objectType, newObject);
            }
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _settings.Fast = !_settings.Fast;
        }
    }
}
