using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PlugIn;

namespace DelphiTestTask
{
    class WorkWithPlugins
    {
        public List<IPlugin> PluginsList { get; private set; } //list з усіма доступними плагінами

        public void LoadPlugins(string path)
        {
            PluginsList = new List<IPlugin>();

            string[] pluginFiles = Directory.GetFiles(path, "*.dll");

            if (pluginFiles.Length == 0)
                throw new Exception("Немає доступних плагiнiв.");

            foreach (var pluginPath in pluginFiles)
            {
                //завантаження бібліотеки
                Assembly assembly = Assembly.LoadFrom(pluginPath);
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                            PluginsList.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
                catch { continue; }
            }

            if (PluginsList.Count == 0)
                throw new Exception("Немає доступних плагiнiв.");
        }
        public string[] ShowInfo() //Завантаження інформації про плагіни
        {
            if(PluginsList.Count == 0)
                throw new Exception("Немає доступних плагiнiв.");

            string[] pluginsInfo = new string[PluginsList.Count];
            for (int i = 0; i < PluginsList.Count; i++)
            {
                pluginsInfo[i] =
                    $"{i + 1}) Назва плагiну - {PluginsList[i].PluginName}, версiя - {PluginsList[i].Version}, опис - {PluginsList[i].Description}";
            }

            return pluginsInfo;
        }
        public List<string> Search(string path, string value) 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException();

            if(!File.Exists(path))
                throw new Exception("Невiрно вказаний шлях, або файл не iснує");

            List<string> res = new List<string>();
            foreach (var plugin in PluginsList)
            {
                string result = plugin.Search(path,value); 
                if (result != string.Empty) 
                   res.Add($"Плагiн - {plugin.PluginName} знайшов - {result}");
                else res.Add($"Плагiн - {plugin.PluginName} нiчого не знайшов.");
            }

            return res;
        }
    }
}
