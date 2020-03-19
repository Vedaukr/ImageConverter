using System;
using System.IO;
using System.Reflection;
using PluginLoadEnv.Implementation;
using PluginLoadEnv.Interfaces;

namespace ImageConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginsPath = "..\\..\\..\\..\\Converters";
            string path = Path.Combine(basePath, pluginsPath);
            var pluginEnv = new PluginLoadEnv<IConverter>();
            var plugins = pluginEnv.LoadPlugins(path);
            foreach (var plugin in plugins)
            {
                Console.WriteLine(plugin.Description);
            }
        }
    }
}
