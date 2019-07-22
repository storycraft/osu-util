using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BeatmapElementCountStruct
    {
        [MarshalAs(UnmanagedType.I2)]
        public short HitcircleCount;
        [MarshalAs(UnmanagedType.I2)]
        public short SliderCount;
        [MarshalAs(UnmanagedType.I2)]
        public short SpinnerCount;
    }
}
