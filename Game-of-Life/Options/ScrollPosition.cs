using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class ScrollPosition
    {
        static private uint CameraX, CameraY;
        static private byte AprX;  // степень приближения в клетках (approximitation)
        static private uint LeftOffset, RightOffset;
        static private uint TopOffset, DownOffset;

        //------------------------------------------------------------------------------------------------------------------------------------\\

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
