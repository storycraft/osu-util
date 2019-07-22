using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapPlaymodeStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int LocalOffset;

        [MarshalAs(UnmanagedType.R8)]
        public double StackLeniency;

        [MarshalAs(UnmanagedType.I1)]
        public byte GameplayMode;
    }
}
