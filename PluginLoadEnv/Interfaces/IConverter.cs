using System;
using System.Collections.Generic;
using System.Text;

namespace PluginLoadEnv.Interfaces
{
    /// <summary>
    /// Plugin interface of image converter
    /// </summary>
    public interface IConverter : IPlugin
    {
        /// <summary>
        /// Keys which will be used by Program to choose which Converter to use
        /// Typically contains extensions of image format (.png, .jpg/.jpeg etc.)
        /// </summary>
        IEnumerable<string> Keys { get; }

        /// <summary>
        /// Some description to show info in console
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Does convert from self format (e.g. png) to common image format
        /// </summary>
        /// <param name="path"> Image represented in bytes </param>
        /// <returns> Common image format </returns>
        ICommonImage ConvertToCommonFormat(byte[] image);

        /// <summary>
        /// Does convert from common format to self format
        /// </summary>
        /// <param name="image"> Image represented in common image format </param>
        /// <returns> Byte array </returns>
        byte[] ConvertFromCommonFormat(ICommonImage image);
    }
}
