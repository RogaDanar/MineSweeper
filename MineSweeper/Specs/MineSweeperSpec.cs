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

        public List<ICreature> Creatures { get { return _sweepers.Cast<ICreature>().ToList(); } }
        public List<List<double>> Mines { get; private set; }
        public List<List<double>> Holes { get; private set; }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public MineSweeperSpec(MineSweeperSettings settings)
        {
            _settings = settings;
        }

        public void Setup()
        {
            _genetics = new GeneticAlgorithm(_settings);

            var sweeperWeightCount = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons).AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);

            _sweepers = createSweepers().ToList();
            Mines = createMines(_settings.MineCount).ToList();
            Holes = new List<List<double>>();
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = Population.Genomes[i];
            }
        }

        public void NextTick()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];

                var closestMine = DistanceCalculator.GetClosestObject(sweeper.Motion.Position, Mines);
                sweeper.Update(closestMine);

                var foundMine = DistanceCalculator.DetectCollision(sweeper.Motion.Position, closestMine, _settings.TouchDistance);
                if (foundMine)
                {
                    var mine = Mines.Single(x => x.VectorEquals(closestMine));
                    Mines.Remove(mine);
                    Mines.AddRange(createMines(1));
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
            Mines = createMines(Mines.Count).ToList();

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

        private IEnumerable<Sweeper> createSweepers()
        {
            for (int i = 0; i < _settings.SweeperCount; i++)
            {
                var brain = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new Sweeper(_settings.DrawWidth, _settings.DrawHeight, brain);
            }
        }

        private IEnumerable<List<double>> createMines(int numberOfMines)
        {
            for (int i = 0; i < numberOfMines; i++)
            {
                var mine = Vector.RandomVector2D(_settings.DrawWidth, _settings.DrawHeight);
                yield return mine;
            }
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _settings.Fast = !_settings.Fast;
        }
    }
}
