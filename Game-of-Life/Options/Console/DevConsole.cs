using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life.Options
{
    internal class DevConsole
    {
        static public void AddOutput(string OutputInfo)
        {
            MainWindow.DevConsole.Output.Text += "\n" + OutputInfo;
        }
        static public void ExeCom(string command, object sender)
        {
            Options.Console.DevWindowConsole devWindowConsole = sender as Options.Console.DevWindowConsole;
            switch (command.ToLower())
            {
                case "help":
                    devWindowConsole.Output.Text += "\nThere is no help today!";
                    break;
                            // Сюда добавлять обработчики комманд
                default:
                    devWindowConsole.Output.Text += "\nUnknown command '" + command + "'.";
                    break;
            }
        }
    }
}
