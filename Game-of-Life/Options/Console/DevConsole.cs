namespace Game_of_Life.Options
{
    internal class DevConsole
    {
        static public void AddOutput(string OutputInfo) // вывести что-то в консоль
        {
            MainWindow.DevConsole.Output.Text += "\n" + OutputInfo;
        }

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
                // Прим. Команда должна быть в нижнем регистре
                case "help":
                    devWindowConsole.Output.Text += "\nClear - clear the console" + "\nExit - close the application";
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

                default: // Если неверная команда, то вывести об этом сообщение
                    devWindowConsole.Output.Text += "\nUnknown command '" + command + "'.";
                    break;
            }
        }
    }
}