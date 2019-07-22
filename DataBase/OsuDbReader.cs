using OsuUtil.Beatmap;
using OsuUtil.DataBase.Struct;
using OsuUtil.Exceptions.Local;
using OsuUtil.IO;
using OsuUtil.IO.Struct;
using OsuUtil.Status;
using System;
using System.Collections.Generic;
using System.IO;

namespace OsuUtil.DataBase
{
    public class OsuDbReader
    {
        public OsuDb ParseFromStream(Stream dbStream)
        {
            using (OsuBinaryReader reader = new OsuBinaryReader(dbStream))
            {
                OsuDb db = new OsuDb();

                Dictionary<int, OsuBeatmapSet> beatmapSets = new Dictionary<int, OsuBeatmapSet>();
                db.BeatmapSets = beatmapSets;
                db.Info = reader.ReadStruct<OsuDbInfoStruct>();

                bool old = db.Info.Version < 20140609;

                db.PlayerName = reader.ReadString();
                int mapSize = reader.ReadInt32();

                if (old)
                    throw new DbParseException("old osu.db file is not supported. Please update!");

                for (int index = 0; index < mapSize; ++index)
                {
                    OsuBeatmap fromReader = BeatmapParser.ParseFromReader(reader);
                    
                    OsuBeatmapSet beatmapSet;
                    if (beatmapSets.ContainsKey(fromReader.BeatmapInfo.BeatmapSetId))
                    {
                        beatmapSet = beatmapSets[fromReader.BeatmapInfo.BeatmapSetId];
                    }
                    else
                    {
                        beatmapSet = new OsuBeatmapSet(fromReader.RankedName, fromReader.RankedNameUnicode, fromReader.ArtistName, fromReader.ArtistNameUnicode, fromReader.BeatmapInfo.BeatmapSetId, "binary");
                        beatmapSets[beatmapSet.RankedID] = beatmapSet;
                    }

                    beatmapSet.Beatmaps[fromReader.BeatmapInfo.BeatmapId] = fromReader;
                }
                int num2 = reader.ReadByte();

                return db;
            }
        }

        public static class BeatmapParser
        {
            public static OsuBeatmap ParseFromReader(OsuBinaryReader reader)
            {
                int size = reader.ReadInt32();

                OsuBeatmap beatmap = new OsuBeatmap();

                beatmap.ArtistName = reader.ReadString();
                beatmap.ArtistNameUnicode = reader.ReadString();

                beatmap.RankedName = reader.ReadString();
                beatmap.RankedNameUnicode = reader.ReadString();

                beatmap.CreatorName = reader.ReadString();

                beatmap.DiffcultyName = reader.ReadString();

                beatmap.AudioFileName = reader.ReadString();

                beatmap.MD5Hash = reader.ReadString();
                beatmap.OsuFileName = reader.ReadString();

                byte rawRankedStatus = reader.ReadByte();

                if (rawRankedStatus > 8)
                {
                    throw new DbParseException("Ranked status should be smaller than 8. Error while parsing " + beatmap.RankedNameUnicode);
                }

                beatmap.RankedStatus = (RankedStatus)rawRankedStatus;

                beatmap.ElementCount = reader.ReadStruct<BeatmapElementCountStruct>();

                beatmap.LastModification = reader.ReadInt64();

                beatmap.BeatmapPlayInfo = reader.ReadStruct<BeatmapPlayInfoStruct>();

                beatmap.StarRatingOsu = reader.ReadIntDoublePair();
                beatmap.StarRatingTaiko = reader.ReadIntDoublePair();
                beatmap.StarRatingCTB = reader.ReadIntDoublePair();
                beatmap.StarRatingMania = reader.ReadIntDoublePair();

                beatmap.Timeinfo = reader.ReadStruct<BeatmapTimeInfo>();

                beatmap.TimingPointList = reader.ReadTimingPointList();

                beatmap.BeatmapInfo = reader.ReadStruct<BeatmapInfoStruct>();

                beatmap.BeatmapGrade = reader.ReadStruct<BeatmapGradeStruct>();

                beatmap.Playmode = reader.ReadStruct<BeatmapPlaymodeStruct>();

                beatmap.SongSource = reader.ReadString();

                beatmap.SongTags = reader.ReadString();

                beatmap.OnlineOffset = reader.ReadInt16();

                beatmap.Font = reader.ReadString();

                beatmap.Misc = reader.ReadStruct<BeatmapMiscStruct>();

                beatmap.SongFolderName = reader.ReadString();

                beatmap.LastTimeCheck = reader.ReadInt64();

                beatmap.BeatmapSetting = reader.ReadStruct<BeatmapSettingStruct>();

                return beatmap;
            }
        }
    }
}
