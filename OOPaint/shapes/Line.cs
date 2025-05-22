using System;
using System.Windows;
using System.Windows.Media;
using Shared;


using Brush = System.Windows.Media.Brush;
using Pen = System.Windows.Media.Pen;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

namespace OOPaint.Shapes
{
    public class Line : Shape
    {
        public Point Point1 { get; set; }
        public Point Point2  { get; set; }

        public Line(Color color, int lineWidth, Point point1, Point point2) : base(color, Colors.Transparent, lineWidth)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        public override void Draw(DrawingContext context)
        {
            Brush brush = new SolidColorBrush(this.StrokeColor);
            Pen pen = new Pen(brush, this.LineWidth);
            context.DrawLine(pen, Point1, Point2);
        }
        
    }
}
