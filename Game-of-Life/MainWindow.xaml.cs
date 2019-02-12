using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Input;
using Game_of_Life.Cells;
using Game_of_Life.Options;

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

        //----------------------------------------<Timer>------------------------------------------------\\

        public void GlobalTimerInit()
        {
            /*
             *  Инициализириует глобальный таймер
             *    ( создаёт его и назначет обработчик )
             *  
             */

            TimerCallback GTHandler;
            GTHandler = GlobalTimerHandler;
            Timer GlobalTimer = new Timer(GTHandler, 0, 0, 20);
        }

        private void GlobalTimerHandler(object Sender)
        {
            /*
             *  Обработчик события таймера
             *  Срабатывает каждый его цикл
             *  
             *  В глобальном таймере находятся:
             *     
             *     Проверки глобальных условий
             *       ( такие, как условия 
             *         поражения и победы в игре )
             *         
             *     Методы отрисовки
             *      ( например, метод ScrollingMove,
             *        который проверяет положение курсора и
             *        в зависимости от него двигает камеру )
             *        
             *     Всё, что требует
             *       привязки ко времени
             */

            ScrollPosition.ScrollingMove(Mouse.GetPosition(maingrid));
        }

        //-----------------------------------------------------------------------------------------------\\

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