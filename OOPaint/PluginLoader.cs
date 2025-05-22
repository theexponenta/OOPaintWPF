using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint
{
    internal class PluginLoader
    {
        public static IPlugin GetPlugin(string dllPath)
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (typeof(IPlugin).IsAssignableFrom(type))
                {
                    return (IPlugin)Activator.CreateInstance(type);
                }
            }

            return null;
        }
    }
}
