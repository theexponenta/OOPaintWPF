using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Polyline: Shape
    {
        public List<Point> Points { get; }

        public Polyline(Color color, int lineWidth) : base(color, Colors.Transparent, lineWidth)
        {
            this.Points = new List<Point>();
        }

        public override void Draw(DrawingContext context)
        {
            Pen pen = new Pen(new SolidColorBrush(this.strokeColor), this.lineWidth);
            Brush brush = new SolidColorBrush(Colors.Transparent);
            
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(Points[0], false, false);
                ctx.PolyLineTo(Points, true, true);
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
