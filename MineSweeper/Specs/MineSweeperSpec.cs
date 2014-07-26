namespace MineSweeper.Specs
{
    using MineSweeper.Vectors;
    using NeuralNet.Genetics;
    using NeuralNet.Helpers;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeperSpec : IMineSweeperSpec
    {
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

        private MineSweeperSettings _settings;

        public List<Sweeper> Sweepers { get; private set; }
        public List<List<double>> Mines { get; private set; }
        public List<List<double>> Holes { get; private set; }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public MineSweeperSpec(MineSweeperSettings settings)
        {
            _settings = settings;
        }

        public IGeneticAlgorithm SetupGenetics()
        {
            return new GeneticAlgorithm(_settings);
        }

        public void SetupCreatures()
        {
            Sweepers = createSweepers().ToList();
            Mines = createMines(_settings.MineCount).ToList();
            Holes = new List<List<double>>();
        }

        public void SetupPopulation()
        {
            var sweeperWeightCount = Sweepers.First().Brain.AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);
            for (int i = 0; i < Sweepers.Count; i++)
            {
                Sweepers[i].Brain.Genome = Population.Genomes[i];
            }
        }

        public void NextTick()
        {
            for (int i = 0; i < Sweepers.Count; i++)
            {
                var sweeper = Sweepers[i];
                sweeper.Update(Mines);
                var foundMine = sweeper.DetectColision(sweeper.ClosestMine, _settings.MineSize + _settings.SweeperSize);
                if (foundMine != null)
                {
                    var mine = Mines.Single(x => x.VectorEquals(foundMine));
                    Mines.Remove(mine);
                    Mines.AddRange(createMines(1));
                    sweeper.Fitness++;
                }
            }
            Population.UpdateStats();
        }

        public void NextGeneration(IGeneticAlgorithm genetics)
        {
            Population = genetics.NextGeneration(Population);

            for (int i = 0; i < Sweepers.Count; i++)
            {
                Sweepers[i].Brain.Genome = Population.Genomes[i];
                var position = GetRandomPosition();
                var rotation = GetRandomRotation();
                Sweepers[i].Initialize(position, rotation);
            }
            Mines = createMines(Mines.Count).ToList();

            onNextGeneration();
        }

        public void AfterTick()
        {
            onTickEnded();
        }

        private IEnumerable<Sweeper> createSweepers()
        {
            for (int i = 0; i < _settings.SweeperCount; i++)
            {
                var position = GetRandomPosition();
                var rotation = GetRandomRotation();
                var brain = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new Sweeper(position, rotation, _settings.DrawWidth, _settings.DrawHeight, brain);
            }
        }

        private IEnumerable<List<double>> createMines(int numberOfMines)
        {
            for (int i = 0; i < numberOfMines; i++)
            {
                var mine = GetRandomPosition();
                yield return mine;
            }
        }

        private double GetRandomRotation()
        {
            return Rand.Generator.NextDouble() * Math.PI * 2;
        }

        private List<double> GetRandomPosition()
        {
            return Vector.RandomVector2D(_settings.DrawWidth, _settings.DrawHeight);
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _settings.Fast = !_settings.Fast;
        }
    }
}
