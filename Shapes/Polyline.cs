using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Polyline: Shape
    {
        Point[] points;

        public Polyline(Color strokeColor, Color fillColor, int lineWidth, Point[] points) : base(strokeColor, fillColor, lineWidth)
        {
            this.points = points;
        }

        public override void Draw(DrawingContext context)
        {
            Pen pen = new Pen(new SolidColorBrush(this.strokeColor), this.lineWidth);
            Brush brush = new SolidColorBrush(Colors.Transparent);
            
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(points[0], true, true);
                ctx.PolyLineTo(points, true, true);
            }
            
            context.DrawGeometry(brush, pen, geometry);
        }

        public override byte[] Serialize()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
