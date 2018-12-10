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
        static private uint LeftofSet, RightofSet;
        static private uint TopofSet, DownofSet;

        //------------------------------------------------------------------------------------------------------------------------------------\\

        static public uint GetRightofSet() => RightofSet;

        static public uint GetLeftofSet() => LeftofSet;

        static public uint GetToptofSet() => TopofSet;

        static public uint GetDowntofSet() => DownofSet;

        static public byte GetAprX() => AprX;

        static public uint GetCameraX() => CameraX;
    
        static public uint GetCameraY() => CameraY;

        //------------------------------------------------------------------------------------------------------------------------------------\\
    }
}
