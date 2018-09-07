using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PlugIn;

namespace SearchPlugin4
{
    public class PlugIn : IPlugin
    {
        public string Author { get; } = "Андрій Корпало";

        public string Description { get; } = "Пошук реверсованої стрiчки без урахування регiстру.";

        public string PluginName { get; } = "Четвертий плагiн";

        public string Version { get; } = "1.0.0";

        public string Search(string path, string value)
        {
            using (StreamReader stReader = new StreamReader(path))
            {
                string line;
                do
                {
                    line = stReader.ReadLine();
                    if (line != null)
                    {
                        Regex r = new Regex(new string(value.ToCharArray().Reverse().ToArray()), RegexOptions.IgnoreCase);
                        string res = r.Match(line).Value;
                        if (res != string.Empty)
                            return res;
                    }
                } while (line != null);

                return string.Empty;
            }
        }
    }
}
