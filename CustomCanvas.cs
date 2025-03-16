using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using OOPaint.Shapes;


namespace OOPaint
{
    public class CustomCanvas : FrameworkElement
    {
        public List<Shape> Shapes { get; set; }
        
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            foreach (Shape shape in Shapes)
            {
                shape.Draw(drawingContext);
            }
        }
    }
}