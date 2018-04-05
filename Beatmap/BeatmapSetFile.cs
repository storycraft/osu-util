using System;
using System.IO;

namespace OsuUtil.Beatmap
{
  public class BeatmapSetFile : IDisposable
  {
    public IBeatmapSet BeatmapSet { get; private set; }

    public Stream Stream { get; private set; }

    public BeatmapSetFile(IBeatmapSet set, Stream stream)
    {
      this.BeatmapSet = set;
      this.Stream = stream;
    }

    public void Dispose()
    {
      this.Stream.Dispose();
      this.BeatmapSet = null;
      this.Stream = null;
    }
  }
}
