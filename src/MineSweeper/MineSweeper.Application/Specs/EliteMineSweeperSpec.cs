namespace MineSweeper.Application.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Application.Creatures;
    using MineSweeper.Application.Utils;
    using NeuralNet.Genetics;

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
            _sweepers = createSweepers(Settings.SweeperCount - 1).ToList();

            Population = new Population(new GeneticAlgorithm(Settings));
            Population.Populate(_sweepers.Select(x => x.Brain.Genome));

            Population.Genomes.Add(new EliteSweeper2070Genome());

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
            var sweeperWeightCount = GetNewBrain(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs).AllWeightsCount();

            for (int i = 0; i < count; i++)
            {
                var brain = GetNewBrain(SimpleSweeper.BrainInputs, SimpleSweeper.BrainOutputs, sweeperWeightCount);
                yield return new SimpleSweeper(Settings.DrawWidth, Settings.DrawHeight, Settings.MaxSpeed, Settings.MaxRotation, brain);
            }
        }

        private IEnumerable<IList<double>> getMines(int count)
        {
            return GetObjects(ObjectType.Mine, count).Select(x => x.Item2);
        }
    }
}