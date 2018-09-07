using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIn
{
    public interface IPlugin
    {
        string Author { get; } //Автор плагіну
        string Description { get; } //Опис плагіну
        string PluginName { get; } //Назва плагіну
        string Version { get; } //Версія
        string Search(string path, string value); //Метод пошуку
    }
}
