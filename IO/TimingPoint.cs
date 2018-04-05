using System.IO;

namespace OsuUtil.IO
{
    public class TimingPoint
    {
        public double Time;
        public double MsPerQuarter;
        public bool TimingChange;

        public void WriteToWriter(BinaryWriter writer)
        {
            writer.Write(MsPerQuarter);
            writer.Write(Time);
            writer.Write(TimingChange);
        }

        public static TimingPoint ReadFromReader(BinaryReader r)
        {
            return new TimingPoint()
            {
                MsPerQuarter = r.ReadDouble(),
                Time = r.ReadDouble(),
                TimingChange = (uint)r.ReadByte() > 0U
            };
        }
    }
}
