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
        private Dictionary<string, IBeatmap> BeatmapHashMap { get; }

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

            BeatmapHashMap = new Dictionary<string, IBeatmap>();

            foreach (IBeatmapSet mapSet in beatmapSets.Values)
            {
                foreach (IBeatmap map in mapSet.Beatmaps.Values)
                {
                    BeatmapHashMap.Add(map.Hash, map);
                }
            }
        }

        public bool HasBeatmapSet(int id)
        {
            return BeatmapSets.ContainsKey(id);
        }

        public bool HasBeatmapHash(string hash)
        {
            return BeatmapHashMap.ContainsKey(hash);
        }

        public IBeatmap GetBeatmapByHash(string hash)
        {
            return BeatmapHashMap[hash];
        }
    }
}
