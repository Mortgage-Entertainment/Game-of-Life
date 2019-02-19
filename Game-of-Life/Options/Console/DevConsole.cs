﻿using Game_of_Life.Options.Console.MiniMap;

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

                case "minimap":
                    MiniMap miniMap = new MiniMap();
                    miniMap.Show();
                    break;

                default: // Если неверная команда, то вывести об этом сообщение
                    devWindowConsole.Output.Text += "\nUnknown command '" + command + "'.";
                    break;
            }
        }
    }
}