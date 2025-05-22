using System;
using System.Windows;
using System.Windows.Input;
using OOPaint.Shapes;
using Shared;


using Point = System.Windows.Point;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;


namespace OOPaint.Tools
{
    public class PolylineTool : Tool
    {
        enum PolylineToolState
        {
            INITIAL,
            DRAWING
        }
        
        private PolylineToolState state = PolylineToolState.INITIAL;
        private Polyline polyline = null;
        
        public PolylineTool(IPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
            KeyDownEvent += OnKeyDown;
        }
        
        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);
            
            if (state == PolylineToolState.INITIAL)
            {
                polyline = new Polyline(app.SelectedStrokeColor, app.SelectedLineWidth);
                app.AddShape(polyline);
                polyline.Points.Add(point);
                state = PolylineToolState.DRAWING;
            }
            
            polyline.Points.Add(point);
        }
        
        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != PolylineToolState.DRAWING)
                return;
            
            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            polyline.Points[polyline.Points.Count - 1] = point;
            app.Redraw();
        }
        
        private void OnKeyDown(object sender, EventArgs e)
        {
            if (state == PolylineToolState.DRAWING && (e as KeyEventArgs).Key == Key.Escape)
            {
                polyline.Points.RemoveAt(polyline.Points.Count - 1);
                if (polyline.Points.Count == 0)
                    app.DeleteLastShape();
                
                state = PolylineToolState.INITIAL;
                app.Redraw();
            }
        }
    }
}