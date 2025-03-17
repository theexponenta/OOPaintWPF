using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Rectangle : Shape
    {
        public Point TopLeft {get; set;}
        public Point BottomRight {get; set;}

        public Rectangle(Color strokeColor, Color fillColor, int lineWidth, Point topLeft, Point bottomRight) 
            : base(strokeColor, fillColor, lineWidth)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public override void Draw(DrawingContext context)
        {
            Pen pen = new Pen(new SolidColorBrush(strokeColor), this.lineWidth);
            Brush brush = new SolidColorBrush(this.fillColor);
            
            context.DrawRectangle(brush, pen, new Rect(TopLeft.X, TopLeft.Y, Math.Abs(BottomRight.X - TopLeft.X),  Math.Abs(BottomRight.Y - TopLeft.Y)));
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
