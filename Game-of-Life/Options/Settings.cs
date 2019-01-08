using System;

namespace Game_of_Life.Options
{
    internal class Settings
    {
        /*
         *   Класс настроек
         *   
         *   Нужен для обращения к значениям настроек
         *   во время игры
         *   
         *   Например,
         *    ScrollMoveSpeed - скорость перемещения камеры
         *    во время игры переменная 
         *     прибавляется/отнимается к/от 
         *     переменным смещения камеры 
         *      ( Offset'ы в классе ScrollPosition )
         *    
         *    Значения загружаются и сохраняются в файл настроек 
         *     "Settings.bin"
         *   
         */

        static public uint ScrollMoveSpeed;
    }
}
