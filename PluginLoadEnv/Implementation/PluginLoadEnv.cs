using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PluginLoadEnv.Interfaces;

namespace PluginLoadEnv.Implementation
{
    public class PluginLoadEnv<PluginType> : IPluginLoadEnv<PluginType> 
        where PluginType : IPlugin
    {
        public PluginLoadEnv() { }
        public IEnumerable<PluginType> LoadPlugins(string path)
        {
            IEnumerable<Assembly> allAssemblies = GetAllAsmsInDirectory(path);
            IEnumerable<PluginType> plugins = GetAllPlugins(allAssemblies);
            return plugins;
        }

        private IEnumerable<PluginType> GetAllPlugins(IEnumerable<Assembly> allAssemblies)
        {
            Type pluginType = typeof(PluginType);
            List<PluginType> plugins = new List<PluginType>();
            foreach(var assembly in allAssemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(pluginType))
                    {
                        PluginType plugin = (PluginType)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                }
            }
            return plugins;
        }

        private IEnumerable<Assembly> GetAllAsmsInDirectory(string path)
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));
            return allAssemblies;
        } 
    }
}
