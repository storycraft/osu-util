using OsuUtil.Beatmap;
using OsuUtil.DataBase.Struct;
using OsuUtil.IO;
using OsuUtil.IO.Struct;
using System.IO;

namespace OsuUtil.DataBase
{
    public class OsuDbWriter
    {
        public bool WriteToBinary(OsuDb osuDb, Stream stream)
        {
            if (osuDb == null)
                return false;

            using (OsuBinaryWriter writer = new OsuBinaryWriter(stream))
            {
                writer.WriteStruct<OsuDbInfoStruct>(osuDb.Info);
                writer.WriteString(osuDb.PlayerName);

                int count = osuDb.BeatmapCount;
                writer.Write(count);

                foreach (OsuBeatmapSet set in osuDb.BeatmapSets.Values)
                {
                    foreach (OsuBeatmap beatmap in set.Beatmaps.Values)
                    {
                        BeatmapParser.WriteToWriter(writer, beatmap);
                    }
                }
            }

            return true;
        }


    }

    public static class BeatmapParser
    {
        public static void WriteToWriter(OsuBinaryWriter osuWriter, OsuBeatmap beatmap)
        {
            MemoryStream writtenData = new MemoryStream();
            using (OsuBinaryWriter writer = new OsuBinaryWriter(writtenData))
            {
                writer.WriteString(beatmap.ArtistName);
                writer.WriteString(beatmap.ArtistNameUnicode);

                writer.WriteString(beatmap.RankedName);
                writer.WriteString(beatmap.RankedNameUnicode);

                writer.WriteString(beatmap.CreatorName);

                writer.WriteString(beatmap.DiffcultyName);

                writer.WriteString(beatmap.AudioFileName);

                writer.WriteString(beatmap.MD5Hash);
                writer.WriteString(beatmap.OsuFileName);

                writer.Write((byte)beatmap.RankedStatus);

                writer.WriteStruct<BeatmapElementCountStruct>(beatmap.ElementCount);

                writer.Write(beatmap.LastModification);

                writer.WriteStruct<BeatmapPlayInfoStruct>(beatmap.BeatmapPlayInfo);

                writer.WriteIntDoublePair(beatmap.StarRatingOsu);
                writer.WriteIntDoublePair(beatmap.StarRatingTaiko);
                writer.WriteIntDoublePair(beatmap.StarRatingCTB);
                writer.WriteIntDoublePair(beatmap.StarRatingMania);

                writer.WriteStruct<BeatmapTimeInfo>(beatmap.Timeinfo);

                writer.WriteTimingPointList(beatmap.TimingPointList);

                writer.WriteStruct<BeatmapGradeStruct>(beatmap.BeatmapGrade);

                writer.WriteStruct<BeatmapPlaymodeStruct>(beatmap.Playmode);

                writer.WriteString(beatmap.SongSource);
                writer.WriteString(beatmap.SongTags);

                writer.Write(beatmap.OnlineOffset);

                writer.WriteString(beatmap.Font);

                writer.WriteStruct<BeatmapMiscStruct>(beatmap.Misc);

                writer.WriteString(beatmap.SongFolderName);

                writer.Write(beatmap.LastTimeCheck);

                writer.WriteStruct<BeatmapSettingStruct>(beatmap.BeatmapSetting);
            }

            osuWriter.Write(writtenData.Length);
            osuWriter.Write(writtenData.ToArray());
        }
    }
}
