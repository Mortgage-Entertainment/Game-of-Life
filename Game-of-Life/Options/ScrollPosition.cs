using System;
using System.Windows;

namespace Game_of_Life.Options
{
    internal class ScrollPosition
    {
        static private uint CameraX = 127, CameraY = 7;
        static private byte Aprx = 4;            // степень приближения в клетках (approximitation)
        static private uint LeftOffset = 0, RightOffset = 0;
        static private uint TopOffset = 0, BottomOffset = 0;

        //-----------------------------------------------------<Геттеры>----------------------------------------------------------------------\\

        static public uint GetRightOffset() => RightOffset;

        static public uint GetLeftOffset() => LeftOffset;

        static public uint GetTopOffset() => TopOffset;

        static public uint GetBottomOffset() => BottomOffset;

        static public byte GetAprx() => Aprx;

        static public uint GetCameraX() => CameraX;

        static public uint GetCameraY() => CameraY;

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

        //-------------------------------------------------------<Приближение>---------------------------------------------------------------\\

        static public void ScrollingApproximation()
        {
            /*
             *  Метод приближения камеры
             *
             *  Увеличивает масштаб карты
             *
             */

            Aprx--;
            Logic.Drawing();
        }

        //---------------------------------------------------------<Отдаление>----------------------------------------------------------------------\\

        static public void ScrollingDistancing()
        {
            /*
             *  Метод отдаления камеры
             *
             *  Уменьшает масштаб карты
             *
             */

            Aprx++;
            Logic.Drawing();
        }

        //-------------------------------------------------------------<Перемещение>-----------------------------------------------------------------------\\

        static public void ScrollingMove(uint CursorPositionX, uint CursorPositionY)
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


            ////  Перемещение   // Вниз
            if (CursorPositionY > SystemParameters.PrimaryScreenHeight - 2) {
                
                if (TopOffset < 1) {
                    BottomOffset = BottomOffset + Settings.ScrollMoveSpeed;

                    if (BottomOffset > Convert.ToInt32(Logic.GetCellhgh() / 2)) {

                        TopOffset = Convert.ToUInt32(Logic.GetCellhgh() - BottomOffset);
                        BottomOffset = 0;
                        CameraX--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, true);

                    } else {

                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, false);
                    }


                } else {

                    if (TopOffset > Settings.ScrollMoveSpeed) {

                        TopOffset = TopOffset - Settings.ScrollMoveSpeed;

                    } else {

                        BottomOffset = Settings.ScrollMoveSpeed - TopOffset;
                        TopOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_BottomSide, false);
                }
            }


            ////  Перемещение   // Влево
            if (CursorPositionX < 2) {

                if (RightOffset < 1) {

                    LeftOffset = LeftOffset + Settings.ScrollMoveSpeed;

                    if (LeftOffset > Convert.ToInt32(Logic.GetCellhgh() / 2)) {

                        RightOffset = Convert.ToUInt32(Logic.GetCellhgh() - LeftOffset);
                        LeftOffset = 0;
                        CameraX--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, true);

                    } else {

                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, false);
                    }
                    
                } else {

                    if (RightOffset > Settings.ScrollMoveSpeed) {

                        RightOffset = RightOffset - Settings.ScrollMoveSpeed;

                    } else {

                        LeftOffset = Settings.ScrollMoveSpeed - RightOffset;
                        RightOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_LeftSide, false);
                }
            }


            ////  Перемещение   // Вверх
            if (CursorPositionY < 2) {

                if (BottomOffset < 1) {
                    TopOffset = TopOffset + Settings.ScrollMoveSpeed;

                    if (TopOffset > Convert.ToInt32(Logic.GetCellhgh() / 2)) {

                        BottomOffset = Convert.ToUInt32(Logic.GetCellhgh() - TopOffset);
                        TopOffset = 0;
                        CameraX--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, true);

                    } else {

                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, false);
                    }


                } else {

                    if (BottomOffset > Settings.ScrollMoveSpeed) {

                        BottomOffset = BottomOffset - Settings.ScrollMoveSpeed;

                    } else {

                        TopOffset = Settings.ScrollMoveSpeed - BottomOffset;
                        BottomOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_TopSide, false);
                }
            }


            ////  Перемещение   // Впарво
            if (CursorPositionX > SystemParameters.PrimaryScreenWidth - 2) {
                
                if (LeftOffset < 1) {

                    RightOffset = RightOffset + Settings.ScrollMoveSpeed;

                    if (RightOffset > Convert.ToInt32(Logic.GetCellhgh() / 2)) {

                        LeftOffset = Convert.ToUInt32(Logic.GetCellhgh() - RightOffset);
                        RightOffset = 0;
                        CameraX--;
                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, true);

                    } else {

                        Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, false);
                    }
                    
                } else {

                    if (LeftOffset > Settings.ScrollMoveSpeed) {

                        LeftOffset = LeftOffset - Settings.ScrollMoveSpeed;

                    } else {

                        RightOffset = Settings.ScrollMoveSpeed - LeftOffset;
                        LeftOffset = 0;
                    }

                    Logic.SM_Drawing(Logic.ScreenSideofDrawing.SD_RightSide, false);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------\\ */
    }
}