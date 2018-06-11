using OsuUtil.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.DataBase
{
    public class OsuCollectionReader
    {
        public static OsuCollectionDb ParseFromStream(FileStream dbStream)
        {
            Dictionary<string, List<string>> collectionSet = new Dictionary<string, List<string>>();

            using (OsuBinaryReader reader = new OsuBinaryReader(dbStream))
            {
                int version = reader.ReadInt32();
                int collectionCount = reader.ReadInt32();

                for (int i = 0; i < collectionCount; i++)
                {
                    String name = reader.ReadString();

                    List<string> beatmapHashList = new List<string>(); 

                    int count = reader.ReadInt32();

                    for (int j = 0; j < count; j++)
                    {
                        String hash = reader.ReadString();
                        beatmapHashList.Add(hash);
                    }

                    collectionSet.Add(name, beatmapHashList);
                }
            }

            return new OsuCollectionDb(collectionSet);
        }
    }
}
