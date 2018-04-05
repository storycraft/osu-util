using System;
using System.Runtime.Serialization;

namespace OsuUtil.Exceptions.Local
{
    public class UnSupportedBeatmapSetType : Exception
    {
        public UnSupportedBeatmapSetType(string message)
          : base(message)
        {
        }

        public UnSupportedBeatmapSetType(string message, Exception inner)
          : base(message, inner)
        {
        }

        protected UnSupportedBeatmapSetType(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
