using OsuUtil.Beatmap;
using System.Collections.Generic;

namespace OsuUtil.DataBase
{
    public interface BeatmapDb
    {
        Dictionary<int, IBeatmapSet> BeatmapSets { get; }

        bool HasBeatmapHash(string hash);
        IBeatmap GetBeatmapByHash(string hash);

        bool HasBeatmapSet(int id);
    }
}
