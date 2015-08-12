namespace MineSweeper.UI.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;
    using MineSweeper.Application.Specs;
    using NeuralNet.Genetics;

    public class Graph : PictureBox
    {
        private Color _worstColor;
        private Color _bestColor;
        private Color _neutralColor;

        public void Reset(MineSweeperSettings settings)
        {
            Width = settings.DrawWidth;
            Image = new Bitmap(Width, Height);
            _worstColor = settings.WorstColor;
            _bestColor = settings.BestColor;
            _neutralColor = settings.NeutralColor;
        }

        public void Update(Population population)
        {
            Image = new Bitmap(Width, Height);
            var avgpoints = getGraphPoints(population.FitnessStats.PreviousGenerationsAverage);
            var bestpoints = getGraphPoints(population.FitnessStats.PreviousGenerationsBest);
            var worstpoints = getGraphPoints(population.FitnessStats.PreviousGenerationsWorst);

            var graphHeight = (float)Height - 10;
            var maxHeight = bestpoints.Max(x => x.Y);
            var graphWidth = (float)(Width - 10);
            var maxWidth = bestpoints.Count();
            var yScale = graphHeight / maxHeight;
            var xScale = graphWidth / maxWidth;

            using (var graphics = Graphics.FromImage(Image))
            {
                if (avgpoints.Count() > 1)
                {
                    drawGrid(graphics, population.FitnessStats.PreviousGenerationsBest.Max(), avgpoints, yScale, xScale);

                    using (var neutralPen = new Pen(_neutralColor))
                    {
                        drawGraphLine(graphics, avgpoints, neutralPen, yScale, xScale);
                    }
                    using (var bestPen = new Pen(_bestColor))
                    {
                        drawGraphLine(graphics, bestpoints, bestPen, yScale, xScale);
                    }
                    using (var worstPen = new Pen(_worstColor))
                    {
                        drawGraphLine(graphics, worstpoints, worstPen, yScale, xScale);
                    }
                }
            }
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        private void drawGrid(Graphics graphics, double maxValue, PointF[] avgpoints, float yScale, float xScale)
        {
            using (var gridPen = new Pen(Color.LightGray))
            {
                for (int i = 10; i < maxValue; i += 10)
                {
                    var gridLine = new PointF[2];
                    gridLine[0] = new PointF(0, i);
                    gridLine[1] = new PointF(avgpoints.Count() - 1, i);
                    drawGraphLine(graphics, gridLine, gridPen, yScale, xScale);
                }
                for (int i = 50; i < avgpoints.Count(); i += 50)
                {
                    var gridLine = new PointF[2];
                    gridLine[0] = new PointF(i, 0);
                    gridLine[1] = new PointF(i, (int)maxValue);
                    drawGraphLine(graphics, gridLine, gridPen, yScale, xScale);
                }
            }
        }

        private PointF[] getGraphPoints(List<double> fitnesses)
        {
            var generations = fitnesses.Count;
            var points = new PointF[generations + 1];

            points[0] = new PointF(0, 0);
            for (int i = 0; i < generations; i++)
            {
                var x = i + 1;
                var y = (float)fitnesses[i];
                points[i + 1] = new PointF(x, y);
            }

            return points;
        }

        private void drawGraphLine(Graphics graphics, PointF[] points, Pen pen, float yScale, float xScale)
        {
            var matrix = new Matrix();
            matrix.Scale(xScale, yScale);
            matrix.Translate(5, 5, MatrixOrder.Append);
            matrix.TransformPoints(points);

            graphics.DrawLines(pen, points);
        }
    }
}