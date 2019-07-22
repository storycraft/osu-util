using OsuUtil.IO.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OsuUtil.IO
{
    public class OsuBinaryReader : BinaryReader
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

        public OsuBinaryReader(Stream stream)
          : base(stream)
        {
        }

        public OsuBinaryReader(Stream stream, Encoding encoding)
          : base(stream, encoding)
        {
        }

        public byte[] ReadBytes()
        {
            int count = ReadInt32();

            if (count <= 0)
                return new byte[0];

            return ReadBytes(count);
        }

        public override string ReadString()
        {
            byte num = ReadByte();
            switch (num)
            {
                case 0:
                    return "";
                case 11:
                    return base.ReadString();
                default:
                    throw new Exception(string.Format("Type byte must 0x00 or 0x11, but readed 0x{0:X2} at {1})", (object)num, (object)this.Position));
            }
        }

        public DateTime ReadDateTime()
        {
            return DateTime.FromBinary(ReadInt64());
        }

        public Dictionary<int, double> ReadIntDoublePair()
        {
            int num1 = ReadInt32();

            Dictionary<int, double> dictionary = new Dictionary<int, double>();
            for (int index1 = 0; index1 < num1; ++index1)
            {
                int num2 = ReadByte();
                int index2 = ReadInt32();
                int num3 = ReadByte();
                double num4 = ReadDouble();
                dictionary[index2] = num4;
            }

            return dictionary;
        }

        public List<TimingPointStruct> ReadTimingPointList()
        {
            List<TimingPointStruct> timingPointList = new List<TimingPointStruct>();
            int num = ReadInt32();

            for (int index = 0; index < num; ++index)
            {
                timingPointList.Add(ReadStruct<TimingPointStruct>());
            }

            return timingPointList;
        }

        public T ReadStruct<T>() where T : struct
        {
            byte[] buffer = ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T structure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return structure;
        }
    }
}
