﻿using Game_of_Life.Cells;
using System;
using System.Windows;

namespace Game_of_Life.Options
{
    internal class Logic
    {
        static private uint RowsCount;
        static private uint cellhgh;
        static private uint IndexX, IndexY, value, valueconst;  //  рабочие переменные для элемента горизонтального массива, вертикального, инкремента цикла, его установки

        static public uint GetCellhgh() => cellhgh;

        static public uint GetRowsCount() => RowsCount;

        static public void Drawing()
        {
            /*
             * Метод отрисовки картинок
             */

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            if (SystemParameters.PrimaryScreenHeight > SystemParameters.PrimaryScreenWidth)
                cellhgh = Convert.ToUInt32(SystemParameters.PrimaryScreenHeight / (5 + ScrollPosition.GetAprx()));  //cellhgh = щширина экрана / (5*scrollposition.aprx)
            else cellhgh = Convert.ToUInt32(SystemParameters.PrimaryScreenWidth / (5 + ScrollPosition.GetAprx()));
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            IndexX = ScrollPosition.GetCameraX() - 1;
            IndexY = ScrollPosition.GetCameraY() - 1;

            /*
             *  если картинка не создана то создать
             *  установить растягиваемость
             *  и загрузить картинку
             */

            EmptyCell.SetGridImage(IndexX, IndexY);

            EmptyCell.SetImagePosition(IndexX, IndexY, cellhgh);

            valueconst = 3;

            while (valueconst < ScrollPosition.GetAprx() + 7)
            {
                value = valueconst;
                RowsCount = (valueconst - 1) / 2;
                IndexX = IndexX + RowsCount;
                IndexY = IndexY + RowsCount;
                while (value > 0)
                {
                    /*
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmptyCell.SetGridImage(IndexX, IndexY);

                    EmptyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmptyCell.NamesFormuleType.FT_DownFirst);

                    IndexX--;
                    value--;
                }

                IndexY--;
                value = valueconst - 1;

                while (value > 0)
                {
                    /*
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmptyCell.SetGridImage(IndexX, IndexY);

                    EmptyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmptyCell.NamesFormuleType.FT_LeftSecond);

                    IndexY--;
                    value--;
                }

                IndexX++;
                value = valueconst - 1;

                while (value > 0)
                {
                    /*
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmptyCell.SetGridImage(IndexX, IndexY);

                    EmptyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmptyCell.NamesFormuleType.FT_UpThreed);

                    IndexX++;
                    value--;
                }

                IndexY++;
                value = valueconst - 2;

                while (value > 0)
                {
                    /*
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmptyCell.SetGridImage(IndexX, IndexY);

                    EmptyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmptyCell.NamesFormuleType.FT_RightFourth);

                    IndexY++;
                    value--;
                }

                IndexX = ScrollPosition.GetCameraX() - 1;
                IndexY = ScrollPosition.GetCameraY() - 1;
                valueconst += 2;
            }
        }
        ////   КОНЕЦ ФУНКЦИИ     ///  DRAWING

        //-------------------------------------------------Перемещение камеры( SM - Scrolling of Move )-----------------------------------------------------------------\\

        public enum ScreenSideofDrawing
        {
            /*
             *  Перечисление
             *  для определения стороны экрана
             *  
             *  префикс SD_ 
             *   ( SD - Side of Drawing )
             */
             
            SD_BottomSide = 1,   //  низ
            SD_LeftSide = 2,   //  лево
            SD_TopSide = 3,    //  верх
            SD_RightSide = 4   //  право
        }
        
        static public void SM_Drawing(ScreenSideofDrawing VectorofScrolling, bool ReDraw)
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
            IndexX = ScrollPosition.GetCameraX() - 1;                                  //  
            IndexY = ScrollPosition.GetCameraY() - 1;                                  //  метода

            IndexX = IndexX - RowsCount;                                               //  ( задание начальных
            IndexY = IndexY - RowsCount;                                               //   значений переменных


            while ( ScrollPosition.GetCameraX() - 1 + RowsCount + 1  >  IndexX ) {                //  Перемещение
                while ( ScrollPosition.GetCameraY() - 1 + RowsCount + 1  >  IndexY) {             //
                                                                                                  //  камеры
                    EmptyCell.SM_OffsetingImages(IndexX, IndexY, cellhgh, VoS);        //

                    IndexY++;                                                                     //  ( клеток
                }                                                                                 //   в обратную
                IndexX++;                                                                         //   сторону )
                IndexY = IndexY - (2 * RowsCount) - 1;                                            //
            }


            if (ReDraw == true) {                           //  добавление и удаление картинок

                EmptyCell.SM_DeletingCells(RowsCount, VoS); //  удаление ячеек, что попали за границу экрана

                EmptyCell.SM_AddingCells(RowsCount, VoS);   //  отрисовка ячеек, что были за границей экрана
            }

        }
    }
}