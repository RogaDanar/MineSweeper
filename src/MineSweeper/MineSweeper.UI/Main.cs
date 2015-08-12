namespace MineSweeper.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using MineSweeper.Application.Creatures;
    using MineSweeper.Application.Specs;
    using MineSweeper.Application.Utils;
    using NeuralNet.Genetics;

    public partial class Main : Form
    {
        public event EventHandler<MineSweeperSettings> SettingsChanged = delegate { };

        public PictureBox MainPictureBox { get { return pgMain; } }
        public Button ResetButton { get { return btnReset; } }
        public Button StartButton { get { return btnStartStop; } }
        public Button FastButton { get { return btnFast; } }

        public MineSweeperSettings Settings { get; private set; }

        public Main(MineSweeperSettings settings)
        {
            InitializeComponent();
            Icon = Shapes.TankIcon();

            DoubleBuffered = true;

            Settings = settings;

            UpdateDisplaySettings(Settings);
            pgMain.Reset(Settings);
            graphPopulation.Reset(Settings);
            statsGeneration.Reset(Settings);
        }

        public void UpdateStats(Population population)
        {
            statsGeneration.Update(population);
        }

        public void UpdateGraph(Population population)
        {
            graphPopulation.Update(population);
        }

        public void UpdateDisplay(IList<ICreature> creatures, IList<Tuple<ObjectType, IList<double>>> objects)
        {
            pgMain.Update(creatures, objects, Settings);
        }

        public void UpdateDisplaySettings(MineSweeperSettings settings)
        {
            Settings = settings;
            pnlSettings.DisplayCurrentSettings(Settings);
        }

        private void btnResetClick(object sender, EventArgs e)
        {
            Settings = pnlSettings.GetNewSettings(Settings);
            pgMain.Reset(Settings);
            graphPopulation.Reset(Settings);
            statsGeneration.Reset(Settings);

            btnStartStop.Text = "Start";

            SettingsChanged.Raise<MineSweeperSettings>(this, Settings);
        }

        private void btnFastClick(object sender, EventArgs e)
        {
            btnFast.Text = btnFast.Text.Equals("Fast") ? "Slow" : "Fast";
        }

        private void btnStartStopClick(object sender, System.EventArgs e)
        {
            if (btnStartStop.Text.Equals("Start"))
            {
                btnStartStop.Text = "Stop";
                pnlSettings.DisableSpec();
            }
            else
            {
                btnStartStop.Text = "Start";
                pnlSettings.EnableSpec();
            }
        }
    }
}