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
            try
            {
                using (OsuBinaryReader reader = new OsuBinaryReader((Stream)dbStream))
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
                        IBeatmap fromReader = OsuDbReader.BeatmapParser.ParseFromReader(reader, old);
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
            catch (Exception ex)
            {
                throw new BeatmapParseException(string.Format("Failed to parse Db {0}", dbStream.Name), ex);
            }
        }

        private static class BeatmapParser
        {
            public static IBeatmap ParseFromReader(OsuBinaryReader reader, bool old)
            {
                reader.ReadInt32();
                string str1 = reader.ReadString();
                string str2 = reader.ReadString();
                string rankedName = reader.ReadString();
                string str3 = reader.ReadString();
                string str4 = reader.ReadString();
                string str5 = reader.ReadString();
                string str6 = reader.ReadString();
                reader.ReadString();
                reader.ReadString();
                int num1 = reader.ReadByte();
                int num2 = reader.ReadInt16();
                int num3 = reader.ReadInt16();
                int num4 = reader.ReadInt16();
                reader.ReadInt64();
                if (old)
                {
                    int num5 = reader.ReadByte();
                    int num6 = reader.ReadByte();
                    int num7 = reader.ReadByte();
                    int num8 = reader.ReadByte();
                }
                else
                {
                    double num5 = reader.ReadSingle();
                    double num6 = reader.ReadSingle();
                    double num7 = reader.ReadSingle();
                    double num8 = reader.ReadSingle();
                }
                reader.ReadDouble();

                if (!old)
                {
                    reader.ReadIntDoublePair();
                    reader.ReadIntDoublePair();
                    reader.ReadIntDoublePair();
                    reader.ReadIntDoublePair();
                }

                reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadTimingPointList();
                int num9 = reader.ReadInt32();
                int num10 = reader.ReadInt32();
                reader.ReadInt32();
                int num11 = reader.ReadByte();
                int num12 = reader.ReadByte();
                int num13 = reader.ReadByte();
                int num14 = reader.ReadByte();
                int num15 = reader.ReadInt16();
                double num16 = reader.ReadSingle();
                int num17 = reader.ReadByte();
                reader.ReadString();
                string str7 = reader.ReadString();
                int num18 = reader.ReadInt16();
                reader.ReadString();
                reader.ReadBoolean();
                reader.ReadInt64();
                reader.ReadBoolean();
                reader.ReadString();
                reader.ReadInt64();
                reader.ReadBoolean();
                reader.ReadBoolean();
                reader.ReadBoolean();
                reader.ReadBoolean();
                reader.ReadBoolean();

                if (old)
                {
                    int num19 = reader.ReadInt16();
                }

                reader.ReadInt32();
                int num20 = reader.ReadByte();
                string rankedNameUnicode = str3;
                string artist = str1;
                string artistUnicode = str2;
                List<string> tags = new List<string>(str7.Split(' '));
                string creator = str4;
                string diffcultyName = str5;
                string audioFileName = str6;
                int id = num9;
                int setId = num10;

                return new OsuBeatmap(rankedName, rankedNameUnicode, artist, artistUnicode, tags, creator, diffcultyName, audioFileName, id, setId);
            }
        }
    }
}
