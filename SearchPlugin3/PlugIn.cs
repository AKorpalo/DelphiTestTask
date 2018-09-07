using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PlugIn;

namespace SearchPlugin3
{
    public class PlugIn : IPlugin
    {
        public string Author { get; } = "Андрій Корпало";

        public string Description { get; } = "Пошук з права на лiво без урахування регiстру.";

        public string PluginName { get; } = "Третiй плагiн";

        public string Version { get; } = "1.0.0";
        public string Search(string path, string value)
        {
            string text = File.ReadAllText(path);
            string res = Regex.Match(text, value, RegexOptions.RightToLeft | RegexOptions.IgnoreCase).Value;

            if (res != string.Empty)
                return res;
            return string.Empty;
        }
    }
}
