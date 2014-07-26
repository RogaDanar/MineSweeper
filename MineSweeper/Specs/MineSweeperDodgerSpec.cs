namespace MineSweeper.Specs
{
    using MineSweeper.Vectors;
    using NeuralNet.Genetics;
    using NeuralNet.Helpers;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeperDodgerSpec : IMineSweeperSpec
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

        public List<SweeperDodger> SweeperDodgers { get; private set; }
        public List<Sweeper> Sweepers { get { return SweeperDodgers.Select(x => (Sweeper)x).ToList(); } }
        public List<List<double>> Holes { get; private set; }
        public List<List<double>> Mines { get; private set; }
        public Population Population { get; private set; }
        public int Ticks { get { return _settings.Ticks; } }

        public MineSweeperDodgerSpec(MineSweeperSettings settings)
        {
            _settings = settings;
        }

        public IGeneticAlgorithm SetupGenetics()
        {
            return new GeneticAlgorithm(_settings);
        }

        public void SetupCreatures()
        {
            SweeperDodgers = createSweeperDodgers().ToList();
            Mines = createObjects(_settings.MineCount).ToList();
            Holes = createObjects(_settings.MineCount).ToList();
        }

        public void SetupPopulation()
        {
            var sweeperWeightCount = SweeperDodgers.First().Brain.AllWeightsCount();
            Population = new Population(_settings.SweeperCount, sweeperWeightCount);
            for (int i = 0; i < SweeperDodgers.Count; i++)
            {
                SweeperDodgers[i].Brain.Genome = Population.Genomes[i];
            }
        }

        public void NextTick()
        {
            for (int i = 0; i < SweeperDodgers.Count; i++)
            {
                var sweeper = SweeperDodgers[i];
                sweeper.Update(Mines, Holes);

                var touchDistance = _settings.MineSize + _settings.SweeperSize;
                var foundMine = sweeper.DetectColision(sweeper.ClosestMine, touchDistance);
                if (foundMine != null)
                {
                    var mine = Mines.Single(x => x.VectorEquals(foundMine));
                    Mines.Remove(mine);
                    Mines.AddRange(createObjects(1));
                    sweeper.Fitness += 2;
                }

                var foundHole = sweeper.DetectColision(sweeper.ClosestHole, touchDistance);
                if (foundHole != null)
                {
                    var hole = Holes.Single(x => x.VectorEquals(foundHole));
                    Holes.Remove(hole);
                    Holes.AddRange(createObjects(1));
                    sweeper.Fitness -= 3;
                }
            }
            Population.UpdateStats();
        }

        public void NextGeneration(IGeneticAlgorithm genetics)
        {
            Population = genetics.NextGeneration(Population);

            for (int i = 0; i < SweeperDodgers.Count; i++)
            {
                SweeperDodgers[i].Brain.Genome = Population.Genomes[i];
                var position = GetRandomPosition();
                var rotation = GetRandomRotation();
                SweeperDodgers[i].Initialize(position, rotation);
            }
            Mines = createObjects(Mines.Count).ToList();
            Holes = createObjects(Mines.Count).ToList();

            onNextGeneration();
        }

        public void AfterTick()
        {
            onTickEnded();
        }

        private IEnumerable<SweeperDodger> createSweeperDodgers()
        {
            for (int i = 0; i < _settings.SweeperCount; i++)
            {
                var position = GetRandomPosition();
                var rotation = GetRandomRotation();
                var brain = new FeedforwardNetwork(SweeperDodger.BrainInputs, SweeperDodger.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new SweeperDodger(position, rotation, _settings.DrawWidth, _settings.DrawHeight, brain);
            }
        }

        private IEnumerable<List<double>> createObjects(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var position = GetRandomPosition();
                yield return position;
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
