using System;
using System.Windows;
using System.Windows.Input;
using OOPaint.Shapes;
using Shared;


using Point = System.Windows.Point;
using Rectangle = OOPaint.Shapes.Rectangle;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;


namespace OOPaint.Tools
{
    public class RectangleTool : Tool
    {
        enum RectangleToolState
        {
            INITIAL,
            DRAWING
        }
        
        private RectangleToolState state = RectangleToolState.INITIAL;
        private Rectangle rectangle = null;
        private Point startPoint;
        
        public RectangleTool(IPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
            MouseUpEvent += OnMouseUp;
        }
        
        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);
            startPoint = point;
            rectangle = new Rectangle(app.SelectedStrokeColor, app.SelectedFillColor, 
                app.SelectedLineWidth, point, point);
            app.AddShape(rectangle);
            state = RectangleToolState.DRAWING;
        }
        
        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != RectangleToolState.DRAWING)
                return;
            
            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            if (point.X < startPoint.X && point.Y < startPoint.Y)
            {
                rectangle.TopLeft = point;
                rectangle.BottomRight = startPoint;
            }
            else if (point.X < startPoint.X)
            {
                rectangle.TopLeft = new Point(point.X, startPoint.Y);
                rectangle.BottomRight = new Point(startPoint.X, point.Y);
            }
            else if (point.Y < startPoint.Y)
            {
                rectangle.TopLeft = new Point(startPoint.X, point.Y);
                rectangle.BottomRight = new Point(point.X, startPoint.Y);
            }
            else
            {
                rectangle.TopLeft = startPoint;
                rectangle.BottomRight = point;
            }
                
            app.Redraw();
        }
        
        private void OnMouseUp(object sender, EventArgs e)
        {
            state = RectangleToolState.INITIAL;
        }
    }
}