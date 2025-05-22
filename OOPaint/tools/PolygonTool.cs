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
    public class PolygonTool : Tool
    {
        enum PolygonToolState
        {
            INITIAL,
            DRAWING
        }

        private static double CLOSE_DISTANCE = 4;
        private PolygonToolState state = PolygonToolState.INITIAL;
        private Polygon polygon = null;

        public PolygonTool(IPaintApp app) : base(app)
        {
            MouseDownEvent += OnMouseDown;
            MouseMoveEvent += OnMouseMove;
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            Point point = (e as MouseButtonEventArgs).GetPosition(sender as FrameworkElement);

            if (state == PolygonToolState.INITIAL)
            {
                polygon = new Polygon(app.SelectedStrokeColor, app.SelectedFillColor, app.SelectedLineWidth);
                app.AddShape(polygon);
                polygon.Points.Add(point);
                state = PolygonToolState.DRAWING;
            } else if (Utils.Distance(point, polygon.Points[0]) <= CLOSE_DISTANCE)
            {
                state = PolygonToolState.INITIAL;
                polygon.IsCompleted = true;
                polygon.Points.RemoveAt(polygon.Points.Count - 1);
                return;
            }

            polygon.Points.Add(point);
        }

        private void OnMouseMove(object sender, EventArgs e)
        {
            if (state != PolygonToolState.DRAWING)
                return;

            Point point = (e as MouseEventArgs).GetPosition(sender as FrameworkElement);
            polygon.Points[polygon.Points.Count - 1] = point;
            app.Redraw();
        }
    }
}
