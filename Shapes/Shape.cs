using System.Windows.Media;


namespace OOPaint.Shapes
{
    
    public abstract class Shape
    {
        protected Color strokeColor;
        protected Color fillColor;
        protected int lineWidth;

        public Shape(Color strokeColor, Color fillColor, int lineWidth)
        {
            this.strokeColor = strokeColor;
            this.fillColor = fillColor;
            this.lineWidth = lineWidth;
        }

        public abstract void Draw(DrawingContext graphics);

        public abstract byte[] Serialize();
        public abstract void Deserialize(byte[] data);
    }
}
