using System.Collections.Generic;

namespace OsuUtil.Beatmap
{
    public interface IBeatmap
    {
        int Id { get; }

        string RankedNameUnicode { get; }

        string Artist { get; }

        string ArtistUnicode { get; }

        List<string> Tags { get; }

        int SetId { get; }

        string RankedName { get; }

        string Creator { get; }

        string DiffcultyName { get; }

        string SongFolderName { get; }

        string OsuFileName { get; }

        string AudioFileName { get; }

        string Hash { get; }
    }
}
