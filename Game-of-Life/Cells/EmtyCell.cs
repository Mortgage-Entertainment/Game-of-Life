using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Game_of_Life;

namespace Game_of_Life.Cells
{
    class EmtyCell
    {
        /*Класс пустой клетки.
         * Объект этого класса визуально будет
         * выступать в роли фоновых клеток
         * и невизульно содержать другие объекты вроде нейрона.
         */

    //-----------------------------<Объявление переменных>-------------------------------------\\ 

        const int ArraySize = 150;     // для удобства хранит размер массива             
        private int Value = 0;
        private int x, y;
        static private EmtyCell[,] Grid = new EmtyCell[ArraySize, ArraySize];
        private Image Model;

        CellType Type;

    //---------------------------------------------------------------------------------------\\

        private enum CellType
        {
            /* Перечисление, которое содержит названия типов клеток.
             * Будет юзаться для хранения типа клетки, которая содержится
             * в объекте класса EmtyCell
             */

            None = 0,      // Это значение имеет каждый объект этого класса по умолчанию
            Neuron,        // Нейрон
            Building,      // Тип строительной клетки
            Leukocyte,     // Лейкоцит
            Muscle,        // Мышца
            Dead           // Мёртвая клетка
        };

    //---------------------------------<Конструкторы>------------------------------------------\\

        public EmtyCell()   // Конструктор по умолчанию класса EmptyCell
        {
            Model.Source = new BitmapImage(new Uri("/Resources/EmtyCell540.jpg"));
            Type = 0;   // Устанавливаем в тип клетки значение None
            Value++;
        }

        public EmtyCell(uint IndexX, uint IndexY)
        {
            Grid[IndexX, IndexY].Model = new Image();
            Grid[IndexX, IndexY].Model.Source = new BitmapImage(new Uri("/Resources/EmtyCell540.jpg"));
            Grid[IndexX, IndexY].Type = 0;    // Устанавливаем в тип клетки значение None
            Value++;
        }

    //----------------------------------------------------------------------------------------\\

        public enum NamesFormuleType
        {
             /* 
             *  Перечисление, которое
             *  определяет, какая формула будет использоваться
             *  в методе формул расчёта координат изображений
             *   ( имя метода - SetImagePosition)
             *  
             *   ( для метода отрисовки DrawingCells
             *    в классе Logic )
             */ 

            FT_DownFirst = 1,    // Первая формула, проход нижней части
            FT_LeftSecond = 2,   // Вторая формула, проход левой части
            FT_UpThreed = 3,     // Третья формула, проход верхней части
            FT_RightFourth = 4   // Четвёртая формула, проход правой части
        }

        static private uint[] MarginValues = new uint[4];

        static public void SetImagePosition(uint IndexX, uint IndexY, uint CellHeight, uint RowsCount, uint CellsinRow, uint value, NamesFormuleType FormuleType)
        {
            /*
             * Метод вычисления координат.
             * 
             * Имеет 4 разных формулы 
             * для расчёта координат в четырёх разных циклах,
             * которые находятся в функции отрисовки
             * 
             *  ( DrawingCells
             *   в классе Logic )
             */

            if (FormuleType == FT_DownFirst)
            {
                MarginValues[1] = (SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2) + (CellHeight * RowsCount) - CellHeight * (CellsinRow - value) + ScrollPosition.GetLeftOffset - ScrollPosition.GetRightOffset;//установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = (SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetTopOffset - ScrollPosition.GetDownOffset;//установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1];
                MarginValues[4] = SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2];

                Grid[IndexX, IndexY].Model.Margin = MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4];
            }

            if (FormuleType == FT_LeftSecond)
            {
                MarginValues[1] = (SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2) - (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset - ScrollPosition.GetRightOffset;//установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = (SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2) + (CellHeight * RowsCount) - (CellHeight * (CellsinRow - value)) + ScrollPosition.GetTopOffset - ScrollPosition.GetDownOffset;//установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1];
                MarginValues[4] = SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2];

                Grid[IndexX, IndexY].Model.Margin = MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4];
            }

        }

        static public void SetImagePosition(uint IndexX, uint IndexY, uint CellHeight)
        {
            /*
             * Перегруженная функция. 
             * 
             * Нужна, чтобы отрисовать центральную ячейку,
             * 
             * так как при её отрисовки имеются ещё не все значения, необходимые в аргументах оригинальной функции.
             */

            MarginValues[1] = (SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2);
            MarginValues[2] = (SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2);


            MarginValues[3] = SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1];
            MarginValues[4] = SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2];

            Grid[IndexX, IndexY].Model.Margin = MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4];
        }
            
    }
}
