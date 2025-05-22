using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using OOPaint.Shapes;


using Brush = System.Windows.Media.Brush;
using Pen = System.Windows.Media.Pen;


namespace OOPaint
{
    public class CustomCanvas : FrameworkElement
    {
        public OOPaintApp App { get; set; } = null;
        
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (App == null)
                return;

            base.OnRender(drawingContext);
            Clear(drawingContext);

            for (int i = 0; i <= App.UndoIndex; i++)
            {
                App.Shapes[i].Draw(drawingContext);
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