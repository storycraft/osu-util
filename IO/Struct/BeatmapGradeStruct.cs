using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BeatmapGradeStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int GradeOsu;
        [MarshalAs(UnmanagedType.I4)]
        public int GradeTaiko;
        [MarshalAs(UnmanagedType.I4)]
        public int GradeCTB;
        [MarshalAs(UnmanagedType.I4)]
        public int GradeMania;
    }
}
