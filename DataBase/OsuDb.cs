using OsuUtil.Beatmap;
using OsuUtil.DataBase.Struct;
using System;
using System.Collections.Generic;

namespace OsuUtil.DataBase
{
    public class OsuDb
    {
        public OsuDbInfoStruct Info;

        public string PlayerName;

        public Dictionary<int, OsuBeatmapSet> BeatmapSets { get; }

        public int BeatmapCount
        {
            get
            {
                int all = 0;

                foreach (OsuBeatmapSet set in BeatmapSets.Values)
                {
                    all += set.Beatmaps.Count;
                }

                return all;
            }
        }

        public bool HasBeatmapSet(int id)
        {
            return BeatmapSets.ContainsKey(id);
        }

        public List<OsuBeatmap> GetBeatmapList()
        {
            List<OsuBeatmap> list = new List<OsuBeatmap>(BeatmapCount);

            foreach (OsuBeatmapSet set in BeatmapSets.Values)
            {
                list.AddRange(set.Beatmaps.Values);
            }

            return list;
        }

        public OsuBeatmap GetBeatmapByHash(string hash)
        {
            if (hash == null || "".Equals(hash))
                return null;

            foreach (OsuBeatmapSet mapSet in BeatmapSets.Values)
            {
                foreach (OsuBeatmap map in mapSet.Beatmaps.Values)
                {
                    if (hash.Equals(map.MD5Hash))
                        return map;
                }
            }

            return null;
        }
    }
}
