using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Line : Shape
    {
        Point point1;
        Point point2;

        public Line(Color color, int lineWidth, Point point1, Point point2) : base(color, Colors.Transparent, lineWidth)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public override void Draw(DrawingContext context)
        {
            Brush brush = new SolidColorBrush(this.strokeColor);
            Pen pen = new Pen(brush, this.lineWidth);
            context.DrawLine(pen, point1, point2);
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
