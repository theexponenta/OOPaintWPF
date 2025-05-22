using System.Windows;
using System.Windows.Media;
using Shared;


namespace Plugins.Trapezoid
{
    public class Trapezoid : Shape
    {
        private static int basesRatio = 3;

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Trapezoid(Color strokeColor, Color fillColor, int lineWidth, Point topLeft, Point bottomRight)
            : base(strokeColor, fillColor, lineWidth)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public override void Draw(DrawingContext context)
        {
            double upperBaseHalfLength = (BottomRight.X - TopLeft.X) / (basesRatio * 2);
            double centerX = (BottomRight.X + TopLeft.X) / 2;

            Point[] points =
            {
                new Point(TopLeft.X, BottomRight.Y),
                new Point(centerX - upperBaseHalfLength, TopLeft.Y),
                new Point(centerX + upperBaseHalfLength, TopLeft.Y),
                BottomRight
            };

            Pen pen = new Pen(new SolidColorBrush(this.StrokeColor), this.LineWidth);
            Brush brush = new SolidColorBrush(this.FillColor);

            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(points[0], true, true);
                ctx.PolyLineTo(points, true, true);
            }

            context.DrawGeometry(brush, pen, geometry);
        }
    }
}
