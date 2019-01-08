﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Game_of_Life.Options;

namespace Game_of_Life.Cells
{
    internal class EmptyCell
    {
        /*Класс пустой клетки.
         * Объект этого класса визуально будет
         * выступать в роли фоновых клеток
         * и невизульно содержать другие объекты вроде нейрона.
         */

        //-----------------------------<Объявление переменных>-------------------------------------\\

        private const int ArraySize = 150;     // для удобства хранит размер массива
        private int Value = 0;         // для удобства хранит кол-во созданных объектов этого класса
        private int x, y;
        static private EmptyCell[,] Grid = new EmptyCell[ArraySize, ArraySize];        // Один из важнейших массивов в игре. Хранит пустые клетки (для удобной работы)
        static private uint[] MarginValues = new uint[4];            // Массив хранящий координаты margin для установки их в объект при отрисовке
        private Image Model;                // Объект картинки. Нужен для визуального отображения пустой клетки

        private CellType Type;              // Объект перечисления, который хранит название типа хлетки, которая находится в этой (пустой) клетке

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

        public EmptyCell()   // Конструктор по умолчанию класса EmptyCell
        {
            Type = 0;   // Устанавливаем в тип клетки значение None
            Value++;
        }

        public EmptyCell(uint IndexX, uint IndexY)
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
                    Grid[IndexX, IndexY] = new EmptyCell();
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

            int TypeofFormule = (int)(FormuleType);

            if (TypeofFormule == 1)
            {
                MarginValues[1] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 + (CellHeight * RowsCount) - CellHeight * (CellsinRow - value) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));   //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((uint)(Convert.ToInt32(SystemParameters.PrimaryScreenHeight / 2) - Convert.ToInt32(CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset()));     //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 2)
            {
                MarginValues[1] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 - (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));       //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 + (CellHeight * RowsCount) - (CellHeight * (CellsinRow - value)) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset()));      //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 3)
            {
                MarginValues[1] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 - (CellHeight * RowsCount) + (CellHeight * (CellsinRow - value)) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));        //установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 - (CellHeight * RowsCount) + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset()));       //установка вертикальной координаты картинки центральной ячйеки

                MarginValues[3] = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (TypeofFormule == 4)
            {
                MarginValues[1] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenWidth / 2) - CellHeight / 2 + (CellHeight * RowsCount) + ScrollPosition.GetLeftOffset() - ScrollPosition.GetRightOffset()));//установка горизонтальной координаты картинки центральной ячйеки
                MarginValues[2] = unchecked((uint)((uint)(SystemParameters.PrimaryScreenHeight / 2) - CellHeight / 2 - (CellHeight * RowsCount) + (CellHeight * ((CellsinRow - 2) - value)) + CellHeight + ScrollPosition.GetTopOffset() - ScrollPosition.GetBottomOffset()));//установка вертикальной координаты картинки центральной ячйеки
                
                MarginValues[3] = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
                MarginValues[4] = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }
        }

        static public void SetImagePosition(uint IndexX, uint IndexY, uint CellHeight)
        {
            /*
             * Перегруженная функция.
             *
             * Нужна, чтобы отрисовать центральную ячейку,
             *
             * так как при её отрисовке имеются ещё не все значения, необходимые в аргументах оригинальной функции.
             */

            MarginValues[1] = Convert.ToUInt32((int)(SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2));
            MarginValues[2] = Convert.ToUInt32((int)(SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2));

            MarginValues[3] = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth - CellHeight - MarginValues[1]);
            MarginValues[4] = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight - CellHeight - MarginValues[2]);

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

        //--------------------------------------------------------------Перемещение камеры ( SM - ScrollingMove )------------------------------------------------------------------------------\\

        static public void SM_OffsetingImages(uint IndexX, uint IndexY, uint cellhgh, byte VoS)
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

            if (VoS == 1) {  //  при перемещении  / ВНИЗ

                MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left;
                MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top - Settings.ScrollMoveSpeed;
                MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right;
                MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom + Settings.ScrollMoveSpeed;

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (VoS == 2) {  //  при перемещении  / ВЛЕВО

                MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left + Settings.ScrollMoveSpeed;
                MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top;
                MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right - Settings.ScrollMoveSpeed;
                MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom;

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (VoS == 3) {  //  при перемещении  / ВВЕРХ

                MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left;
                MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top + Settings.ScrollMoveSpeed;
                MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right;
                MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom - Settings.ScrollMoveSpeed;

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }

            if (VoS == 4) {  //  при перемещении  / ВПРАВО

                MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left - Settings.ScrollMoveSpeed;
                MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top;
                MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right + Settings.ScrollMoveSpeed;
                MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom;

                Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
            }
        }

        static public void SM_AddingCells(uint RowsCount, byte VoS, uint CellHeight)
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

            uint IndexX = ScrollPosition.GetCameraX() - 1;
            uint IndexY = ScrollPosition.GetCameraY() - 1;


            if (VoS == 1) {                  //  При перемещении    / ВНИЗ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY + RowsCount;

                while (ScrollPosition.GetCameraX() - 1 + ((RowsCount * 2) + 1) > IndexX) {

                    if (Grid[IndexX, IndexY].Model == null)  Grid[IndexX, IndexY].Model = new Image();

                    IndexY--;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left;                  //  берутся координаты
                    MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top + CellHeight;      //  соседней уже отрисованной
                    MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right;                 //  ячейки 
                    MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom - CellHeight;   //  и смещаются на одну клетку

                    IndexY++;
                    Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexX++;
                }
            }


            if (VoS == 2) {                  //  При перемещении    / ВЛЕВО
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraY() - 1 + ((RowsCount * 2) + 1) > IndexY) {

                    if (Grid[IndexX, IndexY].Model == null)  Grid[IndexX, IndexY].Model = new Image();

                    IndexX++;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left - CellHeight;   //  берутся координаты
                    MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top;                 //  соседней уже отрисованной
                    MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right + CellHeight;  //  ячейки 
                    MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom;              //  и смещаются на одну клетку

                    IndexX--;
                    Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexY++;
                }
            }


            if (VoS == 3) {                  //  При перемещении    / ВВЕРХ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraX() - 1 + ((RowsCount * 2) + 1) > IndexX) {

                    if (Grid[IndexX, IndexY].Model == null)  Grid[IndexX, IndexY].Model = new Image();

                    IndexY++;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left;                  //  берутся координаты
                    MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top - CellHeight;      //  соседней уже отрисованной
                    MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right;                 //  ячейки 
                    MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom + CellHeight;   //  и смещаются на одну клетку

                    IndexY--;
                    Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexX++;
                }
            }


            if (VoS == 4) {                  //  При перемещении    / ВПРАВО
                IndexX = IndexX + RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraY() - 1 + ((RowsCount * 2) + 1) > IndexY) {

                    if (Grid[IndexX, IndexY].Model == null)  Grid[IndexX, IndexY].Model = new Image();

                    IndexX--;   //  начало расчёта координат новой отрисованной ячейки

                    MarginValues[1] = (uint)Grid[IndexX, IndexY].Model.Margin.Left + CellHeight;   //  берутся координаты
                    MarginValues[2] = (uint)Grid[IndexX, IndexY].Model.Margin.Top;                 //  соседней уже отрисованной
                    MarginValues[3] = (uint)Grid[IndexX, IndexY].Model.Margin.Right - CellHeight;  //  ячейки 
                    MarginValues[4] = (uint)Grid[IndexX, IndexY].Model.Margin.Bottom;              //  и смещаются на одну клетку

                    IndexX++;
                    Grid[IndexX, IndexY].Model.Margin = new Thickness(MarginValues[1], MarginValues[2], MarginValues[3], MarginValues[4]);
                    //  конец расчёта координат новой отрисованной ячейки

                    IndexY++;
                }
            }
        }

        static public void SM_DeletingCells(uint RowsCount, byte VoS)
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

            uint IndexX = ScrollPosition.GetCameraX() - 1;
            uint IndexY = ScrollPosition.GetCameraY() - 1;


            if (VoS == 1)
            {                  //  При перемещении    / ВНИЗ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraX() - 1 + ((RowsCount * 2) + 1) > IndexX)
                {

                    if (Grid[IndexX, IndexY].Model != null) Grid[IndexX, IndexY].Model = null;

                    IndexX++;
                }
            }


            if (VoS == 2)
            {                  //  При перемещении    / ВЛЕВО
                IndexX = IndexX + RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraY() - 1 + ((RowsCount * 2) + 1) > IndexY)
                {

                    if (Grid[IndexX, IndexY].Model != null) Grid[IndexX, IndexY].Model = null;

                    IndexY++;
                }
            }


            if (VoS == 3)
            {                  //  При перемещении    / ВВЕРХ
                IndexX = IndexX - RowsCount;
                IndexY = IndexY + RowsCount;

                while (ScrollPosition.GetCameraX() - 1 + ((RowsCount * 2) + 1) > IndexX)
                {

                    if (Grid[IndexX, IndexY].Model != null) Grid[IndexX, IndexY].Model = null;

                    IndexX++;
                }
            }


            if (VoS == 4)
            {                  //  При перемещении    / ВПРАВО
                IndexX = IndexX - RowsCount;
                IndexY = IndexY - RowsCount;

                while (ScrollPosition.GetCameraY() - 1 + ((RowsCount * 2) + 1) > IndexY)
                {

                    if (Grid[IndexX, IndexY].Model != null) Grid[IndexX, IndexY].Model = null;

                    IndexY++;
                }
            }
        }

    }
}