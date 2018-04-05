using System;
using System.Runtime.Serialization;

namespace OsuUtil.Exceptions.Local
{
    internal class BeatmapParseException : Exception
    {
        public BeatmapParseException(string message)
          : base(message)
        {
        }

        public BeatmapParseException(string message, Exception inner)
          : base(message, inner)
        {
        }

        protected BeatmapParseException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
