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

        private const double _mineSize = 2;
        private const double _sweeperSize = 5;
        private const double _mutationRate = 0.1;
        private const double _crossoverRate = 0.7;
        private const double _perturbationRate = 0.3;

        private Main _mainForm;
        private bool _formReady;
        private bool _done;
        private bool _runSimulation;
        private bool _fast;
        private bool _reset;
        private double _drawWidth;
        private double _drawHeight;

        private int _sweeperCount;
        private int _mineCount;
        private List<Sweeper> _sweepers;
        private List<List<double>> _mines;
        private int _sweeperWeightCount;
        private GeneticAlgorithm _genetics;
        private Population _population;
        private int _ticks;
        private int _ticksDone;

        public Controller()
        {
            _done = false;
            _runSimulation = false;
            _mineCount = 40;
            _sweeperCount = 30;

            _mainForm = new Main(this, _mineSize, _sweeperSize);
            _drawWidth = _mainForm.MainPictureBox.Width;
            _drawHeight = _mainForm.MainPictureBox.Height;
            _mainForm.Shown += mainFormShown;
            _mainForm.FormClosing += mainFormClosing;
            _mainForm.FormClosed += mainFormClosed;
            _mainForm.ResetButton.Click += mainFormResetButtonClick;
            _mainForm.StartButton.Click += mainFormStartButtonClick;
            _mainForm.FastButton.Click += mainFormFastButtonClick;

            var uiThread = new Thread(() => {
                Application.Run(_mainForm);
            });
            uiThread.Start();

            StartSimulation();
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _fast = !_fast;
        }

        private void mainFormStartButtonClick(object sender, EventArgs e)
        {
            _runSimulation = !_runSimulation;
            if (_runSimulation && _reset)
            {
                Setup(_sweeperCount, _mineCount);
                _reset = false;
            }
        }

        private void mainFormResetButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var main = button.Parent as Main;
                if (main != null)
                {
                    _sweeperCount = main.SweeperCount;
                    _mineCount = main.MineCount;
                }
            }
            _runSimulation = false;
            _reset = true;
        }

        private void mainFormClosed(object sender, FormClosedEventArgs e)
        {
            _done = true;
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            _runSimulation = false;
            _formReady = false;
        }

        private void mainFormShown(object sender, EventArgs e)
        {
            _formReady = true;
            if (_mainForm != null)
            {
                _mainForm.Invoke((MethodInvoker)delegate { _mineCount = _mainForm.MineCount; });
                _mainForm.Invoke((MethodInvoker)delegate { _sweeperCount = _mainForm.SweeperCount; });
            }
            _genetics = new GeneticAlgorithm(_mutationRate, _crossoverRate, _perturbationRate);
            Setup(_sweeperCount, _mineCount);
        }

        public void Setup(int numberOfSweepers, int numberOfMines)
        {
            _sweepers = createSweepers(numberOfSweepers).ToList();
            _mines = createMines(numberOfMines).ToList();
            _sweeperWeightCount = _sweepers.First().Brain.AllWeightsCount();
            _population = new Population(numberOfSweepers, _sweeperWeightCount);
            initializeBrains();
        }

        public void StartSimulation(int ticks = 2000)
        {
            _ticks = ticks;
            _ticksDone = 0;
            while (!_done)
            {
                if (_runSimulation)
                {
                    Update();
                    updateUI();
                }
            }
        }

        private void updateUI()
        {
            if (_formReady && _runSimulation)
            {
                try
                {
                    if (_ticksDone == 0)
                    {
                        _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateGraph(_population); });
                    }

                    if (!_fast)
                    {
                        _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateDisplay(_sweepers, _mines); });
                    }
                    _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateStats(_population); });
                }
                catch (ObjectDisposedException) { }
            }
        }

        public void Update()
        {
            if (_ticksDone < _ticks)
            {
                for (int i = 0; i < _sweepers.Count; i++)
                {
                    var sweeper = _sweepers[i];
                    sweeper.Update(_mines);
                    var foundMine = sweeper.CheckForMine(_mineSize + _sweeperSize);
                    if (foundMine != null)
                    {
                        var mine = _mines.Single(x => matchVectors(x, foundMine));
                        _mines.Remove(mine);
                        _mines.AddRange(createMines(1));
                        sweeper.Fitness++;
                    }
                }
                _population.UpdateStats();
                _ticksDone++;
            }
            else
            {
                NextGeneration();
                _ticksDone = 0;
            }
        }

        public void NextGeneration()
        {
            _population = _genetics.NextGeneration(_population);

            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = _population.Genomes[i];
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                _sweepers[i].Initialize(position, rotation);
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
                _sweepers[i].Brain.Genome = _population.Genomes[i];
            }
        }

        private IEnumerable<Sweeper> createSweepers(int numberOfSweepers)
        {
            for (int i = 0; i < numberOfSweepers; i++)
            {
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                yield return new Sweeper(position, rotation, 400, 400);
            }
        }

        private bool matchVectors(List<double> vector, List<double> vectorToMatch)
        {

            if (vector.Count == vectorToMatch.Count)
            {
                for (int i = 0; i < vector.Count; i++)
                {
                    if (!vector[i].Equals(vectorToMatch[i]))
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
            var position = new List<double> { _rand.NextDouble(0, _drawWidth), _rand.NextDouble(0, _drawHeight) };
            return position;
        }

    }
}
