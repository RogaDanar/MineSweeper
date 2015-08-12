namespace MineSweeper.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;

    public class ClusterSweeperSpec : SweeperSpecBase, IMineSweeperSpec
    {
        private List<ClusterSweeper> _sweepers;

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public List<Tuple<ObjectType, IList<double>>> Objects { get; private set; }
        public Population Population { get; private set; }

        public ClusterSweeperSpec()
            : this(MineSweeperSettings.ClusterSweeper())
        {
        }

        public ClusterSweeperSpec(MineSweeperSettings settings)
            : base(settings)
        {
            Objects = new List<Tuple<ObjectType, IList<double>>>();
        }

        public void Setup()
        {
            Population = new Population(new GeneticAlgorithm(Settings));

            var sweeperWeightCount = getNewBrain().AllWeightsCount();
            Population.Populate(Settings.SweeperCount, sweeperWeightCount);

            _sweepers = createSweepers().ToList();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
            }
            createNewObjects();
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];

                var clusterMines = Objects.Where(x => x.Item1 == ObjectType.ClusterMine).Select(x => x.Item2).ToList();
                var closestClusterMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, clusterMines);
                var secondClosestClusterMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, clusterMines, 1);

                var mines = Objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2).ToList();
                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, mines);
                var secondClosestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, mines, 1);

                sweeper.Update(closestClusterMine, secondClosestClusterMine, closestMine, secondClosestClusterMine);

                var clusterMineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestClusterMine, Settings.TouchDistance);
                if (clusterMineCollision)
                {
                    var clusterMine = Objects.Where(x => x.Item1 == ObjectType.ClusterMine).Single(x => x.Item2.VectorEquals(closestClusterMine));
                    Objects.Remove(clusterMine);
                    Objects.AddRange(GetObjects(ObjectType.ClusterMine, 1));
                    sweeper.IncreaseFitness(3);
                }

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, Settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Objects.Where(x => x.Item1 == ObjectType.Mine).Single(x => x.Item2.VectorEquals(closestMine));
                    Objects.Remove(mine);
                    if (Settings.ReplaceMine)
                    {
                        Objects.AddRange(GetObjects(ObjectType.Mine, 1));
                    }
                    sweeper.IncreaseFitness(1);
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
            createNewObjects();

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

        private IEnumerable<ClusterSweeper> createSweepers()
        {
            for (int i = 0; i < Settings.SweeperCount; i++)
            {
                var brain = getNewBrain();
                yield return new ClusterSweeper(Settings.DrawWidth, Settings.DrawHeight, brain);
            }
        }

        private INeuralNet getNewBrain()
        {
            return new FeedforwardNetwork(ClusterSweeper.BrainInputs, ClusterSweeper.BrainOutputs, Settings.HiddenLayers, Settings.HiddenLayerNeurons);
        }

        private void createNewObjects()
        {
            Objects.Clear();
            Objects.AddRange(GetObjects(ObjectType.ClusterMine, Settings.MineCount));
            Objects.AddRange(GetObjects(ObjectType.Mine, Settings.MineCount));
        }
    }
}
