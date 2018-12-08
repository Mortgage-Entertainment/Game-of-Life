﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_of_Life
{
    class Logic
    {
        static void Drawing()
        {
            uint IndexX, IndexY, value, valueconst;   //рабочие переменные для элемента горизонтального массива, вертикального, инкремент цикла, его установка
                                                      //cellhgh = щширина экрана / (5*scrollposition.aprx)


            IndexX = ScrollPosition.CameraX - 1;
            IndexY = ScrollPosition.CameraY - 1;

            /*  
             *  если картинка не создана то создать
             *  установить растягиваемость
             *  и загрузить картинку
             */

            //  EmtyCell.Grid[IndexX, IndexY].Imaжka.Shirina = cellhgh;
            //  EmtyCell.Grid[IndexX, IndexY].Imaжka.Visota = cellhgh;

            // EmtyCell.Grid[IndexX, IndexY].Imaжka.Left = (ShirinaEcrana / 2) - (cellhgh / 2) + (cellhgh * RowsCount) + scrlpos.leftoffset - scrlpos.rightoffset;
            // EmtyCell.Grid[IndexX, IndexY].Imaжka.Top = (VisotaEcrana / 2) - (cellhgh / 2) + (cellhgh * RowsCount) + scrlpos.topoffset - scrlpos.downoffset;

            valueconst = 3;

            while (valueconst < ScrollPosition.aprx + 7)
            {
                value = valueconst;
                RowsCount = (valueconst - 1) / 2;
                IndexX = IndexX + RowsCount;
                IndexY = IndexY + RowsCount;
                while ()
                {
                    /*  
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Height = cellhgh;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Width = cellhgh;

                    // EmtyCell.Grid[IndexX, IndexY].Imaжka.Left = (ShirinaEcrana / 2) - (cellhgh / 2) + (cellhgh * RowsCount) - (cellhgh* (work2 - work3)) + scrlpos.leftoffset - scrlpos.rightoffset;
                    // EmtyCell.Grid[IndexX, IndexY].Imaжka.Top = (VisotaEcrana / 2) - (cellhgh / 2) + (cellhgh * RowsCount) + scrlpos.topoffset - scrlpos.downoffset;

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

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Height = cellhgh;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Widht = cellhgh;

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Left = (ShirinaEcrana / 2) - (cellhgh / 2) + (cellhgh * RowsCount) + scrlpos.leftoffset - scrlpos.rightoffset;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Right = (VisotaEcrana / 2) - (cellhgh / 2) - (cellhgh * RowsCount) - (cellhgh * (work2 - work3)) + scrlpos.topoffset - scrlpos.downoffset;

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

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Width = cellhgh;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Height = cellhgh;

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Left = (ShirinaEcrana / 2) * (cellhgh / 2) - (cellhgh * RowsCount) + (cellhgh * ((work2) - work3)) + scrlpos.leftoffset - scrlpos.rightoffset;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Top = (VisotaEcrana / 2) * (cellhgh / 2) - (cellhgh * RowsCount) + scrlpos.topoffset - scrlpos.downoffset;

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

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Width = cellhgh;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Height = cellhgh;

                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Left = (ShirinaEcrana / 2) * (cellhgh / 2) + (cellhgh * RowsCount) + scrlpos.leftoffset - scrlpos.rightoffset;
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Top = (VisotaEcrana / 2) * (cellhgh / 2) - (cellhgh * RowsCount) + (cellhgh * ((work2 - 2) - work3)) + cellhgh + scrlpos.topoffset - scrlpos.downoffset;

                    IndexY++;
                    value--;
                }

                IndexX = ScrollPosition.CameraX - 1;
                IndexY = ScrollPosition.CameraY - 1;
                valueconst += 2;
            }





        }
    }
}

