using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct BeatmapMiscStruct
    {
        [MarshalAs(UnmanagedType.I1)]
        public byte Unplayed;

        [MarshalAs(UnmanagedType.I8)]
        public long LastPlay;

        [MarshalAs(UnmanagedType.I1)]
        public byte IsOsz2;
    }
}
