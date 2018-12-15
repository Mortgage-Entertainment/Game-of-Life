using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class ScrollPosition
    {
        static private uint CameraX = 127, CameraY = 7;
        static private byte AprX = 4;            // степень приближения в клетках (approximitation)
        static private uint LeftOffset = 0, RightOffset = 0;
        static private uint TopOffset = 0, DownOffset = 0;

        //-----------------------------------------------------<Геттеры>----------------------------------------------------------------------\\

        static public uint GetRightOffset() => RightOffset;

        static public uint GetLeftOffset() => LeftOffset;

        static public uint GetTopOffset() => TopOffset;

        static public uint GetDownOffset() => DownOffset;

        static public byte GetAprX() => AprX;

        static public uint GetCameraX() => CameraX;
    
        static public uint GetCameraY() => CameraY;

        //------------------------------------------------------------------------------------------------------------------------------------\\
    }
}
