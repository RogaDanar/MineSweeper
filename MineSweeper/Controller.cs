namespace MineSweeper
{
    using NeuralNet.Genetics;
    using NeuralNet.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public class Controller
    {
        private readonly Rand _rand = Rand.Generator;

        private const double _mineSize = 10;
        private const double _mutationRate = 0.1;
        private const double _crossoverRate = 0.7;
        private const double _perturbationRate = 0.3;

        private Main _mainForm;

        private List<Sweeper> _sweepers;
        private List<List<double>> _mines;
        private int _sweeperWeightCount;
        private GeneticAlgorithm _geneticAlgorithm;
        private Population _genomePopulation;

        public Controller(int numberOfSweepers, int numberOfMines)
        {
            var uiThread = new Thread(() => {
                _mainForm = new Main(this);
                Application.Run(_mainForm);
            });
            uiThread.Start();

            _sweepers = createSweepers(numberOfSweepers).ToList();
            _mines = createMines(numberOfMines).ToList();
            _geneticAlgorithm = new GeneticAlgorithm(_mutationRate, _crossoverRate, _perturbationRate);

            _sweeperWeightCount = _sweepers.First().Brain.AllWeightsCount();
            _genomePopulation = new Population(numberOfSweepers, _sweeperWeightCount);
            initializeBrains();

            StartSimulation(2000);
        }

        public void StartSimulation(int ticks)
        {
            while (true)
            {
                try
                {
                    _mainForm.Invoke((MethodInvoker)delegate { _mainForm.SetStats(_genomePopulation); });
                }
                catch (Exception)
                {
                    break;
                }

                for (int i = 0; i < ticks; i++)
                {
                    Update();
                    try
                    {
                        _mainForm.Invoke((MethodInvoker)delegate { _mainForm.Tick(_sweepers, _mines); });
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                NextGeneration();
            }
        }

        public void Stop()
        {
        }

        public void Update()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                var sweeper = _sweepers[i];
                sweeper.Update(_mines);
                var foundMine = sweeper.CheckForMine(_mineSize);
                if (foundMine != null)
                {
                    var mine = _mines.Single(x => matchVectors(x, foundMine));
                    _mines.Remove(mine);
                    _mines.AddRange(createMines(1));

                    _genomePopulation.Genomes[i].Fitness++;
                }
            }
        }

        public void NextGeneration()
        {
            _genomePopulation = _geneticAlgorithm.NextGeneration(_genomePopulation);

            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = _genomePopulation.Genomes[i];
                _sweepers[i].Brain.Genome.Fitness = 0.0;
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                _sweepers[i].Initiliaze(position, rotation);
            }
            _mines = createMines(_mines.Count).ToList();
        }

        private IEnumerable<List<double>> createMines(int numberOfMines)
        {
            for (int i = 0; i < numberOfMines; i++)
            {
                var mine = getRandomPosition();
                yield return mine;
            }
        }

        private void initializeBrains()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = _genomePopulation.Genomes[i];
            }
        }

        private IEnumerable<Sweeper> createSweepers(int numberOfSweepers)
        {
            for (int i = 0; i < numberOfSweepers; i++)
            {
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                yield return new Sweeper(position, rotation);
            }
        }

        private bool matchVectors(List<double> vector, List<double> vectorToMatch)
        {
            if (vector.Count == vectorToMatch.Count)
            {
                for (int i = 0; i < vector.Count; i++)
                {
                    if (vector[i] != vectorToMatch[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private double getRandomRotation()
        {
            var rotation = _rand.NextDouble() * Math.PI * 2;
            return rotation;
        }

        private List<double> getRandomPosition()
        {
            var position = new List<double> { _rand.NextDouble(0, 560), _rand.NextDouble(0, 460) };
            //var position = new List<double> { _rand.NextDouble(0, _mainForm.DrawWidth), _rand.NextDouble(0, _mainForm.DrawHeight) };
            return position;
        }

    }
}
