using OsuUtil.Collection;
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
        public OsuCollectionDb ParseFromStream(Stream dbStream)
        {
            OsuCollectionDb db = new OsuCollectionDb();

            using (OsuBinaryReader reader = new OsuBinaryReader(dbStream))
            {
                List<OsuCollection> collectionSet = new List<OsuCollection>();

                db.Version = reader.ReadInt32();
                db.CollectionList = collectionSet;
                int collectionCount = reader.ReadInt32();

                for (int i = 0; i < collectionCount; i++)
                {
                    OsuCollection collection = new OsuCollection();
                    collection.BeatmapHashList = new List<string>();

                    collection.Name = reader.ReadString();

                    List<string> beatmapHashList = new List<string>(); 

                    int count = reader.ReadInt32();

                    for (int j = 0; j < count; j++)
                    {
                        String hash = reader.ReadString();
                        collection.BeatmapHashList.Add(hash);
                    }

                    collectionSet.Add(collection);
                }
            }

            return db;
        }
    }
}
