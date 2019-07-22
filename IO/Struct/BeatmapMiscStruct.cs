using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapMiscStruct
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool Unplayed;

        [MarshalAs(UnmanagedType.I8)]
        public long LastPlay;

        [MarshalAs(UnmanagedType.Bool)]
        public bool IsOsz2;
    }
}
