namespace MineSweeper.Controls
{
    using MineSweeper.Creatures;
    using MineSweeper.Specs;
    using MineSweeper.Utils;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class Playground : PictureBox
    {
        public void Reset(MineSweeperSettings settings)
        {
            Width = settings.DrawWidth;
            Height = settings.DrawHeight;
            Image = new Bitmap(Width, Height);
        }

        public void Update(IList<ICreature> creatures, IList<Tuple<ObjectType, IList<double>>> objects, MineSweeperSettings settings)
        {
            Image = new Bitmap(Width, Height);
            using (var graphics = Graphics.FromImage(Image))
            {
                var bluePen = new Pen(Color.Blue);
                var greenPen = new Pen(Color.DarkGreen);
                var grayPen = new Pen(Color.DarkGray);
                var blackPen = new Pen(Color.Black);
                var redPen = new Pen(Color.Maroon);

                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Take(settings.EliteCount))
                {
                    drawSweeper(graphics, blackPen, bluePen.Brush, sweeper, settings.SweeperSize);
                }

                foreach (var sweeper in creatures.OrderByDescending(x => x.Fitness).Skip(settings.EliteCount))
                {
                    drawSweeper(graphics, blackPen, greenPen.Brush, sweeper, settings.SweeperSize);
                }


                var clusterMines = objects.Where(x => x.Item1 == ObjectType.ClusterMine).Select(x => x.Item2);
                foreach (var mine in clusterMines)
                {
                    drawMine(graphics, blackPen, greenPen.Brush, mine, settings.MineSize + 1);
                }

                var mines = objects.Where(x => x.Item1 == ObjectType.Mine).Select(x => x.Item2);
                foreach (var mine in mines)
                {
                    drawMine(graphics, blackPen, grayPen.Brush, mine, settings.MineSize);
                }

                var holes = objects.Where(x => x.Item1 == ObjectType.Hole).Select(x => x.Item2);
                foreach (var hole in holes)
                {
                    drawMine(graphics, redPen, redPen.Brush, hole, settings.MineSize);
                }

                bluePen.Dispose();
                greenPen.Dispose();
                grayPen.Dispose();
                blackPen.Dispose();
                redPen.Dispose();
            }
        }

        private void drawMine(Graphics graphics, Pen pen, Brush brush, IList<double> mine, float mineSize)
        {
            var mineX = (int)mine[0];
            var mineY = (int)mine[1];

            var points = Shapes.MinePolygonPoints(mineX, mineY, mineSize);

            //graphics.DrawPolygon(pen, points);
            //graphics.FillPolygon(brush, points);
            graphics.DrawEllipse(pen, points[0].X, points[0].Y, 2 * mineSize, 2 * mineSize);
            graphics.FillEllipse(brush, points[0].X, points[0].Y, 2 * mineSize, 2 * mineSize);
        }

        private void drawSweeper(Graphics graphics, Pen pen, Brush brush, ICreature creature, float sweeperSize)
        {
            var sweeperX = (int)(creature.Motion.Position[0]);
            var sweeperY = (int)(creature.Motion.Position[1]);

            var rotDegrees = (float)((creature.Motion.Rotation / (Math.PI * 2)) * 360.0);

            var points = Shapes.TankPolygonPoints(sweeperX, sweeperY, rotDegrees, sweeperSize);

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

    }
}
