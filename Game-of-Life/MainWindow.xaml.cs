using Game_of_Life.Cells;
using Game_of_Life.Options;
using System.Windows;

namespace Game_of_Life
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public Options.Console.DevWindowConsole DevConsole = new Options.Console.DevWindowConsole(); // Создаем экземпляр консоли

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmptyCells.GridInitialization();
            Logic.Drawing(maingrid);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) // Если тильда, то показать консоль
        {
            if (e.Key == System.Windows.Input.Key.OemTilde)
            {
                DevConsole.Visibility = Visibility.Visible;
            }
        }
    }
}