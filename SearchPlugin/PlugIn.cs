using System;
using System.Text.RegularExpressions;
using System.IO;
using PlugIn;
namespace SearchPlugin
{
    public class PlugIn : IPlugin
    {
        public string Author { get; } = "Андрій Корпало";

        public string Description { get; } = "Пошук виключно введеної стрiчки";

        public string PluginName { get; } = "Перший плагiн";

        public string Version { get; } = "1.0.0";

        public string Search(string path, string value)
        {
            /*string text = File.ReadAllText(path);
            Regex r = new Regex(value);
            string res = r.Match(text).Value;
            return res;*/
            using (StreamReader stReader = new StreamReader(path))
            {
                string line;
                do
                {
                    line = stReader.ReadLine();
                    if (line != null)
                    {
                        Regex r = new Regex(value);
                        string res = r.Match(line).Value;
                        if (res != string.Empty)
                            return res;
                    }
                } while (line != null);

                return string.Empty;
            }
        }
        public override string ToString()
        {
            return $"Автор - {Author}, Назва плагiну - {PluginName}, версiя - {Version}, опис - {Description}";
        }
    }
}
