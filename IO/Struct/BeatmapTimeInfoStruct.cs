using System.Runtime.InteropServices;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BeatmapTimeInfo
    {
        [MarshalAs(UnmanagedType.I4)]
        public int DrainTime;
        [MarshalAs(UnmanagedType.I4)]
        public int TotalTime;
        [MarshalAs(UnmanagedType.I4)]
        public int PreviewStart;
    }
}