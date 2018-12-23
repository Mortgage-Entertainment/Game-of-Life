using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_of_Life
{
    class ScrollPosition
    {
        static private uint CameraX = 127, CameraY = 7;
        static private byte Aprx = 4;            // степень приближения в клетках (approximitation)
        static private uint LeftOffset = 0, RightOffset = 0;
        static private uint TopOffset = 0, DownOffset = 0;

        //-----------------------------------------------------<Геттеры>----------------------------------------------------------------------\\

        static public uint GetRightOffset() => RightOffset;

        static public uint GetLeftOffset() => LeftOffset;

        static public uint GetTopOffset() => TopOffset;

        static public uint GetDownOffset() => DownOffset;

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

            static public void ScrollingMove()
            {
                /*
                 *  Метод перемещения
                 * 
                 *  Перемещает камеру в сторону
                 *    ( клетки в обратную )
                 *  , на которую "давит" курсор 
                 *  
                 */

                ///  Перемещение   // Вверх
                if (Cursor.Position.Y < 2) {

                    if (RightOffset < 1) {
                        
                        LeftOffset = LeftOffset + ScrollMoveSpeed;
                        
                        if (LeftOffset > Convert.ToInt32(Logic.GetCellhgh() / 2)) {
                            RightOffset = Convert.ToUInt32(Logic.GetCellhgh() - LeftOffset);
                            LeftOffset = 0;
                            CameraX--;
                        }

                        Logic.ScrollingMoveDrawing();

                    } else {
                        
                        if (RightOffset > ScrollMoveSpeed) {
                            RightOffset = RightOffset - ScrollMoveSpeed;
                        } else {
                            LeftOffset = ScrollMoveSpeed - RightOffset;
                            RightOffset = 0;
                        }

                        Logic.ScrollingMoveDrawing();

                    }

                }
                
                ///  Перемещение   // Влево
                if (Cursor.Position.X < 2) {
                    
                }

                ///  Перемещение   // Вправо
                if (Cursor.Position.X > SystemParameters.PrimaryScreenWidth - 2) {
                    
                }
                
                ///  Перемещение   // Вниз
                if (Cursor.Position.Y > SystemParameters.PrimaryScreenHeight - 2) {
                    
                }
            } 
            
            //------------------------------------------------------------------------------------------------------------------------------------\\ */

    }
}
