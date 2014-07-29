namespace MineSweeper.Controls
{
    using NeuralNet.Genetics;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;

    public class Graph : PictureBox
    {
        public void Update(Population population)
        {
            Image = new Bitmap(Width, Height);
            var avgpoints = getGraphPoints(population.PreviousGenerationAverageFitness);
            var bestpoints = getGraphPoints(population.PreviousGenerationBestFitness);
            var worstpoints = getGraphPoints(population.PreviousGenerationWorstFitness);

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
                    var blackPen = new Pen(Color.Black);
                    drawGraphLine(graphics, avgpoints, blackPen, yScale, xScale);
                    blackPen.Dispose();
                }

                if (bestpoints.Count() > 1)
                {
                    var bluePen = new Pen(Color.Blue);
                    drawGraphLine(graphics, bestpoints, bluePen, yScale, xScale);
                    bluePen.Dispose();
                }

                if (worstpoints.Count() > 1)
                {
                    var redPen = new Pen(Color.Maroon);
                    drawGraphLine(graphics, worstpoints, redPen, yScale, xScale);
                    redPen.Dispose();
                }
            }
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
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
