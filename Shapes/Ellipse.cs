using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Ellipse : Shape
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Ellipse(Color strokeColor, Color fillColor, int lineWidth, Point topLeft, Point bottomRight)
            : base(strokeColor, fillColor, lineWidth)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public override void Draw(DrawingContext context)
        {
            Brush brush = new SolidColorBrush(this.FillColor);
            Pen pen = new Pen(new SolidColorBrush(this.StrokeColor), this.LineWidth);
            
            Point center = new Point((TopLeft.X + BottomRight.X) / 2, (TopLeft.Y + BottomRight.Y) / 2);
            context.DrawEllipse(brush, pen, center, Math.Abs(BottomRight.X - TopLeft.X) / 2, Math.Abs(BottomRight.Y - TopLeft.Y) / 2);
        }
        
    }
}
