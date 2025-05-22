

namespace Shared
{
    public interface IPlugin
    {
        string Name { get; }
        Tool GetTool(IPaintApp app);
    }
}
