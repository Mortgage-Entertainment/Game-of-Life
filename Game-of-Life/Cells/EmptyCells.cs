using Game_of_Life.Options;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game_of_Life.Cells
{
    internal class EmptyCells
    {
        /*
         *   Класс обслуживания и управления
         *   ячейками
         *     ( объектами класса BaseCell )
         *
         *   Здесь находятся методы,
         *     связанные с ячейками;
         *   массив Grid,
         *     который является картой, на которой идёт игра;
         *   переменные, хранящие данные
         *     о ячейках.
         *
         */  //   если кто-то знает о классе EmptyCell, то для него:
             //                             \\
             // КЛАСС EmptyCell БЫЛ РЗДЕЛЁН на\\
             //                                 \\
             //  EmptyCells  \\  И  //  BaseCell  \\

        //---------------------------------------------<Объявление переменных>---------------------------------------------------------------\\

        private const int ArraySize = 150;     // хранит размер массива, чтобы, при случае, меняя переменную, менялся размер всех массивов, использующих это значение
        static private int Value = 0;         // для удобства хранит кол-во созданных объектов этого класса
        static public BaseCell[,] CellGrid = new BaseCell[ArraySize, ArraySize];        // Один из важнейших массивов в игре. Хранит пустые клетки (для удобной работы)

        static private int[] MarginValues = new int[4];            // Массив хранящий координаты margin для установки их в объект при отрисовке

        //---------------------------------<Конструкторы>------------------------------------------\\

        static public void BaseCellConstr(int IndexX, int IndexY)
        {
            Value++;
        }

        //----------------------------------------------------------------------------------------\\

        static public void GridInitialization()
        {
            /*
             * Метод, инициализирующий
             * элементы массива Grid
             */

            int IndexX = 0, IndexY = 0;

            while (IndexX < 150)
            { 
                while (IndexY < 150)
                {
                    CellGrid[IndexX, IndexY] = new BaseCell(IndexX, IndexY);
                    CellGrid[IndexX, IndexY].cellType = 0;    // Устанавливаем в тип клетки значение None
                    IndexY++;
                }
                IndexY = 0;
                IndexX++;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------\\

        static public void SetImagePosition(int IndexX, int IndexY, int CellHeight, int RowsCount, int CellsinRow, int value, Logic.ScreenSideofDrawing FormuleType)
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
                MarginValues[0] = unchecked((int)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 + (CellHeight * RowsCount) - CellHeight * (CellsinRow - value) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset());   //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[1] = unchecked(Convert.ToInt32(SystemParameters.PrimaryScreenHeight / 2) - Convert.ToInt32(CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset());     //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[0]);
                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[1]);

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (TypeofFormule == 2)
            {
                MarginValues[0] = unchecked((int)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 - (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset());       //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[1] = unchecked((int)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 + (CellHeight * RowsCount) - (CellHeight * (CellsinRow - value)) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset());      //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[0]);
                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[1]);

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (TypeofFormule == 3)
            {
                MarginValues[0] = unchecked((int)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 - (CellHeight * (RowsCount + 1)) + (CellHeight * (CellsinRow - value)) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset());        //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[1] = unchecked((int)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 - (CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset());       //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[0]);
                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[1]);

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (TypeofFormule == 4)
            {
                MarginValues[0] = unchecked((int)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 + (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset());//установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[1] = unchecked((int)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 - (CellHeight * RowsCount) + (CellHeight * ((CellsinRow - 2) - value)) + CellHeight + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset());//установка вертикальной координаты картинки центральной ячйеки

                MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[0]);
                MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[1]);

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }
        }

        static public void SetImagePosition(int IndexX, int IndexY, int CellHeight)
        {
            /*
             * Перегруженная функция.
             *
             * Нужна, чтобы отрисовать центральную ячейку,
             *
             * так как при её отрисовке имеются ещё не все значения, необходимые в аргументах оригинальной функции.
             */

            MarginValues[0] = Convert.ToInt32((int)(SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2));
            MarginValues[1] = Convert.ToInt32((int)(SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2));

            MarginValues[2] = Convert.ToInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[0]);
            MarginValues[3] = Convert.ToInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[1]);

            CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
        }

        static public void SetGridImage(int IndexX, int IndexY, Grid grid)    // аргументы для нахождения определённого элемента в масстиве "Grid" и grid в XAML разметке, в котором все будет отрисовываться
        {
            /*
             * Функция, устанавливающая
             * картинку для пустой клетки
             */

            CellGrid[IndexX, IndexY].Model = new Image();     // Создаем объект картинки
            grid.Children.Add(CellGrid[IndexX, IndexY].Model);   // Засовываем его в grid в XAML разметке
            CellGrid[IndexX, IndexY].Model.Source = new BitmapImage(new Uri("../Resources/540.jpg", UriKind.Relative));  // загружем изображение в объект картинки
        }

        //--------------------------------------------------------------<Перемещение камеры ( SM - ScrollingMove )>------------------------------------------------------------------------------\\

        static public void SM_OffsetingImages(int IndexX, int IndexY, int cellhgh, byte VoS)
        {
            /*
             *  метод
             *   ( вызывается в функции ScrollingMoveDrawing в классе Logic )
             *
             *  перемещает клетки
             *  в обратную от перемещения камеры строну
             *
             *  при скроллинге перемещения
             *
             */

            if (VoS == 1)
            {  //  при перемещении  / ВНИЗ
                MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left;
                MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top - Settings.ScrollMoveSpeed;
                MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right;
                MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom + Settings.ScrollMoveSpeed;

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (VoS == 2)
            {  //  при перемещении  / ВЛЕВО
                MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left + Settings.ScrollMoveSpeed;
                MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top;
                MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right - Settings.ScrollMoveSpeed;
                MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom;

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (VoS == 3)
            {  //  при перемещении  / ВВЕРХ
                MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left;
                MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top + Settings.ScrollMoveSpeed;
                MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right;
                MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom - Settings.ScrollMoveSpeed;

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }

            if (VoS == 4)
            {  //  при перемещении  / ВПРАВО
                MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left - Settings.ScrollMoveSpeed;
                MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top;
                MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right + Settings.ScrollMoveSpeed;
                MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom;

                CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
            }
        }

        static public void SM_AddingCells(int RowsCount, byte VoS, int CellHeight, Grid grid)
        {
            /*
             *  Метод
             *
             *   создания объектов
             *   картинок ячеек
             *   и расчёт их координат
             *
             *   при скроллинге перемещения
             *
             *   ( отрисовка тех клеток, что были за границей экрана )
             *
             *  ( вызывается метод
             *   в методе SM_Drawing
             *   класса Logic )
             *
             */   /////  не закончено, расчёта координат пока нет

            int IndexX = (int)ScrollPosition.CameraPosition.X - 1;
            int IndexY = (int)ScrollPosition.CameraPosition.Y - 1;

            if (VoS == 1)
            {                  //  При перемещении    / ВНИЗ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY + RowsCount;

                while (ScrollPosition.CameraPosition.X - 1 + ((RowsCount * 2) + 1) > IndexX)
                {
                    if (CellGrid[IndexX, IndexY].Model == null) CellGrid[IndexX, IndexY].Model = new Image();

                    IndexY--;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left;                  //  берутся координаты
                    MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top + CellHeight;      //  соседней уже отрисованной
                    MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right;                 //  ячейки
                    MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom - CellHeight;   //  и смещаются на одну клетку

                    IndexY++;
                    CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexX++;
                }
            }

            if (VoS == 2)
            {                  //  При перемещении    / ВЛЕВО
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.Y - 1 + ((RowsCount * 2) + 1) > IndexY)
                {
                    if (CellGrid[IndexX, IndexY].Model == null) CellGrid[IndexX, IndexY].Model = new Image();

                    IndexX++;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left - CellHeight;   //  берутся координаты
                    MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top;                 //  соседней уже отрисованной
                    MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right + CellHeight;  //  ячейки
                    MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom;              //  и смещаются на одну клетку

                    IndexX--;
                    CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexY++;
                }
            }

            if (VoS == 3)
            {                  //  При перемещении    / ВВЕРХ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.X - 1 + ((RowsCount * 2) + 1) > IndexX)
                {
                    if (CellGrid[IndexX, IndexY].Model == null) CellGrid[IndexX, IndexY].Model = new Image();

                    IndexY++;   //  начало расчёта координат новой отрисованной ячейки

                    CellGrid[IndexX, IndexY].Model = new Image();

                    MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left;                  //  берутся координаты
                    MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top - CellHeight;      //  соседней уже отрисованной
                    MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right;                 //  ячейки
                    MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom + CellHeight;   //  и смещаются на одну клетку

                    IndexY--;
                    CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexX++;
                }
            }

            if (VoS == 4)
            {                  //  При перемещении    / ВПРАВО
                IndexX = IndexX + RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.Y - 1 + ((RowsCount * 2) + 1) > IndexY)
                {
                    if (CellGrid[IndexX, IndexY].Model == null) CellGrid[IndexX, IndexY].Model = new Image();

                    IndexX--;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[0] = (int)CellGrid[IndexX, IndexY].Model.Margin.Left + CellHeight;   //  берутся координаты
                    MarginValues[1] = (int)CellGrid[IndexX, IndexY].Model.Margin.Top;                 //  соседней уже отрисованной
                    MarginValues[2] = (int)CellGrid[IndexX, IndexY].Model.Margin.Right - CellHeight;  //  ячейки
                    MarginValues[3] = (int)CellGrid[IndexX, IndexY].Model.Margin.Bottom;              //  и смещаются на одну клетку

                    IndexX++;
                    CellGrid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[0], MarginValues[1], MarginValues[2], MarginValues[3]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexY++;
                }
            }
        }

        static public void SM_DeletingCells(int RowsCount, byte VoS)
        {
            /*
             *  Метод
             *
             *   удаления объектов
             *   картинок ячеек
             *   и расчёт их координат
             *
             *   при скроллинге перемещения
             *
             *   ( удаление тех клеток, что что попали за границу экрана )
             *
             *  ( вызывается метод
             *   в методе SM_Drawing
             *   класса Logic )
             *
             */

            int IndexX = (int)ScrollPosition.CameraPosition.X - 1;
            int IndexY = (int)ScrollPosition.CameraPosition.Y - 1;

            if (VoS == 1)
            {                  //  При перемещении    / ВНИЗ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.X - 1 + ((RowsCount * 2) + 1) > IndexX)
                {
                    if (CellGrid[IndexX, IndexY].Model != null) CellGrid[IndexX, IndexY].Model = null;

                    IndexX++;
                }
            }

            if (VoS == 2)
            {                  //  При перемещении    / ВЛЕВО
                IndexX = IndexX + RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.Y - 1 + ((RowsCount * 2) + 1) > IndexY)
                {
                    if (CellGrid[IndexX, IndexY].Model != null) CellGrid[IndexX, IndexY].Model = null;

                    IndexY++;
                }
            }

            if (VoS == 3)
            {                  //  При перемещении    / ВВЕРХ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY + RowsCount;

                while (ScrollPosition.CameraPosition.X - 1 + ((RowsCount * 2) + 1) > IndexX)
                {
                    if (CellGrid[IndexX, IndexY].Model != null) CellGrid[IndexX, IndexY].Model = null;

                    IndexX++;
                }
            }

            if (VoS == 4)
            {                  //  При перемещении    / ВПРАВО
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.CameraPosition.Y - 1 + ((RowsCount * 2) + 1) > IndexY)
                {
                    if (CellGrid[IndexX, IndexY].Model != null) CellGrid[IndexX, IndexY].Model = null;

                    IndexY++;
                }
            }
        }
    }
}