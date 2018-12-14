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

        static public void Drawing()
        {
            /*
             * Метод отрисовки картинок
             */

           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            uint IndexX, IndexY, value, valueconst;   //рабочие переменные для элемента горизонтального массива, вертикального, инкремент цикла, его установка
            int cellhgh;

            if (SystemParameters.PrimaryScreenHeight > SystemParameters.PrimaryScreenWidth)
                cellhgh = Convert.ToInt32(SystemParameters.PrimaryScreenHeight / (5 * ScrollPosition.GetAprX()));  //cellhgh = щширина экрана / (5*scrollposition.aprx)
                else cellhgh = Convert.ToInt32(SystemParameters.PrimaryScreenWidth / (5 * ScrollPosition.GetAprX()));
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\

            IndexX = ScrollPosition.GetCameraX() - 1;
            IndexY = ScrollPosition.GetCameraY() - 1;

            /*  
             *  если картинка не создана то создать
             *  установить растягиваемость
             *  и загрузить картинку
             */

            EmtyCell.SetGridImage(IndexX, IndexY);

            EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh);

            valueconst = 3;

            while (valueconst < ScrollPosition.GetAprX() + 7)
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

                    EmtyCell.SetGridImage(IndexX, IndexY);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmtyCell.NamesFormuleType.FT_DownFirst);

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

                    EmtyCell.SetGridImage(IndexX, IndexY);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmtyCell.NamesFormuleType.FT_LeftSecond);

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

                    EmtyCell.SetGridImage(IndexX, IndexY);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmtyCell.NamesFormuleType.FT_UpThreed);

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

                    EmtyCell.SetGridImage(IndexX, IndexY);

                    EmtyCell.SetImagePosition(IndexX, IndexY, cellhgh, RowsCount, valueconst, value, EmtyCell.NamesFormuleType.FT_RightFourth);

                    IndexY++;
                    value--;
                }

                IndexX = ScrollPosition.GetCameraX() - 1;
                IndexY = ScrollPosition.GetCameraY() - 1;
                valueconst += 2;
            }
        }

        static public void GridInitialization()
        {
            /*
             * Метод, инициализирующий 
             * элементы массива Grid
             */
        }
    }
}

