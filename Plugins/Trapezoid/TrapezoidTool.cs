using Shared;
using System.Windows;
using System.Windows.Input;

namespace Plugins.Trapezoid
{
    public class TrapezoidTool : Tool
    {
        enum TrapezoidToolState
        {
            INITIAL,
            DRAWING
        }

        private TrapezoidToolState state = TrapezoidToolState.INITIAL;
        private Trapezoid trapezoid = null;
        private Point startPoint;

        public TrapezoidTool(IPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
            MouseUpEvent += OnMouseUp;
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);
            startPoint = point;
            trapezoid = new Trapezoid(app.SelectedStrokeColor, app.SelectedFillColor,
                app.SelectedLineWidth, point, point);
            app.AddShape(trapezoid);
            state = TrapezoidToolState.DRAWING;
        }

        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != TrapezoidToolState.DRAWING)
                return;

            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            if (point.X < startPoint.X && point.Y < startPoint.Y)
            {
                trapezoid.TopLeft = point;
                trapezoid.BottomRight = startPoint;
            }
            else if (point.X < startPoint.X)
            {
                trapezoid.TopLeft = new Point(point.X, startPoint.Y);
                trapezoid.BottomRight = new Point(startPoint.X, point.Y);
            }
            else if (point.Y < startPoint.Y)
            {
                trapezoid.TopLeft = new Point(startPoint.X, point.Y);
                trapezoid.BottomRight = new Point(point.X, startPoint.Y);
            }
            else
            {
                trapezoid.TopLeft = startPoint;
                trapezoid.BottomRight = point;
            }

            app.Redraw();
        }
        private void OnMouseUp(object sender, EventArgs e)
        {
            state = TrapezoidToolState.INITIAL;
        }

    }
}
