namespace MineSweeper
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using MineSweeper.Creatures;
    using MineSweeper.Specs;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;

    public partial class Main : Form
    {
        public event EventHandler<MineSweeperSettings> SettingsChanged = delegate { };
        public event EventHandler<SpecEventArgs> SpecChanged = delegate { };

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
                cbSpec.Enabled = false;
            }
            else
            {
                btnStartStop.Text = "Start";
                cbSpec.Enabled = true;
            }
        }

        private void cbSpecSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbSpec.SelectedItem.ToString();
            var spec = default(IMineSweeperSpec);
            switch (selected)
            {
                case "Mine":
                    spec = new MineSweeperSpec();
                    break;
                case "EliteMine":
                    spec = new EliteMineSweeperSpec();
                    break;
                case "Dodger":
                    spec = new MineSweeperHoleDodgerSpec();
                    break;
                case "Cluster":
                    spec = new ClusterSweeperSpec();
                    break;
                default:
                    break;
            }
            var eventArgs = new SpecEventArgs(spec);
            SpecChanged.Raise<SpecEventArgs>(this, eventArgs);
        }
    }
}
