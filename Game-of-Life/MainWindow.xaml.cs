using System.Windows;
using System.Windows.Controls;

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
            //EmtyCell.GridInitialization();
            //Logic.Drawing();
            Button button = new Button();
            Grid grid = new Grid();

            grid.Children.Add(button);
        }
    }
}