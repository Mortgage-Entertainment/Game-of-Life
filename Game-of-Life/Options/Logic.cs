using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game_of_Life.Cells;

namespace Game_of_Life
{
    class Logic
    {
        static private uint RowsCount;

        static void Drawing()
        {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            uint IndexX, IndexY, value, valueconst;   //рабочие переменные для элемента горизонтального массива, вертикального, инкремент цикла, его установка
            double cellhgh = (SystemParameters.PrimaryScreenHeight / (5 * ScrollPosition.GetAprX()));  //cellhgh = щширина экрана / (5*scrollposition.aprx)

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            IndexX = ScrollPosition.GetCameraX() - 1;
            IndexY = ScrollPosition.GetCameraY() - 1;

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

            while (valueconst < ScrollPosition.GetAprX() + 7)
            {
                value = valueconst;
                RowsCount = (valueconst - 1) / 2;
                IndexX = IndexX + RowsCount;
                IndexY = IndexY + RowsCount;
                while ()        /*Аргумент*/
                {
                    /*  
                     *  если картинка не создана то создать
                     *  установить растягиваемость
                     *  и загрузить картинку
                     */

                    EmtyCell.SetGridImageSize(IndexX, IndexY, cellhgh);

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

                    EmtyCell.SetGridImageSize(IndexX, IndexY, cellhgh);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value);
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

                    EmtyCell.SetGridImageSize(IndexX, IndexY, cellhgh);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value);

                    /* может пригодиться
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Left = (SystemParameters.PrimaryScreenHeight / 2) * (cellhgh / 2) - (cellhgh * RowsCount) + (cellhgh * ((valueconst) - value)) + ScrollPosition.GetLeftofSet() - ScrollPosition.GetRightofSet();
                    EmptyCell.Grid[IndexX, IndexY].Imaжka.Top = (SystemParameters.PrimaryScreenWidth / 2) * (cellhgh / 2) - (cellhgh * RowsCount) + ScrollPosition.GetToptofSet() - ScrollPosition.GetDowntofSet();
                    */

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

                    EmtyCell.SetGridImageSize(IndexX, IndexY, cellhgh);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value);

                    IndexY++;
                    value--;
                }

                IndexX = ScrollPosition.GetCameraX() - 1;
                IndexY = ScrollPosition.GetCameraY() - 1;
                valueconst += 2;
            }
        }
    }
}

