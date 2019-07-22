using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapSettingStruct
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsIgnoreBeatmapSound;
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsIgnoreBeatmapSkin;
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsStoryboardDisabled;
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsVideoDisabled;
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsVisualOverrided;

        [MarshalAs(UnmanagedType.I4)]
        public int Unknown2;

        [MarshalAs(UnmanagedType.I4)]
        public int ManiaScrollSpeed;
    }
}
