using System;
using System.Windows;
using System.Windows.Media;


namespace OOPaint.Shapes
{
    public class Ellipse : Shape
    {
        double x, y, width, height;

        public Ellipse(Color strokeColor, Color fillColor, int lineWidth, int x, int y, int width, int height) 
            : base(strokeColor, fillColor, lineWidth)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void Draw(DrawingContext context)
        {
            Brush brush = new SolidColorBrush(this.fillColor);
            Pen pen = new Pen(new SolidColorBrush(this.strokeColor), this.lineWidth);
            
            Point center = new Point(this.x + this.width / 2, this.y + this.height / 2);
            context.DrawEllipse(brush, pen, center, width, height);
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
