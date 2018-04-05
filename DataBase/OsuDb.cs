using OsuUtil.Beatmap;
using System;
using System.Collections.Generic;

namespace OsuUtil.DataBase
{
    public class OsuDb : BeatmapDb
    {
        public int Version { get; }

        public int FolderCount { get; }

        public bool AccountLocked { get; }

        public DateTime AccountUnlock { get; }

        public string PlayerName { get; }

        public Dictionary<int, IBeatmapSet> BeatmapSets { get; }

        public int BeatmapCount
        {
            get
            {
                return BeatmapSets.Count;
            }
        }

        public OsuDb(int version, int folderCount, bool AccountLocked, DateTime AccountUnlock, string PlayerName, Dictionary<int, IBeatmapSet> beatmapSets)
        {
            BeatmapSets = beatmapSets;
            Version = version;
        }

        public bool HasBeatmapSet(int id)
        {
            return BeatmapSets.ContainsKey(id);
        }
    }
}
