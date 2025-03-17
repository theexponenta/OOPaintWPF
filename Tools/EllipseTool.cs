using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using OOPaint.Shapes;


namespace OOPaint.Tools
{
    public class EllipseTool : Tool
    {
        enum EllipseToolState
        {
            INITIAL,
            DRAWING
        }

        private EllipseToolState state = EllipseToolState.INITIAL;
        private Shapes.Ellipse ellipse = null;
        private Point startPoint;

        public EllipseTool(OOPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
            MouseUpEvent += OnMouseUp;
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);
            ellipse = new Shapes.Ellipse(app.SelectedStrokeColor, app.SelectedFillColor,
                app.SelectedLineWidth, point, point);
            app.AddShape(ellipse);
            state = EllipseToolState.DRAWING;
        }

        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != EllipseToolState.DRAWING)
                return;

            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            ellipse.BottomRight = point;

            app.Redraw();
        }

        private void OnMouseUp(object sender, EventArgs e)
        {
            state = EllipseToolState.INITIAL;
        }
    }
}
