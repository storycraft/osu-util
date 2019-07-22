using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BeatmapInfoStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int BeatmapId;
        [MarshalAs(UnmanagedType.I4)]
        public int BeatmapSetId;
        [MarshalAs(UnmanagedType.I4)]
        public int ThreadId;
    }
}
