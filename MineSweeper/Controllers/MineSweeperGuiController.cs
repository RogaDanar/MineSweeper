namespace MineSweeper.Controllers
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using MineSweeper.Specs;
    using NeuralNet.AppHelpers;

    public class MineSweeperGuiController
    {
        private Main _mainForm;
        private Runner _runner;
        private IMineSweeperSpec _spec;
        private MineSweeperSettings _settings;
        private bool _setupNeeded;

        public MineSweeperGuiController(IMineSweeperSpec spec)
        {
            setupSpec(spec);

            _runner = new Runner(_spec);

            initializeMainForm();
        }

        private void setupSpec(IMineSweeperSpec spec)
        {
            _setupNeeded = true;

            _spec = spec;
            _settings = _spec.Settings;
            _spec.NextGenerationEnded += specNextGeneration;
            _spec.TickEnded += specTickEnded;
        }

        private void initializeMainForm()
        {
            _mainForm = new Main(_settings);
            _mainForm.FormClosing += mainFormClosing;
            _mainForm.FormClosed += mainFormClosed;
            _mainForm.SettingsChanged += mainFormSettingsChanged;
            _mainForm.StartButton.Click += mainFormStartButtonClick;
            _mainForm.FastButton.Click += mainFormFastButtonClick;
            _mainForm.pnlSettings.SpecChanged += mainFormSpecChanged;

            var uiThread = new Thread(() =>
            {
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
                setupRunner();
                _runner.EnableSimulation();
            }
            else
            {
                _runner.DisableSimulation();
            }
        }

        private void setupRunner()
        {
            if (_setupNeeded)
            {
                _runner.Setup();
                _setupNeeded = false;
            }
        }

        private void mainFormSettingsChanged(object sender, MineSweeperSettings settings)
        {
            _settings = settings;

            _runner.DisableSimulation();

            _setupNeeded = true;
        }

        private void mainFormSpecChanged(object sender, SpecEventArgs e)
        {
            _runner.DisableSimulation();

            _spec.NextGenerationEnded -= specNextGeneration;
            _spec.TickEnded -= specTickEnded;
            setupSpec(e.Spec);

            _runner.UpdateSpecification(_spec);

            _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateDisplaySettings(_settings); });
        }

        private void mainFormClosed(object sender, FormClosedEventArgs e)
        {
            _runner.ShutdownMainLoop();
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            _runner.DisableSimulation();
        }
    }
}