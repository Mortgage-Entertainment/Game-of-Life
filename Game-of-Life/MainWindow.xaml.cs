using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Game_of_Life.Cells;
using Game_of_Life.Options;
using System.Windows.Input;

namespace Game_of_Life
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmptyCells.GridInitialization();
            Logic.Drawing(maingrid);
            Logic.GlobalTimerInit(maingrid);
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) {
                ScrollPosition.ScrollingDistancing(maingrid);
            } else {
                ScrollPosition.ScrollingApproximation(maingrid);
            }
        }
    }
}