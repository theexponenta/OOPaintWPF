using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Rectangle : Shape
    {
        float x1, y1, x2, y2;

        public Rectangle(Color strokeColor, Color fillColor, int lineWidth, int x1, int y1, int x2, int y2) 
            : base(strokeColor, fillColor, lineWidth)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void Draw(DrawingContext context)
        {
            Pen pen = new Pen(new SolidColorBrush(strokeColor), this.lineWidth);
            Brush brush = new SolidColorBrush(this.fillColor);
            
            context.DrawRectangle(brush, pen, new Rect(this.x1, this.y1, this.x2, this.y2));
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
