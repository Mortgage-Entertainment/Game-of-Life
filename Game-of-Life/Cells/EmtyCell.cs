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
        private int Value = 0;         // для удобства хранит кол-во созданных объектов этого класса
        private int x, y;              
        static private EmtyCell[,] Grid = new EmtyCell[ArraySize, ArraySize];        // Один из важнейших массивов в игре. Хранит пустые клетки (для удобной работы)
        static private int[] MarginValues = new int[4];            // Массив хранящий координаты margin для установки их в объект при отрисовке
        private Image Model;                // Объект картинки. Нужен для визуального отображения пустой клетки

        CellType Type;              // Объект перечисления, который хранит название типа хлетки, которая находится в этой (пустой) клетке 

    //-----------------------------------------------------------------------------------------\\

        private enum CellType
        {
            /* 
             * Перечисление, которое содержит названия типов клеток.
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
            Type = 0;   // Устанавливаем в тип клетки значение None
            Value++;
        }

        public EmtyCell(uint IndexX, uint IndexY)
        {
            Grid[IndexX, IndexY].Type = 0;    // Устанавливаем в тип клетки значение None
            Value++;
        }

        //----------------------------------------------------------------------------------------\\

        static public void GridInitialization()
        {
            /*
             * Метод, инициализирующий 
             * элементы массива Grid
             */

            uint IndexX = 0, IndexY = 0;

            while (IndexX < 150)
            {
                while (IndexY < 150)
                {
                    Grid[IndexX, IndexY] = new EmtyCell();
                    IndexY++;
                }
                IndexY = 0;
                IndexX++;
            }
        }

        //-----------------------------------------------------------------------------------------\\

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


        static public void SetImagePosition(uint IndexX, uint IndexY, int CellHeight, uint RowsCount, uint CellsinRow, uint value, NamesFormuleType FormuleType)
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

            int TypeofFormule = (int)(FormuleType);

            if (TypeofFormule == 1)
            {
                MarginValues[1] = unchecked((int)((int)(SystemParameters.PrimaryScreenWidth / 2) - (int)(CellHeight / 2) + (CellHeight * RowsCount) - CellHeight * (CellsinRow - value) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));   //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((int)(Convert.ToInt32(SystemParameters.PrimaryScreenHeight / 2) - Convert.ToInt32(CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetDownOffset()));     //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 2)
            {
                MarginValues[1] = unchecked((int)((int)(SystemParameters.PrimaryScreenWidth / 2) - (int)(CellHeight / 2) - (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));       //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((int)((int)(SystemParameters.PrimaryScreenHeight / 2) - (int)(CellHeight / 2) + (CellHeight * RowsCount) - (CellHeight * (CellsinRow - value)) + ScrollPosition.GetTopOffset() - ScrollPosition.GetDownOffset()));      //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 3)
            {
                MarginValues[1] = unchecked((int)((int)(SystemParameters.PrimaryScreenWidth / 2) - (int)(CellHeight / 2) - (CellHeight * RowsCount) + (CellHeight * (CellsinRow - value)) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));        //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((int)((int)(SystemParameters.PrimaryScreenHeight / 2) - (int)(CellHeight / 2) -(CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetDownOffset()));       //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 4)
            {
                MarginValues[1] = unchecked((int)((int)(SystemParameters.PrimaryScreenWidth / 2) - (int)(CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));//установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((int)((int)(SystemParameters.PrimaryScreenHeight / 2) - (int)(CellHeight / 2) - (CellHeight * RowsCount) + (CellHeight * ((CellsinRow - 2) - value)) + CellHeight + ScrollPosition.GetTopOffset() - ScrollPosition.GetDownOffset()));//установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

        }

        static public void SetImagePosition(uint IndexX, uint IndexY, int CellHeight)
        {
            /*
             * Перегруженная функция. 
             * 
             * Нужна, чтобы отрисовать центральную ячейку,
             * 
             * так как при её отрисовке имеются ещё не все значения, необходимые в аргументах оригинальной функции.
             */

            MarginValues[1] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2);
            MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2);


            MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
            MarginValues[4] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

            Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
        }

        static public void SetGridImage(uint IndexX, uint IndexY)    // аргументы для нахождения определённого элемента в масстиве "Grid"
        {
            /*
             * Функция, устанавливающая 
             * картинку для пустой клетки
             */

            Grid[IndexX, IndexY].Model = new Image();
            Grid[IndexX, IndexY].Model.Source = new BitmapImage(new Uri("/Resources/EmtyCell540.jpg"));
        }
            
    }
}
