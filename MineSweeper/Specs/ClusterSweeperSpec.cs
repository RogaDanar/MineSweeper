namespace MineSweeper.Specs
{
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClusterSweeperSpec : SweeperSpecBase, IMineSweeperSpec
    {
        private List<ClusterSweeper> _sweepers;

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public List<Tuple<ObjectType, List<double>>> Objects { get; private set; }
        public Population Population { get; private set; }

        public ClusterSweeperSpec()
            : this(MineSweeperSettings.ClusterSweeper())
        {
        }

        public ClusterSweeperSpec(MineSweeperSettings settings)
            : base(settings)
        {
            Objects = new List<Tuple<ObjectType, List<double>>>();
        }

        public void Setup()
        {
            Genetics = new GeneticAlgorithm(Settings);

            var sweeperWeightCount = getNewBrain().AllWeightsCount();
            Population = new Population(Settings.SweeperCount, sweeperWeightCount);
            //Population = new Population { Genomes = Enumerable.Range(1, Settings.SweeperCount).Select(x => new EliteClusterSweeperGenome()).Cast<Genome>().ToList() };

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
                    sweeper.Fitness += 3;
                }

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, Settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Objects.Where(x => x.Item1 == ObjectType.Mine).Single(x => x.Item2.VectorEquals(closestMine));
                    Objects.Remove(mine);
                    Objects.AddRange(GetObjects(ObjectType.Mine, 1));
                    sweeper.Fitness += 1;
                }
            }
            Population.UpdateStats();
        }

        public void NextGeneration()
        {
            Population = Genetics.NextGeneration(Population);

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

        public bool Continue()
        {
            return true;
        }

        private IEnumerable<ClusterSweeper> createSweepers()
        {
            for (int i = 0; i < Settings.SweeperCount; i++)
            {
                var brain = getNewBrain();
                yield return new ClusterSweeper(Settings.DrawWidth, Settings.DrawHeight, brain);
            }
        }

        private FeedforwardNetwork getNewBrain()
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
