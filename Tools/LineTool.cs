using System;
using System.Windows;
using System.Windows.Input;
using OOPaint.Shapes;

namespace OOPaint.Tools
{
    
    public class LineTool : Tool
    {
        enum LineToolState
        {
            INITIAL,
            DRAWING
        }
        
        private LineToolState state = LineToolState.INITIAL;
        private Line line = null;
        
        public LineTool(OOPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
            MouseUpEvent += OnMouseUp;
        }
        
        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);
            line = new Line(app.SelectedStrokeColor, app.SelectedLineWidth, point, point);
            app.AddShape(line);
            state = LineToolState.DRAWING;
        }
        
        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != LineToolState.DRAWING)
                return;
            
            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            line.Point2 = point;
            app.Redraw();
        }
        
        private void OnMouseUp(object sender, EventArgs e)
        {
            state = LineToolState.INITIAL;
        }
    }
    
}