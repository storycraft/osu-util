﻿using OsuUtil.IO.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OsuUtil.IO
{
    public class OsuBinaryWriter : BinaryWriter
    {
        public bool CanRead
        {
            get
            {
                return BaseStream.CanRead;
            }
        }

        public bool CanSeek
        {
            get
            {
                return BaseStream.CanRead;
            }
        }

        public bool CanWrite
        {
            get
            {
                return BaseStream.CanRead;
            }
        }

        public long Length
        {
            get
            {
                return BaseStream.Length;
            }
        }

        public long Position
        {
            get
            {
                return BaseStream.Position;
            }
            set
            {
                BaseStream.Position = value;
            }
        }

        public OsuBinaryWriter(Stream stream)
          : base(stream)
        {
        }

        public OsuBinaryWriter(Stream stream, Encoding encoding)
          : base(stream, encoding)
        {
        }

        public void WriteBytes(byte[] bytes)
        {
            Write(bytes.Length);
            Write(bytes);
        }

        public void WriteString(string str)
        {
            if (str != null)
            {
                Write((byte) 11);
                Write(str);
            }
            else
                Write((byte) 0);
        }

        public void WriteDateTime(DateTime time)
        {
            Write(time.ToBinary());
        }

        public void WriteIntDoublePair(Dictionary<int, double> mods)
        {
            Write(mods.Count);

            foreach (int key in mods.Keys)
            {
                Write((byte) 8);
                Write(key);
                Write((byte) 13);
                Write(mods[key]);
            }
        }

        public void WriteTimingPointList(List<TimingPointStruct> list)
        {
            Write(list.Count);
            foreach (TimingPointStruct timingPoint in list)
                WriteStruct(timingPoint);
        }

        public void WriteStruct<T>(T structure) where T : struct
        {
            byte[] data = new byte[Marshal.SizeOf(typeof(T))];

            IntPtr buff = Marshal.AllocHGlobal(data.Length);
            Marshal.StructureToPtr(structure, buff, false);
            Marshal.Copy(buff, data, 0, data.Length);
            Marshal.FreeHGlobal(buff);

            Write(data);
        }
    }
}
