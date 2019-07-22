using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BeatmapPlaymodeStruct
    {
        [MarshalAs(UnmanagedType.I2)]
        public short LocalOffset;

        [MarshalAs(UnmanagedType.R4)]
        public float StackLeniency;

        [MarshalAs(UnmanagedType.I1)]
        public byte GameplayMode;
    }
}
