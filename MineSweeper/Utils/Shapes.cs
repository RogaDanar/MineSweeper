namespace MineSweeper.Utils
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public static class Shapes
    {
        /// <summary>
        /// Returned points 1-4 are the left track, points 5-8 are the right track, 9-16 are the turret
        /// They should be drawn individually
        /// </summary>
        public static PointF[] TankPolygonPoints(int offsetX, int offsetY, float rotDegrees, float size)
        {
            var points = new PointF[16] { 

                // Left track
                new PointF(-1, -1),
                new PointF(-1, 1),
                new PointF(-0.5f, 1),
                new PointF(-0.5f, -1),

                // Right track
                new PointF(0.5f, -1),
                new PointF(1, -1),
                new PointF(1, 1),
                new PointF(0.5f, 1),

                // Turret
                new PointF(-0.5f, -0.5f),
                new PointF(0.5f, -0.5f),
                new PointF(-0.5f, 0.5f),
                new PointF(-0.25f, 0.5f),
                new PointF(-0.25f, 1.75f),
                new PointF(0.25f, 1.75f),
                new PointF(0.25f, 0.5f),
                new PointF(0.5f, 0.5f)
            };

            var matrix = new Matrix();
            matrix.Rotate(rotDegrees, MatrixOrder.Append);
            matrix.Translate(offsetX, offsetY, MatrixOrder.Append);
            matrix.Scale(size, size);
            matrix.TransformPoints(points);
            return points;
        }

        public static Point[] MinePolygonPoints(int offsetX, int offsetY, float size)
        {
            var points = new Point[4] { 
                new Point(-1, -1),
                new Point(-1, 1),
                new Point(1, 1),
                new Point(1, -1)
            };

            var matrix = new Matrix();
            matrix.Translate(offsetX, offsetY);
            matrix.Scale(size, size);
            matrix.TransformPoints(points);
            return points;
        }

        public static Icon TankIcon()
        {
            var bitmap = new Bitmap(32, 32);
            using (var g = Graphics.FromImage(bitmap))
            {
                var points = TankPolygonPoints(16, 16, 180, 5);
                var matrix = new Matrix();
                matrix.Scale(1.5f, 1.5f);
                matrix.Translate(-5, -5);
                matrix.TransformPoints(points);

                var pen = new Pen(Color.Black);
                g.DrawPolygon(pen, points);
                g.FillPolygon(pen.Brush, points);
                pen.Dispose();
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }
    }
}
