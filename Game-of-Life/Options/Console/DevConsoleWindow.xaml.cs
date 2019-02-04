using System;
using System.Windows;
using System.Windows.Input;

namespace Game_of_Life.Options.Console
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class DevWindowConsole : Window
    {
        public DevWindowConsole()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            if (this.Visibility != Visibility.Hidden)
            {
                this.Hide();
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Click();
        }

        private void Button_Click()
        {
            DevConsole.ExeCom(Input.Text, this);
            Input.Text = string.Empty;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemTilde)
            {
                this.Hide();
            }
        }
    }
}