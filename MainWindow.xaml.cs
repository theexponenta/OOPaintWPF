using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OOPaint.Shapes;


namespace OOPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private OOPaintApp app = new OOPaintApp();
        
        public MainWindow()
        {
            InitializeComponent();
            CustomCanvas canvas = this.FindName("DrawCanvas") as CustomCanvas;
            canvas.Shapes = app.Shapes;
            app.AddShape(new Line(Colors.Black, 2, new Point(100, 100), new Point(200, 200)));
        }
    }
}