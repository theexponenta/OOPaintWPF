using OOPaint.Tools;

namespace OOPaint
{
    public interface IPlugin
    {
        string Name { get; }
        Tool getTool(OOPaintApp app);
    }
}
