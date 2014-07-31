namespace MineSweeper
{
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

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

            pgMain.Reset(Settings);
            graphPopulation.Reset(Settings);

            displayCurrentSettings();
        }

        public void UpdateStats(Population population)
        {
            statsGeneration.Update(population);
        }

        public void UpdateGraph(Population population)
        {
            graphPopulation.Update(population);
        }

        public void UpdateDisplay(List<ICreature> creatures, List<Tuple<ObjectType, List<double>>> objects)
        {
            pgMain.Update(creatures, objects, Settings);
        }

        private void displayCurrentSettings()
        {
            pnlSettings.DisplayCurrentSettings(Settings);
        }

        private void btnResetClick(object sender, EventArgs e)
        {
            Settings = pnlSettings.GetNewSettings(Settings);
            pgMain.Reset(Settings);
            graphPopulation.Reset(Settings);

            btnStartStop.Text = "Start";

            SettingsChanged.Raise<MineSweeperSettings>(this, Settings);
        }

        private void btnFastClick(object sender, EventArgs e)
        {
            btnFast.Text = btnFast.Text.Equals("Fast") ? "Slow" : "Fast";
        }

        private void btnStartStopClick(object sender, System.EventArgs e)
        {
            btnStartStop.Text = btnStartStop.Text.Equals("Start") ? "Stop" : "Start";
        }
    }
}
