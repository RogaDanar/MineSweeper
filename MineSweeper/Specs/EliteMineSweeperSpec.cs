namespace MineSweeper.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;

    public class EliteMineSweeperSpec : SweeperSpecBase, IMineSweeperSpec
    {
        private List<SimpleSweeper> _sweepers;

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

        public EliteMineSweeperSpec()
            : this(MineSweeperSettings.EliteSweeper())
        {
        }

        public EliteMineSweeperSpec(MineSweeperSettings Settings)
            : base(Settings)
        {
            _mines = new List<IList<double>>();
        }

        public void Setup()
        {
            var sweeperWeightCount = getNewBrain().AllWeightsCount();
            Population = new Population(new GeneticAlgorithm(Settings));
            Population.Populate(Settings.SweeperCount - 1, sweeperWeightCount);
            Population.Genomes.Add(new EliteSweeper2070Genome());

            _sweepers = createSweepers().ToList();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
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
                        sweeper.Fitness++;
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
                _sweepers[i].Brain.Genome = Population.Genomes[i];
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

        private IEnumerable<SimpleSweeper> createSweepers()
        {
            for (int i = 0; i < Settings.SweeperCount; i++)
            {
                var brain = getNewBrain();
                yield return new SimpleSweeper(Settings.DrawWidth, Settings.DrawHeight, brain);
            }
        }

        private FeedforwardNetwork getNewBrain()
        {
            return new FeedforwardNetwork(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs, Settings.HiddenLayers, Settings.HiddenLayerNeurons);
        }

        private IEnumerable<IList<double>> getMines(int count)
        {
            return GetObjects(ObjectType.Mine, count).Select(x => x.Item2);
        }
    }
}
