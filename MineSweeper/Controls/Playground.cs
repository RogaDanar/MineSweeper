namespace MineSweeper.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using MineSweeper.Creatures;
    using MineSweeper.Specs;
    using MineSweeper.Utils;

    public class Playground : PictureBox
    {
        private Color _worstColor;
        private Color _bestColor;
        private Color _neutralColor;

        public void Reset(MineSweeperSettings settings)
        {
            Width = settings.DrawWidth;
            Height = settings.DrawHeight;
            Image = new Bitmap(Width, Height);
            _worstColor = settings.WorstColor;
            _bestColor = settings.BestColor;
            _neutralColor = settings.NeutralColor;
        }

        public void Update(IList<ICreature> creatures, IList<Tuple<ObjectType, IList<double>>> objects, MineSweeperSettings settings)
        {
            Image = new Bitmap(Width, Height);
            using (var graphics = Graphics.FromImage(Image))
            {
                var eliteSweeperPen = new Pen(_bestColor);
                var sweeperPen = new Pen(_neutralColor);
                var minePen = new Pen(Color.DarkGray);
                var blackPen = new Pen(Color.Black);
                var redPen = new Pen(Color.Maroon);

                // Elite Sweepers
                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Take(settings.EliteCount))
                {
                    drawSweeper(graphics, eliteSweeperPen, eliteSweeperPen.Brush, sweeper, settings.SweeperSize);
                }

                // Normal Sweepers
                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Skip(settings.EliteCount))
                {
                    drawSweeper(graphics, sweeperPen, sweeperPen.Brush, sweeper, settings.SweeperSize);
                }

                // Mines
                var mines = objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2);
                foreach (var mine in mines)
                {
                    drawMine(graphics, redPen, minePen.Brush, mine, settings.MineSize);
                }

                // ClusterMines
                var clusterMines = objects.Where(x => x.Item1 == ObjectType.ClusterMine).Select(x => x.Item2);
                foreach (var mine in clusterMines)
                {
                    drawMine(graphics, blackPen, sweeperPen.Brush, mine, settings.MineSize + 1);
                }

                // Holes
                var holes = objects.Where(x => x.Item1 == ObjectType.Hole).Select(x => x.Item2);
                foreach (var hole in holes)
                {
                    drawMine(graphics, redPen, redPen.Brush, hole, settings.MineSize + 1);
                }

                eliteSweeperPen.Dispose();
                sweeperPen.Dispose();
                minePen.Dispose();
                blackPen.Dispose();
                redPen.Dispose();
            }
        }

        private void drawMine(Graphics graphics, Pen outlineColor, Brush fillColor, IList<double> mine, float mineSize)
        {
            var mineX = (int)mine[0];
            var mineY = (int)mine[1];

            var points = Shapes.MinePolygonPoints(mineX, mineY, mineSize);

            //graphics.DrawPolygon(pen, points);
            //graphics.FillPolygon(brush, points);
            graphics.DrawEllipse(outlineColor, points[0].X, points[0].Y, 2 * mineSize, 2 * mineSize);
            graphics.FillEllipse(fillColor, points[0].X, points[0].Y, 2 * mineSize, 2 * mineSize);
        }

        private void drawSweeper(Graphics graphics, Pen outlineColor, Brush fillColor, ICreature creature, float sweeperSize)
        {
            var sweeperX = (int)(creature.Motion.Position[0]);
            var sweeperY = (int)(creature.Motion.Position[1]);

            var rotDegrees = (float)((creature.Motion.Rotation / (Math.PI * 2)) * 360.0);

            var points = Shapes.TankPolygonPoints(sweeperX, sweeperY, rotDegrees, sweeperSize);

            // Left track
            graphics.DrawPolygon(outlineColor, points.Take(4).ToArray());
            graphics.FillPolygon(fillColor, points.Take(4).ToArray());

            //Right track
            graphics.DrawPolygon(outlineColor, points.Skip(4).Take(4).ToArray());
            graphics.FillPolygon(fillColor, points.Skip(4).Take(4).ToArray());

            // Turret
            graphics.DrawPolygon(outlineColor, points.Skip(8).Take(8).ToArray());
            graphics.FillPolygon(fillColor, points.Skip(8).Take(8).ToArray());
        }
    }
}