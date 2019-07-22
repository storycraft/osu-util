using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.IO.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BeatmapGradeStruct
    {
        [MarshalAs(UnmanagedType.I1)]
        public byte GradeOsu;
        [MarshalAs(UnmanagedType.I1)]
        public byte GradeTaiko;
        [MarshalAs(UnmanagedType.I1)]
        public byte GradeCTB;
        [MarshalAs(UnmanagedType.I1)]
        public byte GradeMania;
    }
}
