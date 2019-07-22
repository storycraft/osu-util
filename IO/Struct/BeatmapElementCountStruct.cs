using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapElementCountStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int HitcircleCount;
        [MarshalAs(UnmanagedType.I4)]
        public int SliderCount;
        [MarshalAs(UnmanagedType.I4)]
        public int SpinnerCount;
    }
}
