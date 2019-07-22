using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.DataBase.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OsuDbInfoStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int Version;

        [MarshalAs(UnmanagedType.I4)]
        public int FolderCount;

        [MarshalAs(UnmanagedType.Bool)]
        public bool AccountLocked;

        [MarshalAs(UnmanagedType.I8)]
        public long AccountUnlock;
    }
}
