using Shared;


namespace Plugins.Trapezoid
{
    public class TrapezoidPlugin : IPlugin
    {
        public string Name { get { return "Трапеция"; } }

        public Tool GetTool(IPaintApp app)
        {
            return new TrapezoidTool(app);
        }
    }
}
