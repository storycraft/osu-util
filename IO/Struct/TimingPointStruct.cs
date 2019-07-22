using System.Runtime.InteropServices;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TimingPointStruct
    {
        [MarshalAs(UnmanagedType.R8)]
        public double Time;

        [MarshalAs(UnmanagedType.R8)]
        public double MsPerQuarter;

        [MarshalAs(UnmanagedType.I1)]
        public byte TimingChange;
    }
}