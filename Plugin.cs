using OOPaint.Tools;

namespace OOPaint
{
    public interface Plugin
    {
        string Name { get; }
        Tool getTool(OOPaintApp app);
    }
}
