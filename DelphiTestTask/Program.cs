using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIn;

namespace DelphiTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathPlugin = Environment.CurrentDirectory + "\\Plugins";
            string pathData = Environment.CurrentDirectory + "\\Data";
            if (!Directory.Exists("Plugins"))
                Directory.CreateDirectory(pathPlugin);
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory(pathData);

            WorkWithPlugins plugins = new WorkWithPlugins();

            while (true)
            {
            Console.WriteLine("=============Меню=============");
            Console.WriteLine("1) Iнформацiя про усi доступнi плагiни.\n2) Пошук.\n3) Вихiд.");
            int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Iнформацiя про усi доступнi плагiни.\n");
                        //Завантаження плагінів
                        try
                        {
                            plugins.LoadPlugins(pathPlugin);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        //Отримання інформації про плагіни
                        try
                        {
                            string[] pluginsInfo = plugins.ShowInfo(); 
                            foreach (var info in pluginsInfo)
                            {
                                Console.WriteLine(info);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Clear();
                        string fileName;
                        string value;
                        do
                        {
                            Console.WriteLine("Введiть назву файлу у якому здiйснюється пошук (файл повинен знаходитись у папцi 'Data'): ");
                            fileName = Console.ReadLine();
                        } while (string.IsNullOrEmpty(fileName));

                        do
                        {
                            Console.WriteLine("Введiть стрiчку, яка шукається: ");
                            value = Console.ReadLine();
                        } while (string.IsNullOrEmpty(value));
                        Console.WriteLine("Результат пошуку:");
                        //Завантаження плагінів
                        try
                        {
                            plugins.LoadPlugins(pathPlugin); 
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        //Пошук
                        try
                        { 
                            List<string> found = plugins.Search(Path.Combine(pathData,fileName), value); 
                            foreach (var f in found)
                            {
                                Console.WriteLine(f);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Помилка введення.");
                        break;
                }
            }
        }
    }
}
