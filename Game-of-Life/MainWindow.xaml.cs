using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            SomeImage some = new SomeImage();
            some.Image_drow(mygrid);
        }


        class SomeImage
        {
            public void Image_drow(Grid mygrid)
            {
                Image image = new Image();
                mygrid.Children.Add(image);
                image.Source = new BitmapImage(new Uri(@"D:\Game-of-Life\Game-of-Life\Game-of-Life\Resources\540.jpg"));
            }
        }
    }
}