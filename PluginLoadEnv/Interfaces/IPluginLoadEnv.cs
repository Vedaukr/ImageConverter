using System;
using System.Collections.Generic;
using System.Text;

namespace PluginLoadEnv.Interfaces
{
    /// <summary>
    /// Plugin load environment
    /// Does all logic with loading plugin assemblies
    /// </summary>
    public interface IPluginLoadEnv<PluginType> where PluginType : IPlugin
    {
        /// <summary>
        /// Loads all plugins, which are existing at some path
        /// </summary>
        /// <param name="path"> Path to folder with plugins </param>
        /// <returns> All converters </returns>
        IEnumerable<PluginType> LoadPlugins(string path);
    }
}
