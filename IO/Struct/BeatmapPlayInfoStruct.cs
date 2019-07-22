using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct BeatmapPlayInfoStruct
    {
        [MarshalAs(UnmanagedType.R4)]
        public float ApproachRate;
        [MarshalAs(UnmanagedType.R4)]
        public float CircieSize;
        [MarshalAs(UnmanagedType.R4)]
        public float HPDrain;
        [MarshalAs(UnmanagedType.R4)]
        public float OverallDiffculty;
        [MarshalAs(UnmanagedType.R8)]
        public double SliderVelocity;
    }
}
