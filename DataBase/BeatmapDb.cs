using OsuUtil.Beatmap;
using System.Collections.Generic;

namespace OsuUtil.DataBase
{
    public interface BeatmapDb
    {
        Dictionary<int, IBeatmapSet> BeatmapSets { get; }

        bool HasBeatmapSet(int id);
    }
}
