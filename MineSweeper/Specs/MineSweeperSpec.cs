namespace MineSweeper.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;

    public class MineSweeperSpec : SweeperSpecBase, IMineSweeperSpec
    {
        private List<SimpleSweeper> _sweepers;

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public Population Population { get; private set; }

        public List<Tuple<ObjectType, List<double>>> Objects { get; private set; }

        public MineSweeperSpec()
            : this(MineSweeperSettings.Sweeper())
        {
        }

        public MineSweeperSpec(MineSweeperSettings Settings)
            : base(Settings)
        {
            Objects = new List<Tuple<ObjectType, List<double>>>();
        }

        public void Setup()
        {
            var sweeperWeightCount = getNewBrain().AllWeightsCount();
            Population = new Population(new GeneticAlgorithm(Settings));
            Population.Populate(Settings.SweeperCount, sweeperWeightCount);

            _sweepers = createSweepers().ToList();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
            }
            Objects.AddRange(GetObjects(ObjectType.Mine, Settings.MineCount));
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];

                var mines = Objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2).ToList();
                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, mines);
                sweeper.Update(closestMine);

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, Settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Objects.Where(x => x.Item1 == ObjectType.Mine).Single(x => x.Item2.VectorEquals(closestMine));
                    Objects.Remove(mine);
                    Objects.AddRange(GetObjects(ObjectType.Mine, 1));
                    sweeper.Fitness++;
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
            Objects.Clear();
            Objects.AddRange(GetObjects(ObjectType.Mine, Settings.MineCount));

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
    }
}
