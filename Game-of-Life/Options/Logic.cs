using System;
using System.Windows;
using System.Windows.Controls;
using Game_of_Life.Cells;

namespace Game_of_Life.Options
{
    internal class Logic
    {
        static private int RowsCount;
        static private int cellhgh;
        static private int cellhghVisual;  //  переменная, хранящая размер картинки клетки с учётом смещения изображения
        static private int cellhghOffsetAprx = 0;  //  переменные смещения изображения клетки
        static private int cellhghOffsetDist = 0;  //  нужны для плавной камеры
        static private int IndexX, IndexY, value, valueconst;  //  рабочие переменные для элемента горизонтального массива, вертикального, инкремента цикла, его установки

        static public int GetCellhgh() => cellhgh;

        static public int GetRowsCount() => RowsCount;

        //-----------------------------------------------------------------------------------------------------------------------------------\\
        public enum ScreenSideofDrawing
        {
            /*
             *  Перечисление
             *  для определения стороны экрана
             *
             *  префикс SD_
             *   ( SD - Side of Drawing )
             */

            SD_BottomSide = 1, //  низ
            SD_LeftSide = 2,   //  лево
            SD_TopSide = 3,    //  верх
            SD_RightSide = 4   //  право
        }

        //----------------------------------------------------------------------------------------------------------------------------------\\

        static public void Drawing(Grid grid)
        {
            /*
             *  Метод отрисовки картинок
             *  ячеек на старте игры
             *  и при скроллинге
             *    приближения и отдаления
             */

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            if (SystemParameters.PrimaryScreenHeight > SystemParameters.PrimaryScreenWidth)
                cellhgh = Convert.ToInt32(SystemParameters.PrimaryScreenHeight / (5 + ScrollPosition.GetAprx()));  //cellhgh = ширина экрана / (5*scrollposition.aprx)
            else cellhgh = Convert.ToInt32(SystemParameters.PrimaryScreenWidth / (5 + ScrollPosition.GetAprx()));

            cellhghVisual = cellhgh - cellhghOffsetDist + cellhghOffsetAprx;

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            IndexX = (int)(ScrollPosition.CameraPosition.X - 1);
            IndexY = (int)(ScrollPosition.CameraPosition.Y - 1);

            EmptyCells.SetGridImage(IndexX, IndexY, grid);

            EmptyCells.SetImagePosition(IndexX, IndexY, cellhgh);

            valueconst = 3;

            while (valueconst < ScrollPosition.GetAprx() + 7)
            {
                value = valueconst;
                RowsCount = (valueconst - 1) / 2;
                IndexX = IndexX + RowsCount;
                IndexY = IndexY + RowsCount;
                while (value > 0)
                {
                    EmptyCells.SetGridImage(IndexX, IndexY, grid);

                    EmptyCells.SetImagePosition(IndexX, IndexY, cellhghVisual, RowsCount, valueconst, value, ScreenSideofDrawing.SD_BottomSide);

                    IndexX--;
                    value--;
                }

                IndexY--;
                value = valueconst - 1;

                while (value > 0)
                {
                    EmptyCells.SetGridImage(IndexX, IndexY, grid);

                    EmptyCells.SetImagePosition(IndexX, IndexY, cellhghVisual, RowsCount, valueconst, value, ScreenSideofDrawing.SD_LeftSide);

                    IndexY--;
                    value--;
                }

                IndexX++;
                value = valueconst - 1;

                while (value > 0)
                {
                    EmptyCells.SetGridImage(IndexX, IndexY, grid);

                    EmptyCells.SetImagePosition(IndexX, IndexY, cellhghVisual, RowsCount, valueconst, value, ScreenSideofDrawing.SD_RightSide);

                    IndexX++;
                    value--;
                }

                IndexY++;
                value = valueconst - 2;

                while (value > 0)
                {
                    EmptyCells.SetGridImage(IndexX, IndexY, grid);

                    EmptyCells.SetImagePosition(IndexX, IndexY, cellhghVisual, RowsCount, valueconst, value, ScreenSideofDrawing.SD_TopSide);

                    IndexY++;
                    value--;
                }

                IndexX = (int)(ScrollPosition.CameraPosition.X - 1);
                IndexY = (int)(ScrollPosition.CameraPosition.Y - 1);
                valueconst += 2;
            }
        }

        ////   КОНЕЦ ФУНКЦИИ     ///  DRAWING

        //------------------------------------------------<Скроллинг приближения и отдаления>----------------------------------------------------------------------\\

        static public void DeleteOutEmptyCell()
        {
            /*
             *  Метод удаления изображений
             *  клеток из ряда,
             *  ушедшего за край экрана
             *  при приближении камеры
             */

            valueconst = (RowsCount * 2) + 1 + 2;
            value = valueconst;
            IndexX = IndexX + RowsCount + 1;
            IndexY = IndexY + RowsCount + 1;

            while (value > 0)
            {
                EmptyCells.CellGrid[IndexX, IndexY].Model = null;

                IndexX--;
                value--;
            }

            IndexY--;
            value = valueconst - 1;

            while (value > 0)
            {
                EmptyCells.CellGrid[IndexX, IndexY].Model = null;

                IndexY--;
                value--;
            }

            IndexX++;
            value = valueconst - 1;

            while (value > 0)
            {
                EmptyCells.CellGrid[IndexX, IndexY].Model = null;

                IndexX++;
                value--;
            }

            IndexY++;
            value = valueconst - 2;

            while (value > 0)
            {
                EmptyCells.CellGrid[IndexX, IndexY].Model = null;

                IndexY++;
                value--;
            }
        }

        static public void SetCellhghOffsets()
        {
            int ScrnSize;
            if (SystemParameters.PrimaryScreenHeight > SystemParameters.PrimaryScreenWidth)
                ScrnSize = (int)SystemParameters.PrimaryScreenHeight;
            else
                ScrnSize = (int)SystemParameters.PrimaryScreenWidth;

            if (cellhghOffsetAprx > 0)
                cellhghOffsetAprx = Convert.ToInt32(cellhgh / (ScrnSize / ScrollPosition.GetAprxOffset()));

            if (cellhghOffsetAprx > 0)
                cellhghOffsetDist = Convert.ToInt32(cellhgh / (ScrnSize / ScrollPosition.GetAprxOffset()));
        }

        //-------------------------------------------------<Перемещение камеры( SM - Scrolling of Move )>-----------------------------------------------------------------\\

        static public void SM_Drawing(ScreenSideofDrawing VectorofScrolling, bool ReDraw, Grid grid)
        {
            /*
             *  Метод перерисовки клеток
             *  при
             *
             *   скроллинге перемещения
             *
             *    ( метод ScrollingMove в классе ScrollPosition )
             *
             */

            byte VoS = (byte)VectorofScrolling;                                        //  Подготовка
            IndexX = (int)(ScrollPosition.CameraPosition.X - 1);                                  //
            IndexY = (int)(ScrollPosition.CameraPosition.Y - 1);                                  //  метода

            IndexX = IndexX - RowsCount;                                               //  ( задание начальных
            IndexY = IndexY - RowsCount;                                               //   значений переменных

            while (ScrollPosition.CameraPosition.X - 1 + RowsCount + 1 > IndexX)
            {                //  Перемещение
                while (ScrollPosition.CameraPosition.Y - 1 + RowsCount + 1 > IndexY)
                {             //
                              //  камеры
                    EmptyCells.SM_OffsetingImages(IndexX, IndexY, cellhgh, VoS);        //

                    IndexY++;                                                                     //  ( клеток
                }                                                                                 //   в обратную
                IndexX++;                                                                         //   сторону )
                IndexY = IndexY - (2 * RowsCount) - 1;                                            //
            }

            if (ReDraw == true)
            {                           //  добавление и удаление картинок
                EmptyCells.SM_DeletingCells(RowsCount, VoS); //  удаление ячеек, что попали за границу экрана

                EmptyCells.SM_AddingCells(RowsCount, VoS, cellhgh, grid);   //  отрисовка ячеек, что были за границей экрана
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------\\
    }
}