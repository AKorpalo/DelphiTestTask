using System;
using System.IO;
using System.Text.RegularExpressions;
using PlugIn;

namespace SearchPlugin2
{
    public class PlugIn : IPlugin
    {
        public string Author { get; } = "Андрій Корпало";

        public string Description { get; } = "Пошук без урахування регiстру i кiлькость пробiлiв.";

        public string PluginName { get; } = "Другий плагiн";

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
                        Regex r = new Regex(value = Regex.Replace(value, "[ ]+", " "), RegexOptions.IgnoreCase);
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
