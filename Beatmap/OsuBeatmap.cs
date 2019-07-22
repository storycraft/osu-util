using OsuUtil.IO.Struct;
using OsuUtil.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.Beatmap
{
    public class OsuBeatmap
    {
        public string ArtistName;
        public string ArtistNameUnicode;

        public string RankedName;
        public string RankedNameUnicode;

        public string CreatorName;

        public string DiffcultyName;

        public string AudioFileName;

        public string MD5Hash;
        public string OsuFileName;

        public RankedStatus RankedStatus;

        public BeatmapElementCountStruct ElementCount;

        public long LastModification;

        public BeatmapPlayInfoStruct BeatmapPlayInfo;

        public Dictionary<int, double> StarRatingOsu, StarRatingTaiko, StarRatingCTB, StarRatingMania;

        public BeatmapTimeInfo Timeinfo;

        public List<TimingPointStruct> TimingPointList;

        public BeatmapInfoStruct BeatmapInfo;

        public BeatmapGradeStruct BeatmapGrade;

        public BeatmapPlaymodeStruct Playmode;

        public string SongSource;
        public string SongTags;

        public short OnlineOffset;

        public string Font;

        public BeatmapMiscStruct Misc;

        public string SongFolderName;

        public long LastTimeCheck;

        public BeatmapSettingStruct BeatmapSetting; 

        public string MapTag;

        public OsuBeatmap()
        {
            RankedStatus = RankedStatus.UNKNOWN;
            ElementCount = new BeatmapElementCountStruct();
            BeatmapPlayInfo = new BeatmapPlayInfoStruct();

            StarRatingOsu = new Dictionary<int, double>();
            StarRatingTaiko = new Dictionary<int, double>();
            StarRatingCTB = new Dictionary<int, double>();
            StarRatingMania = new Dictionary<int, double>();

            Timeinfo = new BeatmapTimeInfo();
            TimingPointList = new List<TimingPointStruct>();
            BeatmapInfo = new BeatmapInfoStruct();
            BeatmapGrade = new BeatmapGradeStruct();
            Playmode = new BeatmapPlaymodeStruct();

            Misc = new BeatmapMiscStruct();
            BeatmapSetting = new BeatmapSettingStruct();
        }
    }
}
