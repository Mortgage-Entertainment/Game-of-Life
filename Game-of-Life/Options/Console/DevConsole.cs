using Game_of_Life.Options.Console.MiniMap;
using System.Windows.Documents;
using System.Windows.Media;

namespace Game_of_Life.Options
{
    public class DevConsole
    {
        static public void ExeCom(string command, object sender) // Обработчик комманд (комманда, ссылка на экземпляр консоли)
        {
            Options.Console.DevWindowConsole devWindowConsole = sender as Options.Console.DevWindowConsole; // "Конвертация" ссылки в экземпляр
            switch (command.ToLower()) // Проверка комманд вне зависимости от регистра
            {
                /*
                 case "команда":
                    функция;
                    breal;
                 */
                // Прим. Команда должна быть в нижнем регистре, вывод в консоль devWindowConsole.AddOutput(что, цвет), и не забывайте про перенос строки
                case "help":
                    devWindowConsole.AddOutput("\nClear", Brushes.Green);
                    devWindowConsole.AddOutput(" - clear the console");

                    devWindowConsole.AddOutput("\nClose, exit, quit", Brushes.Green);
                    devWindowConsole.AddOutput(" - close the application");

                    devWindowConsole.AddOutput("\nMinimap", Brushes.Green);
                    devWindowConsole.AddOutput(" - open the minimap window");
                    break;

                case "clear":
                    devWindowConsole.Output.Text = string.Empty;
                    break;

                case "exit":
                    App.Current.Shutdown();
                    break;

                case "close":
                    App.Current.Shutdown();
                    break;

                case "quit":
                    App.Current.Shutdown();
                    break;

                case "minimap":
                    MiniMap miniMap = new MiniMap();
                    miniMap.Show();
                    devWindowConsole.AddOutput("\nMinimap opened");
                    devWindowConsole.AddOutput("succesful", Brushes.Green);
                    devWindowConsole.AddOutput(".");
                    break;

                default: // Если неверная команда, то вывести об этом сообщение
                    devWindowConsole.AddOutput("\nUnknown command '");
                    devWindowConsole.AddOutput(command, Brushes.DarkGreen);
                    devWindowConsole.AddOutput("'.");
                    break;
            }
        }
    }
}