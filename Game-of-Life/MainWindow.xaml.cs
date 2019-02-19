using Game_of_Life.Cells;
using Game_of_Life.Options;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Game_of_Life
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public Options.Console.DevWindowConsole DevConsole = new Options.Console.DevWindowConsole(); // Создаем экземпляр консоли

        //-----------------------------------------------<Глобальный таймер>------------------------------------------------------------------\\

        private DispatcherTimer GlobalTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1000), IsEnabled = true }; // 1 сек = 1000 милСек

        public MainWindow()
        {
            InitializeComponent();
            GlobalTimer.Start();
        }

        private void GlobalTimer_Tick(object sender, EventArgs e) // Каждый "тик" таймера
        {
            ScrollPosition.ScrollingMove(Mouse.GetPosition(null));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------\\

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmptyCells.GridInitialization();
            Logic.Drawing(maingrid);
            GlobalTimer.Tick += GlobalTimer_Tick;
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ScrollPosition.ScrollingDistancing(maingrid);
            }
            else
            {
                ScrollPosition.ScrollingApproximation(maingrid);
            }
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