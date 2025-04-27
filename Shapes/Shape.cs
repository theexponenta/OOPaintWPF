using System.Windows.Media;
using System.Text.Json.Serialization;


namespace OOPaint.Shapes
{
    public abstract class Shape
    {
        public Color StrokeColor { get; set; }
        public Color FillColor { get; set; }
        public int LineWidth { get; set; }

        public Shape(Color strokeColor, Color fillColor, int lineWidth)
        {
            this.StrokeColor = strokeColor;
            this.FillColor = fillColor;
            this.LineWidth = lineWidth;
        }

        public abstract void Draw(DrawingContext graphics);
    }
}
