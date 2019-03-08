using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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

        public void AddOutput(string OutputInfo, Brush br) // вывести что-то в консоль с цветом
        {
            this.Output.Inlines.Add(new Run(OutputInfo) { Foreground = br});
        }
        public void AddOutput(string OutputInfo) // вывести что-то в консоль с черным цветом
        {
            this.Output.Inlines.Add(new Run(OutputInfo) { Foreground = Brushes.Black });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // Если нажали закрыть - скрыть
        {
            e.Cancel = true; // Отмена закрытия
            this.Hide();
        }

        private void Window_Deactivate(object sender, EventArgs e) // Если окно неактивно и не скрыто - скрыть
        {
            if (this.Visibility != Visibility.Hidden)
            {
                this.Hide();
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e) // Если нажат ввод - ввод
        {
            if (e.Key == Key.Enter)
            {
                Button_Click();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Нажатие кнопки = ввод
        {
            Button_Click();
        }

        private void Button_Click() // Упрощение кода для ввода
        {
            DevConsole.ExeCom(Input.Text, this);
            Input.Text = string.Empty;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) // Скрытие консоли на ~
        {
            if (e.Key == Key.OemTilde)
            {
                this.Hide();
            }
        }
    }
}