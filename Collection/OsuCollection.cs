using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.Collection
{
    public class OsuCollection
    {
        public string Name;
        public List<string> BeatmapHashList;

        public OsuCollection()
        {
            BeatmapHashList = new List<string>();
        }
    }
}
