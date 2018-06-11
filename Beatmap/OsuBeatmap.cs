using System.Collections.Generic;

namespace OsuUtil.Beatmap
{
    public class OsuBeatmap : IBeatmap
    {
        public string RankedName { get; }

        public string RankedNameUnicode { get; }

        public string Artist { get; }

        public string ArtistUnicode { get; }

        public List<string> Tags { get; }

        public int Id { get; }

        public int SetId { get; }

        public string DiffcultyName { get; }

        public string SongFolderName { get; }

        public string OsuFileName { get; }

        public string AudioFileName { get; }

        public string Creator { get; }

        public string Hash { get; }

        public OsuBeatmap(string rankedName, string rankedNameUnicode, string artist, string artistUnicode, List<string> tags, string creator, string diffcultyName, string songFolderName, string osuFileName, string audioFileName, int id, int setId, string hash)
        {
            RankedName = rankedName;
            RankedNameUnicode = rankedNameUnicode;
            Artist = artist;
            ArtistUnicode = artistUnicode;
            Tags = tags;
            Creator = creator;
            DiffcultyName = diffcultyName;
            SongFolderName = songFolderName;
            OsuFileName = osuFileName;
            AudioFileName = audioFileName;
            Id = id;
            SetId = id;
            Hash = hash;
        }
    }
}
