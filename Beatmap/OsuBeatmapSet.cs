using System.Collections.Generic;

namespace OsuUtil.Beatmap
{
    public class OsuBeatmapSet
    {
        public string RankedName { get; }

        public string RankedNameUnicode { get; }

        public string Artist { get; }

        public string ArtistUnicode { get; }

        public string PackageType { get; }

        public int RankedID { get; }

        public Dictionary<int, OsuBeatmap> Beatmaps { get; }

        public OsuBeatmapSet(string rankedName, string rankedNameUnicode, string artist, string artistUnicod, int rankedId, string packageType)
        {
            Beatmaps = new Dictionary<int, OsuBeatmap>();
            RankedName = rankedName;
            RankedID = rankedId;
            PackageType = packageType;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return RankedID == ((OsuBeatmapSet)obj).RankedID;
        }
    }
}
