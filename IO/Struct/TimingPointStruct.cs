using System.Runtime.InteropServices;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TimingPointStruct
    {
        [MarshalAs(UnmanagedType.R8)]
        public double Time;

        [MarshalAs(UnmanagedType.R8)]
        public double MsPerQuarter;

        [MarshalAs(UnmanagedType.Bool)]
        public bool TimingChange;
    }
}