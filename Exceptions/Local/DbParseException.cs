using System;
using System.Runtime.Serialization;

namespace OsuUtil.Exceptions.Local
{
    internal class DbParseException : Exception
    {
        public DbParseException(string message)
          : base(message)
        {
        }

        public DbParseException(string message, Exception inner)
          : base(message, inner)
        {
        }

        protected DbParseException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
