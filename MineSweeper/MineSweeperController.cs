namespace MineSweeper
{
    using MineSweeper.Creatures;
    using MineSweeper.Specs;
    using NeuralNet.AppHelpers;
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public class MineSweeperController
    {
        private Main _mainForm;
        private Runner _runner;
        private IMineSweeperSpec _spec;
        private MineSweeperSettings _settings;
        private bool _setupNeeded;

        public MineSweeperController(MineSweeperSettings settings)
        {
            _settings = settings;
            _setupNeeded = true;

            _spec = getSpec();
            _runner = new Runner(_spec);

            initializeMainForm();
        }

        private IMineSweeperSpec getSpec()
        {
            var spec = default(IMineSweeperSpec);
            switch (_settings.SweeperType)
            {
                case SweeperType.Sweeper:
                    spec = new MineSweeperSpec(_settings);
                    break;
                case SweeperType.SweeperDodger:
                    spec = new MineSweeperDodgerSpec(_settings);
                    break;
                default:
                    throw new Exception("Unknown SweeperType");
            }

            spec.NextGenerationEnded += specNextGeneration;
            spec.TickEnded += specTickEnded;
            return spec;
        }

        private void initializeMainForm()
        {
            _mainForm = new Main(_settings);
            _mainForm.FormClosing += mainFormClosing;
            _mainForm.FormClosed += mainFormClosed;
            _mainForm.SettingsChanged += mainFormSettingsChanged;
            _mainForm.StartButton.Click += mainFormStartButtonClick;
            _mainForm.FastButton.Click += mainFormFastButtonClick;

            var uiThread = new Thread(() => {
                Application.Run(_mainForm);
            });
            uiThread.Start();
        }

        public void Start()
        {
            _runner.Start();
        }

        private void specTickEnded(object sender, EventArgs e)
        {
            if (!_settings.Fast)
            {
                _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateDisplay(_spec.Creatures, _spec.Objects); });
            }
            _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateStats(_spec.Population); });
        }

        private void specNextGeneration(object sender, EventArgs e)
        {
            _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateGraph(_spec.Population); });
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _settings.Fast = !_settings.Fast;
        }

        private void mainFormStartButtonClick(object sender, EventArgs e)
        {
            if (!_runner.IsRunning)
            {
                if (_setupNeeded)
                {
                    _runner.Setup();
                    _setupNeeded = false;
                }
                _runner.StartRun();
            }
            else
            {
                _runner.StopRun();
            }
        }

        private void mainFormSettingsChanged(object sender, MineSweeperSettings settings)
        {
            _settings = settings;

            _runner.StopRun();

            _setupNeeded = true;
        }

        private void mainFormClosed(object sender, FormClosedEventArgs e)
        {
            _runner.Shutdown();
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            _runner.StopRun();
        }
    }
}
