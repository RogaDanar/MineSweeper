namespace MineSweeper.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;

    public class MineSweeperHoleDodgerSpec : SweeperSpecBase, IMineSweeperSpec
    {
        private List<SweeperDodger> _sweeperDodgers;

        public List<ICreature> Creatures { get { return _sweeperDodgers.Cast<ICreature>().ToList(); } }
        public List<Tuple<ObjectType, IList<double>>> Objects { get; private set; }
        public Population Population { get; private set; }

        public MineSweeperHoleDodgerSpec()
            : this(MineSweeperSettings.SweeperDodger())
        {
        }

        public MineSweeperHoleDodgerSpec(MineSweeperSettings settings)
            : base(settings)
        {
            Objects = new List<Tuple<ObjectType, IList<double>>>();
        }

        public void Setup()
        {
            _sweeperDodgers = createSweeperDodgers(Settings.SweeperCount).ToList();

            Population = new Population(new GeneticAlgorithm(Settings));
            Population.Populate(_sweeperDodgers.Select(x => x.Brain.Genome));

            createNewObjects();
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

                if (holes.Count > 0)
                {
                    var holeCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestHole, Settings.TouchDistance);
                    if (holeCollision)
                    {
                        var hole = Objects.Where(x => x.Item1 == ObjectType.Hole).Single(x => x.Item2.VectorEquals(closestHole));
                        Objects.Remove(hole);
                        //Objects.AddRange(GetObjects(ObjectType.Hole, 1));
                        sweeper.DecreaseFitness(10);
                    }
                }
            }
            Population.UpdateFitnessStats();
        }

        public void NextGeneration()
        {
            Population.NextGeneration();

            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                _sweeperDodgers[i].Brain.UpdateGenome(Population.Genomes[i]);
                _sweeperDodgers[i].SetRandomMotion();
            }
            createNewObjects();

            RaiseNextGenerationEnded();
        }

        private void createNewObjects()
        {
            Objects.Clear();
            Objects.AddRange(GetObjects(ObjectType.Mine, Settings.MineCount));
            Objects.AddRange(GetObjects(ObjectType.Hole, Settings.MineCount));
        }

        public void AfterTick()
        {
            RaiseTickEnded();
        }

        public bool IsFinished()
        {
            return false;
        }

        private IEnumerable<SweeperDodger> createSweeperDodgers(int count)
        {
            // Convenient way to see how many weights are needed for a sweeper, by creating a sweeper
            // who will create its own random genome
            var sweeperWeightCount = GetNewBrain(SweeperDodger.BrainInputs, SweeperDodger.BrainOutputs).AllWeightsCount();

            for (int i = 0; i < count; i++)
            {
                var brain = GetNewBrain(SweeperDodger.BrainInputs, SweeperDodger.BrainOutputs, sweeperWeightCount);
                yield return new SweeperDodger(Settings.DrawWidth, Settings.DrawHeight, Settings.MaxSpeed, Settings.MaxRotation, brain);
            }
        }
    }
}
