namespace MineSweeper
{
    using NeuralNet.Genetics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public event EventHandler<Settings> SettingsChanged;

        protected virtual void OnSettingsChanged()
        {
            if (SettingsChanged != null)
            {
                SettingsChanged(this, Settings);
            }
        }

        public PictureBox MainPictureBox { get { return pbMain; } }
        public Button ResetButton { get { return btnReset; } }
        public Button StartButton { get { return btnStartStop; } }
        public Button FastButton { get { return btnFast; } }

        public Settings Settings { get; private set; }

        public Main(Settings settings)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Settings = settings;

            setupDisplay();
            displayCurrentSettings();
        }

        private void setupDisplay()
        {
            pbMain.Width = Settings.DrawWidth;
            pbMain.Height = Settings.DrawHeight;
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);

            pbGraph.Width = Settings.DrawWidth;
            pbGraph.Image = new Bitmap(pbGraph.Width, pbGraph.Height);
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
            pbGraph.Image = new Bitmap(pbGraph.Width, pbGraph.Height);
            using (var graphics = Graphics.FromImage(pbGraph.Image))
            {
                var avgpoints = getGraphPoints(population.PreviousGenerationAverageFitness);
                var bestpoints = getGraphPoints(population.PreviousGenerationBestFitness);
                var worstpoints = getGraphPoints(population.PreviousGenerationWorstFitness);

                var graphHeight = (float)pbGraph.Height;
                var maxHeight = bestpoints.Max(x => x.Y) + 1;
                var yScale = graphHeight / maxHeight;
                var xScale = (float)pbGraph.Width / (float)bestpoints.Count();

                if (avgpoints.Count() > 1)
                {
                    var matrix = new Matrix();
                    matrix.Scale(xScale, yScale);
                    matrix.TransformPoints(avgpoints);

                    var blackPen = new Pen(Color.Black);
                    graphics.DrawLines(blackPen, avgpoints);
                    blackPen.Dispose();
                }

                if (bestpoints.Count() > 1)
                {
                    var matrix = new Matrix();
                    matrix.Scale(xScale, yScale);
                    matrix.TransformPoints(bestpoints);

                    var bluePen = new Pen(Color.Blue);
                    graphics.DrawLines(bluePen, bestpoints);
                    bluePen.Dispose();
                }

                if (worstpoints.Count() > 1)
                {
                    var matrix = new Matrix();
                    matrix.Scale(xScale, yScale);
                    matrix.TransformPoints(worstpoints);

                    var redPen = new Pen(Color.Red);
                    graphics.DrawLines(redPen, worstpoints);
                    redPen.Dispose();
                }
            }
            pbGraph.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        private PointF[] getGraphPoints(List<double> fitnesses)
        {
            var generations = fitnesses.Count;
            var points = new PointF[generations + 1];

            points[0] = new PointF(0, 0);
            for (int i = 0; i < generations; i++)
            {
                var x = i;
                var y = (float)fitnesses[i];
                points[i + 1] = new PointF(x, y);
            }

            return points;
        }

        public void UpdateDisplay(List<Sweeper> sweepers, List<List<double>> mines)
        {
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
            using (var graphics = Graphics.FromImage(pbMain.Image))
            {
                var redPen = new Pen(Color.Red);
                var greenPen = new Pen(Color.Green);
                var blackPen = new Pen(Color.Black);

                foreach (var sweeper in sweepers.OrderByDescending(x => x.Fitness).Take(3))
                {
                    drawSweeper(graphics, redPen, sweeper);
                }

                foreach (var sweeper in sweepers.OrderByDescending(x => x.Fitness).Skip(3))
                {
                    drawSweeper(graphics, blackPen, sweeper);
                }

                foreach (var mine in mines)
                {
                    drawMine(graphics, greenPen, mine);
                }
                redPen.Dispose();
                greenPen.Dispose();
                blackPen.Dispose();
            }
        }

        private void drawMine(Graphics graphics, Pen pen, List<double> mine)
        {
            var mineX = (int)mine[0];
            var mineY = (int)mine[1];

            var points = getMinePolygonPoints(mineX, mineY);

            graphics.DrawPolygon(pen, points);

            //graphics.FillRectangle(pen.Brush, mineX, mineY, 1, 1);
        }

        private Point[] getMinePolygonPoints(int mineX, int mineY)
        {
            var points = new Point[4] { 
                new Point(-1,-1),
                new Point(-1,+1),
                new Point(+1,+1),
                new Point(+1,-1)
            };

            var matrix = new Matrix();
            matrix.Translate(mineX, mineY);
            matrix.Scale(Settings.MineSize, Settings.MineSize);
            matrix.TransformPoints(points);
            return points;
        }

        private void drawSweeper(Graphics graphics, Pen pen, Sweeper sweeper)
        {
            var sweeperX = (int)(sweeper.Position[0]);
            var sweeperY = (int)(sweeper.Position[1]);

            var rotDegrees = (float)((sweeper.Rotation / (Math.PI * 2)) * 360.0);

            var points = getSweeperPolygonPoints(sweeperX, sweeperY, rotDegrees);

            graphics.DrawPolygon(pen, points.Take(4).ToArray());
            graphics.DrawPolygon(pen, points.Skip(4).Take(4).ToArray());
            graphics.DrawPolygon(pen, points.Skip(8).Take(2).ToArray());
            graphics.DrawPolygon(pen, points.Skip(10).Take(6).ToArray());

            //graphics.FillRectangle(pen.Brush, sweeperX, sweeperY, 1, 1);
        }

        private PointF[] getSweeperPolygonPoints(int sweeperX, int sweeperY, float rotDegrees)
        {
            var points = new PointF[16] { 
                new PointF(-1, -1),
                new PointF(-1, +1),
                new PointF(-0.5f, +1),
                new PointF(-0.5f, -1),

                new PointF(+0.5f, -1),
                new PointF(+1, -1),
                new PointF(+1, +1),
                new PointF(+0.5f, +1),

                new PointF(-0.5f, -0.5f),
                new PointF(+0.5f, -0.5f),

                new PointF(-0.5f, +0.5f),
                new PointF(-0.25f, +0.5f),
                new PointF(-0.25f, +1.75f),
                new PointF(+0.25f, +1.75f),
                new PointF(+0.25f, +0.5f),
                new PointF(+0.5f, +0.5f)
            };

            var matrix = new Matrix();
            matrix.Rotate(rotDegrees, MatrixOrder.Append);
            matrix.Translate(sweeperX, sweeperY, MatrixOrder.Append);
            matrix.Scale(Settings.SweeperSize, Settings.SweeperSize);
            matrix.TransformPoints(points);
            return points;
        }

        private void btnStartStopClick(object sender, System.EventArgs e)
        {
            btnStartStop.Text = btnStartStop.Text.Equals("Start") ? "Stop" : "Start";
        }

        private void btnResetClick(object sender, EventArgs e)
        {
            Settings.SweeperCount = getIntValue(tbSweepers, Settings.SweeperCount);
            Settings.MineCount = getIntValue(tbMine, Settings.MineCount);
            Settings.MutationRate = getDoubleValue(tbMutation, Settings.MutationRate);
            Settings.CrossoverRate = getDoubleValue(tbCrossover, Settings.CrossoverRate);
            Settings.MaxPerturbation = getDoubleValue(tbPerturb, Settings.MaxPerturbation);
            Settings.Ticks = getIntValue(tbTicks, Settings.Ticks);

            Settings.DrawWidth = getIntValue(tbWidth, Settings.DrawWidth);
            Settings.DrawHeight = getIntValue(tbHeight, Settings.DrawHeight);

            btnStartStop.Text = "Start";
            setupDisplay();
            OnSettingsChanged();
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
    }
}
