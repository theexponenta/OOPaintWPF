using System.Windows.Media;


namespace Shared
{
    public interface IPaintApp
    {
        Color SelectedStrokeColor { get; set; }
        Color SelectedFillColor { get; set; }
        int SelectedLineWidth { get; set; }

        void Redraw();
        void AddShape(Shape shape);
        void DeleteLastShape();
    }
}
