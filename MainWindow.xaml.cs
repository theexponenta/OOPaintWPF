using System;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OOPaint.Shapes;
using OOPaint.Tools;


namespace OOPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private OOPaintApp app;
        
        public MainWindow()
        {
            InitializeComponent();

            
            app = new OOPaintApp(DrawCanvas);
            app.AddTool(new LineTool(app));
            app.AddTool(new PolylineTool(app));
            app.AddTool(new RectangleTool(app));
            app.AddTool(new PolygonTool(app));
            app.AddTool(new EllipseTool(app));

            DrawCanvas.Shapes = app.Shapes;
        }

        public void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEDOWN, sender, e);
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEMOVE, sender, e);
        }

        public void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEUP, sender, e);
            DrawCanvas.InvalidateVisual();
        }

        public void Canvas_MouseClick(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSECLICK, sender, e);
        }

        private void ToolComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (app != null)
            {
                app.SelectedToolIndex = ToolComboBox.SelectedIndex;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            app.DispatchEvent(EventType.KEYDOWN, sender, e);
        }
    }
}