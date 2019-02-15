using System;
using System.Windows;
using System.Windows.Controls;

namespace Game_of_Life.Options
{
    internal class ScrollPosition
    {
        static public Point CameraPosition = new Point(127, 7);  //  позиция камеры
        static private byte Aprx = 4;            //  степень приближения в клетках (approximitation)
        static private int LeftOffset = 0, RightOffset  = 0;  //  Переменные смещения камеры              //  чтобы камера была
        static private int TopOffset  = 0, BottomOffset = 0;  //  служат для более точного определения    //  плавной, а не
        static private int AprxOffset = 0, DistOffset   = 0;  //  позиции камеры, чем по одной клетке     //  скакала по клеткам

        //--------------------------------------------------------------<Геттеры>-------------------------------------------------------------------------------\\

        static public int GetRightOffset() => RightOffset;

        static public int GetLeftOffset() => LeftOffset;

        static public int GetTopOffset() => TopOffset;

        static public int GetBottomOffset() => BottomOffset;

        static public byte GetAprx() => Aprx;

        static public int GetAprxOffset() => AprxOffset;

        static public int GetDistOffset() => DistOffset;

        //---------------------------------------------------------<Методы скроллинга>---------------------------------------------------------------------------\\

        /*
         *  Методы скроллинга
         *
         *  Нужны для:
         *      отдаления
         *          /
         *      приближения
         *          /
         *      перемещения
         *
         *      камеры
         *
         */

        //---------------------------------------------------<Приближение>------------------------------------------------------------\\

        static public void ScrollingApproximation(Grid grid)
        {
            /*
             *  Метод приближения камеры
             *
             *  Увеличивает масштаб карты
             *
             */

            if (DistOffset < 1)
            {
                if (AprxOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                {
                    DistOffset = Logic.GetCellhgh() - AprxOffset;
                    AprxOffset = 0;
                    Aprx--;
                    Logic.DeleteOutEmptyCell();
                }
                else
                {
                    AprxOffset += Settings.ScrollDistSpeed;
                }
            }
            else
            {
                if (DistOffset > Settings.ScrollDistSpeed)
                {
                    DistOffset -= Settings.ScrollDistSpeed;
                }
                else
                {
                    AprxOffset = Settings.ScrollDistSpeed - DistOffset;
                    DistOffset = 0;
                }
            }

            Logic.SetCellhghOffsets();
            Logic.Drawing(grid);
        }

        //---------------------------------------------<Отдаление>----------------------------------------------------------------\\

        static public void ScrollingDistancing(Grid grid)
        {
            /*
             *  Метод отдаления камеры
             *
             *  Уменьшает масштаб карты
             *
             */

            if (AprxOffset < 1)
            {
                if (DistOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                {
                    AprxOffset = Logic.GetCellhgh() - DistOffset;
                    DistOffset = 0;
                    Aprx++;
                }
                else
                {
                    DistOffset += Settings.ScrollDistSpeed;
                }
            }
            else
            {
                if (AprxOffset > Settings.ScrollDistSpeed)
                {
                    AprxOffset -= Settings.ScrollDistSpeed;
                }
                else
                {
                    DistOffset = Settings.ScrollDistSpeed - AprxOffset;
                    AprxOffset = 0;
                }
            }

            Logic.SetCellhghOffsets();
            Logic.Drawing(grid);
        }

        //------------------------------------------------------<Перемещение>------------------------------------------------------------------\\

        static public void ScrollingMove(Point CursorPosition)
        {
            /*
             *  Метод перемещения
             *
             *  Перемещает камеру в сторону
             *    ( клетки в обратную )
             *  , на которую "давит" курсор
             *
             *  для вызова внутри него - методы с префиксом SM_
             *   ( SM - Scrolling Move )
             *
             */      /////   не закончено -
                     //   Код был проанализирован логически только в первоначальном варианте ( перемещение влево )
                     //   в остальных случаях он был скопирован и заменены только названия ( Top, Left, Right, Bottom )

            //---------------<Перемещение>--<Вниз>--------------------\\
            if (CursorPosition.Y > SystemParameters.PrimaryScreenHeight - 2) {
                
                if (TopOffset < 1) {
                    BottomOffset = BottomOffset + Settings.ScrollMoveSpeed;

                    if (BottomOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                    {
                        TopOffset = Convert.ToInt32(Logic.GetCellhgh() - BottomOffset);
                        BottomOffset = 0;
                        CameraPosition.X--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, true);
                    }
                    else
                    {
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, false);
                    }
                }
                else
                {
                    if (TopOffset > Settings.ScrollMoveSpeed)
                    {
                        TopOffset = TopOffset - Settings.ScrollMoveSpeed;
                    }
                    else
                    {
                        BottomOffset = Settings.ScrollMoveSpeed - TopOffset;
                        TopOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, false);
                }
            }

            //---------------<Перемещение>--<Влево>--------------------\\
            if (CursorPosition.X < 2) {

                if (RightOffset < 1) {

                    LeftOffset = LeftOffset + Settings.ScrollMoveSpeed;

                    if (LeftOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                    {
                        RightOffset = Convert.ToInt32(Logic.GetCellhgh() - LeftOffset);
                        LeftOffset = 0;
                        CameraPosition.X--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, true);
                    }
                    else
                    {
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, false);
                    }
                }
                else
                {
                    if (RightOffset > Settings.ScrollMoveSpeed)
                    {
                        RightOffset = RightOffset - Settings.ScrollMoveSpeed;
                    }
                    else
                    {
                        LeftOffset = Settings.ScrollMoveSpeed - RightOffset;
                        RightOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, false);
                }
            }

            //---------------<Перемещение>--<Вверх>--------------------\\
            if (CursorPosition.Y < 2) {

                if (BottomOffset < 1) {
                    TopOffset = TopOffset + Settings.ScrollMoveSpeed;

                    if (TopOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                    {
                        BottomOffset = Convert.ToInt32(Logic.GetCellhgh() - TopOffset);
                        TopOffset = 0;
                        CameraPosition.X--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, true);
                    }
                    else
                    {
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, false);
                    }
                }
                else
                {
                    if (BottomOffset > Settings.ScrollMoveSpeed)
                    {
                        BottomOffset = BottomOffset - Settings.ScrollMoveSpeed;
                    }
                    else
                    {
                        TopOffset = Settings.ScrollMoveSpeed - BottomOffset;
                        BottomOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, false);
                }
            }

            //---------------<Перемещение>--<Вправо>--------------------\\
            if (CursorPosition.X > SystemParameters.PrimaryScreenWidth - 2) {
                
                if (LeftOffset < 1) {

                    RightOffset = RightOffset + Settings.ScrollMoveSpeed;

                    if (RightOffset > Convert.ToInt32(Logic.GetCellhgh() / 2))
                    {
                        LeftOffset = Convert.ToInt32(Logic.GetCellhgh() - RightOffset);
                        RightOffset = 0;
                        CameraPosition.X--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, true);
                    }
                    else
                    {
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, false);
                    }
                }
                else
                {
                    if (LeftOffset > Settings.ScrollMoveSpeed)
                    {
                        LeftOffset = LeftOffset - Settings.ScrollMoveSpeed;
                    }
                    else
                    {
                        RightOffset = Settings.ScrollMoveSpeed - LeftOffset;
                        LeftOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, false);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------\\ 
    }
}