namespace MineSweeper.Specs
{
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeperSpec : IMineSweeperSpec
    {
        private MineSweeperSettings _settings;
        private IGeneticAlgorithm _genetics;
        private List<Sweeper> _sweepers;

        public event EventHandler NextGenerationEnded = delegate { };
        public event EventHandler TickEnded = delegate { };

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public List<Tuple<ObjectType, List<double>>> Objects { get; private set; }

        public MineSweeperSpec(MineSweeperSettings settings)
        {
            _settings = settings;
            Objects = new List<Tuple<ObjectType, List<double>>>();
        }

        public void Setup()
        {
            _genetics = new GeneticAlgorithm(_settings);

            var sweeperWeightCount = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons).AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);

            _sweepers = createSweepers().ToList();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
            }
            Objects.AddRange(getObjects(ObjectType.Mine, _settings.MineCount));
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];

                var mines = Objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2).ToList();
                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, mines);
                sweeper.Update(closestMine);

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, _settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Objects.Where(x => x.Item1 == ObjectType.Mine).Single(x => x.Item2.VectorEquals(closestMine));
                    Objects.Remove(mine);
                    Objects.AddRange(getObjects(ObjectType.Mine, 1));
                    sweeper.Fitness++;
                }
            }
            Population.UpdateStats();
        }

        public void NextGeneration()
        {
            Population = _genetics.NextGeneration(Population);

            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
                _sweepers[i].SetRandomMotion();
            }
            Objects.Clear();
            Objects.AddRange(getObjects(ObjectType.Mine, _settings.MineCount));

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

        private IEnumerable<Sweeper> createSweepers()
        {
            for (int i = 0; i < _settings.SweeperCount; i++)
            {
                var brain = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new Sweeper(_settings.DrawWidth, _settings.DrawHeight, brain);
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
