using OsuUtil.Beatmap;
using OsuUtil.Exceptions.Local;
using OsuUtil.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace OsuUtil.DataBase
{
    public static class OsuDbReader
    {
        public static OsuDb ParseFromStream(FileStream dbStream)
        {
            using (OsuBinaryReader reader = new OsuBinaryReader(dbStream))
            {
                Dictionary<int, IBeatmapSet> beatmapSets = new Dictionary<int, IBeatmapSet>();
                int version = reader.ReadInt32();
                bool old = version < 20140609;
                int folderCount = reader.ReadInt32();
                bool AccountLocked = reader.ReadBoolean();
                DateTime AccountUnlock = reader.ReadDateTime();
                string PlayerName = reader.ReadString();
                int num1 = reader.ReadInt32();
                for (int index = 0; index < num1; ++index)
                {
                    IBeatmap fromReader = BeatmapParser.ParseFromReader(reader, old);
                    IBeatmapSet beatmapSet;
                    if (beatmapSets.ContainsKey(fromReader.SetId))
                    {
                        beatmapSet = beatmapSets[fromReader.SetId];
                    }
                    else
                    {
                        beatmapSet = new OsuBeatmapSet(fromReader.RankedName, fromReader.RankedNameUnicode, fromReader.Artist, fromReader.ArtistUnicode, fromReader.Tags, fromReader.SetId, "binary");
                        beatmapSets[beatmapSet.RankedID] = beatmapSet;
                    }
                    beatmapSet.Beatmaps[fromReader.Id] = fromReader;
                }
                int num2 = reader.ReadByte();
                return new OsuDb(version, folderCount, AccountLocked, AccountUnlock, PlayerName, beatmapSets);
            }
        }

        private static class BeatmapParser
        {
            public static IBeatmap ParseFromReader(OsuBinaryReader reader, bool old)
            {
                int size = reader.ReadInt32();
                string artistName = reader.ReadString();
                string artistNameUnicode = reader.ReadString();

                string rankedName = reader.ReadString();
                string rankedNameUnicode = reader.ReadString();

                string creatorName = reader.ReadString();

                string diffcultyName = reader.ReadString();

                string audioFileName = reader.ReadString();

                string md5Hash = reader.ReadString();
                string osuFileName = reader.ReadString();

                int rankedStatus = reader.ReadByte();

                int hitcircleCount = reader.ReadInt16();
                int sliderCount = reader.ReadInt16();
                int spinnerCount = reader.ReadInt16();

                long lastModification = reader.ReadInt64();

                double approachRate, circieSize, hpDrain, overallDiffculty;
                if (old)
                {
                    approachRate = reader.ReadByte();
                    circieSize = reader.ReadByte();
                    hpDrain = reader.ReadByte();
                    overallDiffculty = reader.ReadByte();
                }
                else
                {
                    approachRate = reader.ReadSingle();
                    circieSize = reader.ReadSingle();
                    hpDrain = reader.ReadSingle();
                    overallDiffculty = reader.ReadSingle();
                }

                double sliderVelocity = reader.ReadDouble();

                Dictionary<int, double> starRatingOsu, starRatingTaiko, starRatingCTB, starRatingMania;
                if (!old)
                {
                    starRatingOsu = reader.ReadIntDoublePair();
                    starRatingTaiko = reader.ReadIntDoublePair();
                    starRatingCTB = reader.ReadIntDoublePair();
                    starRatingMania = reader.ReadIntDoublePair();
                }

                int drainTime = reader.ReadInt32();
                int totalTime = reader.ReadInt32();
                int previewStart = reader.ReadInt32();

                List<TimingPoint> timingPointList = reader.ReadTimingPointList();

                int beatmapId = reader.ReadInt32();
                int beatmapSetId = reader.ReadInt32();
                int threadId = reader.ReadInt32();

                int gradeOsu = reader.ReadByte();
                int gradeTaiko = reader.ReadByte();
                int gradeCTB = reader.ReadByte();
                int gradeMania = reader.ReadByte();

                int localOffset = reader.ReadInt16();

                double stackLeniency = reader.ReadSingle();

                byte gameplayMode = reader.ReadByte();

                string songSource = reader.ReadString();
                string songTags = reader.ReadString();

                int onlineOffset = reader.ReadInt16();

                string font = reader.ReadString();

                bool unplayed = reader.ReadBoolean();

                long lastPlay = reader.ReadInt64();

                bool isOsz2 = reader.ReadBoolean();

                string songFolderName = reader.ReadString();

                long lastTimeCheck = reader.ReadInt64();

                bool isIgnoreBeatmapSound = reader.ReadBoolean();
                bool IsIgnoreBeatmapSkin = reader.ReadBoolean();
                bool isStoryboardDisabled = reader.ReadBoolean();
                bool isVideoDisabled = reader.ReadBoolean();
                bool isVisualOverrided = reader.ReadBoolean();

                if (old)
                {
                    int unknown = reader.ReadInt16();
                }

                int unknown2 = reader.ReadInt32();

                int maniaScrollSpeed = reader.ReadByte();

                List<string> tags = new List<string>(songTags.Split(' '));

                return new OsuBeatmap(rankedName, rankedNameUnicode, artistName, artistNameUnicode, tags, creatorName, diffcultyName, songFolderName, osuFileName, audioFileName, beatmapId, beatmapSetId, md5Hash);
            }
        }
    }
}
