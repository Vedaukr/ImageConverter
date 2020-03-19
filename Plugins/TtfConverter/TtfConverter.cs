using PluginLoadEnv.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TtfConverter
{
    public class TtfConverter : IConverter
    {
        public IEnumerable<string> Keys => new List<string>() { ".ttf" };
        public string Description => "TTF format converter.";

        public byte[] ConvertFromCommonFormat(ICommonImage image)
        {
            throw new NotImplementedException();
        }

        public ICommonImage ConvertToCommonFormat(byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
