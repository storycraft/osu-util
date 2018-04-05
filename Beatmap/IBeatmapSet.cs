using System.Collections.Generic;

namespace OsuUtil.Beatmap
{
    public interface IBeatmapSet
    {
        string RankedName { get; }

        string RankedNameUnicode { get; }

        string Artist { get; }

        string ArtistUnicode { get; }

        List<string> Tags { get; }

        string PackageType { get; }

        int RankedID { get; }

        Dictionary<int, IBeatmap> Beatmaps { get; }
    }
}
