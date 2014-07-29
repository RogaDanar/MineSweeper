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

        public event EventHandler NextGenerationEnded;

        private void onNextGeneration()
        {
            if (NextGenerationEnded != null)
            {
                NextGenerationEnded(this, EventArgs.Empty);
            }
        }

        public event EventHandler TickEnded;

        private void onTickEnded()
        {
            if (TickEnded != null)
            {
                TickEnded(this, EventArgs.Empty);
            }
        }

        public List<ICreature> Creatures { get { return _sweeperDodgers.Cast<ICreature>().ToList(); } }
        public List<List<double>> Holes { get; private set; }
        public List<List<double>> Mines { get; private set; }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public MineSweeperDodgerSpec(MineSweeperSettings settings)
        {
            _settings = settings;
        }

        public void Setup()
        {
            _genetics = new GeneticAlgorithm(_settings);

            var sweeperWeightCount = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons).AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);

            _sweeperDodgers = createSweeperDodgers().ToList();
            Mines = createObjects(_settings.MineCount).ToList();
            Holes = createObjects(_settings.MineCount).ToList();
            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                _sweeperDodgers[i].Brain.Genome = Population.Genomes[i];
            }
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweeperDodgers.Count; i++)
            {
                var sweeper = _sweeperDodgers[i];

                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, Mines);
                var closestHole = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, Holes);

                sweeper.Update(closestMine, closestHole);

                var mineCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, _settings.TouchDistance);
                if (mineCollision)
                {
                    var mine = Mines.Single(x => x.VectorEquals(closestMine));
                    Mines.Remove(mine);
                    Mines.AddRange(createObjects(1));
                    sweeper.Fitness += 2;
                }

                var holeCollision = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestHole, _settings.TouchDistance);
                if (holeCollision)
                {
                    var hole = Holes.Single(x => x.VectorEquals(closestHole));
                    Holes.Remove(hole);
                    Holes.AddRange(createObjects(1));
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
            Mines = createObjects(Mines.Count).ToList();
            Holes = createObjects(Mines.Count).ToList();

            onNextGeneration();
        }

        public void AfterTick()
        {
            onTickEnded();
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

        private IEnumerable<List<double>> createObjects(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var position = Vector.RandomVector2D(_settings.DrawWidth, _settings.DrawHeight);
                yield return position;
            }
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _settings.Fast = !_settings.Fast;
        }
    }
}
