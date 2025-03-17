using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using OOPaint.Shapes;


namespace OOPaint
{
    public class CustomCanvas : FrameworkElement
    {
        public List<Shape> Shapes { get; set; } = new List<Shape>();
        
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Clear(drawingContext);
            
            foreach (Shape shape in Shapes)
            {
                shape.Draw(drawingContext);
            }
        }

        private void Clear(DrawingContext drawingContext)
        {
            Brush brush = new SolidColorBrush(Colors.White);
            Pen pen = new Pen(brush, 1);
            drawingContext.DrawRectangle(brush, pen, new Rect(0, 0, ActualWidth, ActualHeight));
        }
    }
}