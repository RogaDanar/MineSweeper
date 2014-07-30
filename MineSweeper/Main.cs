namespace MineSweeper
{
    using MineSweeper.Creatures;
    using MineSweeper.Utils;
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public event EventHandler<MineSweeperSettings> SettingsChanged = delegate { };

        public PictureBox MainPictureBox { get { return pbMain; } }
        public Button ResetButton { get { return btnReset; } }
        public Button StartButton { get { return btnStartStop; } }
        public Button FastButton { get { return btnFast; } }

        public MineSweeperSettings Settings { get; private set; }

        public Main(MineSweeperSettings settings)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Settings = settings;

            setupDisplay();
            displayCurrentSettings();
        }

        public void UpdateStats(Population population)
        {
            lblGenValue.Text = population.Generation.ToString();
            lblBestValue.Text = population.BestFitness.ToString();
            lblWorstValue.Text = population.WorstFitness.ToString();
            lblAvgValue.Text = Math.Round(population.AverageFitness, 2).ToString("0.00");

            lblLastBest.Text = string.Format("({0})", population.PreviousGenerationBestFitness.LastOrDefault());
            lblLastWorst.Text = string.Format("({0})", population.PreviousGenerationWorstFitness.LastOrDefault());
            lblLastAvg.Text = string.Format("({0:0.00})", Math.Round(population.PreviousGenerationAverageFitness.LastOrDefault(), 2));
        }

        public void UpdateGraph(Population population)
        {
            graphPopulation.Update(population);
        }

        public void UpdateDisplay(List<ICreature> creatures, List<Tuple<ObjectType, List<double>>> objects)
        {
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
            using (var graphics = Graphics.FromImage(pbMain.Image))
            {
                var bluePen = new Pen(Color.Blue);
                var greenPen = new Pen(Color.DarkGreen);
                var grayPen = new Pen(Color.DarkGray);
                var blackPen = new Pen(Color.Black);
                var redPen = new Pen(Color.Maroon);

                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Take(Settings.EliteCount))
                {
                    drawSweeper(graphics, blackPen, bluePen.Brush, sweeper);
                }

                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Skip(Settings.EliteCount))
                {
                    drawSweeper(graphics, blackPen, greenPen.Brush, sweeper);
                }


                var mines = objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2);
                foreach (var mine in mines)
                {
                    drawMine(graphics, blackPen, grayPen.Brush, mine);
                }

                var holes = objects.Where(x => x.Item1 == ObjectType.Hole).Select(x => x.Item2);
                foreach (var hole in holes)
                {
                    drawMine(graphics, redPen, redPen.Brush, hole);
                }

                bluePen.Dispose();
                greenPen.Dispose();
                grayPen.Dispose();
                blackPen.Dispose();
                redPen.Dispose();
            }
        }

        private void drawMine(Graphics graphics, Pen pen, Brush brush, List<double> mine)
        {
            var mineX = (int)mine[0];
            var mineY = (int)mine[1];

            var points = Shapes.MinePolygonPoints(mineX, mineY, Settings.MineSize);

            //graphics.DrawPolygon(pen, points);
            //graphics.FillPolygon(brush, points);
            graphics.DrawEllipse(pen, points[0].X, points[0].Y, 2 * Settings.MineSize, 2 * Settings.MineSize);
            graphics.FillEllipse(brush, points[0].X, points[0].Y, 2 * Settings.MineSize, 2 * Settings.MineSize);
        }

        private void drawSweeper(Graphics graphics, Pen pen, Brush brush, ICreature creature)
        {
            var sweeperX = (int)(creature.Motion.Position[0]);
            var sweeperY = (int)(creature.Motion.Position[1]);

            var rotDegrees = (float)((creature.Motion.Rotation / (Math.PI * 2)) * 360.0);

            var points = Shapes.TankPolygonPoints(sweeperX, sweeperY, rotDegrees, Settings.SweeperSize);

            // Left track
            graphics.DrawPolygon(pen, points.Take(4).ToArray());
            graphics.FillPolygon(brush, points.Take(4).ToArray());

            //Right track
            graphics.DrawPolygon(pen, points.Skip(4).Take(4).ToArray());
            graphics.FillPolygon(brush, points.Skip(4).Take(4).ToArray());

            // Turret
            graphics.DrawPolygon(pen, points.Skip(8).Take(8).ToArray());
            graphics.FillPolygon(brush, points.Skip(8).Take(8).ToArray());
        }

        private void setupDisplay()
        {
            pbMain.Width = Settings.DrawWidth;
            pbMain.Height = Settings.DrawHeight;
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);

            graphPopulation.Width = Settings.DrawWidth;
            graphPopulation.Image = new Bitmap(graphPopulation.Width, graphPopulation.Height);
            Icon = Shapes.TankIcon();
        }

        private void displayCurrentSettings()
        {
            tbWidth.Text = Settings.DrawWidth.ToString();
            tbHeight.Text = Settings.DrawHeight.ToString();
            tbMutation.Text = Settings.MutationRate.ToString();
            tbCrossover.Text = Settings.CrossoverRate.ToString();
            tbPerturb.Text = Settings.MaxPerturbation.ToString();
            tbTicks.Text = Settings.Ticks.ToString();
            tbMine.Text = Settings.MineCount.ToString();
            tbSweepers.Text = Settings.SweeperCount.ToString();
            tbElites.Text = Settings.EliteCount.ToString();
            tbHiddenLayer.Text = Settings.HiddenLayers.ToString();
            tbHiddenNeuron.Text = Settings.HiddenLayerNeurons.ToString();
        }

        private void btnResetClick(object sender, EventArgs e)
        {
            Settings.SweeperCount = getIntValue(tbSweepers, Settings.SweeperCount);
            Settings.MineCount = getIntValue(tbMine, Settings.MineCount);
            Settings.MutationRate = getDoubleValue(tbMutation, Settings.MutationRate);
            Settings.CrossoverRate = getDoubleValue(tbCrossover, Settings.CrossoverRate);
            Settings.MaxPerturbation = getDoubleValue(tbPerturb, Settings.MaxPerturbation);
            Settings.Ticks = getIntValue(tbTicks, Settings.Ticks);
            Settings.EliteCount = getIntValue(tbElites, Settings.EliteCount);

            Settings.HiddenLayers = getIntValue(tbHiddenLayer, Settings.HiddenLayers);
            Settings.HiddenLayerNeurons = getIntValue(tbHiddenNeuron, Settings.HiddenLayerNeurons);

            Settings.DrawWidth = getIntValue(tbWidth, Settings.DrawWidth);
            Settings.DrawHeight = getIntValue(tbHeight, Settings.DrawHeight);

            btnStartStop.Text = "Start";
            setupDisplay();
            SettingsChanged.RaiseEvent<MineSweeperSettings>(this, Settings);
        }

        private int getIntValue(TextBox textBox, int originalValue)
        {
            var value = originalValue;
            int.TryParse(textBox.Text, out value);
            return value;
        }

        private double getDoubleValue(TextBox textBox, double originalValue)
        {
            var value = originalValue;
            double.TryParse(textBox.Text, out value);
            return value;
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
