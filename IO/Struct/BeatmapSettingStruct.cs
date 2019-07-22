using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct BeatmapSettingStruct
    {
        [MarshalAs(UnmanagedType.I1)]
        public byte IsIgnoreBeatmapSound;
        [MarshalAs(UnmanagedType.I1)]
        public byte IsIgnoreBeatmapSkin;
        [MarshalAs(UnmanagedType.I1)]
        public byte IsStoryboardDisabled;
        [MarshalAs(UnmanagedType.I1)]
        public byte IsVideoDisabled;
        [MarshalAs(UnmanagedType.I1)]
        public byte IsVisualOverrided;

        [MarshalAs(UnmanagedType.I4)]
        public int LastModification;

        [MarshalAs(UnmanagedType.I1)]
        public byte ManiaScrollSpeed;
    }
}
