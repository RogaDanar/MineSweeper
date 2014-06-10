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
        private Controller _controller;

        public int DrawWidth { get; set; }

        public int DrawHeight { get; set; }

        public Main()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            DoubleBuffered = true;

            setupDisplay();
        }

        public Main(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            DoubleBuffered = true;

            setupDisplay();
        }

        private void setupDisplay()
        {
            DrawWidth = pbMain.Width;
            DrawHeight = pbMain.Height;
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
        }

        internal void SetStats(Population population)
        {
            lblGeneration.Invalidate();
            lblGeneration.Text = string.Format("Generation: {0}    Best Fitness: {1}    Average Fitness: {2}",
                population.Generation,
                population.BestFitness,
                population.AverageFitness);
        }

        public void Tick(List<Sweeper> _sweepers, List<List<double>> _mines)
        {
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);
            using (var graphics = Graphics.FromImage(pbMain.Image))
            {
                var redPen = new Pen(Color.Red);
                var greenPen = new Pen(Color.Green);
                var blackPen = new Pen(Color.Black);

                var first = true;
                foreach (var sweeper in _sweepers.OrderByDescending(x => x.Brain.Genome.Fitness))
                {
                    if (first)
                    {
                        first = false;
                        drawSweeper(graphics, redPen, sweeper);
                    } else
                    {
                        drawSweeper(graphics, blackPen, sweeper);
                    }
                }

                foreach (var mine in _mines)
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

            var points = new Point[4] { 
                new Point(mineX-1,mineY-1),
                new Point(mineX-1,mineY+1),
                new Point(mineX+1,mineY+1),
                new Point(mineX+1,mineY-1)
            };

            graphics.DrawPolygon(pen, points);
        }

        private void drawSweeper(Graphics graphics, Pen pen, Sweeper sweeper)
        {
            var sweeperX = (int)(sweeper.Position[0]);
            var sweeperY = (int)(sweeper.Position[1]);

            var rotDegrees = (float)((sweeper.Rotation / (Math.PI * 2)) * 360.0);

            if (sweeperX > DrawWidth) sweeperX -= DrawWidth;
            if (sweeperX < 0) sweeperX += DrawWidth;
            if (sweeperY > DrawHeight) sweeperY -= DrawHeight;
            if (sweeperY < 0) sweeperY += DrawHeight;

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
            matrix.Scale(5, 5);
            matrix.TransformPoints(points);
            graphics.DrawPolygon(pen, points.Take(4).ToArray());
            graphics.DrawPolygon(pen, points.Skip(4).Take(4).ToArray());
            graphics.DrawPolygon(pen, points.Skip(8).Take(2).ToArray());
            graphics.DrawPolygon(pen, points.Skip(10).Take(6).ToArray());
        }

        private void MainLoad(object sender, System.EventArgs e)
        {
        }

        private void btnStartClick(object sender, System.EventArgs e)
        {
            //var workerThread = new Thread(() => _controller.StartSimulation(2000));
            //workerThread.Start();
        }
    }
}
