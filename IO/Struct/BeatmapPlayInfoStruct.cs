using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapPlayInfoStruct
    {
        [MarshalAs(UnmanagedType.R8)]
        public double ApproachRate;
        [MarshalAs(UnmanagedType.R8)]
        public double CircieSize;
        [MarshalAs(UnmanagedType.R8)]
        public double HPDrain;
        [MarshalAs(UnmanagedType.R8)]
        public double OverallDiffculty;
        [MarshalAs(UnmanagedType.R8)]
        public double SliderVelocity;
    }
}
